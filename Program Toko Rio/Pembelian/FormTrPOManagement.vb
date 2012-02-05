Imports MySql.Data.MySqlClient

Public Class FormTrPOManagement
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim tabelH As String
    Dim tabelD As String
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim SubCat As String = ""
    Dim ukuran As Integer
    Dim satuan As String
    Dim type_po As String
    Dim jml_satuan2 = 0
    Dim nama_satuan2 = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
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
            calc_disc_faktur()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Function calc_disc_faktur()
        Dim disc = txt_disc_faktur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub emptyField()
        dtpPO.Text = Now()
        gridBarang.Rows.Clear()
        cmbSupplier.SelectedIndex = 0
        txtAlamat.Text = ""
        txtDaerah.Text = ""
        emptyBarang()
    End Sub

    Private Sub emptyBarang()
        txtQty.SelectedIndex = 0
        txtHargaBeli.Text = ""
        txtQtyKarung.Text = ""
    End Sub

    Function getSO(Optional ByVal KdSO As String = "")
        Dim sql As String = "Select * from SalesOrder "

        If KdSO <> "" Then
            sql &= "KdSO = '" & KdSO & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim supplier = ""
            Dim readerPO = execute_reader(" select No_PO 'No PO',DATE_FORMAT(Tanggal_PO, '%m/%d/%Y') 'Tanggal', " & _
                                        " MS.KdSupplier, MS.nama, " & _
                                        " Alamat, MS.Daerah, StatusPO, Disc " & _
                                        " from trheaderpo PO " & _
                                        " Join MsSupplier MS On MS.KdSupplier = PO.KdSupplier " & _
                                        " Where No_PO = '" & PK & "' " & _
                                        " And jenis_po = '" & type_po & "' ")

            If readerPO.Read() Then
                txtID.Text = readerPO.Item(0)
                dtpPO.Text = readerPO.Item(1)
                supplier = readerPO.Item(2) & " - " & readerPO.Item(3)
                txt_disc_faktur.Text = readerPO.Item("disc")
                If readerPO.Item(6) <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                Dim StatusPO As String = readerPO.Item("StatusPO")
                setCmbBarang()
            End If
            readerPO.Close()

            cmbSupplier.Text = supplier

            Dim reader = execute_reader(" Select MB.KdBahanMentah,NamaBahanMentah, " & _
                                        " Harga,po.jumlah ,Ukuran,satuan, po.jumlah_real " & _
                                        " from trdetailpo PO " & _
                                        " Join MsBahanMentah MB On PO.KdBahanMentah = MB.KdBahanMentah " & _
                                        " where No_PO = '" & PK & "' " & _
                                        " order by NamaBahanMentah asc ")

            Do While reader.Read
                Dim Subtotal = Val(reader(2)) * Val(reader(3))
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader(0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader(1)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("jumlah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyReal").Value = reader("jumlah_real")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaBeli").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(reader("Harga") * reader("jumlah_real"), 0)
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridBarang.ReadOnly = False

    End Sub


    Public Sub setCmbSupplier()
        Dim varT As String = ""
        cmbSupplier.Items.Clear()
        cmbSupplier.Items.Add("- Pilih Supplier -")
        Dim readerSupplier = execute_reader(" Select * from MsSupplier " & _
                                            " where Nama <>'' " & _
                                            " order by Nama asc ")
        Do While readerSupplier.Read
            cmbSupplier.Items.Add(readerSupplier(0) & " - " & readerSupplier(1))
        Loop
        readerSupplier.Close()
        If cmbSupplier.Items.Count > 0 Then
            cmbSupplier.SelectedIndex = 0
        End If
        readerSupplier.Close()
    End Sub

    Public Sub setCmbBarang()

        Dim varT As String = ""
        cmbBarang.Items.Clear()
        cmbBarang.Items.Add("- Pilih Barang -")
        Dim reader = execute_reader(" Select KdBahanMentah,NamaBahanMentah " & _
                                    " from MsBahanMentah where 1 " & _
                                    " AND IsAktif = '1' " & _
                                    " AND Jenis = '" & type_po & "' " & _
                                    " order by NamaBahanMentah asc ")
        Do While reader.Read
            cmbBarang.Items.Add(reader(0) & " - " & reader(1))
        Loop
        reader.Close()
        If cmbBarang.Items.Count > 0 Then
            cmbBarang.SelectedIndex = 0
        End If
        reader.Close()
    End Sub
    Private Sub deleteTabelTemp()
        Dim query As String
        query = " delete from trheaderpo_t " & _
                " where no_po='" & txtID.Text & "' "
        Try
            execute_update(query)
        Catch ex As Exception
            msgWarning("Error")
        End Try
    End Sub

    Private Sub FormTrPOManagement_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        deleteTabelTemp()
    End Sub

    Function setCmbQty()
        txtQty.Items.Clear()
        txtQty.Items.Add("- Pilih Jumlah -")
        For i As Integer = 1 To 100
            txtQty.Items.Add(i * Val(jml_satuan2))
        Next

        Return True
    End Function

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tabelH = " TrHeaderPO "
        tabelD = " TrDetailPO "
        PK = " No_PO"

        PK = data_carier(0)
        status = data_carier(1)
        type_po = data_carier(2)

        If type_po = "klem" Then
            Me.Text = "Pembelian Klem Mentah"
            jml_satuan2 = 25
            nama_satuan2 = "Karung"
        Else
            Me.Text = "Pembelian Paku"
            jml_satuan2 = 30
            nama_satuan2 = "Kardus"
        End If
        lblKarung.Text = nama_satuan2
        clear_variable_array()
        gridBarang.Columns("clmQtyReal").HeaderText = "Jumlah ( " & nama_satuan2 & " )"

        setCmbQty()
        setCmbSupplier()
        emptyField()
        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbSupplier.Focus()
        setCmbBarang()
        'insert to header pb temp
        Dim tabel As String = " TrHeaderPO_T "
        sql = "insert into " & tabel & " ( no_increment ) values ('" & txtID.Text & "')"
        Try
            execute_update(sql)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub


    Private Sub generateCode()
        Dim code As String = "PO"
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
        sql = " select no_po, Tanggal_PO " & _
              " from  TrHeaderPO " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("no_po")
        Else
            reader.Close()
            sql = " select TrHeaderPO_T.no_po " & _
                  " from  TrHeaderPO_T " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("no_po")
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

    Function SavePODetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0

            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim Qty_real = Val(gridBarang.Rows.Item(i).Cells("clmQtyReal").Value)
            Dim OP = "Plus"
            Dim Attribute = "QtyPurchase_Plus"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim harga = Val(gridBarang.Rows.Item(i).Cells("clmHargaBeli").Value.ToString.Replace(".", "").Replace(",", ""))

            If flag = 1 Then
                StockBahanMentah(Qty_real, OP, harga, KdBarang, Attribute, Trim(txtID.Text), "Form Penerimaan Bahan Mentah", type_po)
            End If

            sqlDetail = " insert into trDetailPO ( no_po, kdbahanmentah, jumlah, " & _
                        " jumlah_real, harga ) values( " & _
                        " '" & Trim(txtID.Text) & "','" & KdBarang & "', '" & Qty & "', " & _
                        " '" & Qty_real & "', '" & harga & "' ) "
            execute_update_manual(sqlDetail)

            sqlDetail = " insert into trDetailPB ( No_PB, kdbahanmentah, " & _
                        " Qty, Qty_real, Harga, Disc, QtyPenerimaan ) values( " & _
                        " '" & Trim(txtID.Text) & "','" & KdBarang & "', " & Qty & ", " & _
                        " " & Qty_real & ",'" & harga & "', 0,'" & Qty_real & "' ) "
            execute_update_manual(sqlDetail)
        Next

        If flag = 1 Then
            Dim sqlPO = " Update trheaderpo set StatusPO = '2' " & _
                        " Where No_PO = '" & Trim(txtID.Text) & "' "
            execute_update_manual(sqlPO)
        End If
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbSupplier.SelectedIndex = 0 Then
            msgInfo("Supplier harus dipilih")
            cmbSupplier.Focus()
        ElseIf gridBarang.RowCount = 0 Then
            msgInfo("Tambah barang terlebih dahulu")
            cmbBarang.Focus()
        Else
            Dim supplierID = cmbSupplier.Text.ToString.Split("-")
            Dim Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            Dim Jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try

                If status = "add" Then
                    sql = " insert into  " & tabelH & " ( No_PO, userid, Tanggal_PO, " & _
                          " KdSupplier, StatusPO, GrandTotal, jenis_po, disc ) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" & kdKaryawan & "', " & _
                          " '" + dtpPO.Value.ToString("yyyy/MM/dd HH:mm:ss") + "', " & _
                          " '" & supplierID(0) & "', '" & flag & "', 0, " & _
                          " '" & Trim(type_po) & "', '" & txt_disc_faktur.Text & "' ) "
                    execute_update_manual(sql)

                    sql = " insert into trheaderpb " & _
                      " ( No_PB, No_PO, userid, " & _
                      " KdSupplier, Tanggal_TerimaBarang, StatusTerimaBarang, " & _
                      " GrandTotal, jenis_pb, Disc, " & _
                      " Jumlah ) values('" + Trim(txtID.Text) + "','" & Trim(txtID.Text) & "', " & _
                      " '" & kdKaryawan & "','" & Trim(supplierID(0)) & "', " & _
                      " '" + dtpPO.Value.ToString("yyyy/MM/dd HH:mm:ss") + "', " & _
                      " '" & Trim(flag) & "','" & Trim(Grandtotal) & "', " & _
                      " '" & type_po & "', '" & txt_disc_faktur.Text & "', '" & Jumlah & "' ) "
                    execute_update_manual(sql)
                ElseIf status = "update" Then
                    sql = " update trheaderpo  set  " & _
                          " Tanggal_PO = '" & dtpPO.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdSupplier = '" & Trim(supplierID(0)) & "'," & _
                          " StatusPO = '" & flag & "'," & _
                          " GrandTotal = 0, " & _
                          " UserID =  '" & Trim(kdKaryawan) & "', " & _
                          " jenis_po =  '" & Trim(type_po) & "', " & _
                          " disc =  '" & Trim(txt_disc_faktur.Text) & "' " & _
                          " where no_po = '" & Trim(txtID.Text) & "' "
                    execute_update_manual(sql)

                    sql = " update trheaderpb set " & _
                        " Tanggal_TerimaBarang='" & dtpPO.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                        " No_PO='" & txtID.Text & "'," & _
                        " userid='" & Trim(kdKaryawan) & "'," & _
                        " KdSupplier='" & Trim(supplierID(0)) & "'," & _
                        " GrandTotal='" & Trim(Grandtotal) & "', " & _
                        " StatusTerimaBarang='" & Trim(flag) & "', " & _
                        " jenis_pb='" & Trim(type_po) & "', " & _
                        " Disc='" & Trim(txt_disc_faktur.Text) & "', " & _
                        " Jumlah='" & Trim(Jumlah) & "' " & _
                        " where  No_PB = '" + txtID.Text + "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trdetailpo where  No_PO = '" & txtID.Text & "'")
                execute_update_manual("delete from trdetailpb where  No_PB = '" & txtID.Text & "'")
                SavePODetail(flag)
                deleteTabelTemp()
                trans.Commit()
                msgInfo("Data berhasil disimpan. Silakan cetak PO")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                MsgBox(ex, MsgBoxStyle.Information)
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbBarang.SelectedIndex = 0 Then
                msgInfo("Barang harus dipilih")
                cmbBarang.Focus()
            ElseIf txtQty.SelectedIndex = 0 Then
                msgInfo("Jumlah harus dipilih")
                txtQty.Focus()
            ElseIf Not IsNumeric(txtHargaBeli.Text) Then
                msgInfo("Harga Beli harus diisi dan berupa angka")
                txtQty.Focus()
            Else
                Dim barangID = cmbBarang.Text.ToString.Split("-")
                Dim harga = 0
                Dim StatusBarang = ""


                For i As Integer = 0 To (gridBarang.RowCount - 1)
                    If gridBarang.Rows(i).Cells("clmPartNo").Value.ToString = Trim(barangID(0)) Then
                        Dim addQty = Val(txtQty.Text)
                        Dim Subtot = (Val(harga) * Val(addQty))

                        gridBarang.Rows.Item(i).Cells("clmNamaBarang").Value = Trim(NamaBarang)
                        gridBarang.Rows.Item(i).Cells("clmUkuran").Value = Trim(ukuran)
                        gridBarang.Rows.Item(i).Cells("clmQty").Value = addQty
                        gridBarang.Rows.Item(i).Cells("clmQtyReal").Value = addQty / jml_satuan2
                        gridBarang.Rows.Item(i).Cells("clmHargaBeli").Value = FormatNumber(CDbl(txtHargaBeli.Text), 0)
                        gridBarang.Rows.Item(i).Cells("clmSubtotal").Value = FormatNumber(CDbl(txtHargaBeli.Text) * (addQty / jml_satuan2), 0)
                        emptyBarang()
                        gridBarang.Focus()
                        HitungTotal()
                        Exit Sub
                    End If
                Next
                Dim Subtotal = (Val(harga) * Val(txtQty.Text))
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = Trim(barangID(0))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = Trim(NamaBarang)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = Trim(ukuran)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = Val(txtQty.Text)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyReal").Value = Val(txtQty.Text) / jml_satuan2
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaBeli").Value = FormatNumber(CDbl(txtHargaBeli.Text), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(CDbl(txtHargaBeli.Text) * (Val(txtQty.Text) / jml_satuan2), 0)
                emptyBarang()
                gridBarang.Focus()
                HitungTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbSupplier_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSupplier.SelectedIndexChanged
        If cmbSupplier.SelectedIndex <> 0 Then
            Dim supplierID = cmbSupplier.Text.ToString.Split("-")

            sql = " Select Alamat,Daerah from MsSupplier " & _
                  " where KdSupplier = '" & Trim(supplierID(0)) & "' "
            Dim reader = execute_reader(sql)

            If reader.Read Then
                txtAlamat.Text = reader(0)
                txtDaerah.Text = reader(1)
            End If
            reader.Close()
        Else
            txtAlamat.Text = ""
            txtDaerah.Text = ""
        End If
    End Sub

    Function get__query_bahanmentah(ByVal barang_id As String)
        'sql = " Select StockAkhir, IfNull((Select Harga From MsBahanMentahList " & _
        '      " where KdBahanMentah = BahanMentahHistory.KdBahanMentah  " & _
        '      " Order By KdBahanMentahList asc Limit 1 ),0) As HargaAwal, " & _
        '      " NamaBahanMentah,Ukuran,satuan " & _
        '      " from BahanMentahHistory " & _
        '      " Join MsBahanMentah On MsBahanMentah.KdBahanMentah = BahanMentahHistory.KdBahanMentah " & _
        '      " where isActive = 1 " & _
        '      " And BahanMentahHistory.kdBahanMentah = '" & barang_id & "' " & _
        '      " order by KdHistory desc limit 1"
        sql = " SELECT IFNULL(SUM(MBML.Qty),0) StockAkhir, IFNULL(MBML.Harga,0) AS HargaAwal, " & _
              "     NamaBahanMentah,Ukuran,satuan  " & _
              " FROM MsBahanMentah MBM " & _
              " LEFT JOIN MsBahanMentahList MBML ON MBML.KdBahanMentah = MBM.KdBahanMentah " & _
              " WHERE MBM.isAktif = 1 " & _
              " AND MBM.kdBahanMentah = '" & barang_id & "' " & _
              " GROUP BY MBM.KdBahanMentah " & _
              " ORDER BY KdBahanMentahList "
        Return sql
    End Function

    Private Sub cmbBarang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBarang.SelectedIndexChanged
        If cmbBarang.SelectedIndex <> 0 Then
            Dim barangID = cmbBarang.Text.ToString.Split("-")

            sql = get__query_bahanmentah(barangID(0))
            Dim reader = execute_reader(sql)

            If reader.Read Then
                lblStock.Text = reader(0)
                NamaBarang = reader("NamaBahanMentah")
                ukuran = reader("Ukuran")
                satuan = reader("satuan")
            End If
            reader.Close()
        Else
            lblStock.Text = 0
        End If
    End Sub

    Private Sub browseSupplier_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseSupplier.Click
        Try
            sub_form = New FormBrowseSupplier
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbSupplier.Text = data_carier(0) & " - " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseBarang.Click
        Try
            data_carier(0) = type_po
            sub_form = New FormBrowseBahanMentahPaku
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbBarang.Text = data_carier(0) & " - " & data_carier(1)
                sql = get__query_bahanmentah(data_carier(0))
                Dim reader = execute_reader(sql)

                If reader.Read Then
                    lblStock.Text = reader(0)
                    NamaBarang = reader("NamaBahanMentah")
                    ukuran = reader("Ukuran")
                    satuan = reader("satuan")
                End If
                reader.Close()
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            gridBarang.Rows.RemoveAt(gridBarang.CurrentRow.Index)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim harga = 0
            Dim qty = Val(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim HargaBeli = gridBarang.CurrentRow.Cells("clmHargaBeli").Value
            If qty Mod jml_satuan2 <> 0 Or Val(qty) <= 0 Then
                MsgBox("Jumlah harus lebih besar dari 0 dan kelipatan " & jml_satuan2, MsgBoxStyle.Information, "Validation Error")
                qty = jml_satuan2
                gridBarang.CurrentRow.Cells("clmQty").Value = jml_satuan2
                gridBarang.CurrentRow.Cells("clmQtyReal").Value = 1
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf Not IsNumeric(HargaBeli) Then
                MsgBox("Harga Beli harus diisi dan berupa angka ", MsgBoxStyle.Information, "Validation Error")
                HargaBeli = 0
            End If
            gridBarang.CurrentRow.Cells("clmHargaBeli").Value = FormatNumber(CDbl(HargaBeli), 0)
            gridBarang.CurrentRow.Cells("clmQty").Value = qty
            gridBarang.CurrentRow.Cells("clmQtyReal").Value = qty / jml_satuan2
            gridBarang.CurrentRow.Cells("clmSubtotal").Value = FormatNumber(CDbl(HargaBeli) * (qty / jml_satuan2), 0)
            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub RadioButton1_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        setCmbBarang()
    End Sub

    Private Sub RadioButton2_Click(ByVal sender As Object, ByVal e As System.EventArgs)
        setCmbBarang()
    End Sub

    Private Sub RadioButton1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub gridBarang_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellContentClick

    End Sub

    Private Sub txtQty_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.SelectedIndexChanged
        txtQtyKarung.Text = Val(txtQty.Text) / Val(jml_satuan2)
    End Sub

    Private Sub main_tool_strip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles main_tool_strip.ItemClicked

    End Sub

    Private Sub txtQtyKarung_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKarung.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQty.Text <> "" Then
            txtHargaBeli.Focus()
        End If
    End Sub

    Private Sub txtQtyKarung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyKarung.TextChanged
        txtQty.Text = Val(txtQtyKarung.Text) * Val(jml_satuan2)
    End Sub

    Private Sub txtHargaBeli_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaBeli.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHargaBeli.Text <> "" Then
            btnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtHargaBeli_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaBeli.Leave
        If txtHargaBeli.Text <> "" Then
            txtHargaBeli.Text = FormatNumber(txtHargaBeli.Text, 0)
        End If
    End Sub

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