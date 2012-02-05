Imports System.Data.SqlClient
Public Class FormBrowseBahanMentah
    Dim status As String
    Dim tab As String
    Dim PK As String
    Dim type_bahanmentah As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select kdBahanMentah Kode,NamaBahanMentah 'Nama',MsBahanMentahTipe.KdBahanMentahTipe, " & _
              " NamaBahanMentahTipe Tipe, MsBahanMentahSubKategori.KdBahanMentahSubKategori," & _
              " BahanMentahSubKategori 'Sub Kategori', " & _
              " ( Select sum(Qty) From MsBahanMentahList " & _
              " Where KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " Group By KdBahanMentah ) Stock, " & _
              " ifnull(( Select Harga from msBahanMentahlist where KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " order by KdBahanMentahList asc limit 1 ),0) HargaAwal " & _
              " from  " & tab & _
              " Join MsBahanMentahTipe On MsBahanMentahTipe.KdBahanMentahTipe = " & tab & ".KdBahanMentahTipe" & _
              " Join MsBahanMentahSubKategori On MsBahanMentahSubKategori.KdBahanMentahSubKategori = " & tab & ".KdBahanMentahSubKategori " & _
              " Where 1 " & _
              " And Jenis = '" & type_bahanmentah & "' "

        sql &= QueryLevel(lvlKaryawan)
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Nama" Then
                col = "NamaBahanMentah"
            ElseIf opt = "Tipe" Then
                col = "NamaBahanMentahTipe"
            ElseIf opt = "Sub Kategori" Then
                col = "BahanMentahSubKategori"
            End If
            sql &= "  And " & col & "  like '%" & cr & "%'  and kdBahanMentah <>'BS00000000'"
        Else
            sql &= "  And kdBahanMentah <>'BS00000000'"
        End If
        sql &= " Order by NamaBahanMentah asc "

        gridBarang.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridBarang.Columns(0).Width = 100
        gridBarang.Columns(1).Width = 100
        gridBarang.Columns(2).Visible = False
        gridBarang.Columns(3).Width = 100
        gridBarang.Columns(4).Visible = False
        gridBarang.Columns(5).Width = 100
        gridBarang.Columns(6).Width = 100
        gridBarang.Columns(7).Width = 100

        If Val(gridBarang.CurrentRow.Cells(6).Value) < 0 Then
            gridBarang.CurrentRow.Cells(6).Value = 0
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Nama")
        cmbCari.Items.Add("Tipe")
        cmbCari.Items.Add("Sub Kategori")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBahanMentah "
        PK = "  KdBahanMentah  "
        type_bahanmentah = data_carier(0)
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
                data_carier(1) = gridBarang.CurrentRow.Cells(1).Value
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
