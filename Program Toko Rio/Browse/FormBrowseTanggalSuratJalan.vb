Imports System.Data.SqlClient
Public Class FormBrowseTanggalSuratJalan
    Dim status As String
    Dim tab As String
    Dim PK As String

    Private Sub msgWarning(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Critical, "Warning")
    End Sub

    Private Sub msgInfo(ByVal str As String)
        MsgBox(str, MsgBoxStyle.Information, "Information")
    End Sub

    Function getFaktur(Optional ByVal KdFaktur As String = "")
        Dim sql As String = "Select * from trfaktur order by kdfaktur desc "

        If KdFaktur <> "" Then
            sql &= "kdfaktur = '" & KdFaktur & "'"
        End If
        Dim reader = execute_reader(sql)
        Return reader
    End Function

    Private Sub generateCode()
        Dim code As String = "SJ"
        Dim angka As Integer
        Dim kode As String
        Dim temp As String
        'code += Today.Year.ToString.Substring(2, 2)
        Dim bulan As Integer = CInt(Today.Month.ToString)
        Dim currentTime As System.DateTime = System.DateTime.Now
        Dim FormatDate As String = Format(currentTime, "yyMMdd")

        'If bulan < 10 Then
        '    code += "0" + bulan.ToString
        'Else
        '    code += bulan.ToString
        'End If
        code += FormatDate

        Dim reader = getFaktur()

        If reader.read Then
            kode = Trim(reader(0).ToString())
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
        txtNoSJ.Text = Trim(code)
    End Sub

    Private Sub FormBrowseTanggalSuratJalan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim sql As String = "Select DATE_FORMAT(IfNull(TanggalSJ,Now()),'%d %M %Y'),ifNull(KdSJ,'0') " & _
                            " from trfaktur where KdFaktur = '" & data_carier(0) & "' "
        Dim reader = execute_reader(sql)
        If reader.read Then
            dtpSJ.Text = reader(0)
            If reader(1) = "0" Then
                txtNoSJ.Text = data_carier(0).ToString.Replace("FK", "SJ")
            Else
                txtNoSJ.Text = reader(1)
            End If
        End If
        reader.close()
    End Sub

    Private Sub print(ByVal type As String)
        idPrint = data_carier(0)
        Dim query As String
        Dim TglSJ = dtpSJ.Value.ToString("yyyy/MM/dd HH:mm:ss")
        Dim jenisFaktur As String = ""
        Dim reader = execute_reader("select jenis_faktur from trfaktur where kdfaktur ='" & idPrint & "'")
        If reader.Read Then
            jenisFaktur = reader(0)
        End If
        reader.close()
        If jenisFaktur = "klem" Then
            query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBarang,NamaBarang,harga,qty,do.disc," & _
              "  TanggalSJ TglSJ,KdSJ 'No. SJ' from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO" & _
              "  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbarang mp on mp.KDBarang=do.KDBarang" & _
              "  join mstoko c on c.kdtoko = ho.kdtoko    where ho.KDFaktur='" & idPrint & "'"
        Else
            query = "select so.KdSo,TanggalSO,NamaToko,ho.KdFaktur `No Faktur`,TanggalFaktur `Tgl Faktur`,mp.KdBahanMentah KdBarang ,NamaBahanMentah NamaBarang,harga,qty,do.disc,HargaDisc,  " & _
              "  TanggalSJ TglSJ,KdSJ 'No. SJ' from trsalesorder so join  trfaktur ho on so.kdso=ho.KdSO " & _
              "  join trfakturdetail do  on ho.KdFaktur=do.KDFaktur join Msbahanmentah mp on mp.KDBahanmentah=do.KDBarang " & _
              "  join mstoko c on c.kdtoko = ho.kdtoko  where ho.KDFaktur='" & idPrint & "'"
        End If
        If type = "faktur" Then
            dropviewM("viewCetakTrFaktur" & kdKaryawan)
            createviewM(query, "viewCetakTrFaktur" & kdKaryawan)
            flagLaporan = "faktur"
        Else
            dropviewM("viewCetakTrSuratJalan" & kdKaryawan)
            createviewM(query, "viewCetakTrSuratJalan" & kdKaryawan)
            flagLaporan = "sj"
        End If
        open_subpage("CRPrintTransaksi")
    End Sub

    Private Sub ToolStripButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ToolStripButton2.Click
        Dim sql As String = " Update trfaktur set TanggalSJ = '" & dtpSJ.Value.ToString("yyyy/MM/dd HH:mm:ss") & "', " & _
                            " KdSJ = '" & txtNoSJ.Text & "' " & _
                            " Where KdFaktur = '" & data_carier(0) & "' "
        execute_update(sql)
        print("sj")
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub txtNoSJ_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtNoSJ.Leave
        If txtNoSJ.Text.Length > 20 Then
            MsgBox("Maksimal kharakter No. SJ adalah 20.", MsgBoxStyle.Information)
            txtNoSJ.Text = data_carier(0).ToString.Replace("FK", "SJ")
        End If
    End Sub
End Class
