Imports System.Data.SqlClient
Public Class FormSOPendingManagamen
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim tempDisc = 0
    Dim tempHargaDisc = 0
    Dim tempHarga = 0
    Dim type_so = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpSO.Text = Now()
        cmbSales.SelectedIndex = 0
        cmbToko.SelectedIndex = 0
        lblDaerah.Text = ""
    End Sub

    'FlagStatus : StatusSO,Stock
    Function check_stock(ByVal KdBarang As String, ByVal addQty As String, ByVal FlagStatus As String)
        Dim sql_stock = ""
        If type_so = "klem" Then
            sql_stock = " Select sum(Qty) As Stock From MsBarangList " & _
                        " Where KdBarang = '" & KdBarang & "' " & _
                        " And StatusBarangList = 0 " & _
                        " Group By KdBarang "
        Else
            sql_stock = " Select sum(Qty) As Stock From msbahanmentahlist " & _
                        " Where KdBahanMentah = '" & KdBarang & "' " & _
                        " And StatusBahanMentahList = 0 " & _
                        " Group By KdBahanMentah "
        End If
        Dim readerStock = execute_reader(sql_stock)
        If readerStock.read Then
            If FlagStatus = "StatusSO" And (Val(readerStock(0)) < Val(addQty)) Then
                readerStock.close()
                Return "Pending"
            ElseIf FlagStatus = "Stock" Then
                Dim readyStock = Val(readerStock(0))
                If Val(readerStock(0)) < 0 Then
                    readyStock = 0
                End If
                Return Val(readyStock)
            End If
        Else
            If FlagStatus = "StatusSO" And (0 < Val(addQty)) Then
                readerStock.close()
                Return "Pending"
            ElseIf FlagStatus = "Stock" Then
                Return 0
            End If
        End If
        readerStock.close()
        Return "Ready"
    End Function

    Function getSO(Optional ByVal KdSO As String = "")
        Dim sql As String = "Select * from TrSalesOrder order by KdSO desc "

        If KdSO <> "" Then
            sql &= "KdSO = '" & KdSO & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim Sales = ""
            Dim Toko = ""
            Dim readerSO = execute_reader(" select KdSO,DATE_FORMAT(TanggalSO, '%m/%d/%Y') Tanggal, " & _
                            " MS.KdSales, NamaSales, SO.Disc, " & _
                            " MT.KdToko, NamaToko, MT.Daerah, StatusSO " & _
                            " from TrSalesOrder SO " & _
                            " Join MsSales MS On MS.KdSales = SO.KdSales " & _
                            " Join MsToko MT On MT.KdToko = SO.KdToko " & _
                            " Where KdSO = '" & PK & "' ")
            If readerSO.Read Then
                txtID.Text = readerSO.Item("KdSO")
                dtpSO.Text = readerSO.Item("Tanggal")
                lblDaerah.Text = readerSO.Item("Daerah")
                Sales = readerSO.Item("KdSales") & " - " & readerSO.Item("NamaSales")
                Toko = readerSO.Item("KdToko") & " - " & readerSO.Item("NamaToko")
                If readerSO.Item("StatusSO") <> 0 And readerSO.Item("StatusSO") <> 1 Then
                    btnSave.Enabled = False
                End If
                txt_disc_faktur.Text = readerSO.Item("Disc")
            End If
            readerSO.Close()
            cmbSales.Text = Sales
            cmbToko.Text = Toko

            Dim sql_so = ""

            If type_so = "klem" Then
                sql_so = " Select MB.KdBarang,NamaBarang, " & _
                         " Harga,sum(Qty) Qty,SO.Disc, " & _
                         " ifnull(( Select sum(Qty) - IfNull(( Select sum(Qty) from TrSalesOrderDetail " & _
                         " Join TrSalesOrder On TrSalesOrderDetail.kdso = TrSalesOrder.kdso " & _
                         " Where KdBarang = MsBarangList.KdBarang " & _
                         " And StatusSo = 3 " & _
                         " And TrSalesOrder.KdSO <> '" & PK & "' " & _
                         " Group By KdBarang ),0) As Stock From MsBarangList " & _
                         " Where KdBarang = SO.KdBarang " & _
                         " And StatusBarangList = 0 " & _
                         " Group By KdBarang ),0) Stock, SO.StatusBarang,merk, " & _
                         " HargaDisc " & _
                         " from TrSalesOrderDetail SO " & _
                         " Join MsBarang MB On SO.KdBarang = MB.KdBarang " & _
                         " Join MsMerk On MsMerk.kdmerk = MB.kdMerk " & _
                         " where KdSO = '" & PK & "' " & _
                         " And StatusBarang <> 1 " & _
                         " GROUP BY MB.KdBarang " & _
                         " order by NamaBarang asc "
            Else
                sql_so = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                         " Harga,sum(Qty) Qty,Disc, " & _
                         " ifnull(( Select sum(Qty) - IfNull(( Select sum(Qty) from TrSalesOrderDetail " & _
                         " Join TrSalesOrder On TrSalesOrderDetail.kdso = TrSalesOrder.kdso " & _
                         " Where KdBarang = msbahanmentahlist.KdBahanMentah " & _
                         " And StatusSo = 3 " & _
                         " And TrSalesOrder.KdSO <> '" & PK & "' " & _
                         " Group By KdBarang ),0) As Stock From msbahanmentahlist " & _
                         " Where KdBahanMentah = SO.KdBarang " & _
                         " And StatusBahanMentahList = 0 " & _
                         " Group By KdBahanMentah ),0) Stock, SO.StatusBarang,'N/A' merk, " & _
                         " HargaDisc " & _
                         " from TrSalesOrderDetail SO " & _
                         " Join msbahanmentah MBM On SO.KdBarang = MBM.KdBahanMentah " & _
                         " where KdSO = '" & PK & "' " & _
                         " And StatusBarang <> 1 " & _
                         " GROUP BY MBM.KdBahanMentah " & _
                         " order by NamaBahanMentah asc "
            End If
            Dim reader = execute_reader(sql_so)

            Do While reader.Read
                Dim HargaDisc = reader("HargaDisc")
                Dim Subtotal = Val(HargaDisc) * Val(reader("Qty"))
                Dim StatusBarang = "Ready"

                If Val(reader("Qty")) > Val(reader("Stock")) Then
                    StatusBarang = "Pending"
                End If

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaJual").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(HargaDisc, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = Math.Round(reader("Disc"), 2)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStock").Value = reader("Stock")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyOri").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = StatusBarang
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
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

    Public Sub setCmbSales()
        Dim varT As String = ""
        cmbSales.Items.Clear()
        cmbSales.Items.Add("- Pilih Sales -")
        Dim reader = execute_reader("Select * from MsSales  where NamaSales <>'' order by NamaSales asc")
        Do While reader.Read
            cmbSales.Items.Add(reader(0) & " - " & reader(1))
        Loop
        reader.Close()
        If cmbSales.Items.Count > 0 Then
            cmbSales.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Public Sub setCmbToko()
        Dim varT As String = ""
        cmbToko.Items.Clear()
        cmbToko.Items.Add("- Pilih Toko -")
        sql = " Select * from MsToko" & _
              " where NamaToko <>'' order by NamaToko asc "
        Dim readerToko = execute_reader(sql)
        Do While readerToko.Read
            cmbToko.Items.Add(readerToko(0) & " - " & readerToko(1))
        Loop
        readerToko.Close()
        If cmbToko.Items.Count > 0 Then
            cmbToko.SelectedIndex = 0
        End If
        readerToko.Close()
    End Sub

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        type_so = data_carier(2)

        If type_so = "klem" Then
            Me.Text = "Penjualan Klem Jadi Tertunda"
        Else
            Me.Text = "Penjualan Paku Tertunda"
        End If

        clear_variable_array()
        setCmbSales()
        setCmbToko()
        emptyField()

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbSales.Focus()
    End Sub

    Private Sub generateCode()
        Dim code As String = "SO"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String

        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, ".dd.MM.yy")
        'code += FormatDate

        Dim reader = getSO()

        If reader.read Then
            kode = Trim(reader(0).ToString())
            temp = kode.Substring(0, 8)
            If temp = code Then
                angka = CInt(kode.Substring(8, 4))
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

    Function SaveSODetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusSO = 0 + Val(flag)

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells("clmHargaJual").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim Disc = Val(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
            Dim OP = "Min"
            Dim Attribute = "QtySO_Min"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim hargaDisc = gridBarang.Rows.Item(i).Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", "")

            If gridBarang.Rows.Item(i).Cells("clmStatus").Value = "Ready" Then
                statusDetail = 0

                sqlDetail = "insert into TrSalesOrderDetail(KdSO,KdBarang, Harga, " _
                           & " Qty, Disc,StatusBarang,HargaDisc) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                           & " '" & harga & "', '" & Qty & "', " _
                           & " '" & Disc & "',  " & _
                             " '" & statusDetail & "', '" & hargaDisc & "')"
                execute_update_manual(sqlDetail)
            ElseIf gridBarang.Rows.Item(i).Cells("clmStatus").Value = "Pending" Then
                statusDetail = 1
                statusSO = 1 + Val(flag)

                sqlDetail = "insert into TrSalesOrderDetailPending(KdSO,KdBarang, Harga, " _
                           & " Qty, Disc,StatusBarang,HargaDisc) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                           & " '" & harga & "', '" & Qty & "', " _
                           & " '" & Disc & "', " & _
                             " '" & statusDetail & "', '" & hargaDisc & "')"
                execute_update_manual(sqlDetail)
            End If
            'End If
        Next

        If flag = 3 And statusSO = 4 Then
            msgInfo("SO tidak dapat di confirm karena salah satu produk masih pending.")
        Else
            Dim sqlHeader = " Update TrSalesOrder set StatusSO = '" & statusSO & "' " & _
                    " Where KdSO = '" & Trim(txtID.Text) & "' "
            execute_update_manual(sqlHeader)
        End If

        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbSales.SelectedIndex = 0 Then
            msgInfo("Sales harus dipilih")
            cmbSales.Focus()
        ElseIf cmbToko.SelectedIndex = 0 Then
            msgInfo("Toko harus dipilih")
            cmbToko.Focus()
        Else
            Dim salesID = cmbSales.Text.ToString.Split("-")
            Dim tokoID = cmbToko.Text.ToString.Split("-")
            Dim Grandtotal = ""

            If (lblGrandtotal.Text <> "") Then
                Grandtotal = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")
            End If

            Dim ReaderGrandDetail = execute_reader(" Select IfNull(sum(HargaDisc * Qty),0) from TrSalesOrderDetail " & _
                                     " Where KdSO = '" & txtID.Text & "' " & _
                                     " And StatusBarang <> 1 ")

            If ReaderGrandDetail.read Then
                Grandtotal += Math.Round(ReaderGrandDetail(0) * 1, 2)
            End If
            ReaderGrandDetail.close()

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                If status = "add" Then
                    sql = " insert into  TrSalesOrder ( " & _
                          " KdSO, TanggalSO, KdSales, KdToko, GrandTotal, StatusSO, " & _
                          " UserID, KomisiSales, jenis_so ) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" + dtpSO.Value.ToString("yyyy/MM/dd HH:mm:ss") + "', " & _
                          " '" & Trim(salesID(0)) & "', '" & Trim(tokoID(0)) & "'," & _
                          " '" & Trim(Grandtotal) & "', '" & flag & "','" & kdKaryawan & "', " & _
                          " '" & txtKomisiSales.Text & "', '" & type_so & "' )"

                    execute_update_manual(sql)
                ElseIf status = "update" Then
                    Try
                        sql = "update   TrSalesOrder  set  TanggalSO='" & dtpSO.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                        " KdSales = '" & Trim(salesID(0)) & "'," & _
                        " KdToko = '" & Trim(tokoID(0)) & "'," & _
                        " GrandTotal = '" & Trim(Grandtotal) & "', " & _
                        " UserID = '" & Trim(kdKaryawan) & "', " & _
                        " KomisiSales = '" & Trim(txtKomisiSales.Text) & "', " & _
                        " jenis_so = '" & type_so & "' " & _
                        " where  KdSO = '" + txtID.Text + "' "
                        execute_update_manual(sql)
                    Catch ex As Exception
                        msgWarning(" Data tidak valid")
                        cmbSales.SelectedIndex = 0
                    End Try
                End If

                execute_update_manual(" delete from TrSalesOrderDetailPending " & _
                                      " where  KdSO = '" & txtID.Text & "' " & _
                                      " And statusBarang = 1 ")
                Dim statusSO = SaveSODetail(flag)

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
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
                lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
                calc_disc_faktur()
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbSales_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSales.SelectedIndexChanged
        If cmbSales.SelectedIndex <> 0 Then
            Dim salesID = cmbSales.Text.ToString.Split("-")

            sql = " Select Komisi from MsSales " & _
                  " where KdSales = '" & Trim(salesID(0)) & "' "
            Dim reader = execute_reader(sql)

            If reader.Read Then
                txtKomisiSales.Text = reader("Komisi")
            End If
            reader.Close()
        Else
            txtKomisiSales.Text = 0
        End If
    End Sub

    Private Sub cmbToko_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbToko.SelectedIndexChanged
        If cmbToko.SelectedIndex <> 0 Then
            Dim tokoID = cmbToko.Text.ToString.Split("-")

            sql = " Select Daerah from MsToko " & _
                  " where KdToko = '" & Trim(tokoID(0)) & "' "
            Dim reader = execute_reader(sql)

            If reader.Read Then
                lblDaerah.Text = reader(0)
            End If
            reader.Close()
        Else
            lblDaerah.Text = ""
        End If
    End Sub

    Private Sub gridBarang_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gridBarang.CellBeginEdit
        tempDisc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
        tempDisc = Math.Round(tempDisc, 2)
        tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
        tempHarga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.Replace(".", "").Replace(",", ""))
    End Sub

    Private Sub gridBarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellClick
        tempDisc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
        tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
        tempHarga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.Replace(".", "").Replace(",", ""))
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim BarangID = gridBarang.CurrentRow.Cells("clmPartNo").Value
            Dim harga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.Replace(".", "").Replace(",", ""))
            Dim hargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
            Dim stok = Val(gridBarang.CurrentRow.Cells("clmStock").Value)

            If IsNumeric(qty) = False Or qty < 1 Then
                MsgBox("Jumlah harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                qty = 1
                gridBarang.CurrentRow.Cells("clmQty").Value = 1
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf IsNumeric(harga) = False Or harga < 1 Then
                MsgBox("Harga harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                harga = 1
                gridBarang.CurrentRow.Cells("clmHargaJual").Value = 1
                gridBarang.CurrentRow.Cells("clmHargaJual").Selected = True
            ElseIf IsNumeric(hargaDisc) = False Or hargaDisc < 1 Then
                MsgBox("Harga Disc harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                hargaDisc = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Selected = True
            ElseIf IsNumeric(disc) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                disc = 0
                gridBarang.CurrentRow.Cells("clmDisc").Value = 0
                gridBarang.CurrentRow.Cells("clmDisc").Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                Dim TempHargaDisc = FormatNumber(hargaDisc, 0)
                gridBarang.CurrentRow.Cells("clmHargaJual").Value = TempHarga
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = TempHargaDisc
            End If

            If hargaDisc <> tempHargaDisc Or harga <> tempHarga Then
                Dim calcDisc = 100 - ((hargaDisc / harga) * 100)
                gridBarang.CurrentRow.Cells("clmDisc").Value = Math.Round(calcDisc, 2)
            ElseIf disc <> tempDisc Then
                Dim discProses = 100 - Val(disc)
                Dim calcHargaJual = harga * (discProses / 100)
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = FormatNumber(calcHargaJual, 0)
            End If

            gridBarang.CurrentRow.Cells("clmSubtotal").Value = FormatNumber(Val(hargaDisc) * Val(qty), 0)
            gridBarang.CurrentRow.Cells("clmStatus").Value = check_stock(BarangID, qty, "StatusSO")

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(3)
    End Sub

    Private Sub browseSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseSales.Click
        Try
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

    Private Sub browseToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseToko.Click
        Try
            sub_form = New FormBrowseToko
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbToko.Text = data_carier(0) & " - " & data_carier(1)
                lblDaerah.Text = data_carier(2)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Function calc_disc_faktur()
        Dim disc = txt_disc_faktur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub txt_disc_faktur_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_disc_faktur.TextChanged
        If IsNumeric(txt_disc_faktur.Text) Then
            calc_disc_faktur()
        Else
            MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
            txt_disc_faktur.Text = 0
            txt_disc_faktur.Focus()
        End If
    End Sub
End Class
