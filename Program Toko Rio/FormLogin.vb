Imports MySql.Data.MySqlClient

Public Class FormLogin

    Private Sub createDB()
        Try

            Dim sql As String = " create database  " & dbName
            execute_update(sql)

        Catch ex As Exception
        End Try
    End Sub
    Private Sub importData()
        Try
            Shell("cmd /c IMPORT DATA.bat")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub addModal()
        Dim sql As String = "alter table trdetailfaktur add HargaBeli int default 0"
        Try
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub addField(ByVal sql)
        Try
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub
    Private Sub changeDataType(ByVal sql)
        Try
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub addHargaRetur()
        Dim sql As String = "alter table trdetailReturPenjualan add HargaRetur int default 0"
        Try
            execute_update(sql)

        Catch ex As Exception

        End Try

        sql = "alter table trdetailReturPembelian add HargaRetur int default 0"
        Try
            execute_update(sql)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub FormLogin_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtID.Text = "a"
        txtPass.Text = "a"


        Dim sql = "alter table mstoko add KdSales varchar(20) default NULL "
        Try
            execute_update(sql)
        Catch ex As Exception

        End Try



        txtID.Select()
        Me.txtID.Focus()



        'Dim sql As String = "update msuser set userid='US11010001' where username='a'"
        'Try
        '    execute_update(sql)

        'Catch ex As Exception

        'End Try
    End Sub
    Private Function checkEmpty() As Boolean
        If txtID.Text = "" Then
            MsgBox("Username harus diisi", MsgBoxStyle.Critical, "Warning")
            txtID.Focus()
            Return False
        ElseIf txtPass.Text = "" Then
            MsgBox("Password harus diisi", MsgBoxStyle.Critical, "Warning")
            txtPass.Focus()
            Return False
        End If
        Return True
    End Function
    Private Sub checkLogin()
        If checkEmpty() Then
            Try
                Dim reader = execute_reader("Select * from msuser where username='" & txtID.Text & "' and password='" & txtPass.Text & "'")
                If reader.Read Then
                    '    If txtID.Text = "admin" And txtPass.Text = "admin" Then
                    kdKaryawan = txtID.Text
                    kdKaryawan = reader(0)
                    namaKaryawan = reader(3)
                    lvlKaryawan = reader(4)
                    MsgBox("Selamat datang " & namaKaryawan, MsgBoxStyle.Information, "Welcome Message")
                    reader.Close()
                    'MainMenu.setMenuEnabled()

                    'MainMenu.ToolStripMenuItem1.Visible = False 'menu hapus data
                    'MainMenu.LaporanLabaRugiToolStripMenuItem.Visible = False 'menu laba rugi
                    'MainMenu.MasterUserToolStripMenuItem.Visible = False 'master user
                    'If LCase(txtID.Text) = "superadmin" Then
                    '    MainMenu.ToolStripMenuItem1.Visible = True
                    '    MainMenu.MasterUserToolStripMenuItem.Visible = True
                    '    MainMenu.LaporanLabaRugiToolStripMenuItem.Visible = True
                    'End If

                    FormMain.Show()
                    Me.Hide()
                Else
                    reader.Close()
                    MsgBox("Username atau Password tidak valid !", MsgBoxStyle.Critical, "Warning")
                    txtPass.Text = ""
                    txtID.Text = ""
                    txtID.Select()
                    txtID.Focus()
                End If
            Catch

                MsgBox("Error!!!", MsgBoxStyle.Critical)
            End Try
        End If
    End Sub
    Private Sub txtPass_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPass.KeyPress
        If AscW(e.KeyChar) = 13 Then
            checkLogin()
        End If
    End Sub
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Try
            checkLogin()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        If MsgBox("Anda yakin ingin keluar dari aplikasi?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
            End
        End If
    End Sub
  
    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress
        If AscW(e.KeyChar) = 13 Then
            checkLogin()
        End If
    End Sub
End Class
