Imports System.Data.SqlClient
Public Class FormPurchasePaymentManagamen
    Dim status As String
    Dim tab As String
    Dim PK As String = ""
    Dim NamaBahanMentah As String = ""
    Dim kdSupplier As String = ""
    Dim jenis_payment As String
    Dim jml_satuan2 = 0
    Dim nama_satuan2 = ""

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Private Sub emptyField()
        dtpPayment.Text = Now()
        cmbPB.SelectedIndex = 0
        txtSupplier.Text = ""
        cmbBayar.SelectedIndex = 0
    End Sub

    Function getPayment(Optional ByVal KdPayment As String = "")
        Dim sql As String = " Select KdPurchasePayment from trPurchasePayment " & _
                            " order by no_increment desc "

        If KdPayment <> "" Then
            sql &= "KdPurchasePayment = '" & KdPayment & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub setData()
        Try
            Dim Supplier = ""
            Dim kdPB = ""
            Dim readerPayment = execute_reader(" select KdPurchasePayment,DATE_FORMAT(TanggalPurchasePayment, '%m/%d/%Y') Tanggal, " & _
                                            " payment.No_PB, MS.KdSupplier, MS.Nama, " & _
                                            " StatusPurchasePayment, " & _
                                            " Note, PaidBy, payment.Disc disc_payment " & _
                                            " from trPurchasePayment payment " & _
                                            " Join MsSupplier MS On MS.KdSupplier = payment.KdSupplier " & _
                                            " Where kdPurchasePayment = '" & PK & "' " & _
                                            " AND jenis_payment = '" & jenis_payment & "' ")

            If readerPayment.Read Then
                txtID.Text = readerPayment.Item("KdPurchasePayment")
                dtpPayment.Text = readerPayment.Item("Tanggal")
                kdPB = readerPayment.Item("No_PB")
                Supplier = readerPayment.Item("KdSupplier") & " - " & readerPayment.Item("Nama")
                txt_disc_payment.Text = readerPayment.Item("disc_payment")
                If readerPayment.Item("StatusPurchasePayment") <> 0 Then
                    btnSave.Enabled = False
                    btnConfirms.Enabled = False
                End If
                txtNote.Text = readerPayment.Item("Note")
                cmbBayar.Text = readerPayment.Item("PaidBy")
            End If
            readerPayment.Close()
            txtSupplier.Text = Supplier
            cmbPB.Text = kdPB

            Dim reader = execute_reader(" Select MB.KdBahanMentah,NamaBahanMentah,Ukuran, " & _
                                        " Harga, Qty, Qty_real,Disc,StatusBarang,Satuan " & _
                                        " from TrPurchasePaymentDetail payment " & _
                                        " Join MsBahanMentah MB On payment.KdBahanMentah = MB.KdBahanMentah " & _
                                        " where kdPurchasePayment = '" & PK & "' " & _
                                        " order by NamaBahanMentah asc ")

            gridBahanMentah.Rows.Clear()
            Do While reader.Read
                Dim Subtotal = (Val(reader("Harga")) * Val(reader("Qty")))

                gridBahanMentah.Rows.Add()
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQtyReal").Value = reader("Qty_real")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = Subtotal
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
            Loop
            reader.Close()

            HitungTotal()
        Catch ex As Exception
            MsgBox("Error!!!!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Private Sub setGrid()
        With gridBahanMentah.ColumnHeadersDefaultCellStyle
            .Alignment = DataGridViewContentAlignment.MiddleCenter
            .Font = New Font(.Font.FontFamily, .Font.Size, _
              .Font.Style Or FontStyle.Bold, GraphicsUnit.Point)
            .ForeColor = Color.Gold

        End With
    End Sub

    Public Sub setCmbPB()
        Dim varT As String = ""
        Dim addQuery = ""
        cmbPB.Items.Clear()
        cmbPB.Items.Add("- Pilih PB -")
        If PK <> "" Then
            addQuery = " And exists( Select 1 from trpurchasepayment tpp " & _
                       " where tpp.KdPurchasePayment = '" & PK & "' " & _
                       " And tpp.No_PB = trheaderpb.No_PB )"
            cmbPB.Enabled = False
            BrowsePB.Enabled = False
        Else
            addQuery = " And statusTerimaBarang <> 0 " & _
                       " And StatusPaid <> 1 " & _
                       " GROUP BY trheaderpb.No_PB " & _
                       " HAVING SUM(GrandTotal) - " & _
                       " IFNULL(( " & _
                       "    SELECT SUM(TotalPurchasePayment) " & _
                       "    FROM trpurchasepayment WHERE trheaderpb.No_PB = trpurchasepayment.No_PB " & _
                       " ), 0) > 0 " & _
                       " And NOT EXISTS ( " & _
                       "    Select 1 from trpurchasepayment tpp " & _
                       "    where tpp.No_PB = trheaderpb.No_PB " & _
                       ") "
        End If

        Dim reader = execute_reader(" Select Distinct trheaderpb.No_PB from trheaderpb " & _
                                    " Join msuser On msuser.UserID = trheaderpb.UserID " & _
                                    " where 1 " & _
                                    " And jenis_pb = '" & jenis_payment & "' " & _
                                    " And StatusTerimaBarang <> 3 " & _
                                    addQuery & _
                                    " Order By no_increment Desc ")
        Do While reader.Read
            cmbPB.Items.Add(reader(0))
        Loop
        reader.Close()
        If cmbPB.Items.Count > 0 Then
            cmbPB.SelectedIndex = 0
        End If
        reader.Close()
    End Sub

    Private Sub FormMsSupplier_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PK = data_carier(0)
        status = data_carier(1)
        jenis_payment = data_carier(2)

        If jenis_payment = "klem" Then
            Me.Text = "Pembayaran Klem Mentah"
            jml_satuan2 = 30
            nama_satuan2 = "Karung"
        Else
            Me.Text = "Pembayaran Paku"
            jml_satuan2 = 25
            nama_satuan2 = "Kardus"
        End If
        clear_variable_array()
        gridBahanMentah.Columns("clmQtyReal").HeaderText = "Qty ( " & nama_satuan2 & " )"

        setCmbPB()
        emptyField()
        If PK = "" Then
            generateCode()
        Else
            setData()
            txtID.Text = PK
        End If
        cmbPB.Focus()
    End Sub

    Private Sub generateCode()
        Dim code As String = "FP"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String

        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")

        code += FormatDate

        Dim reader = getPayment()

        If reader.read Then
            kode = Trim(reader("KdPurchasePayment").ToString())
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

    Function SavePaymentDetail(ByVal flag As String)
        Dim sqlDetail = ""
        Dim statusPB = 1

        For i As Integer = 0 To gridBahanMentah.RowCount - 1
            Dim statusDetail = 0
            Dim harga = gridBahanMentah.Rows.Item(i).Cells("clmHarga").Value.ToString.Replace(".", "").Replace(",", "")
            Dim Qty = Val(gridBahanMentah.Rows.Item(i).Cells("clmQty").Value)
            Dim Qty_real = Val(gridBahanMentah.Rows.Item(i).Cells("clmQtyReal").Value)
            Dim KdBahanMentah = gridBahanMentah.Rows.Item(i).Cells("clmPartNo").Value
            Dim StatusBahanMentah = gridBahanMentah.Rows.Item(i).Cells("clmStatus").Value
            Dim Disc = Val(gridBahanMentah.Rows.Item(i).Cells("clmDisc").Value)

            sqlDetail = "insert into TrPurchasePaymentDetail(KdPurchasePayment,KdBahanMentah, Harga, " _
                           & " Qty, disc, StatusBarang, Qty_real) values( " _
                           & " '" & Trim(txtID.Text) & "','" & KdBahanMentah & "', " _
                           & " '" & harga & "', '" & Qty & "', " _
                           & " '" & Disc & "', '" & StatusBahanMentah & "', '" & Qty_real & "')"
            execute_update_manual(sqlDetail)
        Next

        If flag = 1 Then
            Dim sqlPB = " Update trheaderpb set StatusPaid = '" & statusPB & "' " & _
                        " Where No_PB = '" & Trim(cmbPB.Text) & "' "
            execute_update_manual(sqlPB)
            Return True
        End If
        Return True
    End Function

    Function save(ByVal flag As String)
        If cmbPB.SelectedIndex = 0 Then
            msgInfo("Penerimaan Bahan Mentah harus dipilih")
            cmbPB.Focus()
        ElseIf cmbBayar.SelectedIndex = 0 Then
            msgInfo("Cara Bayar harus dipilih")
            cmbBayar.Focus()
        Else
            Dim Grandtotal = txt_jumlah.Text.ToString.Replace(".", "").Replace(",", "")
            Dim Jumlah = lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", "")

            dbconmanual.Open()
            Dim trans As MySql.Data.MySqlClient.MySqlTransaction

            trans = dbconmanual.BeginTransaction(IsolationLevel.ReadCommitted)

            Try
                If PK = "" Then
                    sql = " insert into  trPurchasePayment ( KdPurchasePayment, " & _
                          " No_PB, TanggalPurchasePayment, KdSupplier, TotalPurchasePayment, " & _
                          " StatusPurchasePayment, Note, UserID, PaidBy, " & _
                          " jenis_payment, Jumlah, Disc) values('" + Trim(txtID.Text) + "', " & _
                          " '" & cmbPB.Text & "', " & _
                          " '" & dtpPayment.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                          " '" & Trim(kdSupplier) & "'," & _
                          " '" & Trim(Grandtotal) & "','" & flag & "', " & _
                          " '" & txtNote.Text & "','" & kdKaryawan & "','" & cmbBayar.Text & "', " & _
                          " '" & jenis_payment & "', '" & Jumlah & "', '" & txt_disc_payment.Text & "' ) "

                    execute_update_manual(sql)
                Else
                    sql = "update   trPurchasePayment  set  TanggalPurchasePayment='" & dtpPayment.Value.ToString("yyyy/MM/dd HH:mm:ss") & "'," & _
                    " No_PB='" & cmbPB.Text & "'," & _
                    " kdSupplier='" & Trim(kdSupplier) & "'," & _
                    " TotalPurchasePayment='" & Trim(Grandtotal) & "', " & _
                    " Note='" & Trim(txtNote.Text) & "', " & _
                    " StatusPurchasePayment='" & flag & "', " & _
                    " UserID='" & kdKaryawan & "', " & _
                    " PaidBy='" & cmbBayar.Text & "', " & _
                    " jenis_payment='" & jenis_payment & "', " & _
                    " Disc='" & txt_disc_payment.Text & "', " & _
                    " Jumlah='" & Jumlah & "' " & _
                    " where  KdPurchasePayment = '" & txtID.Text & "' "
                    execute_update_manual(sql)
                End If

                execute_update_manual("delete from TrPurchasePaymentdetail where  kdPurchasePayment = '" & txtID.Text & "'")
                SavePaymentDetail(flag)

                trans.Commit()
                msgInfo("Data berhasil disimpan")
                Me.Close()
            Catch ex As Exception
                trans.Rollback()
                msgWarning("Data tidak valid")
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

    Private Sub HitungTotal()
        Try
            Dim Grandtotal = 0
            If gridBahanMentah.Rows.Count <> 0 Then
                For i As Integer = 0 To (gridBahanMentah.Rows.Count - 1)
                    Dim total = gridBahanMentah.Rows.Item(i).Cells("clmSubtotal").Value.ToString.Replace(".", "").Replace(",", "")
                    Grandtotal = Val(Grandtotal) + Val(total)
                Next
            End If
            lblGrandtotal.Text = FormatNumber(Grandtotal, 0)
            calc_disc_payment()
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Function calc_disc_payment()
        Dim disc = txt_disc_payment.Text * 1
        disc = 100 - Math.Round(disc, 2)
        Dim jumlah = Val(lblGrandtotal.Text.ToString.Replace(".", "").Replace(",", ""))
        Dim calcJumlah = jumlah * (disc / 100)
        txt_jumlah.Text = FormatNumber(calcJumlah, 0)
        Return True
    End Function

    Private Sub BrowsePB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BrowsePB.Click
        Try
            data_carier(0) = PK
            data_carier(1) = "PurchasePayment"
            data_carier(2) = jenis_payment
            sub_form = New FormBrowsePB
            sub_form.showDialog(FormMain)
            If data_carier(0) <> "" Then
                cmbPB.Text = data_carier(0)
                txtSupplier.Text = data_carier(1)
                kdSupplier = data_carier(2)
                clear_variable_array()

                'Dim reader = execute_reader(" Select MB.KdBahanMentah,NamaBahanMentah,Ukuran, " & _
                '                            " Harga,sum(Qty - ifnull(( Select sum(Qty) " & _
                '                            " from trdetailreturbeli returdetail " & _
                '                            " Join trheaderreturbeli retur On returdetail.KdRetur = retur.KdRetur " & _
                '                            " where KdBahanMentah = pb.KdBahanMentah " & _
                '                            " And retur.KdPB = trheaderpb.No_PB " & _
                '                            " Group By retur.KdPB,KdBahanMentah ),0)) Qty, " & _
                '                            " pb.Disc, ifnull(( Select 'Retur' " & _
                '                            " from trdetailreturbeli returdetail " & _
                '                            " Join trheaderreturbeli retur On returdetail.KdRetur = retur.KdRetur " & _
                '                            " where KdBahanMentah = pb.KdBahanMentah " & _
                '                            " And retur.KdPB = trheaderpb.No_PB " & _
                '                            " Group By retur.KdPB,KdBahanMentah ),'Normal') StatusBarang,Satuan " & _
                '                            " from trdetailpb pb " & _
                '                            " Join trheaderpb On pb.No_PB = trheaderpb.No_PB " & _
                '                            " Join MsBahanMentah MB On pb.KdBahanMentah = MB.KdBahanMentah " & _
                '                            " where pb.No_PB = '" & cmbPB.Text & "' " & _
                '                            " And TipePB = 1 " & _
                '                            " Group by MB.KdBahanMentah,trheaderpb.No_PB,Harga " & _
                '                            " order by NamaBahanMentah asc ")

                'gridBahanMentah.Rows.Clear()
                'Do While reader.Read
                '    Dim Subtotal = (Val(reader("Harga")) * Val(reader("Qty")))

                '    gridBahanMentah.Rows.Add()
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = reader("Disc")
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = Subtotal
                '    gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
                'Loop
                'reader.Close()

                'HitungTotal()
            Else
                'txtSupplier.Text = ""
                'kdSupplier = ""
                'gridBahanMentah.Rows.Clear()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString, MsgBoxStyle.Critical, "Warning!!!")
        End Try
    End Sub

    Private Sub cmbpb_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbPB.SelectedIndexChanged
        If cmbPB.SelectedIndex <> 0 Then
            Dim reader = execute_reader(" SELECT MB.KdBahanMentah,NamaBahanMentah,Ukuran, " & _
                                        " pb.Harga,( pb.Qty - IFNULL( ( " & _
                                        "   SELECT SUM(returdetail.Qty) FROM trDetailreturbeli returdetail " & _
                                        "   JOIN trheaderreturbeli retur ON returdetail.KdRetur = retur.KdRetur " & _
                                        "   WHERE retur.KdPB = trheaderpb.No_PB " & _
                                        "   AND returdetail.KdBahanMentah = pb.KdBahanMentah " & _
                                        "   AND returdetail.Harga = pb.Harga " & _
                                        "   GROUP BY returdetail.KdBahanMentah,retur.KdPB, returdetail.Harga " & _
                                        " ), 0)) Qty, " & _
                                        " IFNULL((  " & _
                                        "   SELECT 'Retur' " & _
                                        "   FROM trdetailreturbeli tdr  " & _
                                        "   JOIN trheaderreturbeli thr ON tdr.KdRetur = thr.KdRetur  " & _
                                        "   WHERE tdr.KdBahanMentah = pb.KdBahanMentah " & _
                                        "   AND thr.KdPB = trheaderpb.No_PB  " & _
                                        "   AND tdr.Harga = pb.Harga  " & _
                                        "   GROUP BY thr.KdPB,tdr.KdBahanMentah, tdr.Harga " & _
                                        " ),'Normal') StatusBarang,  " & _
                                        " MS.KdSupplier, MS.Nama, " & _
                                        " Satuan,pb.disc,trheaderpb.disc disc_payment " & _
                                        " FROM trdetailpb pb " & _
                                        " JOIN trheaderpb ON pb.No_PB = trheaderpb.No_PB " & _
                                        " JOIN MsBahanMentah MB ON pb.KdBahanMentah = MB.KdBahanMentah " & _
                                        " JOIN MsSupplier MS ON MS.KdSupplier = trheaderpb.KdSupplier " & _
                                        " WHERE trheaderpb.No_PB = '" & cmbPB.Text & "' " & _
                                        " AND StatusPaid <> 1 " & _
                                        " GROUP BY MB.KdBahanMentah,trheaderpb.No_PB,Harga " & _
                                        " HAVING(Qty <> 0) " & _
                                        " ORDER BY NamaBahanMentah asc ")

            Dim idxpb = 0
            gridBahanMentah.Rows.Clear()
            Do While reader.Read
                If idxpb = 0 Then
                    txtSupplier.Text = reader("Nama")
                    kdSupplier = reader("KdSupplier")
                    txt_disc_payment.Text = reader("disc_payment")
                End If

                Dim Subtotal = (Val(reader("Harga")) * Val(reader("Qty")))
                gridBahanMentah.Rows.Add()
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmPartNo").Value = reader("KdBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmNamaBarang").Value = reader("NamaBahanMentah")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmUkuran").Value = reader("Ukuran")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmHarga").Value = FormatNumber(reader("Harga"), 0)
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmDisc").Value = reader("disc")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQty").Value = reader("Qty")
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmQtyReal").Value = reader("Qty") / jml_satuan2
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmSubtotal").Value = Subtotal
                gridBahanMentah.Rows.Item(gridBahanMentah.RowCount - 1).Cells("clmStatus").Value = reader("StatusBarang")
                idxpb += 1
            Loop
            reader.Close()

            HitungTotal()
        Else
            txtSupplier.Text = ""
            kdSupplier = ""
            gridBahanMentah.Rows.Clear()
        End If
    End Sub

    Private Sub btnConfirms_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnConfirms.Click
        save(1)
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub

    Private Sub txt_disc_payment_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txt_disc_payment.TextChanged
        If IsNumeric(txt_disc_payment.Text) Then
            calc_disc_payment()
        Else
            MsgBox("Diskon harus berupa angka.", MsgBoxStyle.Information, "Validation Error")
            txt_disc_payment.Text = 0
            txt_disc_payment.Focus()
        End If
    End Sub
End Class
