Imports System.Data.SqlClient
Public Class FormMsBahanMentahTipe
    Dim status As String
    Dim posisi As Integer = 0
    Dim tab As String
    Dim jumData As Integer = 0
    Dim PK As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        txtCari.Text = ""
        txtNama.Text = ""
    End Sub

    Private Sub ubahAktif(ByVal status As Boolean)
        txtID.Enabled = False
        txtNama.Enabled = status

        btnSave.Enabled = status
        btnCancel.Enabled = status
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

        If DataGridView1.RowCount > 0 Then
            Try
                txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
                txtNama.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            Catch ex As Exception
            End Try
        End If
    End Sub

    Private Sub setCmbCari()
        cmbCari.Items.Clear()
        cmbCari.Items.Add("Tipe")
        cmbCari.SelectedIndex = 0
    End Sub

    Private Sub viewAllData(ByVal cr As String, ByVal opt As String)
        sql = "select KdBahanMentahTipe Kode,NamaBahanMentahTipe Tipe from  " & tab
        If opt <> "" Then
            Dim col As String = ""
            If opt = "Tipe" Then
                col = "NamaBahanMentahTipe"
            End If
            sql &= "  where " & col & "  like '%" & cr & "%'  and KdBahanMentahTipe <>'BT00000000'"
        Else
            sql &= "  where KdBahanMentahTipe <>'BT00000000'"
        End If
        DataGridView1.DataSource = execute_datatable(sql)
        jumData = DataGridView1.RowCount
        If jumData > 0 Then
            posisi = jumData
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
        DataGridView1.Columns(1).Width = 200

    End Sub

    Private Sub FormMsBahanMentahTipe_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsBahanMentahTipe "
        PK = "  KdBahanMentahTipe  "
        ubahAktif(False)
        viewAllData("", "")
        posisi = 0
        setData()
        setGrid()
        setCmbCari()
    End Sub

    Private Sub generateCode()
        Dim code As String = "BT"
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

        Dim reader = getCode("MsBahanMentahTipe", "KdBahanMentahTipe")

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
            posisi = e.RowIndex
            setData()
        End If
    End Sub

    Private Sub Button1_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("", "")
    End Sub

    Private Sub txtNama_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNama.KeyPress
        If Asc(e.KeyChar) = Asc("'") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtNama.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        emptyField()
        generateCode()
        ubahAktif(True)
        status = "add"
        txtNama.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        If (DataGridView1.RowCount) Then
            ubahAktif(True)
            status = "update"
            txtNama.Focus()
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If (DataGridView1.RowCount) Then
            Dim selected_cell = DataGridView1.CurrentRow.Cells(0).Value
            If MsgBox("Anda yakin ingin menghapus kode tipe " & selected_cell & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                execute_update("delete from " & tab & " where  " & PK & " = '" & selected_cell & "'")
                msgInfo("Data berhasil dihapus")
                posisi = 0
                viewAllData("", "")
                setData()
            End If
        Else
            msgInfo("Data tidak ditemukan.")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNama.Text = "" Then
            msgInfo("Tipe harus diisi")
            txtNama.Focus()
        Else
            If status = "add" Then
                sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "','" & Trim(txtNama.Text) & "')"
                Try
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                    'txtNoPolisi.Text = ""
                End Try
            ElseIf status = "update" Then
                Try
                    sql = "update   " & tab & "  set  NamaBahanMentahTipe='" & Trim(txtNama.Text) & "' where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("", "")
                    ubahAktif(False)

                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtNama.Text = ""
                End Try
            End If
        End If
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If status = "add" Then
            posisi = 0
        End If
        ubahAktif(False)
        setData()
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
