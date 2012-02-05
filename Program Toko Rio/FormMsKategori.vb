Imports System.Data.SqlClient

Public Class FormMsKategori
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
        txtNoPolisi.Text = ""
        txtCari.Text = ""
    End Sub
    Private Sub setData()
        Try
            If DataGridView1.RowCount Then
                txtID.Text = DataGridView1.CurrentRow.Cells(0).Value.ToString
                txtNoPolisi.Text = DataGridView1.CurrentRow.Cells(1).Value.ToString
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub generateCode()
        Dim code As String
        Dim angka As Integer
        Dim kode As String
        Dim reader = getCode("mskategori", "KdKategori")

        code = "KG"
        If reader.read Then
            kode = reader(0).ToString()
            angka = CInt(kode.Substring(2, 3))
        Else
            angka = 0
        End If
        reader.close()

        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 3 - len
            code += "0"
        Next
        code = code & (angka)
        txtID.Text = code
    End Sub
    Private Sub viewAllData(ByVal cr As String)
        sql = "select KdKategori,Kategori from  " & tab
        If cr <> "" Then
            sql = sql & "  where Kategori like '%" & cr & "%'"
        End If
        
        DataGridView1.DataSource = execute_datatable(sql)

    End Sub
    Private Sub ubahAktif(ByVal b As Boolean)
        txtID.Enabled = False
        txtNoPolisi.Enabled = b
        btnSave.Enabled = b
        btnCancel.Enabled = b
        btnExit.Enabled = Not b
        btnAdd.Enabled = Not b
        btnUpdate.Enabled = Not b
        btnDelete.Enabled = Not b
        DataGridView1.Enabled = Not b
        GroupBox1.Enabled = Not b
    End Sub

    Private Sub setGrid()
        With DataGridView1.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold
        End With
        DataGridView1.Columns(0).Width = 100
        DataGridView1.Columns(1).Width = 340
    End Sub

    Private Sub FormMsKategori_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsKategori "
        PK = "  KdKategori  "
        ubahAktif(False)
        viewAllData("")
        setData()
        setGrid()
    End Sub
    

    Private Sub txtNoPolisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNoPolisi.KeyPress
        If AscW(e.KeyChar) = 13 Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged
        viewAllData(txtCari.Text)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        txtCari.Text = ""
        viewAllData("")
    End Sub

    Private Sub DataGridView1_CellClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 And e.RowIndex <= DataGridView1.Rows.Count - 1 Then
            posisi = e.RowIndex
            setData()
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        generateCode()
        ubahAktif(True)
        status = "add"
        emptyField()
        txtNoPolisi.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ubahAktif(True)
        status = "update"
        txtNoPolisi.Focus()
        'cmbNoInvoice.Enabled = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtNoPolisi.Text <> "" Then
            If MsgBox("Apakah Anda yakin ingin menghapus kategori " & txtNoPolisi.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
                execute_update("delete from " & tab & " where  " & PK & " = '" & txtID.Text & "'")
                msgInfo("Data berhasil dihapus")
                posisi = 0
                viewAllData("")
                setData()
            End If
        Else
            msgInfo("Pilih data yang ingin dihapus")
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If txtNoPolisi.Text = "" Then
            msgInfo("Kategori harus diisi")
            txtNoPolisi.Focus()
        Else
            '  Dim tg As String = String.Format("{0:yyyy-MM-dd}", txtTgl.Value)
            If status = "add" Then
                Try
                    Dim reader = execute_reader("Select * from " & tab & " where kategori ='" & Trim(txtNoPolisi.Text) & "'")
                    If reader.Read Then
                        msgInfo("Kategori telah ada di dalam database")
                        txtNoPolisi.Text = ""
                        txtNoPolisi.Focus()
                        reader.Close()
                    Else
                        reader.Close()
                        sql = "insert into  " & tab & "  values('" + Trim(txtID.Text) + "','" & Trim(txtNoPolisi.Text) & "')"
                        Try
                            execute_update(sql)
                            viewAllData("")
                            ubahAktif(False)
                            msgInfo("Data berhasil disimpan")
                        Catch ex As Exception
                            msgWarning("Data tidak valid")
                            txtNoPolisi.Text = ""
                            txtNoPolisi.Focus()
                        End Try
                    End If
                Catch ex As Exception
                    msgWarning("Data tidak valid")
                    txtNoPolisi.Text = ""
                    txtNoPolisi.Focus()
                End Try
                ' reader.Close()
            ElseIf status = "update" Then
                Try
                    sql = "update   " & tab & "  set Kategori='" & Trim(txtNoPolisi.Text) & "'" & _
                    "  where  " & PK & "='" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtNoPolisi.Text = ""
                    txtNoPolisi.Focus()
                End Try
            End If
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If status = "add" Then
            posisi = 0
        End If
        ubahAktif(False)
        setData()
    End Sub
End Class