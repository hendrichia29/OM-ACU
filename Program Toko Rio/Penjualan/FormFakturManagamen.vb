Imports System.Data.SqlClient
Public Class FormFakturManagamen
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""
    Dim jatuhTempo As Integer
    Dim tJatuhTempo As String
    Dim tempDisc = 0
    Dim tempHargaDisc = 0
    Dim tempHarga = 0
    Dim type_faktur As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    'FlagStatus : StatusSO,Stock
    Function check_stock(ByVal KdBarang As String, ByVal addQty As String, ByVal FlagStatus As String)
        Dim sql_stock = ""
        If type_faktur = "klem" Then
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
                If readyStock < 0 Then
                    readyStock = 0
                End If
                Return Val(readyStock)
            End If
        End If
        readerStock.close()
        If FlagStatus = "Stock" Then
            Return 0
        End If
        Return "Ready"
    End Function

    Private Sub emptyField()
        dtpFaktur.Text = Now()
        cmbSO.SelectedIndex = 0
        txtSales.Text = ""
        txtToko.Text = ""
        lblDaerah.Text = ""
    End Sub

    Function getFaktur(Optional ByVal KdFaktur As String = "")
        Dim sql As String = "Select KdFaktur from trfaktur order by no_increment desc "

        If KdFaktur <> "" Then
            sql &= "kdfaktur = '" & KdFaktur & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim Sales = ""
            Dim Toko = ""
            Dim kdso = ""
            Dim totalKomisi = 0
            Dim komisi = 0
            Dim sql_faktur = ""
            Dim readerSO = execute_reader(" select kdfaktur,DATE_FORMAT(Tanggalfaktur, '%m/%d/%Y') Tanggal, " & _
                                        " so.kdso, MS.KdSales, NamaSales, faktur.TotalKomisiSales, faktur.KomisiPersen, " & _
                                        " MT.KdToko, NamaToko, MT.Daerah, StatusFaktur, faktur.Disc disc_faktur " & _
                                        " from trfaktur faktur " & _
                                        " Join TrSalesOrder SO On  SO.kdso = faktur.kdso " & _
                                        " Join MsSales MS On MS.KdSales = SO.KdSales " & _
                                        " Join MsToko MT On MT.KdToko = SO.KdToko " & _
                                        " Where kdfaktur = '" & PK & "' ")
            If readerSO.Read Then
                txtID.Text = readerSO.Item("kdfaktur")
                dtpFaktur.Text = readerSO.Item("Tanggal")
                lblDaerah.Text = readerSO.Item("Daerah")
                kdso = readerSO.Item("kdso")
                txt_disc_faktur.Text = readerSO.Item("disc_faktur")
                Sales = readerSO.Item("KdSales") & " - " & readerSO.Item("NamaSales")
                Toko = readerSO.Item("KdToko") & " - " & readerSO.Item("NamaToko")
                totalKomisi = readerSO.Item("TotalKomisiSales")
                komisi = readerSO.Item("KomisiPersen")
                If readerSO.Item("StatusFaktur") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerSO.Close()
            txtSales.Text = Sales
            txtToko.Text = Toko
            cmbSO.Text = kdso
            txtTotalKomisi.Text = FormatNumber(totalKomisi, 0)
            txtKomisi.Text = FormatNumber(komisi, 0)

            If type_faktur = "klem" Then
                sql_faktur = " Select MB.KdBarang,NamaBarang, " & _
                             " Harga,HargaDisc,Qty,faktur.Disc, " & _
                             " ifnull(( " & _
                             "  Select StockAkhir " & _
                             "  from BarangHistory where isActive = 1 " & _
                             "  And KdBarang = faktur.KdBarang " & _
                             "  order by KdBarangHistory desc limit 1 " & _
                             " ),0) Stock, " & _
                             " faktur.StatusBarang,Merk,KomisiSales " & _
                             " from TrFakturDetail faktur " & _
                             " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                             " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                             " where kdfaktur = '" & PK & "' " & _
                             " order by NamaBarang asc "
            Else
                sql_faktur = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                             " Harga,HargaDisc,Qty,faktur.Disc, " & _
                             " ifnull(( " & _
                             "  Select StockAkhir " & _
                             "  from BarangHistory where isActive = 1 " & _
                             "  And KdBarang = faktur.KdBarang " & _
                             "  order by KdBarangHistory desc limit 1 " & _
                             " ),0) Stock, " & _
                             " faktur.StatusBarang,'N/A' Merk,KomisiSales " & _
                             " from TrFakturDetail faktur " & _
                             " Join msbahanmentah MBM On faktur.KdBarang = MBM.KdBahanMentah " & _
                             " where kdfaktur = '" & PK & "' " & _
                             " order by NamaBahanMentah asc "
            End If
            Dim reader = execute_reader(sql_faktur)

            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim HargaDisc = reader("HargaDisc")
                Dim Subtotal = Val(HargaDisc) * Val(reader("Qty"))
                Dim StatusBarang = "Ready"

                If Val(reader("StatusBarang")) = 1 Then
                    StatusBarang = "Pending"
                End If

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaJual").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(HargaDisc, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStock").Value = reader("Stock")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyOri").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = StatusBarang
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKomisi").Value = reader("KomisiSales")
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
        cmbSO.Items.Clear()
        cmbSO.Items.Add("- Pilih Pemesanan -")

        If PK <> "" Then
            addQuery = " And exists( Select 1 from trfaktur where kdfaktur = '" & PK & "' And trfaktur.kdSO = so.kdso )"
        Else
            addQuery = " And StatusSO = 3 And Not Exists( Select 1 from trfakturdetail " & _
                       " Join trfaktur On trfaktur.KdFaktur = trfakturdetail.KdFaktur " & _
                       " where trfaktur.kdSO = sodetail.kdso " & _
                       " And kdBarang = sodetail.KdBarang " & _
                       " AND qty - sodetail.qty = 0  ) " & _
                       " And StatusBarang = 0 "
        End If
        Dim reader = execute_reader(" Select DISTINCT so.kdso from trsalesorder so " & _
                                    " Join trsalesorderdetail sodetail On sodetail.kdSO = so.kdSO " & _
                                    " Join msuser On msuser.UserID = so.UserID " & _
                                    " where 1 " & _
                                    " And jenis_so = '" & type_faktur & "' " & _
                                    addQuery & " Order By so.no_increment Desc,StatusSO asc ")
        Do While reader.Read
            cmbSO.Items.Add(reader(0))
        Loop
        reader.Close()
        If cmbSO.Items.Count > 0 Then
            cmbSO.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        type_faktur = data_carier(2)
        clear_variable_array()
        setCmbSO()
        emptyField()

        If type_faktur = "klem" Then
            Me.Text = "Faktur Klem Jadi"
        Else
            Me.Text = "Faktur Paku"
        End If

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbSO.Focus()

    End Sub

    Private Sub generateCode()
        Dim code As String = "FK"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        Dim tempCompare As String = ""

        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, ".dd.MM.yy")
        tempCompare &= FormatDate

        Dim reader = getFaktur()

        If reader.read Then
            kode = Trim(reader("KdFaktur").ToString())
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

    Function SaveFakturDetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusSO = "2"

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells("clmHargaJual").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim disc = Val(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
            Dim OP = "Min"
            Dim Attribute = "QtyFaktur_Min"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim Stok = check_stock(KdBarang, 0, "Stock")
            Dim komisiSales = gridBarang.Rows.Item(i).Cells("clmKomisi").Value
            Dim HargaDisc = gridBarang.Rows.Item(i).Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", "")
            'Dim stock = Val(gridBarang.Rows.Item(i).Cells("clmStock").Value)

            If Qty > Stok Then
                MsgBox("Jumlah tidak mencukupi persedian. Persedian saat ini adalah " & Stok, MsgBoxStyle.Information, "Validation Error")
                Return False
            End If

            If flag = 1 Then
                If type_faktur = "klem" Then
                    StockBarang(Qty, OP, HargaDisc, KdBarang, Attribute, Trim(txtID.Text), "Form Faktur")
                Else
                    StockBahanMentah(Qty, OP, HargaDisc, KdBarang, Attribute, Trim(txtID.Text), "Form Faktur", "Paku")
                End If
            End If
            sqlDetail = "insert into TrFakturDetail(KdFaktur,KdBarang, Harga, " _
                           & " Qty, Disc, KomisiSales, HargaDisc) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                           & " '" & harga & "', '" & Qty & "', " _
                           & " '" & disc & "','" & komisiSales & "','" & HargaDisc & "')"
            execute_update_manual(sqlDetail)
        Next
        Dim readerFaktur = execute_reader(" Select StatusBarang from TrSalesOrderDetail " & _
                                             " Where KdSO = '" & Trim(cmbSO.Text) & "' " & _
                                             " And StatusBarang = 1 ")

        If flag = 1 Then
            If readerFaktur.read = True Then
                statusSO = "4"
            End If
            Dim sqlSO = " Update TrSalesOrder set StatusSO = '" & statusSO & "' " & _
                        " Where KdSO = '" & Trim(cmbSO.Text) & "' "
            execute_update_manual(sqlSO)

            Dim sqlSODetail = " Update TrSalesOrderDetail set StatusBarang = '2' " & _
                                  " Where KdSO = '" & Trim(cmbSO.Text) & "' " & _
                                  " And StatusBarang = 0 "
            execute_update_manual(sqlSODetail)

            readerFaktur.close()
        End If

        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbSO.SelectedIndex = 0 Then
            msgInfo("Pemesanan harus dipilih")
            cmbSO.Focus()
        Else
            Dim Grandtotal = ""
            Dim Jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")

            If (txt_jumlah.Text <> "") Then
                Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            End If

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                Dim TotalKomisi = txtTotalKomisi.Text.ToString.Replace(".", "").Replace(",", "")
                If PK = "" Then
                    sql = " insert into  trfaktur (KdFaktur, KdSO, TanggalFaktur, " & _
                          " KdSales, KdToko, GrandTotal, StatusFaktur, " & _
                          " UserID, TotalKomisiSales, TanggalJT, KomisiPersen, jenis_faktur, " & _
                          " Disc, Jumlah ) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" & cmbSO.Text & "', " & _
                          " '" & dtpFaktur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdsales) & "','" & Trim(kdtoko) & "'," & _
                          " '" & Trim(Grandtotal) & "','" & flag & "','" & kdKaryawan & "', " & _
                          " '" & TotalKomisi & "','" & tJatuhTempo & "', '" & Trim(txtKomisi.Text) & "', " & _
                          " '" & type_faktur & "','" & txt_disc_faktur.Text & "','" & Jumlah & "' )"

                    execute_update_manual(sql)
                Else
                    sql = " update   trfaktur  set " & _
                        " kdso='" & cmbSO.Text & "'," & _
                        " TanggalFaktur='" & dtpFaktur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                        " KdSales='" & Trim(kdsales) & "'," & _
                        " KdToko='" & Trim(kdtoko) & "'," & _
                        " GrandTotal='" & Trim(Grandtotal) & "', " & _
                        " StatusFaktur='" & flag & "', " & _
                        " UserID='" & Trim(kdKaryawan) & "', " & _
                        " TotalKomisiSales='" & Trim(TotalKomisi) & "', " & _
                        " TanggalJT='" & Trim(tJatuhTempo) & "', " & _
                        " KomisiPersen='" & Trim(txtKomisi.Text) & "', " & _
                        " jenis_faktur='" & type_faktur & "', " & _
                        " Disc='" & txt_disc_faktur.Text & "', " & _
                        " Jumlah='" & Jumlah & "' " & _
                        " where  KdFaktur = '" + txtID.Text + "' "
                    execute_update_manual(sql)
                End If
                execute_update_manual("delete from Trfakturdetail where  kdfaktur = '" & txtID.Text & "'")
                If Not SaveFakturDetail(flag) Then
                    dbconmanual.Close()
                    Return False
                End If

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

    Function calc_disc_faktur()
        Dim disc = txt_disc_faktur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            Dim TotalKomisi = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            calc_disc_faktur()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gridBarang.CellBeginEdit
        tempDisc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
        tempDisc = Math.Round(tempDisc, 2)
        tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", ""))
        tempHarga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.ToString.Replace(".", "").Replace(",", ""))
    End Sub

    Private Sub gridBarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellClick
        tempDisc = gridBarang.CurrentRow.Cells("clmDisc").Value * 1
        tempDisc = Math.Round(tempDisc, 2)
        tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", ""))
        tempHarga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.ToString.Replace(".", "").Replace(",", ""))
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim BarangID = gridBarang.CurrentRow.Cells("clmPartNo").Value
            Dim harga = Val(gridBarang.CurrentRow.Cells("clmHargaJual").Value.ToString.Replace(".", "").Replace(",", ""))
            Dim hargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
            Dim stok = check_stock(BarangID, 0, "Stock")

            If IsNumeric(qty) = False Or qty < 1 Then
                MsgBox("Jumlah harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                qty = 1
                gridBarang.CurrentRow.Cells("clmQty").Value = 1
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
                'ElseIf qty > stok Then
                '    MsgBox("Jumlah tidak mencukupi persedian. Persedian saat ini adalah " & stok, MsgBoxStyle.Information, "Validation Error")
                '    qty = 1
                '    gridBarang.CurrentRow.Cells("clmQty").Value = 1
                '    gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf IsNumeric(harga) = False Or harga < 1 Then
                MsgBox("Harga harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                harga = 1
                gridBarang.CurrentRow.Cells("clmHargaJual").Value = 1
                gridBarang.CurrentRow.Cells("clmHargaJual").Selected = True
            ElseIf IsNumeric(disc) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                disc = 0
                gridBarang.CurrentRow.Cells("clmDisc").Value = 0
                gridBarang.CurrentRow.Cells("clmDisc").Selected = True
            ElseIf IsNumeric(hargaDisc) = False Or hargaDisc < 1 Then
                MsgBox("Harga Disc harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                hargaDisc = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                Dim TempHargaDisc = FormatNumber(HargaDisc, 0)
                gridBarang.CurrentRow.Cells("clmHargaJual").Value = TempHarga
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = TempHargaDisc
            End If

            If hargaDisc <> tempHargaDisc Or harga <> tempHarga Then
                Dim calcDisc = 100 - (hargaDisc / harga * 100)
                gridBarang.CurrentRow.Cells("clmDisc").Value = Math.Round(calcDisc, 2)
            ElseIf disc <> tempDisc Then
                Dim discProses = 100 - Math.Round(disc * 1, 2)
                Dim calcHargaJual = harga * (discProses / 100)
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = FormatNumber(calcHargaJual, 0)
            End If

            gridBarang.CurrentRow.Cells("clmSubtotal").Value = FormatNumber(Val(hargaDisc) * Val(qty), 0)

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub BrowseSO_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseSO.Click
        Try
            data_carier(0) = PK
            data_carier(1) = type_faktur
            sub_form = New FormBrowseSO
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbSO.Text = data_carier(0)
                txtSales.Text = data_carier(1)
                txtToko.Text = data_carier(2)
                lblDaerah.Text = data_carier(3)
                kdsales = data_carier(4)
                kdtoko = data_carier(5)
                Dim KomisiDisc = data_carier(6)
                clear_variable_array()

                'Dim sql_so = ""
                'If type_faktur = "klem" Then
                '    sql_so = " Select MB.KdBarang,NamaBarang, " & _
                '             " HargaDisc,Harga,sum(Qty) Qty,SO.Disc, " & _
                '             " ifnull(( Select StockAkhir " & _
                '             " from BarangHistory where isActive = 1 " & _
                '             " And KdBarang = SO.KdBarang " & _
                '             " order by KdBarangHistory desc limit 1 ),0) Stock, " & _
                '             " SO.StatusBarang,Merk, TrSalesOrder.Disc disc_faktur " & _
                '             " from TrSalesOrderDetail SO " & _
                '             " Join MsBarang MB On SO.KdBarang = MB.KdBarang " & _
                '             " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                '             " Join TrSalesOrder On SO.KdSO = TrSalesOrder.KdSO " & _
                '             " where SO.KdSO = '" & cmbSO.Text & "' " & _
                '             " And StatusBarang = 0 " & _
                '             " Group by SO.kdso,MB.KdBarang " & _
                '             " order by NamaBarang asc "
                'Else
                '    sql_so = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                '             " HargaDisc,Harga,sum(Qty) Qty,SO.Disc, " & _
                '             " ifnull(( Select StockAkhir " & _
                '             " from bahanmentahhistory where isActive = 1 " & _
                '             " And KdBahanMentah = SO.KdBarang " & _
                '             " order by KdHistory desc limit 1 ),0) Stock, " & _
                '             " SO.StatusBarang,'N/A' Merk, TrSalesOrder.Disc disc_faktur " & _
                '             " from TrSalesOrderDetail SO " & _
                '             " Join msbahanmentah MBM On SO.KdBarang = MBM.KdBahanMentah " & _
                '             " Join TrSalesOrder On SO.KdSO = TrSalesOrder.KdSO " & _
                '             " where SO.KdSO = '" & cmbSO.Text & "' " & _
                '             " And StatusBarang = 0 " & _
                '             " Group by SO.kdso,MBM.KdBahanMentah " & _
                '             " order by NamaBahanMentah asc "
                'End If

                'Dim reader = execute_reader(sql_so)
                'gridBarang.Rows.Clear()
                'Do While reader.Read
                '    Dim HargaDisc = reader("HargaDisc")
                '    Dim Subtotal = Val(HargaDisc) * Val(reader("Qty"))
                '    Dim StatusBarang = "Ready"
                '    Dim komisi = 0
                '    txt_disc_faktur.Text = reader("disc_faktur")

                '    If Val(reader("StatusBarang")) = 1 Then
                '        StatusBarang = "Pending"
                '    End If

                '    komisi = Subtotal * (KomisiDisc / 100)

                '    gridBarang.Rows.Add()
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaJual").Value = FormatNumber(reader("Harga"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(HargaDisc, 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStock").Value = reader("Stock")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyOri").Value = reader("Qty")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = StatusBarang
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKomisi").Value = komisi
                'Loop
                'reader.Close()

                'HitungTotal()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbSO_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbSO.SelectedIndexChanged
        If cmbSO.SelectedIndex <> 0 Then
            Dim addQuery = ""
            If PK = "" Then
                addQuery = " ( select  ) "
            Else
                addQuery = ""
            End If

            Dim sql_so = ""
            If type_faktur = "klem" Then
                sql_so = " SELECT MB.KdBarang, NamaBarang,  " & _
                        " SO.HargaDisc, SO.Harga, " & _
                        " SUM(SO.Qty) - IFNULL( ( " & _
                        "   SELECT SUM(tfd.Qty) FROM trfakturdetail tfd " & _
                        "   JOIN trfaktur tf ON tfd.KdFaktur = tf.KdFaktur  " & _
                        "   WHERE tf.KdSO = SO.KdSO " & _
                        "   AND tfd.KdBarang = MB.KdBarang " & _
                        "   GROUP BY tfd.KdBarang " & _
                        " ), 0) Qty, " & _
                        " SO.Disc, IFNULL( ( " & _
                        "   SELECT SUM(MBL.Qty) FROM msbaranglist MBL " & _
                        "   WHERE MBL.KdBarang = MB.KdBarang " & _
                        "   AND MBL.StatusBarangList = 0  " & _
                        "   GROUP BY MBL.KdBarang " & _
                        " ),0 ) Stock, SO.StatusBarang,   " & _
                        " MS.KdSales, NamaSales,   " & _
                        " MT.KdToko, NamaToko, MT.Daerah,  " & _
                        " Merk,TSO.KomisiSales,JatuhTempo, TSO.Disc disc_faktur  " & _
                        " FROM TrSalesOrderDetail SO  " & _
                        " JOIN trsalesorder TSO ON SO.kdso = TSO.kdso  " & _
                        " JOIN MsBarang MB ON SO.KdBarang = MB.KdBarang  " & _
                        " JOIN MsMerk ON MsMerk.kdMerk = MB.kdMerk  " & _
                        " JOIN MsSales MS ON MS.KdSales = TSO.KdSales  " & _
                        " JOIN MsToko MT ON MT.KdToko = TSO.KdToko  " & _
                        " WHERE SO.KdSO = '" & cmbSO.Text & "'  " & _
                        " AND SO.StatusBarang = 0  " & _
                        " GROUP BY SO.kdso,MB.KdBarang  " & _
                        " ORDER BY NamaBarang asc "
            Else
                sql_so = " SELECT MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                        " SO.HargaDisc, SO.Harga, " & _
                        " SUM(SO.Qty) - IFNULL(( " & _
                        "   SELECT SUM(tfd.Qty) FROM trfakturdetail tfd " & _
                        "   JOIN trfaktur tf ON tfd.KdFaktur = tf.KdFaktur " & _
                        "   WHERE tf.KdSO = SO.KdSO " & _
                        "   AND tfd.KdBarang = MBM.KdBahanMentah " & _
                        "   GROUP BY tfd.KdBarang " & _
                        " ), 0) Qty, SO.Disc, " & _
                        " IFNULL( ( " & _
                        "   SELECT SUM(MBL.Qty) FROM msbahanmentahlist MBL " & _
                        "   WHERE(MBL.KdBahanMentah = MBM.KdBahanMentah) " & _
                        "   AND MBL.StatusBahanMentahList = 0 " & _
                        "   GROUP BY MBL.KdBahanMentah " & _
                        " ),0) Stock, SO.StatusBarang, " & _
                        " MS.KdSales, NamaSales, " & _
                        " MT.KdToko, NamaToko, MT.Daerah, " & _
                        " 'N/A' Merk,TSO.KomisiSales,JatuhTempo, TSO.Disc disc_faktur " & _
                        " FROM TrSalesOrderDetail SO  " & _
                        " JOIN trsalesorder TSO ON SO.kdso = TSO.kdso " & _
                        " JOIN msbahanmentah MBM ON SO.KdBarang = MBM.KdBahanMentah " & _
                        " JOIN MsSales MS ON MS.KdSales = TSO.KdSales  " & _
                        " JOIN MsToko MT ON MT.KdToko = TSO.KdToko  " & _
                        " WHERE SO.KdSO = '" & cmbSO.Text & "'  " & _
                        " AND StatusBarang = 0  " & _
                        " GROUP BY SO.kdso,MBM.KdBahanMentah  " & _
                        " ORDER BY NamaBahanMentah asc "
            End If
            Dim reader = execute_reader(sql_so)

            Dim idxso = 0
            gridBarang.Rows.Clear()
            Do While reader.Read
                If idxso = 0 Then
                    txtSales.Text = reader("NamaSales")
                    txtToko.Text = reader("NamaToko")
                    lblDaerah.Text = reader("Daerah")
                    kdsales = reader("KdSales")
                    kdtoko = reader("KdToko")
                    txtKomisi.Text = reader("KomisiSales")
                    jatuhTempo = reader("JatuhTempo")
                    txt_disc_faktur.Text = reader("disc_faktur")
                End If

                Dim HargaDisc = reader("HargaDisc")
                Dim Subtotal = Val(HargaDisc) * Val(reader("Qty"))
                Dim StatusBarang = "Ready"
                Dim komisi = 0

                If Val(reader("StatusBarang")) = 1 Then
                    StatusBarang = "Pending"
                End If

                komisi = Subtotal * (txtKomisi.Text / 100)

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaJual").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(HargaDisc, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStock").Value = reader("Stock")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyOri").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = StatusBarang
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKomisi").Value = komisi
                idxso += 1
            Loop
            reader.Close()

            reader = Nothing
            tJatuhTempo = Format(DateAdd(DateInterval.Day, jatuhTempo, CDate(dtpFaktur.Value.ToString("yyyy-MM-dd"))), "yyyy-MM-dd")
            TanggalJT.Text = Format(DateAdd(DateInterval.Day, jatuhTempo, CDate(dtpFaktur.Value.ToString("yyyy-MM-dd"))), "dd MMMM yyyy")

            HitungTotal()
        Else
            txtSales.Text = ""
            txtToko.Text = ""
            lblDaerah.Text = ""
            kdsales = ""
            kdtoko = ""
            gridBarang.Rows.Clear()
        End If
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub txtKomisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKomisi.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtKomisi_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtKomisi.TextChanged
        Dim komisi = 0
        Dim subtotal = 0
        For i As Integer = 0 To gridBarang.RowCount - 1
            subtotal = gridBarang.Rows.Item(i).Cells("clmSubtotal").Value
            komisi = subtotal * (txtKomisi.Text / 100)
            gridBarang.Rows.Item(i).Cells("clmKomisi").Value = komisi
        Next
        HitungTotal()
    End Sub

    Private Sub gridBarang_CellContentClick(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellContentClick

    End Sub
End Class
