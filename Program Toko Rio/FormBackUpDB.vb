Imports System.Data.SqlClient

Public Class FormBackUpDB
    Dim dir As String = "D:\BACKUP_DATA_PROGRAM\"
    Dim source As String = "D:\xampp\mysql\data\db_dai"

    Dim newDir As String
    Dim con As SqlConnection
    Function getWaktu()
        Dim a As String = String.Format("{0:tt}", TimeOfDay)
        Dim h As Integer = CInt(String.Format("{0:hh}", TimeOfDay))
        If a = "PM" And h <> 12 Then
            h = h + 12
        End If
        Dim tg As String = String.Format("{0:ddMMyyyy}", Today.Date)
        getWaktu = String.Format("{0:" & tg & "_" & h & "mmss}", TimeOfDay)
        'Label2.Text = String.Format("{0:" & h & ":mm:ss}", TimeOfDay)
    End Function
    Private Sub FormBackUpDB_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        DateTimePickerSO.Text = Convert.ToDateTime(Today.Date)
        DateTimePickerSO.MinDate = DateTime.Today
        DateTimePickerSO.Enabled = False
        Label1.Visible = False
        Timer1.Enabled = False
    End Sub


    Private Sub backup()
        Label1.Visible = True
        newDir = dir & getWaktu()
        Timer1.Enabled = True

        Shell("cmd /c mkdir " & newDir)
        Shell("cmd /c mkdir " & newDir & "\" & dbName.ToLower)
        'Shell("cmd /c net stop mssqlserver")
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'If MsgBox("Setelah data selesai dibackup maka secara otomatis program akan berakhir dengan sendirinya." & vbNewLine & _
        '"Anda yakin ingin melanjutkan proses ini?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
        backup()
        'End If
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        Shell("cmd /c copy " & source & " " & newDir & "\" & dbName.ToLower, 1, True)
        '   TextBox1.Text = "cmd /c copy " & source & " " & newDir
        ' Shell("cmd /c copy """ & "C:\Program Files\Microsoft SQL Server\MSSQL\Data\DB_DAI_log.LDF""" & " " & newDir, 1, True)
        MsgBox("Data telah selesai dibackup ke " & newDir, MsgBoxStyle.Information)
        Label1.Visible = False
        'Shell("cmd /c net start mssqlserver")

        Timer1.Enabled = False
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        'db.close()
        Me.Close()
        ' FormMain.Close()
    End Sub

End Class