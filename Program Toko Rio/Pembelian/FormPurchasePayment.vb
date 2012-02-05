Imports System.Data.SqlClient
Public Class FormPurchasePayment
    Dim tab As String
    Dim PK As String
    Dim type_payment As String

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
        cmbCari.Items.Add("No. Pembayaran")
        cmbCari.Items.Add("Tanggal Pembayaran")
        cmbCari.Items.Add("No. Penerimaan")
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Status")
        cmbCari.Items.Add("Bayar Dengan")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdPurchasePayment 'No. Pembayaran',DATE_FORMAT(TanggalPurchasePayment,'%d %M %Y') Tanggal, " & _
              " Pembayaran.No_PB 'No. Penerimaan',NamaLengkap 'Nama User', MS.Nama 'Supplier', " & _
              " Pembayaran.TotalPurchasePayment 'Total Bayar', " & _
              " CASE WHEN StatusPurchasePayment = 0 THEN 'New' " & _
              " WHEN StatusPurchasePayment = 1 THEN 'Confirm' End 'Status Bayar', " & _
              " PaidBy 'Bayar Dengan' " & _
              " from  " & tab & " Pembayaran " & _
              " Join msSupplier ms On ms.kdSupplier = Pembayaran.kdSupplier " & _
              " Join msuser mu On mu.userid = Pembayaran.userid " & _
              " Where jenis_payment = '" & type_payment & "' "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Pembayaran" Then
                col = "KdPurchasePayment"
            ElseIf opt = "Tanggal Pembayaran" Then
                col = "TanggalPurchasePayment"
            ElseIf opt = "No. Penerimaan" Then
                col = "Pembayaran.No_PB"
            ElseIf opt = "Nama Supplier" Then
                col = "MS.Nama"
            ElseIf opt = "Status" Then
                col = " CASE WHEN StatusPurchasePayment = 0 THEN 'New' " & _
                      " WHEN StatusPurchasePayment = 1 THEN 'Confirm' End "
            ElseIf opt = "Bayar Dengan" Then
                col = "PaidBy"
            End If

            If col = "TanggalPurchasePayment" Then
                sql &= " And DATE_FORMAT(TanggalPurchasePayment, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(TanggalPurchasePayment, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and KdPurchasePayment <>'SP00000000'"
            Else
                sql &= "  And " & col & "  like '%" & cr & "%'  and KdPurchasePayment <>'SP00000000'"
            End If
        Else
            sql &= "  And KdPurchasePayment <>'FK00000000'"
        End If
        sql &= " Order By StatusPurchasePayment asc, no_increment Desc "

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Width = 100
        DataGridView1.Columns(7).Width = 100
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
        tab = " trPurchasePayment "
        PK = "  KdPurchasePayment  "
        type_payment = data_carier(0)
        If type_payment = "klem" Then
            Me.Text = "Pembayaran Klem Mentah"
        Else
            Me.Text = "Pembayaran Paku"
        End If

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
            open_subpage("FormPurchasePaymentManagamen", "", type_payment)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormPurchasePaymentManagamen", selected_cell, type_payment)
                viewAllData("", "")
            Else
                msgInfo("Data pembayaran tidak ditemukan.")
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
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormPurchasePaymentManagamen", selected_cell)
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
                If DataGridView1.CurrentRow.Cells(6).Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode pembelian " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusPurchasePayment = 0 ")
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
