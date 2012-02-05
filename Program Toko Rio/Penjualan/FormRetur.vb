Imports System.Data.SqlClient
Public Class FormRetur
    Dim tab As String
    Dim PK As String
    Dim type_retur = ""

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
        cmbCari.Items.Add("No. Faktur")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Nama Toko")
        cmbCari.Items.Add("Status Retur")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdRetur 'No. Retur',DATE_FORMAT(TanggalRetur,'%d %M %Y') Tanggal, " & _
              " retur.KdFaktur 'No. Faktur', NamaLengkap 'Nama User', NamaSales 'Nama Sales', " & _
              " NamaToko 'Nama Toko', retur.Grandtotal, " & _
              " CASE " & _
              "     WHEN StatusRetur = 0 THEN 'New' " & _
              "     WHEN StatusRetur = 1 THEN 'Confirm' " & _
              " End 'Status Retur' " & _
              " from  " & tab & " retur " & _
              " Join mssales ms On ms.kdsales = retur.kdsales " & _
              " Join mstoko mt On mt.kdtoko = retur.kdtoko " & _
              " Join msuser mu On mu.userid = retur.userid " & _
              " Where 1 " & _
              " And jenis_retur = '" & type_retur & "' "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Retur" Then
                col = "kdretur"
            ElseIf opt = "Tanggal Retur" Then
                col = "tanggalRetur"
            ElseIf opt = "No. Faktur" Then
                col = "retur.KdFaktur"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Nama Toko" Then
                col = "NamaToko"
            ElseIf opt = "Status Retur" Then
                col = " CASE " & _
                      "     WHEN StatusRetur = 0 THEN 'New' " & _
                      "     WHEN StatusRetur = 1 THEN 'Confirm' " & _
                      " End "
            End If

            If col = "tanggalRetur" Then
                sql &= " And DATE_FORMAT(tanggalretur, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(tanggalretur, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By StatusRetur asc, no_increment Desc "

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
        DataGridView1.Columns(2).Width = 100
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

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " trretur "
        PK = "  kdretur  "
        type_retur = data_carier(0)

        If type_retur = "klem" Then
            Me.Text = "Retur Klem Jadi"
        Else
            Me.Text = "Retur Paku"
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
            open_subpage("FormReturManagamen", "", type_retur)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Retur").Value
                open_subpage("FormReturManagamen", selected_cell, type_retur)
            Else
                msgInfo("Data retur tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
        viewAllData("", "")
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
        btnReset.PerformClick()
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Retur").Value
            open_subpage("FormReturManagamen", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub

    Private Sub ToolStripButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton1.Click
        If DataGridView1.RowCount <> 0 Then
            idPrint = DataGridView1.CurrentRow.Cells("No. Retur").Value
            Dim query As String

            Dim jenisRetur As String = ""
            Dim reader = execute_reader("select jenis_retur from trretur where kdretur ='" & idPrint & "'")
            If reader.Read Then
                jenisRetur = reader(0)
            End If
            reader.close()

            If jenisRetur = "klem" Then
                query = "select retur.KdRetur ,TanggalRetur,retur.KdSO , NamaSales ,  " & _
               " NamaToko, retur.Grandtotal, mp.KDBarang, NamaBarang, harga, qty, rd.disc,HargaDisc,  " & _
               " retur.KdFaktur,rd.StatusBarang from  trretur  retur " & _
               " join trreturdetail rd on rd.kdretur = retur.kdretur " & _
               " join msbarang mp on mp.kdbarang = rd.kdbarang " & _
               " Join mssales ms On ms.kdsales = retur.kdsales   " & _
               " Join mstoko mt On mt.kdtoko = retur.kdtoko   " & _
               " Join msuser mu On mu.userid = retur.userid  " & _
               " where  retur.kdretur='" & idPrint & "' "
            Else
                query = "select retur.KdRetur ,TanggalRetur,retur.KdSO , NamaSales ,  " & _
              " NamaToko, retur.Grandtotal,mp.KdBahanmentah  KDBarang,NamaBahanMentah NamaBarang, harga, qty, rd.disc,HargaDisc,  " & _
              " retur.KdFaktur,rd.StatusBarang from  trretur  retur " & _
              " join trreturdetail rd on rd.kdretur = retur.kdretur " & _
              " join msbahanmentah mp on mp.kdbahanmentah = rd.kdbarang  " & _
              " Join mssales ms On ms.kdsales = retur.kdsales   " & _
              " Join mstoko mt On mt.kdtoko = retur.kdtoko   " & _
              " Join msuser mu On mu.userid = retur.userid  " & _
              " where  retur.kdretur='" & idPrint & "' "
            End If
            '" where StatusRetur = 1 and retur.kdretur='" & idPrint & "' "
            dropviewM("viewCetakTrReturJual" & kdKaryawan)
            createviewM(query, "viewCetakTrReturJual" & kdKaryawan)
            flagLaporan = "retur_jual"
            open_subpage("CRPrintTransaksi")
        Else
            msgInfo("Pilih No retur yang mau dicetak")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Try
            If (DataGridView1.RowCount) Then
                If DataGridView1.CurrentRow.Cells("Status Retur").Value = "New" Then
                    Dim selected_cell = DataGridView1.CurrentRow.Cells("No. Retur").Value
                    If MsgBox("Anda yakin ingin menghapus kode retur " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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
