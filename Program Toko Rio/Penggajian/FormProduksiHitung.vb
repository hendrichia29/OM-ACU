Imports System.Data.SqlClient
Public Class FormProduksiHitung

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
        cmbCari.Items.Add("No. Keluar")
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Karyawan")
        cmbCari.Items.Add("User")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdHitung 'No. Keluar', DATE_FORMAT(TanggalHitung,'%d %M %Y') Tanggal, " & _
              " NamaKaryawan 'Karyawan', NamaLengkap 'User', " & _
              " CASE WHEN StatusHitung = 0 THEN 'New' WHEN StatusHitung = 1 THEN 'Confirm' " & _
              " WHEN StatusHitung = 2 THEN 'Selesai' End 'Status Hitung', " & _
              " CASE WHEN StatusPayment = 0 THEN 'Belum Dibayar' " & _
              " WHEN StatusPayment = 1 THEN 'Sudah Dibayar' End 'Upah Hitung' " & _
              " from  trhitung hitung " & _
              " Join msuser mu On mu.userid = hitung.KdUser " & _
              " Join mskaryawan mk On mk.KdKaryawan = hitung.KdKaryawan " & _
              " Where 1 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Keluar" Then
                col = "KdHitung"
            ElseIf opt = "Tanggal" Then
                col = "TanggalHitung"
            ElseIf opt = "Karyawan" Then
                col = "NamaKaryawan"
            ElseIf opt = "User" Then
                col = "NamaLengkap"
            End If

            If col = "Tanggal" Then
                sql &= " And DATE_FORMAT(TanggalHitung, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(TanggalHitung, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusHitung asc,TanggalHitung Desc "

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
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormProduksiHitungManagement")
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Keluar").Value
                open_subpage("FormProduksiHitungManagement", selected_cell)
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
        txtCari.Text = ""
        txtCari.Focus()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Keluar").Value
            open_subpage("FormProduksiHitungManagement", selected_cell)
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
                If DataGridView1.CurrentRow.Cells("Status Hitung").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Keluar").Value
                    If MsgBox("Anda yakin ingin menghapus produksi hitung ini?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from trhitung where  KdHitung = '" & selected_cell & "' And StatusHitung = 0 ")
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

    Private Sub main_tool_strip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles main_tool_strip.ItemClicked

    End Sub
End Class
