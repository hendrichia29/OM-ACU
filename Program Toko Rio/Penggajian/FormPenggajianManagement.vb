Imports MySql.Data.MySqlClient

Public Class FormPenggajianManagement
    Dim PK As String = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpPantek.Text = Now()
        gridBarang.Rows.Clear()
    End Sub

    Private Sub setData()
        Try
            Dim SelectKaryawan = ""
            Dim readerPenggajian = execute_reader(" select KdPenggajian, DATE_FORMAT(TanggalPenggajian, '%m/%d/%Y') 'Tanggal', " & _
                                                  " StatusPenggajian, " & _
                                                  " DATE_FORMAT(TanggalAwal, '%m/%d/%Y') TanggalAwal, " & _
                                                  " DATE_FORMAT(TanggalAkhir, '%m/%d/%Y') TanggalSampai " & _
                                                  " from trpenggajian gaji " & _
                                                  " Where KdPenggajian = '" & PK & "' ")

            Dim TanggalAwal = "'"
            Dim TanggalAkhir = ""
            If readerPenggajian.Read() Then
                txtKdPenggajian.Text = readerPenggajian("KdPenggajian")
                dtpPantek.Text = readerPenggajian("Tanggal")
                TanggalAwal = readerPenggajian("TanggalAwal")
                TanggalAkhir = readerPenggajian("TanggalSampai")
                If readerPenggajian("StatusPenggajian") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
            End If
            readerPenggajian.Close()
            dtp_dari_tgl.Text = TanggalAwal
            dtp_sampai_tgl.Text = TanggalAkhir

            Dim reader = execute_reader(" SELECT MK.KdKaryawan, MK.NamaKaryawan, " & _
                                        " SUM(gaji.Qty) Qty, gaji.GajiPerQty, " & _
                                        " IFNULL(MB.Ukuran, MBM.Ukuran) Ukuran, " & _
                                        " IFNULL(MM.Merk, '-') Merk, " & _
                                        " gaji.TanggalPengerjaan, KdReferensi, " & _
                                        " ifnull(MB.KdBarang, MBM.KdBahanMentah) KdBarang " & _
                                        " FROM trpenggajiandetail gaji  " & _
                                        " LEFT JOIN MsBarang MB ON MB.KdBarang = gaji.KdBarang  " & _
                                        " LEFT JOIN MsBahanMentah MBM ON MBM.KdBahanMentah = gaji.KdBarang  " & _
                                        " LEFT JOIN MsMerk MM ON MB.KdMerk = MM.KdMerk  " & _
                                        " JOIN MsKaryawan MK ON gaji.KdKaryawan = MK.KdKaryawan  " & _
                                        " WHERE KdPenggajian = '" & PK & "'  " & _
                                        " GROUP BY MB.KdBarang, MBM.KdBahanMentah, KdReferensi " & _
                                        " ORDER BY MK.NamaKaryawan asc ")

            gridBarang.Rows.Clear()
            Do While reader.Read
                gridBarang.Rows.Add()
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdBarang").Value = reader("KdBarang")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKaryawan").Value = reader("KdKaryawan")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmTanggal").Value = reader("TanggalPengerjaan")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaKaryawan").Value = reader("NamaKaryawan")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("GajiPerQty"), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmJumlah").Value = FormatNumber(Val(reader("GajiPerQty")) * Val(reader("GajiPerQty")), 0)
                gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdReferensi").Value = reader("KdReferensi")
            Loop
            reader.Close()
            HitungTotal()
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
    End Sub

    Private Sub HitungTotal()
        Try
            Dim Jumlah = 0
            If gridBarang.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBarang.Rows.Count - 1)
                    Jumlah += gridBarang.Rows.Item(i).Cells("clmJumlah").Value.ToString.Replace(".", "").Replace(",", "")
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Jumlah, 0)
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Function getPenggajian()
        Dim reader = execute_reader(" SELECT GROUP_CONCAT( td.KdPantekDiterima SEPARATOR ',' ) KdReferensi, " & _
                                    " MK.KdKaryawan, MK.NamaKaryawan, " & _
                                    " GROUP_CONCAT( DATE_FORMAT(TanggalPantekDiterima, '%d %M %Y') ) Tanggal, " & _
                                    " SUM(tdd.QtyKlemMentah) Qty, " & _
                                    " MBM.Ukuran, '-' Merk, MBM.KdBahanMentah KdBarang " & _
                                    " FROM trpantek_diterima td  " & _
                                    " JOIN trpantek_diterima_detail tdd ON td.KdPantekDiterima = tdd.KdPantekDiterima " & _
                                    " JOIN MsBahanMentah MBM ON MBM.KdBahanMentah = tdd.KdKlemMentah " & _
                                    " JOIN MsKaryawan MK ON td.KdKaryawan = MK.KdKaryawan " & _
                                    " WHERE 1 " & _
                                    " AND td.StatusPantekDiterima = 1 " & _
                                    " AND NOT EXISTS ( " & _
                                    " SELECT 1 FROM trpenggajiandetail tp " & _
                                    " WHERE tp.KdReferensi = td.KdPantekDiterima " & _
                                    " ) " & _
                                    " AND DATE_FORMAT(TanggalPantekDiterima, '%Y/%m/%d') " & _
                                    " BETWEEN '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                                    " AND '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                                    " GROUP BY MBM.KdBahanMentah, td.KdPantekDiterima " & _
                                    " UNION " & _
                                    " SELECT GROUP_CONCAT( td.KdHitungDiterima SEPARATOR ',' ) KdReferensi, " & _
                                    " MK.KdKaryawan, MK.NamaKaryawan, " & _
                                    " GROUP_CONCAT( DATE_FORMAT(TanggalHitungDiterima, '%d %M %Y')) Tanggal, " & _
                                    " SUM(td.QtyKlemJadi) Qty, " & _
                                    " MB.Ukuran, MM.Merk, MB.KdBarang " & _
                                    " FROM trhitung_diterima th " & _
                                    " JOIN trhitungdetail_diterima td ON th.KdHitungDiterima = td.KdHitungDiterima " & _
                                    " JOIN MsBarang MB ON MB.KdBarang = td.KdKlemJadi " & _
                                    " JOIN MsMerk MM ON MB.KdMerk = MM.KdMerk " & _
                                    " JOIN MsKaryawan MK ON th.KdKaryawan = MK.KdKaryawan " & _
                                    " WHERE 1 " & _
                                    " AND th.StatusHitungDiterima = 1 " & _
                                    " AND NOT EXISTS ( " & _
                                    " SELECT 1 FROM trpenggajiandetail tp " & _
                                    " WHERE tp.KdReferensi = th.KdHitungDiterima " & _
                                    " ) " & _
                                    " AND DATE_FORMAT(TanggalHitungDiterima, '%Y/%m/%d') " & _
                                    " BETWEEN '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                                    " AND '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd") & "' " & _
                                    " GROUP BY MB.KdBarang, td.KdHitungDiterima " & _
                                    " order by NamaKaryawan asc ")

        gridBarang.Rows.Clear()
        Do While reader.Read
            gridBarang.Rows.Add()
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdBarang").Value = reader("KdBarang")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdKaryawan").Value = reader("KdKaryawan")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmTanggal").Value = reader("Tanggal")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmNamaKaryawan").Value = reader("NamaKaryawan")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmMerk").Value = reader("Merk")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmQty").Value = reader("Qty")
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmHarga").Value = 0
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmJumlah").Value = 0
            gridBarang.Rows.Item(gridBarang.RowCount - 1).Cells("clmKdReferensi").Value = reader("KdReferensi")
        Loop
        reader.Close()
        HitungTotal()
        Return True
    End Function

    Private Sub FormTrPOManagement_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        clear_variable_array()
        emptyField()
        If PK <> "" Then
            setData()
            txtKdPenggajian.Text = PK
        Else
            getPenggajian()
            generateCode()
        End If
    End Sub

    Private Sub generateCode()
        Dim code As String = "PG"
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
        sql = " select KdPenggajian " & _
              " from  trpenggajian " & _
              " order by no_increment desc " & _
              " limit 1"
        Dim reader = execute_reader(sql)
        If reader.Read() Then
            kode = reader("KdPenggajian")
        Else
            reader.Close()
            sql = " select KdPenggajian " & _
                  " from  trpenggajian_t " & _
                  " order by no_increment desc limit 1 "
            Dim reader2 = execute_reader(sql)
            If reader2.Read() Then
                kode = reader2("KdPenggajian")
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
        txtKdPenggajian.Text = Trim(code)
    End Sub

    Function SavePantekDetail(ByVal flag As String)
        Dim sqlDetail = ""
        For i As Integer = 0 To gridBarang.RowCount - 1
            Dim KdKaryawan = gridBarang.Rows.Item(i).Cells("clmKdKaryawan").Value
            Dim tanggal = Val(gridBarang.Rows.Item(i).Cells("clmTanggal").Value)
            Dim KdBarang = gridBarang.Rows.Item(i).Cells("clmKdBarang").Value
            Dim Qty = gridBarang.Rows.Item(i).Cells("clmQty").Value
            Dim Harga = gridBarang.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim KdReferensi = gridBarang.Rows.Item(i).Cells("clmKdReferensi").Value

            sqlDetail = " insert into trpenggajiandetail ( " & _
                        " KdPenggajian, KdKaryawan, TanggalPengerjaan, " & _
                        " KdBarang, Qty, GajiPerQty, KdReferensi ) VALUES ( " & _
                        " '" & txtKdPenggajian.Text & "' , '" & Trim(KdKaryawan) & "', " & _
                        " '" & tanggal & "', '" & Trim(KdBarang) & "', " & _
                        " '" & Qty & "', '" & Harga & "', '" & KdReferensi & "' ) "
            execute_update_manual(sqlDetail)

            If flag = 1 Then
                sql = " update trpantek_diterima  set  " & _
                      " StatusPaymentDiterima = 1 " & _
                      " where KdPantekDiterima = '" & Trim(KdReferensi) & "' "
                execute_update_manual(sql)

                sql = " update trhitung_diterima  set  " & _
                      " StatusPaymentDiterima = 1 " & _
                      " where KdHitungDiterima = '" & Trim(KdReferensi) & "' "
                execute_update_manual(sql)
            End If
        Next
        Return True
    End Function

    Function save(ByVal flag As String)
        If gridBarang.RowCount = 0 Then
            msgInfo("Data penggajian tidak ada")
            dtp_dari_tgl.Focus()
        Else
            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction
            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)
            Try

                If PK = "" Then
                    sql = " insert into trpenggajian ( KdPenggajian, " & _
                          " TanggalPenggajian, KdUser, StatusPenggajian, " & _
                          " TanggalAwal, TanggalAkhir ) " & _
                          " values( '" & Trim(txtKdPenggajian.Text) & "', " & _
                          " '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdKaryawan) & "', " & _
                          " '" & flag & "', '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' ) "
                    execute_update_manual(sql)
                Else
                    sql = " update trpenggajian  set  " & _
                          " TanggalPenggajian = '" & dtpPantek.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                          " KdUser = '" & Trim(kdKaryawan) & "'," & _
                          " StatusPenggajian = '" & flag & "', " & _
                          " TanggalAwal = '" & dtp_dari_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " TanggalAkhir = '" & dtp_sampai_tgl.Value.ToString("yyyy/MM/dd HH:mm:ss") & "' " & _
                          " where KdPenggajian = '" & Trim(txtKdPenggajian.Text) & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from trpenggajiandetail where  KdPenggajian = '" & txtKdPenggajian.Text & "'")
                If Not SavePantekDetail(flag) Then
                    Return False
                End If
                trans.Commit()
                msgInfo("Data Penggajian berhasil disimpan.")
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

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub gridBarang_CellEndEdit(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles gridBarang.CellEndEdit
        Try
            Dim Qty = CInt(gridBarang.CurrentRow.Cells("clmQty").Value)
            Dim Harga = gridBarang.CurrentRow.Cells("clmHarga").Value

            If Qty <= 0 Then
                MsgBox("Jumlah klem harus lebih besar dari 0", MsgBoxStyle.Information, "Validation Error")
                Qty = 1
                gridBarang.CurrentRow.Cells("clmQty").Selected = True
            ElseIf Val(Harga) <= 0 Then
                MsgBox("Harga harus lebih besar dari 0", MsgBoxStyle.Information, "Validation Error")
                Harga = 1
                gridBarang.CurrentRow.Cells("clmHarga").Selected = True
            End If

            gridBarang.CurrentRow.Cells("clmQty").Value = CInt(Qty)
            gridBarang.CurrentRow.Cells("clmHarga").Value = Val(Harga)
            gridBarang.CurrentRow.Cells("clmJumlah").Value = Qty * Harga
            HitungTotal()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub dtp_dari_tgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_dari_tgl.ValueChanged
        getPenggajian()
    End Sub

    Private Sub dtp_sampai_tgl_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles dtp_sampai_tgl.ValueChanged
        getPenggajian()
    End Sub
End Class