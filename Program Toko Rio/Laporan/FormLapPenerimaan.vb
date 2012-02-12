Imports System.Data.SqlClient

Public Class FormLapPenerimaan
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
            MsgBox("failed")
        End Try
    End Sub

    Private Sub initGrid(ByVal s As String, ByVal s2 As String) 'area,toko
        tg1 = String.Format("{0:yyyy-MM-dd}", txtTgl.Value)
        tg2 = String.Format("{0:yyyy-MM-dd}", txtTgl2.Value)
        Dim reader As SqlDataReader = Nothing
        Dim jenisPB As String = ""
        If RadioButton1.Checked = True Then
            jenisPB = "klem"
        Else
            jenisPB = "paku"
        End If

        query = "  select ho.no_Pb `No. Penerimaan`,DATE_FORMAT(Tanggal_TerimaBarang,'%d-%m-%Y') `Tgl Terima Barang`,c.Nama `Supplier`,mp.KdBahanMentah `Part No.`,NamaBahanMentah NamaBarang " & _
        " ,Qty_real Qty,FORMAT(harga,0) Harga, FORMAT(sum(Qty_real*harga),0) `Total`   " & _
        " , CASE WHEN StatusPaid = 1 THEN 'Lunas'  " & _
        " WHEN StatusPaid = 0 THEN 'Belum Lunas' End 'Pembayaran' " & _
        " from trheaderpb ho join trdetailpb do  on ho.no_pb=do.no_pb join  MsBahanMentah mp on mp.KdBahanMentah=do.KdBahanMentah " & _
        " join trheaderpo hpo on hpo.no_po=ho.no_po  join mssupplier c on c.kdsupplier = hpo.kdsupplier    " & _
        " where  DATE_FORMAT(Tanggal_TerimaBarang,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(Tanggal_TerimaBarang,'%Y-%m-%d') <='" & tg2 & "' " & _
        " and  StatusTerimaBarang <> 0 and jenis_pb='" & jenisPB & "' " & _
        " group by ho.no_Pb,`Tgl Terima Barang`,c.Nama,do.KdBahanMentah,NamaBahanMentah,Qty_real,Harga  "
        '"left join( " & _
        '      "     select ho.KdPB,ho.kdretur,  IFNULL(sum(qty * (harga - (harga*do.disc/100))),0)  `Total Retur`  " & _
        '      "     from trheaderreturbeli ho join trdetailreturbeli do  on ho.Kdretur=do.KDRetur   " & _
        '      " where(StatusRetur <> 0) " & _
        '      "     group by ho.kdpb,ho.kdretur   " & _
        '      " )as ret on ret.kdPB= ho.no_pb  " & _
        sql = query


        TextBox1.Text = query
        Dim totalJual As Double = 0
        Dim jumlahHasil As Double = 0
        Dim totalJualHarga As Double = 0
        'Try
        Dim jumAr As Integer = 0
        Dim idAr As Integer = 0
        Dim reader21 = execute_reader(sql)
        Do While reader21.Read
            jumAr = jumAr + 1
        Loop
        reader21.Close()
        reader21 = Nothing

        Dim NO_PO(jumAr) As String
        Dim NO_PB(jumAr) As String
        Dim Tgl_PB(jumAr) As String
        Dim supplier(jumAr) As String
        Dim Part_No(jumAr) As String
        Dim Nama_barang(jumAr) As String
        Dim merk(jumAr) As String
        Dim subkategori(jumAr) As String
        Dim qty(jumAr) As Double
        Dim harga(jumAr) As Double
        Dim total(jumAr) As Double
        Dim pembayaran(jumAr) As String


        reader21 = execute_reader(sql)
        Do While reader21.Read
            NO_PO(idAr) = "1" 'reader21("No PO")
            NO_PB(idAr) = reader21("No. Penerimaan")
            Tgl_PB(idAr) = reader21("Tgl Terima Barang")
            supplier(idAr) = reader21("Supplier")
            Part_No(idAr) = reader21("Part No.")
            Nama_barang(idAr) = reader21("NamaBarang")
            merk(idAr) = "" 'reader21("Merk")
            subkategori(idAr) = "" 'reader21("Subkategori")
            qty(idAr) = reader21("Qty")
            harga(idAr) = reader21("Harga")
            total(idAr) = reader21("Total")
            pembayaran(idAr) = reader21("Pembayaran")

            idAr = idAr + 1
        Loop
        reader21.Close()

        dropTableTotal()
        createTabTotal()
        Dim x As Integer = 0
        For x = 0 To idAr - 1
            sql = "insert into v_total_pb(NO_PO,NO_PB,Tgl_Terima_Barang,Supplier,Part_No,NamaBarang,Merk,Subkategori,Qty,Harga,Total,Pembayaran) " & _
            "  values('" & NO_PO(x) & "','" & NO_PB(x) & "','" & Tgl_PB(x) & "','" & supplier(x) & "','" & Part_No(x) & "','" & Nama_barang(x) & "','" & merk(x) & "','" & subkategori(x) & "'," & qty(x) & "," & harga(x) & "," & total(x) & ",'" & pembayaran(x) & "')"
            Try
                execute_update(sql)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Next
        'TextBox1.Text = sql
        Try

            tglMulai = tg1
            tglAkhir = tg2
            '   dropview("viewCetakLapPB" & kdKaryawan)
            '  createview(query, "viewCetakLapPB" & kdKaryawan)
            DataGridView1.DataSource = execute_datatable(query)
            jumlahHasil = DataGridView1.RowCount
            If jumlahHasil = 0 Then
                MsgBox("Tidak ada data ", MsgBoxStyle.Information)
            End If

            Dim totalValue As Double = 0
            Dim reader2 = execute_reader(query)
            Do While reader2.Read
                totalValue += reader2("Total")
            Loop
            reader2.Close()
            lblTotal.Text = FormatNumber(totalValue, 0)
            Button3.Enabled = True

        Catch
            MsgBox("Gagal query", MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub FormLapPenerimaan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Button3.Enabled = False
        txtTgl.Value = Convert.ToDateTime("01/" & Today.Month & "/" & Today.Year)
        txtTgl2.Value = Convert.ToDateTime(Today.Date)
        RadioButton1.Checked = True
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        initGrid("", "")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        flagLaporan = "lap_pb"
        'CRLaporan.Show() 
        open_subpage("CRLaporan")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        initGrid("", "")
    End Sub

    Private Sub createTabTotal()
        Try
            Dim sql As String
            sql = " create Table v_total_pb (" & _
                " id int(11) NOT NULL auto_increment primary key,  " & _
                " NO_PO varchar(20) NULL , " & _
                " NO_PB varchar(20) NULL, " & _
                " Tgl_Terima_Barang varchar(30) NULL , " & _
                " Supplier varchar(60) NULL , " & _
                " Part_No varchar(20) NULL , " & _
                " NamaBarang varchar(50) NULL , " & _
                " Merk varchar(50) NULL , " & _
                " Subkategori varchar(50) NULL , " & _
                " Qty int(11) NULL , " & _
                " Harga int(11) NULL , " & _
                " Total int(11) NULL , " & _
                " Pembayaran varchar(20) NULL " & _
                " )"
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dropTableTotal()
        Try
            Dim sql As String
            sql = "drop table v_total_pb "
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub
End Class