Imports MySql.Data.MySqlClient

Public Class FormProduksiHitungManagement
    Dim PK As String = ""
    Dim statusHitung = 0
    Dim Merk

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    'FlagStatus : StatusSO,Stock
    Function check_stock(ByVal KdBarang As String)
        Dim sql_stock = ""
        sql_stock = " SELECT SUM(QtyKlemMentahDiterima) - IFNULL( ( " & _
                    " SELECT SUM(QtyKlemHitung) " & _
                    " FROM trhitungdetail " & _
                    " WHERE KdHitung <> '" & txtKdHitung.Text & "' " & _
                    " AND KdKlemHitung = tdd.KdKlemMentah " & _
                    " GROUP BY KdKlemHitung " & _
                    " ), 0 ) Stock " & _
                    " FROM trpantek_diterima td " & _
                    " JOIN trpantek_diterima_detail tdd ON td.KdPantekDiterima = tdd.KdPantekDiterima " & _
                    " WHERE StatusPantekDiterima = 1 " & _
                    " AND KdKlemMentah = '" & KdBarang & "' " & _
                    " GROUP BY KdKlemMentah "
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
        dtpHitung.Text = Now()
        gridKlemPantek.Rows.Clear()
        cmbKaryawan.SelectedIndex = 0
        txtAlamat.Text = ""
        txtTelepon.Text = ""
        emptyBarang()
    End Sub

    Private Sub emptyBarang()
        cmbKlemPantek.SelectedIndex = 0
        cmbKlemJadi.SelectedIndex = 0
        lblStokKlemPantek.Text = 0
        txtQtyKlemPantek.Text = 0
        txtQtyKlemJadi.Text = 0
    End Sub

    Private Sub setData()
        Try
            Dim SelectKaryawan = ""
            Dim readerHitung = execute_reader(" select KdHitung, DATE_FORMAT(TanggalHitung, '%m/%d/%Y') 'Tanggal', " & _
                                              " hitung.KdKaryawan, MK.NamaKaryawan, " & _
                                              " Alamat, MK.NoHP, StatusHitung " & _
                                              " from trhitung hitung " & _
                                              " Join mskaryawan MK On MK.KdKaryawan = hitung.KdKaryawan " & _
                                              " Where KdHitung = '" & PK & "' ")

            If readerHitung.Read() Then
                txtKdHitung.Text = readerHitung.Item("KdHitung")
                dtpHitung.Text = readerHitung.Item("Tanggal")
                SelectKaryawan = Trim(readerHitung.Item("KdKaryawan")) & " ~ " & readerHitung.Item("NamaKaryawan")
                statusHitung = readerHitung.Item("StatusHitung")
                If statusHitung <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerHitung.Close()

            cmbKaryawan.Text = SelectKaryawan
            Dim reader = execute_reader(" Select klem.KdBahanMentah 'KdKlem', klem.NamaBahanMentah 'NamaKlem', " & _
                                        " klem.Ukuran 'UkuranKlem', sum(QtyKlemHitung) QtyKlemPantek " & _
                                        " from trhitungdetail hitung " & _
                                        " Join MsBahanMentah klem On klem.KdBahanMentah = hitung.KdKlemHitung " & _
                                        " where KdHitung = '" & PK & "' " & _
                                        " GROUP BY klem.KdBahanMentah " & _
                                        " order by klem.NamaBahanMentah asc ")

            Do While reader.Read
                gridKlemPantek.Rows.Add()
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmKdKlemPantek").Value = reader("KdKlem")
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmUkuranKlemPantek").Value = reader("NamaKlem")
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmQtyKlemPantek").Value = reader("QtyKlemPantek")
            Loop
            reader.Close()

            Dim readerKlemJadi = execute_reader(" Select klem.KdBarang 'KdKlemJadi', klem.NamaBarang 'NamaKlemJadi', " & _
                                        " klem.Ukuran 'UkuranKlem', sum(QtyKlemJadi) QtyKlemJadi, " & _
                                        " Merk " & _
                                        " from trhitungdetail_hasil hitung " & _
                                        " Join MsBarang klem On klem.KdBarang = hitung.KdKlemJadi " & _
                                        " Join msmerk merk On merk.KdMerk = klem.KdMerk " & _
                                        " where KdHitung = '" & PK & "' " & _
                                        " GROUP BY klem.KdBarang " & _
                                        " order by klem.NamaBarang asc ")

            Do While readerKlemJadi.Read
                gridKlemJadi.Rows.Add()
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdKlemJadi").Value = readerKlemJadi("KdKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmUkuranKlemJadi").Value = readerKlemJadi("NamaKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmMerk").Value = readerKlemJadi("Merk")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyKlemJadi").Value = readerKlemJadi("QtyKlemJadi")
            Loop
            readerKlemJadi.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub setGrid()
        With gridKlemPantek.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridKlemPantek.ReadOnly = False

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

    Public Sub setCmbKlemPantek()
        Dim varT As String = ""
        cmbKlemPantek.Items.Clear()
        cmbKlemPantek.Items.Add("- Pilih Klem Pantek -")
        Dim reader = execute_reader(" Select MBM.KdBahanMentah, MBM.NamaBahanMentah, " & _
                                    " SUM(tdd.QtyKlemMentahDiterima) - IFNULL( ( " & _
                                    " SELECT SUM(QtyKlemHitung) " & _
                                    " FROM trhitungdetail " & _
                                    " WHERE KdHitung <> '" & txtKdHitung.Text & "' " & _
                                    " AND KdKlemHitung = tdd.KdKlemMentah " & _
                                    " GROUP BY KdKlemHitung " & _
                                    " ), 0 ) Stock " & _
                                    " from trpantek_diterima_detail tdd " & _
                                    " JOIN trpantek_diterima td ON td.KdPantekDiterima = tdd.KdPantekDiterima " & _
                                    " JOIN MsBahanMentah MBM ON tdd.KdKlemMentah = MBM.KdBahanMentah " & _
                                    " where 1 " & _
                                    " AND IsAktif = '1' " & _
                                    " AND MBM.jenis = 'Klem' " & _
                                    " AND td.StatusPantekDiterima = 1 " & _
                                    " GROUP BY MBM.KdBahanMentah " & _
                                    " HAVING Stock >  0 " & _
                                    " order by NamaBahanMentah asc ")
        Do While reader.Read
            cmbKlemPantek.Items.Add(reader("KdBahanMentah") & " ~ " & reader("NamaBahanMentah"))
        Loop
        reader.Close()
        If cmbKlemPantek.Items.Count > 0 Then
            cmbKlemPantek.SelectedIndex = 0
        End If
    End Sub

    Public Sub setCmbKlemJadi()
        Dim varT As String = ""
        cmbKlemJadi.Items.Clear()
        cmbKlemJadi.Items.Add("- Pilih Klem Jadi -")
        Dim reader = execute_reader(" Select MB.KdBarang, MB.NamaBarang " & _
                                    " from MsBarang MB " & _
                                    " where 1 " & _
                                    " AND IsAktif = '1' " & _
                                    " order by NamaBarang asc ")
        Do While reader.Read
            cmbKlemJadi.Items.Add(reader("KdBarang") & " ~ " & reader("NamaBarang"))
        Loop
        reader.Close()
        If cmbKlemJadi.Items.Count > 0 Then
            cmbKlemJadi.SelectedIndex = 0
        End If
    End Sub

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        clear_variable_array()
        setCmbKaryawan()
        setCmbKlemPantek()
        setCmbKlemJadi()
        emptyField()
        If PK <> "" Then
            setData()
            txtKdHitung.Text = PK
        Else
            generateCode()
        End If
    End Sub

    Private Sub generateCode()
        Dim code As String = "PH"
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
        sql = " select KdHitung " & _
              " from  trhitung " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("KdHitung")
        Else
            reader.Close()
            sql = " select KdHitung " & _
                  " from  trhitung_t " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("KdHitung")
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
        txtKdHitung.Text = Trim(code)
    End Sub

    Function SaveHitungDetail(ByVal flag As String)
        Dim sqlDetail = ""

        For i As Integer = 0 To gridKlemPantek.RowCount - 1
            Dim QtyKlemPantek = Val(gridKlemPantek.Rows.Item(i).Cells("clmQtyKlemPantek").Value)
            Dim KdKlemPantek = gridKlemPantek.Rows.Item(i).Cells("clmKdKlemPantek").Value
            Dim StokKlemPantek = check_stock(KdKlemPantek)
            If QtyKlemPantek > StokKlemPantek Then
                MsgBox("Jumlah klem pantek telah melebihi stok. Stok saat ini adalah " & StokKlemPantek)
                Return False
            Else
                sqlDetail = " insert into trhitungdetail ( KdHitung, KdKlemHitung, QtyKlemHitung " & _
                            " ) VALUES ( " & _
                            " '" & txtKdHitung.Text & "' , '" & Trim(KdKlemPantek) & "', " & _
                            " '" & QtyKlemPantek & "' ) "
                execute_update_manual(sqlDetail)
            End If
        Next

        For i As Integer = 0 To gridKlemJadi.RowCount - 1
            Dim QtyKlemJadi = Val(gridKlemJadi.Rows.Item(i).Cells("clmQtyKlemJadi").Value)
            Dim KdKlemJadi = gridKlemJadi.Rows.Item(i).Cells("clmKdKlemJadi").Value

            sqlDetail = " insert into trhitungdetail_hasil ( KdHitung, KdKlemJadi, QtyKlemJadi " & _
                        " ) VALUES ( " & _
                        " '" & txtKdHitung.Text & "' , '" & Trim(KdKlemJadi) & "', " & _
                        " '" & QtyKlemJadi & "' ) "
            execute_update_manual(sqlDetail)
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbKaryawan.SelectedIndex = 0 Then
            msgInfo("Karyawan harus dipilih")
            cmbKaryawan.Focus()
        ElseIf gridKlemPantek.RowCount = 0 Then
            msgInfo("Tambah klem pantek terlebih dahulu")
            cmbKlemPantek.Focus()
        ElseIf gridKlemJadi.RowCount = 0 Then
            msgInfo("Tambah klem jadi terlebih dahulu")
            cmbKlemJadi.Focus()
        Else
            Dim KdKar = cmbKaryawan.Text.ToString.Split("~")
            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction
            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try

                If PK = "" Then
                    sql = " insert into trhitung ( KdHitung, TanggalHitung, " & _
                          " KdKaryawan, KdUser, StatusHitung ) " & _
                          " values( '" & Trim(txtKdHitung.Text) & "', " & _
                          " '" & dtpHitung.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" + Trim(KdKar(0)) + "', " & _
                          " '" & Trim(kdKaryawan) & "', '" & flag & "' ) "

                    execute_update_manual(sql)
                Else
                    sql = " update trHitung  set  " & _
                          " TanggalHitung = '" & dtpHitung.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdKaryawan = '" & Trim(KdKar(0)) & "'," & _
                          " StatusHitung = '" & flag & "'," & _
                          " KdUser =  '" & Trim(kdKaryawan) & "' " & _
                          " where KdHitung = '" & Trim(txtKdHitung.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trhitungdetail where  KdHitung = '" & txtKdHitung.Text & "'")
                execute_update_manual("delete from trhitungdetail_hasil where  KdHitung = '" & txtKdHitung.Text & "'")
                If Not SaveHitungDetail(flag) Then
                    Return False
                End If
                trans.Commit()
                msgInfo("Data produksi hitung berhasil disimpan.")
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
            If cmbKlemPantek.SelectedIndex = 0 Then
                msgInfo("Klem Mentah harus dipilih")
                cmbKlemPantek.Focus()
            ElseIf Val(txtQtyKlemPantek.Text) = 0 Then
                msgInfo("Jumlah klem mentah harus berupa angka dan lebih besar dari 0")
                txtQtyKlemPantek.Focus()
            Else
                Dim KdKlem = cmbKlemPantek.Text.ToString.Split("~")
                Dim StokKlem = check_stock(KdKlem(0))
                Dim harga = 0
                Dim StatusBarang = ""

                If StokKlem < Val(txtQtyKlemPantek.Text) Then
                    MsgBox("Jumlah klem pantek melebihin stok. Stok saat ini " & StokKlem, MsgBoxStyle.Information, "Validation Error")
                Else
                    For i As Integer = 0 To (gridKlemPantek.RowCount - 1)
                        If gridKlemPantek.Rows(i).Cells("clmKdKlemPantek").Value.ToString = Trim(KdKlem(0)) Then
                            MsgBox("Klem sudah ada didalam grid.")
                            Exit Sub
                        End If
                    Next

                    gridKlemPantek.Rows.Add()
                    gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmKdKlemPantek").Value = Trim(KdKlem(0))
                    gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmUkuranKlemPantek").Value = Trim(KdKlem(1))
                    gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmQtyKlemPantek").Value = Val(txtQtyKlemPantek.Text)
                    emptyBarang()

                    gridKlemPantek.Focus()
                End If
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
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

    Private Sub browseKlemMentah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKlemPantek.Click
        Try
            data_carier(0) = txtKdHitung.Text
            sub_form = New FormBrowseKlemPantek
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbKlemPantek.Text = data_carier(0) & " ~ " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            gridKlemPantek.Rows.RemoveAt(gridKlemPantek.CurrentRow.Index)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridKlemJadi_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridKlemPantek.CellEndEdit
        Try
            Dim harga = 0
            Dim qtyKlem = Val(gridKlemPantek.CurrentRow.Cells("clmQtyKlemPantek").Value)
            Dim KdKlem = gridKlemPantek.CurrentRow.Cells("clmKdKlemPantek").Value
            Dim StokKlem = check_stock(KdKlem)

            If Val(qtyKlem) <= 0 Then
                MsgBox("Jumlah klem harus lebih besar dari 0", MsgBoxStyle.Information, "Validation Error")
                qtyKlem = 1
                gridKlemPantek.CurrentRow.Cells("clmQtyKlemPantek").Value = qtyKlem
                gridKlemPantek.CurrentRow.Cells("clmQtyKlemPantek").Selected = True
            ElseIf qtyKlem > StokKlem Then
                MsgBox("Jumlah klem pantek melebihin stok. Stok saat ini " & StokKlem, MsgBoxStyle.Information, "Validation Error")
                qtyKlem = StokKlem
                gridKlemPantek.CurrentRow.Cells("clmQtyKlemPantek").Value = qtyKlem
                gridKlemPantek.CurrentRow.Cells("clmQtyKlemPantek").Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub btnAddKlemJadi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAddKlemJadi.Click
        Try
            If cmbKlemJadi.SelectedIndex = 0 Then
                msgInfo("Klem jadi harus dipilih")
                cmbKlemJadi.Focus()
            Else
                Dim KdKlem = cmbKlemJadi.Text.ToString.Split("~")

                For i As Integer = 0 To (gridKlemJadi.RowCount - 1)
                    If gridKlemJadi.Rows(i).Cells("clmKdKlemJadi").Value.ToString = Trim(KdKlem(0)) Then
                        MsgBox("Klem sudah ada didalam grid.")
                        Exit Sub
                    End If
                Next

                gridKlemJadi.Rows.Add()
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdKlemJadi").Value = Trim(KdKlem(0))
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmUkuranKlemJadi").Value = Trim(KdKlem(1))
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmMerk").Value = Trim(Merk)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyKlemJadi").Value = Val(txtQtyKlemJadi.Text)
                emptyBarang()

                gridKlemJadi.Focus()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub browseKlemJadi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKlemJadi.Click
        Try
            sub_form = New FormBrowseBarang
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbKlemJadi.Text = data_carier(0) & " ~ " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnRemoveKlemJadi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemoveKlemJadi.Click
        Try
            gridKlemJadi.Rows.RemoveAt(gridKlemJadi.CurrentRow.Index)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridKlemJadi.CellEndEdit
        Try
            Dim harga = 0
            Dim qtyKlem = Val(gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Value)
            Dim KdKlem = gridKlemJadi.CurrentRow.Cells("clmKdKlemJadi").Value

            If Val(qtyKlem) < 0 Then
                MsgBox("Jumlah klem harus lebih besar atau sama dengan 0", MsgBoxStyle.Information, "Validation Error")
                qtyKlem = 1
                gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Value = qtyKlem
                gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub txtQtyKlemJadi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKlemJadi.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKlemJadi.Text <> "" Then
            btnAddKlemJadi_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmbKlemPantek_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKlemPantek.SelectedIndexChanged
        If cmbKlemPantek.SelectedIndex <> 0 Then
            Dim KdKlemPantek = cmbKlemPantek.Text.ToString.Split("~")

            lblStokKlemPantek.Text = check_stock(KdKlemPantek(0))
        Else
            lblStokKlemPantek.Text = 0
            txtQtyKlemPantek.Text = 0
        End If
    End Sub

    Private Sub cmbKlemJadi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKlemJadi.SelectedIndexChanged
        If cmbKlemJadi.SelectedIndex <> 0 Then
            Dim KdKlem = cmbKlemJadi.Text.ToString.Split("~")
            Dim reader = execute_reader(" SELECT Merk FROM MsMerk mm " & _
                                        " JOIN msbarang mb ON mb.KdMerk = mm.KdMerk " & _
                                        " WHERE mb.KdBarang = '" & KdKlem(0) & "' ")
            If reader.read Then
                Merk = reader("Merk")
            End If
        End If
    End Sub
End Class