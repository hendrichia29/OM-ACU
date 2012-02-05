Imports System.Data.SqlClient
Public Class FormBrowseBahanMentahPaku
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String
    Dim type_bahanmentah As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select MBM.kdBahanMentah Kode, MBM.NamaBahanMentah 'Nama', " & _
              "     MBM.Jenis, Ifnull( SUM(MBML.QTY), 0 ) Stock, " & _
              "     FORMAT(MBM.HargaJualKg,0) 'Harga Jual' " & _
              " from  " & tab & " MBM " & _
              " LEFT JOIN MsBahanMentahList MBML ON MBML.KdBahanMentah = MBM.KdBahanMentah " & _
              " Where 1 " & _
              " And MBM.Jenis = '" & type_bahanmentah & "' "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama" Then
                col = "MBM.NamaBahanMentah"
            ElseIf opt = "Kode" Then
                col = "MBM.kdBahanMentah"
            ElseIf opt = "Jenis" Then
                col = "MBM.Jenis"
            End If
            sql &= "  And " & col & "  like '%" & cr & "%' "
        End If
        sql &= " GROUP BY MBM.KdBahanMentah " & _
               " Order by MBM.NamaBahanMentah asc "

        gridBarang.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With

        If Val(gridBarang.CurrentRow.Cells("Stock").Value) < 0 Then
            gridBarang.CurrentRow.Cells("Stock").Value = 0
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Kode")
        cmbCari.Items.Add("Nama")
        cmbCari.Items.Add("Jenis")
        cmbCari.SelectedIndex = 1
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBahanMentah "
        PK = "  KdBahanMentah  "
        type_bahanmentah = data_carier(0)
        If type_bahanmentah = "" Then
            type_bahanmentah = "paku"
        End If
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs)
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Function getBarang()
        Try
            If gridBarang.RowCount Then
                data_carier(0) = gridBarang.CurrentRow.Cells("Kode").Value
                data_carier(1) = gridBarang.CurrentRow.Cells("Nama").Value
                data_carier(2) = gridBarang.CurrentRow.Cells("Stock").Value
                data_carier(3) = gridBarang.CurrentRow.Cells("Harga Jual").Value
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

    Private Sub cmbCari_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbCari.SelectedIndexChanged
        txtCari.Text = ""
        txtCari.Focus()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub
End Class
