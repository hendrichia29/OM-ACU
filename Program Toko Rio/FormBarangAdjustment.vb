Imports System.Data.SqlClient
Public Class FormBarangAdjustment
    Dim status As String
    Dim tab As String
    Dim Stock As Integer = 0
    Dim PK As String = ""
    Dim type_adj = ""
    Dim jml_konversi = 0

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Function visibleHarga(ByVal status As Boolean)
        lblHarga.Visible = status
        txtHarga.Visible = status
        lblIDR.Visible = status
        Return True
    End Function

    Private Sub emptyField()
        txtHarga.Text = 0
        cmbPenyesuaian.SelectedIndex = 0
        txtQty.Text = 0
        txtHargaList.Text = 0
        If type_adj <> "klem_jadi" Then
            cmbQtyKg.Visible = True
            lblSatuanKg.Visible = True
            cmbQtyKg.SelectedIndex = 0
        Else
            cmbQtyKg.Visible = False
            lblSatuanKg.Visible = False
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Tanggal")
        cmbCari.Items.Add("Penyesuaian")
        cmbCari.Items.Add("Harga")
        cmbCari.Items.Add("Harga List")
        cmbCari.Items.Add("Jumlah")
        cmbCari.Items.Add("Note")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select KdAdj Kode,TanggalAdj Tanggal,Type Penyesuaian, Adj.KdBarang, " & _
              " ifnull(NamaBarang,NamaBahanMentah) 'Nama Barang', format(Harga, 0) Harga, " & _
              " format(Adj.HargaList, 0) 'Harga List', Qty Jumlah,Adj.Note " & _
              " from  " & tab & " Adj " & _
              " Left Join MsBarang On MsBarang.KdBarang = Adj.KdBarang " & _
              " Left Join MsBahanMentah On MsBahanMentah.KdBahanMentah = Adj.KdBarang " & _
              " where 1 " & _
              " And jenis_adj = '" & type_adj & "' "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Tanggal" Then
                col = "TanggalAdj"
            ElseIf opt = "Penyesuaian" Then
                col = "Type"
            ElseIf opt = "Harga" Then
            ElseIf opt = "Harga List" Then
                col = "Adj.HargaList"
                col = "Harga"
            ElseIf opt = "Jumlah" Then
                col = "Qty"
            ElseIf opt = "Note" Then
                col = "Note"
            End If
            sql &= "  And " & col & "  like '%" & cr & "%'  and KdAdj <>'AJ00000000'"
        Else
            sql &= "  And KdAdj <>'AJ00000000'"
        End If

        DataGridView1.DataSource = execute_datatable(sql)
        txtQty.Enabled = False
        cmbPenyesuaian.SelectedIndex = 0
        cmbPenyesuaian.Enabled = False
        cmbBarang.SelectedIndex = 0
        visibleHarga(False)
    End Sub

    Public Sub setCmbBarangJadi()
        Dim reader = execute_reader(" Select KdBarang,NamaBarang from MsBarang where 1 " & _
                                    " And NamaBarang <>'' order by NamaBarang asc")
        Dim varT As String = ""
        cmbBarang.Items.Clear()
        cmbBarang.Items.Add("- Pilih Barang -")
        Do While reader.Read
            cmbBarang.Items.Add(reader(0) & " - " & reader(1))
        Loop
        reader.Close()
        If cmbBarang.Items.Count > 0 Then
            cmbBarang.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Public Sub setCmbBahanMentah()
        Dim type_bahanmentah = ""
        If type_adj = "klem_mentah" Then
            type_bahanmentah = "klem"
        ElseIf type_adj = "paku" Then
            type_bahanmentah = "paku"
        End If
        Dim reader = execute_reader(" Select KdBahanMentah,NamaBahanMentah from MsBahanMentah where 1 " & _
                                    " And NamaBahanMentah <>'' " & _
                                    " And Jenis = '" & type_bahanmentah & "' " & _
                                    " order by NamaBahanMentah asc")
        Dim varT As String = ""
        cmbBarang.Items.Clear()
        cmbBarang.Items.Add("- Pilih Barang -")
        Do While reader.Read
            cmbBarang.Items.Add(reader(0) & " - " & reader(1))
        Loop
        reader.Close()
        If cmbBarang.Items.Count > 0 Then
            cmbBarang.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Function setCmbQty()
        cmbQtyKg.Items.Clear()
        cmbQtyKg.Items.Add("- Pilih -")
        For i As Integer = 1 To 100
            cmbQtyKg.Items.Add(i * Val(jml_konversi))
        Next
        Return True
    End Function

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " TrAdjusment "
        PK = "  KdAdj "
        type_adj = data_carier(0)
        If type_adj = "klem_jadi" Then
            Me.Text = "Penyesuaian Stock Klem Jadi"
            lblSatuan.Text = " / Pack"
            setCmbBarangJadi()
        ElseIf type_adj = "klem_mentah" Or type_adj = "paku" Then
            If type_adj = "klem_mentah" Then
                Me.Text = "Penyesuaian Stock Klem Mentah"
                lblSatuan.Text = " / Karung"
                jml_konversi = 25
            Else
                Me.Text = "Penyesuaian Stock Paku"
                lblSatuan.Text = " / Kardus"
                jml_konversi = 30
            End If
            setCmbBahanMentah()
            setCmbQty()
        End If
        emptyField()
        generateCode()
        viewAllData("", "")
        setGrid()
        setCmbCari()
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
        DataGridView1.Columns(3).Visible = False
        DataGridView1.Columns(4).Width = 100
        DataGridView1.Columns(5).Width = 100
        DataGridView1.Columns(6).Width = 100
    End Sub

    Function getADJ(Optional ByVal KdADJ As String = "")
        Dim sql As String = "Select * from TrAdjusment Order By KdAdj desc"
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub generateCode()
        Dim code As String = "AJ"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        'code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")

        'If bulan < 10 Then
        '    code += "0" + bulan.ToString
        'Else
        '    code += bulan.ToString
        'End If
        code += FormatDate

        Dim reader = getADJ()

        If reader.read Then
            kode = Trim(reader(0).ToString())
            temp = kode.Substring(0, 8)
            If temp = code Then
                angka = CInt(kode.Substring(8, 4))
            Else
                angka = 0
            End If
            reader.Close()
        Else
            angka = 0
            reader.Close()
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim harga_modal = reset_number_format(txtHarga.Text)
        Dim harga_jual = reset_number_format(txtHargaList.Text)
        If cmbBarang.SelectedIndex = 0 Then
            msgInfo("Barang harus dipilih")
            cmbBarang.Focus()
        ElseIf cmbPenyesuaian.SelectedIndex = 0 Then
            msgInfo("Penyesuaian harus dipilih")
            cmbPenyesuaian.Focus()
        ElseIf Val(txtQty.Text) = 0 Then
            msgInfo("Jumlah harus diisi  adn lebih besar dari 0")
            txtQty.Focus()
        ElseIf cmbPenyesuaian.SelectedIndex = 2 And (harga_modal = "" Or harga_modal = "0") Then
            msgInfo("harga harus diisi dan lebih besar dari 0")
            txtHarga.Focus()
        Else
            Dim barangID = cmbBarang.Text.ToString.Split("-")
            If harga_modal = "" Then
                harga_modal = 0
            End If
            sql = " insert into  TrAdjusment ( KdAdj, TanggalAdj, KdBarang, " & _
                  " TYPE, Harga, Qty, Note,  HargaList, jenis_adj ) " & _
                  " values('" + Trim(txtID.Text) + "',now(), " & _
                  " '" & Trim(barangID(0)) & "','" & Trim(cmbPenyesuaian.Text) & "'," & _
                  " '" & Val(Trim(harga_modal)) & "','" & txtQty.Text & "', " & _
                  " '" & txtNote.Text & "','" & Val(harga_jual) & "','" & type_adj & "')"

            Dim OP = ""
            Dim Attribute = ""
            If cmbPenyesuaian.Text = "-" Then
                OP = "Min"
                Attribute = "QtyAdj_Min"
            ElseIf cmbPenyesuaian.Text = "+" Then
                OP = "Plus"
                Attribute = "QtyAdj_Plus"
            End If

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try
                If type_adj = "klem_jadi" Then
                    StockBarang(txtQty.Text, OP, harga_jual, Trim(barangID(0)), Attribute, Trim(txtID.Text), "Form Adjusment")
                ElseIf type_adj = "klem_mentah" Then
                    StockBahanMentah(txtQty.Text, OP, harga_jual, Trim(barangID(0)), Attribute, Trim(txtID.Text), "Form Adjusment", "klem")
                ElseIf type_adj = "paku" Then
                    StockBahanMentah(txtQty.Text, OP, harga_jual, Trim(barangID(0)), Attribute, Trim(txtID.Text), "Form Adjusment", "paku")
                End If
                execute_update_manual(sql)
                trans.Commit()
                msgInfo("Data berhasil disimpan")
                generateCode()
                viewAllData("", "")
            Catch ex As Exception
                trans.Rollback()
                msgWarning("Data tidak valid pada Adjusment")
            End Try
            dbconmanual.Close()
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
            txtNote.Focus()
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQty.Text <> "" Then
            txtHarga.Focus()
        End If
    End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browseBarang.Click
        Try
            If type_adj = "klem_jadi" Then
                sub_form = New FormBrowseBarang
            ElseIf type_adj = "klem_mentah" Then
                data_carier(0) = "klem"
                sub_form = New FormBrowseBahanMentah
            ElseIf type_adj = "paku" Then
                data_carier(0) = "paku"
                sub_form = New FormBrowseBahanMentah
            End If
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbBarang.Text = data_carier(0) & " - " & data_carier(1)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub cmbBarang_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbBarang.SelectedIndexChanged
        If cmbBarang.SelectedIndex <> 0 Then
            Dim barangID = cmbBarang.Text.ToString.Split("-")
            sql = " Select StockAkhir, HargaJualKarung HargaList " & _
                  " from MsBahanMentah mbm " & _
                  " Left Join BahanMentahHistory bmh ON mbm.kdBahanMentah = bmh.kdBahanMentah " & _
                  " where isActive = 1 " & _
                  " And mbm.kdBahanMentah = '" & barangID(0) & "' "
            If type_adj = "klem_jadi" Then
                sql = " SELECT IFNULL(bh.StockAkhir,0), HargaList  " & _
                      " FROM MsBarang mb " & _
                      " LEFT JOIN BarangHistory bh ON mb.KdBarang = bh.KdBarang " & _
                      " WHERE IFNULL(bh.isActive,1) = 1 " & _
                      " And mb.kdBarang = '" & barangID(0) & "' " & _
                      " ORDER BY IFNULL(bh.KdBarangHistory,1) DESC " & _
                      " LIMIT 1 "
            ElseIf type_adj = "klem_mentah" Then
                sql &= " And mbm.Jenis = 'Klem' " & _
                       " limit 1 "
            ElseIf type_adj = "paku" Then
                sql &= " And mbm.Jenis = 'Paku' " & _
                       " limit 1 "
            End If
            Dim reader = execute_reader(sql)

            If reader.Read Then
                Stock = reader(0)
                txtHargaList.Text = FormatNumber(reader(1), 0)
                cmbPenyesuaian.Enabled = True
            Else
                Stock = 0
                txtHargaList.Text = 0
                cmbPenyesuaian.Enabled = True
            End If
            reader.Close()
            txtQty.Focus()
        End If
    End Sub

    Private Sub cmbPenyesuaian_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cmbPenyesuaian.SelectedIndexChanged
        If cmbBarang.SelectedIndex <> 0 Then
            txtQty.Enabled = True
            If cmbPenyesuaian.SelectedIndex = 2 Then
                visibleHarga(True)
            Else
                visibleHarga(False)
            End If
        Else
            txtQty.Enabled = False
            visibleHarga(False)
        End If
        txtQty.Focus()
    End Sub

    Private Sub txtNote_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNote.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtQty_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQty.TextChanged
        If cmbPenyesuaian.SelectedIndex = 1 And Val(txtQty.Text) > Val(Stock) Then
            msgInfo("Persediaan tidak mencukupi tidak mencukupi. Persediaan saat ini adalah " & Stock)
            txtQty.Text = Stock
        Else
            cmbQtyKg.Text = Val(txtQty.Text) * Val(jml_konversi)
        End If
    End Sub

    Private Sub txtHargaList_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaList.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
            txtNote.Focus()
        End If
    End Sub

    Private Sub txtHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.Leave
        If txtHarga.Text <> "" Then
            txtHarga.Text = FormatNumber(reset_number_format(txtHarga.Text), 0)
        End If
    End Sub

    Private Sub txtHargaList_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaList.Leave
        If txtHargaList.Text <> "" Then
            txtHargaList.Text = FormatNumber(reset_number_format(txtHargaList.Text), 0)
        End If
    End Sub

    Private Sub cmbQtyKg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQtyKg.SelectedIndexChanged
        txtQty.Text = Val(cmbQtyKg.Text) / Val(jml_konversi)
    End Sub

    Private Sub lblSatuanKg_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSatuanKg.Click

    End Sub

    Private Sub lblSatuan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles lblSatuan.Click

    End Sub
End Class
