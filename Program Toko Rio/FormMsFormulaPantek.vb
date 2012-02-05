Imports System.Data.SqlClient

Public Class FormMsFormulaPantek
    Dim status As String
    Dim tab As String
    Dim PK As String
    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub
    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Function clear()
        txtQtyKlemJadi.Text = 0
        txtQtyPaku.Text = 0
        txtQtyKlemMentah.Text = 0
        cmbQtyKlemMentah.SelectedIndex = 0
        cmbQtyPaku.SelectedIndex = 0
        Return True
    End Function

    Function setCmbQtyKlem()
        cmbQtyKlemMentah.Items.Clear()
        cmbQtyKlemMentah.Items.Add("- Pilih -")
        For i As Integer = 1 To 100
            cmbQtyKlemMentah.Items.Add(i * Val(25))
        Next
        cmbQtyKlemMentah.SelectedIndex = 0
        Return True
    End Function

    Function setCmbQtyPaku()
        cmbQtyPaku.Items.Clear()
        cmbQtyPaku.Items.Add("- Pilih Jumlah -")
        For i As Integer = 1 To 100
            cmbQtyPaku.Items.Add(i * Val(30))
        Next
        cmbQtyPaku.SelectedIndex = 0
        Return True
    End Function

    Public Sub setCmbUkuran()
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
        cmbUkuran.SelectedIndex = 0
    End Sub

    Private Sub FormMsMerk_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        setCmbQtyKlem()
        setCmbQtyPaku()
        setCmbUkuran()
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        If Val(txtQtyKlemMentah.Text) = 0 Then
            msgInfo("Jumlah klem mentah harus berupa angka dan lebih besar dari 0")
            txtQtyKlemMentah.Focus()
        ElseIf Val(txtQtyPaku.Text) = 0 Then
            msgInfo("Jumlah paku harus berupa angka dan lebih besar dari 0")
            txtQtyPaku.Focus()
        ElseIf Val(txtQtyKlemJadi.Text) = 0 Then
            msgInfo("Jumlah klem jadi harus diisi")
            txtQtyKlemJadi.Focus()
        Else
            'Try
            sql = " INSERT INTO msformulapantek ( " & _
                  " UkuranKlemMentah, QtyKlemMentah, QtyPaku, QtyKlemJadi " & _
                  " ) VALUES ( " & _
                  " '" & cmbUkuran.Text & "', '" & Val(txtQtyKlemMentah.Text) & "', " & _
                  " '" & Val(txtQtyPaku.Text) & "', '" & Val(txtQtyKlemJadi.Text) & "' " & _
                  " ) ON DUPLICATE KEY UPDATE  " & _
                  " QtyKlemMentah = '" & Val(txtQtyKlemMentah.Text) & "', " & _
                  " QtyPaku = '" & Val(txtQtyPaku.Text) & "', " & _
                  " QtyKlemJadi = '" & Val(txtQtyKlemJadi.Text) & "' "
            execute_update(sql)
            msgInfo("Formula telah diubah")
            'Catch ex As Exception
            '    MsgBox(ex, MsgBoxStyle.Information)
            'End Try
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtQtyKlemMentah_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKlemMentah.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKlemMentah.Text <> "" Then
            txtQtyPaku.Focus()
        End If
    End Sub

    Private Sub txtQtyKlemMentah_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyKlemMentah.TextChanged
        cmbQtyKlemMentah.Text = Val(txtQtyKlemMentah.Text) * 25
    End Sub

    Private Sub txtQtyPaku_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyPaku.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyPaku.Text <> "" Then
            txtQtyKlemJadi.Focus()
        End If
    End Sub

    Private Sub TextBox1_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtQtyPaku.TextChanged
        cmbQtyPaku.Text = Val(txtQtyPaku.Text) * 30
    End Sub

    Private Sub cmbUkuran_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbUkuran.SelectedIndexChanged
        clear()
        Dim sql = " SELECT QtyKlemMentah, QtyPaku, " & _
                  " QtyKlemJadi, UkuranKlemMentah " & _
                  " FROM msformulapantek " & _
                  " WHERE UkuranKlemMentah = '" & cmbUkuran.Text & "' "
        Dim readerFormula = execute_reader(sql)
        If readerFormula.Read Then
            txtQtyKlemMentah.Text = readerFormula.Item("QtyKlemMentah")
            txtQtyPaku.Text = readerFormula.Item("QtyPaku")
            txtQtyKlemJadi.Text = readerFormula.Item("QtyKlemJadi")
            cmbUkuran.Text = readerFormula.Item("UkuranKlemMentah")
        End If
        readerFormula.Close()
    End Sub

    Private Sub txtQtyKlemJadi_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtQtyKlemJadi.KeyPress
        If Asc(e.KeyChar) <> Asc("-") And AscW(e.KeyChar) <> 13 And AscW(e.KeyChar) <> 8 And (Asc(e.KeyChar) < Asc("0") Or Asc(e.KeyChar) > Asc("9")) Then
            e.KeyChar = Nothing
        End If
        If AscW(e.KeyChar) = 13 And txtQtyKlemJadi.Text <> "" Then
            btnSave_Click(Nothing, Nothing)
        End If
    End Sub
End Class