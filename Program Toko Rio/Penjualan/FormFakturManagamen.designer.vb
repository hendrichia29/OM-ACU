<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormFakturManagamen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormFakturManagamen))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtTotalKomisi = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.txtKomisi = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.TanggalJT = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtToko = New System.Windows.Forms.TextBox
        Me.txtSales = New System.Windows.Forms.TextBox
        Me.BrowseSO = New System.Windows.Forms.Button
        Me.cmbSO = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblDaerah = New System.Windows.Forms.TextBox
        Me.dtpFaktur = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.SeparatorAdd = New System.Windows.Forms.ToolStripSeparator
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.SeparatorConfirm = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.gridBarang = New System.Windows.Forms.DataGridView
        Me.txt_jumlah = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_disc_faktur = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.clmPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmStock = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHargaJual = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHargaDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyOri = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKomisi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txtTotalKomisi)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.txtKomisi)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.TanggalJT)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtToko)
        Me.GroupBox2.Controls.Add(Me.txtSales)
        Me.GroupBox2.Controls.Add(Me.BrowseSO)
        Me.GroupBox2.Controls.Add(Me.cmbSO)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblDaerah)
        Me.GroupBox2.Controls.Add(Me.dtpFaktur)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(947, 195)
        Me.GroupBox2.TabIndex = 476
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(767, 105)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(28, 15)
        Me.Label8.TabIndex = 587
        Me.Label8.Text = "IDR"
        Me.Label8.Visible = False
        '
        'txtTotalKomisi
        '
        Me.txtTotalKomisi.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTotalKomisi.Enabled = False
        Me.txtTotalKomisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTotalKomisi.Location = New System.Drawing.Point(578, 105)
        Me.txtTotalKomisi.MaxLength = 20
        Me.txtTotalKomisi.Name = "txtTotalKomisi"
        Me.txtTotalKomisi.Size = New System.Drawing.Size(183, 22)
        Me.txtTotalKomisi.TabIndex = 586
        Me.txtTotalKomisi.Visible = False
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(485, 108)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(75, 15)
        Me.Label9.TabIndex = 585
        Me.Label9.Text = "Total Komisi"
        Me.Label9.Visible = False
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(639, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(18, 15)
        Me.Label7.TabIndex = 584
        Me.Label7.Text = "%"
        Me.Label7.Visible = False
        '
        'txtKomisi
        '
        Me.txtKomisi.BackColor = System.Drawing.SystemColors.ButtonHighlight
        Me.txtKomisi.Enabled = False
        Me.txtKomisi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKomisi.Location = New System.Drawing.Point(578, 77)
        Me.txtKomisi.MaxLength = 20
        Me.txtKomisi.Name = "txtKomisi"
        Me.txtKomisi.Size = New System.Drawing.Size(55, 22)
        Me.txtKomisi.TabIndex = 583
        Me.txtKomisi.Visible = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(485, 80)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 582
        Me.Label5.Text = "Komisi Sales"
        Me.Label5.Visible = False
        '
        'TanggalJT
        '
        Me.TanggalJT.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.TanggalJT.Enabled = False
        Me.TanggalJT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TanggalJT.Location = New System.Drawing.Point(578, 49)
        Me.TanggalJT.MaxLength = 20
        Me.TanggalJT.Name = "TanggalJT"
        Me.TanggalJT.Size = New System.Drawing.Size(236, 22)
        Me.TanggalJT.TabIndex = 581
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(485, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(75, 15)
        Me.Label2.TabIndex = 580
        Me.Label2.Text = "Jatuh tempo"
        '
        'txtToko
        '
        Me.txtToko.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtToko.Enabled = False
        Me.txtToko.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtToko.Location = New System.Drawing.Point(165, 131)
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
        'BrowseSO
        '
        Me.BrowseSO.Location = New System.Drawing.Point(378, 74)
        Me.BrowseSO.Name = "BrowseSO"
        Me.BrowseSO.Size = New System.Drawing.Size(23, 21)
        Me.BrowseSO.TabIndex = 577
        Me.BrowseSO.Text = "..."
        Me.BrowseSO.UseVisualStyleBackColor = True
        '
        'cmbSO
        '
        Me.cmbSO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbSO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSO.FormattingEnabled = True
        Me.cmbSO.Location = New System.Drawing.Point(165, 72)
        Me.cmbSO.Name = "cmbSO"
        Me.cmbSO.Size = New System.Drawing.Size(207, 24)
        Me.cmbSO.TabIndex = 576
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(25, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(96, 15)
        Me.Label13.TabIndex = 575
        Me.Label13.Text = "No. Pemesanan"
        '
        'lblDaerah
        '
        Me.lblDaerah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblDaerah.Enabled = False
        Me.lblDaerah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDaerah.Location = New System.Drawing.Point(165, 162)
        Me.lblDaerah.MaxLength = 20
        Me.lblDaerah.Name = "lblDaerah"
        Me.lblDaerah.Size = New System.Drawing.Size(236, 22)
        Me.lblDaerah.TabIndex = 573
        '
        'dtpFaktur
        '
        Me.dtpFaktur.Location = New System.Drawing.Point(165, 46)
        Me.dtpFaktur.Name = "dtpFaktur"
        Me.dtpFaktur.Size = New System.Drawing.Size(236, 20)
        Me.dtpFaktur.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(89, 15)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Tanggal Faktur"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(25, 198)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 15)
        Me.Label4.TabIndex = 563
        Me.Label4.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 168)
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
        Me.Label1.Location = New System.Drawing.Point(25, 138)
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
        Me.lblKodekaryawan.Size = New System.Drawing.Size(63, 15)
        Me.lblKodekaryawan.TabIndex = 480
        Me.lblKodekaryawan.Text = "No. Faktur"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.SeparatorAdd, Me.btnConfirms, Me.SeparatorConfirm, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(986, 54)
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
        'SeparatorAdd
        '
        Me.SeparatorAdd.Name = "SeparatorAdd"
        Me.SeparatorAdd.Size = New System.Drawing.Size(6, 54)
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
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(380, 494)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 24)
        Me.Label6.TabIndex = 502
        Me.Label6.Text = "Grand Total ( IDR )"
        '
        'lblGrandtotal
        '
        Me.lblGrandtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGrandtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblGrandtotal.Enabled = False
        Me.lblGrandtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(551, 494)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(118, 24)
        Me.lblGrandtotal.TabIndex = 503
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'gridBarang
        '
        Me.gridBarang.AllowUserToAddRows = False
        Me.gridBarang.AllowUserToDeleteRows = False
        Me.gridBarang.AllowUserToOrderColumns = True
        Me.gridBarang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmPartNo, Me.clmNamaBarang, Me.clmMerk, Me.clmStock, Me.clmHargaJual, Me.clmHargaDisc, Me.clmDisc, Me.clmQty, Me.clmSubtotal, Me.clmQtyOri, Me.clmStatus, Me.clmKomisi})
        Me.gridBarang.Location = New System.Drawing.Point(12, 258)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.Size = New System.Drawing.Size(947, 230)
        Me.gridBarang.TabIndex = 504
        '
        'txt_jumlah
        '
        Me.txt_jumlah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_jumlah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_jumlah.Enabled = False
        Me.txt_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah.Location = New System.Drawing.Point(530, 567)
        Me.txt_jumlah.Multiline = True
        Me.txt_jumlah.Name = "txt_jumlah"
        Me.txt_jumlah.Size = New System.Drawing.Size(139, 24)
        Me.txt_jumlah.TabIndex = 586
        Me.txt_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(380, 567)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 24)
        Me.Label25.TabIndex = 585
        Me.Label25.Text = "Jumlah ( IDR )"
        '
        'txt_disc_faktur
        '
        Me.txt_disc_faktur.Enabled = False
        Me.txt_disc_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_disc_faktur.Location = New System.Drawing.Point(628, 524)
        Me.txt_disc_faktur.MaxLength = 20
        Me.txt_disc_faktur.Name = "txt_disc_faktur"
        Me.txt_disc_faktur.Size = New System.Drawing.Size(41, 22)
        Me.txt_disc_faktur.TabIndex = 587
        Me.txt_disc_faktur.Text = "0"
        Me.txt_disc_faktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(372, 549)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(334, 13)
        Me.Label24.TabIndex = 584
        Me.Label24.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(380, 522)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 24)
        Me.Label23.TabIndex = 583
        Me.Label23.Text = "Disc (%)"
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
        'clmStock
        '
        Me.clmStock.HeaderText = "Stock Klem"
        Me.clmStock.Name = "clmStock"
        Me.clmStock.ReadOnly = True
        Me.clmStock.Visible = False
        Me.clmStock.Width = 120
        '
        'clmHargaJual
        '
        Me.clmHargaJual.HeaderText = "Harga Jual *"
        Me.clmHargaJual.Name = "clmHargaJual"
        '
        'clmHargaDisc
        '
        Me.clmHargaDisc.HeaderText = "Harga Disc"
        Me.clmHargaDisc.Name = "clmHargaDisc"
        Me.clmHargaDisc.Visible = False
        '
        'clmDisc
        '
        Me.clmDisc.HeaderText = "Disc ( % )"
        Me.clmDisc.Name = "clmDisc"
        Me.clmDisc.Visible = False
        '
        'clmQty
        '
        Me.clmQty.HeaderText = "Jumlah *"
        Me.clmQty.Name = "clmQty"
        '
        'clmSubtotal
        '
        Me.clmSubtotal.HeaderText = "Subtotal"
        Me.clmSubtotal.Name = "clmSubtotal"
        Me.clmSubtotal.ReadOnly = True
        '
        'clmQtyOri
        '
        Me.clmQtyOri.HeaderText = "QtyOri"
        Me.clmQtyOri.Name = "clmQtyOri"
        Me.clmQtyOri.Visible = False
        '
        'clmStatus
        '
        Me.clmStatus.HeaderText = "Status Barang"
        Me.clmStatus.Name = "clmStatus"
        Me.clmStatus.ReadOnly = True
        Me.clmStatus.Visible = False
        '
        'clmKomisi
        '
        Me.clmKomisi.HeaderText = "Komisi"
        Me.clmKomisi.Name = "clmKomisi"
        Me.clmKomisi.Visible = False
        '
        'FormFakturManagamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(986, 600)
        Me.Controls.Add(Me.txt_jumlah)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_disc_faktur)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormFakturManagamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Faktur"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorAdd As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtpFaktur As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents lblDaerah As System.Windows.Forms.TextBox
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents BrowseSO As System.Windows.Forms.Button
    Friend WithEvents cmbSO As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtToko As System.Windows.Forms.TextBox
    Friend WithEvents txtSales As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorConfirm As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents TanggalJT As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtKomisi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtTotalKomisi As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_disc_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents clmPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmStock As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHargaJual As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHargaDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSubtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyOri As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmStatus As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKomisi As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
