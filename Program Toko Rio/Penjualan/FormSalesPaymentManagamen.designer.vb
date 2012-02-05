<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSalesPaymentManagamen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSalesPaymentManagamen))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtToko = New System.Windows.Forms.TextBox
        Me.txtSales = New System.Windows.Forms.TextBox
        Me.BrowseFaktur = New System.Windows.Forms.Button
        Me.cmbFaktur = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblDaerah = New System.Windows.Forms.TextBox
        Me.dtpPayment = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.SeparatorConfirm = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridBarang = New System.Windows.Forms.DataGridView
        Me.clmPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHarga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHargaDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.lblTelahBayar = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblTotalBayar = New System.Windows.Forms.TextBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtPaid = New System.Windows.Forms.TextBox
        Me.txt_disc_payment = New System.Windows.Forms.TextBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.txt_jumlah = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.txtTotalKomisSales = New System.Windows.Forms.TextBox
        Me.lblKomisiName = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtToko)
        Me.GroupBox2.Controls.Add(Me.txtSales)
        Me.GroupBox2.Controls.Add(Me.BrowseFaktur)
        Me.GroupBox2.Controls.Add(Me.cmbFaktur)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblDaerah)
        Me.GroupBox2.Controls.Add(Me.dtpPayment)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 161)
        Me.GroupBox2.TabIndex = 476
        Me.GroupBox2.TabStop = False
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(566, 74)
        Me.txtNote.MaxLength = 20
        Me.txtNote.Multiline = True
        Me.txtNote.Name = "txtNote"
        Me.txtNote.Size = New System.Drawing.Size(236, 79)
        Me.txtNote.TabIndex = 582
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(475, 74)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 583
        Me.Label9.Text = "Note"
        '
        'txtToko
        '
        Me.txtToko.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtToko.Enabled = False
        Me.txtToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToko.Location = New System.Drawing.Point(566, 15)
        Me.txtToko.MaxLength = 20
        Me.txtToko.Name = "txtToko"
        Me.txtToko.Size = New System.Drawing.Size(236, 22)
        Me.txtToko.TabIndex = 579
        '
        'txtSales
        '
        Me.txtSales.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSales.Enabled = False
        Me.txtSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSales.Location = New System.Drawing.Point(165, 102)
        Me.txtSales.MaxLength = 20
        Me.txtSales.Name = "txtSales"
        Me.txtSales.Size = New System.Drawing.Size(236, 22)
        Me.txtSales.TabIndex = 578
        '
        'BrowseFaktur
        '
        Me.BrowseFaktur.Location = New System.Drawing.Point(378, 74)
        Me.BrowseFaktur.Name = "BrowseFaktur"
        Me.BrowseFaktur.Size = New System.Drawing.Size(23, 21)
        Me.BrowseFaktur.TabIndex = 577
        Me.BrowseFaktur.Text = "..."
        Me.BrowseFaktur.UseVisualStyleBackColor = True
        '
        'cmbFaktur
        '
        Me.cmbFaktur.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbFaktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbFaktur.FormattingEnabled = True
        Me.cmbFaktur.Location = New System.Drawing.Point(165, 72)
        Me.cmbFaktur.Name = "cmbFaktur"
        Me.cmbFaktur.Size = New System.Drawing.Size(207, 24)
        Me.cmbFaktur.TabIndex = 576
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(25, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 15)
        Me.Label13.TabIndex = 575
        Me.Label13.Text = "No. Faktur"
        '
        'lblDaerah
        '
        Me.lblDaerah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDaerah.Enabled = False
        Me.lblDaerah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaerah.Location = New System.Drawing.Point(566, 46)
        Me.lblDaerah.MaxLength = 20
        Me.lblDaerah.Name = "lblDaerah"
        Me.lblDaerah.Size = New System.Drawing.Size(236, 22)
        Me.lblDaerah.TabIndex = 573
        '
        'dtpPayment
        '
        Me.dtpPayment.Location = New System.Drawing.Point(165, 46)
        Me.dtpPayment.Name = "dtpPayment"
        Me.dtpPayment.Size = New System.Drawing.Size(236, 20)
        Me.dtpPayment.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(125, 15)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Tanggal Pembayaran"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(475, 48)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 15)
        Me.Label3.TabIndex = 561
        Me.Label3.Text = "Daerah"
        '
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(162, 26)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(0, 13)
        Me.txtID.TabIndex = 501
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(475, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 15)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Nama Toko"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(25, 109)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(75, 15)
        Me.Label18.TabIndex = 481
        Me.Label18.Text = "Nama Sales"
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(25, 23)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(99, 15)
        Me.lblKodekaryawan.TabIndex = 480
        Me.lblKodekaryawan.Text = "No. Pembayaran"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator4, Me.btnConfirms, Me.SeparatorConfirm, Me.btnExit})
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
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmPartNo, Me.clmNamaBarang, Me.clmMerk, Me.clmHarga, Me.clmHargaDisc, Me.clmDisc, Me.clmQty, Me.clmSubtotal, Me.clmStatus})
        Me.gridBarang.Location = New System.Drawing.Point(12, 224)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.ReadOnly = True
        Me.gridBarang.Size = New System.Drawing.Size(998, 216)
        Me.gridBarang.TabIndex = 504
        '
        'clmPartNo
        '
        Me.clmPartNo.HeaderText = "Part No."
        Me.clmPartNo.Name = "clmPartNo"
        Me.clmPartNo.ReadOnly = True
        Me.clmPartNo.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clmNamaBarang
        '
        Me.clmNamaBarang.HeaderText = "Nama Barang"
        Me.clmNamaBarang.Name = "clmNamaBarang"
        Me.clmNamaBarang.ReadOnly = True
        '
        'clmMerk
        '
        Me.clmMerk.HeaderText = "Merk"
        Me.clmMerk.Name = "clmMerk"
        Me.clmMerk.ReadOnly = True
        '
        'clmHarga
        '
        Me.clmHarga.HeaderText = "Harga List"
        Me.clmHarga.Name = "clmHarga"
        Me.clmHarga.ReadOnly = True
        '
        'clmHargaDisc
        '
        Me.clmHargaDisc.HeaderText = "Harga Disc"
        Me.clmHargaDisc.Name = "clmHargaDisc"
        Me.clmHargaDisc.ReadOnly = True
        '
        'clmDisc
        '
        Me.clmDisc.HeaderText = "Disc ( % )"
        Me.clmDisc.Name = "clmDisc"
        Me.clmDisc.ReadOnly = True
        Me.clmDisc.Visible = False
        Me.clmDisc.Width = 80
        '
        'clmQty
        '
        Me.clmQty.HeaderText = "Qty Faktur"
        Me.clmQty.Name = "clmQty"
        Me.clmQty.ReadOnly = True
        '
        'clmSubtotal
        '
        Me.clmSubtotal.HeaderText = "Subtotal"
        Me.clmSubtotal.Name = "clmSubtotal"
        Me.clmSubtotal.ReadOnly = True
        '
        'clmStatus
        '
        Me.clmStatus.HeaderText = "Status Barang"
        Me.clmStatus.Name = "clmStatus"
        Me.clmStatus.ReadOnly = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(450, 446)
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
        Me.lblGrandtotal.Location = New System.Drawing.Point(630, 446)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(134, 20)
        Me.lblGrandtotal.TabIndex = 503
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblTelahBayar
        '
        Me.lblTelahBayar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTelahBayar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTelahBayar.Enabled = False
        Me.lblTelahBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTelahBayar.Location = New System.Drawing.Point(630, 549)
        Me.lblTelahBayar.Multiline = True
        Me.lblTelahBayar.Name = "lblTelahBayar"
        Me.lblTelahBayar.Size = New System.Drawing.Size(134, 20)
        Me.lblTelahBayar.TabIndex = 506
        Me.lblTelahBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(450, 549)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(144, 20)
        Me.Label5.TabIndex = 505
        Me.Label5.Text = "Telah Bayar ( IDR )"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(451, 579)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(334, 13)
        Me.Label7.TabIndex = 507
        Me.Label7.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'lblTotalBayar
        '
        Me.lblTotalBayar.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblTotalBayar.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblTotalBayar.Enabled = False
        Me.lblTotalBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalBayar.Location = New System.Drawing.Point(630, 595)
        Me.lblTotalBayar.Multiline = True
        Me.lblTotalBayar.Name = "lblTotalBayar"
        Me.lblTotalBayar.Size = New System.Drawing.Size(134, 20)
        Me.lblTotalBayar.TabIndex = 509
        Me.lblTotalBayar.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(450, 595)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(140, 20)
        Me.Label8.TabIndex = 508
        Me.Label8.Text = "Total Bayar ( IDR )"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(450, 621)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(101, 20)
        Me.Label10.TabIndex = 510
        Me.Label10.Text = "Bayar ( IDR )"
        '
        'txtPaid
        '
        Me.txtPaid.Location = New System.Drawing.Point(630, 621)
        Me.txtPaid.Name = "txtPaid"
        Me.txtPaid.Size = New System.Drawing.Size(134, 20)
        Me.txtPaid.TabIndex = 511
        Me.txtPaid.Text = "0"
        Me.txtPaid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_disc_payment
        '
        Me.txt_disc_payment.Enabled = False
        Me.txt_disc_payment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_disc_payment.Location = New System.Drawing.Point(723, 472)
        Me.txt_disc_payment.MaxLength = 20
        Me.txt_disc_payment.Name = "txt_disc_payment"
        Me.txt_disc_payment.Size = New System.Drawing.Size(41, 22)
        Me.txt_disc_payment.TabIndex = 594
        Me.txt_disc_payment.Text = "0"
        Me.txt_disc_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(450, 472)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 24)
        Me.Label23.TabIndex = 593
        Me.Label23.Text = "Disc (%)"
        '
        'txt_jumlah
        '
        Me.txt_jumlah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_jumlah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_jumlah.Enabled = False
        Me.txt_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah.Location = New System.Drawing.Point(625, 519)
        Me.txt_jumlah.Multiline = True
        Me.txt_jumlah.Name = "txt_jumlah"
        Me.txt_jumlah.Size = New System.Drawing.Size(139, 24)
        Me.txt_jumlah.TabIndex = 597
        Me.txt_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(450, 519)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 24)
        Me.Label25.TabIndex = 596
        Me.Label25.Text = "Jumlah ( IDR )"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(451, 506)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(334, 13)
        Me.Label24.TabIndex = 595
        Me.Label24.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTotalKomisSales)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 469)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(316, 100)
        Me.GroupBox1.TabIndex = 598
        Me.GroupBox1.TabStop = False
        '
        'txtTotalKomisSales
        '
        Me.txtTotalKomisSales.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalKomisSales.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txtTotalKomisSales.Enabled = False
        Me.txtTotalKomisSales.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalKomisSales.Location = New System.Drawing.Point(176, 37)
        Me.txtTotalKomisSales.Multiline = True
        Me.txtTotalKomisSales.Name = "txtTotalKomisSales"
        Me.txtTotalKomisSales.Size = New System.Drawing.Size(134, 20)
        Me.txtTotalKomisSales.TabIndex = 516
        Me.txtTotalKomisSales.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'lblKomisiName
        '
        Me.lblKomisiName.AutoSize = True
        Me.lblKomisiName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKomisiName.Location = New System.Drawing.Point(25, 506)
        Me.lblKomisiName.Name = "lblKomisiName"
        Me.lblKomisiName.Size = New System.Drawing.Size(99, 20)
        Me.lblKomisiName.TabIndex = 515
        Me.lblKomisiName.Text = "Komisi Sales"
        '
        'FormSalesPaymentManagamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1022, 650)
        Me.Controls.Add(Me.lblKomisiName)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txt_jumlah)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txt_disc_payment)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.txtPaid)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.lblTotalBayar)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblTelahBayar)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSalesPaymentManagamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = " Pembayaran Faktur"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpPayment As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents lblDaerah As System.Windows.Forms.TextBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents BrowseFaktur As System.Windows.Forms.Button
    Friend WithEvents cmbFaktur As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtToko As System.Windows.Forms.TextBox
    Friend WithEvents txtSales As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorConfirm As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents lblTelahBayar As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblTotalBayar As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPaid As System.Windows.Forms.TextBox
    Friend WithEvents clmPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHargaDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSubtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents txt_disc_payment As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTotalKomisSales As System.Windows.Forms.TextBox
    Friend WithEvents lblKomisiName As System.Windows.Forms.Label

End Class
