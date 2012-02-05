Imports System.Data.SqlClient
Public Class FormBrowseSupplier
    Dim tab As String
    Dim PK As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = "select kdsupplier Kode,Nama,Alamat,Daerah,NoTelp 'Nomor Telepon',NoHP 'Nomor HP',noFax 'Nomor Fax' from  " & tab

        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama Supplier" Then
                col = "Nama"
            ElseIf opt = "Alamat" Then
                col = "Alamat"
            ElseIf opt = "Daerah" Then
                col = "Daerah"
            ElseIf opt = "No Telp" Then
                col = "NoTelp"
            ElseIf opt = "No HP" Then
                col = "NoHP"
            ElseIf opt = "No Fax" Then
                col = "noFax"
            End If
            sql &= "  where " & col & "  like '%" & cr & "%'  and kdsupplier <>'SP00000000'"
        Else
            sql &= "  where kdsupplier <>'SP00000000'"
        End If

        gridSales.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridSales.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama Supplier")
        cmbCari.Items.Add("Alamat")
        cmbCari.Items.Add("Daerah")
        cmbCari.Items.Add("No Telp")
        cmbCari.Items.Add("No HP")
        cmbCari.Items.Add("No Fax")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsSupplier "
        PK = "  KdSupplier  "
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getSales()
        Try
            If gridSales.RowCount Then
                data_carier(0) = gridSales.CurrentRow.Cells(0).Value
                data_carier(1) = gridSales.CurrentRow.Cells(1).Value
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
        getSales()
        Me.Close()
    End Sub

    Private Sub gridSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridSales.DoubleClick
        getSales()
        Me.Close()
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub cmbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCari.SelectedIndexChanged
        txtCari.Text = ""
        txtCari.Focus()
    End Sub
End Class
