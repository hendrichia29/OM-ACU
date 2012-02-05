Imports MySql.Data.MySqlClient

Public Class FormProduksiPantekManagement
    Dim PK As String = ""
    Dim statusPantek = 0
    Dim OP = "Min"
    Dim Attribute = "QtyProd_Min"
    Dim KonversiKlemToKg = 25
    Dim KonversiPakuToKg = 30

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    'FlagStatus : StatusSO,Stock
    Function check_stock(ByVal KdBarang As String)
        Dim sql_stock = ""
        sql_stock = " Select sum(Qty) As Stock " & _
                    " From msbahanmentahlist MBMT " & _
                    " JOIN msbahanmentah MBM ON MBMT.KdBahanMentah = MBM.KdBahanMentah " & _
                    " Where MBMT.KdBahanMentah = '" & KdBarang & "' " & _
                    " And MBMT.StatusBahanMentahList = 0 " & _
                    " Group By MBMT.KdBahanMentah "
        Dim readerStock = execute_reader(sql_stock)
        If readerStock.read Then
            Dim readyStock = Val(readerStock(0))
            If readyStock < 0 Then
                readyStock = 0
            End If
            Return Val(readyStock)
        End If
        readerStock.close()
        Return 0
    End Function

    Private Sub emptyField()
        dtpPantek.Text = Now()
        gridBarang.Rows.Clear()
        cmbKaryawan.SelectedIndex = 0
        txtAlamat.Text = ""
        txtTelepon.Text = ""
        emptyBarang()
    End Sub

    Private Sub emptyBarang()
        cmbKlemMentah.SelectedIndex = 0
        cmbPaku.SelectedIndex = 0
        cmbQtyKlemMentah.SelectedIndex = 0
        cmbQtyPaku.SelectedIndex = 0
        txtQtyKlemMentah.Text = 0
        txtQtyPaku.Text = 0
    End Sub

    Private Sub setData()
        Try
            Dim SelectKaryawan = ""
            Dim readerPantek = execute_reader(" select KdPantek, DATE_FORMAT(TanggalPantek, '%m/%d/%Y') 'Tanggal', " & _
                                          " pantek.KdKaryawan, MK.NamaKaryawan, " & _
                                          " Alamat, MK.NoHP, StatusPantek " & _
                                          " from trpantek pantek " & _
                                          " Join mskaryawan MK On MK.KdKaryawan = pantek.KdKaryawan " & _
                                          " Where KdPantek = '" & PK & "' ")

            If readerPantek.Read() Then
                txtKdPantek.Text = readerPantek.Item("KdPantek")
                dtpPantek.Text = readerPantek.Item("Tanggal")
                SelectKaryawan = Trim(readerPantek.Item("KdKaryawan")) & " ~ " & readerPantek.Item("NamaKaryawan")
                statusPantek = readerPantek.Item("StatusPantek")
                If readerPantek.Item("StatusPantek") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                    btnRemove.Enabled = False
                End If
            End If
            readerPantek.Close()

            cmbKaryawan.Text = SelectKaryawan
            Dim reader = execute_reader(" Select klem.KdBahanMentah 'KdKlem', klem.NamaBahanMentah 'NamaKlem', " & _
                                        " klem.Ukuran 'UkuranKlem', sum(QtyKlemMentah) QtyKlemMentah, " & _
                                        " paku.KdBahanMentah 'KdPaku', paku.NamaBahanMentah 'NamaPaku', " & _
                                        " paku.Ukuran 'UkuranPaku', sum(QtyPaku) QtyPaku " & _
                                        " from trpantekdetail pantek " & _
                                        " Join MsBahanMentah klem On klem.KdBahanMentah = KdKlemMentah " & _
                                        " Join MsBahanMentah paku On paku.KdBahanMentah = KdPaku " & _
                                        " where KdPantek = '" & PK & "' " & _
                                        " GROUP BY klem.KdBahanMentah, paku.KdBahanMentah " & _
                                        " order by klem.NamaBahanMentah asc ")

            Do While reader.Read
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKlem").Value = reader("KdKlem")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdPaku").Value = reader("KdPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranKlem").Value = reader("NamaKlem")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranPaku").Value = reader("NamaPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlem").Value = reader("QtyKlemMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlemKg").Value = reader("QtyKlemMentah") * KonversiKlemToKg
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPaku").Value = reader("QtyPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPakuKg").Value = reader("QtyPaku") * KonversiPakuToKg
            Loop
            reader.Close()
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

    Public Sub setCmbKaryawan()
        Dim varT As String = ""
        cmbKaryawan.Items.Clear()
        cmbKaryawan.Items.Add("- Pilih Karyawan -")
        Dim readerKaryawan = execute_reader(" SELECT `KdKaryawan`, `NamaKaryawan`, " & _
                                            " `Alamat`, `NoHP`, `NoHP`, " & _
                                            " `JenisKaryawan` " & _
                                            " FROM `mskaryawan` " & _
                                            " order by NamaKaryawan asc ")
        Do While readerKaryawan.Read
            cmbKaryawan.Items.Add(readerKaryawan("KdKaryawan") & " ~ " & readerKaryawan("NamaKaryawan"))
        Loop
        readerKaryawan.Close()
        If cmbKaryawan.Items.Count > 0 Then
            cmbKaryawan.SelectedIndex = 0
        End If
        readerKaryawan.Close()
    End Sub

    Public Sub setCmbBarang()

        Dim varT As String = ""
        cmbKlemMentah.Items.Clear()
        cmbPaku.Items.Clear()
        cmbKlemMentah.Items.Add("- Pilih Klem Mentah -")
        cmbPaku.Items.Add("- Pilih Paku -")
        Dim reader = execute_reader(" Select KdBahanMentah,NamaBahanMentah, Jenis " & _
                                    " from MsBahanMentah where 1 " & _
                                    " AND IsAktif = '1' " & _
                                    " order by NamaBahanMentah asc ")
        Do While reader.Read
            If reader("Jenis") = "Klem" Then
                cmbKlemMentah.Items.Add(reader("KdBahanMentah") & " ~ " & reader("NamaBahanMentah"))
            Else
                cmbPaku.Items.Add(reader("KdBahanMentah") & " ~ " & reader("NamaBahanMentah"))
            End If
        Loop
        reader.Close()
        If cmbPaku.Items.Count > 0 Then
            cmbPaku.SelectedIndex = 0
        End If
        If cmbKlemMentah.Items.Count > 0 Then
            cmbKlemMentah.SelectedIndex = 0
        End If
    End Sub

    Function setCmbQtyKlem()
        cmbQtyKlemMentah.Items.Clear()
        cmbQtyKlemMentah.Items.Add("- Pilih -")
        For i As Integer = 1 To 100
            cmbQtyKlemMentah.Items.Add(i * KonversiKlemToKg)
        Next
        cmbQtyKlemMentah.SelectedIndex = 0
        Return True
    End Function

    Function setCmbQtyPaku()
        cmbQtyPaku.Items.Clear()
        cmbQtyPaku.Items.Add("- Pilih -")
        For i As Integer = 1 To 100
            cmbQtyPaku.Items.Add(i * KonversiPakuToKg)
        Next
        cmbQtyPaku.SelectedIndex = 0
        Return True
    End Function

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        clear_variable_array()
        setCmbQtyKlem()
        setCmbQtyPaku()
        setCmbKaryawan()
        setCmbBarang()
        emptyField()
        If PK <> "" Then
            setData()
            txtKdPantek.Text = PK
        Else
            generateCode()
        End If
    End Sub

    Private Sub generateCode()
        Dim code As String = "PK"
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
        sql = " select KdPantek " & _
              " from  trpantek " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("KdPantek")
        Else
            reader.Close()
            sql = " select KdPantek " & _
                  " from  trpantek_t " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("KdPantek")
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
        txtKdPantek.Text = Trim(code)
    End Sub

    Function SavePantekDetail(ByVal flag As String)
        Dim sqlDetail = ""

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim QtyKlem = Val(gridBarang.Rows.Item(i).Cells("clmQtyKlem").Value)
            Dim QtyPaku = Val(gridBarang.Rows.Item(i).Cells("clmQtyPaku").Value)
            Dim KdKlem = gridBarang.Rows.Item(i).Cells("clmKdKlem").Value
            Dim KdPaku = gridBarang.Rows.Item(i).Cells("clmKdPaku").Value
            Dim StokKlem = check_stock(KdKlem)
            Dim StokPaku = check_stock(KdPaku)
            If QtyKlem > StokKlem Then
                MsgBox("Jumlah klem telah melebihi stok. Stok saat ini adalah " & StokKlem)
                Return False
            ElseIf QtyPaku > StokPaku Then
                MsgBox("Jumlah paku telah melebihi stok. Stok saat ini adalah " & StokPaku)
                Return False
            Else
                If flag = 1 Then
                    StockBahanMentah(QtyKlem, OP, 0, Trim(KdKlem), Attribute, txtKdPantek.Text, "Form Pantek Klem", "Klem")
                    StockBahanMentah(QtyPaku, OP, 0, Trim(KdPaku), Attribute, txtKdPantek.Text, "Form Pantek Klem", "Paku")
                End If
                sqlDetail = " insert into trpantekdetail ( KdPantek, KdKlemMentah, QtyKlemMentah, " & _
                            " KdPaku, QtyPaku ) VALUES ( " & _
                            " '" & txtKdPantek.Text & "' , '" & Trim(KdKlem) & "', " & _
                            " '" & QtyKlem & "', '" & Trim(KdPaku) & "', " & _
                            " '" & QtyPaku & "' ) "
                execute_update_manual(sqlDetail)
            End If
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbKaryawan.SelectedIndex = 0 Then
            msgInfo("Karyawan harus dipilih")
            cmbKaryawan.Focus()
        ElseIf gridBarang.RowCount = 0 Then
            msgInfo("Tambah barang terlebih dahulu")
            cmbKlemMentah.Focus()
        Else
            Dim KdKar = cmbKaryawan.Text.ToString.Split("~")
            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction
            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try

                If PK = "" Then
                    sql = " insert into trpantek ( KdPantek, TanggalPantek, " & _
                          " KdKaryawan, KdUser, StatusPantek ) " & _
                          " values( '" & Trim(txtKdPantek.Text) & "', " & _
                          " '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" + Trim(KdKar(0)) + "', " & _
                          " '" & Trim(kdKaryawan) & "', '" & flag & "' ) "
                    execute_update_manual(sql)
                Else
                    sql = " update trpantek  set  " & _
                          " TanggalPantek = '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdKaryawan = '" & Trim(KdKar(0)) & "'," & _
                          " StatusPantek = '" & flag & "'," & _
                          " KdUser =  '" & Trim(kdKaryawan) & "' " & _
                          " where KdPantek = '" & Trim(txtKdPantek.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trpantekdetail where  KdPantek = '" & txtKdPantek.Text & "'")
                If Not SavePantekDetail(flag) Then
                    Return False
                End If
                trans.Commit()
                msgInfo("Data produksi pantek berhasil disimpan.")
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
        dbconmanual.Open()
        Dim trans As MySql.Data.MySqlClient.MySqlTransaction
        trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
        Try
            If cmbKlemMentah.SelectedIndex = 0 Then
                msgInfo("Klem Mentah harus dipilih")
                cmbKlemMentah.Focus()
            ElseIf cmbQtyKlemMentah.SelectedIndex = 0 Then
                msgInfo("Jumlah klem mentah harus dipilih")
                cmbQtyKlemMentah.Focus()
            ElseIf cmbPaku.SelectedIndex = 0 Then
                msgInfo("Paku harus dipilih")
                cmbPaku.Focus()
            ElseIf cmbQtyPaku.SelectedIndex = 0 Then
                msgInfo("Jumlah paku harus dipilih")
                cmbQtyPaku.Focus()
            Else
                Dim KdKlem = cmbKlemMentah.Text.ToString.Split("~")
                Dim KdPaku = cmbPaku.Text.ToString.Split("~")
                Dim StokKlem = check_stock(KdKlem(0))
                Dim StokPaku = check_stock(KdPaku(0))
                Dim harga = 0
                Dim StatusBarang = ""

                If StokKlem < Val(txtQtyKlemMentah.Text) Then
                    MsgBox("Jumlah klem melebihin stok. Stok saat ini " & StokKlem, MsgBoxStyle.Information, "Validation Error")
                ElseIf StokPaku < Val(txtQtyPaku.Text) Then
                    MsgBox("Jumlah paku melebihin stok. Stok saat ini " & StokPaku, MsgBoxStyle.Information, "Validation Error")
                Else
                    For i As Integer = 0 To (gridBarang.RowCount - 1)
                        If gridBarang.Rows(i).Cells("clmKdKlem").Value.ToString = Trim(KdKlem(0)) And statusPantek = 0 Then
                            MsgBox("Klem sudah ada didalam grid.")
                            Exit Sub
                        End If
                    Next

                    If statusPantek <> 0 Then
                        If MsgBox("Anda yakin ingin menambah barang?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                            StockBahanMentah(Val(txtQtyKlemMentah.Text), OP, 0, Trim(KdKlem(0)), Attribute, txtKdPantek.Text, "Form Pantek Klem", "Klem")
                            StockBahanMentah(Val(txtQtyPaku.Text), OP, 0, Trim(KdPaku(0)), Attribute, txtKdPantek.Text, "Form Pantek Klem", "Paku")
                            Dim sqlDetail = " insert into trpantekdetail ( KdPantek, KdKlemMentah, QtyKlemMentah, " & _
                                " KdPaku, QtyPaku ) VALUES ( " & _
                                " '" & txtKdPantek.Text & "' , '" & Trim(KdKlem(0)) & "', " & _
                                " '" & txtQtyKlemMentah.Text & "', '" & Trim(KdPaku(0)) & "', " & _
                                " '" & txtQtyPaku.Text & "' ) "
                            execute_update_manual(sqlDetail)

                        Else
                            Exit Sub
                        End If
                    End If

                    gridBarang.Rows.Add()
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKlem").Value = Trim(KdKlem(0))
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdPaku").Value = Trim(KdPaku(0))
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranKlem").Value = Trim(KdKlem(1))
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranPaku").Value = Trim(KdPaku(1))
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlem").Value = Val(txtQtyKlemMentah.Text)
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlemKg").Value = Val(txtQtyKlemMentah.Text) * KonversiKlemToKg
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPaku").Value = Val(txtQtyPaku.Text)
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPakuKg").Value = Val(txtQtyPaku.Text) * KonversiPakuToKg
                    emptyBarang()

                    gridBarang.Focus()
                End If
            End If
            trans.Commit()
        Catch ex As Exception
            trans.Rollback()
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
        dbconmanual.Close()
    End Sub

    Private Sub cmbKaryawan_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKaryawan.SelectedIndexChanged
        If cmbKaryawan.SelectedIndex <> 0 Then
            Dim KdKaryawan = cmbKaryawan.Text.ToString.Split("~")

            sql = " Select Alamat,NoHP from mskaryawan " & _
                  " where KdKaryawan = '" & Trim(KdKaryawan(0)) & "' "
            Dim reader = execute_reader(sql)

            If reader.Read Then
                txtAlamat.Text = reader("Alamat")
                txtTelepon.Text = reader("NoHP")
            End If
            reader.Close()
        Else
            txtAlamat.Text = ""
            txtTelepon.Text = ""
        End If
    End Sub

    Private Sub browseKaryawan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKaryawan.Click
        Try
            sub_form = New FormBrowseKaryawan
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbKaryawan.Text = data_carier(0) & " ~ " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub browseKlemMentah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKlemMentah.Click
        Try
            data_carier(0) = "Klem"
            sub_form = New FormBrowseBahanMentahPaku
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbKlemMentah.Text = data_carier(0) & " ~ " & data_carier(1)
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
            Dim qtyKlem = Val(gridBarang.CurrentRow.Cells("clmQtyKlem").Value)
            Dim qtyPaku = Val(gridBarang.CurrentRow.Cells("clmQtyPaku").Value)
            Dim KdKlem = gridBarang.CurrentRow.Cells("clmKdKlem").Value
            Dim KdPaku = gridBarang.CurrentRow.Cells("clmKdPaku").Value
            Dim StokKlem = check_stock(KdKlem)
            Dim StokPaku = check_stock(KdPaku)

            If Val(qtyKlem) <= 0 Then
                MsgBox("Jumlah klem harus lebih besar dari 0 dan kelipatan " & KonversiKlemToKg, MsgBoxStyle.Information, "Validation Error")
                qtyKlem = 1
                gridBarang.CurrentRow.Cells("clmQtyKlem").Selected = True
            ElseIf qtyKlem > StokKlem Then
                MsgBox("Jumlah klem melebihin stok. Stok saat ini " & StokKlem, MsgBoxStyle.Information, "Validation Error")
                qtyKlem = StokKlem
                gridBarang.CurrentRow.Cells("clmQtyKlem").Selected = True
            ElseIf Val(qtyPaku) <= 0 Then
                MsgBox("Jumlah paku harus lebih besar dari 0 dan kelipatan " & KonversiPakuToKg, MsgBoxStyle.Information, "Validation Error")
                qtyPaku = 1
                gridBarang.CurrentRow.Cells("clmQtyPaku").Selected = True
            ElseIf qtyPaku > StokPaku Then
                MsgBox("Jumlah paku melebihin stok. Stok saat ini " & StokPaku, MsgBoxStyle.Information, "Validation Error")
                qtyPaku = StokPaku
                gridBarang.CurrentRow.Cells("clmQtyPaku").Selected = True
            End If
            gridBarang.CurrentRow.Cells("clmQtyKlem").Value = CInt(qtyKlem)
            gridBarang.CurrentRow.Cells("clmQtyPaku").Value = CInt(qtyPaku)
            gridBarang.CurrentRow.Cells("clmQtyKlemKg").Value = CInt(qtyKlem) * KonversiKlemToKg
            gridBarang.CurrentRow.Cells("clmQtyPakuKg").Value = CInt(qtyPaku) * KonversiPakuToKg
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub browsePaku_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browsePaku.Click
        Try
            data_carier(0) = "Paku"
            sub_form = New FormBrowseBahanMentahPaku
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbPaku.Text = data_carier(0) & " ~ " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub txtQtyKlemMentah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKlemMentah.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKlemMentah.Text <> "" Then
            cmbPaku.Focus()
        End If
    End Sub

    Private Sub txtQtyKarung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyKlemMentah.TextChanged
        cmbQtyKlemMentah.Text = Val(txtQtyKlemMentah.Text) * Val(KonversiKlemToKg)
    End Sub

    Private Sub cmbKlemMentah_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKlemMentah.SelectedIndexChanged
        If cmbKlemMentah.SelectedIndex <> 0 Then
            Dim KdKlem = cmbKlemMentah.Text.ToString.Split("~")
            Dim SqlBarang = " SELECT KdBahanMentah, KarungToKg " & _
                           " FROM msbahanmentah " & _
                           " WHERE KdBahanMentah = '" & KdKlem(0) & "' "
            Dim readerBarang = execute_reader(SqlBarang)
            If readerBarang.read Then
                KonversiKlemToKg = readerBarang("KarungToKg")
            End If
            readerBarang.close()
            txtQtyKlemMentah.Enabled = True
            cmbQtyKlemMentah.Enabled = True
            setCmbQtyKlem()
        Else
            txtQtyKlemMentah.Enabled = False
            cmbQtyKlemMentah.Enabled = False
        End If
    End Sub

    Private Sub cmbPaku_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPaku.SelectedIndexChanged
        If cmbPaku.SelectedIndex <> 0 Then
            Dim KdPaku = cmbPaku.Text.ToString.Split("~")
            Dim SqlBarang = " SELECT KdBahanMentah, KarungToKg " & _
                           " FROM msbahanmentah " & _
                           " WHERE KdBahanMentah = '" & KdPaku(0) & "' "
            Dim readerBarang = execute_reader(SqlBarang)
            If readerBarang.read Then
                KonversiPakuToKg = readerBarang("KarungToKg")
            End If
            readerBarang.close()
            txtQtyPaku.Enabled = True
            cmbQtyPaku.Enabled = True
            setCmbQtyPaku()
        Else
            txtQtyPaku.Enabled = False
            cmbQtyPaku.Enabled = False
        End If
    End Sub

    Private Sub txtQtyPaku_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyPaku.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyPaku.Text <> "" Then
            btnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtQtyPaku_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyPaku.TextChanged
        cmbQtyPaku.Text = Val(txtQtyPaku.Text) * Val(KonversiPakuToKg)
    End Sub

    Private Sub cmbQtyKlemMentah_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQtyKlemMentah.SelectedIndexChanged
        txtQtyKlemMentah.Text = Val(cmbQtyKlemMentah.Text) / Val(KonversiKlemToKg)
    End Sub

    Private Sub cmbQtyPaku_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQtyPaku.SelectedIndexChanged
        txtQtyPaku.Text = Val(cmbQtyPaku.Text) / Val(KonversiPakuToKg)
    End Sub
End Class