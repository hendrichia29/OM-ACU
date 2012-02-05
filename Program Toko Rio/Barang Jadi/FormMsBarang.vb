Imports System.Data.SqlClient

Public Class FormMsBarang
    Dim statusAdd As String
    Dim tab As String
    Dim PK As String
    Dim jenis As String = ""
    Dim satuan As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        txtCari.Text = ""
        txtQty.Text = ""
        'txtHarga.Text = 0
        txtHargaJual.Text = 0
        cmbUkuran.SelectedIndex = 0
        cmbMerk.SelectedIndex = 0
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtHargaJual.Enabled = status
        If statusAdd = "Add" Then
            'txtHarga.Enabled = status
            txtQty.Enabled = status
        Else
            VisibleQty(False)
        End If

        btnSave.Enabled = status
        btnCancel.Enabled = status
        cmbUkuran.Enabled = status
        cmbMerk.Enabled = status

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
            cmbMerk.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString & " ~ " & DataGridView1.CurrentRow.Cells(5).Value.ToString
            txtHargaJual.Text = FormatNumber(reset_number_format(DataGridView1.CurrentRow.Cells("Harga Jual").Value), 0)
            txtQty.Text = DataGridView1.CurrentRow.Cells("Stock").Value.ToString
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Ukuran")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = " select kdBarang Kode,NamaBarang Nama, Ukuran,Satuan,msbarang.KdMerk,Merk, " & _
              " ifnull(( Select StockAkhir from BarangHistory where kdBarang = " & tab & ".KdBarang " & _
              " order by KdBarangHistory desc limit 1 ),0) Stock, " & _
              " ifnull(( Select DATE_FORMAT( TanggalHistory,'%d/%m/%Y') TanggalHistory " & _
              " from BarangHistory where kdBarang = " & tab & ".KdBarang " & _
              " order by KdBarangHistory desc limit 1 ),'00/00/0000') `Tanggal Stok`, " & _
              " Format(HargaList,0) as 'Harga Jual' " & _
              " from  " & tab & _
              " Join MsMerk On MsMerk.KdMerk = " & tab & ".KdMerk " & _
              " where isAktif='1' "
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Ukuran" Then
                col = "Ukuran"
            End If
            sql &= "  AND " & col & "  like '%" & cr & "%'  "
        End If

        sql &= " Order by kdBarang desc "
        DataGridView1.DataSource = execute_datatable(sql)
        If DataGridView1.RowCount > 0 Then
            setData()
        End If
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
        DataGridView1.Columns(2).Width = 130
        DataGridView1.Columns(3).Width = 100
        DataGridView1.Columns(4).Width = 100
    End Sub
    Public Sub setCmbJenis()
        cmbUkuran.Items.Clear()
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
    End Sub

    Public Sub setCmbMerk()
        Dim reader = execute_reader("Select * from MsMerk  where merk <>'' order by merk asc")
        Dim varT As String = ""
        cmbMerk.Items.Clear()
        cmbMerk.Items.Add("- Pilih Merk -")
        Do While reader.Read
            cmbMerk.Items.Add(reader(0) & " ~ " & reader(1))
        Loop
        reader.Close()
        If cmbMerk.Items.Count > 0 Then
            cmbMerk.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Private Sub FormMsBarang_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBarang "
        PK = "  KdBarang "
        jenis = ""
        satuan = "Pack"
        ubahAktif(False)
        viewAllData("", "")
        setGrid()
        setCmbCari()
        setCmbJenis()
        setCmbMerk()
        setData()
    End Sub
    Private Sub generateCode()
        Dim code As String = "BG"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)

        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If

        Dim reader = getCode("MsBarang", "KdBarang")

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

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub


    Function VisibleQty(ByVal status As Boolean)
        lblQty.Visible = status
        txtQty.Visible = status
        txtQty.Enabled = status
        lblQtyBintang.Visible = status
        'lblModal.Visible = status
        lblJml.Visible = status
        'txtHarga.Visible = status
        'txtHarga.Enabled = status
        'lblHargaBintang.Visible = status
        'lblHarga.Visible = status
        Return False
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        emptyField()
        generateCode()
        ubahAktif(True)
        statusAdd = "add"
        VisibleQty(True)
        txtQty.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (DataGridView1.RowCount) Then
            ubahAktif(True)
            statusAdd = "update"
            VisibleQty(False)
            cmbUkuran.Focus()
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (DataGridView1.RowCount) Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            If MsgBox("Anda yakin ingin menghapus kode barang " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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
        'Dim harga = reset_number_format(txtHarga.Text)
        Dim harga_jual = reset_number_format(txtHargaJual.Text)
        If txtNama.Text = "" Then
            msgInfo("harus diisi")
            txtNama.Focus()
        ElseIf Val(txtQty.Text) = 0 And statusAdd = "add" Then
            msgInfo("Kuantitas harus diisi dan lebih besar dari 0")
            txtQty.Focus()
            'ElseIf Val(harga) = 0 And statusAdd = "add" Then
            '    msgInfo("Harga Modal harus diisi dan lebih besar dari 0")
            '    txtHarga.Focus()
        ElseIf cmbMerk.SelectedIndex = 0 Then
            msgInfo("Merk harus dipilih")
            cmbMerk.Focus()
        ElseIf Val(harga_jual) = 0 Then
            msgInfo("Harga Jual harus diisi dan lebih besar dari 0")
            txtHargaJual.Focus()
        Else
            Dim merkID = cmbMerk.Text.ToString.Split("~")
            Dim QtyUpdate_Plus = 0
            Dim OP = ""
            Dim Attribute = ""

            If statusAdd = "add" Then

                If (txtQty.Text = "" Or txtQty.Text = 0) Then
                    msgInfo("Jumlah harus diisi dan lebih besar dari 0")
                    txtQty.Focus()
                    'ElseIf (harga = "" Or harga = 0) Then
                    '    msgInfo("Harga harus diisi dan lebih besar dari 0")
                    '    txtHarga.Focus()
                Else
                    Dim exists As Integer = 0
                    sql = " select * from  " & tab & " " & _
                          " where NamaBarang='" & Trim(txtNama.Text) & (cmbUkuran.Text) & "' " & _
                          " AND KdMerk = '" & merkID(0) & "' "
                    Dim reader = execute_reader(sql)
                    If reader.Read Then
                        exists = 1
                    Else
                        exists = 0
                    End If
                    reader.Close()
                    If exists = 1 Then
                        msgInfo("Data telah ada..")
                    Else

                        sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "','" & Trim(merkID(0)) & "','" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                          "" & (cmbUkuran.Text) & ",'" & satuan & "','1',NULL,'" & harga_jual & "')"

                        QtyUpdate_Plus = Val(txtQty.Text)
                        OP = "Plus"
                        Attribute = "QtyUpdate_Plus"

                        dbconmanual.Open()
                        Dim trans As MySql.Data.MySqlClient.MySqlTransaction

                        trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
                        Try
                            execute_update_manual(sql)
                            If QtyUpdate_Plus <> 0 Then
                                StockBarang(QtyUpdate_Plus, OP, harga_jual, Trim(txtID.Text), Attribute, "", "Form Barang")
                            End If
                            trans.Commit()

                            viewAllData("", "")
                            ubahAktif(False)
                            msgInfo("Data berhasil disimpan")
                        Catch ex As Exception
                            trans.Rollback()
                            msgWarning("Data tidak valid")
                        End Try
                        dbconmanual.Close()
                    End If
                End If
            ElseIf statusAdd = "update" Then
                Try
                    sql = " update   " & tab & "  set  NamaBarang='" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                          " Ukuran=" & Trim(cmbUkuran.Text) & ",kdmerk='" & merkID(0) & "', " & _
                          " HargaList='" & harga_jual & "' " & _
                          " where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning("Data tidak valid")

                End Try
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        statusAdd = ""
        ubahAktif(False)
        setData()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Private Sub txtHarga_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
    '    If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
    '        e.KeyChar = Nothing
    '    End If
    '    If AscW(e.KeyChar) = 13 And txtHarga.Text <> "" Then
    '        cmbMerk.Focus()
    '    End If
    'End Sub


    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        FormMsMerk.Show()
    End Sub

    Private Sub txtHargaJual_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHargaJual.KeyPress
        If e.KeyChar <> "." And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtHargaJual.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub Label9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label9.Click

    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        setData()
    End Sub

    Private Sub btnHistory_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHistory.Click
        Dim selected_cell = DataGridView1.CurrentRow.Cells("Kode").Value
        open_subpage("FormBarangHistory", selected_cell)
    End Sub

    'Private Sub txtHarga_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHarga.Leave
    '    If txtHarga.Text <> "" Then
    '        txtHarga.Text = FormatNumber(reset_number_format(txtHarga.Text), 0)
    '    End If
    'End Sub

    Private Sub txtHargaJual_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtHargaJual.Leave
        If txtHargaJual.Text <> "" Then
            txtHargaJual.Text = FormatNumber(reset_number_format(txtHargaJual.Text), 0)
        End If
    End Sub

    Private Sub cmbMerk_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbMerk.SelectedIndexChanged
        Dim merkID = cmbMerk.Text.ToString.Split("~")

        If cmbMerk.SelectedIndex = 0 Then
            txtNama.Text = "Merk -ukuran"
        Else
            txtNama.Text = merkID(1) & " -ukuran"
        End If
    End Sub
End Class