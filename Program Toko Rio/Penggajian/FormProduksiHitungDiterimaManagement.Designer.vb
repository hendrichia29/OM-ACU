<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProduksiHitungDiterimaManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProduksiHitungDiterimaManagement))
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbKaryawan = New System.Windows.Forms.TextBox
        Me.browseKdHitung = New System.Windows.Forms.Button
        Me.cmbKdHitung = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtKdHitungDiterima = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTelepon = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpHitungDiterima = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridKlemPantek = New System.Windows.Forms.DataGridView
        Me.clmKdKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemPantek = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.gridKlemHitung = New System.Windows.Forms.DataGridView
        Me.clmKdKlemHitung = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlemHitung = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemHitung = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.txtHarga = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtQtyKlemJadi = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.browseKlemJadi = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.btnAdd = New System.Windows.Forms.Button
        Me.cmbKlemJadi = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.gridKlemJadi = New System.Windows.Forms.DataGridView
        Me.clmKdKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerkJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHargaModalKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyKlemJadi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyPrioritas = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKdMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmIsiMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridKlemPantek, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gridKlemHitung, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.gridKlemJadi, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbKaryawan)
        Me.GroupBox2.Controls.Add(Me.browseKdHitung)
        Me.GroupBox2.Controls.Add(Me.cmbKdHitung)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtKdHitungDiterima)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTelepon)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpHitungDiterima)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 113)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'cmbKaryawan
        '
        Me.cmbKaryawan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.cmbKaryawan.Enabled = False
        Me.cmbKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKaryawan.Location = New System.Drawing.Point(598, 24)
        Me.cmbKaryawan.MaxLength = 20
        Me.cmbKaryawan.Name = "cmbKaryawan"
        Me.cmbKaryawan.Size = New System.Drawing.Size(236, 22)
        Me.cmbKaryawan.TabIndex = 593
        '
        'browseKdHitung
        '
        Me.browseKdHitung.Location = New System.Drawing.Point(371, 78)
        Me.browseKdHitung.Name = "browseKdHitung"
        Me.browseKdHitung.Size = New System.Drawing.Size(23, 21)
        Me.browseKdHitung.TabIndex = 592
        Me.browseKdHitung.Text = "..."
        Me.browseKdHitung.UseVisualStyleBackColor = True
        '
        'cmbKdHitung
        '
        Me.cmbKdHitung.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKdHitung.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKdHitung.FormattingEnabled = True
        Me.cmbKdHitung.Location = New System.Drawing.Point(158, 76)
        Me.cmbKdHitung.Name = "cmbKdHitung"
        Me.cmbKdHitung.Size = New System.Drawing.Size(207, 24)
        Me.cmbKdHitung.TabIndex = 591
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(18, 78)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(65, 15)
        Me.Label2.TabIndex = 590
        Me.Label2.Text = "No. Keluar"
        '
        'txtKdHitungDiterima
        '
        Me.txtKdHitungDiterima.AutoSize = True
        Me.txtKdHitungDiterima.Location = New System.Drawing.Point(155, 22)
        Me.txtKdHitungDiterima.Name = "txtKdHitungDiterima"
        Me.txtKdHitungDiterima.Size = New System.Drawing.Size(0, 13)
        Me.txtKdHitungDiterima.TabIndex = 589
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(18, 19)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(68, 15)
        Me.lblKodekaryawan.TabIndex = 588
        Me.lblKodekaryawan.Text = "No. Terima"
        '
        'txtAlamat
        '
        Me.txtAlamat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(598, 52)
        Me.txtAlamat.MaxLength = 20
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(236, 22)
        Me.txtAlamat.TabIndex = 587
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(458, 55)
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
        Me.txtTelepon.Location = New System.Drawing.Point(598, 80)
        Me.txtTelepon.MaxLength = 20
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New System.Drawing.Size(236, 22)
        Me.txtTelepon.TabIndex = 585
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(458, 83)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 15)
        Me.Label3.TabIndex = 584
        Me.Label3.Text = "Handphone Karyawan"
        '
        'dtpHitungDiterima
        '
        Me.dtpHitungDiterima.Location = New System.Drawing.Point(158, 50)
        Me.dtpHitungDiterima.Name = "dtpHitungDiterima"
        Me.dtpHitungDiterima.Size = New System.Drawing.Size(236, 20)
        Me.dtpHitungDiterima.TabIndex = 570
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(458, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(100, 15)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Karyawan Hitung"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator4, Me.btnConfirms, Me.ToolStripSeparator1, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(1003, 54)
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
        Me.gridKlemPantek.Location = New System.Drawing.Point(6, 19)
        Me.gridKlemPantek.Name = "gridKlemPantek"
        Me.gridKlemPantek.ReadOnly = True
        Me.gridKlemPantek.Size = New System.Drawing.Size(403, 188)
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
        Me.clmQtyKlemPantek.ReadOnly = True
        Me.clmQtyKlemPantek.Width = 140
        '
        'gridKlemHitung
        '
        Me.gridKlemHitung.AllowUserToAddRows = False
        Me.gridKlemHitung.AllowUserToDeleteRows = False
        Me.gridKlemHitung.AllowUserToOrderColumns = True
        Me.gridKlemHitung.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridKlemHitung.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlemHitung, Me.clmUkuranKlemHitung, Me.clmMerk, Me.clmQtyKlemHitung})
        Me.gridKlemHitung.Location = New System.Drawing.Point(6, 19)
        Me.gridKlemHitung.Name = "gridKlemHitung"
        Me.gridKlemHitung.ReadOnly = True
        Me.gridKlemHitung.Size = New System.Drawing.Size(403, 188)
        Me.gridKlemHitung.TabIndex = 569
        '
        'clmKdKlemHitung
        '
        Me.clmKdKlemHitung.HeaderText = "No. Klem"
        Me.clmKdKlemHitung.Name = "clmKdKlemHitung"
        Me.clmKdKlemHitung.ReadOnly = True
        Me.clmKdKlemHitung.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.clmKdKlemHitung.Visible = False
        '
        'clmUkuranKlemHitung
        '
        Me.clmUkuranKlemHitung.HeaderText = "Ukuran Klem"
        Me.clmUkuranKlemHitung.Name = "clmUkuranKlemHitung"
        Me.clmUkuranKlemHitung.ReadOnly = True
        '
        'clmMerk
        '
        Me.clmMerk.HeaderText = "Merk"
        Me.clmMerk.Name = "clmMerk"
        Me.clmMerk.ReadOnly = True
        '
        'clmQtyKlemHitung
        '
        Me.clmQtyKlemHitung.HeaderText = "Jumlah Klem ( Pack )"
        Me.clmQtyKlemHitung.Name = "clmQtyKlemHitung"
        Me.clmQtyKlemHitung.ReadOnly = True
        Me.clmQtyKlemHitung.Width = 140
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.gridKlemHitung)
        Me.GroupBox1.Location = New System.Drawing.Point(448, 183)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(415, 221)
        Me.GroupBox1.TabIndex = 570
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Klem Jadi yang akan di hasilkan"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.gridKlemPantek)
        Me.GroupBox3.Location = New System.Drawing.Point(12, 183)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(415, 221)
        Me.GroupBox3.TabIndex = 568
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Klem sudah dipantek yang akan dihitung"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.txtHarga)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.Label10)
        Me.GroupBox4.Controls.Add(Me.txtQtyKlemJadi)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.browseKlemJadi)
        Me.GroupBox4.Controls.Add(Me.btnRemove)
        Me.GroupBox4.Controls.Add(Me.btnAdd)
        Me.GroupBox4.Controls.Add(Me.cmbKlemJadi)
        Me.GroupBox4.Controls.Add(Me.Label21)
        Me.GroupBox4.Controls.Add(Me.gridKlemJadi)
        Me.GroupBox4.Location = New System.Drawing.Point(12, 413)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(979, 221)
        Me.GroupBox4.TabIndex = 571
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Klem Jadi Sudah dihitung"
        '
        'txtHarga
        '
        Me.txtHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarga.Location = New System.Drawing.Point(98, 85)
        Me.txtHarga.MaxLength = 20
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(207, 22)
        Me.txtHarga.TabIndex = 631
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 86)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(79, 15)
        Me.Label4.TabIndex = 630
        Me.Label4.Text = "Harga Modal"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(165, 60)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 15)
        Me.Label10.TabIndex = 629
        Me.Label10.Text = "/ Karung"
        '
        'txtQtyKlemJadi
        '
        Me.txtQtyKlemJadi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemJadi.Location = New System.Drawing.Point(98, 57)
        Me.txtQtyKlemJadi.MaxLength = 20
        Me.txtQtyKlemJadi.Name = "txtQtyKlemJadi"
        Me.txtQtyKlemJadi.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemJadi.TabIndex = 628
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(5, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 15)
        Me.Label5.TabIndex = 626
        Me.Label5.Text = "Jumlah"
        '
        'browseKlemJadi
        '
        Me.browseKlemJadi.Location = New System.Drawing.Point(311, 29)
        Me.browseKlemJadi.Name = "browseKlemJadi"
        Me.browseKlemJadi.Size = New System.Drawing.Size(23, 21)
        Me.browseKlemJadi.TabIndex = 625
        Me.browseKlemJadi.Text = "..."
        Me.browseKlemJadi.UseVisualStyleBackColor = True
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(168, 113)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(61, 23)
        Me.btnRemove.TabIndex = 624
        Me.btnRemove.Text = "Hapus"
        Me.btnRemove.UseVisualStyleBackColor = True
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(101, 113)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(61, 23)
        Me.btnAdd.TabIndex = 622
        Me.btnAdd.Text = "Tambah"
        Me.btnAdd.UseVisualStyleBackColor = True
        '
        'cmbKlemJadi
        '
        Me.cmbKlemJadi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbKlemJadi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKlemJadi.FormattingEnabled = True
        Me.cmbKlemJadi.Location = New System.Drawing.Point(98, 27)
        Me.cmbKlemJadi.Name = "cmbKlemJadi"
        Me.cmbKlemJadi.Size = New System.Drawing.Size(207, 24)
        Me.cmbKlemJadi.TabIndex = 623
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(6, 29)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(62, 15)
        Me.Label21.TabIndex = 620
        Me.Label21.Text = "Klem Jadi"
        '
        'gridKlemJadi
        '
        Me.gridKlemJadi.AllowUserToAddRows = False
        Me.gridKlemJadi.AllowUserToDeleteRows = False
        Me.gridKlemJadi.AllowUserToOrderColumns = True
        Me.gridKlemJadi.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridKlemJadi.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlemJadi, Me.clmUkuranKlemJadi, Me.clmMerkJadi, Me.clmHargaModalKlemJadi, Me.clmQtyKlemJadi, Me.clmQtyPrioritas, Me.clmKdMerk, Me.clmIsiMerk})
        Me.gridKlemJadi.Location = New System.Drawing.Point(340, 19)
        Me.gridKlemJadi.Name = "gridKlemJadi"
        Me.gridKlemJadi.Size = New System.Drawing.Size(633, 188)
        Me.gridKlemJadi.TabIndex = 509
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
        'clmMerkJadi
        '
        Me.clmMerkJadi.HeaderText = "Merk"
        Me.clmMerkJadi.Name = "clmMerkJadi"
        Me.clmMerkJadi.ReadOnly = True
        '
        'clmHargaModalKlemJadi
        '
        Me.clmHargaModalKlemJadi.HeaderText = "Harga Modal *"
        Me.clmHargaModalKlemJadi.Name = "clmHargaModalKlemJadi"
        '
        'clmQtyKlemJadi
        '
        Me.clmQtyKlemJadi.HeaderText = "Jumlah Klem ( Karung ) *"
        Me.clmQtyKlemJadi.Name = "clmQtyKlemJadi"
        Me.clmQtyKlemJadi.Width = 150
        '
        'clmQtyPrioritas
        '
        Me.clmQtyPrioritas.HeaderText = "Conversi "
        Me.clmQtyPrioritas.Name = "clmQtyPrioritas"
        Me.clmQtyPrioritas.ReadOnly = True
        Me.clmQtyPrioritas.Width = 140
        '
        'clmKdMerk
        '
        Me.clmKdMerk.HeaderText = "KodeMerk"
        Me.clmKdMerk.Name = "clmKdMerk"
        Me.clmKdMerk.ReadOnly = True
        Me.clmKdMerk.Visible = False
        '
        'clmIsiMerk
        '
        Me.clmIsiMerk.HeaderText = "IsiMerk"
        Me.clmIsiMerk.Name = "clmIsiMerk"
        Me.clmIsiMerk.ReadOnly = True
        Me.clmIsiMerk.Visible = False
        '
        'FormProduksiHitungDiterimaManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1003, 646)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "FormProduksiHitungDiterimaManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produksi Hitung Diterima"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridKlemPantek, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gridKlemHitung, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.gridKlemJadi, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpHitungDiterima As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents gridKlemPantek As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelepon As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKdHitungDiterima As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents gridKlemHitung As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents gridKlemJadi As System.Windows.Forms.DataGridView
    Friend WithEvents browseKdHitung As System.Windows.Forms.Button
    Friend WithEvents cmbKdHitung As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemJadi As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents browseKlemJadi As System.Windows.Forms.Button
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents cmbKlemJadi As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents cmbKaryawan As System.Windows.Forms.TextBox
    Friend WithEvents txtHarga As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clmKdKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemPantek As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdKlemHitung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlemHitung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemHitung As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerkJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHargaModalKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlemJadi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyPrioritas As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmIsiMerk As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
