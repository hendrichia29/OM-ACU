Imports System.Data.SqlClient
Public Class FormBrowseStatusRetur

    Private Sub FormBrowseStatusRetur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cmbStatus.SelectedIndex = 0
    End Sub

    Private Sub cmbStatus_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbStatus.SelectedIndexChanged
        If cmbStatus.SelectedIndex <> 0 Then
            data_carier(0) = cmbStatus.Text
            Me.Close()
        End If
    End Sub
End Class
