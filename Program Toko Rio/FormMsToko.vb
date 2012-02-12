Imports System.Data.SqlClient
Public Class FormMsToko
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        txtCari.Text = ""
        txtNamaToko.Text = ""
        txtOwner.Text = ""
        txtAlamat.Text = ""

        txtDaerah.Text = ""

        txtNoTelp.Text = ""
        txtNoHp.Text = ""
        txtNoFax.Text = ""
        txtJatuhTempo.Text = ""
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtNamaToko.Enabled = status
        txtOwner.Enabled = status
        txtAlamat.Enabled = status

        txtDaerah.Enabled = status

        txtNoTelp.Enabled = status
        txtNoHp.Enabled = status
        txtNoFax.Enabled = status
        txtJatuhTempo.Enabled = status
        cmbSales.Enabled = status

        btnSave.Enabled = status
        btnCancel.Enabled = status
        btnExit.Enabled = Not status
        GroupBox1.Enabled = Not status

        btnSave.Enabled = status
        btnCancel.Enabled = status
        btnAdd.Enabled = Not status
        btnUpdate.Enabled = Not status
        btnDelete.Enabled = Not status
        DataGridView1.Enabled = Not status

    End Sub

    Private Sub setData()

        If jumData > 0 Then
            Try
                txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
                txtNamaToko.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                txtOwner.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                txtAlamat.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                'cmbArea.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString & " - " & DataGridView1.CurrentRow.Cells(5).Value.ToString
                txtDaerah.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                'cmbEkspedisi.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString & " - " & DataGridView1.CurrentRow.Cells(8).Value.ToString
                txtNoTelp.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
                txtNoHp.Text = DataGridView1.CurrentRow.Cells(6).Value.ToString
                txtNoFax.Text = DataGridView1.CurrentRow.Cells(7).Value.ToString
                txtJatuhTempo.Text = DataGridView1.CurrentRow.Cells(8).Value.ToString
                cmbSales.Text = DataGridView1.CurrentRow.Cells("KdSales").Value.ToString & "-" & DataGridView1.CurrentRow.Cells("NamaSales").Value.ToString
            Catch ex As Exception
            End Try
        End If



        
        

    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama Toko")
        cmbCari.Items.Add("Nama Owner")
        cmbCari.Items.Add("Nama Daerah")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select kdtoko Kode,NamaToko 'Nama Toko',NamaOwner 'Nama Pemilik', " & _
              " AlamatToko 'Alamat Toko', " & _
              " Daerah,mt.NoTelp 'Nomor Telepon', " & _
              " mt.NoHP 'Nomor HP',mt.NoFax 'Nomor Fax', JatuhTempo 'Jatuh Tempo' " & _
              " ,ms.KdSales,NamaSales from  " & tab & " mt left join mssales ms on ms.kdsales=mt.kdsales "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama Toko" Then
                col = "NamaToko"
            ElseIf opt = "Nama Owner" Then
                col = "NamaOwner"
            ElseIf opt = "Nama Dearah" Then
                col = "Daerah"
            End If
            sql &= "  where " & col & "  like '%" & cr & "%' "
        End If

        DataGridView1.DataSource = execute_datatable(sql)
        jumData = DataGridView1.RowCount
        If jumData > 0 Then
            posisi = jumData
            setData()
        End If
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        DataGridView1.Columns("Kode").Width = 100
        DataGridView1.Columns("Nama Toko").Width = 150
        DataGridView1.Columns("Nama Pemilik").Width = 150
        DataGridView1.Columns("Alamat Toko").Width = 150
        DataGridView1.Columns("Daerah").Width = 150
        DataGridView1.Columns("Nomor Telepon").Width = 100
        DataGridView1.Columns("Nomor HP").Width = 100
        DataGridView1.Columns("Nomor Fax").Width = 150
        DataGridView1.Columns("Jatuh Tempo").Width = 100

    End Sub
    Public Sub setCmbSales()
        Dim varT As String = ""
        cmbSales.Items.Clear()
        cmbSales.Items.Add("- Pilih Sales -")
        Dim reader = execute_reader(" Select * from MsSales " & _
                                    " where NamaSales <>'' " & _
                                    " order by NamaSales asc")
        Do While reader.Read
            cmbSales.Items.Add(reader("KdSales") & " - " & reader("NamaSales"))
        Loop
        reader.Close()
        If cmbSales.Items.Count > 0 Then
            cmbSales.SelectedIndex = 0
        End If
        reader.Close()
    End Sub
    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsToko "
        PK = "  KdToko  "
        ubahAktif(False)
        viewAllData("", "")
        posisi = 0
        setData()
        setGrid()
        setCmbCari()
        setCmbSales()
    End Sub

    Private Sub generateCode()
        Dim code As String = "TK"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")

        code += FormatDate

        Dim reader = getCode("MsToko", "KdToko")

        If reader.read Then
            kode = Trim(reader(0).ToString())
            temp = kode.Substring(0, 8)
            If temp = code Then
                angka = CInt(kode.Substring(8, 4))
            Else
                angka = 0
            End If
        Else
            angka = 0
        End If
        reader.close()

        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            posisi = e.RowIndex
            setData()
        End If
    End Sub

    Private Sub btnAdd_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        emptyField()
        generateCode()
        ubahAktif(True)
        status = "add"
        txtNamaToko.Focus()
    End Sub

    Private Sub btnUpdate_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ubahAktif(True)
        status = "update"
        txtNamaToko.Focus()
    End Sub

    Private Sub btnDelete_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (DataGridView1.RowCount) Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            If MsgBox("Anda yakin ingin menghapus kode toko " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "'")
                msgInfo("Data berhasil dihapus")
                posisi = 0
                viewAllData("", "")
                setData()
            End If
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNamaToko.Text = "" Then
            msgInfo("Nama toko harus diisi")
            txtNamaToko.Focus()
        ElseIf txtOwner.Text = "" Then
            msgInfo("Nama Owner harus diisi")
            txtOwner.Focus()
        ElseIf txtAlamat.Text = "" Then
            msgInfo("Nama alamat harus diisi")
            txtAlamat.Focus()
        ElseIf txtNoTelp.Text = "" Then
            msgInfo("No telepon harus diisi")
            txtNoTelp.Focus()
        ElseIf txtJatuhTempo.Text = "" Then
            msgInfo("Jatuh Tempo harus diisi")
            txtJatuhTempo.Focus()
        ElseIf cmbSales.Text = "- Pilih Sales -" Then
            msgInfo("Sales harus dipilih")
            cmbSales.Focus()
        Else
            Dim areaID = ""
            Dim EkspedisiID = ""
            Dim salesID = cmbSales.Text.ToString.Split("-")

            If status = "add" Then
                sql = " insert into  " & tab & " ( KdToko, NamaToko, NamaOwner, " & _
                      " AlamatToko, Daerah, NoTelp, NoHP, NoFax, JatuhTempo,KdSales) " & _
                      " values('" + Trim(txtID.Text) + "','" & Trim(txtNamaToko.Text) & "', " & _
                      " '" & Trim(txtOwner.Text) & "','" & Trim(txtAlamat.Text) & "', " & _
                      " '" & Trim(txtDaerah.Text) & "', " & _
                      " '" & Trim(txtNoTelp.Text) & "','" & Trim(txtNoHp.Text) & "', " & _
                      " '" & Trim(txtNoFax.Text) & "','" & Trim(txtJatuhTempo.Text) & "', " & _
                      " '" & salesID(0) & "')"
                Try
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                End Try
            ElseIf status = "update" Then
                Try
                    sql = " update   " & tab & "  set " & _
                          " NamaToko='" & Trim(txtNamaToko.Text) & "', " & _
                          " NamaOwner='" & Trim(txtOwner.Text) & "', " & _
                          " AlamatToko = '" & Trim(txtAlamat.Text) & "', " & _
                          " Daerah = '" & Trim(txtDaerah.Text) & "', " & _
                          " NoTelp = '" & Trim(txtNoTelp.Text) & "', " & _
                          " NoHP = '" & Trim(txtNoHp.Text) & "', " & _
                          " NoFax='" & Trim(txtNoFax.Text) & "', " & _
                          " JatuhTempo = '" & Trim(txtJatuhTempo.Text) & "', " & _
                          " KdSales='" & salesID(0) & "'" & _
                          " where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtNamaToko.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If status = "add" Then
            posisi = 0
        End If
        ubahAktif(False)
        setData()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtNamaToko_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamaToko.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNamaToko.Text <> "" Then
            txtOwner.Focus()
        End If
    End Sub

    Private Sub txtOwner_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtOwner.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtOwner.Text <> "" Then
            txtAlamat.Focus()
        End If
    End Sub

    Private Sub txtAlamat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlamat.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtDaerah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDaerah.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtDaerah.Text <> "" Then
            txtNoTelp.Focus()
        End If
    End Sub

    Private Sub txtNoTelp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoTelp.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNoTelp.Text <> "" Then
            txtNoHp.Focus()
        End If
    End Sub

    Private Sub txtNoHp_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoHp.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNoHp.Text <> "" Then
            txtNoFax.Focus()
        End If
    End Sub

    Private Sub txtNoFax_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoFax.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNoFax.Text <> "" Then
            txtJatuhTempo.Focus()
        End If
    End Sub

    Private Sub txtJatuhTempo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJatuhTempo.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtJatuhTempo.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub
End Class
