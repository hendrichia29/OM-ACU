Public Class FormTrPenerimaanBahanMentahM
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim tabelH As String
    Dim tabelD As String
    Dim NamaBahanMentah As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""
    Dim query As String = ""
    Dim jenis_pb As String
    Dim jml_satuan2 = 0
    Dim nama_satuan2 = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Function getRealQty(ByVal kdBahanMentah As String)
        Dim sqlRealQty = " SELECT SUM(trdetailpo.jumlah) -  " & _
                        " IFNULL( (  " & _
                        "   SELECT SUM(trdetailpb.Qty) FROM trdetailpb " & _
                        "   JOIN trheaderpb ON trheaderpb.No_PB = trheaderpb.No_PB " & _
                        "   WHERE trheaderpb.No_PO = trheaderpo.No_PO " & _
                        "   AND StatusTerimaBarang > 0 " & _
                        "   AND trdetailpb.kdbahanmentah = trdetailpo.kdbahanmentah " & _
                        "   GROUP BY trdetailpb.kdbahanmentah, trheaderpb.No_PO " & _
                        " ) , 0 ) qty,  " & _
                        " trdetailpo.kdbahanmentah " & _
                        " FROM trdetailpo " & _
                        " JOIN trheaderpo ON  trheaderpo.No_PO = trdetailpo.No_PO  " & _
                        " WHERE trdetailpo.No_PO = '" & cmbPO.Text & "'  " & _
                        " AND StatusPO > 0 " & _
                        " AND trdetailpo.kdbahanmentah = '" & kdBahanMentah & "' " & _
                        " AND jenis_po = '" & jenis_pb & "' " & _
                        " GROUP BY trdetailpo.kdbahanmentah,trheaderpo.No_PO "
        Dim readerRealQty = execute_reader(sqlRealQty)
        If readerRealQty.read Then
            Return readerRealQty("qty")
        End If
        readerRealQty.close()
        Return 0
    End Function

    Private Sub setData()
        Try
            Dim Supplier = ""
            Dim kdPO = ""
            Dim readerPB = execute_reader(" select No_PB,DATE_FORMAT(Tanggal_TerimaBarang, '%d %M %Y') Tanggal, " & _
                                          " PO.No_PO,Tanggal_PO, MS.KdSupplier, MS.Nama, " & _
                                          " StatusTerimaBarang, PB.Disc disc_pb " & _
                                          " from trheaderpb PB " & _
                                          " Join trheaderpo PO On  PO.No_PO = PB.No_PO " & _
                                          " Join MsSupplier MS On MS.KdSupplier = PB.KdSupplier " & _
                                          " Where No_PB = '" & PK & "' ")
            If readerPB.Read Then
                txtID.Text = readerPB.Item("No_PB")
                dtpPB.Text = readerPB.Item("Tanggal")
                kdPO = readerPB.Item("No_PO")
                txtTglPO.Text = readerPB.Item("Tanggal_PO").ToString
                txtKdSupplier.Text = readerPB.Item("KdSupplier").ToString
                txtSupplier.Text = readerPB.Item("Nama")
                txt_disc_faktur.Text = readerPB.Item("disc_pb")
                If readerPB.Item("StatusTerimaBarang") > 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerPB.Close()

            cmbPO.Text = kdPO

            Dim reader = execute_reader(" Select BM.KdBahanMentah, NamaBahanMentah, Ukuran, " & _
                                        " Satuan, Harga, PB.Qty, " & _
                                        " PB.Disc,QtyPenerimaan, PB.Qty_real " & _
                                        " from trdetailpb PB " & _
                                        " JOIN  trheaderpb ON trheaderpb.No_PB = PB.No_PB " & _
                                        " Join MsBahanMentah BM On PB.kdbahanmentah = BM.KdBahanMentah " & _
                                        " where PB.No_PB = '" & PK & "' " & _
                                        " order by NamaBahanMentah asc ")
            gridBahanMentah.Rows.Clear()
            Do While reader.Read
                Dim Subtotal = (Val(reader("Harga")) * Val(reader("Qty")))

                gridBahanMentah.Rows.Add()
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty2").Value = reader("Qty_real")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQtyReal").Value = reader("QtyPenerimaan")
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub emptyField()
        dtpPB.Text = Now()
        cmbPO.SelectedIndex = 0
        txtTglPO.Text = ""
        txtKdSupplier.Text = ""
        txtSupplier.Text = ""
        gridBahanMentah.Rows.Clear()
    End Sub

    Private Sub deleteTabelTemp()
        query = " delete from trheaderpb_t where   no_pb='" & txtID.Text & "'  "
        Try
            execute_update(query)
        Catch ex As Exception
            msgWarning("Error")
        End Try
    End Sub

    Private Sub FormTrPenerimaanBarangM_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'delete data sampah
        deleteTabelTemp()
    End Sub

    Private Sub setCmbPO()
        Dim addQuery = ""
        cmbPO.Items.Clear()
        cmbPO.Items.Add("- Pilih PO -")

        If PK <> "" Then
            addQuery = " And exists( Select 1 from trheaderpb where No_PB = '" & PK & "' And No_PO = TrHeaderPO.No_PO )"
            cmbPO.Enabled = False
            BrowsePO.Enabled = False
        Else
            addQuery &= " And StatusPO = 1 And Not Exists( " & _
                       "    Select 1 from trdetailpb " & _
                       "    Join trheaderpb On trheaderpb.No_PB = trdetailpb.No_PB " & _
                       "    where trheaderpb.No_PO = trdetailpo.No_PO " & _
                       "    And kdbahanmentah = trdetailpo.kdbahanmentah " & _
                       "    Group by trheaderpb.No_PO " & _
                       "    HAVING SUM(qty) - trdetailpo.jumlah = 0 " & _
                       " ) "
        End If

        sql = " Select DISTINCT TrHeaderPO.no_po from TrHeaderPO " & _
              " Join trdetailpo On trdetailpo.no_po = TrHeaderPO.no_po " & _
              " Join msuser On msuser.UserID = TrHeaderPO.UserID " & _
              " where 1 " & _
              " And jenis_po = '" & jenis_pb & "' " & _
              addQuery & _
              " GROUP BY TrHeaderPO.No_PO " & _
              " ORDER BY no_increment DESC "

        Dim reader = execute_reader(sql)
        Do While reader.Read
            cmbPO.Items.Add(reader.GetString(0))
        Loop
        reader.Close()
        If cmbPO.Items.Count > 0 Then
            cmbPO.SelectedIndex = 0
        End If
    End Sub

    Private Sub FormTrPenerimaanBarangM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tabelH = " TrHeaderPB "
        tabelD = " TrDetailPB "
        PK = " No_PB"

        PK = data_carier(0)
        status = data_carier(1)
        jenis_pb = data_carier(2)

        If jenis_pb = "klem" Then
            Me.Text = "Penerimaan Klem Mentah"
            jml_satuan2 = 30
            nama_satuan2 = "Karung"
        Else
            Me.Text = "Penerimaan Paku"
            jml_satuan2 = 25
            nama_satuan2 = "Kardus"
        End If

        clear_variable_array()
        gridBahanMentah.Columns("clmQty2").HeaderText = "Jumlah ( " & nama_satuan2 & " )"
        setCmbPO()

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If

        'insert to header pb temp
        Dim tabel As String = " TrHeaderPO_T "
        sql = "insert into " & tabel & " values ('" & txtID.Text & "')"
        Try
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub


    Private Sub generateCode()
        Dim code As String = "PB"
        Dim angka As Integer
        Dim kode As String = ""
        Dim temp As String
        Dim bulan As Integer = CInt(Today.Month.ToString)
        code += Today.Year.ToString.Substring(2, 2)
        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If

        'generate code
        sql = " select no_PB from  TrHeaderPB order by no_increment desc limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("no_PB")
        Else
            reader.Close()
            sql = " select no_PB from  TrHeaderPB_T  order by no_increment  desc limit 1"
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("no_PB")
            Else
                kode = ""
            End If
            reader2.Close()
        End If
        reader.Close()
        reader = Nothing

        If kode <> "" Then
            temp = kode.Substring(0, 6)
            If temp = code Then
                angka = CInt(kode.Substring(6, 4))
            Else
                angka = 0
            End If

        Else
            angka = 0
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub


    Private Sub cmbPO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPO.SelectedIndexChanged
        If cmbPO.SelectedIndex <> 0 Then
            sql = " select hpo.kdsupplier,nama,DATE_FORMAT(tanggal_po,'%d %M %Y') " & _
                  " from  TrHeaderPO hpo " & _
                  " join mssupplier s on s.kdsupplier=hpo.kdsupplier " & _
                  " where no_PO = '" & cmbPO.Text & "' " & _
                  " And jenis_po = '" & jenis_pb & "' "
            Dim reader = execute_reader(sql)
            If reader.Read() Then
                txtKdSupplier.Text = reader(0)
                txtSupplier.Text = reader(1)
                txtTglPO.Text = reader(2).ToString
            End If
            reader.Close()

            reader = Nothing
            'sql = " select dpo.kdbahanmentah,namaBahanMentah,Ukuran,Satuan, " & _
            '      " dpo.harga,dpo.jumlah - ifnull(thp.Qty,0) jumlah," & _
            '      " dpo.jumlah*dpo.harga  `total` " & _
            '      " from  TrdetailPO dpo " & _
            '      " join msBahanMentah b on b.kdBahanMentah=dpo.kdbahanmentah " & _
            '      " Left JOIN ( Select sum(tdp.Qty) Qty, thp.No_PO, tdp.kdbahanmentah " & _
            '      " from trdetailpb tdp " & _
            '      " Join trheaderpb thp On tdp.No_PB = thp.No_PB " & _
            '      " Group By thp.No_PO, tdp.kdbahanmentah ) thp On thp.kdbahanmentah = dpo.kdbahanmentah " & _
            '      " And thp.No_PO = dpo.No_PO " & _
            '      " where dpo.no_PO='" & cmbPO.Text & "' " & _
            '      " AND dpo.jumlah - ifnull(thp.Qty,0) <> 0 "
            sql = " SELECT dpo.kdbahanmentah,namaBahanMentah,Ukuran,Satuan, " & _
                " dpo.harga,dpo.jumlah - IFNULL(( " & _
                "   Select SUM(tdp.Qty) " & _
                "   FROM trdetailpb tdp " & _
                "   JOIN trheaderpb thp ON tdp.No_PB = thp.No_PB  " & _
                "   WHERE tdp.kdbahanmentah = dpo.kdbahanmentah " & _
                "   AND thp.No_PO = dpo.No_PO " & _
                "   GROUP BY thp.No_PO, tdp.kdbahanmentah " & _
                " ),0) jumlah, " & _
                " dpo.jumlah*dpo.harga  `total` " & _
                " FROM  TrdetailPO dpo " & _
                " JOIN msBahanMentah b ON b.kdBahanMentah=dpo.kdbahanmentah " & _
                " WHERE dpo.no_PO='" & cmbPO.Text & "' " & _
                " GROUP BY dpo.KdBahanMentah " & _
                " HAVING jumlah <> 0 "
            reader = execute_reader(sql)
            Dim harga As Double = 0
            gridBahanMentah.Rows.Clear()
            Do While reader.Read
                gridBahanMentah.Rows.Add()
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = Trim(reader("kdbahanmentah"))
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = Trim(reader("namaBahanMentah"))
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = Trim(reader("Ukuran"))
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("harga"), 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = Val(reader("jumlah"))
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty2").Value = Val(reader("jumlah")) / jml_satuan2
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = 0
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(reader("total"), 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQtyReal").Value = reader("jumlah")
            Loop
            reader.Close()

            HitungTotal()
        Else
            emptyField()
        End If
    End Sub


    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBahanMentah.CellEndEdit
        Try
            If gridBahanMentah.CurrentRow.Cells("clmHarga").Value <> "" Then
                gridBahanMentah.CurrentRow.Cells("clmHarga").Value = gridBahanMentah.CurrentRow.Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            End If
            Dim harga = Val(gridBahanMentah.CurrentRow.Cells("clmHarga").Value)
            Dim qty = Val(gridBahanMentah.CurrentRow.Cells("clmQty").Value)
            Dim Disc = Val(gridBahanMentah.CurrentRow.Cells("clmDisc").Value)
            Dim RealPenerimaan = Val(gridBahanMentah.CurrentRow.Cells("clmQtyReal").Value)

            If Val(gridBahanMentah.CurrentRow.Cells("clmQty").Value) = 0 Or qty Mod jml_satuan2 <> 0 Or qty > RealPenerimaan Then
                MsgBox("Jumlah harus berupa angka dan lebih kecil dari " & RealPenerimaan & " dan kelipatan " & jml_satuan2, MsgBoxStyle.Information, "Validation Error")
                qty = jml_satuan2
                gridBahanMentah.CurrentRow.Cells("clmQty").Value = qty
                gridBahanMentah.CurrentRow.Cells("clmQty2").Value = 1
                gridBahanMentah.CurrentRow.Cells("clmQty").Selected = True
            ElseIf IsNumeric(gridBahanMentah.CurrentRow.Cells("clmDisc").Value) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                Disc = 0
                gridBahanMentah.CurrentRow.Cells("clmDisc").Value = 0
                gridBahanMentah.CurrentRow.Cells("clmDisc").Selected = True
            ElseIf IsNumeric(harga) = False Then
                MsgBox("Harga harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                harga = 1
                gridBahanMentah.CurrentRow.Cells("clmHarga").Value = 1
                gridBahanMentah.CurrentRow.Cells("clmHarga").Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                gridBahanMentah.CurrentRow.Cells("clmHarga").Value = TempHarga
            End If
            gridBahanMentah.CurrentRow.Cells("clmQty2").Value = qty / jml_satuan2
            gridBahanMentah.CurrentRow.Cells("clmSubtotal").Value = FormatNumber((Val(harga) * Val(qty)) * ((100 - Val(Disc)) / 100), 0)
            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBahanMentah.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBahanMentah.Rows.Count - 1)
                    Dim total = gridBahanMentah.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            calc_disc_faktur()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Function SavePBDetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim StatusTerimaBahanMentah = ""
        Dim statusPenerimaan = 0

        For i As Integer = 0 To gridBahanMentah.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBahanMentah.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBahanMentah.Rows.Item(i).Cells("clmQty").Value)
            Dim Qty_real = Val(gridBahanMentah.Rows.Item(i).Cells("clmQty2").Value)
            Dim disc = Val(gridBahanMentah.Rows.Item(i).Cells("clmDisc").Value)
            Dim OP = "Plus"
            Dim Attribute = "QtyPurchase_Plus"
            Dim KdBahanMentah = gridBahanMentah.Rows.Item(i).Cells("clmPartNo").Value
            Dim realQty = getRealQty(KdBahanMentah)
            Dim HargaDisc = (Val(harga)) * ((100 - Val(disc)) / 100)
            If flag = 1 Then
                StockBahanMentah(Qty_real, OP, HargaDisc, KdBahanMentah, Attribute, Trim(txtID.Text), "Form Penerimaan Bahan Mentah", jenis_pb)
            End If
            If Qty = realQty And Qty <> 0 Then
                statusPenerimaan += 1
            End If

            sqlDetail = " insert into trDetailPB ( No_PB, kdbahanmentah, " & _
                        " Qty, Qty_real, Harga, Disc, QtyPenerimaan ) values( " & _
                        " '" & Trim(txtID.Text) & "','" & KdBahanMentah & "', " & Qty & ", " & _
                        " " & Qty_real & ",'" & harga & "','" & disc & "','" & realQty & "')"
            execute_update_manual(sqlDetail)
        Next

        If flag = 1 And statusPenerimaan = (gridBahanMentah.RowCount - 1) Then
            Dim sqlPO = " Update trheaderpo set StatusPO = '2' " & _
                        " Where No_PO = '" & Trim(cmbPO.Text) & "' "
            execute_update_manual(sqlPO)
        End If
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbPO.SelectedIndex = 0 Then
            msgInfo("No PO harus dipilih")
            cmbPO.Focus()
        Else
            Dim Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            Dim Jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try

                If PK = "" Then
                    sql = " insert into " & tabelH & _
                      " ( No_PB, No_PO, userid, " & _
                      " KdSupplier, Tanggal_TerimaBarang, StatusTerimaBarang, " & _
                      " GrandTotal, jenis_pb, Disc, " & _
                      " Jumlah ) values('" + Trim(txtID.Text) + "','" & Trim(cmbPO.Text) & "', " & _
                      " '" & kdKaryawan & "','" & Trim(txtKdSupplier.Text) & "', " & _
                      " '" + dtpPB.Value.ToString("yyyy/MM/dd HH:mm:ss") + "', " & _
                      " '" & Trim(flag) & "','" & Trim(Grandtotal) & "', " & _
                      " '" & jenis_pb & "', '" & txt_disc_faktur.Text & "', '" & Jumlah & "' ) "
                    execute_update_manual(sql)
                Else
                    sql = " update " & tabelH & " set Tanggal_TerimaBarang='" & dtpPB.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                    " No_PO='" & cmbPO.Text & "'," & _
                    " userid='" & Trim(kdKaryawan) & "'," & _
                    " KdSupplier='" & Trim(txtKdSupplier.Text) & "'," & _
                    " GrandTotal='" & Trim(Grandtotal) & "', " & _
                    " StatusTerimaBarang='" & Trim(flag) & "', " & _
                    " jenis_pb='" & Trim(jenis_pb) & "', " & _
                    " Disc='" & Trim(txt_disc_faktur.Text) & "', " & _
                    " Jumlah='" & Trim(Jumlah) & "' " & _
                    " where  No_PB = '" + txtID.Text + "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trdetailpb where  No_PB = '" & txtID.Text & "'")
                SavePBDetail(flag)

                trans.Commit()
                deleteTabelTemp()
                msgInfo("Data berhasil disimpan. Silakan cetak Penerimaan Bahan Mentah")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                MsgBox(ex, MsgBoxStyle.Critical)
            End Try
            dbconmanual.Close()
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save(0)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub BrowseSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowsePO.Click
        Try
            data_carier(0) = PK
            data_carier(1) = jenis_pb
            sub_form = New FormBrowsePO
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                'txtTglPO.Text = data_carier(1)
                'txtKdSupplier.Text = data_carier(2)
                'txtSupplier.Text = data_carier(3)
                cmbPO.Text = data_carier(0)
                clear_variable_array()

                'sql = " select dpo.kdbahanmentah,namaBahanMentah,Ukuran,Satuan, " & _
                '      " dpo.harga,dpo.jumlah,dpo.jumlah*dpo.harga 'total' " & _
                '      " from  TrdetailPO dpo " & _
                '      " join msBahanMentah b on b.kdBahanMentah=dpo.kdbahanmentah " & _
                '      " where no_PO='" & cmbPO.Text & "' "

                'Dim reader = execute_reader(sql)
                'Dim harga As Double = 0
                'gridBahanMentah.Rows.Clear()
                'Do While reader.Read
                '    gridBahanMentah.Rows.Add()
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = Trim(reader("kdbahanmentah"))
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = Trim(reader("namaBahanMentah"))
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = Trim(reader("Ukuran"))
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("harga"), 0)
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = Val(reader("jumlah"))
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty2").Value = Val(reader("jumlah")) / jml_satuan2
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = 0
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(reader("total"), 0)
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQtyReal").Value = reader("jumlah")
                'Loop
                'reader.Close()

                'HitungTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Function calc_disc_faktur()
        Dim disc = txt_disc_faktur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub txt_disc_faktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_disc_faktur.TextChanged
        If IsNumeric(txt_disc_faktur.Text) Then
            calc_disc_faktur()
        Else
            MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
            txt_disc_faktur.Text = 0
            txt_disc_faktur.Focus()
        End If
    End Sub
End Class