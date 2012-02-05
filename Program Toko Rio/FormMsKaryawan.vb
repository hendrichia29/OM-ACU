Imports System.Data.SqlClient

Public Class FormMsKaryawan
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
        txtNama.Text = ""
        txtAlamat.Text = ""
        txtNoHp.Text = ""
        txtNoTelp.Text = "-"
        cmbJenisKaryawan.SelectedIndex = 0
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtNama.Enabled = status
        txtAlamat.Enabled = status
        txtNoTelp.Enabled = status
        txtNoHp.Enabled = status
        btnSave.Enabled = status
        btnCancel.Enabled = status
        cmbJenisKaryawan.Enabled = status

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

        If DataGridView1.RowCount > 0 Then
            Try
                txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
                txtNama.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
                txtAlamat.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
                txtNoTelp.Text = DataGridView1.CurrentRow.Cells(3).Value.ToString
                txtNoHp.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
                cmbJenisKaryawan.Text = DataGridView1.CurrentRow.Cells(5).Value.ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama Karyawan")
        cmbCari.Items.Add("Alamat")
        cmbCari.Items.Add("Nomor Telepon")
        cmbCari.Items.Add("Nomor HP")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = "select kdKaryawan Kode,NamaKaryawan 'Nama Karyawan',Alamat,NoTelp 'Nomor Telepon',NoHP 'Nomor HP',JenisKaryawan `Jenis Karyawan` from  " & tab
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama Karyawan" Then
                col = "NamaKaryawan"
            ElseIf opt = "Alamat" Then
                col = "Alamat"
            ElseIf opt = "Nomor Telepon" Then
                col = "NoTelp"
            ElseIf opt = "Nomor HP" Then
                col = "NoHP"
            End If
            sql &= "  where " & col & "  like '%" & cr & "%'  "
        Else
            sql &= "  where kdKaryawan <>'SL00000000'"
        End If
        sql &= " Order By NamaKaryawan "

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
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 180
        DataGridView1.Columns(2).Width = 130
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 150

    End Sub
    Public Sub setCmbJenis()
        cmbJenisKaryawan.Items.Clear()
        cmbJenisKaryawan.Items.Add("Menhitung Klem")
        cmbJenisKaryawan.Items.Add("Memantek Klem")
        cmbJenisKaryawan.Items.Add("Menhitung & memantek Klem")
    End Sub

    Private Sub FormMsKaryawan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsKaryawan "
        PK = "  KdKaryawan "
        ubahAktif(False)
        viewAllData("", "")
        posisi = 0
        setData()
        setGrid()
        setCmbCari()
        setCmbJenis()
    End Sub
    Private Sub generateCode()
        Dim code As String = "KY"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)

        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If

        Dim reader = getCode("MsKaryawan", "KdKaryawan")

        If reader.read Then
            kode = Trim(reader(0).ToString())
            temp = kode.Substring(0, 6)
            If temp = code Then
                angka = CInt(kode.Substring(6, 4))
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

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            posisi = e.RowIndex
            setData()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub txtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNama.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNama.Text <> "" Then
            txtAlamat.Focus()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        emptyField()
        generateCode()
        ubahAktif(True)
        status = "add"
        txtNama.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (DataGridView1.RowCount) Then
            ubahAktif(True)
            status = "update"
            txtNama.Focus()
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (DataGridView1.RowCount) Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            If MsgBox("Anda yakin ingin menghapus kode Karyawan " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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
        If txtNama.Text = "" Then
            msgInfo("Nama Karyawan harus diisi")
            txtNama.Focus()
        ElseIf txtAlamat.Text = "" Then
            msgInfo("Alamat harus diisi")
            txtAlamat.Focus()
        ElseIf txtNoTelp.Text = "" Then
            msgInfo("Nomor telepon harus diisi")
            txtNoTelp.Focus()
        Else

            If status = "add" Then
                sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "','" & Trim(txtNama.Text) & "', " & _
                      "'" & Trim(txtAlamat.Text) & "','" & Trim(txtNoTelp.Text) & "','" & Trim(txtNoHp.Text) & "','" & Trim(cmbJenisKaryawan.Text) & "')"
                Try
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                    'txtNoPolisi.Text = ""
                End Try
            ElseIf status = "update" Then
                Try
                    sql = "update   " & tab & "  set  NamaKaryawan='" & Trim(txtNama.Text) & "', " & _
                          "Alamat='" & Trim(txtAlamat.Text) & "', " & _
                          "NoTelp='" & Trim(txtNoTelp.Text) & "', " & _
                          "NoHP='" & Trim(txtNoHp.Text) & "',jeniskaryawan='" & Trim(cmbJenisKaryawan.Text) & "' " & _
                          "where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtNama.Text = ""
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

    Private Sub txtAlamat_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtAlamat.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
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
            cmbJenisKaryawan.Focus()
        End If
    End Sub

    Private Sub txtKomisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And cmbJenisKaryawan.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub
End Class