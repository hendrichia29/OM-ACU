Imports System.Data.SqlClient
Module tool_module
    Public form 'variable for main form management
    Public opened_page As String 'variable for current opened page
    Public sub_form 'variable for sub form management

    'function for closing main page management
    Function close_allpage()
        Try
            form.close()
        Catch ex As NullReferenceException
            MsgBox("There's an error occur while trying to close the page. Please try again.", MsgBoxStyle.OkOnly, "Error")
            opened_page = ""
            Return False
        End Try
        Return True
    End Function

    Function clear_variable_array()
        For i As Integer = 1 To 6
            data_carier(i) = ""
        Next
        Return True
    End Function

    'function for opening main page management
    Function open_page(ByVal page_to_open As String, Optional ByVal detail_id As String = "", Optional ByVal additional As String = "")
        If opened_page <> "" Then
            Try
                form.Close()
            Catch ex As NullReferenceException
                MsgBox("There's an error occur while trying to open the page. Please try again.", MsgBoxStyle.OkOnly, "Error")
                opened_page = ""
                Return False
            End Try
        End If

        If page_to_open = "FormMsProvinsi" Then
            form = New FormMsProvinsi
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsProvinsi"
        ElseIf page_to_open = "FormMsSales" Then
            form = New FormMsSales
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsSales"
        ElseIf page_to_open = "FormMsSupplier" Then
            form = New FormMsSupplier
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsSupplier"
        ElseIf page_to_open = "FormMsToko" Then
            form = New FormMsToko
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsToko"
        ElseIf page_to_open = "FormMsBahanMentahTipe" Then
            form = New FormMsBahanMentahTipe
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsBahanMentahTipe"
        ElseIf page_to_open = "FormMsMerk" Then
            form = New FormMsMerk
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsMerk"
        ElseIf page_to_open = "FormMsKategori" Then
            form = New FormMsKategori
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsKategori"
        ElseIf page_to_open = "FormSOManagemen" Then
            form = New FormSOManagamen
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormSOManagamen"
        ElseIf page_to_open = "FormSO" Then
            form = New FormSO
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormSO"
        ElseIf page_to_open = "FormMsBahanMentah" Then
            form = New FormMsBahanMentah
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsBahanMentah"
        ElseIf page_to_open = "FormMsBarang" Then
            form = New FormMsBarang
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsBarang"
        ElseIf page_to_open = "FormBarangAdjusment" Then
            form = New FormBarangAdjustment
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormBarangAdjusment"
        ElseIf page_to_open = "FormMsBahanMentahSubKategori" Then
            form = New FormMsBahanMentahSubKategori
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsBahanMentahSubKategori"
        ElseIf page_to_open = "FormFaktur" Then
            form = New FormFaktur
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormFaktur"
        ElseIf page_to_open = "FormRetur" Then
            form = New FormRetur
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormRetur"
        ElseIf page_to_open = "FormSalesPayment" Then
            form = New FormSalesPayment
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            data_carier(1) = additional
            form.Show()
            data_carier(0) = ""
            data_carier(1) = ""
            opened_page = "FormSalesPayment"
        ElseIf page_to_open = "FormSalesPaymentManagamen" Then
            form = New FormSalesPaymentManagamen
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormSalesPaymentManagamen"
        ElseIf page_to_open = "FormPOManagement" Then
            form = New FormTrPOManagement
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormPOManagement"
        ElseIf page_to_open = "FormTrPenerimaanBahanMentah" Then
            form = New FormTrPenerimaanBahanMentah_backup
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormTrPenerimaanBahanMentah"
        ElseIf page_to_open = "FormMsProfile" Then
            form = New FormMsProfile
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsProfile"
        ElseIf page_to_open = "FormLapPO" Then
            form = New FormLapPO
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapPO"
        ElseIf page_to_open = "FormLapSO" Then
            form = New FormLapSO
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapSO"
        ElseIf page_to_open = "FormLapPenjualan" Then
            form = New FormLapPenjualan
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapPenjualan"
        ElseIf page_to_open = "FormLapReturJual" Then
            form = New FormLapReturJual
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapReturJual"
        ElseIf page_to_open = "FormLapPenerimaan" Then
            form = New FormLapPenerimaan
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapPenerimaan"
        ElseIf page_to_open = "FormLapReturBeli" Then
            form = New FormLapReturBeli
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapReturBeli"
        ElseIf page_to_open = "FormTrPO" Then
            form = New FormTrPO
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormTrPO"
        ElseIf page_to_open = "FormKomisiSales" Then
            form = New FormKomisiSales
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormKomisiSales"
        ElseIf page_to_open = "FormLapLabaRugi" Then
            form = New FormLapLabaRugi
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapLabaRugi"
        ElseIf page_to_open = "FormMsKaryawan" Then
            form = New FormMsKaryawan
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsKaryawan"
            'FormMsKlem
        ElseIf page_to_open = "FormMsKlem" Then
            form = New FormMsBahanMentah
            form.MdiParent = FormMain
            data_carier(0) = "Klem"
            form.Show()
            data_carier(0) = ""
            opened_page = "FormMsKlem"
        ElseIf page_to_open = "FormMsPaku" Then
            form = New FormMsBahanMentah
            form.MdiParent = FormMain
            data_carier(0) = "Paku"
            form.Show()
            data_carier(0) = ""
            opened_page = "FormMsPaku"
        ElseIf page_to_open = "FormBackUpDB" Then
            form = New FormBackUpDB
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormBackUpDB"
        ElseIf page_to_open = "FormTrReturPembelian" Then
            form = New FormTrReturPembelian
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormTrReturPembelian"
        ElseIf page_to_open = "FormPurchasePayment" Then
            form = New FormPurchasePayment
            form.MdiParent = FormMain
            data_carier(0) = detail_id
            form.Show()
            data_carier(0) = ""
            opened_page = "FormPurchasePayment"
        ElseIf page_to_open = "FormLapPembayaranPiutang" Then
            form = New FormLapPembayaranPiutang
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapPembayaranPiutang"
        ElseIf page_to_open = "FormLapPembayaranUtang" Then
            form = New FormLapPembayaranUtang
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormLapPembayaranUtang"
        ElseIf page_to_open = "FormMsFormula" Then
            form = New FormMsFormula
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormMsFormula"
        ElseIf page_to_open = "FormProduksiPantek" Then
            form = New FormProduksiPantek
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormProduksiPantek"
        ElseIf page_to_open = "FormProduksiPantekDiterima" Then
            form = New FormProduksiPantekDiterima
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormProduksiPantekDiterima"
        ElseIf page_to_open = "FormProduksiHitung" Then
            form = New FormProduksiHitung
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormProduksiHitung"
        ElseIf page_to_open = "FormProduksiHitungDiterima" Then
            form = New FormProduksiHitungDiterima
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormProduksiHitungDiterima"
        ElseIf page_to_open = "FormPenggajian" Then
            form = New FormPenggajian
            form.MdiParent = FormMain
            form.Show()
            opened_page = "FormPenggajian"
        End If
        Return True
    End Function

    'function for opening sub page management
    Function open_subpage(ByVal subpage_to_open As String, Optional ByVal detail_id As String = "", Optional ByVal additional As String = "")
        If subpage_to_open = "FormBrowseBarang" Then
            sub_form = New FormBrowseBarang
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormBrowseBahanMentah" Then
            sub_form = New FormBrowseBahanMentah
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormSOManagamen" Then
            sub_form = New FormSOManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormSOPendingManagamen" Then
            sub_form = New FormSOPendingManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormFakturManagamen" Then
            sub_form = New FormFakturManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormReturManagamen" Then
            sub_form = New FormReturManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormSalesPaymentManagamen" Then
            sub_form = New FormSalesPaymentManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormSalesPaymentManagamen)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormSalesPaymentByDateManagamen" Then
            sub_form = New FormSalesPaymentByDateManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            sub_form.ShowDialog(FormSalesPaymentByDateManagamen)
            data_carier(0) = ""
            data_carier(1) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormBarangHistory" Then
            sub_form = New FormBarangHistory
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "CRPrintTransaksi" Then
            sub_form = New CRPrintTransaksi
            data_carier(0) = "" 'detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "CRLaporan" Then
            sub_form = New CRLaporan
            data_carier(0) = "" 'detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormPOManagement" Then
            sub_form = New FormTrPOManagement
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormTrPenerimaanBahanMentahM" Then
            sub_form = New FormTrPenerimaanBahanMentahM
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormTrPenerimaanBahanMentah" Then
            sub_form = New FormTrPenerimaanBahanMentah_backup
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormTrReturPembelianM" Then
            sub_form = New FormTrReturPembelianM
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormPurchasePaymentManagamen" Then
            sub_form = New FormPurchasePaymentManagamen
            data_carier(0) = detail_id
            If (detail_id <> "") Then
                data_carier(1) = "update"
            Else
                data_carier(1) = "add"
            End If
            data_carier(2) = additional
            sub_form.ShowDialog(FormPurchasePaymentManagamen)
            data_carier(0) = ""
            data_carier(1) = ""
            data_carier(2) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormBrowseTanggalSuratJalan" Then
            sub_form = New FormBrowseTanggalSuratJalan
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "CRDaftarTagih" Then
            '[    sub_form = New CRDaftarTagih
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormBrowseSales" Then
            sub_form = New FormBrowseSales
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormBahanMentahHistory" Then
            sub_form = New FormBahanMentahHistory
            data_carier(0) = detail_id
            data_carier(1) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            sub_form = ""
        ElseIf subpage_to_open = "print_sales_order" Then
            sub_form = New sales_order
            data_carier(0) = detail_id
            data_carier(1) = additional
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            data_carier(1) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormProduksiPantekManagement" Then
            sub_form = New FormProduksiPantekManagement
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormProduksiPantekDiterimaManagement" Then
            sub_form = New FormProduksiPantekDiterimaManagement
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormProduksiHitungManagement" Then
            sub_form = New FormProduksiHitungManagement
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormProduksiHitungDiterimaManagement" Then
            sub_form = New FormProduksiHitungDiterimaManagement
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        ElseIf subpage_to_open = "FormPenggajianManagement" Then
            sub_form = New FormPenggajianManagement
            data_carier(0) = detail_id
            sub_form.ShowDialog(FormMain)
            data_carier(0) = ""
            sub_form = ""
        End If
        Return True
    End Function

    'Qty yang akan di input ke history
    'Op : Operator Min Atau Plus
    'Attribute : Attribute Table yang akan di insert
    Function BarangHistory(ByVal Qty As String, ByVal Op As String, ByVal Attribute As String, ByVal KdBarang As String, ByVal HargaAwal As String, ByVal HargaAkhir As String, Optional ByVal KdTrans As String = "", Optional ByVal Modul As String = "", Optional ByVal StatusBarangList As String = "0", Optional ByVal StockAkhir As Integer = 0)
        If Qty <> 0 Then
            Dim StockAwal = StockAkhir

            If Op = "Min" Then
                StockAkhir = Val(StockAkhir) - Val(Qty)
            ElseIf Op = "Plus" Then
                If StatusBarangList = 0 Then
                    StockAkhir = Val(StockAkhir) + Val(Qty)
                Else
                    StockAkhir = Val(StockAkhir)
                End If
            End If

            Dim sqlHistory = "insert into BarangHistory(KdBarang,UserID,TanggalHistory,StockAwal, " & _
                              Attribute & ",StockAkhir,HargaAwal,HargaAkhir,Module,RefNumber,StatusBarangList) " & _
                              "values('" + KdBarang + "','" & kdKaryawan & "',now(), " & _
                              "'" & StockAwal & "','" & Qty & "', " & _
                              "'" & Trim(StockAkhir) & "','" & Trim(HargaAwal) & "','" & Trim(HargaAkhir) & "', " & _
                              "'" & Modul & "','" & Trim(KdTrans) & "','" & Trim(StatusBarangList) & "')"

            execute_update_manual(sqlHistory)
        End If
        Return True
    End Function

    'Qty yang akan di input ke history
    'Op : Operator Min Atau Plus
    'Attribute : Attribute Table yang akan di insert
    Function BahanMentahHistory(ByVal Qty As String, ByVal Op As String, ByVal Attribute As String, ByVal KdBahanMentah As String, ByVal HargaAwal As String, ByVal HargaAkhir As String, Optional ByVal KdTrans As String = "", Optional ByVal Modul As String = "", Optional ByVal jenis As String = "Klem", Optional ByVal StatusBarangList As String = "0", Optional ByVal StockAkhir As Integer = 0)
        If Qty <> 0 Then
            Dim StockAwal = StockAkhir

            If Op = "Min" Then
                StockAkhir = Val(StockAkhir) - Val(Qty)
            ElseIf Op = "Plus" Then
                StockAkhir = Val(StockAkhir) + Val(Qty)
            End If

            Dim sqlHistory = "insert into BahanMentahHistory(KdBahanMentah,UserID,TanggalHistory,StockAwal, " & _
                              Attribute & ",StockAkhir,HargaAwal,HargaAkhir,Module,RefNumber,StatusBahanMentahList,Jenis) " & _
                              "values('" + KdBahanMentah + "','" & kdKaryawan & "',now(), " & _
                              "'" & StockAwal & "','" & Qty & "', " & _
                              "'" & Trim(StockAkhir) & "','" & Trim(HargaAwal) & "','" & Trim(HargaAkhir) & "', " & _
                              "'" & Modul & "','" & Trim(KdTrans) & "','" & Trim(StatusBarangList) & "','" & jenis & "')"

            execute_update_manual(sqlHistory)
        End If
        Return True
    End Function

    'Qty yang akan di input ke history
    'Op : Operator Min Atau Plus
    'Attribute : Attribute Table yang akan di insert
    Function StockBarang(ByVal Qty As String, ByVal Op As String, ByVal Harga As String, ByVal KdBarang As String, ByVal Attribute As String, Optional ByVal KdTrans As String = "", Optional ByVal Modul As String = "", Optional ByVal StatusBarangList As String = "0")
        Dim CurrentQty = 0
        Dim sqlHistory = ""
        Dim cnt = 0
        Dim StockAkhir = 0
        Dim readerCnt = execute_reader("Select count(*) cnt from MsBarangList Where KdBarang = '" & KdBarang & "' And StatusBarangList = 0 ")

        If readerCnt.Read Then
            cnt = readerCnt(0)
        End If
        readerCnt.Close()
        Dim qty_arr(cnt)
        Dim KdList_arr(cnt)
        Dim harga_arr(cnt)

        readerCnt.Close()

        Dim readerStock = execute_reader("Select StockAwal,StockAkhir from baranghistory where isActive = 1 And KdBarang = '" & KdBarang & "' order by KdBarangHistory desc limit 1")
        Do While readerStock.Read
            StockAkhir = readerStock(1)
        Loop
        readerStock.Close()

        If Op = "Min" Then
            Dim reader = execute_reader("Select Qty,KdList,harga from MsBarangList Where KdBarang = '" & KdBarang & "' And StatusBarangList = 0 order by KdList asc")
            Dim no = 0
            Do While reader.Read
                qty_arr(no) = reader(0)
                KdList_arr(no) = reader(1)
                harga_arr(no) = reader(2)
                no += 1
            Loop
            reader.Close()
            For i As Integer = 0 To no - 1
                If Val(Qty) >= Val(qty_arr(i)) Then
                    execute_update_manual("Delete from MsBarangList where KdList = " & KdList_arr(i))
                    CurrentQty += qty_arr(i)
                ElseIf Val(Qty) < Val(qty_arr(i)) Then
                    sqlHistory = "Update MsBarangList set Qty = Qty - " & Val(Qty) & " where KdList = '" & KdList_arr(i) & "'"
                    execute_update_manual(sqlHistory)
                    CurrentQty = Qty
                End If
                BarangHistory(Math.Abs(Val(CurrentQty)), Op, Trim(Attribute), KdBarang, harga_arr(i), Harga, KdTrans, Modul, 0, StockAkhir)
                If Qty = CurrentQty Then
                    Return True
                Else
                    Qty = Qty - Val(qty_arr(i))
                    StockAkhir -= qty_arr(i)
                End If
            Next
        ElseIf Op = "Plus" Then
            sqlHistory = "Insert into MsBarangList(KdBarang,Harga,Qty,StatusBarangList) values('" & KdBarang & "'," & Harga & "," & Qty & "," & StatusBarangList & ")"
            execute_update_manual(sqlHistory)
            BarangHistory(Val(Qty), Op, Trim(Attribute), KdBarang, Harga, 0, KdTrans, Modul, StatusBarangList, StockAkhir)
        End If
        Return True
    End Function

    Function StockBahanMentah(ByVal Qty As String, ByVal Op As String, ByVal Harga As String, ByVal KdBahanMentah As String, ByVal Attribute As String, Optional ByVal KdTrans As String = "", Optional ByVal Modul As String = "", Optional ByVal jenis As String = "Klem", Optional ByVal StatusBarangList As String = "0")
        Dim CurrentQty = 0
        Dim sqlHistory = ""
        Dim cnt = 0
        Dim StockAkhir = 0
        Dim readerCnt = execute_reader("Select count(*) cnt from MsBahanMentahList Where KdBahanMentah = '" & KdBahanMentah & "'  And StatusBahanMentahList = 0 ")

        If readerCnt.Read Then
            cnt = readerCnt(0)
        End If
        readerCnt.Close()
        Dim qty_arr(cnt)
        Dim KdList_arr(cnt)
        Dim harga_arr(cnt)

        readerCnt.Close()

        Dim readerStock = execute_reader("Select StockAwal,StockAkhir from bahanmentahhistory where isActive = 1 And KdBahanMentah = '" & KdBahanMentah & "' And StatusBahanMentahList = 0 order by KdHistory desc limit 1")
        Do While readerStock.Read
            StockAkhir = readerStock(1)
        Loop
        readerStock.Close()
        If Op = "Min" Then
            Dim reader = execute_reader("Select Qty,KdBahanMentahList,harga from MsBahanMentahList Where KdBahanMentah = '" & KdBahanMentah & "' order by KdBahanMentahList asc")
            Dim no = 0
            Do While reader.Read
                qty_arr(no) = reader(0)
                KdList_arr(no) = reader(1)
                harga_arr(no) = reader(2)
                no += 1
            Loop
            reader.Close()

            For i As Integer = 0 To no - 1
                If Val(Qty) >= Val(qty_arr(i)) Then
                    execute_update_manual("Delete from MsBahanMentahList where KdBahanMentahList = " & KdList_arr(i))
                    CurrentQty += qty_arr(i)
                ElseIf Val(Qty) < Val(qty_arr(i)) Then
                    sqlHistory = "Update MsBahanMentahList set Qty = Qty - " & Val(Qty) & " where KdBahanMentahList = '" & KdList_arr(i) & "'"
                    execute_update_manual(sqlHistory)
                    CurrentQty = Qty
                End If
                BahanMentahHistory(Math.Abs(Val(CurrentQty)), Op, Trim(Attribute), KdBahanMentah, harga_arr(i), Harga, KdTrans, Modul, jenis, 0, StockAkhir)
                If Qty = CurrentQty Then
                    Return True
                Else
                    Qty = Qty - Val(qty_arr(i))
                    StockAkhir -= qty_arr(i)
                End If
            Next
        ElseIf Op = "Plus" Then
            sqlHistory = "Insert into MsBahanMentahList(KdBahanMentah,Harga,Qty,Jenis,StatusBahanMentahList) values('" & KdBahanMentah & "'," & Harga & "," & Qty & ",'" & jenis & "'," & StatusBarangList & ")"
            execute_update_manual(sqlHistory)

            BahanMentahHistory(Val(Qty), Op, Trim(Attribute), KdBahanMentah, Harga, 0, KdTrans, Modul, jenis, StatusBarangList, StockAkhir)
        End If
        Return True
    End Function

    Function check_code(ByVal ID As String, ByVal CurrentID As String, ByVal NamaTable As String, ByVal PrimaryKey As String)
        Dim reader = execute_reader(" Select 1 from " & NamaTable & " " & _
                                " where " & PrimaryKey & " = '" & ID & "' " & _
                                " And " & PrimaryKey & " <> '" & CurrentID & "'")
        If reader.Read Then
            reader.Close()
            Return True
        Else
            reader.Close()
            Return False
        End If
        Return False
    End Function

    Function getCode(ByVal NamaTable As String, ByVal PrimaryKey As String, Optional ByVal Jenis As String = "")
        Dim addQuery = ""
        If Jenis <> "" Then
            addQuery = " AND Jenis = '" & Jenis & "' "
        End If
        Dim sql As String = " Select " & PrimaryKey & " " & _
                            " from " & NamaTable & " " & _
                            " WHERE 1 " & _
                            addQuery & _
                            " Order By " & PrimaryKey & " desc " & _
                            " limit 1"
        Dim reader = execute_reader(sql)
        Return reader
    End Function
    
    Function QueryLevel(ByVal lvlID As Integer, Optional ByVal clmName As String = "", Optional ByVal Attribute As String = "LevelID")
            Dim query As String = ""
            If lvlID = lvlStaffRio Then
                query = " And IfNull(" & clmName & Attribute & "," & lvlID & ") in (" & lvlID & "," & lvlSuperuser & ") "
            ElseIf lvlID = lvlStaffLain Then
                query = " And IfNull(" & clmName & Attribute & "," & lvlID & ") = " & lvlID & " "
            End If
            Return query
    End Function

    Public Sub dropviewM(ByVal viewname As String)
        Try
            Dim sql As String = " drop view  " & viewname
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Public Sub createviewM(ByVal q As String, ByVal viewName As String)
        Try
            Dim sql As String
            sql = " create view " & viewName & " as (" & q & " )"
            '    TextBox1.Text = sql
            execute_update(sql)
            ' MsgBox("1")
        Catch ex As Exception
        End Try
    End Sub

    Function GetPrioritasMerk()
        sql = " SELECT KdMerk, Isi, Merk FROM MsMerk " & _
              " WHERE Prioritas = 1 "
        Dim reader = execute_reader(sql)
        Return reader
        Return True
    End Function

    Public Function reset_number_format(ByVal number As String)
        Return number.ToString.Replace(".", "").Replace(",", "")
    End Function
End Module
