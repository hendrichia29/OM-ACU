Imports System.Data.SqlClient
Public Class FormBrowseHitungKeluar
    Dim KdHitungDiterima As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        Dim addQuery = ""

        sql = " select DISTINCT hitung.KdHitung 'No. Keluar',DATE_FORMAT(TanggalHitung,'%d %M %Y') Tanggal, " & _
              " NamaKaryawan 'Karyawan' , " & _
              " CASE WHEN StatusHitung = 0 THEN 'New' WHEN StatusHitung = 1 THEN 'Confirm' " & _
              " WHEN StatusHitung = 2 THEN 'Selesai' End 'Status Hitung' " & _
              " from  trhitung hitung " & _
              " Join trHitungdetail pd On pd.KdHitung = hitung.KdHitung " & _
              " Join mskaryawan MK On MK.KdKaryawan = hitung.KdKaryawan " & _
              " Join msuser mu On mu.userid = hitung.KdUser " & _
              " WHERE StatusHitung = 1 "

        If KdHitungDiterima = "" Then
            addQuery = " AND NOT EXISTS ( " & _
                       "    SELECT 1 FROM trhitung_diterima th " & _
                       "    WHERE th.KdHitung = hitung.KdHitung " & _
                       " ) "
        End If
        sql &= addQuery

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Keluar" Then
                col = "hitung.KdHitung"
            ElseIf opt = "Tanggal" Then
                col = "TanggalHitung"
            ElseIf opt = "Karyawan" Then
                col = "NamaKaryawan"
            End If

            If col = "TanggalHitung" Then
                sql &= " And DATE_FORMAT(TanggalHitung, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(TanggalHitung, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " Order By no_increment Desc "

        gridToko.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridToko.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. Keluar")
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Karyawan")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        KdHitungDiterima = data_carier(0)
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getPentekKeluar()
        Try
            If gridToko.RowCount Then
                data_carier(0) = gridToko.CurrentRow.Cells("No. Keluar").Value
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Information)
        End Try
        Return False
    End Function

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        getPentekKeluar()
        Me.Close()
    End Sub

    Private Sub gridSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridToko.DoubleClick
        getPentekKeluar()
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

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
        txtCari.Focus()
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCari.Click
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub
End Class
