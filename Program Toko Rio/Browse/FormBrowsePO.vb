Imports System.Data.SqlClient
Public Class FormBrowsePO
    Dim tab As String
    Dim PK As String
    Dim jenis_po As String
    Dim no_po As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        Dim addQuery = ""

        sql = " select DISTINCT PO.No_PO 'No. PO',DATE_FORMAT(Tanggal_PO,'%d %M %Y') Tanggal, " & _
              "     Nama 'Nama Supplier' , " & _
              "     CASE WHEN StatusPO = 0 THEN 'New' WHEN StatusPO = 1 THEN 'Confirm' " & _
              "     WHEN StatusPO = 2 THEN 'Barang Diterima' End 'Status', MS.KdSupplier " & _
              " from  " & tab & " PO " & _
              " Join trdetailpo pod On pod.No_PO = PO.No_PO " & _
              " Join MsSupplier MS On MS.KdSupplier = PO.KdSupplier " & _
              " Join msuser mu On mu.userid = PO.userid " & _
              " where 1 " & _
              " And jenis_po = '" & jenis_po & "' "

        If no_po <> "" Then
            addQuery &= " And exists( " & _
                        "   Select 1 from trheaderpb " & _
                        "   where No_PB = '" & no_po & "' " & _
                        "   And No_PO = PO.No_PO " & _
                        " ) "
        Else
            addQuery &= " And StatusPO = 1 " & _
                        " And Not Exists( " & _
                        "   Select 1 from trdetailpb " & _
                        "   Join trheaderpb On trheaderpb.No_PB = trdetailpb.No_PB " & _
                        "   where trheaderpb.No_PO = pod.No_PO " & _
                        "   And kdbahanmentah = pod.kdbahanmentah " & _
                        "   Group by trheaderpb.No_PO " & _
                        "   HAVING SUM(qty) - pod.jumlah = 0 " & _
                        " ) "
        End If
        sql &= addQuery

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. PO" Then
                col = "PO.No_PO"
            ElseIf opt = "Tanggal PO" Then
                col = "Tanggal_PO"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Status" Then
                col = " CASE WHEN StatusPO = 0 THEN 'New' WHEN StatusPO = 1 THEN 'Confirm' " & _
                      " WHEN StatusPO = 2 THEN 'Barang Diterima' End "
            End If

            If col = "Tanggal_PO" Then
                sql &= " And DATE_FORMAT(Tanggal_PO, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(Tanggal_PO, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " GROUP BY PO.No_PO " & _
               " Order By no_increment Desc,StatusPO asc "

        gridToko.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridToko.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridToko.Columns("KdSupplier").Visible = False
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. PO")
        cmbCari.Items.Add("Tanggal PO")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Status")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " trheaderpo "
        PK = "  No_PO  "
        no_po = data_carier(0)
        jenis_po = data_carier(1)
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getPO()
        Try
            If gridToko.RowCount Then
                data_carier(0) = gridToko.CurrentRow.Cells("No. PO").Value
                data_carier(1) = gridToko.CurrentRow.Cells("Tanggal").Value
                data_carier(2) = gridToko.CurrentRow.Cells("KdSupplier").Value
                data_carier(3) = gridToko.CurrentRow.Cells("Nama Supplier").Value
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
        getPO()
        Me.Close()
    End Sub

    Private Sub gridSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridToko.DoubleClick
        getPO()
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
