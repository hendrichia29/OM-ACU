Module ModuleProgram
    Public sql As String
    Public dbName As String = "db_tokoacu "
    Public kdKaryawan As String
    Public namaKaryawan As String
    Public data_carier(6) 'variable for parameter passing
    Public flagLaporan As String
    Public lvlKaryawan As Integer
    Public lvlStaffRio As Integer = 1
    Public lvlStaffLain As Integer = 2
    Public lvlSuperuser As Integer = 3

    Public tglMulai As String
    Public tglAkhir As String
    Public idPrint As String
    Public areaReport As String
    Public jenisReport As String

    Public kdFisingView As String

    Public komisiSalesSalesPayment As Double
    Public grandTotalSalesPayment As Double
    Public totalKomisiSalesSalesPayment As Double
    Public jumlahSetelahKomisiSalesPayment As Double
    Public jumlahSetelahPotonganSalesPayment As Double
    Public discAmountSalesPayment As Double
    Public kdSalesPayment As String
    Public tglPayment As String
    Public salesPayment As String
    Public catatanPayment As String
End Module
