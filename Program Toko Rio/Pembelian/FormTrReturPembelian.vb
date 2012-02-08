Imports System.Data.SqlClient

Public Class FormTrReturPembelian
    Dim tab As String
    Dim PK As String
    Public type_retur As String = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
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
        cmbCari.Items.Add("No. Retur")
        cmbCari.Items.Add("Tanggal Retur")
        cmbCari.Items.Add("No. Penerimaan")
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Status Retur")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdRetur 'No. Retur',DATE_FORMAT(TanggalRetur,'%d %M %Y') Tanggal, " & _
              " retur.KdPB 'No. Penerimaan', NamaLengkap 'Nama User', " & _
              " Nama 'Nama Supplier', FORMAT(retur.Grandtotal,0) Grandtotal, " & _
              " CASE WHEN StatusRetur = 0 THEN 'New' WHEN StatusRetur = 1 THEN 'Confirm' " & _
              " End 'Status Retur' " & _
              " from  " & tab & " retur " & _
              " Join trheaderpb pb On pb.No_PB = retur.kdPB " & _
              " Join mssupplier mt On mt.kdsupplier = pb.kdsupplier " & _
              " Join msuser mu On mu.userid = retur.userid " & _
              " Where 1 " & _
              " And jenis_retur = '" & type_retur & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Retur" Then
                col = "kdretur"
            ElseIf opt = "Tanggal Retur" Then
                col = "tanggalRetur"
            ElseIf opt = "No. Penerimaan" Then
                col = "retur.kdPB"
            ElseIf opt = "Nama Supplier" Then
                col = "Nama"
            ElseIf opt = "Status Retur" Then
                col = " CASE WHEN StatusRetur = 0 THEN 'New' WHEN StatusRetur = 1 THEN 'Confirm' End "
            End If

            If col = "tanggalretur" Then
                sql &= " And DATE_FORMAT(tanggalretur, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(tanggalretur, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusRetur asc, retur.no_increment Desc "

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 100
        DataGridView1.Columns("No. Penerimaan").Width = 120
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Width = 100
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
    Private Sub FormTrReturPembelian_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " trheaderreturbeli "
        PK = "  kdretur  "
        type_retur = data_carier(0)

        If type_retur = "klem" Then
            Me.Text = "Retur Klem Mentah"
        Else
            Me.Text = "Retur Paku"
        End If

        ubahAktif(False)
        viewAllData("", "")
        setGrid()
        setCmbCari()
        visibleCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormTrReturPembelianM", "", type_retur)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormTrReturPembelianM", selected_cell, type_retur)
            Else
                msgInfo("Data retur tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
        viewAllData("", "")
    End Sub

    'Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    If (DataGridView1.RowCount) Then
    '        Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
    '        If MsgBox("Anda yakin ingin menghapus kode area " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
    '            Dim cmd As New SqlCommand("delete from " & tab & " where  " & PK & " = '" & selected_cell & "'", db.Connection)
    '            cmd.ExecuteNonQuery()
    '            msgInfo("Data berhasil dihapus")
    '            posisi = 0
    '            viewAllData("", "")
    '        End If
    '    Else
    '        msgInfo("Data tidak ditemukan.")
    '    End If
    'End Sub

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
            open_subpage("FormTrReturPembelianM", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub sales_order_main_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If DataGridView1.RowCount <> 0 Then
            idPrint = DataGridView1.CurrentRow.Cells(0).Value

            Dim query As String
            query = "select retur.KdRetur ,TanggalRetur,retur.KdPB `No Penerimaan` ,   " & _
           " Nama, retur.Grandtotal,mp.kdbahanmentah KDBarang,NamaBahanMentah NamaBarang, harga, rd.disc,rd.qty,  " & _
           " retur.Disc `DiscRetur` " & _
           " from  trheaderreturbeli  retur " & _
           " Join trheaderpb pb On pb.No_PB = retur.kdPB   " & _
           " join trdetailreturbeli rd on rd.kdretur = retur.kdretur " & _
           " join msbahanmentah mp on mp.kdbahanmentah = rd.kdbahanmentah " & _
           " Join mssupplier mt On mt.kdsupplier = pb.kdsupplier   " & _
           " Join msuser mu On mu.userid = retur.userid  " & _
           "where   retur.kdretur='" & idPrint & "' "
            'TextBox1.Text = query
            dropviewM("viewCetakTrReturBeliUS11010001") ' & kdKaryawan)
            createviewM(query, "viewCetakTrReturBeliUS11010001") ' & kdKaryawan)
            flagLaporan = "retur_beli"
            CRPrintTransaksi.Show()
        Else
            msgInfo("Pilih No retur yang mau dicetak")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells("Status Retur").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode retur pembelian " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusRetur = 0 ")
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
End Class