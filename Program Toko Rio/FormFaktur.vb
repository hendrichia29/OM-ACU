Imports System.Data.SqlClient
Public Class FormFaktur
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String

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
        cmbCari.Items.Add("No. SO")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Nama Toko")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdFaktur 'No. Faktur',DATE_FORMAT(Tanggalfaktur,'%d %M %Y') Tanggal, " & _
              " faktur.KdSO 'No. SO', NamaSales 'Nama Sales', " & _
              " NamaToko 'Nama Toko', faktur.Grandtotal, " & _
              " CASE WHEN StatusFaktur = 0 THEN 'New' WHEN StatusFaktur = 1 THEN 'Confirm' " & _
              " WHEN StatusFaktur = 2 THEN 'Retur Beberapa' " & _
              " WHEN StatusFaktur = 3 THEN 'Retur Semua' End 'Status Faktur' " & _
              " from  " & tab & " faktur " & _
              " Join trsalesorder so On so.kdso = faktur.kdso " & _
              " Join mssales ms On ms.kdsales = so.kdsales " & _
              " Join mstoko mt On mt.kdtoko = so.kdtoko " & _
              " Where 1 = 1 "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Faktur" Then
                col = "kdfaktur"
            ElseIf opt = "Tanggal Faktur" Then
                col = "tanggalfaktur"
            ElseIf opt = "No. SO" Then
                col = "faktur.kdso"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Nama Toko" Then
                col = "NamaToko"
            End If

            If col = "tanggalfaktur" Then
                sql &= " And DATE_FORMAT(tanggalfaktur, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and DATE_FORMAT(tanggalfaktur, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' " & _
                                   " and kdfaktur <>'FK00000000'"
            Else
                sql &= "  And " & col & "  like '%" & cr & "%'  and kdfaktur <>'FK00000000'"
            End If
        Else
            sql &= "  And kdfaktur <>'FK00000000'"
        End If

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
        ubahAktif(False)
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
            open_subpage("FormFakturManagamen")
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        Try
            If DataGridView1.RowCount <> 0 Then
                Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
                open_subpage("FormFakturManagamen", selected_cell)
            Else
                msgInfo("Data faktur tidak ditemukan.")
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
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
    End Sub

    Private Sub DataGridView1_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles DataGridView1.DoubleClick
        Try
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            open_subpage("FormFakturManagamen", selected_cell)
            viewAllData("", "")
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData("", cmbCari.Text)
    End Sub
End Class
