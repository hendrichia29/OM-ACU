Imports System.Data.SqlClient

Public Class FormMsProfile
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
        txtUsername.Text = ""
        txtPass.Text = ""
        txtNamaL.Text = ""
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
        sql = "select UserID,Username,NamaLengkap,Level, Password from  " & tab
        If cr <> "" Then
            sql = sql & "  where username like '%" & cr & "%'"
        End If

        Dim reader_profile = execute_reader(sql)
        While reader_profile.read
            txtID.Text = reader_profile("UserID")
            txtUsername.Text = reader_profile("Username")
            txtPass.Text = reader_profile("Password")
            txtNamaL.Text = reader_profile("NamaLengkap")
            txtNamaL.Text = reader_profile("NamaLengkap")
        End While
        reader_profile.close()
    End Sub

    Private Sub FormMsUser_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsUser "
        PK = "  UserID  "

        viewAllData("")
        posisi = 0

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

    Private Sub txtNoPolisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtUsername.KeyPress
        If AscW(e.KeyChar) = 13 And txtUsername.Text <> "" Then
            txtPass.Focus()
        End If
    End Sub

    Private Sub txtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If AscW(e.KeyChar) = 13 And txtPass.Text <> "" Then
            txtNamaL.Focus()
        End If
    End Sub

    Private Sub txtNamaL_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNamaL.KeyPress
        If AscW(e.KeyChar) = 13 Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtUsername.Text = "" Then
            msgInfo("Username harus diisi")
            txtUsername.Focus()
        ElseIf txtPass.Text = "" Then
            msgInfo("Password harus diisi")
            txtPass.Focus()
        ElseIf txtNamaL.Text = "" Then
            msgInfo("Nama lengkap pengguna harus diisi")
            txtPass.Focus()
        Else
            Try
                Dim reader = execute_reader("Select * from msuser where username='" & Trim(txtUsername.Text) & "' And userid <> '" & txtID.Text & "' ")
                If reader.Read Then
                    msgInfo("Username telah digunakan. Silakan pilih username yang lain")
                    txtUsername.Text = ""
                    txtUsername.Focus()
                    reader.Close()
                Else
                    reader.Close()
                    sql = " update   " & tab & "  set Password='" & Trim(txtPass.Text) & "', " & _
                          " username='" & Trim(txtUsername.Text) & "', " & _
                          " namalengkap='" & Trim(txtNamaL.Text) & "' " & _
                          " where  " & PK & "='" + txtID.Text + "' "
                    Try
                        execute_update(sql)
                        viewAllData("")
                        msgInfo("Data berhasil disimpan")
                    Catch ex As Exception
                        msgWarning("Data tidak valid")
                        txtUsername.Text = ""
                        txtUsername.Focus()
                    End Try
                End If
            Catch ex As Exception
                msgWarning("Data tidak valid")
                txtUsername.Text = ""
                txtUsername.Focus()
            End Try
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class