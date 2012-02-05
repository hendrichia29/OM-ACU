Imports System.Data.SqlClient
Public Class FormBrowseKlemPantek
    Dim KdPantek As String
    Dim KdHitung = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select DISTINCT pantek.KdKlemMentah 'Kode Klem', " & _
              " NamaBahanMentah 'Nama Klem', Ukuran, " & _
              " SUM(QtyKlemMentahDiterima) - IFNULL( ( " & _
              " SELECT SUM(QtyKlemHitung) " & _
              " FROM trhitungdetail thd " & _
              " WHERE thd.KdHitung <> '" & KdHitung & "' " & _
              " AND thd.KdKlemHitung = pantek.KdKlemMentah " & _
              " GROUP BY thd.KdKlemHitung " & _
              " ), 0 ) Stok " & _
              " from  trpantek_diterima_detail pantek " & _
              " Join trpantek_diterima tr On tr.KdPantekDiterima = pantek.KdPantekDiterima " & _
              " Join MsBahanMentah MBM On MBM.KdBahanMentah = pantek.KdKlemMentah " & _
              " where StatusPantekDiterima = 1 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "Kode Klem" Then
                col = "pantek.KdKlemMentah"
            ElseIf opt = "Nama Klem" Then
                col = "NamaBahanMentah"
            End If

            sql &= "  And " & col & "  like '%" & cr & "%' "
        End If
        sql &= " GROUP BY pantek.KdKlemMentah " & _
               " HAVING Stok > 0 " & _
               " Order By NamaBahanMentah asc "
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
        cmbCari.Items.Add("Kode Klem")
        cmbCari.Items.Add("Nama Klem")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        viewAllData("", "")
        KdHitung = data_carier(0)
        data_carier(0) = ""
        setGrid()
        setCmbCari()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getPentekKeluar()
        'Try
        If gridToko.RowCount Then
            data_carier(0) = gridToko.CurrentRow.Cells("Kode Klem").Value
            data_carier(1) = gridToko.CurrentRow.Cells("Nama Klem").Value
        End If
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
        txtCari.Text = ""
        txtCari.Focus()
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub btnCari_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub
End Class
