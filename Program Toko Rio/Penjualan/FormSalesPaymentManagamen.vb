Imports System.Data.SqlClient
Public Class FormSalesPaymentManagamen
    Dim tipe_pembayaran As String
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""
    Dim type_payment = ""
    Dim komisi_sales = 0

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpPayment.Text = Now()
        cmbFaktur.SelectedIndex = 0
        txtSales.Text = ""
        txtToko.Text = ""
        lblDaerah.Text = ""
        'cmbBayar.SelectedIndex = 0
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
            Dim readerPayment = execute_reader(" select KdSalesPayment,DATE_FORMAT(TanggalSalesPayment, '%m/%d/%Y') Tanggal, " & _
                                               " kdFaktur, MS.KdSales, NamaSales, disc_payment, " & _
                                               " MT.KdToko, NamaToko, MT.Daerah,StatusSalesPayment, " & _
                                               " Note, TotalSalesPayment,PaidBy from trSalesPayment payment " & _
                                               " Join MsSales MS On MS.KdSales = payment.KdSales " & _
                                               " Join MsToko MT On MT.KdToko = payment.KdToko " & _
                                               " Where kdSalesPayment = '" & PK & "' ")

            If readerPayment.Read Then
                txtID.Text = readerPayment.Item("KdSalesPayment")
                dtpPayment.Text = readerPayment.Item("Tanggal")
                lblDaerah.Text = readerPayment.Item("Daerah")
                kdFaktur = readerPayment.Item("kdFaktur")
                kdsales = readerPayment.Item("KdSales")
                txtSales.Text = readerPayment.Item("NamaSales")
                kdtoko = readerPayment.Item("KdToko")
                txtToko.Text = readerPayment.Item("NamaToko")
                txt_disc_payment.Text = readerPayment.Item("disc_payment")
                If readerPayment.Item("StatusSalesPayment") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                txtNote.Text = readerPayment.Item("Note")
                txtPaid.Text = FormatNumber(readerPayment.Item("TotalSalesPayment"), 0)
                'cmbBayar.Text = readerPayment.Item("PaidBy")
            End If
            readerPayment.Close()
            cmbFaktur.Text = kdFaktur

            Dim sql_pembayaran = ""
            If type_payment = "klem" Then
                sql_pembayaran = " Select MB.KdBarang,NamaBarang, " & _
                                " HargaDisc, Harga, Qty, Disc,StatusBarang, Merk " & _
                                " from TrsalesPaymentDetail payment " & _
                                " Join MsBarang MB On payment.KdBarang = MB.KdBarang " & _
                                " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                                " where kdsalesPayment = '" & PK & "' " & _
                                " order by NamaBarang asc "
            Else
                sql_pembayaran = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                                " HargaDisc, Harga, Qty, Disc,StatusBarang, 'N/A' Merk " & _
                                " from TrsalesPaymentDetail payment " & _
                                " Join msbahanmentah MBM On payment.KdBarang = MBM.KdBahanMentah " & _
                                " where kdsalesPayment = '" & PK & "' " & _
                                " order by NamaBahanMentah asc "
            End If

            Dim reader = execute_reader(sql_pembayaran)

            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim Subtotal = Val(reader("HargaDisc")) * Val(reader("Qty"))

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
            Loop
            reader.Close()

            HitungTotal()
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

    Public Sub setCmbSO()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbFaktur.Items.Clear()
        cmbFaktur.Items.Add("- Pilih Faktur -")
        If PK <> "" Then
            addQuery = " And exists( " & _
                       " Select 1 from trsalesPayment " & _
                       " where kdsalesPayment = '" & PK & "' " & _
                       " And trsalesPayment.kdFaktur = trfaktur.kdFaktur ) "
            cmbFaktur.Enabled = False
            BrowseFaktur.Enabled = False
        Else
            addQuery = " And statusfaktur <> 0 " & _
                       " And StatusPayment <> 1 " & _
                       " And NOT EXISTS( " & _
                       "    Select 1 from trreturdetail trd " & _
                       "    Join trretur tr On tr.KdRetur = trd.KdRetur " & _
                       "    where tr.KdFaktur = trfaktur.KdFaktur " & _
                       "    And tfd.KdBarang = trd.KdBarang " & _
                       "    GROUP BY trd.KdBarang " & _
                       "    HAVING tfd.Qty - SUM(trd.Qty) < 1 " & _
                       " ) "
        End If

        Dim reader = execute_reader(" Select trfaktur.KdFaktur, " & _
                                    " (( 100 - trfaktur.disc ) / 100 ) * SUM( ( " & _
                                    "   tfd.Qty - IfNull(( " & _
                                    "     SELECT trd.Qty FROM trreturdetail trd " & _
                                    "     JOIN trretur tr ON tr.KdRetur = trd.KdRetur " & _
                                    "     WHERE tr.KdFaktur = tfd.KdFaktur " & _
                                    "     AND trd.KdBarang = tfd.KdBarang " & _
                                    "     GROUP BY trd.KdBarang " & _
                                    "   ), 0) ) * tfd.HargaDisc " & _
                                    " ) TotalFaktur, " & _
                                    " IfNull(( " & _
                                    "     SELECT SUM(tsp.TotalSalesPayment) FROM trsalespayment tsp " & _
                                    "     WHERE tsp.KdFaktur = tfd.KdFaktur " & _
                                    "     AND tsp.kdsalesPayment <> '" & PK & "' " & _
                                    "     GROUP BY tsp.KdFaktur " & _
                                    " ), 0) TotalPayment " & _
                                    " from trfaktur " & _
                                    " Join trfakturdetail tfd On tfd.KdFaktur = trfaktur.KdFaktur " & _
                                    " Join msuser On msuser.UserID = trfaktur.UserID " & _
                                    " where 1 " & _
                                    " And jenis_faktur = '" & type_payment & "' " & _
                                    addQuery & _
                                    " GROUP BY trfaktur.kdFaktur " & _
                                    " HAVING ( TotalFaktur - TotalPayment ) > 0 " & _
                                    " Order By no_increment Desc, StatusFaktur asc ")
        Do While reader.Read
            cmbFaktur.Items.Add(reader("KdFaktur"))
        Loop
        reader.Close()
        If cmbFaktur.Items.Count > 0 Then
            cmbFaktur.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        type_payment = data_carier(2)
        clear_variable_array()
        setCmbSO()
        emptyField()

        If type_payment = "klem" Then
            Me.Text = "Pembayaran Klem Jadi"
        Else
            Me.Text = "Pembayaran Paku"
        End If

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbFaktur.Focus()
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
            Dim harga = gridBarang.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim hargaDisc = gridBarang.Rows.Item(i).Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim disc = Val(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim StatusBarang = gridBarang.Rows.Item(i).Cells("clmStatus").Value

            sqlDetail = "insert into TrSalesPaymentDetail( KdSalesPayment, KdBarang, Harga, " & _
                        " Qty, Disc, StatusBarang, HargaDisc ) values( " & _
                        " '" & Trim(txtID.Text) & "','" & KdBarang & "', " & _
                        " '" & harga & "', '" & Qty & "', " & _
                        " '" & disc & "', '" & StatusBarang & "', " & _
                        " '" & hargaDisc & "' )"
            execute_update_manual(sqlDetail)
        Next

        If flag = 1 Then
            If Val(txtPaid.Text.ToString.Replace(".", "").Replace(",", "")) < Val(lblTotalBayar.Text.ToString.Replace(".", "").Replace(",", "")) Then
                statusFaktur = 2
            End If
            Dim sqlFaktur = " Update TrFaktur set StatusPayment = '" & statusFaktur & "' " & _
                        " Where KdFaktur = '" & Trim(cmbFaktur.Text) & "' "
            execute_update_manual(sqlFaktur)
            Return True
        End If
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbFaktur.SelectedIndex = 0 Then
            msgInfo("Faktur harus dipilih")
            cmbFaktur.Focus()
            'ElseIf cmbBayar.SelectedIndex = 0 Then
            '    msgInfo("Cara Bayar harus dipilih")
            '    cmbBayar.Focus()
        ElseIf txtPaid.Text = "" Then
            msgInfo("Bayar harus diisi")
            txtPaid.Focus()
        ElseIf Val(lblTotalBayar.Text.Replace(".", "").Replace(",", "")) <= 0 And Val(txtPaid.Text.Replace(".", "").Replace(",", "")) <> 0 Then
            msgInfo("Total paid harus 0. Dikarenakan pembayaran SO sudah tidak ada.")
        Else
            Dim totalPaid = txtPaid.Text.ToString.Replace(".", "").Replace(",", "")
            Dim KomisiSales = Val(txtTotalKomisSales.Text.ToString.Replace(".", "").Replace(",", ""))

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                If PK = "" Then
                    sql = " insert into  trSalesPayment(KdSalesPayment, " & _
                          " TanggalSalesPayment, KdSales, KdToko, TotalSalesPayment, " & _
                          " StatusSalesPayment, Note, UserID, PaidBy, KdFaktur, " & _
                          " jenis_payment, disc_payment, komisi_sales ) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" & dtpPayment.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdsales) & "','" & Trim(kdtoko) & "'," & _
                          " '" & Trim(totalPaid) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "','" & kdKaryawan & "', " & _
                          " '" & 2 & "','" & cmbFaktur.Text & "', " & _
                          " '" & type_payment & "', '" & txt_disc_payment.Text & "', " & _
                          " '" & KomisiSales & "' )"
                    execute_update_manual(sql)
                Else
                    sql = " update trSalesPayment set " & _
                          " TanggalSalesPayment = '" & dtpPayment.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdSales = '" & Trim(kdsales) & "'," & _
                          " KdToko = '" & Trim(kdtoko) & "'," & _
                          " TotalSalesPayment = '" & Trim(totalPaid) & "', " & _
                          " Note = '" & Trim(txtNote.Text) & "', " & _
                          " StatusSalesPayment = '" & flag & "', " & _
                          " UserID = '" & kdKaryawan & "', " & _
                          " PaidBy = '" & 2 & "', " & _
                          " KdFaktur = '" & cmbFaktur.Text & "', " & _
                          " jenis_payment = '" & type_payment & "', " & _
                          " disc_payment = '" & txt_disc_payment.Text & "', " & _
                          " komisi_sales = '" & KomisiSales & "' " & _
                          " where  KdSalesPayment = '" & Trim(txtID.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from TrSalesPaymentdetail where  kdSalesPayment = '" & txtID.Text & "'")
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

    Function calc_disc_payment()
        Dim disc = txt_disc_payment.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        lblTotalBayar.Text = FormatNumber(calcJumlah - Val(lblTelahBayar.Text.ToString.Replace(".", "").Replace(",", "")), 0)
        Return True
    End Function

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            calc_disc_payment()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub BrowseFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseFaktur.Click
        Try
            data_carier(0) = PK
            data_carier(1) = "SalesPayment"
            data_carier(2) = type_payment
            sub_form = New FormBrowseFaktur
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbFaktur.Text = data_carier(0)
                'txtSales.Text = data_carier(1)
                'txtToko.Text = data_carier(2)
                'lblDaerah.Text = data_carier(3)
                'kdsales = data_carier(4)
                'kdtoko = data_carier(5)
                clear_variable_array()

                'generateCode()
                'txtID.Text &= "/" & kdsales

                'Dim addQuery = ""
                'If PK <> "" Then
                '    addQuery = " And Trfaktur.KdFaktur <> '" & cmbFaktur.Text & "' "
                'End If

                'Dim sql_pembayaran = ""
                'If type_payment = "klem" Then
                '    sql_pembayaran = " Select MB.KdBarang,NamaBarang, " & _
                '                    " HargaDisc, Harga, sum(Qty - ifnull(( Select sum(Qty) " & _
                '                    " from TrReturDetail " & _
                '                    " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                    " where KdBarang = faktur.KdBarang " & _
                '                    " And KdFaktur = Trfaktur.KdFaktur " & _
                '                    " Group By KdFaktur,KdBarang ),0)) Qty, " & _
                '                    " Disc, ifnull(( Select 'Retur' " & _
                '                    " from TrReturDetail " & _
                '                    " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                    " where KdBarang = faktur.KdBarang " & _
                '                    " And KdFaktur = Trfaktur.KdFaktur " & _
                '                    " Group By KdFaktur,KdBarang ),'Normal') StatusBarang,Merk, " & _
                '                    " IfNull(( Select sum(TotalSalesPayment) from trsalespayment " & _
                '                    " Where KdFaktur = Trfaktur.KdFaktur " & _
                '                    addQuery & " ) ,0) " & _
                '                    " from TrfakturDetail faktur " & _
                '                    " Join Trfaktur On Trfaktur.kdFaktur = faktur.kdFaktur " & _
                '                    " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                '                    " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                '                    " where Trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                '                    " Group by MB.KdBarang,Trfaktur.KdFaktur " & _
                '                    " order by NamaBarang asc "
                'Else
                '    sql_pembayaran = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                '                    " HargaDisc, Harga, sum(Qty - ifnull(( Select sum(Qty) " & _
                '                    " from TrReturDetail " & _
                '                    " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                    " where KdBarang = faktur.KdBarang " & _
                '                    " And KdFaktur = Trfaktur.KdFaktur " & _
                '                    " Group By KdFaktur,KdBarang ),0)) Qty, " & _
                '                    " Disc, ifnull(( Select 'Retur' " & _
                '                    " from TrReturDetail " & _
                '                    " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                    " where KdBarang = faktur.KdBarang " & _
                '                    " And KdFaktur = Trfaktur.KdFaktur " & _
                '                    " Group By KdFaktur,KdBarang ),'Normal') StatusBarang,'N/A' Merk, " & _
                '                    " IfNull(( Select sum(TotalSalesPayment) from trsalespayment " & _
                '                    " Where KdFaktur = Trfaktur.KdFaktur " & _
                '                    addQuery & " ) ,0) " & _
                '                    " from TrfakturDetail faktur " & _
                '                    " Join Trfaktur On Trfaktur.kdFaktur = faktur.kdFaktur " & _
                '                    " Join msbahanmentah MBM On faktur.KdBarang = MBM.KdBahanMentah " & _
                '                    " where Trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                '                    " Group by MBM.KdBahanMentah,Trfaktur.KdFaktur " & _
                '                    " order by NamaBahanMentah asc "
                'End If
                'Dim reader = execute_reader(sql_pembayaran)

                'gridBarang.Rows.Clear()
                'Do While reader.Read
                '    Dim Subtotal = Val(reader("HargaDisc")) * Val(reader("Qty"))

                '    gridBarang.Rows.Add()
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
                'Loop
                'reader.Close()

                'HitungTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbfaktur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFaktur.SelectedIndexChanged
        If cmbFaktur.SelectedIndex <> 0 Then
            Dim addQuery = ""
            If PK <> "" Then
                addQuery = " And KdSalesPayment <> '" & txtID.Text & "' "
            End If

            Dim sql_pembayaran = ""
            If type_payment = "klem" Then
                sql_pembayaran = " Select MB.KdBarang,NamaBarang, " & _
                                " HargaDisc, Harga, sum(Qty) - " & _
                                " ifnull(( " & _
                                "   Select sum(Qty) " & _
                                "   from TrReturDetail " & _
                                "   Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                "   where TrReturDetail.KdBarang = faktur.KdBarang " & _
                                "   AND TrRetur.KdFaktur = trfaktur.KdFaktur " & _
                                "   Group By TrRetur.KdFaktur, TrReturDetail.KdBarang " & _
                                " ),0) Qty, " & _
                                " faktur.Disc, " & _
                                " ifnull(( " & _
                                "   Select 'Retur' " & _
                                "   from TrReturDetail " & _
                                "   Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                "   where TrReturDetail.KdBarang = faktur.KdBarang " & _
                                "   AND TrRetur.KdFaktur = trfaktur.KdFaktur " & _
                                "   Group By TrRetur.KdFaktur, TrReturDetail.KdBarang " & _
                                " ),'Normal') StatusBarang, " & _
                                " MS.KdSales, NamaSales, " & _
                                " MT.KdToko, NamaToko, MT.Daerah, Merk, " & _
                                " IfNull(( " & _
                                "   Select sum(TotalSalesPayment) from trsalespayment " & _
                                "   Where KdFaktur = trfaktur.KdFaktur " & _
                                    addQuery & " " & _
                                " ) ,0) TotalSalesPayment, faktur.KdFaktur, " & _
                                "  trfaktur.Disc disc_faktur, MS.Komisi " & _
                                " from TrFakturDetail faktur " & _
                                " Join trfaktur On faktur.kdfaktur = trfaktur.kdfaktur " & _
                                " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                                " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                                " Join MsSales MS On MS.KdSales = trfaktur.KdSales " & _
                                " Join MsToko MT On MT.KdToko = trfaktur.KdToko " & _
                                " where trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                                " Group by MB.KdBarang,trfaktur.KdFaktur " & _
                                " order by NamaBarang asc "
            Else
                sql_pembayaran = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                                " HargaDisc, Harga, sum(Qty) - " & _
                                " ifnull(( " & _
                                "   Select sum(Qty) " & _
                                "   from TrReturDetail " & _
                                "   Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                "   where TrReturDetail.KdBarang = faktur.KdBarang " & _
                                "   AND TrRetur.KdFaktur = trfaktur.KdFaktur " & _
                                "   Group By TrRetur.KdFaktur, TrReturDetail.KdBarang " & _
                                " ),0) Qty, " & _
                                " faktur.Disc, " & _
                                " ifnull(( " & _
                                "   Select 'Retur' " & _
                                "   from TrReturDetail " & _
                                "   Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                "   where KdBarang = faktur.KdBarang " & _
                                "   AND KdFaktur = trfaktur.KdFaktur " & _
                                "   Group By KdFaktur,KdBarang " & _
                                " ),'Normal') StatusBarang, " & _
                                " MS.KdSales, NamaSales, " & _
                                " MT.KdToko, NamaToko, MT.Daerah, 'N/A' Merk, " & _
                                " IfNull(( " & _
                                "   Select sum(TotalSalesPayment) from trsalespayment " & _
                                "   Where KdFaktur = trfaktur.KdFaktur " & _
                                    addQuery & " " & _
                                " ) ,0) TotalSalesPayment, faktur.KdFaktur, " & _
                                "  trfaktur.Disc disc_faktur, MS.Komisi " & _
                                " from TrFakturDetail faktur " & _
                                " Join trfaktur On faktur.kdfaktur = trfaktur.kdfaktur " & _
                                " Join msbahanmentah MBM On faktur.KdBarang = MBM.KdBahanMentah " & _
                                " Join MsSales MS On MS.KdSales = trfaktur.KdSales " & _
                                " Join MsToko MT On MT.KdToko = trfaktur.KdToko " & _
                                " where trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                                " Group by MBM.KdBahanMentah,trfaktur.KdFaktur " & _
                                " order by NamaBahanMentah asc "
            End If
            Dim reader = execute_reader(sql_pembayaran)
            '" And StatusSalesPayment <> 0 " & _

            Dim idxfaktur = 0
            Dim TotalPaid = Val(txtPaid.Text.ToString.Replace(".", "").Replace(",", ""))
            gridBarang.Rows.Clear()
            Do While reader.Read
                If idxfaktur = 0 Then
                    txtSales.Text = reader("NamaSales")
                    txtToko.Text = reader("NamaToko")
                    lblDaerah.Text = reader("Daerah")
                    kdsales = reader("KdSales")
                    kdtoko = reader("KdToko")
                    lblTelahBayar.Text = FormatNumber(reader("TotalSalesPayment"), 0)
                    txt_disc_payment.Text = reader("disc_faktur")
                    lblKomisiName.Text = "Komisi Sales " & reader("Komisi") & "% ( IDR )"
                    komisi_sales = Val(reader("Komisi"))
                    txtTotalKomisSales.Text = FormatNumber(TotalPaid * (Val(komisi_sales) / 100), 0)
                End If

                Dim Subtotal = Val(reader("HargaDisc")) * Val(reader("Qty"))
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
                idxfaktur += 1
            Loop
            reader.Close()

            generateCode()
            txtID.Text &= "/" & kdsales

            HitungTotal()
        Else
            txtSales.Text = ""
            txtToko.Text = ""
            lblDaerah.Text = ""
            kdsales = ""
            kdtoko = ""
            gridBarang.Rows.Clear()
            generateCode()
            lblKomisiName.Text = "Komisi Sales ( IDR )"
        End If
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub txtPaid_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtPaid.Leave
        If txtPaid.Text <> "" Then
            Dim TotalPaid = Val(txtPaid.Text.ToString.Replace(".", "").Replace(",", ""))
            txtTotalKomisSales.Text = FormatNumber(TotalPaid * (Val(komisi_sales) / 100), 0)
            txtPaid.Text = FormatNumber(txtPaid.Text, 0)
        End If
    End Sub

    Private Sub txtPaid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPaid.TextChanged

    End Sub
End Class
