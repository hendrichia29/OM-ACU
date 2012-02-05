Imports System.Data.SqlClient
Public Class FormBrowsePB
    Dim tab As String
    Dim PK As String
    Dim type_pb = ""
    Dim KdPB = ""
    Dim ModuleName = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        Dim addQuery = " GROUP BY pb.No_PB "
        sql = " select distinct pb.No_PB 'No. Penerimaan',DATE_FORMAT(Tanggal_TerimaBarang,'%d %M %Y') Tanggal, " & _
              "     NamaLengkap 'Nama User',MS.Nama 'Supplier', " & _
              "     sum(pb.Grandtotal) Grandtotal, " & _
              "     MS.KdSupplier, " & _
              "     CASE " & _
              "         WHEN StatusPaid = 0 THEN 'Belum Lunas' " & _
              "         WHEN StatusPaid = 1 THEN 'Lunas' " & _
              "     End 'Status Paid', " & _
              "     CASE " & _
              "         WHEN StatusTerimaBarang = 0 THEN 'New' " & _
              "         WHEN StatusTerimaBarang = 1 THEN 'Confirm' " & _
              "         WHEN StatusTerimaBarang = 2 THEN 'Retur Sebagian' " & _
              "         WHEN StatusTerimaBarang = 3 THEN 'Retur Semua' " & _
              "     End 'Status' " & _
              " from  " & tab & " pb " & _
              " Join trdetailpb On trdetailpb.no_pb = pb.no_pb " & _
              " LEFT Join MsSupplier MS On MS.KdSupplier = pb.KdSupplier " & _
              " Join msuser mu On mu.userid = pb.userid " & _
              " Where 1 " & _
              " And jenis_pb = '" & type_pb & "' "

        If KdPB <> "" And ModuleName = "PurchasePayment" Then
            sql &= " And exists( " & _
                   "    Select 1 from trpurchasepayment " & _
                   "    where KdPurchasePayment = '" & KdPB & "' " & _
                   "    And No_PB = pb.No_PB " & _
                   " ) " & _
                   " And StatusPaid <> 1 "
        ElseIf ModuleName = "PurchasePayment" Then
            addQuery = " And StatusTerimaBarang not in (0,3) " & _
                       " And StatusPaid <> 1 " & _
                       " GROUP BY pb.No_PB " & _
                       " HAVING SUM(pb.GrandTotal) - " & _
                       " IFNULL(( " & _
                       "    SELECT SUM(TotalPurchasePayment) " & _
                       "    FROM trpurchasepayment WHERE pb.No_PB = No_PB " & _
                       " ), 0) > 0 " & _
                       " And NOT EXISTS ( " & _
                       "    Select 1 from trpurchasepayment tpp " & _
                       "    where tpp.No_PB = pb.No_PB " & _
                       " ) "
        ElseIf KdPB <> "" And ModuleName = "ReturPB" Then
            sql &= " And exists( " & _
                   "    Select 1 from trheaderreturbeli thr " & _
                   "    where thr.kdretur = '" & KdPB & "' " & _
                   "    And thr.No_PB = pb.No_PB " & _
                   " )"
        ElseIf ModuleName = "ReturPB" Then
            sql &= " And StatusTerimaBarang in (1,2) " & _
                   " And Not Exists( " & _
                   "    Select 1 from trdetailreturbeli " & _
                   "    Join trheaderreturbeli On trheaderreturbeli.KdRetur = trdetailreturbeli.KdRetur " & _
                   "    where trheaderreturbeli.KdPB = pb.No_PB " & _
                   "    And kdbahanmentah = trdetailpb.kdbahanmentah " & _
                   "    Group by trheaderreturbeli.KdPB " & _
                   "    HAVING SUM(qty) - trdetailpb.Qty = 0 " & _
                   " ) "
        End If
        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Penerimaan" Then
                col = "pb.No_PB"
            ElseIf opt = "Tanggal" Then
                col = "Tanggal_TerimaBarang"
            ElseIf opt = "Nama Supplier" Then
                col = "MS.Nama"
            ElseIf opt = "Status Paid" Then
                col = " CASE WHEN StatusPaid = 0 THEN 'Belum Lunas' " & _
                      " WHEN StatusPaid = 1 THEN 'Lunas' " & _
                      " End "
            ElseIf opt = "Status" Then
                col = " CASE " & _
                      "     WHEN StatusTerimaBarang = 0 THEN 'New' " & _
                      "     WHEN StatusTerimaBarang = 1 THEN 'Confirm' " & _
                      "     WHEN StatusTerimaBarang = 2 THEN 'Retur Sebagian' " & _
                      "     WHEN StatusTerimaBarang = 3 THEN 'Retur Semua' " & _
                      " End "
            End If

            If col = "Tanggal" Then
                sql &= " And DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= addQuery
        sql &= " Order By no_increment Desc "
        gridPenerimaanBarang.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridPenerimaanBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridPenerimaanBarang.Columns(0).Width = 100
        gridPenerimaanBarang.Columns(1).Width = 100
        gridPenerimaanBarang.Columns(2).Width = 100
        gridPenerimaanBarang.Columns(3).Width = 100
        gridPenerimaanBarang.Columns(4).Width = 100
        gridPenerimaanBarang.Columns(5).Visible = False

    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. Penerimaan")
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Status Paid")
        cmbCari.Items.Add("Status")        
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " trheaderpb "
        PK = "  No_PB  "
        KdPB = data_carier(0)
        ModuleName = data_carier(1)
        type_pb = data_carier(2)
        clear_variable_array()
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getPB()
        Try
            If gridPenerimaanBarang.RowCount Then
                data_carier(0) = gridPenerimaanBarang.CurrentRow.Cells(0).Value
                data_carier(1) = gridPenerimaanBarang.CurrentRow.Cells(3).Value
                data_carier(2) = gridPenerimaanBarang.CurrentRow.Cells(5).Value
                data_carier(3) = gridPenerimaanBarang.CurrentRow.Cells(6).Value
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try
        Return False
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        getpb()
        Me.Close()
    End Sub

    Private Sub gridSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridPenerimaanBarang.DoubleClick
        getpb()
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

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub
End Class
