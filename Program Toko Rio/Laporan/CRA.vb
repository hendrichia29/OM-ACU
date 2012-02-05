Imports System.Data.SqlClient

Public Class CRA
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
            TextBox1.Text = sql
            execute_update(sql)
            MsgBox("1")
        Catch ex As Exception
        End Try
    End Sub
    Private Sub CRA_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim query As String
        kdKaryawan = "US11010001"
        'query = "select So.KdSO,TanggalSO,GrandTotal,StatusSO,SOD.KdBarang,NamaBarang, " & _
        '" SOD.Harga,SOD.Qty,SOD.Disc,Statusbarang,MS.NamaSales,MS.Alamat,MS.NoTelp NoTelpSales,MS.NoHP NoHPSales,  " & _
        '" MT.NamaToko,MT.AlamatToko,MT.Daerah,MT.NoTelp NoTelpCustomer,Mt.NoHP NoHPCustomer " & _
        '" from TrSalesOrder SO " & _
        '" join trSalesOrderdetail SOD on SOD.KdSO = so.kdso  " & _
        '" Join MsSales MS On MS.KdSales = SO.KdSales  " & _
        '" Join MsToko MT On MT.KdToko = SO.KdToko  " & _
        '" Join MsArea MP On MP.KdArea = MT.KdArea    " & _
        '" Join MsBarang MB On MB.KdBarang = SOD.KdBarang  "

        'dropview("viewCetakTrSO" & kdKaryawan)
        'createview(query, "viewCetakTrSO" & kdKaryawan)

        'query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBarang,NamaBarang,harga,qty,disc" & _
        '"  from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO" & _
        '"  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbarang mp on mp.KDBarang=do.KDBarang" & _
        '"  join mstoko c on c.kdtoko = ho.kdtoko  join msarea a on a.kdarea = c.kdarea"
        'dropview("viewCetakTrFaktur" & kdKaryawan)
        'createview(query, "viewCetakTrFaktur" & kdKaryawan)
        'CRPrintTransaksi.Show()


        'query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBarang,NamaBarang,harga,qty,disc" & _
        '"  from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO" & _
        '"  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbarang mp on mp.KDBarang=do.KDBarang" & _
        '"  join mstoko c on c.kdtoko = ho.kdtoko  join msarea a on a.kdarea = c.kdarea"
        'idPrint = "RT1108140001"
        'query = "select retur.KdRetur ,TanggalRetur,retur.KdFaktur , NamaSales ,  " & _
        '" NamaToko, retur.Grandtotal, retur.Status, mp.KDBarang, NamaBarang, harga, qty, disc " & _
        '" from  trretur  retur " & _
        '" Join trfaktur faktur On faktur.kdfaktur = retur.kdfaktur   " & _
        '" join trreturdetail rd on rd.kdretur = retur.kdretur " & _
        '" join msbarang mp on mp.kdbarang = rd.kdbarang " & _
        '" Join mssales ms On ms.kdsales = faktur.kdsales   " & _
        '" Join mstoko mt On mt.kdtoko = faktur.kdtoko   " & _
        '" Join msuser mu On mu.userid = retur.userid  " & _
        '"where StatusRetur = 1 and retur.kdretur='" & idPrint & "' "
        'dropviewM("viewCetakTrReturJual" & kdKaryawan)
        'createviewM(query, "viewCetakTrReturJual" & kdKaryawan)
        'flagLaporan = "retur_jual"
        'CRPrintTransaksi.Show()


        'PO
        '  idPrint = "PO11080002"
        '  query = "select PO.NO_PO,Tanggal_PO,MB.KdBarang,NamaBarang,  " & _
        '"    POD.Harga,POD.Jumlah,MS.Nama,MS.Alamat,MS.Daerah,MS.NoTelp NoTelp,MS.NoHP NoHP         " & _
        '"    from Trheaderpo PO  " & _
        '"    join trdetailpo POD on POD.no_po = PO.no_po " & _
        '"    Join Mssupplier MS On MS.KdSupplier = PO.KdSupplier " & _
        '"    Join MsBarang MB On MB.KdBarang = POD.KdBarang where PO.no_po='" & idPrint & "'"
        '  dropviewM("viewCetakPO" & kdKaryawan)
        '  createviewM(query, "viewCetakPO" & kdKaryawan)
        '  flagLaporan = "po"
        '  CRPrintTransaksi.Show()

        'PB
        idPrint = "PB11080001"
        query = "select pb.No_PB,Tanggal_TerimaBarang,PO.NO_PO,Tanggal_PO,MB.KdBarang,NamaBarang,  " & _
        " POD.Harga,POD.Qty,MS.Nama,MS.Alamat,MS.Daerah,MS.NoTelp NoTelp,MS.NoHP NoHP   " & _
        "  from Trheaderpo PO " & _
        "  join trheaderpb pb on Pb.no_po = PO.no_po" & _
        "  join trdetailpb POD on Pb.no_pb = POD.no_pb" & _
        "  Join Mssupplier MS On MS.KdSupplier = PO.KdSupplier " & _
        "  Join MsBarang MB On MB.KdBarang = POD.KdBarang where PB.no_pb='" & idPrint & "'"
        dropviewM("viewCetakPB" & kdKaryawan)
        createviewM(query, "viewCetakPB" & kdKaryawan)
        flagLaporan = "pb"
        'CRPrintTransaksi.Show()

    End Sub
End Class