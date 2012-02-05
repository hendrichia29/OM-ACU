Imports System.Data.SqlClient
Public Class FormBahanMentahHistory
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String
    Dim jenis = ""
    Dim jml_satuan2 = 0
    Dim nama_satuan2 = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub setData(ByVal sql As String)

        Dim reader = execute_reader(sql)

        While reader.read
            txtID.Text = reader(0).ToString
            txtNama.Text = reader("Nama").ToString
            txtUkuran.Text = reader("Ukuran").ToString
            txtJenis.Text = reader("Jenis").ToString
            txtQty.Text = reader("Stock").ToString
            txtQtyKg.Text = Val(txtQty.Text) * jml_satuan2
        End While
        reader.close()

        Dim sql_history = " select ifNull(sum(QtyRetur_Min),0) Retur, " & _
                          " IfNull(sum(QtyUpdate_Plus+QtyAdj_Plus),0) plus, " & _
                          " IfNull(sum(QtyUpdate_Min+QtyAdj_Min),0) min, " & _
                          " IfNull(sum(QtyPurchase_Plus),0) pb,IfNull(sum(QtyProd_Min),0) prod " & _
                          " from BahanMentahhistory where StatusBahanMentahList <> 1 and KdBahanMentah = '" & txtID.Text & "' "
        Dim reader_history = execute_reader(sql_history)

        txtPB.Text = 0
        txtReturPB.Text = 0
        txtProd.Text = 0
        txtUpdatePlus.Text = 0
        txtUpdateMin.Text = 0
        While reader_history.read
            txtPB.Text = reader_history("pb")
            txtReturPB.Text = reader_history("Retur")
            txtProd.Text = reader_history("prod")
            txtUpdatePlus.Text = reader_history("plus")
            txtUpdateMin.Text = reader_history("min")
        End While
        reader_history.close()
        txtTotalPlus.Text = Val(txtPB.Text) + Val(txtUpdatePlus.Text)
        txtTotalMin.Text = Val(txtTotalPlus.Text) - Val(txtProd.Text) - Val(txtReturPB.Text) - Val(txtUpdateMin.Text)

        Dim sql_stock
        sql_stock = " SELECT SUM(QtyKlemMentahDiterima) - IFNULL( ( " & _
                    " SELECT SUM(QtyKlemHitung) " & _
                    " FROM trhitungdetail " & _
                    " WHERE 1 " & _
                    " AND KdKlemHitung = tdd.KdKlemMentah " & _
                    " GROUP BY KdKlemHitung " & _
                    " ), 0 ) Stock " & _
                    " FROM trpantek_diterima td " & _
                    " JOIN trpantek_diterima_detail tdd ON td.KdPantekDiterima = tdd.KdPantekDiterima " & _
                    " WHERE StatusPantekDiterima = 1 " & _
                    " AND KdKlemMentah = '" & PK & "' " & _
                    " GROUP BY KdKlemMentah "
        Dim readerStock = execute_reader(sql_stock)
        Dim readyStock = 0
        If readerStock.read Then
            readyStock = Val(readerStock(0))
        End If
        txtKlemPantek.Text = readyStock
        readerStock.close()

    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select msbahanmentah.KdBahanMentah 'No. Part', " & _
              " NamaBahanMentah Nama, Ukuran, Jenis, " & _
              " ifnull(( Select StockAkhir from bahanmentahhistory " & _
              " where isActive = 1 And KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " order by KdHistory desc limit 1 ),0) Stock " & _
              " from  " & tab & _
              " Where msbahanmentah.KdBahanMentah = '" & PK & "' "

        Dim sql_stock = " select DATE_FORMAT(TanggalHistory,'%d %M %Y') Tanggal, StockAwal 'Stock Awal', " & _
                        " StockAkhir - StockAwal Qty, StockAkhir 'Stock Akhir', '" & nama_satuan2 & "' Satuan, " & _
                        " Module " & _
                        " from bahanmentahhistory " & _
                        " Where bahanmentahhistory.KdBahanMentah = '" & PK & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "Tanggal" Then
                col = "TanggalHistory"
            ElseIf opt = "Stock Awal" Then
                col = "StockAwal"
            ElseIf opt = "Qty" Then
                col = "StockAkhir - StockAwal"
            ElseIf opt = "Stock Akhir" Then
                col = "StockAkhir"
            ElseIf opt = "Module" Then
                col = "Module"
            End If

            If col = "TanggalHistory" Then
                sql_stock &= " And DATE_FORMAT(TanggalHistory, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                             " and DATE_FORMAT(TanggalHistory, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql_stock &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If

        gridStock.DataSource = execute_datatable(sql_stock)
        jumData = gridStock.RowCount
        setData(sql)

        gridStock.Columns(0).Width = 150
        gridStock.Columns(5).Width = 200
    End Sub

    Private Sub viewAllDataProd(ByVal cr As String, ByVal opt As String)
        Dim sql_stock = " select RefNumber 'No. Produksi', " & _
                        " DATE_FORMAT(TanggalHistory,'%d %M %Y') Tanggal,QtyProd_Min " & _
                        " from bahanmentahhistory " & _
                        " Where bahanmentahhistory.KdBahanMentah = '" & PK & "' " & _
                        " And ifNull(QtyProd_Min,0) <> 0 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Prod" Then
                col = "RefNumber"
            ElseIf opt = "Tanggal" Then
                col = "TanggalHistory"
            ElseIf opt = "Qty" Then
                col = "QtyProd_Min"
            End If

            If col = "TanggalHistory" Then
                sql_stock &= " And DATE_FORMAT(TanggalHistory, '%Y/%m/%d') >= '" & dtpFromProd.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and DATE_FORMAT(TanggalHistory, '%Y/%m/%d') <= '" & dtpToProd.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql_stock &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If

        gridProd.DataSource = execute_datatable(sql_stock)

        gridProd.Columns(1).Width = 150
    End Sub

    Private Sub viewAllDataPB(ByVal cr As String, ByVal opt As String)
        Dim sql_stock = " select trheaderpb.No_PB 'No. Penerimaan', DATE_FORMAT(Tanggal_TerimaBarang,'%d %M %Y') Tanggal, " & _
                        " No_PO 'No. PO', MS.Nama 'Supplier', Qty 'Jumlah ( Kg )', Qty_real 'Jumlah ( " & nama_satuan2 & " )' " & _
                        " from trdetailpb " & _
                        " Join trheaderpb On trheaderpb.No_PB = trdetailpb.No_PB " & _
                        " Join MsSupplier MS On trheaderpb.KdSupplier = MS.KdSupplier " & _
                        " Where trdetailpb.KdBahanMentah = '" & PK & "' " & _
                        " And StatusTerimaBarang <> 0 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Penerimaan" Then
                col = "trheaderpb.No_PB"
            ElseIf opt = "No. PO" Then
                col = "No_PO"
            ElseIf opt = "Tanggal" Then
                col = "Tanggal_TerimaBarang"
            ElseIf opt = "Supplier" Then
                col = "MS.Nama"
            ElseIf opt = "Qty" Then
                col = "Qty"
            End If

            If col = "Tanggal_TerimaBarang" Then
                sql_stock &= " And DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') >= '" & dtpFromPB.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') <= '" & dtpToPB.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql_stock &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If

        gridPB.DataSource = execute_datatable(sql_stock)
        gridPB.Columns(1).Width = 150
    End Sub

    Private Sub viewAllDataReturPB(ByVal cr As String, ByVal opt As String)
        Dim sql_stock = " select trheaderreturbeli.KdRetur 'No. Retur Penerimaan', DATE_FORMAT(TanggalRetur,'%d %M %Y') Tanggal, " & _
                        " No_PO 'No. PO', MS.Nama 'Supplier', sum(Qty) 'Jumlah ( Kg )', sum(Qty_real) 'Jumlah ( " & nama_satuan2 & " )' " & _
                        " from trdetailreturbeli " & _
                        " Join trheaderreturbeli On trheaderreturbeli.KdRetur = trdetailreturbeli.KdRetur " & _
                        " Join MsSupplier MS On trheaderreturbeli.KdSupplier = MS.KdSupplier " & _
                        " Where trdetailreturbeli.KdBahanMentah = '" & PK & "' " & _
                        " And StatusRetur <> 0 "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Retur Penerimaan" Then
                col = "trheaderreturbeli.KdRetur"
            ElseIf opt = "No. PO" Then
                col = "No_PO"
            ElseIf opt = "Tanggal" Then
                col = "TanggalRetur"
            ElseIf opt = "Supplier" Then
                col = "MS.Nama"
            ElseIf opt = "Qty" Then
                col = "Qty"
            End If

            If col = "TanggalRetur" Then
                sql_stock &= " And DATE_FORMAT(TanggalRetur, '%Y/%m/%d') >= '" & dtpFromReturPB.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and DATE_FORMAT(TanggalRetur, '%Y/%m/%d') <= '" & dtpToReturPB.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql_stock &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If

        gridReturPB.DataSource = execute_datatable(sql_stock & " Group by DATE_FORMAT(TanggalRetur,'%d %M %Y'),No_PO ")
        gridReturPB.Columns(1).Width = 150
    End Sub

    Private Sub setGrid()
        With gridStock.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Stock Awal")
        cmbCari.Items.Add("Qty")
        cmbCari.Items.Add("Stock Akhir")
        cmbCari.Items.Add("Module")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub setCmbCariProd()
        cmbCariProd.Items.Clear()
        cmbCariProd.Items.Add("No. Prod")
        cmbCariProd.Items.Add("Tanggal")
        cmbCariProd.Items.Add("Qty")
        cmbCariProd.SelectedIndex = 0
    End Sub

    Private Sub setCmbCariPB()
        cmbCariPB.Items.Clear()
        cmbCariPB.Items.Add("No. Penerimaan")
        cmbCariPB.Items.Add("Tanggal")
        cmbCariPB.Items.Add("No. PO")
        cmbCariPB.Items.Add("Supplier")
        cmbCariPB.Items.Add("Qty")
        cmbCariPB.SelectedIndex = 0
    End Sub

    Private Sub setCmbCariReturPB()
        cmbCariReturPB.Items.Clear()
        cmbCariReturPB.Items.Add("No. Retur Penerimaan")
        cmbCariReturPB.Items.Add("Tanggal")
        cmbCariReturPB.Items.Add("No. PO")
        cmbCariReturPB.Items.Add("Supplier")
        cmbCariReturPB.Items.Add("Qty")
        cmbCariReturPB.SelectedIndex = 0
    End Sub

    Function visibleDate()
        dtpFrom.Visible = True
        dtpTo.Visible = True
        lblSeperator.Visible = True
        btnCari.Visible = True
        btnReset2.Visible = True

        txtCari.Visible = False
        btnReset.Visible = False
        Return False
    End Function

    Function visibleCari()
        dtpFrom.Visible = False
        dtpTo.Visible = False
        lblSeperator.Visible = False
        btnCari.Visible = False
        btnReset2.Visible = False

        txtCari.Visible = True
        btnReset.Visible = True
        Return False
    End Function

    Function visibleDateProd()
        dtpFromProd.Visible = True
        dtpToProd.Visible = True
        lblSeperatorProd.Visible = True
        btnCariProd.Visible = True
        btnResetProd2.Visible = True

        txtCariProd.Visible = False
        btnResetProd.Visible = False
        Return False
    End Function

    Function visibleCariProd()
        dtpFromProd.Visible = False
        dtpToProd.Visible = False
        lblSeperatorProd.Visible = False
        btnCariProd.Visible = False
        btnResetProd2.Visible = False

        txtCariProd.Visible = True
        btnResetProd.Visible = True
        Return False
    End Function

    Function visibleDatePB()
        dtpFromPB.Visible = True
        dtpToPB.Visible = True
        lblSeperatorPB.Visible = True
        btnCariPB.Visible = True
        btnResetPB2.Visible = True

        txtCariPB.Visible = False
        btnResetPB.Visible = False
        Return False
    End Function

    Function visibleCariPB()
        dtpFromPB.Visible = False
        dtpToPB.Visible = False
        lblSeperatorPB.Visible = False
        btnCariPB.Visible = False
        btnResetPB2.Visible = False

        txtCariPB.Visible = True
        btnResetPB.Visible = True
        Return False
    End Function

    Function visibleDateReturPB()
        dtpFromReturPB.Visible = True
        dtpToReturPB.Visible = True
        lblSeperatorReturPB.Visible = True
        btnCariReturPB.Visible = True
        btnResetReturPB2.Visible = True

        txtCariReturPB.Visible = False
        btnResetReturPB.Visible = False
        Return False
    End Function

    Function visibleCariReturPB()
        dtpFromReturPB.Visible = False
        dtpToReturPB.Visible = False
        lblSeperatorReturPB.Visible = False
        btnCariReturPB.Visible = False
        btnResetReturPB2.Visible = False

        txtCariReturPB.Visible = True
        btnResetReturPB.Visible = True
        Return False
    End Function

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBahanMentah "
        PK = data_carier(0)
        jenis = data_carier(1)

        If jenis = "klem" Then
            jml_satuan2 = 30
            nama_satuan2 = "Karung"
            lblSatuan.Text = "/ Karung"
        Else
            jml_satuan2 = 25
            nama_satuan2 = "Kardus"
            lblSatuan.Text = "/ Kardus"
        End If

        clear_variable_array()
        visibleDate()
        setCmbCari()
        setCmbCariProd()
        setCmbCariPB()
        setCmbCariReturPB()
        viewAllData("", "")
        viewAllDataProd("", "")
        viewAllDataPB("", "")
        viewAllDataReturPB("", "")
        posisi = 0
        setGrid()
    End Sub

    Private Sub cmbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCari.SelectedIndexChanged
        If cmbCari.SelectedIndex = 0 Then
            visibleDate()
        Else
            visibleCari()
        End If
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnReset2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset2.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub cmbCariFaktur_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCariProd.SelectedIndexChanged
        If cmbCariProd.SelectedIndex = 1 Then
            visibleDateProd()
        Else
            visibleCariProd()
        End If
    End Sub

    Private Sub btnCariFaktur_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCariProd.Click
        viewAllDataProd("", cmbCariProd.Text)
    End Sub

    Private Sub btnResetFaktur_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetProd.Click
        txtCariProd.Text = ""
        viewAllDataProd("", "")
    End Sub

    Private Sub btnResetFaktur2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetProd2.Click
        txtCariProd.Text = ""
        viewAllDataProd("", "")
    End Sub

    Private Sub txtCariFaktur_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCariProd.TextChanged
        viewAllDataProd(txtCariProd.Text, cmbCariProd.Text)
    End Sub

    Private Sub cmbCariPB_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCariPB.SelectedIndexChanged
        If cmbCariPB.SelectedIndex = 1 Then
            visibleDatePB()
        Else
            visibleCariPB()
        End If
    End Sub

    Private Sub btnCariPB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCariPB.Click
        viewAllDataPB("", cmbCariPB.Text)
    End Sub

    Private Sub btnResetPB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetPB.Click
        txtCariPB.Text = ""
        viewAllDataPB("", "")
    End Sub

    Private Sub btnResetPB2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetPB2.Click
        txtCariPB.Text = ""
        viewAllDataPB("", "")
    End Sub

    Private Sub txtCariPB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCariPB.TextChanged
        viewAllDataPB(txtCariPB.Text, cmbCariPB.Text)
    End Sub

    Private Sub cmbCariReturPB_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbCariReturPB.SelectedIndexChanged
        If cmbCariReturPB.SelectedIndex = 0 Then
            visibleDateReturPB()
        Else
            visibleCariReturPB()
        End If
    End Sub

    Private Sub btnCariReturPB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCariReturPB.Click
        viewAllDataReturPB("", cmbCariReturPB.Text)
    End Sub

    Private Sub btnResetReturPB_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetReturPB.Click
        txtCariReturPB.Text = ""
        viewAllDataReturPB("", "")
    End Sub

    Private Sub btnResetReturPB2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnResetReturPB2.Click
        txtCariReturPB.Text = ""
        viewAllDataReturPB("", "")
    End Sub

    Private Sub txtCariReturPB_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCariReturPB.TextChanged
        viewAllDataReturPB(txtCariReturPB.Text, cmbCariReturPB.Text)
    End Sub

    Private Sub dtpToFaktur_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtpToProd.ValueChanged

    End Sub
End Class
