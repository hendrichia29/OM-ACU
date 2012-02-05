Imports System.Data.SqlClient

Public Class FormTrPO_backup
    Dim status As String
    Dim tab As String
    Dim PK As String
    Public type_po As String = ""

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
        cmbCari.Items.Add("No. Pemesanan")
        cmbCari.Items.Add("Tanggal Pemesanan")
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Status")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select PO.No_PO 'No. Pemesanan',DATE_FORMAT(Tanggal_PO,'%d %M %Y') Tanggal, Nama 'Nama Supplier' ," & _
              " CASE WHEN StatusPO = 0 THEN 'New' WHEN StatusPO = 1 THEN 'Confirm' " & _
              " WHEN StatusPO = 2 THEN 'Barang Diterima' End 'Status Pemesanan' " & _
              " from  " & tab & " PO " & _
              " Left Join MsSupplier MS On MS.KdSupplier = PO.KdSupplier " & _
              " Join msuser mu On mu.userid = PO.userid " & _
              " Where 1 " & _
              " And jenis_po = '" & type_po & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Pemesanan" Then
                col = "PO.No_PO"
            ElseIf opt = "Tanggal Pemesanan" Then
                col = "Tanggal_PO"
            ElseIf opt = "Nama Supplier" Then
                col = "Nama"
            ElseIf opt = "Status" Then
                col = " CASE WHEN StatusPO = 0 THEN 'New' WHEN StatusPO = 1 THEN 'Confirm' " & _
                      " WHEN StatusPO = 2 THEN 'Barang Diterima' End "
            End If

            If col = "Tanggal_PO" Then
                sql &= " And DATE_FORMAT(Tanggal_PO, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(Tanggal_PO, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "

            Else
                sql &= "  And " & col & "  like '%" & cr & "%'   "

            End If
        End If
        sql &= " Order By StatusPO, no_increment Desc  "

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
        tab = " TrheaderPO "
        PK = "  NO_PO"
        type_po = data_carier(0)
        If type_po = "klem" Then
            Me.Text = "Penerimaan Klem Mentah"
        Else
            Me.Text = "Penerimaan Paku"
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

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick

    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormPOManagement", "", type_po)
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
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormPOManagement", selected_cell, type_po)
                viewAllData("", "")
            Else
                msgInfo("Data pemesanan tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If DataGridView1.RowCount <> 0 Then
            idPrint = DataGridView1.CurrentRow.Cells(0).Value
            'MsgBox("under construction")
            Dim query As String
            query = "select PO.NO_PO,Tanggal_PO,MB.KdBahanMentah,NamaBahanMentah,  " & _
              "    POD.Harga,POD.Jumlah,Ukuran,satuan,MS.Nama,MS.Alamat,MS.Daerah,MS.NoTelp NoTelp,MS.NoHP NoHP         " & _
              "    from Trheaderpo PO  " & _
              "    join trdetailpo POD on POD.no_po = PO.no_po " & _
              "    Join Mssupplier MS On MS.KdSupplier = PO.KdSupplier " & _
              "    Join MsBahanMentah MB On POD.KdBahanMentah = MB.KdBahanMentah  where PO.no_po='" & idPrint & "'"
            dropviewM("viewCetakPO" & kdKaryawan)
            createviewM(query, "viewCetakPO" & kdKaryawan)
            flagLaporan = "po"
            open_subpage("CRPrintTransaksi")
        Else
            msgInfo("Pilih SO yang mau dicetak")
        End If


    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells("Status Pemesanan").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode po " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusPO = 0 ")
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