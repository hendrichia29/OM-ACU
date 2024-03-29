Imports MySql.Data.MySqlClient

Public Class FormProduksiPantekDiterimaManagement
    Dim PK As String = ""
    Dim statusPantek = 0
    Dim OP = "Min"
    Dim Attribute = "QtyProd_Min"
    Dim KonversiKlemToKg = 25
    Dim KonversiPakuToKg = 30

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpPantek.Text = Now()
        gridBarang.Rows.Clear()
        txtKaryawan.Text = ""
        cmbPantekKeluar.SelectedIndex = 0
        txtAlamat.Text = ""
        txtTelepon.Text = ""
    End Sub

    Private Sub setData()
        Try
            Dim SelectKaryawan = ""
            Dim KdPantek = ""
            Dim readerPantek = execute_reader(" select KdPantekDiterima, KdPantek, " & _
                                              " DATE_FORMAT(TanggalPantekDiterima, '%m/%d/%Y') 'Tanggal', " & _
                                              " pantek.KdKaryawan, MK.NamaKaryawan, " & _
                                              " Alamat, MK.NoHP, StatusPantekDiterima " & _
                                              " from trpantek_diterima pantek " & _
                                              " Join mskaryawan MK On MK.KdKaryawan = pantek.KdKaryawan " & _
                                              " Where KdPantekDiterima = '" & PK & "' ")
            If readerPantek.Read() Then
                txtKdPantek.Text = readerPantek.Item("KdPantekDiterima")
                KdPantek = readerPantek.Item("KdPantek")
                dtpPantek.Text = readerPantek.Item("Tanggal")
                SelectKaryawan = Trim(readerPantek.Item("KdKaryawan")) & " ~ " & readerPantek.Item("NamaKaryawan")
                statusPantek = readerPantek.Item("StatusPantekDiterima")
                txtAlamat.Text = readerPantek.Item("Alamat")
                txtTelepon.Text = readerPantek.Item("NoHP")
                If readerPantek.Item("StatusPantekDiterima") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerPantek.Close()
            txtKaryawan.Text = SelectKaryawan
            cmbPantekKeluar.Text = KdPantek
            Dim reader = execute_reader(" Select klem.KdBahanMentah 'KdKlem', klem.NamaBahanMentah 'NamaKlem', " & _
                                        " klem.Ukuran 'UkuranKlem', sum(pantek.QtyKlemMentah) QtyKlemMentah, " & _
                                        " paku.KdBahanMentah 'KdPaku', paku.NamaBahanMentah 'NamaPaku', " & _
                                        " paku.Ukuran 'UkuranPaku', sum(pantek.QtyPaku) QtyPaku, QtyKlemMentahDiterima, " & _
                                        " mfp.QtyKlemMentah 'QtyKlemFormula', mfp.QtyKlemJadi 'QtyKlemJadiFormula', " & _
                                        " mfp.QtyPaku 'QtyPakuFormula' " & _
                                        " from trpantek_diterima_detail pantek " & _
                                        " Join MsBahanMentah klem On klem.KdBahanMentah = KdKlemMentah " & _
                                        " Join MsBahanMentah paku On paku.KdBahanMentah = KdPaku " & _
                                        " join msformula mfp on mfp.UkuranKlemMentah = klem.Ukuran " & _
                                        " where KdPantekDiterima = '" & PK & "' " & _
                                        " GROUP BY klem.KdBahanMentah, paku.KdBahanMentah " & _
                                        " order by klem.NamaBahanMentah asc ")
            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim QtyKlemPantek = Val(reader("QtyKlemMentah")) / Val(reader("QtyKlemJadiFormula"))
                Dim QtyKlemMentah = QtyKlemPantek * reader("QtyKlemFormula")
                Dim QtyPaku = QtyKlemPantek * reader("QtyPakuFormula")
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKlem").Value = reader("KdKlem")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdPaku").Value = reader("KdPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranKlem").Value = reader("NamaKlem")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranPaku").Value = reader("NamaPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlem").Value = reader("QtyKlemMentah")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPaku").Value = reader("QtyPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPerkiraan").Value = QtyKlemMentah & " - " & QtyPaku
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyDiterima").Value = reader("QtyKlemMentahDiterima")
            Loop
            reader.Close()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub setGrid()
        With gridBarang.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
        gridBarang.ReadOnly = False

    End Sub

    Public Sub setCmbPantekKeluar()
        Dim addQuery = ""
        cmbPantekKeluar.Items.Clear()
        cmbPantekKeluar.Items.Add("- Pilih No. Keluar -")

        If PK <> "" Then
            addQuery = " And exists( Select 1 from trpantek_diterima " & _
                       " where KdPantekDiterima = '" & PK & "' And KdPantek = trpantek.KdPantek )"
            cmbPantekKeluar.Enabled = False
            browsePantekKeluar.Enabled = False
        Else
            addQuery &= " And StatusPantek = 1 " & _
                        " AND StatusKlemMentah = 0 " & _
                        " And Not Exists( Select 1 from trpantek_diterima " & _
                        " where trpantek_diterima.KdPantek = trpantekdetail.KdPantek ) "
        End If

        sql = " Select DISTINCT trpantek.KdPantek from trpantek " & _
              " Join trpantekdetail On trpantekdetail.KdPantek = trpantek.KdPantek " & _
              " Join msuser On msuser.UserID = trpantek.KdUser " & _
              " where 1 " & _
              addQuery & _
              " ORDER BY trpantek.no_increment "

        Dim reader = execute_reader(sql)
        Do While reader.Read
            cmbPantekKeluar.Items.Add(reader.GetString(0))
        Loop
        reader.Close()
        If cmbPantekKeluar.Items.Count > 0 Then
            cmbPantekKeluar.SelectedIndex = 0
        End If
    End Sub

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        clear_variable_array()
        setCmbPantekKeluar()
        emptyField()
        If PK <> "" Then
            setData()
            txtKdPantek.Text = PK
        Else
            generateCode()
        End If
    End Sub

    Private Sub generateCode()
        Dim code As String = "PK"
        Dim angka As Integer
        Dim kode As String = ""
        Dim temp As String
        Dim bulan As Integer = CInt(Today.Month.ToString)
        code += Today.Year.ToString.Substring(2, 2)
        If bulan < 10 Then
            code += "0" + bulan.ToString
        Else
            code += bulan.ToString
        End If

        'generate code
        sql = " select KdPantekDiterima " & _
              " from  trpantek_diterima " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("KdPantekDiterima")
        Else
            reader.Close()
            sql = " select KdPantekDiterima " & _
                  " from  trpantek_diterima_t " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("KdPantekDiterima")
            Else
                kode = ""
            End If
            reader2.Close()
        End If
        reader.Close()
        reader = Nothing

        If kode <> "" Then
            temp = kode.Substring(0, 6)
            If temp = code Then
                angka = CInt(kode.Substring(6, 4))
            Else
                angka = 0
            End If

        Else
            angka = 0
        End If
        angka = angka + 1
        Dim len As Integer = angka.ToString().Length
        For i As Integer = 1 To 4 - len
            code += "0"
        Next
        code = code & (angka)
        txtKdPantek.Text = Trim(code)
    End Sub

    Function SavePantekDetail(ByVal flag As String)
        Dim sqlDetail = ""

        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim statusDetail = 0
            Dim QtyKlem = Val(gridBarang.Rows.Item(i).Cells("clmQtyKlem").Value)
            Dim QtyPaku = Val(gridBarang.Rows.Item(i).Cells("clmQtyPaku").Value)
            Dim QtyDiterima = Val(gridBarang.Rows.Item(i).Cells("clmQtyDiterima").Value)
            Dim KdKlem = gridBarang.Rows.Item(i).Cells("clmKdKlem").Value
            Dim KdPaku = gridBarang.Rows.Item(i).Cells("clmKdPaku").Value
            If QtyKlem < QtyDiterima Then
                MsgBox("Jumlah diterima telah melebihi jumlah klem keluar.")
                Return False
            Else
                sqlDetail = " insert into trpantek_diterima_detail ( " & _
                            " KdPantekDiterima, KdKlemMentah, QtyKlemMentah, " & _
                            " KdPaku, QtyPaku, QtyKlemMentahDiterima ) VALUES ( " & _
                            " '" & txtKdPantek.Text & "' , '" & Trim(KdKlem) & "', " & _
                            " '" & QtyKlem & "', '" & Trim(KdPaku) & "', " & _
                            " '" & QtyPaku & "', '" & QtyDiterima & "' ) "
                execute_update_manual(sqlDetail)

                If flag = 1 Then
                    Dim sqlPantek = " UPDATE trpantek SET " & _
                                    " StatusPantek = 2 " & _
                                    " WHERE KdPantek = '" & Trim(cmbPantekKeluar.Text) & "' "
                    execute_update_manual(sqlPantek)
                End If
            End If
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbPantekKeluar.SelectedIndex = 0 Then
            msgInfo("No. keluar harus dipilih")
            cmbPantekKeluar.Focus()
        Else
            Dim KdKar = txtKaryawan.Text.ToString.Split("~")
            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction
            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try

                If PK = "" Then
                    sql = " insert into trpantek_diterima ( KdPantekDiterima, KdPantek, " & _
                          " TanggalPantekDiterima, " & _
                          " KdKaryawan, KdUser, StatusPantekDiterima ) " & _
                          " values( '" & Trim(txtKdPantek.Text) & "', " & _
                          " '" + Trim(cmbPantekKeluar.Text) + "', " & _
                          " '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" + Trim(KdKar(0)) + "', " & _
                          " '" & Trim(kdKaryawan) & "', '" & flag & "' ) "
                    execute_update_manual(sql)
                Else
                    sql = " update trpantek_diterima  set  " & _
                          " TanggalPantekDiterima = '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdPantek = '" & Trim(cmbPantekKeluar.Text) & "'," & _
                          " KdKaryawan = '" & Trim(KdKar(0)) & "'," & _
                          " StatusPantekDiterima = '" & flag & "'," & _
                          " KdUser =  '" & Trim(kdKaryawan) & "' " & _
                          " where KdPantekDiterima = '" & Trim(txtKdPantek.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual(" delete from trpantek_diterima_detail " & _
                                      " where  KdPantekDiterima = '" & txtKdPantek.Text & "'")
                If Not SavePantekDetail(flag) Then
                    Return False
                End If
                trans.Commit()
                msgInfo("Data produksi pantek berhasil disimpan.")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                MsgBox(ex, MsgBoxStyle.Information)
            End Try
            dbconmanual.Close()
        End If
        Return True
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        save(0)
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub browseKlemMentah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles browsePantekKeluar.Click
        Try
            data_carier(0) = PK
            sub_form = New FormBrowsePantekKeluar
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbPantekKeluar.Text = data_carier(0)
                clear_variable_array()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim harga = 0
            Dim qtyKlem = Val(gridBarang.CurrentRow.Cells("clmQtyKlem").Value)
            Dim qtyPaku = Val(gridBarang.CurrentRow.Cells("clmQtyPaku").Value)
            Dim qtyDiterima = Val(gridBarang.CurrentRow.Cells("clmQtyDiterima").Value)
            Dim KdKlem = gridBarang.CurrentRow.Cells("clmKdKlem").Value
            Dim KdPaku = gridBarang.CurrentRow.Cells("clmKdPaku").Value

            If qtyKlem < qtyDiterima Then
                MsgBox("Jumlah klem diterima melebihin stok klem keluar.", MsgBoxStyle.Information, "Validation Error")
                qtyKlem = qtyKlem
                gridBarang.CurrentRow.Cells("clmQtyDiterima").Value = qtyKlem
                gridBarang.CurrentRow.Cells("clmQtyDiterima").Selected = True
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub cmbPantekKeluar_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPantekKeluar.SelectedIndexChanged
        If cmbPantekKeluar.SelectedIndex <> 0 Then
            sql = " select pantek.KdKaryawan, NamaKaryawan , " & _
                  " Alamat, NoHP, " & _
                  " DATE_FORMAT(TanggalPantek,'%d %M %Y') " & _
                  " from  trpantek pantek " & _
                  " join mskaryawan mk on mk.KdKaryawan = pantek.KdKaryawan " & _
                  " where KdPantek = '" & cmbPantekKeluar.Text & "' "
            Dim reader = execute_reader(sql)
            If reader.Read() Then
                txtKaryawan.Text = reader("KdKaryawan") & " ~ " & reader("NamaKaryawan")
                txtAlamat.Text = reader("Alamat")
                txtTelepon.Text = reader("NoHP")
            End If
            reader.Close()

            reader = Nothing
            sql = " select pd.KdKlemMentah, bm.namaBahanMentah 'NamaKlem', KdPaku, " & _
                  " paku.namaBahanMentah 'NamaPaku', " & _
                  " pd.QtyKlemMentah, pd.QtyPaku, KdKlemMentah, KdPaku, " & _
                  " mfp.QtyKlemMentah 'QtyKlemFormula', mfp.QtyKlemJadi 'QtyKlemJadiFormula', " & _
                  " mfp.QtyPaku 'QtyPakuFormula' " & _
                  " from  trpantekdetail pd " & _
                  " join msBahanMentah bm on bm.kdBahanMentah = pd.KdKlemMentah " & _
                  " join msBahanMentah paku on paku.kdBahanMentah = pd.KdPaku " & _
                  " join msformula mfp on mfp.UkuranKlemMentah = bm.Ukuran " & _
                  " where pd.KdPantek='" & cmbPantekKeluar.Text & "' "
            reader = execute_reader(sql)
            Dim harga As Double = 0
            gridBarang.Rows.Clear()
            Do While reader.Read
                Dim QtyKlemPantek = Val(reader("QtyKlemMentah")) / Val(reader("QtyKlemJadiFormula"))
                Dim QtyKlemMentah = QtyKlemPantek * reader("QtyKlemFormula")
                Dim QtyPaku = QtyKlemPantek * reader("QtyPakuFormula")
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKlem").Value = Trim(reader("KdKlemMentah"))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdPaku").Value = Trim(reader("KdPaku"))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranKlem").Value = Trim(reader("NamaKlem"))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuranPaku").Value = reader("NamaPaku")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyKlem").Value = Val(reader("QtyKlemMentah"))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyPaku").Value = Val(reader("QtyPaku"))
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmPerkiraan").Value = QtyKlemMentah & " - " & QtyPaku
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQtyDiterima").Value = 0
            Loop
            reader.Close()
        Else
            emptyField()
        End If
    End Sub
End Class