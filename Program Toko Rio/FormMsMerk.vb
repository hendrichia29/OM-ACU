Imports System.Data.SqlClient

Public Class FormMsMerk
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
        txtMerk.Text = ""
        txtIsi.Text = ""
        chkDefault.Checked = False
    End Sub
    Private Sub setData()
        Try
            If DataGridView1.RowCount Then
                txtID.Text = DataGridView1.CurrentRow.Cells("KdMerk").Value.ToString
                txtMerk.Text = DataGridView1.CurrentRow.Cells("Merk").Value.ToString
                txtIsi.Text = DataGridView1.CurrentRow.Cells("Isi").Value.ToString
                If DataGridView1.CurrentRow.Cells("Prioritas").Value.ToString Then
                    chkDefault.Checked = True
                    chkDefault.Visible = True
                Else
                    chkDefault.Checked = False
                    If Not CheckDefaultMerk() Then
                        chkDefault.Visible = True
                    Else
                        chkDefault.Visible = False
                    End If
                End If
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub generateCode()
        Dim code As String
        Dim angka As Integer
        Dim kode As String
        Dim reader = getCode("msmerk", "KdMerk")
        code = "MR"
        If reader.read Then
            kode = reader(0).ToString()
            angka = CInt(Val(kode.Substring(2, 3)))
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
        sql = "select KdMerk, Merk, Isi, Prioritas as Prioritas from  " & tab
        If cr <> "" Then
            sql = sql & "  where merk like '%" & cr & "%'"
        End If
        DataGridView1.DataSource = execute_datatable(sql)
        If Not CheckDefaultMerk() Then
            chkDefault.Visible = True
        Else
            chkDefault.Visible = False
            chkDefault.Checked = False
        End If
    End Sub
    Private Sub ubahAktif(ByVal b As Boolean)
        txtID.Enabled = False
        txtMerk.Enabled = b
        txtIsi.Enabled = b
        chkDefault.Enabled = b
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
        DataGridView1.Columns(1).Width = 200
    End Sub

    Private Sub FormMsMerk_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        'FormMsBarang.setCmbMerk()
        '  FormMsBarang.Timer1.Enabled = True
    End Sub

    Function CheckDefaultMerk()
        sql = " SELECT 1 FROM MsMerk " & _
              " WHERE Prioritas = 1 "
        Dim reader = execute_reader(sql)
        If Not reader.Read Then
            Return False
        End If
        Return True
    End Function

    Private Sub FormMsMerk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        tab = " MsMerk "
        PK = "  KdMerk  "
        ubahAktif(False)
        viewAllData("")
        setData()
        setGrid()
        If Not CheckDefaultMerk() Then
            chkDefault.Visible = True
        Else
            chkDefault.Visible = False
            chkDefault.Checked = False
        End If
    End Sub

    Private Sub txtNoPolisi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMerk.KeyPress
        If AscW(e.KeyChar) = 13 Then
            txtIsi.Focus()
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
        emptyField()
        generateCode()
        ubahAktif(True)
        status = "add"
        txtMerk.Focus()
    End Sub

    Private Sub btnUpdate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUpdate.Click
        ubahAktif(True)
        status = "update"
        txtMerk.Focus()
        'cmbNoInvoice.Enabled = False
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If txtMerk.Text <> "" Then
            If MsgBox("Apakah Anda yakin ingin menghapus merk " & txtMerk.Text & "?", MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Confirmation") = MsgBoxResult.Yes Then
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
        Dim chk_prioritas = 0
        If chkDefault.Checked Then
            chk_prioritas = 1
        End If
        If txtMerk.Text = "" Then
            msgInfo("Merk harus diisi")
            txtMerk.Focus()
        ElseIf CInt(Val(txtIsi.Text)) = 0 Then
            msgInfo("isi harus diisi dan berupa angka")
            txtIsi.Focus()
        Else
            If status = "add" Then
                Try
                    Dim reader = execute_reader("Select * from msmerk where merk='" & Trim(txtMerk.Text) & "'")
                    If reader.Read Then
                        msgInfo("Merk telah ada di dalam database")
                        txtMerk.Text = ""
                        txtMerk.Focus()
                        reader.Close()
                    Else
                        reader.Close()
                        Dim isi = CInt(Val(txtIsi.Text)).ToString
                        Dim prioritas = CInt(Val(chk_prioritas)).ToString
                        sql = " insert into  " & tab & " ( kdmerk, merk, isi, Prioritas " & _
                              " ) values( " & _
                              " '" + Trim(txtID.Text) + "', '" & Trim(txtMerk.Text) & "', " & _
                              " '" & isi & "', '" & prioritas & "' " & _
                              " ) "
                        Try
                            execute_update(sql)
                            viewAllData("")
                            ubahAktif(False)
                            msgInfo("Data berhasil disimpan")
                        Catch ex As Exception
                            MsgBox(ex, MsgBoxStyle.Information)
                            txtMerk.Text = ""
                            txtMerk.Focus()
                        End Try
                    End If
                Catch ex As Exception
                    MsgBox(ex, MsgBoxStyle.Information)
                    txtMerk.Text = ""
                    txtMerk.Focus()
                End Try
                ' reader.Close()
            ElseIf status = "update" Then
                Try
                    sql = " update   " & tab & " set " & _
                          " Merk = '" & Trim(txtMerk.Text) & "', " & _
                          " isi = '" & CInt(Val(txtIsi.Text)) & "', " & _
                          " Prioritas = '" & CInt(Val(chk_prioritas)) & "' " & _
                          " where  " & PK & " = '" + txtID.Text + "' "
                    execute_update(sql)
                    viewAllData("")
                    ubahAktif(False)
                    msgInfo("Data berhasil disimpan")
                Catch ex As Exception
                    msgWarning(" Data tidak valid")
                    txtMerk.Text = ""
                    txtMerk.Focus()
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
        FormMsBarang.setCmbMerk()
    End Sub

    Private Sub txtIsi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtIsi.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtIsi.Text <> "" Then
            chkDefault.Focus()
        End If
    End Sub
End Class