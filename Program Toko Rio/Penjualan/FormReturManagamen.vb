Imports System.Data.SqlClient
Public Class FormReturManagamen
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBarang As String = ""
    Dim Merk As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""
    Dim isPaid As String = 0
    Dim statusReturFaktur = 0
    Dim type_retur As String
    Dim tempDisc = 0
    Dim tempHargaDisc = 0
    Dim tempHarga = 0


    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpRetur.Text = Now()
        cmbFaktur.SelectedIndex = 0
        txtSales.Text = ""
        txtToko.Text = ""
        lblDaerah.Text = ""
    End Sub

    Function getRetur(Optional ByVal KdRetur As String = "")
        Dim sql As String = "Select KdRetur from trRetur order by no_increment desc "

        If KdRetur <> "" Then
            sql &= "kdRetur = '" & KdRetur & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim Sales = ""
            Dim Toko = ""
            Dim kdFaktur = ""
            Dim readerRetur = execute_reader(" select kdretur,DATE_FORMAT(Tanggalretur, '%m/%d/%Y') Tanggal, " & _
                                            " retur.kdFaktur, MS.KdSales, NamaSales, " & _
                                            " MT.KdToko, NamaToko, MT.Daerah, StatusRetur, " & _
                                            " Note, retur.Disc disc_retur " & _
                                            " from trretur retur " & _
                                            " Join MsSales MS On MS.KdSales = retur.KdSales " & _
                                            " Join MsToko MT On MT.KdToko = retur.KdToko " & _
                                            " Where kdretur = '" & PK & "' ")
            If readerRetur.Read Then
                txtID.Text = readerRetur.Item("kdretur")
                dtpRetur.Text = readerRetur.Item("Tanggal")
                lblDaerah.Text = readerRetur.Item("Daerah")
                kdFaktur = readerRetur.Item("kdFaktur")
                Sales = readerRetur.Item("KdSales") & " - " & readerRetur.Item("NamaSales")
                Toko = readerRetur.Item("KdToko") & " - " & readerRetur.Item("NamaToko")
                txt_disc_retur.Text = readerRetur.Item("disc_retur")
                If readerRetur.Item("StatusRetur") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                statusReturFaktur = readerRetur.Item("StatusRetur")
                txtNote.Text = readerRetur.Item("Note")
            End If
            readerRetur.Close()
            txtSales.Text = Sales
            txtToko.Text = Toko
            cmbFaktur.Text = kdFaktur

            Dim sql_retur = ""
            If type_retur = "klem" Then
                sql_retur = " Select MB.KdBarang,NamaBarang, " & _
                            " Harga, Qty,retur.Disc, " & _
                            " IfNull(QtyFaktur,0) - " & _
                            " ifNull(QtyRetur,0) as QtyFaktur, " & _
                            " StatusBarang,Merk,HargaDisc " & _
                            " from TrReturDetail retur " & _
                            " Join MsBarang MB On retur.KdBarang = MB.KdBarang " & _
                            " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                            " Left Join ( select sum(Qty) QtyFaktur,KdBarang from TrFakturDetail " & _
                            " Join TrFaktur on TrFaktur.KdFaktur = TrFakturDetail.KdFaktur " & _
                            " Where TrFaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                            " And statusfaktur <> 0 " & _
                            " Group By  TrFaktur.kdFaktur,KdBarang ) fakturdetail On fakturdetail.KdBarang = retur.KdBarang " & _
                            " Left Join ( Select sum(Qty) QtyRetur,TrRetur.KdRetur,KdBarang from TrReturDetail " & _
                            " Join TrRetur on TrRetur.KdRetur = TrReturDetail.KdRetur " & _
                            " Where 1 " & _
                            " And KdFaktur = '" & cmbFaktur.Text & "' " & _
                            " Group by TrRetur.KdFaktur,KdBarang ) returdetail On returdetail.KdRetur <> retur.KdRetur " & _
                            " And returdetail.KdBarang = retur.KdBarang " & _
                            " where retur.kdretur = '" & PK & "' " & _
                            " order by NamaBarang asc "
            Else
                sql_retur = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                            " Harga, Qty,retur.Disc, " & _
                            " IfNull(QtyFaktur,0) - ifNull(QtyRetur,0) as QtyFaktur, " & _
                            " StatusBarang,'N/A' Merk,HargaDisc " & _
                            " from TrReturDetail retur " & _
                            " Join msbahanmentah MBM On retur.KdBarang = MBM.KdBahanMentah " & _
                            " Left Join ( select sum(Qty) QtyFaktur,KdBarang from TrFakturDetail " & _
                            " Join TrFaktur on TrFaktur.KdFaktur = TrFakturDetail.KdFaktur " & _
                            " Where TrFaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                            " And statusfaktur <> 0 " & _
                            " Group By  TrFaktur.kdFaktur,KdBarang ) fakturdetail On fakturdetail.KdBarang = retur.KdBarang " & _
                            " Left Join ( Select sum(Qty) QtyRetur,TrRetur.KdRetur,KdBarang from TrReturDetail " & _
                            " Join TrRetur on TrRetur.KdRetur = TrReturDetail.KdRetur " & _
                            " Where 1 " & _
                            " And KdFaktur = '" & cmbFaktur.Text & "' " & _
                            " Group by TrRetur.KdFaktur,KdBarang ) returdetail On returdetail.KdRetur <> retur.KdRetur " & _
                            " And returdetail.KdBarang = retur.KdBarang " & _
                            " where retur.kdretur = '" & PK & "' " & _
                            " order by NamaBahanMentah asc "
            End If
            Dim reader = execute_reader(sql_retur)

            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim HargaDisc = Val(reader("HargaDisc"))
                Dim Subtotal = HargaDisc * Val(reader("Qty"))

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyFaktur").Value = reader("QtyFaktur")
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

    Public Sub setCmbFaktur()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbFaktur.Items.Clear()
        cmbFaktur.Items.Add("- Pilih Faktur -")
        If PK <> "" Then
            addQuery = " And exists( " & _
                       "    Select 1 from trretur " & _
                       "    where kdretur = '" & PK & "' " & _
                       "    And trretur.KdFaktur = trfaktur.KdFaktur " & _
                       " ) "
            cmbFaktur.Enabled = False
            BrowseFaktur.Enabled = False
        Else
            addQuery = " And statusfaktur not in (0,3) " & _
                       " And NOT EXISTS( " & _
                       "    Select 1 from trreturdetail trd " & _
                       "    Join trretur tr On tr.KdRetur = trd.KdRetur " & _
                       "    where tr.KdFaktur = trfaktur.KdFaktur " & _
                       "    And tfd.KdBarang = trd.KdBarang " & _
                       "    GROUP BY trd.KdBarang " & _
                       "    HAVING tfd.Qty - SUM(trd.Qty) < 1 " & _
                       " ) "
        End If

        Dim reader = execute_reader(" Select trfaktur.KdFaktur from trfaktur " & _
                                    " Join trfakturdetail tfd On tfd.KdFaktur = trfaktur.KdFaktur " & _
                                    " Left Join msuser On msuser.UserID = trfaktur.UserID " & _
                                    " where 1 " & _
                                    " And jenis_faktur = '" & type_retur & "' " & _
                                    addQuery & " Group By trfaktur.KdFaktur " & _
                                    " Order By no_increment DESC ")
        Do While reader.Read
            cmbFaktur.Items.Add(reader(0))
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
        type_retur = data_carier(2)
        clear_variable_array()
        setCmbFaktur()
        emptyField()

        If type_retur = "klem" Then
            Me.Text = "Retur Klem Jadi"
        Else
            Me.Text = "Retur Paku"
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
        Dim code As String = "RF"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        Dim tempCompare As String = ""

        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, ".dd.MM.yy")
        tempCompare &= FormatDate

        Dim reader = getRetur()

        If reader.read Then
            kode = Trim(reader("KdRetur").ToString())
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

    Function SaveReturDetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusFaktur = 3
        Dim StatusBarangList = 0

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim hargaDisc = gridBarang.Rows.Item(i).Cells("clmHargaDisc").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells("clmQty").Value)
            Dim disc = Val(gridBarang.Rows.Item(i).Cells("clmDisc").Value)
            Dim OP = "Plus"
            Dim Attribute = "QtyRetur_Plus"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmPartNo").Value
            Dim Stok = gridBarang.Rows.Item(i).Cells("clmQtyFaktur").Value
            Dim statusBarang = gridBarang.Rows.Item(i).Cells("clmStatus").Value

            If statusBarang = "Rusak" Then
                StatusBarangList = 1
            End If

            If Qty <> Stok Then
                statusFaktur = 2
            End If

            If Qty <> 0 Then
                If flag = 1 Then
                    If type_retur = "klem" Then
                        StockBarang(Qty, OP, harga, KdBarang, Attribute, Trim(txtID.Text), "Form Retur Penjualan", StatusBarangList)
                    Else
                        StockBahanMentah(Qty, OP, harga, KdBarang, Attribute, Trim(txtID.Text), "Form Retur Penjualan", "Paku", StatusBarangList)
                    End If
                End If
                sqlDetail = "insert into TrReturDetail(KdRetur,KdBarang, Harga, " _
                               & " Qty, Disc,StatusBarang, HargaDisc) values( " _
                               & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                               & " '" & harga & "', '" & Qty & "', " _
                               & " '" & disc & "','" & statusBarang & "','" & hargaDisc & "')"

                execute_update_manual(sqlDetail)

            End If
        Next

        If flag = 1 Then
            Dim sqlFaktur = " Update TrFaktur set StatusFaktur = '" & statusFaktur & "' " & _
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
        Else
            Dim Grandtotal = ""
            Dim checkQty = 0
            Dim jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")

            For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                If gridBarang.Rows.Item(i).Cells("clmQty").Value <> 0 Then
                    checkQty += 1
                    If gridBarang.Rows.Item(i).Cells("clmStatus").Value = "- Klik disini -" Then
                        msgInfo("Klik status barang.")
                        gridBarang.Rows.Item(i).Cells("clmStatus").Selected = True
                        Return True
                        Exit Function
                    End If
                Else
                    checkQty += 0
                End If
            Next

            If checkQty = 0 Then
                msgInfo("Salah satu jumlah harus diisi lebih dari 0.")
                Return True
                Exit Function
            End If

            If (txt_jumlah.Text <> "") Then
                Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            End If

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            If isPaid > 0 Then
                isPaid = 1
            End If

            Try
                If PK = "" Then
                    sql = " insert into  trretur ( KdRetur, KdFaktur, TanggalRetur, " & _
                          " KdSales, KdToko, GrandTotal, StatusRetur, Note, " & _
                          " UserID, AfterPaid, jenis_retur, Disc, Jumlah ) " & _
                          " values('" + Trim(txtID.Text) + "', " & _
                          " '" & cmbFaktur.Text & "', " & _
                          " '" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdsales) & "','" & Trim(kdtoko) & "'," & _
                          " '" & Trim(Grandtotal) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "', " & _
                          " '" & kdKaryawan & "','" & isPaid & "','" & type_retur & "', " & _
                          " '" & txt_disc_retur.Text & "', '" & jumlah & "' )"
                    execute_update_manual(sql)
                Else
                    sql = "update   trretur  set  TanggalRetur='" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                    " kdFaktur = '" & cmbFaktur.Text & "'," & _
                    " TanggalRetur = '" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                    " KdSales = '" & Trim(kdsales) & "'," & _
                    " KdToko = '" & Trim(kdtoko) & "'," & _
                    " GrandTotal = '" & Trim(Grandtotal) & "', " & _
                    " StatusRetur = '" & flag & "', " & _
                    " Note =  '" & Trim(txtNote.Text) & "', " & _
                    " UserID = '" & kdKaryawan & "', " & _
                    " AfterPaid = '" & isPaid & "', " & _
                    " jenis_retur = '" & type_retur & "', " & _
                    " Disc = '" & txt_disc_retur.Text & "', " & _
                    " Jumlah = '" & jumlah & "' " & _
                    " where  KdRetur = '" + txtID.Text + "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from Trreturdetail where  kdretur = '" & txtID.Text & "'")
                SaveReturDetail(flag)

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
        Dim disc = txt_disc_retur.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
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
            calc_disc_faktur()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellBeginEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellCancelEventArgs) Handles gridBarang.CellBeginEdit
        tempDisc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
        tempDisc = Math.Round(tempDisc, 2)
        tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
        tempHarga = Val(gridBarang.CurrentRow.Cells("clmHarga").Value.Replace(".", "").Replace(",", ""))
    End Sub

    Private Sub gridBarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellClick
        If gridBarang.CurrentRow.Cells("clmStatus").Selected = True Then
            sub_form = New FormBrowseStatusRetur
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                gridBarang.CurrentRow.Cells("clmStatus").Value = data_carier(0)
                clear_variable_array()
            End If
        Else
            tempDisc = gridBarang.CurrentRow.Cells("clmDisc").Value * 1
            tempDisc = Math.Round(tempDisc, 2)
            tempHargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
            tempHarga = Val(gridBarang.CurrentRow.Cells("clmHarga").Value.Replace(".", "").Replace(",", ""))
        End If
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim BarangID = gridBarang.CurrentRow.Cells("clmPartNo").Value
            Dim harga = Val(gridBarang.CurrentRow.Cells("clmHarga").Value.Replace(".", "").Replace(",", ""))
            Dim hargaDisc = Val(gridBarang.CurrentRow.Cells("clmHargaDisc").Value.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells("clmDisc").Value)
            Dim stok = Val(gridBarang.CurrentRow.Cells("clmQtyFaktur").Value)

            If qty < 1 Then
                MsgBox("Jumlah harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells("clmQty").Value = stok
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf qty > stok Then
                MsgBox("Jumlah tidak mencukupi persedian. Persedian saat ini adalah " & stok, MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells("clmQty").Value = stok
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf harga < 1 Then
                MsgBox("Harga harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                harga = 1
                gridBarang.CurrentRow.Cells("clmHarga").Value = 1
                gridBarang.CurrentRow.Cells("clmHarga").Selected = True
            ElseIf hargaDisc < 1 Then
                MsgBox("Harga Disc harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                hargaDisc = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = 1
                gridBarang.CurrentRow.Cells("clmHargaDisc").Selected = True
            ElseIf IsNumeric(gridBarang.CurrentRow.Cells("clmDisc").Value) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                disc = 0
                gridBarang.CurrentRow.Cells("clmDisc").Value = 0
                gridBarang.CurrentRow.Cells("clmDisc").Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                Dim TempHargaDisc = FormatNumber(hargaDisc, 0)
                gridBarang.CurrentRow.Cells("clmHarga").Value = TempHarga
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = TempHargaDisc
            End If

            If hargaDisc <> tempHargaDisc Or harga <> tempHarga Then
                Dim calcDisc = 100 - (hargaDisc / harga * 100)
                gridBarang.CurrentRow.Cells("clmDisc").Value = Math.Round(calcDisc, 2)
            ElseIf disc <> tempDisc Then
                Dim discProses = 100 - Math.Round(disc * 1, 2)
                Dim calcHarga = harga * (discProses / 100)
                gridBarang.CurrentRow.Cells("clmHargaDisc").Value = FormatNumber(calcHarga, 0)
            End If

            gridBarang.CurrentRow.Cells("clmSubtotal").Value = FormatNumber(Val(hargaDisc) * Val(qty), 0)

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub BrowseFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseFaktur.Click
        Try
            data_carier(0) = PK
            data_carier(1) = "ReturFaktur"
            data_carier(2) = type_retur
            sub_form = New FormBrowseFaktur
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbFaktur.Text = data_carier(0)
                'txtSales.Text = data_carier(1)
                'txtToko.Text = data_carier(2)
                'lblDaerah.Text = data_carier(3)
                'kdsales = data_carier(4)
                'kdtoko = data_carier(5)
                'isPaid = data_carier(6)
                clear_variable_array()

                'Dim sql_faktur = ""
                'If type_retur = "klem" Then
                '    sql_faktur = " Select MB.KdBarang,NamaBarang, Trfaktur.Disc disc_faktur, " & _
                '                " Harga,sum(Qty) - ifnull(QtyRetur,0) Qty, " & _
                '                " TrReturDetail.Disc, faktur.StatusBarang,Merk,HargaDisc " & _
                '                " from TrfakturDetail faktur " & _
                '                " Join Trfaktur On Trfaktur.KdFaktur = faktur.KdFaktur " & _
                '                " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                '                " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                '                " Join ( Select sum(Qty) QtyRetur,KdBarang,KdFaktur " & _
                '                " from TrReturDetail " & _
                '                " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                " where 1 " & _
                '                " Group By KdFaktur,KdBarang ) retur On retur.KdBarang = faktur.KdBarang " & _
                '                " And retur.KdFaktur = Trfaktur.KdFaktur " & _
                '                " where Trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                '                " Group by Trfaktur.KdFaktur,MB.KdBarang " & _
                '                " order by NamaBarang asc "
                'Else
                '    sql_faktur = " Select MBM.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                '                " Harga,sum(Qty) - ifnull(QtyRetur,0) Qty, Trfaktur.Disc disc_faktur, " & _
                '                " TrReturDetail.Disc, faktur.StatusBarang,'N/A' Merk,HargaDisc " & _
                '                " from TrfakturDetail faktur " & _
                '                " Join Trfaktur On Trfaktur.KdFaktur = faktur.KdFaktur " & _
                '                " Join msbahanmentah MBM On faktur.KdBarang = MBM.KdBahanMentah " & _
                '                " Join ( Select sum(Qty) QtyRetur,KdBarang,KdFaktur " & _
                '                " from TrReturDetail " & _
                '                " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                '                " where 1 " & _
                '                " Group By KdFaktur,KdBarang ) retur On retur.KdBarang = faktur.KdBarang " & _
                '                " And retur.KdFaktur = Trfaktur.KdFaktur " & _
                '                " where Trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                '                " Group by Trfaktur.KdFaktur,MBM.KdBahanMentah " & _
                '                " order by NamaBarang asc "
                'End If

                'Dim reader = execute_reader(sql_faktur)

                'gridBarang.Rows.Clear()
                'Do While reader.Read
                '    txt_disc_retur.Text = reader("disc_faktur")
                '    gridBarang.Rows.Add()
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyFaktur").Value = reader("Qty")
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = 0
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = 0
                '    gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = "- Klik disini -"
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
            Dim sql_faktur = ""
            If type_retur = "klem" Then
                sql_faktur = " Select MB.KdBarang, NamaBarang, " & _
                            " HargaDisc, Harga,sum(Qty) - " & _
                            " ifnull(( " & _
                            "   Select sum(Qty) " & _
                            "   from TrReturDetail " & _
                            "   Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                            "   where TrReturDetail.KdBarang = faktur.KdBarang " & _
                            "   And TrRetur.kdFaktur = trfaktur.kdFaktur " & _
                            "   AND TrReturDetail.Harga = faktur.Harga " & _
                            "   Group By TrRetur.kdFaktur, TrReturDetail.KdBarang " & _
                            " ),0) Qty, " & _
                            " faktur.Disc, faktur.StatusBarang, " & _
                            " MS.KdSales, NamaSales, " & _
                            " MT.KdToko, NamaToko, MT.Daerah, " & _
                            " Merk, StatusPayment, IfNull(HargaAwal,0) HargaAwal, " & _
                            " trfaktur.Disc disc_faktur " & _
                            " from TrFakturDetail faktur " & _
                            " Join trfaktur On faktur.kdfaktur = trfaktur.kdfaktur " & _
                            " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                            " Join MsMerk On MsMerk.kdMerk = MB.kdMerk " & _
                            " Join MsSales MS On MS.KdSales = trfaktur.KdSales " & _
                            " Join MsToko MT On MT.KdToko = trfaktur.KdToko " & _
                            " Left Join baranghistory BH On BH.RefNumber = trfaktur.kdfaktur" & _
                            " And BH.KdBarang = faktur.KdBarang" & _
                            " where trfaktur.kdFaktur = '" & cmbFaktur.Text & "' " & _
                            " Group by Trfaktur.kdFaktur, MB.KdBarang " & _
                            " order by NamaBarang asc "
            Else
                sql_faktur = " SELECT MBM.KdBahanMentah KdBarang, NamaBahanMentah NamaBarang, " & _
                            " faktur.Harga, SUM(Qty) - " & _
                            " IFNULL(( " & _
                            "   SELECT SUM(Qty) FROM TrReturDetail trd " & _
                            "   JOIN TrRetur tr ON trd.KdRetur = tr.KdRetur " & _
                            "   WHERE trd.KdBarang = faktur.KdBarang " & _
                            "   AND tr.KdFaktur = trfaktur.KdFaktur " & _
                            "   GROUP BY KdFaktur,KdBarang " & _
                            " ),0) Qty, " & _
                            " faktur.Disc, faktur.StatusBarang, " & _
                            " MS.KdSales, NamaSales, " & _
                            " MT.KdToko, NamaToko, MT.Daerah, " & _
                            " 'N/A' Merk,StatusPayment,HargaDisc, " & _
                            " trfaktur.Disc disc_faktur " & _
                            " FROM TrFakturDetail faktur " & _
                            " JOIN trfaktur ON faktur.kdfaktur = trfaktur.kdfaktur " & _
                            " JOIN msbahanmentah MBM ON faktur.KdBarang = MBM.KdBahanMentah " & _
                            " JOIN MsSales MS ON MS.KdSales = trfaktur.KdSales " & _
                            " JOIN MsToko MT ON MT.KdToko = trfaktur.KdToko " & _
                            " WHERE trfaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                            " GROUP BY Trfaktur.KdFaktur, MBM.KdBahanMentah " & _
                            " ORDER BY NamaBahanMentah asc "
            End If

            Dim reader = execute_reader(sql_faktur)

            Dim idxfaktur = 0
            gridBarang.Rows.Clear()
            Do While reader.Read
                If idxfaktur = 0 Then
                    txtSales.Text = reader("NamaSales")
                    txtToko.Text = reader("NamaToko")
                    lblDaerah.Text = reader("Daerah")
                    kdsales = reader("KdSales")
                    kdtoko = reader("KdToko")
                    isPaid = reader("StatusPayment")
                    txt_disc_retur.Text = reader("disc_faktur")
                End If

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPartNo").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHargaDisc").Value = FormatNumber(reader("HargaDisc"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyFaktur").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmSubtotal").Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmStatus").Value = "- Klik disini -"
                idxfaktur += 1
            Loop
            reader.Close()

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
End Class
