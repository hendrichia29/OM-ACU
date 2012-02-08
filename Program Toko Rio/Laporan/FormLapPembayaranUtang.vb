Imports System.Data.SqlClient

Public Class FormLapPembayaranUtang
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

    Private Sub initGrid(ByVal s As String, ByVal s2 As String) 'area,toko
        tg1 = String.Format("{0:yyyy-MM-dd}", txtTgl.Value)
        tg2 = String.Format("{0:yyyy-MM-dd}", txtTgl2.Value)
        Dim reader As SqlDataReader = Nothing
        Dim queryFrom As String = ""
        Dim query2 As String = ""

        query = " select KdPurchasePayment `No Pembayaran`,DATE_FORMAT(TanggalPurchasePayment,'%d/%m/%Y') `Tgl Bayar`,Nama `Nama Supplier`,ho.No_PB `No Penerimaan Barang`,hpb.No_PO `No Pemesanan`,FORMAT(TotalPurchasePayment,0) `Total Pembayaran`  "
        query2 = " select KdPurchasePayment `No Pembayaran`,DATE_FORMAT(TanggalPurchasePayment,'%d/%m/%Y') `Tgl Pembayaran`,Nama `Nama Supplier`,ho.No_PB `No Penerimaan Barang`,hpb.No_PO `No Pemesanan`,TotalPurchasePayment `Total Pembayaran`  "

        queryFrom += "  from  trpurchasepayment ho join mssupplier c on c.kdsupplier = ho.kdsupplier join trheaderpb hpb on hpb.no_pb=ho.no_pb "
        queryFrom += "  where  DATE_FORMAT(TanggalPurchasePayment,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalPurchasePayment,'%Y-%m-%d') <='" & tg2 & "' " & _
                 "  And StatusPurchasePayment = 1 "
        'If cmbJenis.Text = "Barang Jadi" Then
        '    queryFrom += " AND TipePurchase = 0 "
        'ElseIf cmbJenis.Text = "Bahan Mentah" Then
        '    queryFrom += " AND TipePurchase = 1 "
        'ElseIf cmbJenis.Text = "Fising" Then
        '    queryFrom += " AND TipePurchase = 2 "
        'End If
        query += queryFrom
        query2 += queryFrom

        TextBox1.Text = query
        Dim totalJual As Double = 0
        Dim jumlahHasil As Double = 0
        Dim totalJualHarga As Double = 0
        'Try
        Try
            tglMulai = tg1
            tglAkhir = tg2
            dropview("viewCetakLapPembayaranUtangUS11010001") '"  & kdKaryawan)
            createview(query2, "viewCetakLapPembayaranUtangUS11010001") '  & kdKaryawan)
            DataGridView1.DataSource = execute_datatable(query)
            jumlahHasil = DataGridView1.RowCount
            If jumlahHasil = 0 Then
                MsgBox("Tidak ada data ", MsgBoxStyle.Information)
            End If

            Dim totalValue As Double = 0
            Dim reader2 = execute_reader(query)
            Do While reader2.Read
                totalValue += reader2("Total Pembayaran")
            Loop
            reader2.Close()
            lblTotal.Text = FormatNumber(totalValue, 0)
            Button3.Enabled = True
            
        Catch
            MsgBox("Gagal query", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub setCmbJenis()
        cmbJenis.Items.Clear()
        cmbJenis.Items.Clear()
        cmbJenis.Items.Add("Barang Jadi")
        cmbJenis.Items.Add("Bahan Mentah")
        cmbJenis.Items.Add("Fising")
        If cmbJenis.Items.Count > 0 Then cmbJenis.SelectedIndex = 0
    End Sub

    Private Sub FormLapPembayaranUtang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Enabled = False
        txtTgl.Value = Convert.ToDateTime("01/" & Today.Month & "/" & Today.Year)
        txtTgl2.Value = Convert.ToDateTime(Today.Date)
        setCmbJenis()
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        initGrid("", "")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        flagLaporan = "lap_pembayaran_utang"
        open_subpage("CRLaporan")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        initGrid("", "")
        setGrid()
    End Sub

    Private Sub cmbJenis_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbJenis.SelectedIndexChanged
        initGrid("", "")
        setGrid()
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold
        End With
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 90
        DataGridView1.Columns(2).Width = 200
        DataGridView1.Columns(3).Width = 150

        DataGridView1.Columns(4).Width = 120
        DataGridView1.Columns(5).Width = 120
        'DataGridView1.Columns(3).Visible = False
    End Sub

End Class