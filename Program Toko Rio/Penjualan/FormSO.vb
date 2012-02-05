Imports System.Data.SqlClient
Public Class FormSO
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String
    Public type_so As String = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

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
            '    TextBox1.Text = sql
            execute_update(sql)
            ' MsgBox("1")
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        btnExit.Enabled = Not status
        GroupBox1.Enabled = Not status

        btnAdd.Enabled = Not status
        btnUpdate.Enabled = Not status
        btnDelete.Enabled = Not status
        DataGridView1.Enabled = Not status
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. SO")
        cmbCari.Items.Add("Tanggal SO")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Nama Toko")
        cmbCari.Items.Add("Status")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select Distinct SO.KdSO 'No. SO',DATE_FORMAT(TanggalSO,'%d %M %Y') Tanggal, " & _
              " NamaLengkap 'Nama User', NamaSales 'Nama Sales', " & _
              " NamaToko 'Nama Toko', FORMAT(Grandtotal, 0) Grandtotal, " & _
              " CASE WHEN StatusSO = 0 THEN 'New' WHEN StatusSO = 1 THEN 'New' " & _
              " WHEN StatusSO = 2 THEN 'Faktur' WHEN StatusSO = 3 THEN 'Confirm' " & _
              " WHEN StatusSO = 4 THEN 'Faktur - Pending' End 'Status SO' " & _
              " from  " & tab & " SO " & _
              " Join trsalesorderdetail sodetail On sodetail.KdSO = SO.KdSO " & _
              " Join MsSales MS On MS.KdSales = SO.KdSales " & _
              " Join MsToko MT On MT.KdToko = SO.KdToko " & _
              " Join msuser mu On mu.userid = SO.userid " & _
              " Where 1 " & _
              " And StatusBarang <> 1 " & _
              " And jenis_so = '" & type_so & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. SO" Then
                col = "SO.KdSO"
            ElseIf opt = "Tanggal SO" Then
                col = "TanggalSO"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Nama Toko" Then
                col = "NamaToko"
            ElseIf opt = "Status" Then
                col = " CASE WHEN StatusSO = 0 THEN 'New' WHEN StatusSO = 1 THEN 'New' " & _
                      " WHEN StatusSO = 2 THEN 'Faktur' WHEN StatusSO = 3 THEN 'Confirm' " & _
                      " WHEN StatusSO = 4 THEN 'Faktur - Pending' End "
            End If

            If col = "TanggalSO" Then
                sql &= " And DATE_FORMAT(TanggalSO, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and DATE_FORMAT(TanggalSO, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusSO asc, no_increment Desc "

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        DataGridView1.Columns(0).Width = 120
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns(2).Width = 100
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
    End Sub

    Function visibleDate()
        dtpFrom.Visible = True
        dtpTo.Visible = True
        lblSeperator.Visible = True
        btnCari.Visible = True

        txtCari.Visible = False
        btnReset.Visible = False
        Return False
    End Function

    Function visibleCari()
        dtpFrom.Visible = False
        dtpTo.Visible = False
        lblSeperator.Visible = False
        btnCari.Visible = False

        txtCari.Visible = True
        btnReset.Visible = True
        Return False
    End Function

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " TrSalesOrder "
        PK = "  KdSO  "
        type_so = data_carier(0)

        If type_so = "klem" Then
            Me.Text = "Penjualan Klem Jadi"
        Else
            Me.Text = "Penjualan Paku"
        End If

        'ubahAktif(False)
        viewAllData("", "")
        posisi = 0
        setGrid()
        setCmbCari()
        visibleCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            posisi = e.RowIndex
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormSOManagamen", "", type_so)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormSOManagamen", selected_cell, type_so)
            Else
                msgInfo("Data SO tidak ditemukan.")
            End If

            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub cmbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCari.SelectedIndexChanged
        If cmbCari.SelectedIndex = 1 Then
            visibleDate()
        Else
            visibleCari()
        End If
        txtCari.Text = ""
        txtCari.Focus()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormSOManagamen", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells(6).Value = "New" Or DataGridView1.CurrentRow.Cells(6).Value = "Pending" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode pemesana " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusSO = 0 ")
                        msgInfo("Data berhasil dihapus")
                        viewAllData("", "")
                    End If
                Else
                    msgInfo("Data tidak dihapus. Hanya data yang memiliki status New yang dapat di hapus.")
                End If
            Else
                msgInfo("Data tidak ditemukan.")
            End If
        Catch ex As Exception
            msgInfo("Data tidak dapat dihapus.")
        End Try
    End Sub


    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click

        ' Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value

        ' open_subpage("print_sales_order", selected_cell)

        If DataGridView1.RowCount <> 0 Then
            idPrint = DataGridView1.CurrentRow.Cells(0).Value
            Dim jenisSO As String = ""
            Dim reader = execute_reader("select jenis_so from trsalesorder where kdSO ='" & idPrint & "'")
            If reader.Read Then
                jenisSO = reader(0)
            End If
            reader.close()

            Dim query As String
            If jenisSO = "klem" Then
                query = "select So.KdSO,TanggalSO,GrandTotal,StatusSO,SOD.KdBarang,NamaBarang, " & _
                        " HargaDisc `Harga`,SOD.Qty,SOD.Disc,Statusbarang,MS.NamaSales,MS.Alamat,MS.NoTelp NoTelpSales,MS.NoHP NoHPSales,  " & _
                        " MT.NamaToko,MT.AlamatToko,MT.Daerah,MT.NoTelp NoTelpCustomer,Mt.NoHP NoHPCustomer " & _
                        " from TrSalesOrder SO " & _
                        " join trSalesOrderdetail SOD on SOD.KdSO = so.kdso  " & _
                        " Join MsSales MS On MS.KdSales = SO.KdSales  " & _
                        " Join MsToko MT On MT.KdToko = SO.KdToko  " & _
                        " Join MsBarang MB On MB.KdBarang = SOD.KdBarang  " & _
                        " Join MsMerk On MsMerk.kdmerk = MB.kdMerk  " & _
                        " where so.KdSo='" & idPrint & "'"
               
            Else
                query = "select So.KdSO,TanggalSO,GrandTotal,StatusSO,MB.KdBahanMentah KdBarang,NamaBahanMentah NamaBarang, " & _
                        " HargaDisc `Harga`,SOD.Qty,SOD.Disc,Statusbarang,MS.NamaSales,MS.Alamat,MS.NoTelp NoTelpSales,MS.NoHP NoHPSales,  " & _
                        " MT.NamaToko,MT.AlamatToko,MT.Daerah,MT.NoTelp NoTelpCustomer,Mt.NoHP NoHPCustomer " & _
                        " from TrSalesOrder SO " & _
                        " join trSalesOrderdetail SOD on SOD.KdSO = so.kdso  " & _
                        " Join MsSales MS On MS.KdSales = SO.KdSales  " & _
                        " Join MsToko MT On MT.KdToko = SO.KdToko  " & _
                        " Join MsBahanMentah MB On MB.KdBahanMentah = SOD.KdBarang  " & _
                        " where so.KdSo='" & idPrint & "'"
               
            End If
            dropview("viewCetakTrSO" & kdKaryawan)
            createview(query, "viewCetakTrSO" & kdKaryawan)
            flagLaporan = "so"

            open_subpage("CRPrintTransaksi")
        Else
            msgInfo("Pilih SO yang mau dicetak")
        End If
    End Sub
End Class
