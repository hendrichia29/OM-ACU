Imports System.Data.SqlClient
Public Class FormSalesPaymentByDateManagamen
    Dim tipe_pembayaran As String
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""
    Dim komisi_sales = 0

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtp_tgl.Text = Now()
        dtp_dari_tgl.Text = Now()
        dtp_sampai_tgl.Text = DateAdd(DateInterval.Month, 1, Now())
        cmbSales.SelectedIndex = 0
    End Sub

    Public Sub setCmbSales()
        Dim varT As String = ""
        cmbSales.Items.Clear()
        cmbSales.Items.Add("- Pilih Sales -")
        Dim reader = execute_reader(" Select Distinct trfaktur.KdSales, NamaSales " & _
                                    " from trfaktur " & _
                                    " Join MsSales On MsSales.KdSales = trfaktur.KdSales " & _
                                    " LEFT JOIN trsalespayment payment ON payment.KdFaktur = trfaktur.KdFaktur " & _
                                    " where NamaSales <>'' " & _
                                    " And ( IfNull(PaidBy,0) = 0 Or IfNull(PaidBy,0) = 2 ) " & _
                                    " order by NamaSales asc ")
        Do While reader.Read
            cmbSales.Items.Add(reader("KdSales") & " - " & reader("NamaSales"))
        Loop
        reader.Close()
        If cmbSales.Items.Count > 0 Then
            cmbSales.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Function getPayment(Optional ByVal KdPayment As String = "")
        Dim sql As String = "Select KdSalesPayment from trSalesPayment order by no_increment desc "

        If KdPayment <> "" Then
            sql &= "KdSalesPayment = '" & KdPayment & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim Toko = ""
            Dim kdFaktur = ""
            Dim dari_tgl = ""
            Dim sampai_tgl = ""
            Dim readerPayment = execute_reader(" select KdSalesPayment,DATE_FORMAT(TanggalPayment, '%m/%d/%Y') Tanggal, " & _
                                               " DATE_FORMAT(DariTanggal, '%m/%d/%Y') dari_tanggal, " & _
                                               " DATE_FORMAT(SampaiTanggal, '%m/%d/%Y') sampai_tanggal, " & _
                                               " MS.KdSales, NamaSales, " & _
                                               " StatusSalesPayment, " & _
                                               " Note, TotalSalesPayment, DiscPembayaran " & _
                                               " from trsalespaymentbydate payment " & _
                                               " Join MsSales MS On MS.KdSales = payment.KdSales " & _
                                               " Where kdSalesPayment = '" & PK & "' ")
            If readerPayment.Read Then
                txtID.Text = readerPayment.Item("KdSalesPayment")
                dtp_tgl.Text = readerPayment.Item("Tanggal")
                dari_tgl = readerPayment.Item("dari_tanggal")
                sampai_tgl = readerPayment.Item("sampai_tanggal")
                kdsales = readerPayment.Item("KdSales") & " - " & readerPayment.Item("NamaSales")
                txtDiscPembayaran.Text = readerPayment.Item("DiscPembayaran")
                If readerPayment.Item("StatusSalesPayment") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                txtNote.Text = readerPayment.Item("Note")
            End If
            readerPayment.Close()
            cmbSales.Text = kdsales
            dtp_dari_tgl.Text = dari_tgl
            dtp_sampai_tgl.Text = sampai_tgl
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        clear_variable_array()
        setCmbSales()
        emptyField()
        If PK = "" Then
            generateCode()
            BtnPrint.Enabled = False
        Else
            setData()
            txtID.Text = PK
            BtnPrint.Enabled = True
        End If
        cmbSales.Focus()
    End Sub

    Private Sub generateCode()
        Dim code As String = "PF"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        Dim tempCompare As String = ""

        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, ".dd.MM.yy")
        tempCompare &= FormatDate

        Dim reader = getPayment()

        If reader.read Then
            kode = Trim(reader("KdSalesPayment").ToString())
            temp = kode.Substring(6, 9)
            If temp = tempCompare Then
                angka = CInt(kode.Substring(2, 4))
            Else
                angka = 0
            End If
            reader.Close()
        Else
            angka = 0
            reader.Close()
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka) & FormatDate
        txtID.Text = Trim(code)
    End Sub

    Function SavePaymentDetail(ByVal flag As String)
        Dim sqlDetail = ""
        Dim statusFaktur = 1

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim faktur = gridBarang.Rows.Item(i).Cells("clmFaktur").Value
            Dim total_faktur = gridBarang.Rows.Item(i).Cells("clmGrandtotal").Value
            Dim paid_by = gridBarang.Rows.Item(i).Cells("clmLangsungBayar").Value

            If paid_by = "Tidak" Then
                paid_by = 0
            Else
                paid_by = 1
            End If

            sqlDetail = " insert into trsalespaymentbydatedetail(KdSalesPayment, " & _
                        " KdFaktur, GrandtotalFaktur, PaidBy ) values( " & _
                        " '" & Trim(txtID.Text) & "', '" & faktur & "', " & _
                        " '" & total_faktur & "', '" & paid_by & "' )"
            execute_update_manual(sqlDetail)

            If flag = 1 Then
                Dim sqlFaktur = " Update TrFaktur set StatusPayment = '" & statusFaktur & "' " & _
                            " Where KdFaktur = '" & faktur & "' "
                execute_update_manual(sqlFaktur)
            End If
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbSales.SelectedIndex = 0 Then
            msgInfo("Sales harus dipilih")
            cmbSales.Focus()
        Else
            Dim totalPaid = lblJumlahSetelahPotongan.Text.ToString.Replace(".", "").Replace(",", "")
            Dim KomisiSales = Val(lbl_disc_amount.Text.ToString.Replace(".", "").Replace(",", ""))
            Dim salesID = cmbSales.Text.ToString.Split("-")

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                If PK = "" Then
                    sql = " insert into  trsalespaymentbydate(KdSalesPayment, " & _
                          " TanggalPayment, DariTanggal, SampaiTanggal, " & _
                          " KdSales, TotalSalesPayment, " & _
                          " StatusSalesPayment, Note, UserID, " & _
                          " flag_payment, DiscPembayaran, komisi_sales) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" & dtp_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(salesID(0)) & "', '" & Trim(totalPaid) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "','" & kdKaryawan & "', '1', " & _
                          " '" & txtDiscPembayaran.Text & "', '" & KomisiSales & "') "
                    execute_update_manual(sql)
                Else
                    sql = " update trsalespaymentbydate set " & _
                          " TanggalPayment = '" & dtp_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " DariTanggal = '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " SampaiTanggal = '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdSales = '" & Trim(salesID(0)) & "'," & _
                          " TotalSalesPayment = '" & Trim(totalPaid) & "', " & _
                          " Note = '" & Trim(txtNote.Text) & "', " & _
                          " StatusSalesPayment = '" & flag & "', " & _
                          " UserID = '" & kdKaryawan & "', " & _
                          " flag_payment = '1', " & _
                          " DiscPembayaran = '" & txtDiscPembayaran.Text & "', " & _
                          " komisi_sales = '" & KomisiSales & "' " & _
                          " where  KdSalesPayment = '" & txtID.Text & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual(" delete from trsalespaymentbydatedetail " & _
                                      " where  kdSalesPayment = '" & txtID.Text & "'")
                SavePaymentDetail(flag)

                trans.Commit()
                msgInfo("Data berhasil disimpan")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                msgWarning("Data tidak valid")
            End Try
            dbconmanual.Close()
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save(0)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            Dim TotalKomisi = 0
            Dim TotalBayarLangsung = 0
            Dim total_jumlah = lbl_disc_amount.Text.ToString.Replace(".", "").Replace(",", "")
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells("clmJumlah").Value.ToString.Replace(".", "").Replace(",", "")
                    Dim paid_status = gridBarang.Rows.Item(i).Cells("clmLangsungBayar").Value.ToString
                    If gridBarang.Rows.Item(i).Cells("clmLangsungBayar").Value = "Tidak" Then
                        Grandtotal = Val(Grandtotal) + Val(total)
                    End If
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            Dim total_komisi_sales = Val(Grandtotal * (komisi_sales / 100))
            txtTotalKomisSales.Text = FormatNumber(total_komisi_sales, 0)
            Dim DiscPembayaran = (Grandtotal - total_komisi_sales) * (Val(txtDiscPembayaran.Text) / 100)
            lblDiscPembayaran.Text = FormatNumber(DiscPembayaran, 0)
            lblJumlahSetelahKomisi.Text = FormatNumber(Grandtotal - total_komisi_sales, 0)
            lblJumlahSetelahPotongan.Text = FormatNumber((Grandtotal - total_komisi_sales - DiscPembayaran) - total_jumlah, 0)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub txtPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub browseSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseSales.Click
        Try
            data_carier(0) = "payment"
            sub_form = New FormBrowseSales
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbSales.Text = data_carier(0) & " - " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbSales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSales.SelectedIndexChanged
        Dim salesID = cmbSales.Text.ToString.Split("-")
        Dim sql_query = " select Komisi " & _
                        " from mssales " & _
                        " where KdSales = '" & Trim(salesID(0)) & "' "
        Dim reader = execute_reader(sql_query)
        komisi_sales = 0
        If reader.Read Then
            lblKomisiName.Text = "Komisi Sales " & reader("Komisi") & "%"
            komisi_sales = reader("Komisi")
        Else
            lblKomisiName.Text = "Komisi Sales 0%"
        End If
        reader.close()
        getFaktur()
    End Sub

    Function getFaktur()
        Try
            Dim salesID = cmbSales.Text.ToString.Split("-")
            Dim sql_query = ""
            If PK <> "" Then

                sql_query &= " select faktur.KdFaktur,DATE_FORMAT(TanggalFaktur, '%m/%d/%Y') Tanggal, " & _
                            " faktur.KdSO, MT.KdToko, NamaToko, " & _
                            " GrandTotal, KomisiPersen, TotalKomisiSales, " & _
                            " IfNull(PaidBy,0) PaidBy, faktur.Disc disc_faktur, " & _
                            " Jumlah " & _
                            " from trfaktur faktur " & _
                            " Join MsSales MS On MS.KdSales = faktur.KdSales " & _
                            " JOIN MsToko MT ON MT.KdToko = faktur.KdToko " & _
                            " JOIN trsalespaymentbydatedetail pd ON pd.KdFaktur = faktur.KdFaktur " & _
                            " JOIN trsalespaymentbydate payment ON pd.KdSalesPayment = payment.KdSalesPayment " & _
                            " Where faktur.KdSales = '" & Trim(salesID(0)) & "' " & _
                            " And payment.kdSalesPayment = '" & PK & "' " & _
                            " And DATE_FORMAT(DariTanggal, '%Y/%m/%d') >= '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                            " And DATE_FORMAT(SampaiTanggal, '%Y/%m/%d') <= '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql_query &= " select faktur.KdFaktur,DATE_FORMAT(TanggalFaktur, '%m/%d/%Y') Tanggal, " & _
                            " faktur.KdSO, MT.KdToko, NamaToko, " & _
                            " GrandTotal, KomisiPersen, TotalKomisiSales, " & _
                            " IfNull(PaidBy,0) PaidBy, faktur.Disc disc_faktur, " & _
                            " Jumlah " & _
                            " from trfaktur faktur " & _
                            " Join MsSales MS On MS.KdSales = faktur.KdSales " & _
                            " JOIN MsToko MT ON MT.KdToko = faktur.KdToko " & _
                            " LEFT JOIN trsalespayment payment ON payment.KdFaktur = faktur.KdFaktur " & _
                            " Where faktur.KdSales = '" & Trim(salesID(0)) & "' " & _
                            " And DATE_FORMAT(TanggalFaktur, '%Y/%m/%d') >= '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                            " And DATE_FORMAT(TanggalFaktur, '%Y/%m/%d') <= '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                            " And ( IfNull(PaidBy,0) = 0 Or IfNull(PaidBy,0) = 2 )" & _
                            " And statusfaktur <> 0 " & _
                            " -- And StatusPayment <> 1 " & _
                            " And Not Exists ( " & _
                            "   Select 1 from trsalespaymentbydatedetail " & _
                            "   Where KdFaktur = faktur.KdFaktur " & _
                            " ) "
            End If
            Dim reader = execute_reader(sql_query)
            Dim total_disc = 0
            Dim total_jumlah = 0

            gridBarang.Rows.Clear()
            Do While reader.Read
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmFaktur").Value = reader("KdFaktur")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmTanggal").Value = reader("Tanggal")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSO").Value = reader("KdSO")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmToko").Value = reader("NamaToko")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmJumlah").Value = reader("Jumlah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("disc_faktur")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmGrandtotal").Value = FormatNumber(reader("Grandtotal"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKomisiPersen").Value = reader("KomisiPersen")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmTotalKomisi").Value = FormatNumber(reader("TotalKomisiSales"), 0)
                If reader("PaidBy") = 0 Then
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmLangsungBayar").Value = "Tidak"
                    'If Val(reader("disc_faktur")) <> 0 Then
                    '    total_disc = (komisi_sales - reader("disc_faktur"))
                    '    total_jumlah += (reader("Jumlah") * (total_disc / 100))
                    'End If
                Else
                    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmLangsungBayar").Value = "Ya"
                    total_disc = (komisi_sales - reader("disc_faktur"))
                    total_jumlah += (reader("Jumlah") * (total_disc / 100))
                End If
            Loop
            reader.Close()
            lbl_disc_amount.Text = FormatNumber(total_jumlah, 0)

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try
        Return True
    End Function

    Private Sub dtp_dari_tgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_dari_tgl.ValueChanged
        getFaktur()
    End Sub

    Private Sub dtp_sampai_tgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_sampai_tgl.ValueChanged
        getFaktur()
    End Sub

    

    Private Sub createTabTemp()
        Try
            Dim sql As String
            sql = " create Table v_salespayment_bydate (" & _
                " id int(11) NOT NULL auto_increment primary key,  " & _
                " KdFaktur varchar(50) NULL , " & _
                " TglFaktur varchar(50) NULL , " & _
                " KdSO varchar(50) NULL , " & _
                " NamaToko varchar(100) NULL , " & _
                " Jumlah double NULL , " & _
                " Disc double NULL , " & _
                " TotalFaktur double NULL , " & _
                " Pembayaran varchar(20) NULL " & _
                " )"
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub dropTableTemp()
        Try
            Dim sql As String
            sql = "drop table v_salespayment_bydate "
            execute_update(sql)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub BtnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BtnPrint.Click
        If PK <> "" Then
            dropTableTemp()
            createTabTemp()
            For i As Integer = 0 To gridBarang.RowCount - 1
                Dim nofaktur = gridBarang.Rows.Item(i).Cells("clmFaktur").Value.ToString
                Dim tglfaktur = gridBarang.Rows.Item(i).Cells("clmTanggal").Value.ToString
                Dim noSO = gridBarang.Rows.Item(i).Cells("clmSO").Value.ToString
                Dim toko = gridBarang.Rows.Item(i).Cells("clmToko").Value.ToString
                Dim jumlah = CDbl(gridBarang.Rows.Item(i).Cells("clmJumlah").Value)
                Dim diskon = CDbl(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
                Dim grand = CDbl(gridBarang.Rows.Item(i).Cells("clmGrandtotal").Value)
                Dim lsg = gridBarang.Rows.Item(i).Cells("clmLangsungBayar").Value
                sql = "insert into  v_salespayment_bydate(KdFaktur,TglFaktur,KdSO,NamaToko,Jumlah,Disc,TotalFaktur,Pembayaran)  values " & _
                " ('" & nofaktur & "','" & tglfaktur & "','" & noSO & "','" & toko & "'," & jumlah & "," & diskon & "," & grand & ",'" & lsg & "')"
                execute_update(sql)
            Next
            flagLaporan = "lap_salespayment_bydate"

            sql = "select komisi_sales from trsalespaymentbydate where KdSalesPayment='" & PK & "'"
            Dim reader = execute_reader(sql)
            If reader.Read Then
                komisiSalesSalesPayment = reader(0)
            Else
                komisiSalesSalesPayment = 0
            End If
            reader.close()

            Dim salesID = cmbSales.Text.ToString.Split("-")


            tglMulai = String.Format("{0:yyyy-MM-dd}", dtp_dari_tgl.Value)
            tglAkhir = String.Format("{0:yyyy-MM-dd}", dtp_sampai_tgl.Value)
            tglPayment = String.Format("{0:yyyy-MM-dd}", dtp_tgl.Value)
            salesPayment = salesID(1)
            catatanPayment = txtNote.Text

            kdSalesPayment = PK
            grandTotalSalesPayment = CDbl(lblGrandtotal.Text)
            totalKomisiSalesSalesPayment = CDbl(txtTotalKomisSales.Text)
            jumlahSetelahKomisiSalesPayment = CDbl(lblJumlahSetelahKomisi.Text)
            jumlahSetelahPotonganSalesPayment = CDbl(lblJumlahSetelahPotongan.Text)
            discAmountSalesPayment = CDbl(lbl_disc_amount.Text)
            open_subpage("CRLaporan")
        End If
    End Sub

    Private Sub txtDiscPembayaran_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtDiscPembayaran.TextChanged
        Dim jumlahSetelahKomisi = Val(lblJumlahSetelahKomisi.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim potongan = Val(lbl_disc_amount.Text.ToString.Replace(".", "").Replace(",", ""))
        If IsNumeric(txtDiscPembayaran.Text) Then
            Dim DiscPembayaran = Val(jumlahSetelahKomisi) * (Val(txtDiscPembayaran.Text) / 100)
            lblDiscPembayaran.Text = FormatNumber(DiscPembayaran, 0)
            lblJumlahSetelahPotongan.Text = FormatNumber(jumlahSetelahKomisi - DiscPembayaran - potongan, 0)
        Else
            txtDiscPembayaran.Text = 0
            lblDiscPembayaran.Text = 0
            MsgBox("Disc harus berupa angka")
        End If
    End Sub
End Class
