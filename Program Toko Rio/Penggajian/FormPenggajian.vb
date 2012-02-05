Imports System.Data.SqlClient
Public Class FormPenggajian

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        btnExit.Enabled = Not status
        GroupBox1.Enabled = Not status

        btnAdd.Enabled = Not status
        btnUpdate.Enabled = Not status
        btnDelete.Enabled = Not status
        DataGridView1.Enabled = Not status
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. Gaji")
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Status")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdPenggajian 'No. Gaji', DATE_FORMAT(TanggalPenggajian,'%d %M %Y') Tanggal, " & _
              " NamaLengkap 'User', " & _
              " CASE " & _
              "     WHEN StatusPenggajian = 0 THEN 'New' " & _
              "     WHEN StatusPenggajian = 1 THEN 'Confirm' " & _
              "     WHEN StatusPenggajian = 2 THEN 'Selesai' " & _
              " End 'Status' " & _
              " from  trpenggajian gaji " & _
              " Join msuser mu On mu.userid = gaji.KdUser " & _
              " Where 1 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Gaji" Then
                col = "KdPenggajian"
            ElseIf opt = "Tanggal" Then
                col = "TanggalPenggajian"
            ElseIf opt = "Status" Then
                col = " CASE " & _
                      "     WHEN StatusPenggajian = 0 THEN 'New' " & _
                      "     WHEN StatusPenggajian = 1 THEN 'Confirm' " & _
                      "     WHEN StatusPenggajian = 2 THEN 'Selesai' " & _
                      " End "
            End If

            If col = "TanggalPenggajian" Then
                sql &= " And DATE_FORMAT(TanggalPenggajian, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(TanggalPenggajian, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusPenggajian asc, no_increment Desc "

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Function visibleDate()
        dtpFrom.Visible = True
        dtpTo.Visible = True
        lblSeperator.Visible = True
        btnCari.Visible = True

        txtCari.Visible = False
        btnReset.Visible = False
        Return False
    End Function

    Function visibleCari()
        dtpFrom.Visible = False
        dtpTo.Visible = False
        lblSeperator.Visible = False
        btnCari.Visible = False

        txtCari.Visible = True
        btnReset.Visible = True
        Return False
    End Function

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewAllData("", "")
        setGrid()
        setCmbCari()
        visibleCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
        txtCari.Focus()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormPenggajianManagement")
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Gaji").Value
                open_subpage("FormPenggajianManagement", selected_cell)
                viewAllData("", "")
            Else
                msgInfo("Data tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCari.SelectedIndexChanged
        If cmbCari.SelectedIndex = 1 Then
            visibleDate()
        Else
            visibleCari()
        End If
        btnReset.PerformClick()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Gaji").Value
            open_subpage("FormPenggajianManagement", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells("Status").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Gaji").Value
                    If MsgBox("Anda yakin ingin menghapus penggajian ini?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from trpenggajian where  KdPenggajian = '" & selected_cell & "' And StatusPenggajian = 0 ")
                        execute_update("delete from trpantekdetail where  KdPenggajian = '" & selected_cell & "' ")
                        msgInfo("Data berhasil dihapus")
                        viewAllData("", "")
                    End If
                Else
                    msgInfo("Data tidak dihapus. Hanya data yang memiliki status New yang dapat di hapus.")
                End If
            Else
                msgInfo("Data tidak ditemukan.")
            End If
        Catch ex As Exception
            msgInfo("Data tidak dapat dihapus.")
        End Try
    End Sub
End Class
