Imports System.Data.SqlClient

Public Class FormMsPaku
    Dim status As String
    Dim tab As String
    Dim PK As String
    Dim jenis As String = "Paku"
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
        txtQty.Text = ""
        txtHarga.Text = ""
        txtJualPerKg.Text = ""
        txtJualPerKarung.Text = ""
        txtPerKg.Text = 25
        cmbUkuran.SelectedIndex = 0
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtQty.Enabled = status
        txtHarga.Enabled = status

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
            txtQty.Text = DataGridView1.CurrentRow.Cells(4).Value.ToString
            txtHarga.Text = FormatNumber(DataGridView1.CurrentRow.Cells("Harga").Value.ToString, 0)
            txtJualPerKg.Text = FormatNumber(DataGridView1.CurrentRow.Cells("HargaJualKg").Value.ToString, 0)
            txtJualPerKarung.Text = FormatNumber(DataGridView1.CurrentRow.Cells("HargaJualKarung").Value.ToString, 0)
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
              " ifnull(( Select StockAkhir from BahanMentahHistory where jenis ='" & jenis & "' order by KdHistory desc limit 1 ),0) Stock, " & _
              " ifnull(( Select DATE_FORMAT( TanggalHistory,'%d/%m/%Y') TanggalHistory " & _
              " from BahanMentahHistory where jenis ='" & jenis & "' order by KdHistory desc limit 1 ),'00/00/0000') `Tanggal Stok` , " & _
              " Format(ifnull(( Select harga " & _
              " from msbahanmentahlist where jenis ='" & jenis & "' " & _
              " order by  KdBahanMentahList  desc limit 1 ),0), 0) `Harga`  " & _
              "  " & _
              " from  " & tab & _
              " left Join MsSupplier On MsSupplier.KdSupplier = " & tab & ".KdSupplier where isAktif='1' "
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
        'DataGridView1.Columns(5).Width = 150
    End Sub
    Public Sub setCmbJenis()
        cmbUkuran.Items.Clear()
        cmbUkuran.Items.Add("16")
        cmbUkuran.Items.Add("20")
        cmbUkuran.Items.Add("23")
        cmbUkuran.Items.Add("30")
        cmbUkuran.Items.Add("35")
        cmbUkuran.Items.Add("39")
        cmbUkuran.Items.Add("50")
    End Sub
    Private Sub FormMsPaku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        TAB = " MsBahanMentah "
        PK = "  KdBahanMentah "
        jenis = "Paku"
        satuan = "Kg"
        ubahAktif(False)
        viewAllData("", "")
        setData()
        setGrid()
        setCmbCari()
        setCmbJenis()
    End Sub

    Private Sub generateCode()
        Dim code As String = "PK"
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

        Dim reader = getCode("MsBahanMentah", "KdBahanMentah")

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
        txtQty.Visible = status
        lblQtyBintang.Visible = status
        txtHarga.Visible = status
        lblHargaBintang.Visible = status
        lblHarga.Visible = status
        Return False
    End Function
    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        generateCode()
        ubahAktif(True)
        status = "add"
        VisibleQty(True)
        emptyField()
        txtHarga.Focus()

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
            If MsgBox("Anda yakin ingin menghapus kode paku " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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
        If txtNama.Text = "" Then
            'msgInfo("Nama Karyawan harus diisi")
            txtNama.Focus()
        ElseIf Val(txtQty.Text) = 0 And status = "add" Then
            msgInfo("Jumlah harus diisi dan lebih besar dari 0")
            txtQty.Focus()
        Else

            Dim QtyUpdate_Plus = 0
            Dim QtyUpdate_Min = ""
            Dim QtyUpdate = 0
            Dim OP = ""
            Dim Attribute = ""
            StockAwal = StockAkhir
            If status = "add" Then
                If Val(txtQty.Text) = 0 Then
                    msgInfo("Jumlah harus diisi dan lebih besar dari 0")
                    txtQty.Focus()
                ElseIf Val(txtHarga.Text) = 0 Then
                    msgInfo("Harga harus diisi dan lebih besar dari 0")
                    txtQty.Focus()
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
                        msgInfo("Data telah ada..")
                    Else
                        sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "',NULL,'" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                        "" & Trim(cmbUkuran.Text) & ",'" & jenis & "','" & satuan & "','1')"

                        QtyUpdate_Plus = Val(txtQty.Text)
                        QtyUpdate = QtyUpdate_Plus
                        OP = "Plus"
                        Attribute = "QtyUpdate_Plus"

                        dbconmanual.Open()
                        Dim trans As MySql.Data.MySqlClient.MySqlTransaction

                        trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
                        Try
                            execute_update_manual(sql)
                            StockBahanMentah(QtyUpdate, OP, txtHarga.Text, Trim(txtID.Text), Attribute, "", "Form Klem", jenis)
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
                    sql = "update   " & tab & "  set  NamaBahanMentah='" & Trim(txtNama.Text) & (cmbUkuran.Text) & "', " & _
                          "Ukuran=" & Trim(cmbUkuran.Text) & "  " & _
                          "where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    '    txtNama.Text = ""
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
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtQty_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQty.KeyPress

    End Sub
End Class