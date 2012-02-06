Imports System.Data.SqlClient

Public Class FormBackUpDB
    Dim dir As String = "D:\BACKUP_DATA_PROGRAM\"
    Dim source As String = "D:\xampp\mysql\data\db_dai"
    Dim pass As String = " --password 110488 "
    Dim dirXampp As String = "D"
    Dim newDir As String
    Dim con As SqlConnection
    Dim fname = ""
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
        Shell("cmd /c mkdir " & dir)
        pass = " "
        fname = "db_dai" & getWaktu() & ".sql"
        'Process.Start(dirXampp & ":\xampp\mysql\bin\mysqldump.exe", "-u root " & pass & "db_dai -r C:\backup.sql")
        Process.Start(dirXampp & ":\xampp\mysql\bin\mysqldump.exe", "-u root " & pass & "db_dai -r " & dir & fname)
        Timer1.Enabled = True
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        backup()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Timer1.Enabled = False
        MsgBox("Data telah selesai dibackup ke " & dir & fname, MsgBoxStyle.Information)
        Label1.Visible = False
        Timer1.Enabled = False
        Timer2.Enabled = True
    End Sub

    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Me.Close()
    End Sub

End Class