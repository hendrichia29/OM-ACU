Imports System.Data.SqlClient
Public Class FormBrowseFaktur
    Dim status As String
    Dim tab As String
    Dim PK As String
    Dim type_faktur = ""
    Dim type_document = ""
    Dim KdPayment = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub
    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        Dim Having = ""
        sql = " select faktur.KdFaktur 'No. Faktur', " & _
              " DATE_FORMAT(Tanggalfaktur,'%d %M %Y') Tanggal, " & _
              " NamaLengkap 'Nama User', NamaSales 'Nama Sales', " & _
              " NamaToko 'Nama Toko', Daerah, " & _
              " (( 100 - faktur.disc ) / 100 ) * SUM( ( " & _
              "   tfd.Qty - IfNull(( " & _
              "     SELECT trd.Qty FROM trreturdetail trd " & _
              "     JOIN trretur tr ON tr.KdRetur = trd.KdRetur " & _
              "     WHERE tr.KdFaktur = tfd.KdFaktur " & _
              "     AND trd.KdBarang = tfd.KdBarang " & _
              "     GROUP BY trd.KdBarang " & _
              "   ), 0) ) * tfd.HargaDisc " & _
              " ) TotalFakur, " & _
              " IfNull(( " & _
              "     SELECT SUM(tsp.TotalSalesPayment) FROM trsalespayment tsp " & _
              "     WHERE tsp.KdFaktur = tfd.KdFaktur " & _
              "     AND tsp.kdsalesPayment <> '" & KdPayment & "' " & _
              "     GROUP BY tsp.KdFaktur " & _
              " ), 0) TelahBayar , " & _
              " CASE " & _
              "     WHEN Statusfaktur = 0 THEN 'New' " & _
              "     WHEN Statusfaktur = 1 THEN 'Confirm' " & _
              "     WHEN Statusfaktur = 2 THEN 'Retur Sebagian' " & _
              "     WHEN Statusfaktur = 3 THEN 'Retur Semua' " & _
              " End 'Status faktur', " & _
              " MS.KdSales, MT.KdToko, " & _
              " CASE " & _
              "     WHEN StatusPayment = 0 THEN 'Belum Lunas' " & _
              "     WHEN StatusPayment = 1 THEN 'Lunas' " & _
              "     WHEN StatusPayment = 2 THEN 'Bayar Setengah' " & _
              " End 'Status Pembayaran' " & _
              " from  " & tab & " faktur " & _
              " Join trfakturdetail tfd On tfd.KdFaktur = faktur.KdFaktur " & _
              " Join MsSales MS On MS.KdSales = faktur.KdSales " & _
              " Join MsToko MT On MT.KdToko = faktur.KdToko " & _
              " Join msuser mu On mu.userid = faktur.userid " & _
              " Where 1 " & _
              " And jenis_faktur = '" & type_faktur & "' "

        If KdPayment <> "" And type_document = "SalesPayment" Then
            sql &= " And exists( " & _
                   "    Select 1 from trsalesPayment " & _
                   "    where kdsalesPayment = '" & KdPayment & "' " & _
                   "    And kdfaktur = faktur.kdfaktur " & _
                   " ) " & _
                   " And StatusPayment <> 1 "
        ElseIf type_document = "SalesPayment" Then
            sql &= " And statusfaktur <> 0 " & _
                   " And StatusPayment <> 1 " & _
                   " And NOT EXISTS( " & _
                   "    Select 1 from trreturdetail trd " & _
                   "    Join trretur tr On tr.KdRetur = trd.KdRetur " & _
                   "    where tr.KdFaktur = faktur.KdFaktur " & _
                   "    And tfd.KdBarang = trd.KdBarang " & _
                   "    GROUP BY trd.KdBarang " & _
                   "    HAVING tfd.Qty - SUM(trd.Qty) < 1 " & _
                   " ) "
            Having &= " HAVING ( TotalFakur - TelahBayar ) > 0 "
        ElseIf KdPayment <> "" And type_document = "ReturFaktur" Then
            sql &= " And exists( " & _
                   "    Select 1 from trretur " & _
                   "    where kdretur = '" & PK & "' " & _
                   "    And KdFaktur = faktur.KdFaktur " & _
                   " ) "
        ElseIf type_document = "ReturFaktur" Then
            sql &= " And statusfaktur not in (0,3) " & _
                   " And NOT EXISTS ( " & _
                   "    Select 1 from trreturdetail trd " & _
                   "    Join trretur tr On tr.KdRetur = trd.KdRetur " & _
                   "    where tr.KdFaktur = faktur.KdFaktur " & _
                   "    And tfd.KdBarang = trd.KdBarang " & _
                   "    GROUP BY trd.KdBarang " & _
                   "    HAVING tfd.Qty - SUM(trd.Qty) < 1 " & _
                    " ) "
        End If
        data_carier(0) = ""
        data_carier(1) = ""

        If opt <> "" Then
            Dim col As String = ""
            If opt = "No. Faktur" Then
                col = "faktur.Kdfaktur"
            ElseIf opt = "Tanggal Faktur" Then
                col = "Tanggalfaktur"
            ElseIf opt = "Nama Sales" Then
                col = "NamaSales"
            ElseIf opt = "Nama Toko" Then
                col = "NamaToko"
            End If

            If col = "Tanggalfaktur" Then
                sql &= " And DATE_FORMAT(Tanggalfaktur, '%Y/%m/%d') >= '" & dtpFrom.Value.ToString("yyyy/MM/dd") & "' " & _
                       " and DATE_FORMAT(Tanggalfaktur, '%Y/%m/%d') <= '" & dtpTo.Value.ToString("yyyy/MM/dd") & "' "
            Else
                sql &= "  And " & col & "  like '%" & cr & "%' "
            End If
        End If
        sql &= " GROUP BY faktur.KdFaktur " & _
               Having & _
               " Order By no_increment Desc,StatusFaktur asc "
        gridToko.DataSource = execute_datatable(sql)
    End Sub

    Private Sub setGrid()
        With gridToko.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridToko.Columns(0).Width = 120
        gridToko.Columns(1).Width = 100
        gridToko.Columns(2).Width = 100
        gridToko.Columns(3).Width = 100
        gridToko.Columns(4).Width = 100
        gridToko.Columns(5).Width = 100
        gridToko.Columns(6).Width = 100
        gridToko.Columns("KdSales").Visible = False
        gridToko.Columns("KdToko").Visible = False

    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("No. Faktur")
        cmbCari.Items.Add("Tanggal Faktur")
        cmbCari.Items.Add("Nama Sales")
        cmbCari.Items.Add("Nama Toko")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub FormMsArea_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " Trfaktur "
        PK = "  Kdfaktur  "
        KdPayment = data_carier(0)
        type_faktur = data_carier(2)
        type_document = data_carier(1)
        viewAllData("", "")
        setGrid()
        setCmbCari()
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs)
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Function getFaktur()
        Try
            If gridToko.RowCount Then
                data_carier(0) = gridToko.CurrentRow.Cells("No. Faktur").Value
                data_carier(1) = gridToko.CurrentRow.Cells("Nama Sales").Value
                data_carier(2) = gridToko.CurrentRow.Cells("Nama Toko").Value
                data_carier(3) = gridToko.CurrentRow.Cells("Daerah").Value
                data_carier(4) = gridToko.CurrentRow.Cells("KdSales").Value
                data_carier(5) = gridToko.CurrentRow.Cells("KdToko").Value
                data_carier(6) = gridToko.CurrentRow.Cells("Status Pembayaran").Value
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
        getFaktur()
        Me.Close()
    End Sub

    Private Sub gridSales_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles gridToko.DoubleClick
        getFaktur()
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
