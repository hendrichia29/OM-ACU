Imports System.Data.SqlClient
Public Class FormBrowseBarang
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String
    Dim KdHitung = ""
    Dim ModuleName = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        Dim AddQuery = ""
        If KdHitung <> "" And ModuleName = "HitungKlem" Then
            AddQuery = " JOIN trhitungdetail_hasil thd ON MsBarang.KdBarang = thd.KdKlemJadi " & _
                       " AND thd.KdHitung = '" & KdHitung & "' "
        End If

        sql = " SELECT MsBarang.kdBarang Kode, NamaBarang 'Nama Barang', " & _
              " Merk, MsMerk.kdMerk, Ukuran, Satuan, " & _
              " IFNULL( SUM(msbaranglist.Qty),0)- IFNULL(( " & _
              "     SELECT SUM(Qty) " & _
              "     FROM TrSalesOrderDetail " & _
              "     JOIN TrSalesOrder ON TrSalesOrderDetail.kdso = TrSalesOrder.kdso " & _
              "     WHERE(KdBarang = MsBarangList.KdBarang) " & _
              "     AND StatusSo = 3 " & _
              "     GROUP BY KdBarang " & _
              " ),0) Stock, " & _
              " FORMAT(HargaList,0) 'Harga Jual' " & _
              " FROM MsBarang " & _
              " LEFT JOIN MsBarangList ON MsBarangList.KdBarang = MsBarang.KdBarang " & _
              " AND StatusBarangList = 0 " & _
              " JOIN MsMerk ON MsMerk.kdMerk =  MsBarang.kdMerk " & _
              AddQuery & _
              " WHERE 1 "

        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama Barang" Then
                col = "NamaBarang"
            ElseIf opt = "Merk" Then
                col = "Merk"
            ElseIf opt = "Ukuran" Then
                col = "Ukuran"
            ElseIf opt = "Satuan" Then
                col = "Satuan"
            End If
            sql &= "  And " & col & "  like '%" & cr & "%' "
        End If

        sql &= " GROUP BY MsBarang.KdBarang " & _
               " ORDER BY NamaBarang ASC "
        gridBarang.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridBarang.Columns("kdMerk").Visible = False
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama Barang")
        cmbCari.Items.Add("Merk")
        cmbCari.Items.Add("Ukuran")
        cmbCari.Items.Add("Satuan")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBarang "
        PK = "  KdBarang  "
        KdHitung = data_carier(0)
        ModuleName = data_carier(1)
        clear_variable_array()
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Function getBarang()
        Try
            If gridBarang.RowCount > 0 Then
                data_carier(0) = gridBarang.CurrentRow.Cells("Kode").Value
                data_carier(1) = gridBarang.CurrentRow.Cells("Nama Barang").Value
                data_carier(2) = gridBarang.CurrentRow.Cells("Merk").Value
                data_carier(3) = gridBarang.CurrentRow.Cells("Stock").Value
                data_carier(4) = gridBarang.CurrentRow.Cells("Harga Jual").Value
                data_carier(5) = gridBarang.CurrentRow.Cells("Harga Jual").Value
                data_carier(6) = gridBarang.CurrentRow.Cells("Harga Jual").Value
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
        getBarang()
        Me.Close()
    End Sub

    Private Sub gridBarang_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridBarang.DoubleClick
        getBarang()
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
