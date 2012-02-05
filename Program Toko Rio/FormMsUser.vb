Imports System.Data.SqlClient

Public Class FormMsUser
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
        txtNoPolisi.Text = ""
        txtNama.Text = ""
        txtNamaL.Text = ""
        cmbLevel.SelectedIndex = 0
        txtCari.Text = ""
    End Sub

    Private Sub setData()
        Dim index As Integer = 0
        Dim temp As String = ""
        Try
            txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            txtNoPolisi.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            txtNama.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            txtNamaL.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString 'level

            If DataGridView1.CurrentRow.Cells(3).Value.ToString = 1 Then
                temp = "1 - " & "Staff rio"
            ElseIf DataGridView1.CurrentRow.Cells(3).Value.ToString = 2 Then
                temp = "2 - " & "Staff lain"
            ElseIf DataGridView1.CurrentRow.Cells(3).Value.ToString = 3 Then
                temp = "3 - " & "Superuser"
            End If

            cmbLevel.Text = temp

        Catch ex As Exception
        End Try
    End Sub

    Private Sub generateCode()
        Dim code As String = "US"
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

        Dim reader = getCode("msuser", "UserID")

        If reader.read Then
            kode = reader(0).ToString()
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
        txtID.Text = code
    End Sub

    Private Sub viewAllData(ByVal cr As String)
        sql = "select UserID 'User ID',Username,NamaLengkap 'Nama Lengkap',Level, Password from  " & tab
        If cr <> "" Then
            sql = sql & "  where username like '%" & cr & "%'"
        End If

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub ubahAktif(ByVal b As Boolean)
        txtID.Enabled = False
        txtNoPolisi.Enabled = b
        txtNama.Enabled = b
        txtNamaL.Enabled = b

        btnSave.Enabled = b
        btnCancel.Enabled = b
        btnExit.Enabled = Not b

        btnAdd.Enabled = Not b
        btnUpdate.Enabled = Not b
        btnDelete.Enabled = Not b
        DataGridView1.Enabled = Not b

        If txtID.Text <> "US11010001" Then
            cmbLevel.Enabled = b
        End If
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold
        End With
        DataGridView1.Columns(0).Width = 80
        DataGridView1.Columns(1).Width = 150
        DataGridView1.Columns(2).Width = 150
        DataGridView1.Columns(3).Width = 80
        DataGridView1.Columns(4).Width = 180
    End Sub
    Public Sub setComboLevel()
        cmbLevel.Items.Clear()
        cmbLevel.Items.Add("- Pilih level -")
        cmbLevel.Items.Add("1 - Staff rio")
        cmbLevel.Items.Add("2 - Staff lain")
        cmbLevel.Items.Add("3 - Superuser")
        cmbLevel.SelectedIndex = 0
    End Sub

    Private Sub FormMsUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsUser "
        PK = "  UserID  "

        setComboLevel()
        ubahAktif(False)
        viewAllData("")
        posisi = 0
        setData()
        setGrid()

    End Sub
    Private Sub DataGridView1_CellClick1(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            posisi = e.RowIndex
            setData()
        End If
    End Sub



    Private Sub txtNoHP_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtJumlah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtNoPolisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoPolisi.KeyPress
        If AscW(e.KeyChar) = 13 And txtNoPolisi.Text <> "" Then
            txtNama.Focus()
        End If
    End Sub

    Private Sub txtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNama.KeyPress
        If AscW(e.KeyChar) = 13 And txtNama.Text <> "" Then
            txtNamaL.Focus()
        End If
    End Sub

    Private Sub txtNamaL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamaL.KeyPress
        If AscW(e.KeyChar) = 13 Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub DataGridView1_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text)
    End Sub


    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        generateCode()
        ubahAktif(True)
        status = "add"
        emptyField()
        txtNoPolisi.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ubahAktif(True)
        status = "update"
        txtNoPolisi.Focus()
        'cmbNoInvoice.Enabled = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If MsgBox("Apakah Anda yakin ingin menghapus user id " & txtID.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            execute_update("delete from " & tab & " where  " & PK & " = '" & txtID.Text & "'")
            msgInfo("Data berhasil dihapus")
            posisi = 0
            viewAllData("")
            setData()
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNoPolisi.Text = "" Then
            msgInfo("Username harus diisi")
            txtNoPolisi.Focus()
        ElseIf txtNama.Text = "" Then
            msgInfo("Password harus diisi")
            txtNama.Focus()
        ElseIf txtNamaL.Text = "" Then
            msgInfo("Nama lengkap pengguna harus diisi")
            txtNama.Focus()
        ElseIf cmbLevel.SelectedIndex = 0 Then
            msgInfo("Level harus dipilih")
            cmbLevel.Focus()
        Else
            Dim LevelID = cmbLevel.Text.ToString.Split(" - ")
            If status = "add" Then
                Try
                    Dim reader = execute_reader("Select * from msuser where username='" & Trim(txtNoPolisi.Text) & "'")
                    If reader.Read Then
                        msgInfo("Username telah digunakan. Silakan pilih username yang lain")
                        txtNoPolisi.Text = ""
                        txtNoPolisi.Focus()
                        reader.Close()
                    Else
                        reader.Close()
                        sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "','" & Trim(txtNoPolisi.Text) & "','" & Trim(txtNama.Text) & "','" & txtNamaL.Text & "','" & Trim(LevelID(0)) & "')"
                        Try
                            execute_update(sql)
                            viewAllData("")
                            ubahAktif(False)
                            msgInfo("Data berhasil disimpan")
                        Catch ex As Exception
                            msgWarning("Data tidak valid")
                            txtNoPolisi.Text = ""
                            txtNoPolisi.Focus()
                        End Try
                    End If
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                    txtNoPolisi.Text = ""
                    txtNoPolisi.Focus()
                End Try
            ElseIf status = "update" Then
                Try
                    sql = "update   " & tab & "  set Password='" & Trim(txtNama.Text) & "', username='" & Trim(txtNoPolisi.Text) & "'," & _
                    " namalengkap='" & Trim(txtNamaL.Text) & "', Level='" & Trim(LevelID(0)) & "' " & _
                    "  where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtNoPolisi.Text = ""
                    txtNoPolisi.Focus()
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
End Class