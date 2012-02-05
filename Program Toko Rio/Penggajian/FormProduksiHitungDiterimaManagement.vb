Imports MySql.Data.MySqlClient

Public Class FormProduksiHitungDiterimaManagement
    Dim PK As String = ""
    Dim statusHitung = 0
    Dim KdKaryawan = ""
    Dim Merk = ""
    Dim KdMerk = ""
    Dim IsiMerk = 0
    Dim IsiMerkPrioritas = 0
    Dim KdMerkPrioritas = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpHitungDiterima.Text = ""
        gridKlemPantek.Rows.Clear()
        gridKlemHitung.Rows.Clear()
        cmbKaryawan.Text = ""
        KdKaryawan = ""
        txtAlamat.Text = ""
        txtTelepon.Text = ""
        emptyBarang()
    End Sub

    Function emptyBarang()
        cmbKlemJadi.SelectedIndex = 0
        txtQtyKlemJadi.Text = 0
        txtHarga.Text = 0
        Return True
    End Function

    Private Sub setData()
        Try
            Dim KdHitung = ""
            Dim readerHitung = execute_reader(" select KdHitungDiterima, DATE_FORMAT(TanggalHitungDiterima, '%m/%d/%Y') 'Tanggal', " & _
                                              " hitung.KdKaryawan, MK.NamaKaryawan, " & _
                                              " Alamat, MK.NoHP, StatusHitungDiterima, KdHitung " & _
                                              " from trhitung_diterima hitung " & _
                                              " Join mskaryawan MK On MK.KdKaryawan = hitung.KdKaryawan " & _
                                              " Where KdHitungDiterima = '" & PK & "' ")

            If readerHitung.Read() Then
                txtKdHitungDiterima.Text = readerHitung.Item("KdHitungDiterima")
                dtpHitungDiterima.Text = readerHitung.Item("Tanggal")
                cmbKaryawan.Text = readerHitung.Item("NamaKaryawan")
                KdKaryawan = Trim(readerHitung.Item("KdKaryawan"))
                statusHitung = readerHitung.Item("StatusHitungDiterima")
                KdHitung = readerHitung.Item("KdHitung")
                If statusHitung <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerHitung.Close()

            cmbKdHitung.Text = KdHitung

            Dim readerKlemJadi = execute_reader(" Select klem.KdBarang 'KdKlemJadi', klem.NamaBarang 'NamaKlemJadi', " & _
                                                " klem.Ukuran 'UkuranKlem', sum(QtyKlemJadi) QtyKlemJadi, " & _
                                                " HargaModalKlemJadi, Merk, mm.KdMerk, " & _
                                                " mm.Isi, QtyKlemPrioritas " & _
                                                " from trhitungdetail_diterima hitung " & _
                                                " Join MsBarang klem On klem.KdBarang = hitung.KdKlemJadi " & _
                                                " Join msmerk mm On mm.KdMerk = klem.KdMerk " & _
                                                " where KdHitungDiterima = '" & PK & "' " & _
                                                " GROUP BY klem.KdBarang " & _
                                                " order by klem.NamaBarang asc ")

            gridKlemJadi.Rows.Clear()
            Do While readerKlemJadi.Read
                gridKlemJadi.Rows.Add()
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdKlemJadi").Value = readerKlemJadi("KdKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmUkuranKlemJadi").Value = readerKlemJadi("NamaKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmMerkJadi").Value = readerKlemJadi("Merk")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdMerk").Value = readerKlemJadi("KdMerk")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmIsiMerk").Value = readerKlemJadi("Isi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmHargaModalKlemJadi").Value = readerKlemJadi("HargaModalKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyKlemJadi").Value = readerKlemJadi("QtyKlemJadi")
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyPrioritas").Value = readerKlemJadi("QtyKlemPrioritas")
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

    Public Sub setCmbKlemJadi()
        Dim varT As String = ""
        cmbKlemJadi.Items.Clear()
        cmbKlemJadi.Items.Add("- Pilih Klem Jadi -")
        Dim reader = execute_reader(" Select MB.KdBarang, MB.NamaBarang " & _
                                    " from MsBarang MB " & _
                                    " JOIN trhitungdetail_hasil thd ON MB.KdBarang = thd.KdKlemJadi " & _
                                    " where 1 " & _
                                    " AND MB.IsAktif = '1' " & _
                                    " AND thd.KdHitung = '" & cmbKdHitung.Text & "' " & _
                                    " order by MB.NamaBarang asc ")
        Do While reader.Read
            cmbKlemJadi.Items.Add(reader("KdBarang") & " ~ " & reader("NamaBarang"))
        Loop
        reader.Close()
        If cmbKlemJadi.Items.Count > 0 Then
            cmbKlemJadi.SelectedIndex = 0
        End If
    End Sub

    Public Sub setCmbKdHitung()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbKdHitung.Items.Clear()
        cmbKdHitung.Items.Add("- Pilih Klem Jadi -")
        If PK = "" Then
            addQuery = " AND NOT EXISTS ( " & _
                       " SELECT 1 FROM trhitung_diterima th " & _
                       " WHERE th.KdHitung = trhitung.KdHitung " & _
                       " ) " & _
                       " AND StatusHitung = 1 "
        End If
        Dim reader = execute_reader(" SELECT KdHitung FROM trhitung " & _
                                    " WHERE TelahDihitung = 0 " & _
                                    addQuery & _
                                    " ORDER BY no_increment DESC")
        Do While reader.Read
            cmbKdHitung.Items.Add(reader("KdHitung"))
        Loop
        reader.Close()
        If cmbKdHitung.Items.Count > 0 Then
            cmbKdHitung.SelectedIndex = 0
        End If
    End Sub

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        clear_variable_array()
        setCmbKlemJadi()
        setCmbKdHitung()
        emptyField()
        If PK <> "" Then
            setData()
            txtKdHitungDiterima.Text = PK
        Else
            generateCode()
        End If

        Dim ReaderPrioritas = GetPrioritasMerk()
        If ReaderPrioritas.read Then
            gridKlemJadi.Columns("clmQtyPrioritas").HeaderText = "Conversi ke " & ReaderPrioritas("Merk")
            KdMerkPrioritas = ReaderPrioritas("KdMerk")
            IsiMerkPrioritas = ReaderPrioritas("Isi")
        End If
        ReaderPrioritas.close()
    End Sub

    Private Sub generateCode()
        Dim code As String = "HD"
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
        sql = " select KdHitungDiterima " & _
              " from  trhitung_diterima " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("KdHitungDiterima")
        Else
            reader.Close()
            sql = " select KdHitungDiterima " & _
                  " from  trhitung_diterima_t " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("KdHitungDiterima")
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
        txtKdHitungDiterima.Text = Trim(code)
    End Sub

    Function SaveHitungDetail(ByVal flag As String)
        Dim sqlDetail = ""

        For i As Integer = 0 To gridKlemJadi.RowCount - 1
            Dim QtyKlemJadi = CInt(gridKlemJadi.Rows.Item(i).Cells("clmQtyKlemJadi").Value)
            Dim QtyPrioritas = CInt(gridKlemJadi.Rows.Item(i).Cells("clmQtyPrioritas").Value)
            Dim KdKlemJadi = gridKlemJadi.Rows.Item(i).Cells("clmKdKlemJadi").Value
            Dim HargaModal = gridKlemJadi.Rows.Item(i).Cells("clmHargaModalKlemJadi").Value
            Dim OP = "Plus"
            Dim Attribute = "QtyProd_Plus"

            If flag = 1 Then
                StockBarang(QtyKlemJadi, OP, HargaModal, KdKlemJadi, Attribute, Trim(txtKdHitungDiterima.Text), "Form Produksi Hitung Klem")
            End If

            sqlDetail = " insert into trhitungdetail_diterima ( KdHitungDiterima, " & _
                        " KdKlemJadi, QtyKlemJadi, HargaModalKlemJadi, QtyKlemPrioritas " & _
                        " ) VALUES ( " & _
                        " '" & txtKdHitungDiterima.Text & "' , '" & Trim(KdKlemJadi) & "', " & _
                        " '" & QtyKlemJadi & "', '" & HargaModal & "', '" & QtyPrioritas & "' ) "
            execute_update_manual(sqlDetail)
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbKaryawan.Text = "" Then
            msgInfo("Karyawan tidak boleh kosong")
            cmbKaryawan.Focus()
        ElseIf cmbKdHitung.SelectedIndex = 0 Then
            msgInfo("No Keluar harus dipilih")
            cmbKdHitung.Focus()
        ElseIf gridKlemJadi.RowCount = 0 Then
            msgInfo("Tambah klem jadi terlebih dahulu")
            cmbKlemJadi.Focus()
        Else
            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction
            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try

                If PK = "" Then
                    sql = " insert into trhitung_diterima ( KdHitungDiterima, TanggalHitungDiterima, " & _
                          " KdHitung, KdKaryawan, KdUser, StatusHitungDiterima ) " & _
                          " values( '" & Trim(txtKdHitungDiterima.Text) & "', " & _
                          " '" & dtpHitungDiterima.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(cmbKdHitung.Text) & "', '" + Trim(KdKaryawan) + "', " & _
                          " '" & Trim(KdKaryawan) & "', '" & flag & "' ) "

                    execute_update_manual(sql)
                Else
                    sql = " update trhitung_diterima  set  " & _
                          " TanggalHitungDiterima = '" & dtpHitungDiterima.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdHitung = '" & Trim(cmbKdHitung.Text) & "'," & _
                          " KdKaryawan = '" & Trim(KdKaryawan) & "'," & _
                          " StatusHitungDiterima = '" & flag & "'," & _
                          " KdUser =  '" & Trim(KdKaryawan) & "' " & _
                          " where KdHitungDiterima = '" & Trim(txtKdHitungDiterima.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trhitungdetail_diterima where KdHitungDiterima = '" & txtKdHitungDiterima.Text & "'")
                If Not SaveHitungDetail(flag) Then
                    Return False
                End If
                trans.Commit()
                msgInfo("Data produksi hitung diterima berhasil disimpan.")
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

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub browseKlemJadi_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbKlemJadi.SelectedIndex = 0 Then
                msgInfo("Klem Mentah harus dipilih")
                cmbKlemJadi.Focus()
            ElseIf Val(txtQtyKlemJadi.Text) = 0 Then
                msgInfo("Jumlah klem harus berupa angka dan lebih besar dari 0")
                txtQtyKlemJadi.Focus()
            ElseIf Val(txtHarga.Text) = 0 Then
                msgInfo("Harga modal klem harus berupa angka dan lebih besar dari 0")
                txtHarga.Focus()
            Else
                Dim KdKlem = cmbKlemJadi.Text.ToString.Split("~")
                Dim harga = 0
                Dim QtyPrioritas = Val(txtQtyKlemJadi.Text)
                For i As Integer = 0 To (gridKlemJadi.RowCount - 1)
                    If gridKlemJadi.Rows(i).Cells("clmKdKlemJadi").Value.ToString = Trim(KdKlem(0)) Then
                        MsgBox("Klem sudah ada didalam grid.")
                        Exit Sub
                    End If
                Next
                If KdMerkPrioritas <> KdMerk Then
                    QtyPrioritas = (CInt(txtQtyKlemJadi.Text) * CInt(IsiMerk)) / CInt(IsiMerkPrioritas)
                End If

                gridKlemJadi.Rows.Add()
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdKlemJadi").Value = Trim(KdKlem(0))
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmUkuranKlemJadi").Value = Trim(KdKlem(1))
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmMerkJadi").Value = Trim(Merk)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmKdMerk").Value = Trim(KdMerk)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmIsiMerk").Value = Trim(IsiMerk)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmHargaModalKlemJadi").Value = Val(txtHarga.Text)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyKlemJadi").Value = CInt(txtQtyKlemJadi.Text)
                gridKlemJadi.Rows.Item(gridKlemJadi.RowCount - 1).Cells("clmQtyPrioritas").Value = CInt(QtyPrioritas)
                emptyBarang()

                gridKlemJadi.Focus()
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

    Private Sub gridBarang_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gridKlemJadi.CellBeginEdit
        
    End Sub

    Private Sub txtQtyKlemJadi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKlemJadi.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKlemJadi.Text <> "" Then
            txtHarga.Focus()
        End If
    End Sub

    Private Sub cmbKdHitung_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKdHitung.SelectedIndexChanged
        If cmbKdHitung.SelectedIndex <> 0 Then
            Dim readerkaryawan = execute_reader(" Select MK.KdKaryawan, NamaKaryawan, NoHP, " & _
                                                " Alamat from trhitung hitung " & _
                                                " Join mskaryawan MK On MK.KdKaryawan = hitung.KdKaryawan " & _
                                                " where KdHitung = '" & cmbKdHitung.Text & "' ")

            If readerkaryawan.read Then
                cmbKaryawan.Text = readerkaryawan("NamaKaryawan")
                txtAlamat.Text = readerkaryawan("Alamat")
                txtTelepon.Text = readerkaryawan("NoHP")
                KdKaryawan = readerkaryawan("KdKaryawan")
            End If
            readerkaryawan.close()

            Dim reader = execute_reader(" Select klem.KdBahanMentah 'KdKlem', klem.NamaBahanMentah 'NamaKlem', " & _
                                        " klem.Ukuran 'UkuranKlem', sum(QtyKlemHitung) QtyKlemPantek " & _
                                        " from trhitungdetail hitung " & _
                                        " Join MsBahanMentah klem On klem.KdBahanMentah = hitung.KdKlemHitung " & _
                                        " where KdHitung = '" & cmbKdHitung.Text & "' " & _
                                        " GROUP BY klem.KdBahanMentah " & _
                                        " order by klem.NamaBahanMentah asc ")

            gridKlemPantek.Rows.Clear()
            Do While reader.Read
                gridKlemPantek.Rows.Add()
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmKdKlemPantek").Value = reader("KdKlem")
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmUkuranKlemPantek").Value = reader("NamaKlem")
                gridKlemPantek.Rows.Item(gridKlemPantek.RowCount - 1).Cells("clmQtyKlemPantek").Value = reader("QtyKlemPantek")
            Loop
            reader.Close()

            Dim readerKlemHitung = execute_reader(" Select klem.KdBarang 'KdKlemJadi', klem.NamaBarang 'NamaKlemJadi', " & _
                                                " klem.Ukuran 'UkuranKlem', sum(QtyKlemJadi) QtyKlemJadi, " & _
                                                " Merk, mm.KdMerk " & _
                                                " from trhitungdetail_hasil hitung " & _
                                                " Join MsBarang klem On klem.KdBarang = hitung.KdKlemJadi " & _
                                                " Join msmerk mm On mm.KdMerk = klem.KdMerk " & _
                                                " where KdHitung = '" & cmbKdHitung.Text & "' " & _
                                                " GROUP BY klem.KdBarang " & _
                                                " order by klem.NamaBarang asc ")

            gridKlemHitung.Rows.Clear()
            Do While readerKlemHitung.Read
                gridKlemHitung.Rows.Add()
                gridKlemHitung.Rows.Item(gridKlemHitung.RowCount - 1).Cells("clmKdKlemHitung").Value = readerKlemHitung("KdKlemJadi")
                gridKlemHitung.Rows.Item(gridKlemHitung.RowCount - 1).Cells("clmUkuranKlemHitung").Value = readerKlemHitung("NamaKlemJadi")
                gridKlemHitung.Rows.Item(gridKlemHitung.RowCount - 1).Cells("clmMerk").Value = readerKlemHitung("Merk")
                gridKlemHitung.Rows.Item(gridKlemHitung.RowCount - 1).Cells("clmQtyKlemHitung").Value = readerKlemHitung("QtyKlemJadi")
            Loop
            readerKlemHitung.Close()

            setCmbKlemJadi()
        Else
            dtpHitungDiterima.Text = ""
            gridKlemPantek.Rows.Clear()
            gridKlemHitung.Rows.Clear()
            cmbKaryawan.Text = ""
            KdKaryawan = ""
            txtAlamat.Text = ""
            txtTelepon.Text = ""
        End If
    End Sub

    Private Sub browseKdHitung_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKdHitung.Click
        Try
            data_carier(0) = PK
            sub_form = New FormBrowseHitungKeluar
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbKdHitung.Text = data_carier(0)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub browseKlemJadi_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseKlemJadi.Click
        Try
            If cmbKdHitung.SelectedIndex <> 0 Then
                data_carier(0) = cmbKdHitung.Text
                data_carier(1) = "HitungKlem"
                sub_form = New FormBrowseBarang
                sub_form.showDialog(FormMain)
                If data_carier(0) <> "" Then
                    cmbKlemJadi.Text = data_carier(0) & " ~ " & data_carier(1)
                    clear_variable_array()
                End If
            Else
                MsgBox("Silakan pilih No. Keluar terlebih dahulu", MsgBoxStyle.Information)
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub txtHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
            btnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub cmbKlemJadi_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbKlemJadi.SelectedIndexChanged
        If cmbKlemJadi.SelectedIndex <> 0 Then
            Dim KdKlem = cmbKlemJadi.Text.ToString.Split("~")
            Dim reader = execute_reader(" SELECT Merk, mm.KdMerk, mm.Isi FROM MsMerk mm " & _
                                        " JOIN msbarang mb ON mb.KdMerk = mm.KdMerk " & _
                                        " WHERE mb.KdBarang = '" & KdKlem(0) & "' ")
            If reader.read Then
                Merk = reader("Merk")
                KdMerk = reader("KdMerk")
                IsiMerk = reader("Isi")
            End If
        End If
    End Sub

    Private Sub gridKlemJadi_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridKlemJadi.CellEndEdit
        Try
            Dim harga = 0
            Dim qtyKlem = CInt(gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Value)
            Dim qtyPrioritas = CInt(gridKlemJadi.CurrentRow.Cells("clmQtyPrioritas").Value)
            Dim KdKlem = gridKlemJadi.CurrentRow.Cells("clmKdKlemJadi").Value
            Dim HargaModal = gridKlemJadi.CurrentRow.Cells("clmHargaModalKlemJadi").Value
            Dim CurrKdMerk = gridKlemJadi.CurrentRow.Cells("clmKdMerk").Value
            Dim CurrIsiMerk = CInt(gridKlemJadi.CurrentRow.Cells("clmIsiMerk").Value)

            If Val(qtyKlem) <= 0 Then
                MsgBox("Jumlah klem harus lebih besar dari 0", MsgBoxStyle.Information, "Validation Error")
                qtyKlem = 1
                gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Selected = True
            ElseIf Val(HargaModal) <= 0 Then
                MsgBox("Harga modal klem harus lebih besar dari 0", MsgBoxStyle.Information, "Validation Error")
                HargaModal = 1
                gridKlemJadi.CurrentRow.Cells("clmHargaModalKlemJadi").Selected = True
            End If

            If KdMerkPrioritas <> CurrKdMerk Then
                qtyPrioritas = (qtyKlem * CurrIsiMerk) / CInt(IsiMerkPrioritas)
            Else
                qtyPrioritas = qtyKlem
            End If
            gridKlemJadi.CurrentRow.Cells("clmQtyKlemJadi").Value = CInt(qtyKlem)
            gridKlemJadi.CurrentRow.Cells("clmQtyPrioritas").Value = CInt(qtyPrioritas)
            gridKlemJadi.CurrentRow.Cells("clmHargaModalKlemJadi").Value = Val(HargaModal)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub
End Class