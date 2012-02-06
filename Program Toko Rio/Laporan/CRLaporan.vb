Public Class CRLaporan

    Private Sub CRLaporan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CrystalReportViewer1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CrystalReportViewer1.Load
        Dim rp = Nothing
        Dim no As String = idPrint

        If flagLaporan = "lap_penagihan" Then
         
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
            'ElseIf flagLaporan = "faktur" Then
            '    rp = New CrystalReportFaktur
            '    rp.SetParameterValue("kd", no)
            '    Me.Text = "Faktur " & no
            'ElseIf flagLaporan = "retur_jual" Then
            '    rp = New CrystalReportReturJual
            '    rp.SetParameterValue("kd", no)
            '    Me.Text = "Retur Penjualan " & no
            'ElseIf flagLaporan = "po" Then
            '    rp = New CrystalReportPO
            '    rp.SetParameterValue("kd", no)
            '    Me.Text = "Purchase Order " & no
            'ElseIf flagLaporan = "pb" Then
            '    rp = New CrystalReportPO
            '    rp.SetParameterValue("kd", no)
            '    Me.Text = "Penerimaan Barang " & no
        ElseIf flagLaporan = "lap_so" Then
            rp = New CrystalReportLapSO
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Sales Order periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_jual" Then
            rp = New CrystalReportLapPenjualanFk
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Pennjualan periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_retur_jual" Then
            rp = New CrystalReportLapReturJualNew
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Retur Penjualan periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4

        ElseIf flagLaporan = "lap_po" Then
            rp = New CrystalReportLapPO
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Pemesanan Barang periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_pb" Then
            rp = New CrystalReportLapPB
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Penerimaan Barang periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_retur_beli" Then
            rp = New CrystalReportLapreturBeli
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Retur Pembelian periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_laba_rugi" Then
            rp = New CrystalReportLapLR
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Laba Rugi periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4


        ElseIf flagLaporan = "lap_salespayment_bydate" Then
            rp = New CrystalReportSalesPaymentByDate
            rp.SetParameterValue("kd", kdSalesPayment)
            rp.SetParameterValue("sales", salesPayment)
            rp.SetParameterValue("catatan", catatanPayment)
            rp.SetParameterValue("tglByr", CDate(tglPayment))
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            rp.SetParameterValue("v1_komisi", komisiSalesSalesPayment)
            rp.SetParameterValue("v2_grandtotal", grandTotalSalesPayment)
            rp.SetParameterValue("v3_totalKomisiSales", totalKomisiSalesSalesPayment)
            rp.SetParameterValue("v4_jumlahSetelahKomisi", jumlahSetelahKomisiSalesPayment)
            rp.SetParameterValue("v5_jumlahSetelahPotongan", jumlahSetelahPotonganSalesPayment)
            rp.SetParameterValue("v6_discAmount", discAmountSalesPayment)
            Me.Text = "Pembayaran " '  & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_pembayaran_utang" Then
            rp = New CrystalReportLapPembayaranUtang
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Pembayaran Utang periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
        ElseIf flagLaporan = "lap_pembayaran_piutang" Then
            rp = New CrystalReportLapPembayaranPiutang
            rp.SetParameterValue("tg1", CDate(tglMulai))
            rp.SetParameterValue("tg2", CDate(tglAkhir))
            Me.Text = "Laporan Pembayaran Piutang periode " & tglMulai & "-" & tglAkhir
            rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.PaperA4
3:
        End If

        'rp.PrintOptions.PaperSize = CrystalDecisions.Shared.PaperSize.DefaultPaperSize
        CrystalReportViewer1.Zoom(100)
        CrystalReportViewer1.ReportSource = rp
    End Sub
End Class