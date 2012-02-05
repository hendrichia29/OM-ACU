Imports System.Data.SqlClient

Public Class FormLapLabaRugi
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

        'JANGAN DIHAPUS
        'query = " select refNumber `No Faktur`, df.KdBarang , df.Harga,HargaAwal,df.qty,df.disc, df.Harga* df.Disc / 100  `disc angka`," & _
        '" ((df.Harga - (df.Harga* df.Disc / 100 )  - hargaawal)  * df.qty)  " & _
        '
        query = "select refNumber `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d %M %Y') `Tgl Faktur`,NamaToko, FORMAT(sum((df.Harga - (df.Harga* df.Disc / 100 )  - hargaawal)  * " & _
" (df.qty - ifnull((select ifnull(qty,0) from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  where KdFaktur= refNumber and kdbarang=df.KdBarang),0))),0)  `Total Laba/Rugi`   "

        query2 = "select refNumber `No Faktur`,DATE_FORMAT(TanggalFaktur,'%d %M %Y') `Tgl Faktur`,NamaToko, sum((df.Harga - (df.Harga* df.Disc / 100 )  - hargaawal)  * " & _
" (df.qty - ifnull((select ifnull(qty,0) from trretur r join trreturdetail dr on dr.kdretur=r.kdretur  where KdFaktur= refNumber and kdbarang=df.KdBarang),0)))  `Total Laba/Rugi`   "

        queryFrom = "  from  trfakturdetail df " & _
        "  join `baranghistory` bgh on bgh.kdbarang = df.KdBarang " & _
        "  join trfaktur ho on ho.KdFaktur=bgh.refnumber " & _
        "  join mstoko c on c.kdtoko = ho.kdtoko " & _
        "  where Module ='Form Faktur'" & _
        "  and refnumber in(" & _
        "  select kdfaktur from trfaktur " & _
        "  where DATE_FORMAT(TanggalFaktur,'%Y-%m-%d') >='" & tg1 & "' and DATE_FORMAT(TanggalFaktur,'%Y-%m-%d') <='" & tg2 & "'" & _
        "  And StatusFaktur <> 0 And StatusPayment = 1 " & _
        "  )group by refNumber  order by refnumber asc  "

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
            dropview("viewCetakLapLR" & kdKaryawan)
            createview(query2, "viewCetakLapLR" & kdKaryawan)
            DataGridView1.DataSource = execute_datatable(query)
            jumlahHasil = DataGridView1.RowCount
            If jumlahHasil = 0 Then
                MsgBox("Tidak ada data ", MsgBoxStyle.Information)
            End If

            Dim totalValue As Double = 0
            Dim reader2 = execute_reader(query)
            Do While reader2.Read
                totalValue += reader2("Total Laba/Rugi")
            Loop
            reader2.Close()
            lblTotal.Text = FormatNumber(totalValue, 0)
            Button3.Enabled = True
            
        Catch
            MsgBox("Gagal query", MsgBoxStyle.Critical)
        End Try
        setGrid()
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
            .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold
        End With
        DataGridView1.Columns(0).Width = 140
        DataGridView1.Columns(1).Width = 120
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 200
    End Sub


    Private Sub FormLapLabaRugi_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Button3.Enabled = False
        txtTgl.Value = Convert.ToDateTime("01/" & Today.Month & "/" & Today.Year)
        txtTgl2.Value = Convert.ToDateTime(Today.Date)
    End Sub

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        initGrid("", "")
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        flagLaporan = "lap_laba_rugi"
        open_subpage("CRLaporan")
        'CRLaporan.Show()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        initGrid("", "")
    End Sub
End Class