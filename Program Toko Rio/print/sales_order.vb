Imports MySql.Data.MySqlClient
Public Class sales_order
    ReadOnly query_sales_order = " SELECT so.KdSO, TanggalSO, NamaSales, NamaToko, GrandTotal, StatusSO, " & _
                                 " UserID, KomisiSales, jenis_so, " & _
                                 " mb.KdBarang, NamaBarang, Harga, Qty, Disc, " & _
                                 " StatusBarang, HargaDisc " & _
                                 " From trsalesorder so " & _
                                 " Join MsSales ms On ms.KdSales = so.KdSales " & _
                                 " Join MsToko mt On mt.KdToko = so.KdToko " & _
                                 " Join trsalesorderdetail sod On sod.KdSO = so.KdSO " & _
                                 " Join msbarang mb On mb.KdBarang = sod.KdBarang "
    Dim str_so_id = ""

    Function report(ByVal query_for_sales_order As String)
        open_connection()
        Dim ds As New DataSet1
        Dim adapter As New MySqlDataAdapter(query_for_sales_order, dbconnection)
        Dim datatable As New DataTable
        adapter.Fill(datatable)
        adapter.Fill(ds.Sales_Order)
        datatable = ds.Sales_Order

        Dim form As New CrystalReportSO
        form.Load("PUT CRYSTAL REPORT PATH HERE\CrystalReportSO.rpt")
        form.SetDataSource(datatable)
        crv_sales_order.ReportSource = form
        crv_sales_order.Refresh()
        Return True
    End Function

    Private Sub sales_order_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        str_so_id = data_carier(0)
        report(query_sales_order & " Where so.KdSO = '" & str_so_id & "' ")
    End Sub
End Class