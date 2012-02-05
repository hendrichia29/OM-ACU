Imports System.Data.SqlClient

Public Class FormTrPO
    Dim tab As String
    Dim PK As String
    Dim type_pb As String

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
        DataGridView1.Enabled = Not status
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. Penerimaan")
        cmbCari.Items.Add("Tanggal Penerimaan")
        cmbCari.Items.Add("No. PO")
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Status")
        cmbCari.Items.Add("Status Paid")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select PB.No_PB 'No. Penerimaan',DATE_FORMAT(Tanggal_TerimaBarang,'%d %M %Y') Tanggal, " & _
              " No_PO 'No. PO', MS.Nama 'Nama Supplier' ," & _
              " PB.GrandTotal `Grand Total`, " & _
              " CASE WHEN StatusTerimaBarang = 0 THEN 'New' WHEN StatusTerimaBarang = 1 THEN 'Confirm' " & _
              " WHEN StatusTerimaBarang = 2 THEN 'Retur Sebagian' " & _
              " WHEN StatusTerimaBarang = 3 THEN 'Retur Semua' " & _
              " End 'Status', " & _
              " CASE WHEN StatusPaid = 0 THEN 'Belum Lunas' WHEN StatusPaid = 1 THEN 'Lunas' " & _
              " End 'Status Paid' " & _
              " from  " & tab & " PB " & _
              " Join MsSupplier MS On MS.KdSupplier = PB.KdSupplier " & _
              " Join msuser mu On mu.userid = PB.userid " & _
              " Where 1 " & _
              " And jenis_pb = '" & type_pb & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Penerimaan" Then
                col = "No_PB"
            ElseIf opt = "No. PO" Then
                col = "PB.No_PO"
            ElseIf opt = "Tanggal Penerimaan" Then
                col = "Tanggal_TerimaBarang"
            ElseIf opt = "Nama Supplier" Then
                col = "MS.Nama"
            ElseIf opt = "Status" Then
                col = " CASE WHEN StatusTerimaBarang = 0 THEN 'New' WHEN StatusTerimaBarang = 1 THEN 'Confirm' " & _
                      " WHEN StatusTerimaBarang = 2 THEN 'Retur Sebagian' " & _
                      " WHEN StatusTerimaBarang = 3 THEN 'Retur Semua' END "
            ElseIf opt = "Status Paid" Then
                col = " CASE WHEN StatusPaid = 0 THEN 'Belum Lunas' WHEN StatusPaid = 1 THEN 'Lunas' " & _
                      " End "
            End If

            If col = "Tanggal_TerimaBarang" Then
                sql &= " And DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(Tanggal_TerimaBarang, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%'   "
            End If
        End If
        sql &= " Order By StatusTerimaBarang, no_increment Desc  "

        DataGridView1.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
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
    Private Sub FormTrPO_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " trheaderpb "
        PK = "  NO_PB"
        type_pb = data_carier(0)
        If type_pb = "klem" Then
            Me.Text = "Penerimaan Klem Mentah"
        ElseIf type_pb = "paku" Then
            Me.Text = "Penerimaan Paku"
        ElseIf type_pb = "klem_jadi" Then
            Me.Text = "Penerimaan Klem Jadi"
        Else
            Me.Close()
        End If

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
            open_subpage("FormPOManagement", "", type_pb)
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

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub


    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If DataGridView1.RowCount <> 0 Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormPOManagement", selected_cell, type_pb)
            viewAllData("", "")
        Else
            msgInfo("Data faktur tidak ditemukan.")
        End If
    End Sub

    Private Sub main_tool_strip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles main_tool_strip.ItemClicked

    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If DataGridView1.RowCount <> 0 Then
            idPrint = DataGridView1.CurrentRow.Cells(0).Value
            Dim query As String
            query = "select pb.No_PB,Tanggal_TerimaBarang,PO.NO_PO,Tanggal_PO,POD.kdbahanmentah,NamaBahanMentah,  " & _
           " POD.Harga,POD.Qty,MS.Nama,MS.Alamat,MS.Daerah,MS.NoTelp NoTelp,MS.NoHP NoHP   " & _
           "  from Trheaderpo PO " & _
           "  join trheaderpb pb on Pb.no_po = PO.no_po" & _
           "  join trdetailpb POD on Pb.no_pb = POD.no_pb" & _
           "  Join Mssupplier MS On MS.KdSupplier = PO.KdSupplier " & _
           "  Join MsBahanMentah MB On MB.KdBahanMentah = POD.kdbahanmentah where PB.no_pb='" & idPrint & "'"
            dropviewM("viewCetakPB" & kdKaryawan)
            createviewM(query, "viewCetakPB" & kdKaryawan)
            flagLaporan = "pb"
            open_subpage("CRPrintTransaksi")
        Else
            msgInfo("Pilih SO yang mau dicetak")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells("Status").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode penerimaan Bahan Mentah " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusTerimaBarang = 0 ")
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