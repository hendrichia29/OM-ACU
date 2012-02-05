Imports System.Data.SqlClient

Public Class FormTrReturPembelianM
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim SubCat As String = ""
    Dim kdsupplier As String = ""
    Dim statusReturPB = 0
    Dim type_retur As String
    Dim isPaid As String = 0
    Dim jml_satuan2 = 0
    Dim nama_satuan2 = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpRetur.Text = Now()
        cmbPB.SelectedIndex = 0
        txtSupplier.Text = ""
    End Sub

    Function getRetur(Optional ByVal KdRetur As String = "")
        Dim sql As String = "Select kdRetur from trheaderReturbeli order by no_increment desc "

        If KdRetur <> "" Then
            sql &= "kdRetur = '" & KdRetur & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim kdfaktur = ""
            Dim readerRetur = execute_reader(" select kdretur,DATE_FORMAT(Tanggalretur, '%m/%d/%Y') Tanggal, " & _
                                            " pb.No_PB, pb.KdSupplier,Nama `Supplier`, " & _
                                            " StatusRetur, Note, retur.Disc disc_retur " & _
                                            " from trheaderreturbeli retur " & _
                                            " Join Trheaderpb pb On  pb.no_PB = retur.kdPB " & _
                                            " Join MsSupplier MT On MT.KdSupplier = pb.KdSupplier " & _
                                            " Where kdretur = '" & PK & "' " & _
                                            " And jenis_retur = '" & type_retur & "' ")
            If readerRetur.Read Then
                txtID.Text = readerRetur.Item("kdretur")
                dtpRetur.Text = readerRetur.Item("Tanggal")
                kdfaktur = readerRetur.Item("No_PB")
                kdsupplier = readerRetur.Item("KdSupplier")
                txtSupplier.Text = readerRetur.Item("Supplier")
                txt_disc_retur.Text = readerRetur.Item("disc_retur")
                If readerRetur.Item("StatusRetur") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                statusReturPB = readerRetur.Item("StatusRetur")
                txtNote.Text = readerRetur("Note")
            End If
            cmbPB.Text = kdfaktur
            Dim reader = execute_reader(" Select MB.KdBahanMentah,NamaBahanMentah,Ukuran, Satuan, " & _
                                        " Harga, Qty, Qty_real, dr.Disc, " & _
                                        " IfNull(( " & _
                                        "   select sum(Qty) from TrDetailPB dp " & _
                                        "   Join TrheaderPB pb on pb.No_pb = dp.No_pb " & _
                                        "   Where pb.No_pb = rb.KdPB " & _
                                        "   And KdBahanMentah = dr.KdBahanMentah " & _
                                        "   And statusterimabarang <> 0 " & _
                                        "   GROUP BY dp.KdBahanMentah " & _
                                        " ),0) - ifNull(( " & _
                                        "   SELECT SUM(Qty) FROM TrdetailReturbeli tdr " & _
                                        "   JOIN TrheaderReturbeli hr ON hr.KdRetur = tdr.KdRetur " & _
                                        "   WHERE hr.KdRetur <> rb.kdretur " & _
                                        "   AND tdr.KdBahanMentah = dr.KdBahanMentah " & _
                                        "   AND hr.KdPB = rb.KdPB " & _
                                        "   GROUP BY tdr.KdBahanMentah " & _
                                        " ),0) as QtyFaktur " & _
                                        " from TrdetailReturbeli dr " & _
                                        " Join trheaderreturbeli rb On rb.KdRetur = dr.KdRetur " & _
                                        " Join msbahanmentah MB On dr.KdBahanMentah = MB.KdBahanMentah " & _
                                        " where rb.kdretur = '" & PK & "' " & _
                                        " order by NamaBahanMentah asc ")

            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim Subtotal = (Val(reader("Harga")) * Val(reader("Qty")))

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyTerima").Value = reader("QtyFaktur")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyReal").Value = reader("Qty_real")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = Subtotal
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Public Sub setCmbFaktur()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbPB.Items.Clear()
        cmbPB.Items.Add("- Pilih Penerimaan Barang -")
        If PK <> "" Then
            addQuery = " And exists( Select 1 from trheaderreturbeli hr " & _
                       " where kdretur = '" & PK & "' " & _
                       " And hp.NO_PB = hr.KdPB )"
        Else
            addQuery &= " And StatusTerimaBarang in (1,2) And Not Exists( " & _
                       "    Select 1 from trdetailreturbeli " & _
                       "    Join trheaderreturbeli On trheaderreturbeli.KdRetur = trdetailreturbeli.KdRetur " & _
                       "    where trheaderreturbeli.KdPB = trdetailpb.No_PB " & _
                       "    And kdbahanmentah = trdetailpb.kdbahanmentah " & _
                       "    Group by trheaderreturbeli.KdPB " & _
                       "    HAVING SUM(qty) - trdetailpb.Qty = 0 " & _
                       " ) "
        End If

        Dim reader = execute_reader(" Select hp.No_PB from trheaderpb hp " & _
                                    " Join msuser On msuser.UserID = hp.UserID " & _
                                    " Join trdetailpb On trdetailpb.no_pb = hp.no_pb " & _
                                    " where 1 " & _
                                    " AND jenis_pb = '" & type_retur & "' " & _
                                    addQuery & _
                                    " GROUP BY hp.No_PB " & _
                                    " Order By no_increment Desc ")
        Do While reader.Read
            cmbPB.Items.Add(reader(0))
        Loop
        reader.Close()
        If cmbPB.Items.Count > 0 Then
            cmbPB.SelectedIndex = 0
        End If
        reader.Close()
    End Sub
    Private Sub FormTrReturPembelianM_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        type_retur = data_carier(2)

        If type_retur = "klem" Then
            Me.Text = "Retur Klem Mentah"
            jml_satuan2 = 30
            nama_satuan2 = "Karung"
        Else
            Me.Text = "Retur Paku"
            jml_satuan2 = 25
            nama_satuan2 = "Kardus"
        End If
        clear_variable_array()
        gridBarang.Columns("clmQtyReal").HeaderText = "Qty Retur ( " & nama_satuan2 & " )"

        setCmbFaktur()
        emptyField()

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
            BrowsePB.Enabled = False
        End If
        cmbPB.Focus()
    End Sub

    Private Sub generateCode()
        Dim code As String = "RB"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")
        code += FormatDate

        Dim reader = getRetur()

        If reader.read Then
            kode = Trim(reader("kdRetur").ToString())
            temp = kode.Substring(0, 8)
            If temp = code Then
                angka = CInt(kode.Substring(8, 4))
            Else
                angka = 0
            End If
            reader.Close()
        Else
            angka = 0
            reader.Close()
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Function SaveReturDetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusFaktur = 3

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim Qty_real = gridBarang.Rows.Item(i).Cells("clmQtyReal").Value
            Dim disc = Val(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
            Dim OP = "Min"
            Dim Attribute = "QtyRetur_Min"
            Dim KdBahanMentah = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim Stok = gridBarang.Rows.Item(i).Cells("clmQtyTerima").Value

            If Qty <> Stok Then
                statusFaktur = 2
            End If

            If Qty <> 0 Then
                If flag = 1 Then
                    StockBahanMentah(Qty_real, OP, harga, KdBahanMentah, Attribute, Trim(txtID.Text), "Form Retur", type_retur)
                End If
                sqlDetail = "insert into trdetailreturbeli(KdRetur,KdBahanMentah, Harga, " _
                           & " Qty, Disc, Qty_real) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBahanMentah & "', " _
                           & " '" & harga & "', '" & Qty & "', '" & disc & "', '" & Qty_real & "' )"
                execute_update_manual(sqlDetail)
            End If
        Next

        If flag = 1 Then
            Dim sqlFaktur = " Update trheaderpb set StatusTerimaBarang = '" & statusFaktur & "' " & _
                            " Where NO_PB = '" & Trim(cmbPB.Text) & "' "
            execute_update_manual(sqlFaktur)
            Return True
        End If
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbPB.SelectedIndex = 0 Then
            msgInfo("No Penerimaan barang harus dipilih")
            cmbPB.Focus()
        Else
            Dim Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            Dim Jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")
            Dim checkQty = 0

            For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                If gridBarang.Rows.Item(i).Cells("clmQty").Value <> 0 Then
                    checkQty += 1
                Else
                    checkQty += 0
                End If
            Next

            If checkQty = 0 Then
                msgInfo("Salah satu jumlah harus diisi lebih dari 0.")
                Return True
                Exit Function
            End If

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            If isPaid > 0 Then
                isPaid = 1
            End If

            Try
                If PK = "" Then
                    sql = " insert into  trheaderreturbeli ( " & _
                          " KdRetur, KdPB, TanggalRetur, KdSupplier, " & _
                          " GrandTotal, StatusRetur, Note, UserID, " & _
                          " AfterPaid, jenis_retur, Disc, Jumlah " & _
                          " ) values('" + Trim(txtID.Text) + "', " & _
                          " '" & cmbPB.Text & "', " & _
                          " '" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdsupplier) & "'," & _
                          " '" & Trim(Grandtotal) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "','" & kdKaryawan & "', " & _
                          " '" & isPaid & "', '" & type_retur & "', '" & txt_disc_retur.Text & "', " & _
                          " '" & Jumlah & "' )"
                    execute_update_manual(sql)
                Else
                    sql = " update   trheaderreturbeli  set  " & _
                        " TanggalRetur='" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                        " KdPB='" & cmbPB.Text & "'," & _
                        " KdSupplier='" & Trim(kdsupplier) & "'," & _
                        " GrandTotal='" & Trim(Grandtotal) & "', " & _
                        " Note='" & Trim(txtNote.Text) & "', " & _
                        " UserID='" & kdKaryawan & "', " & _
                        " AfterPaid='" & isPaid & "', " & _
                        " jenis_retur='" & type_retur & "', " & _
                        " Disc='" & txt_disc_retur.Text & "', " & _
                        " StatusRetur = '" & flag & "', " & _
                        " Jumlah='" & Jumlah & "' " & _
                        " where  KdRetur = '" + txtID.Text + "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from Trdetailreturbeli where  kdretur = '" & txtID.Text & "'")
                SaveReturDetail(flag)

                trans.Commit()
                msgInfo("Data berhasil disimpan")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                msgWarning("Data tidak valid")
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

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            calc_disc_retur()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellDoubleClick

    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim BarangID = gridBarang.CurrentRow.Cells("clmPartNo").Value
            Dim harga = Val(gridBarang.CurrentRow.Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim qty_real = Val(gridBarang.CurrentRow.Cells("clmQtyReal").Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
            Dim stok = Val(gridBarang.CurrentRow.Cells("clmQtyTerima").Value)

            If IsNumeric(qty) = False Or qty Mod jml_satuan2 <> 0 Then
                MsgBox("Jumlah retur harus berupa angka dan kelipatan " & jml_satuan2, MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells("clmQty").Value = stok
                gridBarang.CurrentRow.Cells("clmQtyReal").Value = stok / jml_satuan2
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf qty > stok Then
                MsgBox("Jumlah retur melebii barang yang diterima", MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells("clmQty").Value = stok
                gridBarang.CurrentRow.Cells("clmQtyReal").Value = stok / jml_satuan2
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf IsNumeric(disc) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                disc = 0
                gridBarang.CurrentRow.Cells("clmDisc").Value = 0
                gridBarang.CurrentRow.Cells("clmDisc").Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                gridBarang.CurrentRow.Cells("clmHarga").Value = TempHarga
            End If
            gridBarang.CurrentRow.Cells("clmQtyReal").Value = qty / jml_satuan2
            gridBarang.CurrentRow.Cells("clmSubtotal").Value = FormatNumber((Val(harga) * Val(qty)), 0)

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub BrowseFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowsePB.Click
        Try
            data_carier(0) = PK
            data_carier(1) = "ReturPB"
            data_carier(2) = type_retur
            sub_form = New FormBrowsePB
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbPB.Text = data_carier(0)
                kdsupplier = data_carier(2)
                txtSupplier.Text = data_carier(1)
                isPaid = data_carier(3)
                clear_variable_array()

                'Dim reader = execute_reader(" Select MB.KdBahanMentah,NamaBahanMentah,Ukuran, Satuan, " & _
                '                            " Harga,sum(pb.Qty) - ifnull(( Select sum(Qty) " & _
                '                            " from trdetailreturbeli " & _
                '                            " Join trheaderreturbeli On trdetailreturbeli.KdRetur = trheaderreturbeli.KdRetur " & _
                '                            " where KdBahanMentah = pb.KdBahanMentah " & _
                '                            " And KdPB = hpb.No_PB " & _
                '                            " Group By KdPB,KdBahanMentah ),0) Qty, " & _
                '                            " pb.Disc, hpb.Disc disc_retur " & _
                '                            " from trdetailpb pb " & _
                '                            " Join trheaderpb hpb On pb.No_PB = hpb.No_PB " & _
                '                            " Join msbahanmentah MB On pb.KdBahanMentah = MB.KdBahanMentah " & _
                '                            " where hpb.No_PB = '" & cmbPB.Text & "' " & _
                '                            " Group by hpb.No_PB,MB.KdBahanMentah " & _
                '                            " order by NamaBahanMentah asc ")

                'gridBarang.Rows.Clear()
                'Do While reader.Read
                '    gridBarang.Rows.Add()
                '    txt_disc_retur.Text = reader("disc_retur")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyTerima").Value = reader("Qty")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = 0
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyReal").Value = 0
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = 0
                'Loop
                'reader.Close()

                'HitungTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbfaktur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPB.SelectedIndexChanged
        If cmbPB.SelectedIndex <> 0 Then
            'Dim reader = execute_reader(" SELECT MB.KdBahanMentah,NamaBahanMentah,Ukuran, " & _
            '                            " dp.Harga,dp.Qty - IFNULL(SUM(dr.Qty),0) Qty, " & _
            '                            " dp.Disc,MT.KdSupplier, Nama, Satuan, StatusPayment, " & _
            '                            " pb.Disc disc_retur " & _
            '                            " FROM Trdetailpb dp " & _
            '                            " JOIN trheaderpb pb ON dp.no_pb = pb.no_pb " & _
            '                            " LEFT JOIN TrHeaderReturBeli hr ON hr.KdPB = pb.No_PB " & _
            '                            " LEFT JOIN TrdetailReturbeli dr ON hr.KdRetur = dr.KdRetur " & _
            '                            " AND dr.KdBahanMentah = dp.KdBahanMentah " & _
            '                            " JOIN msbahanmentah MB ON dp.KdBahanMentah = MB.KdBahanMentah " & _
            '                            " JOIN Mssupplier MT ON MT.Kdsupplier = pb.KdSupplier " & _
            '                            " WHERE pb.No_pb = '" & cmbPB.Text & "' " & _
            '                            " GROUP BY pb.NO_PB, dp.KdBahanMentah " & _
            '                            " HAVING Qty <> 0 " & _
            '                            " ORDER BY NamaBahanMentah asc ")
            sql = " SELECT MB.KdBahanMentah,NamaBahanMentah,Ukuran, " & _
                " dp.Harga,dp.Qty - IFNULL(( " & _
                "   SELECT SUM(dr.Qty) FROM TrdetailReturbeli dr " & _
                "   JOIN TrHeaderReturBeli hr ON hr.KdRetur = dr.KdRetur " & _
                "   WHERE(hr.KdPB = pb.No_PB) " & _
                "   AND dr.KdBahanMentah = dp.KdBahanMentah " & _
                "   GROUP BY dr.KdBahanMentah " & _
                " ),0) Qty, " & _
                " dp.Disc,MT.KdSupplier, Nama, Satuan, StatusPayment, " & _
                " pb.Disc disc_retur " & _
                " FROM Trdetailpb dp " & _
                " JOIN trheaderpb pb ON dp.no_pb = pb.no_pb " & _
                " JOIN msbahanmentah MB ON dp.KdBahanMentah = MB.KdBahanMentah " & _
                " JOIN Mssupplier MT ON MT.Kdsupplier = pb.KdSupplier " & _
                " WHERE pb.No_pb = '" & cmbPB.Text & "' " & _
                " GROUP BY pb.NO_PB, dp.KdBahanMentah " & _
                " HAVING Qty <> 0 " & _
                " ORDER BY NamaBahanMentah ASC "
            Dim reader = execute_reader(sql)

            Dim idxfaktur = 0
            gridBarang.Rows.Clear()
            Do While reader.Read
                If idxfaktur = 0 Then
                    txtSupplier.Text = reader("Nama")
                    isPaid = reader("StatusPayment")
                    kdsupplier = reader("KdSupplier")
                    txt_disc_retur.Text = reader("disc_retur")
                End If

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyTerima").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyReal").Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = 0
                idxfaktur += 1
            Loop
            reader.Close()

            HitungTotal()
        Else
            txtSupplier.Text = ""
            kdsupplier = ""
            gridBarang.Rows.Clear()
        End If
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Function calc_disc_retur()
        Dim disc = txt_disc_retur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub gridBarang_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellContentClick

    End Sub

    Private Sub txt_disc_retur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_disc_retur.TextChanged
        If IsNumeric(txt_disc_retur.Text) Then
            calc_disc_retur()
        Else
            MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
            txt_disc_retur.Text = 0
            txt_disc_retur.Focus()
        End If
    End Sub
End Class