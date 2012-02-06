Public Class FormMain

    Private Sub MerkToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormMsMerk.Show()
    End Sub

    Private Sub KategoriToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FormMsKategori.Show()
    End Sub

    Private Sub PropinsiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsProvinsi")
    End Sub

    Private Sub EkspedisiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsEkspedisi")
    End Sub

    Private Sub SalesToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SalesToolStripMenuItem1.Click
        open_page("FormMsSales")
    End Sub

    Private Sub SupplierToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SupplierToolStripMenuItem.Click
        open_page("FormMsSupplier")
    End Sub

    Private Sub TokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TokoToolStripMenuItem.Click
        open_page("FormMsToko")
    End Sub

    Private Sub btn_logout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btn_logout.Click
        Me.Hide()

        FormLogin.txtID.Text = ""
        FormLogin.txtPass.Text = ""
        FormLogin.txtID.Select()
        FormLogin.txtID.Focus()
        FormLogin.Show()
    End Sub

    Private Sub TipeToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsJenisFishing")
    End Sub

    Private Sub AreaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsArea")
    End Sub

    Private Sub TipeToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsBahanMentahTipe")
    End Sub

    Private Sub SubKategoriToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsBahanMentahSubKategori")
    End Sub

    Private Sub BahanMentahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BahanMentahToolStripMenuItem.Click

    End Sub

    Private Sub MerkToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsMerk")
    End Sub

    Private Sub MerkTipeToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsMerkTipe")
    End Sub

    Private Sub KategoriToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsKategori")
    End Sub

    Private Sub SubKategoriToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsKategoriSub")
    End Sub

    Private Sub JenisFisingToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
    End Sub

    Private Sub FormMain_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub BarangJadiToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangJadiToolStripMenuItem.Click
        open_page("FormMsBarang")
    End Sub

    Private Sub MerkToolStripMenuItem_Click_2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MerkToolStripMenuItem.Click
        open_page("FormMsMerk")
    End Sub

    Private Sub TransferStokToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormTrTransferStock")
    End Sub

    Private Sub BahanMentahToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsBahanMentah")
    End Sub

    Private Sub SalesOrderToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormSO")
    End Sub

    Private Sub FisingToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormMsFising")
    End Sub

    Private Sub PurchaseOrderToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseOrderToolStripMenuItem2.Click

    End Sub

    Private Sub ProfileToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProfileToolStripMenuItem.Click
        open_page("FormMsProfile")
    End Sub

    Private Sub RegisterToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles RegisterToolStripMenuItem.Click
        open_page("FormMsUser")
    End Sub

    Private Sub PenagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenagihanToolStripMenuItem.Click
        open_page("FormLapPenagihan")
    End Sub

    Private Sub PenjualanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenjualanToolStripMenuItem.Click
        'open_page("FormLapPenjualan")
        'open_sub_page("FormLapPenjualan")
        open_subpage("FormLapPenjualanFaktur")
    End Sub

   
    Private Sub GoodReceiveToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormTrPenerimaanBarangM")
    End Sub

    Private Sub ToolStripMenuItemPurchaseOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemPurchaseOrder.Click
        open_page("FormLapPO")
    End Sub

    Private Sub ToolStripMenuItemSalesOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItemSalesOrder.Click
        open_page("FormLapSO")
    End Sub

    Private Sub btn_dashboard_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormKomisiSales")
    End Sub

    Private Sub PurchaseReturnToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchaseReturnToolStripMenuItem1.Click

    End Sub

    Private Sub LabaRugiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabaRugiToolStripMenuItem.Click
        open_page("FormLapLabaRugi")
    End Sub

    Private Sub BackupDataToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackupDataToolStripMenuItem.Click

        open_page("FormBackUpDB")
    End Sub

    Private Sub ToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem2.Click

    End Sub

    Private Sub ReturToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturToolStripMenuItem.Click
        open_page("FormLapReturJual")
    End Sub

    Private Sub ProduksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ProduksiToolStripMenuItem.Click
        open_page("FormLapProduksi")
    End Sub

    Private Sub TransferStokToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransferStokToolStripMenuItem1.Click
        open_page("FormLapTransferStock")
    End Sub

    Private Sub ReturToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormTrPenerimaanBarangM")
    End Sub

    Private Sub PenerimaanBarangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenerimaanBarangToolStripMenuItem.Click
        open_page("FormLapPenerimaan")
    End Sub

    Private Sub ReturToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReturToolStripMenuItem1.Click
        open_page("FormLapReturBeli")
    End Sub

    Private Sub PurchasePaymentToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PurchasePaymentToolStripMenuItem1.Click

    End Sub

    Private Sub UtangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UtangToolStripMenuItem.Click
        open_page("FormLapPembayaranUtang")
    End Sub

    Private Sub PiutangToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PiutangToolStripMenuItem.Click
        open_page("FormLapPembayaranPiutang")
    End Sub

    Private Sub DaftarPenagihanToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DaftarPenagihanToolStripMenuItem.Click
        open_page("FormLapPenagihan2")
    End Sub

    Private Sub ToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem5.Click
        open_page("FormMsKaryawan")
    End Sub

    Private Sub KlemToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemToolStripMenuItem.Click
        open_page("FormMsKlem")
    End Sub

    Private Sub PakuToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem1.Click
        open_page("FormMsPaku")
    End Sub

    Private Sub BayarPerTokoToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub BayarPerTanggalToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub KlemJadiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemJadiToolStripMenuItem.Click
        open_page("FormSO", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem.Click
        open_page("FormSO", "paku")
    End Sub

    Private Sub KlemJadiToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemJadiToolStripMenuItem1.Click
        open_page("FormFaktur", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem2.Click
        open_page("FormFaktur", "paku")
    End Sub

    Private Sub KlemJadiToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemJadiToolStripMenuItem2.Click
        open_page("FormRetur", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem3.Click
        open_page("FormRetur", "paku")
    End Sub

    Private Sub BayarPerTokoToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayarPerTokoToolStripMenuItem1.Click
        open_page("FormSalesPayment", "toko", "klem")
    End Sub

    Private Sub BayarPerTanggalToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormSalesPayment", "tanggal", "klem")
    End Sub

    Private Sub ToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        open_page("FormSalesPayment", "tanggal", "paku")
    End Sub

    Private Sub BayarPerTanggalToolStripMenuItem_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayarPerTanggalToolStripMenuItem.Click
        open_page("FormSalesPayment", "tanggal")
    End Sub

    Private Sub KlemMentahToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemMentahToolStripMenuItem.Click
        open_page("FormTrPO", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem4_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem4.Click
        open_page("FormTrPO", "paku")
    End Sub

    Private Sub KlemToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemToolStripMenuItem1.Click
        open_page("FormTrPenerimaanBahanMentah", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem5.Click
        open_page("FormTrPenerimaanBahanMentah", "paku")
    End Sub

    Private Sub KlemMentahToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemMentahToolStripMenuItem1.Click
        open_page("FormTrReturPembelian", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem6.Click
        open_page("FormTrReturPembelian", "paku")
    End Sub

    Private Sub KlemMentahToolStripMenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemMentahToolStripMenuItem2.Click
        open_page("FormPurchasePayment", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem7.Click
        open_page("FormPurchasePayment", "paku")
    End Sub

    Private Sub KlemJadiToolStripMenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemJadiToolStripMenuItem4.Click
        open_page("FormBarangAdjusment", "klem_jadi")
    End Sub

    Private Sub KlemMentahToolStripMenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemMentahToolStripMenuItem3.Click
        open_page("FormBarangAdjusment", "klem_mentah")
    End Sub

    Private Sub PakuToolStripMenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem8.Click
        open_page("FormBarangAdjusment", "paku")
    End Sub

    Private Sub ToolStripMenuItem8_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem8.Click
        open_page("FormTrPO", "klem")
    End Sub

    Private Sub OakuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OakuToolStripMenuItem.Click
        open_page("FormTrPO", "paku")
    End Sub

    Private Sub ToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem9.Click
        open_page("FormTrPenerimaanBahanMentah", "klem")
    End Sub

    Private Sub ToolStripMenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem10.Click
        open_page("FormTrPenerimaanBahanMentah", "paku")
    End Sub

    Private Sub ToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem11.Click
        open_page("FormTrReturPembelian", "klem")
    End Sub

    Private Sub ToolStripMenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem12.Click
        open_page("FormTrReturPembelian", "paku")
    End Sub

    Private Sub ToolStripMenuItem13_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem13.Click
        open_page("FormPurchasePayment", "klem")
    End Sub

    Private Sub ToolStripMenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem14.Click
        open_page("FormPurchasePayment", "paku")
    End Sub

    Private Sub KlemMentahToolStripMenuItem7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemMentahToolStripMenuItem7.Click
        open_page("FormSO", "klem")
    End Sub

    Private Sub PakuToolStripMenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem11.Click
        open_page("FormSO", "paku")
    End Sub

    Private Sub ToolStripMenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem15.Click
        open_page("FormFaktur", "klem")
    End Sub

    Private Sub ToolStripMenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem16.Click
        open_page("FormFaktur", "paku")
    End Sub

    Private Sub ToolStripMenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem17.Click
        open_page("FormRetur", "klem")
    End Sub

    Private Sub ToolStripMenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripMenuItem18.Click
        open_page("FormRetur", "paku")
    End Sub

    Private Sub BayarPerFakturToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayarPerFakturToolStripMenuItem.Click
        open_page("FormSalesPayment", "toko", "klem")
    End Sub

    Private Sub BayarPerFakturToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayarPerFakturToolStripMenuItem1.Click
        open_page("FormSalesPayment", "toko", "paku")
    End Sub

    Private Sub BayarPerTanggalToolStripMenuItem1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BayarPerTanggalToolStripMenuItem1.Click
        open_page("FormSalesPayment", "tanggal")
    End Sub

    Private Sub BarangKeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangKeluarToolStripMenuItem.Click
        open_page("FormProduksiPantek")
    End Sub

    Private Sub BarangDiterrimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BarangDiterrimaToolStripMenuItem.Click
        open_page("FormProduksiPantekDiterima")
    End Sub

    Private Sub KlemKeluarToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemKeluarToolStripMenuItem.Click
        open_page("FormProduksiHitung")
    End Sub

    Private Sub KlemDiterimaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemDiterimaToolStripMenuItem.Click
        open_page("FormProduksiHitungDiterima")
    End Sub

    Private Sub PenggajianToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PenggajianToolStripMenuItem.Click
        open_page("FormPenggajian")
    End Sub

    Private Sub PakuToolStripMenuItem9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PakuToolStripMenuItem9.Click
        open_page("FormSalesPayment", "toko", "paku")
    End Sub

    Private Sub FormulaProduksiToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormulaProduksiToolStripMenuItem.Click
        open_page("FormMsFormula")
    End Sub

    Private Sub KlemJadiToolStripMenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KlemJadiToolStripMenuItem5.Click
        open_page("FormTrPO", "klem_jadi")
    End Sub
End Class