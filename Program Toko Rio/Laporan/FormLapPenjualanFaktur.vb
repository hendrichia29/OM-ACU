Imports System.Data.SqlClient

Public Class FormLapPenjualanFaktur
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
        Dim namaview As String = ""
        jenisReport = ""
        namaview = "viewCetakLapPenjualanFk"
        Dim queryFrom As String = ""
        Dim query2 As String = ""
        Dim jenisFaktur = ""
        If RadioButton1.Checked = True Then
            jenisFaktur = "klem"
        ElseIf RadioButton2.Checked = True Then
            jenisFaktur = "paku"
        End If
        query = " select hr.KdFaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d-%m-%Y') `Tgl Faktur`,hr.KdSO `No Pemesanan`,DATE_FORMAT(TanggalSO,'%d-%m-%Y') `Tgl Pemesanan`,NamaToko " & _
        ", FORMAT(hr.Jumlah,0) `Grandtotal Sblm Disc`,hr.Disc `Disc (%)`, format(hr.Grandtotal,0)  `Grandtotal`  " & _
        ",DATE_FORMAT(TanggalJT,'%d-%m-%Y') `Tgl Jatuh Tempo` "
        query2 = " select hr.KdFaktur `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d-%m-%Y') `Tgl Faktur`,hr.KdSO `No Pemesanan`,DATE_FORMAT(TanggalSO,'%d-%m-%Y') `Tgl Pemesanan`,NamaToko " & _
        ",hr.Jumlah `Grandtotal Sblm Disc`,hr.Disc `Disc (%)`, hr.Grandtotal  `Grandtotal`  " & _
        ",DATE_FORMAT(TanggalJT,'%d-%m-%Y') `Tgl Jatuh Tempo` "
        queryFrom += "  from    " & _
        "  trfaktur hr join mstoko c on c.kdtoko = hr.kdtoko " & _
        "  Join trsalesorder so On so.kdSo = hr.KdSO  "
        queryFrom += "  where  DATE_FORMAT(TanggalFaktur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalFaktur,'%Y-%m-%d') <='" & tg2 & "'"
        queryFrom += "  and StatusFaktur <> 0  AND jenis_faktur='" & jenisFaktur & "' "
        'queryFrom += "  group by hr.KdFaktur,`Tgl Faktur`,hr.KdSO,TanggalSO,NamaToko,dr.KdBarang,NamaBarang,Merk,Qty,Harga,dr.Disc  "

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
            dropview(namaview & "us11010001")
            createview(query2, namaview & "us11010001")
            DataGridView1.DataSource = execute_datatable(query)
            jumlahHasil = DataGridView1.RowCount
            If jumlahHasil = 0 Then
                MsgBox("Tidak ada data ", MsgBoxStyle.Information)
            End If

            Dim totalValue As Double = 0
            Dim reader2 = execute_reader(query)
            Do While reader2.Read
                totalValue += reader2("Grandtotal")
            Loop
            reader2.Close()
            lblTotal.Text = FormatNumber(totalValue, 0)
            Button3.Enabled = True

        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub
    Private Sub FormLapPenjualanFaktur_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        status = 0
        Button3.Enabled = False

        txtTgl.Value = Convert.ToDateTime("01/" & Today.Month & "/" & Today.Year)
        txtTgl2.Value = Convert.ToDateTime(Today.Date)


        status = 2

        RadioButton1.Checked = True
        Label2.Visible = True
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        initGrid("", "")

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        flagLaporan = "lap_jual"
        open_subpage("CRLaporan")
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        view()
    End Sub

    Private Sub view()
        Dim key As String = ""
        Dim key2 As String = ""
        If RadioButton1.Checked = False And RadioButton2.Checked = False Then
            MsgBox("Jenis penjualan harus dipilih", MsgBoxStyle.Information)
        Else
            initGrid(key, key2)
        End If
        'If cmbCari.Text = "Article" Then
        '    key = "Artikel"
        'ElseIf cmbCari.Text = "Kode Barang" Then
        '    key = "mp.KdBarang"
        'End If
        'If cmbCari2.Text = "Kode Customer" Then
        '    key2 = "ho.KdCustomer"
        'ElseIf cmbCari2.Text = "Nama Toko" Then
        '    key2 = "c.NamaToko"
        'End If
        ' key2 = cmbCari2.Text

    End Sub
End Class