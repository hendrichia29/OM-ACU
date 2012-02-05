Imports System.Data.SqlClient

Public Class FormMsBahanMentah
    Dim status As String
    Dim tab As String
    Dim PK As String
    Dim jenis As String
    Dim StockAwal As Double
    Dim StockAkhir As Double
    Dim satuan As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        txtCari.Text = ""
        txtQtyKarung.Text = 0
        cmbQtyKg.SelectedIndex = 0
        txtHarga.Text = 0
        txtJualPerKg.Text = 0
        txtJualPerKarung.Text = 0
        cmbUkuran.SelectedIndex = 0
        If jenis = "Klem" Then
            txtPerKg.Text = 25
        Else
            txtPerKg.Text = 30
        End If
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtQtyKarung.Enabled = status
        cmbQtyKg.Enabled = status
        txtHarga.Enabled = status
        txtPerKg.Enabled = status
        txtJualPerKg.Enabled = status

        btnSave.Enabled = status
        btnCancel.Enabled = status
        cmbUkuran.Enabled = status

        btnExit.Enabled = Not status
        GroupBox1.Enabled = Not status

        btnSave.Enabled = status
        btnCancel.Enabled = status
        btnAdd.Enabled = Not status
        btnUpdate.Enabled = Not status
        btnDelete.Enabled = Not status
        DataGridView1.Enabled = Not status
    End Sub

    Private Sub setData()
        If DataGridView1.RowCount Then
            txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
            cmbUkuran.Text = DataGridView1.CurrentRow.Cells(2).Value.ToString
            txtQtyKarung.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            txtHarga.Text = FormatNumber(reset_number_format(DataGridView1.CurrentRow.Cells("Harga").Value), 0)
            txtJualPerKg.Text = FormatNumber(reset_number_format(DataGridView1.CurrentRow.Cells("HargaJualKg").Value), 0)
            txtJualPerKarung.Text = FormatNumber(reset_number_format(DataGridView1.CurrentRow.Cells("HargaJualKarung").Value), 0)
            txtPerKg.Text = DataGridView1.CurrentRow.Cells("KarungToKg").Value.ToString
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Ukuran")
        cmbCari.Items.Add("Supplier")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select kdBahanMentah Kode,NamaBahanMentah Nama, Ukuran, Satuan, " & _
              " ifnull(( Select StockAkhir from BahanMentahHistory where jenis ='" & jenis & "' " & _
              " And KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " order by KdHistory desc limit 1 ),0) Stock, " & _
              " ifnull(( Select DATE_FORMAT( TanggalHistory,'%d/%m/%Y') TanggalHistory " & _
              " from BahanMentahHistory where jenis ='" & jenis & "' " & _
              " And KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " order by KdHistory desc limit 1 ),'00/00/0000') `Tanggal Stok` , " & _
              " format(ifnull(( Select harga " & _
              " from msbahanmentahlist where jenis ='" & jenis & "' " & _
              " And KdBahanMentah = " & tab & ".KdBahanMentah " & _
              " order by  KdBahanMentahList  desc limit 1 ),0), 0) `Harga`,  " & _
              " format(HargaJualKg, 0) HargaJualKg, format(HargaJualKarung, 0) HargaJualKarung, " & _
              " KarungToKg " & _
              "  " & _
              " from  " & tab & _
              " where isAktif='1' "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Ukuran" Then
                col = "Ukuran"
            ElseIf opt = "Supplier" Then
                col = "NamaSupplier"
            End If
            sql &= "  AND " & col & "  like '%" & cr & "%'  "
        End If
        sql &= "  AND jenis='" & jenis & "'"
        sql &= " Order by kdBahanMentah desc "
        DataGridView1.DataSource = execute_datatable(sql)
        setData()

        Dim reader = execute_reader("Select StockAwal,StockAkhir from BahanMentahHistory  where jenis ='" & jenis & "' order by KdHistory desc limit 1")
        Do While reader.Read
            StockAwal = reader(0)
            StockAkhir = reader(1)
        Loop
        reader.Close()
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold
        End With
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 180
        DataGridView1.Columns(2).Width = 50
        DataGridView1.Columns(3).Width = 50
        DataGridView1.Columns(4).Width = 50
    End Sub

    Public Sub setCmbJenis()
        cmbUkuran.Items.Clear()
        If jenis = "Klen" Then
            cmbUkuran.Items.Add("4")
            cmbUkuran.Items.Add("5")
            cmbUkuran.Items.Add("6")
            cmbUkuran.Items.Add("7")
            cmbUkuran.Items.Add("8")
            cmbUkuran.Items.Add("9")
            cmbUkuran.Items.Add("10")
            cmbUkuran.Items.Add("12")
            cmbUkuran.Items.Add("14")
            cmbUkuran.Items.Add("17")
            cmbUkuran.Items.Add("19")
            cmbUkuran.Items.Add("22")
            cmbUkuran.Items.Add("29")
        Else
            cmbUkuran.Items.Add("16 m/m")
            cmbUkuran.Items.Add("20 m/m")
            cmbUkuran.Items.Add("23 m/m")
            cmbUkuran.Items.Add("30 m/m")
            cmbUkuran.Items.Add("35 m/m")
            cmbUkuran.Items.Add("39 m/m")
            cmbUkuran.Items.Add("50 m/m")
        End If
    End Sub

    Function setCmbQty()
        cmbQtyKg.Items.Clear()
        cmbQtyKg.Items.Add("- Pilih -")
        For i As Integer = 1 To 100
            cmbQtyKg.Items.Add(i * txtPerKg.Text)
        Next
        Return True
    End Function

    Private Sub FormMsKlem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBahanMentah "
        PK = "  KdBahanMentah "
        jenis = data_carier(0)
        Me.Text = "Master " & jenis
        If jenis = "Klem" Then
            txtNama.Text = "- Klem mentah -"
            txtPerKg.Text = 25
            lblKarung.Text = "/ Karung Or"
            lblJual.Text = "/ Karung"
            satuan = "Karung"
            lblSatuan.Text = "1 Karung ="
        Else
            txtNama.Text = "- Paku -"
            txtPerKg.Text = 30
            lblKarung.Text = "/ Kardus Or"
            lblJual.Text = "/ Kardus"
            satuan = "Kg"
            lblSatuan.Text = "1 Kardus ="
        End If
        setCmbQty()
        ubahAktif(False)
        viewAllData("", "")
        setGrid()
        setCmbCari()
        setCmbJenis()
        setData()
    End Sub
    Private Sub generateCode()
        Dim code As String
        Dim angka As Integer
        Dim kode As String
        Dim temp As String

        If jenis = "Klem" Then
            code = "KL"
        Else
            code = "PK"
        End If

        code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)

        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If

        Dim reader = getCode("MsBahanMentah", "KdBahanMentah", jenis)

        If reader.read Then
            kode = Trim(reader(0).ToString())
            temp = kode.Substring(0, 6)
            If temp = code Then
                angka = CInt(kode.Substring(6, 4))
            Else
                angka = 0
            End If
        Else
            angka = 0
        End If
        reader.close()

        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = Trim(code)
    End Sub

    Private Sub txtCari_TextChanged1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text, cmbCari.Text)
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            setData()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub


    Function VisibleQty(ByVal status As Boolean)
        lblQty.Visible = status
        txtQtyKarung.Visible = status
        cmbQtyKg.Visible = status
        lblQtyBintang.Visible = status
        lblKarung.Visible = status
        txtHarga.Visible = status
        lblHargaBintang.Visible = status
        lblHarga.Visible = status
        lblModal.Visible = status
        Return False
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        emptyField()
        generateCode()
        ubahAktif(True)
        status = "add"
        VisibleQty(True)
        txtQtyKarung.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (DataGridView1.RowCount) Then
            ubahAktif(True)
            status = "update"
            VisibleQty(False)
            cmbUkuran.Focus()
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (DataGridView1.RowCount) Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            If MsgBox("Anda yakin ingin menghapus kode " & jenis & " " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                execute_update("update " & tab & " set isAktif='0' where  " & PK & " = '" & selected_cell & "'")
                msgInfo("Data berhasil dihapus")
                viewAllData("", "")
                setData()
            End If
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim harga = reset_number_format(txtHarga.Text)
        Dim hargaJualKg = reset_number_format(txtJualPerKg.Text)
        Dim hargaJualKarung = reset_number_format(txtJualPerKarung.Text)

        If txtNama.Text = "" Then
            msgInfo("Nama " & jenis & " harus diisi")
            txtNama.Focus()
        ElseIf Val(txtQtyKarung.Text) = 0 Then
            msgInfo("Jumlah harus diisi")
            txtQtyKarung.Focus()
        ElseIf Val(harga) = 0 And status = "add" Then
            msgInfo("Harga moddal harus diisi dan lebih besar dari 0")
            txtHarga.Focus()
        ElseIf Val(hargaJualKg) = 0 And status = "add" Then
            msgInfo("Harga jual moddal harus diisi dan lebih besar dari 0")
            txtJualPerKg.Focus()
        ElseIf Val(hargaJualKarung) = 0 And status = "add" Then
            msgInfo("Harga jual moddal harus diisi dan lebih besar dari 0")
            txtJualPerKg.Focus()
        Else

            Dim QtyUpdate_Plus = 0
            Dim QtyUpdate_Min = ""
            Dim QtyUpdate = 0
            Dim OP = ""
            Dim Attribute = ""
            StockAwal = StockAkhir
            If status = "add" Then
                If Val(harga) = 0 Then
                    msgInfo("Harga harus diisi dan lebih besar dari 0")
                    txtHarga.Focus()
                Else
                    Dim exists As Integer = 0
                    sql = "select * from  " & tab & "  where NamaBahanMentah='" & Trim(txtNama.Text) & (cmbUkuran.Text) & "' "
                    Dim reader = execute_reader(sql)
                    If reader.Read Then
                        exists = 1
                    Else
                        exists = 0
                    End If
                    reader.Close()
                    If exists = 1 Then
                        msgInfo("Data telah ada .")
                    Else
                        sql = " insert into  " & tab & "  values('" + Trim(txtID.Text) + "',NULL,'" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                        " '" & Trim(cmbUkuran.Text) & "','" & jenis & "','" & satuan & "','1', " & _
                        " '" & hargaJualKg & "','" & hargaJualKarung & "','" & txtPerKg.Text & "')"

                        QtyUpdate_Plus = Val(txtQtyKarung.Text)
                        QtyUpdate = QtyUpdate_Plus
                        OP = "Plus"
                        Attribute = "QtyUpdate_Plus"

                        dbconmanual.Open()
                        Dim trans As MySql.Data.MySqlClient.MySqlTransaction

                        trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
                        Try
                            execute_update_manual(sql)
                            StockBahanMentah(QtyUpdate, OP, hargaJualKg, Trim(txtID.Text), Attribute, "", "Form " & jenis, jenis)
                            ubahAktif(False)
                            trans.Commit()
                            msgInfo("Data berhasil disimpan")
                            viewAllData("", "")
                        Catch ex As Exception
                            trans.Rollback()
                            MsgBox(ex.ToString, MsgBoxStyle.Information)
                        End Try
                        dbconmanual.Close()
                    End If
                End If
            ElseIf status = "update" Then
                Try
                    sql = " update   " & tab & "  set  NamaBahanMentah='" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                          " Ukuran='" & Trim(cmbUkuran.Text) & "', " & _
                          " HargaJualKg='" & Trim(hargaJualKg) & "', " & _
                          " HargaJualKarung='" & Trim(hargaJualKarung) & "', " & _
                          " KarungToKg='" & Trim(txtPerKg.Text) & "', " & _
                          " Satuan = '" & Trim(satuan) & "' " & _
                          " where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        ubahAktif(False)
        setData()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
            txtJualPerKg.Focus()
        End If
    End Sub


    Private Sub main_tool_strip_ItemClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.ToolStripItemClickedEventArgs) Handles main_tool_strip.ItemClicked

    End Sub

    Private Sub txtJualPerKg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJualPerKg.KeyPress
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
    End Sub

    Private Sub txtJualPerKg_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJualPerKg.Leave
        txtJualPerKg.Text = FormatNumber(reset_number_format(txtJualPerKg.Text), 0)
    End Sub

    Private Sub txtJualPerKg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJualPerKg.TextChanged
        Dim hargaJualKg = txtJualPerKg.Text.ToString.Replace(".", "").Replace(",", "")
        txtJualPerKarung.Text = FormatNumber(Val(hargaJualKg) * Val(txtPerKg.Text), 0)
    End Sub

    Private Sub txtPerKg_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtPerKg.KeyPress
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtPerKg.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtPerKg_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtPerKg.TextChanged
        Dim hargaJualKg = txtJualPerKg.Text.ToString.Replace(".", "").Replace(",", "")
        txtJualPerKarung.Text = FormatNumber(Val(hargaJualKg) * Val(txtPerKg.Text), 0)
    End Sub

    Private Sub txtID_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtID.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtID.Text <> "" Then
            cmbUkuran.Focus()
        End If
    End Sub

    Private Sub cmbUkuran_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUkuran.SelectedIndexChanged
        txtQtyKarung.Focus()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
        open_subpage("FormBahanMentahHistory", selected_cell, jenis)
    End Sub

    Private Sub txtHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.Leave
        If txtHarga.Text <> "" Then
            txtHarga.Text = FormatNumber(reset_number_format(txtHarga.Text), 0)
        End If
    End Sub

    Private Sub txtJualPerKarung_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJualPerKarung.Leave
        If txtJualPerKarung.Text <> "" Then
            txtJualPerKarung.Text = FormatNumber(reset_number_format(txtJualPerKarung.Text), 0)
        End If
    End Sub

    Private Sub txtQtyKarung_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKarung.KeyPress
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKarung.Text <> "" Then
            txtHarga.Focus()
        End If
    End Sub

    Private Sub txtQtyKarung_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyKarung.TextChanged
        cmbQtyKg.Text = Val(txtQtyKarung.Text) * Val(txtPerKg.Text)
    End Sub

    Private Sub cmbQtyKg_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbQtyKg.SelectedIndexChanged
        txtQtyKarung.Text = Val(cmbQtyKg.Text) / Val(txtPerKg.Text)
    End Sub
End Class