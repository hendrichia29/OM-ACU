<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProduksiHitungManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProduksiHitungManagement))
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtKdHitung = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTelepon = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpHitung = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.browseKaryawan = New System.Windows.Forms.Button
        Me.cmbKaryawan = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.lblStokKlemPantek = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txtQtyKlemPantek = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.browseKlemPantek = New System.Windows.Forms.Button
        Me.cmbKlemPantek = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridKlemPantek = New System.Windows.Forms.DataGridView
        Me.clmKdKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gridKlemJadi = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txtQtyKlemJadi = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.browseKlemJadi = New System.Windows.Forms.Button
        Me.btnRemoveKlemJadi = New System.Windows.Forms.Button
        Me.btnAddKlemJadi = New System.Windows.Forms.Button
        Me.cmbKlemJadi = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.clmKdKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridKlemPantek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridKlemJadi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKdHitung)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTelepon)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpHitung)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.browseKaryawan)
        Me.GroupBox2.Controls.Add(Me.cmbKaryawan)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 177)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'txtKdHitung
        '
        Me.txtKdHitung.AutoSize = True
        Me.txtKdHitung.Location = New System.Drawing.Point(155, 22)
        Me.txtKdHitung.Name = "txtKdHitung"
        Me.txtKdHitung.Size = New System.Drawing.Size(0, 13)
        Me.txtKdHitung.TabIndex = 589
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(18, 19)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(65, 15)
        Me.lblKodekaryawan.TabIndex = 588
        Me.lblKodekaryawan.Text = "No. Hitung"
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
        'dtpHitung
        '
        Me.dtpHitung.Location = New System.Drawing.Point(158, 50)
        Me.dtpHitung.Name = "dtpHitung"
        Me.dtpHitung.Size = New System.Drawing.Size(236, 20)
        Me.dtpHitung.TabIndex = 570
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
        'browseKaryawan
        '
        Me.browseKaryawan.Location = New System.Drawing.Point(371, 85)
        Me.browseKaryawan.Name = "browseKaryawan"
        Me.browseKaryawan.Size = New System.Drawing.Size(23, 21)
        Me.browseKaryawan.TabIndex = 560
        Me.browseKaryawan.Text = "..."
        Me.browseKaryawan.UseVisualStyleBackColor = True
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
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Karyawan Hitung"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(233, 109)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(61, 23)
        Me.btnRemove.TabIndex = 572
        Me.btnRemove.Text = "Hapus"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(166, 109)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(61, 23)
        Me.btnAdd.TabIndex = 571
        Me.btnAdd.Text = "Tambah"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.lblStokKlemPantek)
        Me.GroupBox3.Controls.Add(Me.Label10)
        Me.GroupBox3.Controls.Add(Me.Label8)
        Me.GroupBox3.Controls.Add(Me.txtQtyKlemPantek)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.browseKlemPantek)
        Me.GroupBox3.Controls.Add(Me.btnRemove)
        Me.GroupBox3.Controls.Add(Me.btnAdd)
        Me.GroupBox3.Controls.Add(Me.cmbKlemPantek)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 247)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(415, 144)
        Me.GroupBox3.TabIndex = 568
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Klem sudah dipantek yang akan dihitung"
        '
        'lblStokKlemPantek
        '
        Me.lblStokKlemPantek.AutoSize = True
        Me.lblStokKlemPantek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStokKlemPantek.Location = New System.Drawing.Point(163, 59)
        Me.lblStokKlemPantek.Name = "lblStokKlemPantek"
        Me.lblStokKlemPantek.Size = New System.Drawing.Size(0, 15)
        Me.lblStokKlemPantek.TabIndex = 619
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(233, 84)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 15)
        Me.Label10.TabIndex = 618
        Me.Label10.Text = "/ Karung"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(233, 59)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 15)
        Me.Label8.TabIndex = 613
        Me.Label8.Text = "/ Karung"
        '
        'txtQtyKlemPantek
        '
        Me.txtQtyKlemPantek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemPantek.Location = New System.Drawing.Point(166, 81)
        Me.txtQtyKlemPantek.MaxLength = 20
        Me.txtQtyKlemPantek.Name = "txtQtyKlemPantek"
        Me.txtQtyKlemPantek.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemPantek.TabIndex = 617
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(28, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 579
        Me.Label5.Text = "Jumlah"
        '
        'browseKlemPantek
        '
        Me.browseKlemPantek.Location = New System.Drawing.Point(378, 28)
        Me.browseKlemPantek.Name = "browseKlemPantek"
        Me.browseKlemPantek.Size = New System.Drawing.Size(23, 21)
        Me.browseKlemPantek.TabIndex = 572
        Me.browseKlemPantek.Text = "..."
        Me.browseKlemPantek.UseVisualStyleBackColor = True
        '
        'cmbKlemPantek
        '
        Me.cmbKlemPantek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKlemPantek.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKlemPantek.FormattingEnabled = True
        Me.cmbKlemPantek.Location = New System.Drawing.Point(165, 26)
        Me.cmbKlemPantek.Name = "cmbKlemPantek"
        Me.cmbKlemPantek.Size = New System.Drawing.Size(207, 24)
        Me.cmbKlemPantek.TabIndex = 571
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(28, 59)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(37, 15)
        Me.Label2.TabIndex = 508
        Me.Label2.Text = "Stock"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(28, 31)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(125, 15)
        Me.Label21.TabIndex = 505
        Me.Label21.Text = "Klem Sudah dipantek"
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
        'gridKlemPantek
        '
        Me.gridKlemPantek.AllowUserToAddRows = False
        Me.gridKlemPantek.AllowUserToDeleteRows = False
        Me.gridKlemPantek.AllowUserToOrderColumns = True
        Me.gridKlemPantek.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridKlemPantek.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlemPantek, Me.clmUkuranKlemPantek, Me.clmQtyKlemPantek})
        Me.gridKlemPantek.Location = New System.Drawing.Point(12, 397)
        Me.gridKlemPantek.Name = "gridKlemPantek"
        Me.gridKlemPantek.Size = New System.Drawing.Size(376, 244)
        Me.gridKlemPantek.TabIndex = 509
        '
        'clmKdKlemPantek
        '
        Me.clmKdKlemPantek.HeaderText = "No. Klem"
        Me.clmKdKlemPantek.Name = "clmKdKlemPantek"
        Me.clmKdKlemPantek.ReadOnly = True
        Me.clmKdKlemPantek.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmKdKlemPantek.Visible = False
        '
        'clmUkuranKlemPantek
        '
        Me.clmUkuranKlemPantek.HeaderText = "Ukuran Klem"
        Me.clmUkuranKlemPantek.Name = "clmUkuranKlemPantek"
        Me.clmUkuranKlemPantek.ReadOnly = True
        '
        'clmQtyKlemPantek
        '
        Me.clmQtyKlemPantek.HeaderText = "Jumlah Klem ( Karung )"
        Me.clmQtyKlemPantek.Name = "clmQtyKlemPantek"
        Me.clmQtyKlemPantek.Width = 140
        '
        'gridKlemJadi
        '
        Me.gridKlemJadi.AllowUserToAddRows = False
        Me.gridKlemJadi.AllowUserToDeleteRows = False
        Me.gridKlemJadi.AllowUserToOrderColumns = True
        Me.gridKlemJadi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridKlemJadi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlemJadi, Me.clmUkuranKlemJadi, Me.clmMerk, Me.clmQtyKlemJadi})
        Me.gridKlemJadi.Location = New System.Drawing.Point(448, 397)
        Me.gridKlemJadi.Name = "gridKlemJadi"
        Me.gridKlemJadi.Size = New System.Drawing.Size(376, 244)
        Me.gridKlemJadi.TabIndex = 569
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.txtQtyKlemJadi)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.browseKlemJadi)
        Me.GroupBox1.Controls.Add(Me.btnRemoveKlemJadi)
        Me.GroupBox1.Controls.Add(Me.btnAddKlemJadi)
        Me.GroupBox1.Controls.Add(Me.cmbKlemJadi)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Location = New System.Drawing.Point(448, 247)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 144)
        Me.GroupBox1.TabIndex = 570
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Klem Jadi yang akan di hasilkan"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(230, 60)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(40, 15)
        Me.Label6.TabIndex = 618
        Me.Label6.Text = "/ Pack"
        '
        'txtQtyKlemJadi
        '
        Me.txtQtyKlemJadi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemJadi.Location = New System.Drawing.Point(163, 57)
        Me.txtQtyKlemJadi.MaxLength = 20
        Me.txtQtyKlemJadi.Name = "txtQtyKlemJadi"
        Me.txtQtyKlemJadi.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemJadi.TabIndex = 617
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(25, 61)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 15)
        Me.Label9.TabIndex = 579
        Me.Label9.Text = "Jumlah"
        '
        'browseKlemJadi
        '
        Me.browseKlemJadi.Location = New System.Drawing.Point(378, 28)
        Me.browseKlemJadi.Name = "browseKlemJadi"
        Me.browseKlemJadi.Size = New System.Drawing.Size(23, 21)
        Me.browseKlemJadi.TabIndex = 572
        Me.browseKlemJadi.Text = "..."
        Me.browseKlemJadi.UseVisualStyleBackColor = True
        '
        'btnRemoveKlemJadi
        '
        Me.btnRemoveKlemJadi.Location = New System.Drawing.Point(230, 85)
        Me.btnRemoveKlemJadi.Name = "btnRemoveKlemJadi"
        Me.btnRemoveKlemJadi.Size = New System.Drawing.Size(61, 23)
        Me.btnRemoveKlemJadi.TabIndex = 572
        Me.btnRemoveKlemJadi.Text = "Hapus"
        Me.btnRemoveKlemJadi.UseVisualStyleBackColor = True
        '
        'btnAddKlemJadi
        '
        Me.btnAddKlemJadi.Location = New System.Drawing.Point(163, 85)
        Me.btnAddKlemJadi.Name = "btnAddKlemJadi"
        Me.btnAddKlemJadi.Size = New System.Drawing.Size(61, 23)
        Me.btnAddKlemJadi.TabIndex = 571
        Me.btnAddKlemJadi.Text = "Tambah"
        Me.btnAddKlemJadi.UseVisualStyleBackColor = True
        '
        'cmbKlemJadi
        '
        Me.cmbKlemJadi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKlemJadi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKlemJadi.FormattingEnabled = True
        Me.cmbKlemJadi.Location = New System.Drawing.Point(165, 26)
        Me.cmbKlemJadi.Name = "cmbKlemJadi"
        Me.cmbKlemJadi.Size = New System.Drawing.Size(207, 24)
        Me.cmbKlemJadi.TabIndex = 571
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(28, 31)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(62, 15)
        Me.Label13.TabIndex = 505
        Me.Label13.Text = "Klem Jadi"
        '
        'clmKdKlemJadi
        '
        Me.clmKdKlemJadi.HeaderText = "No. Klem"
        Me.clmKdKlemJadi.Name = "clmKdKlemJadi"
        Me.clmKdKlemJadi.ReadOnly = True
        Me.clmKdKlemJadi.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmKdKlemJadi.Visible = False
        '
        'clmUkuranKlemJadi
        '
        Me.clmUkuranKlemJadi.HeaderText = "Ukuran Klem"
        Me.clmUkuranKlemJadi.Name = "clmUkuranKlemJadi"
        Me.clmUkuranKlemJadi.ReadOnly = True
        '
        'clmMerk
        '
        Me.clmMerk.HeaderText = "Merk"
        Me.clmMerk.Name = "clmMerk"
        Me.clmMerk.ReadOnly = True
        '
        'clmQtyKlemJadi
        '
        Me.clmQtyKlemJadi.HeaderText = "Jumlah Klem ( Pack )"
        Me.clmQtyKlemJadi.Name = "clmQtyKlemJadi"
        Me.clmQtyKlemJadi.Width = 140
        '
        'FormProduksiHitungManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(926, 649)
        Me.Controls.Add(Me.gridKlemJadi)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.gridKlemPantek)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "FormProduksiHitungManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produksi Hitung"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridKlemPantek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridKlemJadi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents dtpHitung As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents browseKlemPantek As System.Windows.Forms.Button
    Friend WithEvents cmbKlemPantek As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents browseKaryawan As System.Windows.Forms.Button
    Friend WithEvents cmbKaryawan As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents gridKlemPantek As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelepon As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtKdHitung As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemPantek As System.Windows.Forms.TextBox
    Friend WithEvents lblStokKlemPantek As System.Windows.Forms.Label
    Friend WithEvents clmKdKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents gridKlemJadi As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemJadi As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents browseKlemJadi As System.Windows.Forms.Button
    Friend WithEvents btnRemoveKlemJadi As System.Windows.Forms.Button
    Friend WithEvents btnAddKlemJadi As System.Windows.Forms.Button
    Friend WithEvents cmbKlemJadi As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents clmKdKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
