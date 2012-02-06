Imports System.Data.SqlClient
Public Class FormFaktur
    Dim tab As String
    Dim PK As String
    Dim type_faktur = ""

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
        cmbCari.Items.Add("No. Faktur")
        cmbCari.Items.Add("Tanggal Faktur")
        cmbCari.Items.Add("No. Pemesanan")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Nama Toko")
        cmbCari.Items.Add("Status Faktur")
        cmbCari.Items.Add("Status Pembayaran")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdFaktur 'No. Faktur',DATE_FORMAT(Tanggalfaktur,'%d %M %Y') Tanggal, " & _
              " faktur.KdSO 'No. SO',NamaLengkap 'Nama User', NamaSales 'Nama Sales', " & _
              " NamaToko 'Nama Toko',FORMAT(faktur.Jumlah,0) `Grandtotal Sblm Disc`,faktur.Disc `Diskon(%)`," & _
              " FORMAT(faktur.Grandtotal,0) `Grandtotal`, " & _
              " CASE WHEN StatusFaktur = 0 THEN 'New' WHEN StatusFaktur = 1 THEN 'Confirm' " & _
              " WHEN StatusFaktur = 2 THEN 'Retur Sebagian' " & _
              " WHEN StatusFaktur = 3 THEN 'Retur Semua' End 'Status Faktur', " & _
              " CASE WHEN StatusPayment = 0 THEN 'Belum Lunas' " & _
              " WHEN StatusPayment = 1 THEN 'Lunas' " & _
              " WHEN StatusPayment = 2 THEN 'Bayar Setengah' End 'Pembayaran', " & _
              " KdSJ `No Surat Jln`, " & _
              " DATE_FORMAT(TanggalSJ,'%d %M %Y') `Tgl Surat Jln` " & _
              " from  " & tab & " faktur " & _
              " Join trsalesorder so On so.kdso = faktur.kdso " & _
              " Join mssales ms On ms.kdsales = so.kdsales " & _
              " Join mstoko mt On mt.kdtoko = so.kdtoko " & _
              " Join msuser mu On mu.userid = faktur.userid " & _
              " Where 1 " & _
              " And jenis_faktur = '" & type_faktur & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Faktur" Then
                col = "kdfaktur"
            ElseIf opt = "Tanggal Faktur" Then
                col = "tanggalfaktur"
            ElseIf opt = "No. Pemesanan" Then
                col = "faktur.kdso"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Nama Toko" Then
                col = "NamaToko"
            ElseIf opt = "Status Faktur" Then
                col = " CASE WHEN StatusFaktur = 0 THEN 'New' " & _
                      " WHEN StatusFaktur = 1 THEN 'Confirm' " & _
                      " WHEN StatusFaktur = 2 THEN 'Retur Sebagian' " & _
                      " WHEN StatusFaktur = 3 THEN 'Retur Semua' End "
            ElseIf opt = "Status Pembayaran" Then
                col = " CASE WHEN StatusPayment = 0 THEN 'Belum Lunas' " & _
                      " WHEN StatusPayment = 1 THEN 'Lunas' " & _
                      " WHEN StatusPayment = 2 THEN 'Bayar Setengah' End "
            End If

            If col = "tanggalfaktur" Then
                sql &= " And DATE_FORMAT(tanggalfaktur, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(tanggalfaktur, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusFaktur asc, faktur.no_increment Desc "

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
        DataGridView1.Columns(2).Width = 120
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Width = 150
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
        tab = " trfaktur "
        PK = "  kdfaktur  "
        type_faktur = data_carier(0)

        If type_faktur = "klem" Then
            Me.Text = "Faktur Klem Jadi"
        Else
            Me.Text = "Faktur Paku"
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
        txtCari.Focus()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Try
            open_subpage("FormFakturManagamen", "", type_faktur)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormFakturManagamen", selected_cell, type_faktur)
                viewAllData("", "")
            Else
                msgInfo("Data faktur tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
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
        btnReset.PerformClick()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormFakturManagamen", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub print(ByVal type As String)
        idPrint = DataGridView1.CurrentRow.Cells(0).Value
        
        Dim jenisFaktur As String = ""
        Dim reader = execute_reader("select jenis_faktur from trfaktur where kdfaktur ='" & idPrint & "'")
        If reader.Read Then
            jenisFaktur = reader(0)
        End If
        reader.close()

        Dim query As String
        If jenisFaktur = "klem" Then
            query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBarang,NamaBarang,harga,qty,do.disc,HargaDisc, " & _
              "  ho.Disc DiscFaktur,ho.GrandTotal" & _
              "  from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO" & _
              "  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbarang mp on mp.KDBarang=do.KDBarang" & _
              "  join mstoko c on c.kdtoko = ho.kdtoko   where ho.KDFaktur='" & idPrint & "'"
            'TextBox1.Text = query
        Else
            query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBahanMentah KdBarang ,NamaBahanMentah NamaBarang,harga,qty,do.disc,HargaDisc,  " & _
              "  ho.Disc DiscFaktur,ho.GrandTotal" & _
              "  from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO " & _
              "  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbahanmentah mp on mp.KDBahanmentah=do.KDBarang " & _
              "  join mstoko c on c.kdtoko = ho.kdtoko  where ho.KDFaktur='" & idPrint & "'"
        End If
        If type = "faktur" Then
            dropviewM("viewCetakTrFakturUS11010001") ' & kdKaryawan)
            createviewM(query, "viewCetakTrFakturUS11010001") ' & kdKaryawan)
            flagLaporan = "faktur"
        Else
            dropviewM("viewCetakTrSuratJalanUS11010001") ' & kdKaryawan)
            createviewM(query, "viewCetakTrSuratJalanUS11010001") ' & kdKaryawan)
            flagLaporan = "sj"
        End If
        open_subpage("CRPrintTransaksi")
    End Sub
    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If DataGridView1.RowCount <> 0 Then
           
            print("faktur")
        Else
            msgInfo("Pilih Faktur yang mau dicetak")
        End If
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        If DataGridView1.RowCount <> 0 Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormBrowseTanggalSuratJalan", selected_cell)
        Else
            msgInfo("Pilih Faktur yang mau dicetak")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells(7).Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                    If MsgBox("Anda yakin ingin menghapus kode faktur " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                        execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "' And StatusFaktur = 0 ")
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
