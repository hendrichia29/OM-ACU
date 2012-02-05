Imports MySql.Data.MySqlClient

Public Class FormTrPO
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String = ""
    Dim tabelH As String
    Dim tabelD As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpSO.Text = Now()

        cmbToko.SelectedIndex = 0
        'lblDaerah.Text = ""
        'lblProvinsi.Text = ""
        emptyBarang()
    End Sub

    Private Sub emptyBarang()
        cmbBarang.SelectedIndex = 0
        txtHarga.Text = ""
        txtQty.Text = ""
        txtDisc.Text = "0"
    End Sub

    Function getSO(Optional ByVal KdSO As String = "")
        Dim sql As String = "Select * from  " & tabelH & " "

        If KdSO <> "" Then
            sql &= PK & " = '" & KdSO & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try

            Dim Sales = ""
            Dim Toko = ""
            Dim readerSO = execute_reader(" select KdSO,TanggalSO, MS.KdSales, NamaSales, " & _
                            " MT.KdToko, NamaToko, MT.Daerah, NamaProvinsi from SalesOrder SO " & _
                            " Join MsSales MS On MS.KdSales = SO.KdSales " & _
                            " Join MsToko MT On MT.KdToko = SO.KdToko " & _
                            " Join MsProvinsi MP On MP.KdProvinsi = MT.KdProvinsi" & _
                            " Where KdSO = '" & PK & "' ")
            If readerSO.Read() Then
                txtID.Text = readerSO.Item(0)
                dtpSO.Text = readerSO.Item(1)
                'lblDaerah.Text = readerSO.Item(6)
                'lblProvinsi.Text = readerSO.Item(7)
                Sales = readerSO.Item(2) & " - " & readerSO.Item(3)
                Toko = readerSO.Item(4) & " - " & readerSO.Item(5)
            End If
            readerSO.Close()


            cmbToko.Text = Toko
            Dim reader = execute_reader("Select MB.KdBarang,NamaBarang, " & _
                                    "Harga,Qty,Disc, " & _
                                    "isnull(( Select Top 1 StockAkhir " & _
                                    "from BarangHistory where isActive = 1 " & _
                                    "And KdBarang = SO.KdBarang " & _
                                    "order by KdBarangHistory desc ),0), SO.StatusBarang " & _
                                    "from SalesOrderDetail SO " & _
                                    "Join MsBarang MB On SO.KdBarang = MB.KdBarang " & _
                                    "where KdSO = '" & PK & "' " & _
                                    "order by NamaBarang asc")

            Do While reader.Read
                Dim Subtotal = (Val(reader(2)) * Val(reader(3))) * ((100 - Val(reader(4))) / 100)
                Dim StatusBarang = "Ready"

                If Val(reader(6)) = 1 Then
                    StatusBarang = "Pending"
                End If
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(0).Value = reader(0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(1).Value = reader(1)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(2).Value = FormatNumber(reader(2), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(3).Value = reader(3)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(4).Value = reader(4)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(5).Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(6).Value = reader(5)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(7).Value = reader(3)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(8).Value = StatusBarang
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
        gridBarang.ReadOnly = False
        gridBarang.Columns(0).Width = 100
        gridBarang.Columns(1).Width = 200
        gridBarang.Columns(2).Width = 220
        gridBarang.Columns(2).ReadOnly = False
        gridBarang.Columns(3).Width = 115
        gridBarang.Columns(3).ReadOnly = False
        gridBarang.Columns(4).Width = 115
        gridBarang.Columns(4).ReadOnly = False
        gridBarang.Columns(5).Visible = True

    End Sub


    Public Sub setCmbSupplier()

        Dim varT As String = ""
        cmbToko.Items.Clear()
        cmbToko.Items.Add("- Pilih Supplier -")
        sql = " Select * from MsSupplier" & _
              " where Nama <>'' order by Nama asc "
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

    Public Sub setCmbBarang()
        Dim varT As String = ""
        cmbBarang.Items.Clear()
        cmbBarang.Items.Add("- Pilih Barang -")
        Dim reader = execute_reader("Select KdBarang,NamaBarang from MsBarang  where NamaBarang <>'' order by NamaBarang asc")
        Do While reader.Read
            cmbBarang.Items.Add(reader(0) & " - " & reader(1))
        Loop
        reader.Close()
        If cmbBarang.Items.Count > 0 Then
            cmbBarang.SelectedIndex = 0
        End If
        reader.Close()
    End Sub
    Private Sub FormTrPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tabelH = " TrHeaderPO "
        tabelD = " TrDetailPO "
        PK = " No_PO "

        PK = data_carier(0)
        status = data_carier(1)

        setCmbSupplier()
        setCmbBarang()
        emptyField()

        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbToko.Focus()

        'insert to header pb temp
        Dim tabel As String = " TrHeaderPO_T "
        sql = "insert into " & tabel & " values ('" & txtID.Text & "')"
        Try
            execute_update(sql)
        Catch ex As Exception
            msgWarning("Gagal insert ke tabel temporary")
        End Try
    End Sub

    Private Sub generateCode()
        PK = "No_PO"
        Dim code As String = "PO"
        Dim angka As Integer
        Dim kode As String = ""
        Dim temp As String
        Dim bulan As Integer = CInt(Today.Month.ToString)
        code += Today.Year.ToString.Substring(2, 2)
        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If
      

        'generate code
        sql = " select top 1 " & PK & " from  " & tabelH & " order by " & PK & "  desc"
        MsgBox(sql)
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader(0)
        Else
            reader.Close()
            sql = " select top 1 " & PK & " from  " & tabelH & "_T  order by " & PK & "  desc"
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2(0)
            Else
                kode = ""
            End If
            reader2.Close()
        End If
        reader.Close()
        reader = Nothing

        If kode <> "" Then
            temp = kode.Substring(0, 6)
            If temp = code Then
                angka = CInt(kode.Substring(6, 4))
            Else
                angka = 0
            End If

        Else
            angka = 0
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Function SaveSODetail()
        Dim sqlHistory = ""
        Dim sqlDetail = ""
        Dim statusSO = ""

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBarang.Rows.Item(i).Cells(2).Value.ToString.Replace(".", "").Replace(",", "")
            Dim OldQty = Val(gridBarang.Rows.Item(i).Cells(7).Value)
            Dim Stok = Val(gridBarang.Rows.Item(i).Cells(6).Value)
            Dim Qty = Val(gridBarang.Rows.Item(i).Cells(3).Value)
            Dim OP = "Min"
            Dim Attribute = "QtySO_Min"
            Dim KdBarang = gridBarang.Rows.Item(i).Cells(0).Value

            

            sqlDetail = "insert into SalesOrderDetail(KdSO,KdBarang, Harga, " _
                           & " Qty, Disc,StatusBarang) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBarang & "', " _
                           & " '" & harga & "', '" & gridBarang.Rows.Item(i).Cells(3).Value & "', " _
                           & " '" & gridBarang.Rows.Item(i).Cells(4).Value & "', '" & statusDetail & "')"
            execute_update(sqlDetail)
        Next
        Return statusSO
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If cmbToko.SelectedIndex = 0 Then
            msgInfo("Supplier harus dipilih")
            cmbToko.Focus()
        ElseIf gridBarang.RowCount = 0 Then
            msgInfo("Tambah barang terlebih dahulu")
            cmbBarang.Focus()
        Else
            Dim salesID = ""
            Dim tokoID = cmbToko.Text.ToString.Split("-")
            Dim Grandtotal = ""

            If (lblGrandtotal.Text <> "") Then
                Grandtotal = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")
            End If

            execute_update("delete from " & tabelD & " where  " & PK & " = '" & txtID.Text & "'")
            Dim statusSO = SaveSODetail()

            If status = "add" Then
                Try
                    sql = "insert into  " & tabelH & " values('" + Trim(txtID.Text) + "','-','" & kdKaryawan & "','" + dtpSO.Value.ToString("yyyy/MM/dd HH:mm:ss") + "', " & _
                    "NULL,NULL,NULL,NULL,0,0)"
                    execute_update(sql)
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                End Try
            ElseIf status = "update" Then
                'Try
                '    sql = "update   " & tabelH & "  set  TanggalSO='" & dtpSO.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                '    " KdSales='" & Trim(salesID(0)) & "'," & _
                '    " KdToko='" & Trim(tokoID(0)) & "'," & _
                '    " GrandTotal='" & Trim(Grandtotal) & "', " & _
                '    " StatusSO='" & Trim(statusSO) & "' " & _
                '    " where  KdSO = '" + txtID.Text + "' "
                '    Dim cmd As New SqlCommand(sql, db.Connection)
                '    cmd.ExecuteNonQuery()
                'Catch ex As Exception
                '    msgWarning(" Data tidak valid")
                'End Try
            End If
            msgInfo("Data berhasil disimpan")
            Me.Close()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Dim total = gridBarang.Rows.Item(i).Cells(5).Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            If cmbBarang.SelectedIndex = 0 Then
                msgInfo("Barang harus dipilih")
                cmbBarang.Focus()
            ElseIf txtHarga.Text = "" Then
                msgInfo("Harga harus diisi")
                txtHarga.Focus()
            ElseIf txtQty.Text = "" Then
                msgInfo("Jumlah harus diisi")
                txtQty.Focus()
            ElseIf txtQty.Text = "0" Then
                msgInfo("Jumlah harus lebih dari 0")
                txtQty.Focus()
            Else
                Dim barangID = cmbBarang.Text.ToString.Split("-")
                Dim harga = txtHarga.Text.ToString.Replace(".", "").Replace(",", "")
                Dim StatusBarang = ""


                For i As Integer = 0 To (gridBarang.RowCount - 1)
                    If gridBarang.Rows(i).Cells(0).Value.ToString = Trim(barangID(0)) Then
                        Dim addQty = Val(txtQty.Text) + gridBarang.Rows.Item(i).Cells(3).Value
                        Dim Subtot = (Val(harga) * Val(addQty)) * ((100 - Val(txtDisc.Text)) / 100)

                        gridBarang.Rows.Item(i).Cells(2).Value = FormatNumber(harga, 0)
                        gridBarang.Rows.Item(i).Cells(3).Value = addQty
                        gridBarang.Rows.Item(i).Cells(4).Value = Val(txtDisc.Text)
                        gridBarang.Rows.Item(i).Cells(5).Value = FormatNumber(Subtot, 0)
                        gridBarang.Rows.Item(i).Cells(6).Value = Val(lblStock.Text)
                        ' gridBarang.Rows.Item(i).Cells(8).Value = StatusBarang
                        Exit Sub
                    End If
                Next
                Dim Subtotal = (Val(harga) * Val(txtQty.Text)) * ((100 - Val(txtDisc.Text)) / 100)
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(0).Value = Trim(barangID(0))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(1).Value = Trim(barangID(1))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(2).Value = FormatNumber(harga, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(3).Value = Val(txtQty.Text)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(4).Value = Val(txtDisc.Text)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(5).Value = FormatNumber(Subtotal, 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(6).Value = Val(lblStock.Text)
                ' gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells(8).Value = StatusBarang

                HitungTotal()
                emptyBarang()

                gridBarang.Focus()
                'End If
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub



    Private Sub cmbToko_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbToko.SelectedIndexChanged
      
    End Sub

    Private Sub cmbBarang_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbBarang.SelectedIndexChanged
        If cmbBarang.SelectedIndex <> 0 Then
            Dim barangID = cmbBarang.Text.ToString.Split("-")
            sql = " Select Top 1 StockAkhir from BarangHistory where isActive = 1 And kdBarang = '" & barangID(0) & "' order by KdBarangHistory desc"
            Dim reader = execute_reader(sql)
            If reader.Read Then
                lblStock.Text = reader(0)
            End If
            reader.Close()
            txtHarga.Focus()
        Else
            lblStock.Text = 0
        End If
    End Sub

    Private Sub txtHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
            txtQty.Focus()
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtDisc.Text <> "" Then
            txtDisc.Focus()
        End If
    End Sub

    Private Sub txtDisc_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDisc.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQty.Text <> "" Then
            btnAdd_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub browseSales_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
 
    End Sub

    Private Sub browseToko_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseToko.Click
        Try
            sub_form = New FormBrowseToko
            sub_form.showDialog(FormMain)
            cmbToko.Text = data_carier(0) & " - " & data_carier(1)
            'lblDaerah.Text = data_carier(2)
            'lblProvinsi.Text = data_carier(3)
            clear_variable_array()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseBarang.Click
        Try
            sub_form = New FormBrowseBarang
            sub_form.showDialog(FormMain)
            cmbBarang.Text = data_carier(0) & " - " & data_carier(1)
            lblStock.Text = data_carier(2)
            clear_variable_array()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub txtHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.Leave
        If txtHarga.Text <> "" Then
            txtHarga.Text = FormatNumber(txtHarga.Text, 0)
        End If
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        Try
            gridBarang.Rows.RemoveAt(gridBarang.CurrentRow.Index)
            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim harga = Val(gridBarang.CurrentRow.Cells(2).Value.Replace(".", "").Replace(",", ""))
            Dim qty = Val(gridBarang.CurrentRow.Cells(3).Value)
            Dim disc = Val(gridBarang.CurrentRow.Cells(4).Value)
            Dim stok = Val(gridBarang.CurrentRow.Cells(6).Value)

            If IsNumeric(qty) = False Or qty < 1 Then
                MsgBox("Jumlah harus lebih besar dari 0 dan berupa angka.", MsgBoxStyle.Information, "Validation Error")
                qty = 1
                gridBarang.CurrentRow.Cells(3).Value = 1
                gridBarang.CurrentRow.Cells(3).Selected = True
              
            Else
                Dim TempHarga = FormatNumber(harga, 0)
                gridBarang.CurrentRow.Cells(2).Value = TempHarga
            End If
            gridBarang.CurrentRow.Cells(5).Value = FormatNumber((Val(harga) * Val(qty)) * ((100 - Val(disc)) / 100), 0)
            HitungTotal()
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub
End Class