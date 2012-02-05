Imports System.Data.SqlClient
Public Class FormSalesPayment
    Dim tipe_pembayaran As String
    Dim tab As String
    Dim PK As String
    Dim add_url As String
    Dim flag_payment As Char
    Dim status_type As String
    Dim type_pembayaran = ""

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
        If status_type = "toko" Then
            cmbCari.Items.Add("No. Faktur")
            cmbCari.Items.Add("Nama Sales")
            cmbCari.Items.Add("Nama Toko")
            cmbCari.Items.Add("Status")
            cmbCari.Items.Add("Bayar Dengan")
        Else
            cmbCari.Items.Add("Nama Sales")
        End If
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        If status_type = "toko" Then
            sql = " select KdSalesPayment 'No. Pembayaran',DATE_FORMAT(TanggalSalesPayment,'%d %M %Y') Tanggal, " & _
                  " Pembayaran.KdFaktur 'No. Faktur', NamaSales 'Nama Sales', " & _
                  " NamaToko 'Nama Toko', FORMAT(Pembayaran.TotalSalesPayment,0) 'Total Bayar', " & _
                  " CASE " & _
                  "     WHEN StatusSalesPayment = 0 THEN 'New' " & _
                  "     WHEN StatusSalesPayment = 1 THEN 'Confirm' " & _
                  " End 'Status', " & _
                  " CASE " & _
                  "     WHEN PaidBy = 1 THEN 'Lewat Sales' " & _
                  "     WHEN PaidBy = 2 THEN 'Langsung' " & _
                  " End 'Bayar Dengan' " & _
                  " from  " & tab & " Pembayaran " & _
                  " Join mssales ms On ms.kdsales = Pembayaran.kdsales " & _
                  " Join mstoko mt On mt.kdtoko = Pembayaran.kdtoko " & _
                  " Where 1 " & _
                  " And flag_payment = '" & flag_payment & "' " & _
                  " And jenis_payment = '" & type_pembayaran & "' "

            If opt <> "" Then
                Dim col As String = ""
                If opt = "No. Pembayaran" Then
                    col = "KdSalesPayment"
                ElseIf opt = "Tanggal Pembayaran" Then
                    col = "TanggalSalesPayment"
                ElseIf opt = "No. Faktur" Then
                    col = "Pembayaran.KdFaktur"
                ElseIf opt = "Nama Sales" Then
                    col = "NamaSales"
                ElseIf opt = "Nama Toko" Then
                    col = "NamaToko"
                ElseIf opt = "Status" Then
                    col = " CASE " & _
                          "     WHEN StatusSalesPayment = 0 THEN 'New' " & _
                          "     WHEN StatusSalesPayment = 1 THEN 'Confirm' " & _
                          " End "
                ElseIf opt = "Bayar Dengan" Then
                    col = " CASE " & _
                          "     WHEN PaidBy = 1 THEN 'Lewat Sales' " & _
                          "     WHEN PaidBy = 2 THEN 'Langsung' " & _
                          " End "
                End If

                If col = "TanggalSalesPayment" Then
                    sql &= " And DATE_FORMAT(TanggalSalesPayment, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                           " and DATE_FORMAT(TanggalSalesPayment, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
                Else
                    sql &= "  And " & col & "  like '%" & cr & "%' "
                End If
            End If
            sql &= " Order By StatusSalesPayment asc, no_increment Desc "
        ElseIf status_type = "tanggal" Then
            sql = " select KdSalesPayment 'No. Pembayaran', " & _
                  " DATE_FORMAT(TanggalPayment,'%d %M %Y') 'Tanggal Bayar', " & _
                  " DATE_FORMAT(DariTanggal,'%d %M %Y') 'Dari Tanggal', " & _
                  " DATE_FORMAT(SampaiTanggal,'%d %M %Y') 'Sampai Tanggal', " & _
                  " NamaSales 'Nama Sales', FORMAT(Pembayaran.TotalSalesPayment,0) 'Total Bayar', " & _
                  " CASE WHEN StatusSalesPayment = 0 THEN 'New' " & _
                  " WHEN StatusSalesPayment = 1 THEN 'Confirm' End 'Status' " & _
                  " from  trsalespaymentbydate Pembayaran " & _
                  " Join mssales ms On ms.kdsales = Pembayaran.kdsales " & _
                  " Where 1 " & _
                  " And flag_payment = '" & flag_payment & "' "

            If opt <> "" Then
                Dim col As String = ""
                If opt = "No. Pembayaran" Then
                    col = "KdSalesPayment"
                ElseIf opt = "Tanggal Pembayaran" Then
                    col = "TanggalPayment"
                ElseIf opt = "Nama Sales" Then
                    col = "NamaSales"
                End If

                If col = "TanggalPayment" Then
                    sql &= " And DATE_FORMAT(TanggalPayment, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                           " and DATE_FORMAT(TanggalPayment, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
                Else
                    sql &= "  And " & col & "  like '%" & cr & "%' "
                End If
            End If
            sql &= " Order By StatusSalesPayment asc, no_increment Desc "
        End If

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
        tab = " trSalesPayment "
        PK = "  KdSalesPayment  "
        status_type = data_carier(0)
        type_pembayaran = data_carier(1)

        If status_type = "toko" Then
            add_url = "FormSalesPaymentManagamen"
            Me.Text = "Pembayaran Per Toko"
            flag_payment = "0"
        ElseIf status_type = "tanggal" Then
            add_url = "FormSalesPaymentByDateManagamen"
            Me.Text = "Pembayaran Per Tanggal"
            flag_payment = "1"
        End If

        If type_pembayaran = "klem" Then
            Me.Text = "Pembayaran Klem Jadi"
        ElseIf type_pembayaran = "paku" Then
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage(add_url, "", type_pembayaran)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                If status_type = "toko" Then
                    open_subpage("FormSalesPaymentManagamen", selected_cell, type_pembayaran)
                ElseIf status_type = "tanggal" Then
                    open_subpage("FormSalesPaymentByDateManagamen", selected_cell, type_pembayaran)
                End If
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
        btnReset.PerformClick()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            If DataGridView1.RowCount > 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormSalesPaymentManagamen", selected_cell)
                viewAllData("", "")
            End If
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
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode payment " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update(" delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusSalesPayment = 0; " & _
                                       " delete from trsalespaymentdetail where  KdSalesPayment = '" & selected_cell & "'; ")
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

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
        txtCari.Focus()
    End Sub
End Class
