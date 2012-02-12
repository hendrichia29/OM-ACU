Imports System.Data.SqlClient

Public Class FormKomisiSales
    Dim jumData As Integer
    Dim query As String
    Dim queryJumlah As String
    Dim tabel As String
    Dim status As Integer = 0
    Dim tg1 As String
    Dim tg2 As String
    Dim idxB As Integer
    Dim thn As Integer
    Dim idxB2 As Integer
    Dim thn2 As Integer

    Private Sub dropview(ByVal viewname As String)
        Try
            Dim sql As String = " drop view  " & viewname
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub createview(ByVal q As String, ByVal viewName As String)
        Try
            Dim sql As String
            sql = " create view " & viewName & " as (" & q & " )"
            '     MsgBox(sql)
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub initGrid()
        tg1 = String.Format("{0:yyyy-MM-dd}", txtTgl.Value)
        tg2 = String.Format("{0:yyyy-MM-dd}", txtTgl2.Value)

        Dim sql As String = ""
        'sql = "select NamaSales `Nama Sales` , sum(qty * (harga - (harga*disc/100))) * Komisi /100 `Jumlah Komisi` from trsalesorder so join trsalesorderdetail sod on sod.kdso=so.kdso " & _
        '" join mssales sls on sls.kdsales=so.kdsales  join trfaktur fk on fk.kdso=so.kdso " & _
        '" where statusfaktur <> 0 and (DATE_FORMAT(TanggalSO,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalSO,'%Y-%m-%d') <='" & tg2 & "')  group by sls.kdsales  "
        'FORMAT(sum(qty*harga),0)
        'sql = "select NamaSales `Nama Sales` , FORMAT(sum(qty * (harga - (harga*disc/100))) * Komisi /100,0) `Jumlah Komisi` from trsalesorder so " & _
        ' " join mssales sls on sls.kdsales=so.kdsales  join trfaktur fk on fk.kdso=so.kdso  join trfakturdetail fkd on fkd.kdfaktur=fk.kdfaktur " & _
        '" where statusfaktur <> 0 And StatusPayment = 1 and (DATE_FORMAT(TanggalSO,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalSO,'%Y-%m-%d') <='" & tg2 & "')  group by sls.kdsales  "
        'sql = "select so.kdso `No SO`,fk.kdfaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d/%m/%Y') `Tgl Faktur`,NamaToko `Toko`,NamaSales `Nama Sales`," & _
        '" sp.kdbarang `Part No.` ,Qty `Qty Faktur`, " & _
        '" IFNULL( (select ifnull(dr.qty,0) from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  where AfterPaid =1 and r.KdFaktur= fk.KdFaktur and dr.kdbarang=sp.KdBarang and (DATE_FORMAT(TanggalRetur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalRetur,'%Y-%m-%d') <='" & tg1 & "')),0)  `Qty Retur`," & _
        '" FORMAT(Harga,0) Harga,so.Disc," & _
        '" FORMAT( (qty -IFNULL( (select ifnull(dr.qty,0) from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  where AfterPaid =1 and r.KdFaktur= fk.KdFaktur and dr.kdbarang=sp.KdBarang and (DATE_FORMAT(TanggalRetur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalRetur,'%Y-%m-%d') <='" & tg1 & "')),0) )   * (harga - (harga*dr.disc/100)),0) Total, " & _
        '" fk.KomisiSales `% Komisi` , " & _
        '" FORMAT((qty-IFNULL( (select ifnull(dr.qty,0) from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  where AfterPaid =1 and r.KdFaktur= fk.KdFaktur and dr.kdbarang=sp.KdBarang and (DATE_FORMAT(TanggalRetur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalRetur,'%Y-%m-%d') <='" & tg1 & "')),0)) * (harga - (harga*dr.disc/100)) * fk.KomisiSales /100,0) `Jumlah Komisi`  " & _
        '" from trsalesorder so " & _
        '" join mssales sls on sls.kdsales=so.kdsales  " & _
        '" join trfaktur fk on fk.kdso=so.kdso " & _
        '" join trsalespayment tsp on tsp.KdFaktur = fk.KdFaktur" & _
        '" join  trsalespaymentdetail sp on sp.KdSalesPayment = tsp.KdSalesPayment " & _
        '" join mstoko mt on mt.kdtoko = so.KdToko " & _
        '" where statusfaktur <> 0 And StatusPayment = 1 and (DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') <='" & tg2 & "')   " & _
        '" and NamaSales = '" & Trim(cmbSales.Text) & "'"

        '12 feb 2012
        'sql = " select so.kdso `No SO`,fk.kdfaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d/%m/%Y') `Tgl Faktur`," & _
        '      "  NamaToko `Toko`," & _
        '      "  NamaSales `Nama Sales` ,fk.GrandTotal,so.KomisiSales," & _
        '      "  TotalKomisiSales -" & _
        '      "  ( " & _
        '      "  select IFNULL(sum(hargadisc*qty),0) TotalRetur " & _
        '      "  from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  " & _
        '      " where AfterPaid = 1 " & _
        '      "  and (DATE_FORMAT(TanggalRetur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalRetur,'%Y-%m-%d') <='" & tg1 & "') " & _
        '      "  ) `Jumlah Komisi`   " & _
        '    " from trsalesorder so " & _
        '    " join mssales sls on sls.kdsales=so.kdsales  " & _
        '    " join trfaktur fk on fk.kdso=so.kdso " & _
        '    " join trsalespayment tsp on tsp.KdFaktur = fk.KdFaktur" & _
        '    " join mstoko mt on mt.kdtoko = so.KdToko " & _
        '    " where statusfaktur <> 0 And StatusPayment = 1 and (DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') <='" & tg2 & "')   " & _
        '    " and NamaSales = '" & Trim(cmbSales.Text) & "'"
        Dim queryFrom As String = ""
        Dim sql2 As String = ""

        sql = " select so.kdso `No SO`,fk.kdfaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d/%m/%Y') `Tgl Faktur`," & _
              " format(fk.GrandTotal,0) Grandtotal,NamaToko `Toko`," & _
              " DATE_FORMAT(TanggalSalesPayment,'%d/%m/%Y') `Tgl Bayar`," & _
              " NamaSales `Nama Sales`,format(tsp.Komisi_Sales,0) `Komisi`"

        sql2 = " select so.kdso `No SO`,fk.kdfaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d/%m/%Y') `Tgl Faktur`," & _
              " fk.GrandTotal Grandtotal,NamaToko `Toko`," & _
              " DATE_FORMAT(TanggalSalesPayment,'%d/%m/%Y') `Tgl Bayar`," & _
              " NamaSales `Nama Sales` ,tsp.Komisi_Sales `Komisi`"

        queryFrom = " from trsalesorder so " & _
            " join mssales sls on sls.kdsales=so.kdsales  " & _
            " join trfaktur fk on fk.kdso=so.kdso " & _
            " join trsalespayment tsp on tsp.KdFaktur = fk.KdFaktur" & _
            " join mstoko mt on mt.kdtoko = so.KdToko " & _
            " where StatusSalesPayment	= 1  " & _
            " and (DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalSalesPayment,'%Y-%m-%d') <='" & tg2 & "')   " & _
            " and NamaSales = '" & Trim(cmbSales.Text) & "'"

        sql += queryFrom
        sql2 += queryFrom
        Try
            tglMulai = tg1
            tglAkhir = tg2
            dropview("view_komisi_sales")
            createview(sql2, "view_komisi_sales")
            ' TextBox1.Text = sql
            DataGridView1.DataSource = execute_datatable(sql)
            TextBox1.Text = sql
            Dim totalValue As Double = 0
            Dim reader = execute_reader(sql)
            Do While reader.Read
                totalValue += reader("Komisi")
            Loop
            reader.Close()
            lblTotal.Text = FormatNumber(totalValue, 0)
            Button3.Enabled = True
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub FormKomisiSales_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        txtTgl.Value = Convert.ToDateTime("01/" & Today.Month & "/" & Today.Year)
        txtTgl2.Value = Convert.ToDateTime(Today.Date)
        initGrid()
        setCmbSales()
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        initGrid()
    End Sub

    Public Sub setCmbSales()
        Dim reader = execute_reader("Select * from MsSales  order by NamaSales asc")
        Dim varT As String = ""
        cmbSales.Items.Clear()
        'cmbSales.Items.Add("- Pilih Sales -")
        Do While reader.Read
            cmbSales.Items.Add(reader(1).ToString.ToUpper) ' & "-" & reader(0))
        Loop
        reader.Close()
        If cmbSales.Items.Count > 0 Then
            cmbSales.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        flagLaporan = "komisi_sales"
        open_subpage("CRLaporan")
    End Sub
End Class