<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPaymentByDateManagamen
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing AndAlso components IsNot Nothing Then
            components.Dispose()
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPaymentByDateManagamen))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.browseSales = New System.Windows.Forms.Button
        Me.cmbSales = New System.Windows.Forms.ComboBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.dtp_tgl = New System.Windows.Forms.DateTimePicker
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtp_sampai_tgl = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.dtp_dari_tgl = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.SeparatorConfirm = New System.Windows.Forms.ToolStripSeparator
        Me.BtnPrint = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridBarang = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.lblKomisiName = New System.Windows.Forms.Label
        Me.lbl_disc = New System.Windows.Forms.Label
        Me.txtTotalKomisSales = New System.Windows.Forms.TextBox
        Me.lbl_disc_amount = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.lblJumlahSetelahKomisi = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.lblJumlahSetelahPotongan = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.lblDiscPembayaran = New System.Windows.Forms.TextBox
        Me.Disc = New System.Windows.Forms.Label
        Me.txtDiscPembayaran = New System.Windows.Forms.TextBox
        Me.clmFaktur = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTanggal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSO = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmToko = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmGrandtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKomisiPersen = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTotalKomisi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmLangsungBayar = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.browseSales)
        Me.GroupBox2.Controls.Add(Me.cmbSales)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.dtp_tgl)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtp_sampai_tgl)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.dtp_dari_tgl)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 169)
        Me.GroupBox2.TabIndex = 476
        Me.GroupBox2.TabStop = False
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(159, 119)
        Me.txtNote.MaxLength = 20
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(236, 40)
        Me.txtNote.TabIndex = 597
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(19, 119)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 598
        Me.Label9.Text = "Note"
        '
        'browseSales
        '
        Me.browseSales.Location = New System.Drawing.Point(372, 91)
        Me.browseSales.Name = "browseSales"
        Me.browseSales.Size = New System.Drawing.Size(23, 21)
        Me.browseSales.TabIndex = 596
        Me.browseSales.Text = "..."
        Me.browseSales.UseVisualStyleBackColor = True
        '
        'cmbSales
        '
        Me.cmbSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSales.FormattingEnabled = True
        Me.cmbSales.Location = New System.Drawing.Point(159, 89)
        Me.cmbSales.Name = "cmbSales"
        Me.cmbSales.Size = New System.Drawing.Size(207, 24)
        Me.cmbSales.TabIndex = 595
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(19, 96)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 15)
        Me.Label18.TabIndex = 594
        Me.Label18.Text = "Nama Sales"
        '
        'dtp_tgl
        '
        Me.dtp_tgl.Location = New System.Drawing.Point(159, 35)
        Me.dtp_tgl.Name = "dtp_tgl"
        Me.dtp_tgl.Size = New System.Drawing.Size(236, 20)
        Me.dtp_tgl.TabIndex = 591
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(19, 38)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(125, 15)
        Me.Label3.TabIndex = 590
        Me.Label3.Text = "Tanggal Pembayaran"
        '
        'dtp_sampai_tgl
        '
        Me.dtp_sampai_tgl.Location = New System.Drawing.Point(507, 64)
        Me.dtp_sampai_tgl.Name = "dtp_sampai_tgl"
        Me.dtp_sampai_tgl.Size = New System.Drawing.Size(236, 20)
        Me.dtp_sampai_tgl.TabIndex = 589
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(403, 63)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 15)
        Me.Label1.TabIndex = 588
        Me.Label1.Text = "Sampai Tanggal"
        '
        'dtp_dari_tgl
        '
        Me.dtp_dari_tgl.Location = New System.Drawing.Point(159, 61)
        Me.dtp_dari_tgl.Name = "dtp_dari_tgl"
        Me.dtp_dari_tgl.Size = New System.Drawing.Size(236, 20)
        Me.dtp_dari_tgl.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(19, 64)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(78, 15)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Dari Tanggal"
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(156, 16)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(0, 13)
        Me.txtID.TabIndex = 501
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(19, 13)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(99, 15)
        Me.lblKodekaryawan.TabIndex = 480
        Me.lblKodekaryawan.Text = "No. Pembayaran"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator4, Me.btnConfirms, Me.SeparatorConfirm, Me.BtnPrint, Me.ToolStripSeparator3, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(1022, 54)
        Me.main_tool_strip.TabIndex = 478
        Me.main_tool_strip.Text = "Tool Strip"
        '
        'btnSave
        '
        Me.btnSave.Image = CType(resources.GetObject("btnSave.Image"), System.Drawing.Image)
        Me.btnSave.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(51, 51)
        Me.btnSave.Text = "Simpan"
        Me.btnSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'btnConfirms
        '
        Me.btnConfirms.Image = CType(resources.GetObject("btnConfirms.Image"), System.Drawing.Image)
        Me.btnConfirms.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnConfirms.Name = "btnConfirms"
        Me.btnConfirms.Size = New System.Drawing.Size(55, 51)
        Me.btnConfirms.Text = "Confirm"
        Me.btnConfirms.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnConfirms.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'SeparatorConfirm
        '
        Me.SeparatorConfirm.Name = "SeparatorConfirm"
        Me.SeparatorConfirm.Size = New System.Drawing.Size(6, 54)
        '
        'BtnPrint
        '
        Me.BtnPrint.Image = CType(resources.GetObject("BtnPrint.Image"), System.Drawing.Image)
        Me.BtnPrint.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(36, 51)
        Me.BtnPrint.Text = "Print"
        Me.BtnPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BtnPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 54)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(44, 51)
        Me.btnExit.Text = "Keluar"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'gridBarang
        '
        Me.gridBarang.AllowUserToAddRows = False
        Me.gridBarang.AllowUserToDeleteRows = False
        Me.gridBarang.AllowUserToOrderColumns = True
        Me.gridBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmFaktur, Me.clmTanggal, Me.clmSO, Me.clmToko, Me.clmDisc, Me.clmJumlah, Me.clmGrandtotal, Me.clmKomisiPersen, Me.clmTotalKomisi, Me.clmLangsungBayar})
        Me.gridBarang.Location = New System.Drawing.Point(12, 232)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.ReadOnly = True
        Me.gridBarang.Size = New System.Drawing.Size(998, 150)
        Me.gridBarang.TabIndex = 504
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(486, 387)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(111, 20)
        Me.Label6.TabIndex = 502
        Me.Label6.Text = "Jumlah ( IDR )"
        '
        'lblGrandtotal
        '
        Me.lblGrandtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGrandtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblGrandtotal.Enabled = False
        Me.lblGrandtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(666, 387)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(134, 20)
        Me.lblGrandtotal.TabIndex = 503
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKomisiName
        '
        Me.lblKomisiName.AutoSize = True
        Me.lblKomisiName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKomisiName.Location = New System.Drawing.Point(486, 413)
        Me.lblKomisiName.Name = "lblKomisiName"
        Me.lblKomisiName.Size = New System.Drawing.Size(99, 20)
        Me.lblKomisiName.TabIndex = 512
        Me.lblKomisiName.Text = "Komisi Sales"
        '
        'lbl_disc
        '
        Me.lbl_disc.AutoSize = True
        Me.lbl_disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_disc.Location = New System.Drawing.Point(486, 507)
        Me.lbl_disc.Name = "lbl_disc"
        Me.lbl_disc.Size = New System.Drawing.Size(78, 20)
        Me.lbl_disc.TabIndex = 513
        Me.lbl_disc.Text = "Potongan"
        '
        'txtTotalKomisSales
        '
        Me.txtTotalKomisSales.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalKomisSales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalKomisSales.Enabled = False
        Me.txtTotalKomisSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalKomisSales.Location = New System.Drawing.Point(666, 413)
        Me.txtTotalKomisSales.Multiline = True
        Me.txtTotalKomisSales.Name = "txtTotalKomisSales"
        Me.txtTotalKomisSales.Size = New System.Drawing.Size(134, 20)
        Me.txtTotalKomisSales.TabIndex = 514
        Me.txtTotalKomisSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lbl_disc_amount
        '
        Me.lbl_disc_amount.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lbl_disc_amount.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lbl_disc_amount.Enabled = False
        Me.lbl_disc_amount.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl_disc_amount.Location = New System.Drawing.Point(666, 507)
        Me.lbl_disc_amount.Multiline = True
        Me.lbl_disc_amount.Name = "lbl_disc_amount"
        Me.lbl_disc_amount.Size = New System.Drawing.Size(134, 20)
        Me.lbl_disc_amount.TabIndex = 515
        Me.lbl_disc_amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(487, 436)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(334, 13)
        Me.Label4.TabIndex = 516
        Me.Label4.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'lblJumlahSetelahKomisi
        '
        Me.lblJumlahSetelahKomisi.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblJumlahSetelahKomisi.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJumlahSetelahKomisi.Enabled = False
        Me.lblJumlahSetelahKomisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJumlahSetelahKomisi.Location = New System.Drawing.Point(666, 452)
        Me.lblJumlahSetelahKomisi.Multiline = True
        Me.lblJumlahSetelahKomisi.Name = "lblJumlahSetelahKomisi"
        Me.lblJumlahSetelahKomisi.Size = New System.Drawing.Size(134, 20)
        Me.lblJumlahSetelahKomisi.TabIndex = 518
        Me.lblJumlahSetelahKomisi.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(486, 452)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(111, 20)
        Me.Label13.TabIndex = 517
        Me.Label13.Text = "Jumlah ( IDR )"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(487, 530)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(334, 13)
        Me.Label14.TabIndex = 519
        Me.Label14.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'lblJumlahSetelahPotongan
        '
        Me.lblJumlahSetelahPotongan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblJumlahSetelahPotongan.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblJumlahSetelahPotongan.Enabled = False
        Me.lblJumlahSetelahPotongan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJumlahSetelahPotongan.Location = New System.Drawing.Point(666, 546)
        Me.lblJumlahSetelahPotongan.Multiline = True
        Me.lblJumlahSetelahPotongan.Name = "lblJumlahSetelahPotongan"
        Me.lblJumlahSetelahPotongan.Size = New System.Drawing.Size(134, 20)
        Me.lblJumlahSetelahPotongan.TabIndex = 521
        Me.lblJumlahSetelahPotongan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.Location = New System.Drawing.Point(486, 546)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(111, 20)
        Me.Label15.TabIndex = 520
        Me.Label15.Text = "Jumlah ( IDR )"
        '
        'lblDiscPembayaran
        '
        Me.lblDiscPembayaran.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDiscPembayaran.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblDiscPembayaran.Enabled = False
        Me.lblDiscPembayaran.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDiscPembayaran.Location = New System.Drawing.Point(666, 481)
        Me.lblDiscPembayaran.Multiline = True
        Me.lblDiscPembayaran.Name = "lblDiscPembayaran"
        Me.lblDiscPembayaran.Size = New System.Drawing.Size(134, 20)
        Me.lblDiscPembayaran.TabIndex = 523
        Me.lblDiscPembayaran.Text = "0"
        Me.lblDiscPembayaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Disc
        '
        Me.Disc.AutoSize = True
        Me.Disc.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Disc.Location = New System.Drawing.Point(486, 481)
        Me.Disc.Name = "Disc"
        Me.Disc.Size = New System.Drawing.Size(76, 20)
        Me.Disc.TabIndex = 522
        Me.Disc.Text = "Disc ( % )"
        '
        'txtDiscPembayaran
        '
        Me.txtDiscPembayaran.Location = New System.Drawing.Point(568, 481)
        Me.txtDiscPembayaran.Name = "txtDiscPembayaran"
        Me.txtDiscPembayaran.Size = New System.Drawing.Size(42, 20)
        Me.txtDiscPembayaran.TabIndex = 524
        Me.txtDiscPembayaran.Text = "0"
        Me.txtDiscPembayaran.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'clmFaktur
        '
        Me.clmFaktur.HeaderText = "No. Faktur"
        Me.clmFaktur.Name = "clmFaktur"
        Me.clmFaktur.ReadOnly = True
        Me.clmFaktur.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmFaktur.Width = 120
        '
        'clmTanggal
        '
        Me.clmTanggal.HeaderText = "Tanggal"
        Me.clmTanggal.Name = "clmTanggal"
        Me.clmTanggal.ReadOnly = True
        '
        'clmSO
        '
        Me.clmSO.HeaderText = "No. SO"
        Me.clmSO.Name = "clmSO"
        Me.clmSO.ReadOnly = True
        Me.clmSO.Width = 120
        '
        'clmToko
        '
        Me.clmToko.HeaderText = "Nama Toko"
        Me.clmToko.Name = "clmToko"
        Me.clmToko.ReadOnly = True
        '
        'clmDisc
        '
        Me.clmDisc.HeaderText = "Disc"
        Me.clmDisc.Name = "clmDisc"
        Me.clmDisc.ReadOnly = True
        '
        'clmJumlah
        '
        Me.clmJumlah.HeaderText = "Jumlah"
        Me.clmJumlah.Name = "clmJumlah"
        Me.clmJumlah.ReadOnly = True
        '
        'clmGrandtotal
        '
        Me.clmGrandtotal.HeaderText = "Total Faktur"
        Me.clmGrandtotal.Name = "clmGrandtotal"
        Me.clmGrandtotal.ReadOnly = True
        Me.clmGrandtotal.Visible = False
        '
        'clmKomisiPersen
        '
        Me.clmKomisiPersen.HeaderText = "Komisi ( % )"
        Me.clmKomisiPersen.Name = "clmKomisiPersen"
        Me.clmKomisiPersen.ReadOnly = True
        Me.clmKomisiPersen.Visible = False
        '
        'clmTotalKomisi
        '
        Me.clmTotalKomisi.HeaderText = "Total Komisi"
        Me.clmTotalKomisi.Name = "clmTotalKomisi"
        Me.clmTotalKomisi.ReadOnly = True
        Me.clmTotalKomisi.Visible = False
        '
        'clmLangsungBayar
        '
        Me.clmLangsungBayar.HeaderText = "Langsung Bayar"
        Me.clmLangsungBayar.Name = "clmLangsungBayar"
        Me.clmLangsungBayar.ReadOnly = True
        Me.clmLangsungBayar.Width = 120
        '
        'FormSalesPaymentByDateManagamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1022, 583)
        Me.Controls.Add(Me.txtDiscPembayaran)
        Me.Controls.Add(Me.lblDiscPembayaran)
        Me.Controls.Add(Me.Disc)
        Me.Controls.Add(Me.lblJumlahSetelahPotongan)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.lblJumlahSetelahKomisi)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.lbl_disc_amount)
        Me.Controls.Add(Me.txtTotalKomisSales)
        Me.Controls.Add(Me.lbl_disc)
        Me.Controls.Add(Me.lblKomisiName)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesPaymentByDateManagamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Pembayaran Faktur"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents dtp_dari_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorConfirm As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents dtp_sampai_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dtp_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents browseSales As System.Windows.Forms.Button
    Friend WithEvents cmbSales As System.Windows.Forms.ComboBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblKomisiName As System.Windows.Forms.Label
    Friend WithEvents lbl_disc As System.Windows.Forms.Label
    Friend WithEvents txtTotalKomisSales As System.Windows.Forms.TextBox
    Friend WithEvents lbl_disc_amount As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents lblJumlahSetelahKomisi As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblJumlahSetelahPotongan As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BtnPrint As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents lblDiscPembayaran As System.Windows.Forms.TextBox
    Friend WithEvents Disc As System.Windows.Forms.Label
    Friend WithEvents txtDiscPembayaran As System.Windows.Forms.TextBox
    Friend WithEvents clmFaktur As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSO As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmToko As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmJumlah As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmGrandtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKomisiPersen As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTotalKomisi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmLangsungBayar As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
