<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProduksiPantekManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProduksiPantekManagement))
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtKdPantek = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTelepon = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.dtpPantek = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.lblSatuanKg = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtQtyPaku = New System.Windows.Forms.TextBox
        Me.txtQtyKlemMentah = New System.Windows.Forms.TextBox
        Me.browsePaku = New System.Windows.Forms.Button
        Me.cmbQtyPaku = New System.Windows.Forms.ComboBox
        Me.cmbPaku = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbQtyKlemMentah = New System.Windows.Forms.ComboBox
        Me.browseKlemMentah = New System.Windows.Forms.Button
        Me.cmbKlemMentah = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.browseKaryawan = New System.Windows.Forms.Button
        Me.cmbKaryawan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridBarang = New System.Windows.Forms.DataGridView
        Me.clmKdKlem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKdPaku = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemKg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranPaku = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyPakuKg = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyPaku = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKdPantek)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTelepon)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.dtpPantek)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.browseKaryawan)
        Me.GroupBox2.Controls.Add(Me.cmbKaryawan)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 236)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'txtKdPantek
        '
        Me.txtKdPantek.AutoSize = True
        Me.txtKdPantek.Location = New System.Drawing.Point(155, 22)
        Me.txtKdPantek.Name = "txtKdPantek"
        Me.txtKdPantek.Size = New System.Drawing.Size(0, 13)
        Me.txtKdPantek.TabIndex = 589
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(18, 19)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(67, 15)
        Me.lblKodekaryawan.TabIndex = 588
        Me.lblKodekaryawan.Text = "No. Pantek"
        '
        'txtAlamat
        '
        Me.txtAlamat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(158, 113)
        Me.txtAlamat.MaxLength = 20
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(236, 22)
        Me.txtAlamat.TabIndex = 587
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 116)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(102, 15)
        Me.Label14.TabIndex = 586
        Me.Label14.Text = "Alamat Karyawan"
        '
        'txtTelepon
        '
        Me.txtTelepon.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTelepon.Enabled = False
        Me.txtTelepon.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelepon.Location = New System.Drawing.Point(158, 141)
        Me.txtTelepon.MaxLength = 20
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New System.Drawing.Size(236, 22)
        Me.txtTelepon.TabIndex = 585
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 144)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 15)
        Me.Label3.TabIndex = 584
        Me.Label3.Text = "Handphone Karyawan"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(591, 207)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(99, 23)
        Me.btnRemove.TabIndex = 572
        Me.btnRemove.Text = "Hapus Barang"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(467, 207)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(109, 23)
        Me.btnAdd.TabIndex = 571
        Me.btnAdd.Text = "Tambah Barang"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'dtpPantek
        '
        Me.dtpPantek.Location = New System.Drawing.Point(158, 50)
        Me.dtpPantek.Name = "dtpPantek"
        Me.dtpPantek.Size = New System.Drawing.Size(236, 20)
        Me.dtpPantek.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(18, 53)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(52, 15)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Tanggal"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label9)
        Me.GroupBox3.Controls.Add(Me.lblSatuanKg)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtQtyPaku)
        Me.GroupBox3.Controls.Add(Me.txtQtyKlemMentah)
        Me.GroupBox3.Controls.Add(Me.browsePaku)
        Me.GroupBox3.Controls.Add(Me.cmbQtyPaku)
        Me.GroupBox3.Controls.Add(Me.cmbPaku)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.cmbQtyKlemMentah)
        Me.GroupBox3.Controls.Add(Me.browseKlemMentah)
        Me.GroupBox3.Controls.Add(Me.cmbKlemMentah)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(458, 19)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(415, 182)
        Me.GroupBox3.TabIndex = 568
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Barang"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(367, 118)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 16)
        Me.Label9.TabIndex = 619
        Me.Label9.Text = "/ Kg"
        '
        'lblSatuanKg
        '
        Me.lblSatuanKg.AutoSize = True
        Me.lblSatuanKg.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSatuanKg.Location = New System.Drawing.Point(367, 62)
        Me.lblSatuanKg.Name = "lblSatuanKg"
        Me.lblSatuanKg.Size = New System.Drawing.Size(31, 16)
        Me.lblSatuanKg.TabIndex = 615
        Me.lblSatuanKg.Text = "/ Kg"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(233, 115)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(68, 15)
        Me.Label10.TabIndex = 618
        Me.Label10.Text = "/ Kardus Or"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(233, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(69, 15)
        Me.Label8.TabIndex = 613
        Me.Label8.Text = "/ Karung Or"
        '
        'txtQtyPaku
        '
        Me.txtQtyPaku.Enabled = False
        Me.txtQtyPaku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyPaku.Location = New System.Drawing.Point(166, 112)
        Me.txtQtyPaku.MaxLength = 20
        Me.txtQtyPaku.Name = "txtQtyPaku"
        Me.txtQtyPaku.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyPaku.TabIndex = 617
        '
        'txtQtyKlemMentah
        '
        Me.txtQtyKlemMentah.Enabled = False
        Me.txtQtyKlemMentah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemMentah.Location = New System.Drawing.Point(166, 56)
        Me.txtQtyKlemMentah.MaxLength = 20
        Me.txtQtyKlemMentah.Name = "txtQtyKlemMentah"
        Me.txtQtyKlemMentah.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemMentah.TabIndex = 612
        '
        'browsePaku
        '
        Me.browsePaku.Location = New System.Drawing.Point(378, 85)
        Me.browsePaku.Name = "browsePaku"
        Me.browsePaku.Size = New System.Drawing.Size(23, 21)
        Me.browsePaku.TabIndex = 581
        Me.browsePaku.Text = "..."
        Me.browsePaku.UseVisualStyleBackColor = True
        '
        'cmbQtyPaku
        '
        Me.cmbQtyPaku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQtyPaku.FormattingEnabled = True
        Me.cmbQtyPaku.Location = New System.Drawing.Point(308, 115)
        Me.cmbQtyPaku.Name = "cmbQtyPaku"
        Me.cmbQtyPaku.Size = New System.Drawing.Size(53, 21)
        Me.cmbQtyPaku.TabIndex = 582
        '
        'cmbPaku
        '
        Me.cmbPaku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPaku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPaku.FormattingEnabled = True
        Me.cmbPaku.Location = New System.Drawing.Point(165, 83)
        Me.cmbPaku.Name = "cmbPaku"
        Me.cmbPaku.Size = New System.Drawing.Size(207, 24)
        Me.cmbPaku.TabIndex = 580
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 116)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 15)
        Me.Label5.TabIndex = 579
        Me.Label5.Text = "Jumlah Paku"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(29, 86)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 15)
        Me.Label7.TabIndex = 578
        Me.Label7.Text = "Paku"
        '
        'cmbQtyKlemMentah
        '
        Me.cmbQtyKlemMentah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQtyKlemMentah.Enabled = False
        Me.cmbQtyKlemMentah.FormattingEnabled = True
        Me.cmbQtyKlemMentah.Location = New System.Drawing.Point(308, 57)
        Me.cmbQtyKlemMentah.Name = "cmbQtyKlemMentah"
        Me.cmbQtyKlemMentah.Size = New System.Drawing.Size(53, 21)
        Me.cmbQtyKlemMentah.TabIndex = 576
        '
        'browseKlemMentah
        '
        Me.browseKlemMentah.Location = New System.Drawing.Point(378, 28)
        Me.browseKlemMentah.Name = "browseKlemMentah"
        Me.browseKlemMentah.Size = New System.Drawing.Size(23, 21)
        Me.browseKlemMentah.TabIndex = 572
        Me.browseKlemMentah.Text = "..."
        Me.browseKlemMentah.UseVisualStyleBackColor = True
        '
        'cmbKlemMentah
        '
        Me.cmbKlemMentah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKlemMentah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKlemMentah.FormattingEnabled = True
        Me.cmbKlemMentah.Location = New System.Drawing.Point(165, 26)
        Me.cmbKlemMentah.Name = "cmbKlemMentah"
        Me.cmbKlemMentah.Size = New System.Drawing.Size(207, 24)
        Me.cmbKlemMentah.TabIndex = 571
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(125, 15)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Jumlah Klem Mentah"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(28, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(81, 15)
        Me.Label21.TabIndex = 505
        Me.Label21.Text = "Klem Mentah"
        '
        'browseKaryawan
        '
        Me.browseKaryawan.Location = New System.Drawing.Point(371, 85)
        Me.browseKaryawan.Name = "browseKaryawan"
        Me.browseKaryawan.Size = New System.Drawing.Size(23, 21)
        Me.browseKaryawan.TabIndex = 560
        Me.browseKaryawan.Text = "..."
        Me.browseKaryawan.UseVisualStyleBackColor = True
        Me.browseKaryawan.Visible = False
        '
        'cmbKaryawan
        '
        Me.cmbKaryawan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKaryawan.FormattingEnabled = True
        Me.cmbKaryawan.Location = New System.Drawing.Point(158, 83)
        Me.cmbKaryawan.Name = "cmbKaryawan"
        Me.cmbKaryawan.Size = New System.Drawing.Size(207, 24)
        Me.cmbKaryawan.TabIndex = 559
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 85)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(102, 15)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Karyawan Pantek"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator4, Me.btnConfirms, Me.ToolStripSeparator1, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(926, 54)
        Me.main_tool_strip.TabIndex = 506
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
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 54)
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
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlem, Me.clmKdPaku, Me.clmUkuranKlem, Me.clmQtyKlemKg, Me.clmQtyKlem, Me.clmUkuranPaku, Me.clmQtyPakuKg, Me.clmQtyPaku})
        Me.gridBarang.Location = New System.Drawing.Point(14, 306)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.Size = New System.Drawing.Size(900, 244)
        Me.gridBarang.TabIndex = 509
        '
        'clmKdKlem
        '
        Me.clmKdKlem.HeaderText = "No. Klem"
        Me.clmKdKlem.Name = "clmKdKlem"
        Me.clmKdKlem.ReadOnly = True
        Me.clmKdKlem.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmKdKlem.Visible = False
        '
        'clmKdPaku
        '
        Me.clmKdPaku.HeaderText = "No. Paku"
        Me.clmKdPaku.Name = "clmKdPaku"
        Me.clmKdPaku.Visible = False
        '
        'clmUkuranKlem
        '
        Me.clmUkuranKlem.HeaderText = "Ukuran Klem"
        Me.clmUkuranKlem.Name = "clmUkuranKlem"
        Me.clmUkuranKlem.ReadOnly = True
        '
        'clmQtyKlemKg
        '
        Me.clmQtyKlemKg.HeaderText = "Jumlah Klem ( Kg )"
        Me.clmQtyKlemKg.Name = "clmQtyKlemKg"
        Me.clmQtyKlemKg.ReadOnly = True
        Me.clmQtyKlemKg.Width = 120
        '
        'clmQtyKlem
        '
        Me.clmQtyKlem.HeaderText = "Jumlah Klem ( Karung ) *"
        Me.clmQtyKlem.Name = "clmQtyKlem"
        Me.clmQtyKlem.Width = 150
        '
        'clmUkuranPaku
        '
        Me.clmUkuranPaku.HeaderText = "Ukuran Paku"
        Me.clmUkuranPaku.Name = "clmUkuranPaku"
        Me.clmUkuranPaku.ReadOnly = True
        '
        'clmQtyPakuKg
        '
        Me.clmQtyPakuKg.HeaderText = "Jumlah Paku ( Kg )"
        Me.clmQtyPakuKg.Name = "clmQtyPakuKg"
        Me.clmQtyPakuKg.ReadOnly = True
        Me.clmQtyPakuKg.Width = 120
        '
        'clmQtyPaku
        '
        Me.clmQtyPaku.HeaderText = "Jumlah Paku ( Kardus ) *"
        Me.clmQtyPaku.Name = "clmQtyPaku"
        Me.clmQtyPaku.Width = 150
        '
        'FormProduksiPantekManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(926, 649)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Name = "FormProduksiPantekManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produksi Pantek"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dtpPantek As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents browseKlemMentah As System.Windows.Forms.Button
    Friend WithEvents cmbKlemMentah As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents browseKaryawan As System.Windows.Forms.Button
    Friend WithEvents cmbKaryawan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelepon As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cmbQtyKlemMentah As System.Windows.Forms.ComboBox
    Friend WithEvents cmbQtyPaku As System.Windows.Forms.ComboBox
    Friend WithEvents browsePaku As System.Windows.Forms.Button
    Friend WithEvents cmbPaku As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtKdPantek As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents lblSatuanKg As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemMentah As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyPaku As System.Windows.Forms.TextBox
    Friend WithEvents clmKdKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdPaku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemKg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranPaku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyPakuKg As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyPaku As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
