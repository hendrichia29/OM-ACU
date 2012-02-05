Imports System.Data.SqlClient
Public Class FormBrowseSales
    Dim tab As String
    Dim PK As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select Distinct MsSales.kdSales Kode,NamaSales 'Nama Sales',Alamat, " & _
              " NoTelp 'Nomor Telepon',NoHP 'Nomor HP', Komisi " & _
              " from  " & tab

        Dim addQuery = ""
        If data_carier(0) = "payment" Then
            addQuery = " JOIN trfaktur ON MsSales.kdSales = trfaktur.kdSales " & _
                       " LEFT JOIN trsalespayment payment ON payment.KdFaktur = trfaktur.KdFaktur " & _
                       " And ( IfNull(PaidBy,0) = 0 Or IfNull(PaidBy,0) = 2 ) "
        End If
        sql &= addQuery & " Where 1 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Alamat" Then
                col = "Alamat"
            ElseIf opt = "Nomor Telepon" Then
                col = "NoTelp"
            ElseIf opt = "Nomor HP" Then
                col = "NoHP"
            End If
            sql &= "  And " & col & "  like '%" & cr & "%' "
        End If

        sql &= " ORDER BY NamaSales ASC "
        gridSales.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridSales.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridSales.Columns(0).Width = 100
        gridSales.Columns(1).Width = 100
        gridSales.Columns(2).Width = 100
        gridSales.Columns(3).Width = 100
        gridSales.Columns(4).Width = 100
        gridSales.Columns(5).Width = 100

    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Alamat")
        cmbCari.Items.Add("Nomor Telepon")
        cmbCari.Items.Add("Nomor HP")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsSales "
        PK = "  MsSales.KdSales  "
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
                data_carier(0) = gridSales.CurrentRow.Cells("Kode").Value
                data_carier(1) = gridSales.CurrentRow.Cells("Nama Sales").Value
                data_carier(2) = gridSales.CurrentRow.Cells("Komisi").Value
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
