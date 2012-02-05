Public Class CRPrintTransaksi

    Private Sub CRPrintTransaksi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim rp = Nothing
        Dim no As String = idPrint
        ' MsgBox(flagLaporan)
        If flagLaporan = "so" Then
            rp = New CrystalReportSO
            rp.SetParameterValue("kd", no)
            Me.Text = "Pemesanan Penjualan " & no
        ElseIf flagLaporan = "faktur" Then
            rp = New CrystalReportFaktur
            rp.SetParameterValue("kd", no)
            Me.Text = "Faktur " & no
        ElseIf flagLaporan = "sj" Then
            rp = New CrystalReportSJ
            rp.SetParameterValue("kd", no)
            Me.Text = "Surat Jalan Faktur " & no
        ElseIf flagLaporan = "retur_jual" Then
            rp = New CrystalReportReturJual
            rp.SetParameterValue("kd", no)
            Me.Text = "Retur Penjualan " & no
        ElseIf flagLaporan = "po" Then
            rp = New CrystalReportPO
            rp.SetParameterValue("kd", no)
            Me.Text = "Pemesanan Pembelian " & no
        ElseIf flagLaporan = "pb" Then
            rp = New CrystalReportPB
            rp.SetParameterValue("kd", no)
            Me.Text = "Penerimaan Barang " & no
        ElseIf flagLaporan = "retur_beli" Then
            rp = New CrystalReportReturbeli
            rp.SetParameterValue("kd", no)
            Me.Text = "Retur Pembelian " & no

        ElseIf flagLaporan = "po_fising" Then
            rp = New CrystalReportPOFising
            'rp.SetParameterValue("kd", no)
            Me.Text = "Purchase Order " & no
        ElseIf flagLaporan = "pb_fising" Then
            rp = New CrystalReportPBFising
            'rp.SetParameterValue("kd", no)
            Me.Text = "Penerimaan Barang " & no
        ElseIf flagLaporan = "retur_beli_fising" Then
            rp = New CrystalReportReturBeliFising
            ' rp.SetParameterValue("kd", no)
            Me.Text = "Retur Pembelian  " & no
        End If

        rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        ' CrystalReportViewer1.Zoom(100)
        CrystalReportViewer1.ReportSource = rp
        ' CrystalReportViewer1.PrintReport()
    End Sub
End Class