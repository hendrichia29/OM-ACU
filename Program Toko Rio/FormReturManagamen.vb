Imports System.Data.SqlClient
Public Class FormReturManagamen
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String = ""
    Dim Tipe As String = ""
    Dim SubCat As String = ""
    Dim kdsales As String = ""
    Dim kdtoko As String = ""

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
        lblProvinsi.Text = ""
        cmbStatusRetur.SelectedIndex = 0
    End Sub

    Function getRetur(Optional ByVal KdRetur As String = "")
        Dim sql As String = "Select * from trRetur order by kdRetur desc "

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
            Dim kdfaktur = ""
            Dim readerRetur = execute_reader(" select kdretur,DATE_FORMAT(Tanggalretur, '%m/%d/%Y') Tanggal, " & _
                            " faktur.kdfaktur, MS.KdSales, NamaSales, " & _
                            " MT.KdToko, NamaToko, MT.Daerah, NamaProvinsi,StatusRetur, " & _
                            " Status, Note from trretur retur " & _
                            " Join TrFaktur faktur On  faktur.kdfaktur = retur.kdfaktur " & _
                            " Join MsSales MS On MS.KdSales = faktur.KdSales " & _
                            " Join MsToko MT On MT.KdToko = faktur.KdToko " & _
                            " Join MsProvinsi MP On MP.KdProvinsi = MT.KdProvinsi" & _
                            " Where kdretur = '" & PK & "' ")
            If readerRetur.Read Then
                txtID.Text = readerRetur.Item(0)
                dtpRetur.Text = readerRetur.Item(1)
                lblDaerah.Text = readerRetur.Item(7)
                lblProvinsi.Text = readerRetur.Item(8)
                kdfaktur = readerRetur.Item(2)
                Sales = readerRetur.Item(3) & " - " & readerRetur.Item(4)
                Toko = readerRetur.Item(5) & " - " & readerRetur.Item(6)
                If readerRetur.Item(9) <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                cmbStatusRetur.Text = readerRetur.Item(10)
                txtNote.Text = readerRetur.Item(11)
            End If
            readerRetur.Close()
            txtSales.Text = Sales
            txtToko.Text = Toko
            cmbFaktur.Text = kdfaktur

            Dim reader = execute_reader(" Select MB.KdBarang,NamaBarang,Subkategori, " & _
                                    " Harga, Qty,Disc, " & _
                                    " IfNull(( select sum(Qty) from TrFakturDetail " & _
                                    " Join TrFaktur on TrFaktur.KdFaktur = TrFakturDetail.KdFaktur " & _
                                    " Where TrFaktur.KdFaktur = '" & cmbFaktur.Text & "' " & _
                                    " And KdBarang = retur.KdBarang " & _
                                    " And statusfaktur <> 0 ),0) - ifNull(( " & _
                                    " Select sum(Qty) from TrReturDetail " & _
                                    " Join TrRetur on TrRetur.KdRetur = TrReturDetail.KdRetur " & _
                                    " Where TrRetur.KdRetur <> retur.KdRetur " & _
                                    " And KdBarang = retur.KdBarang " & _
                                    " And KdFaktur = '" & cmbFaktur.Text & "' ),0) as QtyFaktur,StatusBarang " & _
                                    " from TrReturDetail retur " & _
                                    " Join MsBarang MB On retur.KdBarang = MB.KdBarang " & _
                                    " Join MsMerkTipe On MsMerkTipe.kdTipe = MB.kdTipe " & _
                                    " Join MsSubkategori On MsSubkategori.KdSub = MB.KdSub " & _
                                    " where kdretur = '" & PK & "' " & _
                                    " order by NamaBarang asc ")

            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim Subtotal = (Val(reader(3)) * Val(reader(4))) * ((100 - Val(reader(5))) / 100)

                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(0).Value = reader(0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(1).Value = reader(1)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(2).Value = reader(2)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(3).Value = FormatNumber(reader(3), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(4).Value = reader(6)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(5).Value = reader(5)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(6).Value = reader(4)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(7).Value = Subtotal
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(8).Value = reader(7)
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

    Public Sub setCmbFaktur()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbFaktur.Items.Clear()
        cmbFaktur.Items.Add("- Pilih Faktur -")
        If PK <> "" Then
            addQuery = " where exists( Select 1 from trretur where kdretur = '" & PK & "' And kdfaktur = trfaktur.kdfaktur )"
        Else
            addQuery = "where statusfaktur in (1,2)"
        End If

        Dim reader = execute_reader("Select kdfaktur from trfaktur " & addQuery & " order by kdfaktur asc")
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
        setCmbFaktur()
        emptyField()

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbFaktur.Focus()
    End Sub

    Private Sub generateCode()
        Dim code As String = "RT"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        'code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")

        'If bulan < 10 Then
        '    code += "0" + bulan.ToString
        'Else
        '    code += bulan.ToString
        'End If
        code += FormatDate

        Dim reader = getRetur()

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
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Function SaveReturDetail(ByVal flag As String)
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusFaktur = 3
        Dim StatusBarangList = 0

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells(3).Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells(6).Value)
            Dim disc = Val(gridBarang.Rows.Item(i).Cells(5).Value)
            Dim OP = "Plus"
            Dim Attribute = "QtyRetur_Plus"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells(0).Value
            Dim Stok = gridBarang.Rows.Item(i).Cells(4).Value
            Dim statusBarang = gridBarang.Rows.Item(i).Cells(8).Value

            If statusBarang = "Rusak" Then
                StatusBarangList = 1
            End If

            If Qty <> Stok Then
                statusFaktur = 2
            End If

            If Qty <> 0 Then
                If flag = 1 Then
                    StockBarang(Qty, OP, harga, KdBarang, Attribute, Trim(txtID.Text), "Form Retur", StatusBarangList)

                    Dim sqlRetur = " Update TrRetur set StatusRetur = '1' " & _
                        " Where kdretur = '" & Trim(txtID.Text) & "' "
                    execute_update_manual(sqlRetur)
                End If
                sqlDetail = "insert into TrReturDetail(KdRetur,KdBarang, Harga, " _
                               & " Qty, Disc,StatusBarang) values( " _
                               & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                               & " '" & harga & "', '" & Qty & "', " _
                               & " '" & disc & "','" & statusBarang & "')"
                execute_update_manual(sqlDetail)
            End If
        Next
        Dim sqlFaktur = " Update TrFaktur set StatusFaktur = '" & statusFaktur & "' " & _
                    " Where KdFaktur = '" & Trim(cmbFaktur.Text) & "' "
        execute_update_manual(sqlFaktur)
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbFaktur.SelectedIndex = 0 Then
            msgInfo("Faktur harus dipilih")
            cmbFaktur.Focus()
        ElseIf cmbStatusRetur.SelectedIndex = 0 Then
            msgInfo("Status faktur harus dipilih")
            cmbStatusRetur.Focus()
        Else
            Dim Grandtotal = ""
            Dim checkQty = 0

            For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                If gridBarang.Rows.Item(i).Cells(6).Value = 0 Then
                    checkQty = 0
                Else
                    checkQty = 1
                    If gridBarang.Rows.Item(i).Cells(8).Value = "- Klik disini -" Then
                        msgInfo("Klik status barang.")
                        gridBarang.Rows.Item(i).Cells(8).Selected = True
                        Return True
                        Exit Function
                    End If
                End If
            Next

            If checkQty = 0 Then
                msgInfo("Salah satu jumlah harus diisi lebih dari 0.")
                Return True
                Exit Function
            End If

            If (lblGrandtotal.Text <> "") Then
                Grandtotal = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")
            End If

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                If PK = "" Then
                    sql = " insert into  trretur  values('" + Trim(txtID.Text) + "', " & _
                          " '" & cmbFaktur.Text & "', " & _
                          " '" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdsales) & "','" & Trim(kdtoko) & "'," & _
                          " '" & Trim(Grandtotal) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "','" & cmbStatusRetur.Text & "')"

                    execute_update_manual(sql)
                Else
                    sql = "update   trretur  set  TanggalRetur='" & dtpRetur.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                    " kdFaktur='" & cmbFaktur.Text & "'," & _
                    " KdSales='" & Trim(kdsales) & "'," & _
                    " KdToko='" & Trim(kdtoko) & "'," & _
                    " GrandTotal='" & Trim(Grandtotal) & "', " & _
                    " Status='" & Trim(cmbStatusRetur.Text) & "', " & _
                    " Note='" & Trim(txtNote.Text) & "' " & _
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

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells(7).Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellClick
        If gridBarang.CurrentRow.Cells(8).Selected = True Then
            sub_form = New FormBrowseStatusRetur
            sub_form.showDialog(FormMain)
            gridBarang.CurrentRow.Cells(8).Value = data_carier(0)
            clear_variable_array()
        End If
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim BarangID = gridBarang.CurrentRow.Cells(0).Value
            Dim harga = Val(gridBarang.CurrentRow.Cells(3).Value.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells(6).Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells(5).Value)
            Dim stok = Val(gridBarang.CurrentRow.Cells(4).Value)

            If IsNumeric(qty) = False Then
                MsgBox("Jumlah harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells(6).Value = stok
                gridBarang.CurrentRow.Cells(6).Selected = True
            ElseIf qty > stok Then
                MsgBox("Jumlah tidak mencukupi persedian. Persedian saat ini adalah " & stok, MsgBoxStyle.Information, "Validation Error")
                qty = stok
                gridBarang.CurrentRow.Cells(6).Value = stok
                gridBarang.CurrentRow.Cells(6).Selected = True
            ElseIf IsNumeric(harga) = False Or harga < 1 Then
                MsgBox("Harga harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                harga = 1
                gridBarang.CurrentRow.Cells(3).Value = 1
                gridBarang.CurrentRow.Cells(3).Selected = True
            ElseIf IsNumeric(disc) = False Then
                MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
                disc = 0
                gridBarang.CurrentRow.Cells(5).Value = 0
                gridBarang.CurrentRow.Cells(5).Selected = True
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                gridBarang.CurrentRow.Cells(3).Value = TempHarga
            End If

            gridBarang.CurrentRow.Cells(7).Value = FormatNumber((Val(harga) * Val(qty)) * ((100 - Val(disc)) / 100), 0)

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub BrowseFaktur_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowseFaktur.Click
        Try
            sub_form = New FormBrowseFaktur
            sub_form.showDialog(FormMain)
            cmbFaktur.Text = data_carier(0)
            txtSales.Text = data_carier(1)
            txtToko.Text = data_carier(2)
            lblDaerah.Text = data_carier(4)
            lblProvinsi.Text = data_carier(3)
            kdsales = data_carier(5)
            kdtoko = data_carier(6)
            clear_variable_array()

            Dim reader = execute_reader(" Select MB.KdBarang,NamaBarang,Subkategori, " & _
                                        " Harga,Qty - ifnull(( Select sum(Qty) " & _
                                        " from TrReturDetail " & _
                                        " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                        " where KdBarang = faktur.KdBarang " & _
                                        " And KdFaktur = faktur.KdFaktur " & _
                                        " Group By KdFaktur ),0) Qty, " & _
                                        " Disc, faktur.StatusBarang " & _
                                        " from TrfakturDetail faktur " & _
                                        " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                                        " Join MsMerkTipe On MsMerkTipe.kdTipe = MB.kdTipe " & _
                                        " Join MsSubkategori On MsSubkategori.KdSub = MB.KdSub " & _
                                        " where Kdfaktur = '" & cmbFaktur.Text & "' " & _
                                        " order by NamaBarang asc ")

            gridBarang.Rows.Clear()
            Do While reader.Read
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(0).Value = reader(0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(1).Value = reader(1)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(2).Value = reader(2)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(3).Value = FormatNumber(reader(3), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(4).Value = reader(4)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(5).Value = reader(5)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(6).Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(7).Value = 0
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(8).Value = "- Klik disini -"
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbfaktur_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbFaktur.SelectedIndexChanged
        Dim reader = execute_reader(" Select MB.KdBarang,NamaBarang,Subkategori, " & _
                                    " Harga,Qty - ifnull(( Select sum(Qty) " & _
                                    " from TrReturDetail " & _
                                    " Join TrRetur On TrReturDetail.KdRetur = TrRetur.KdRetur " & _
                                    " where KdBarang = faktur.KdBarang " & _
                                    " And KdFaktur = faktur.KdFaktur " & _
                                    " Group By KdFaktur ),0) Qty, " & _
                                    " Disc, faktur.StatusBarang, " & _
                                    " MS.KdSales, NamaSales, " & _
                                    " MT.KdToko, NamaToko, MT.Daerah, NamaProvinsi " & _
                                    " from TrFakturDetail faktur " & _
                                    " Join trfaktur On faktur.kdfaktur = trfaktur.kdfaktur " & _
                                    " Join MsBarang MB On faktur.KdBarang = MB.KdBarang " & _
                                    " Join MsMerkTipe On MsMerkTipe.kdTipe = MB.kdTipe " & _
                                    " Join MsSubkategori On MsSubkategori.KdSub = MB.KdSub " & _
                                    " Join MsSales MS On MS.KdSales = trfaktur.KdSales " & _
                                    " Join MsToko MT On MT.KdToko = trfaktur.KdToko " & _
                                    " Join MsProvinsi MP On MP.KdProvinsi = MT.KdProvinsi" & _
                                    " where faktur.Kdfaktur = '" & cmbFaktur.Text & "' " & _
                                    " order by NamaBarang asc ")

        Dim idxfaktur = 0
        gridBarang.Rows.Clear()
        Do While reader.Read
            If idxfaktur = 0 Then
                txtSales.Text = reader(8)
                txtToko.Text = reader(10)
                lblDaerah.Text = reader(11)
                lblProvinsi.Text = reader(12)
                kdsales = reader(7)
                kdtoko = reader(9)
            End If

            gridBarang.Rows.Add()
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(0).Value = reader(0)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(1).Value = reader(1)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(2).Value = reader(2)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(3).Value = FormatNumber(reader(3), 0)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(4).Value = reader(4)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(5).Value = reader(5)
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(6).Value = 0
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(7).Value = 0
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(8).Value = "- Klik disini -"
            idxfaktur += 1
        Loop
        reader.Close()

        HitungTotal()
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub
End Class
