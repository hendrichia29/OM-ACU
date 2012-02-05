<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPenggajianManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPenggajianManagement))
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.dtp_sampai_tgl = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.dtp_dari_tgl = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtKdPenggajian = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.dtpPantek = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridBarang = New System.Windows.Forms.DataGridView
        Me.clmKdKaryawan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKdReferensi = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmKdBarang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmTanggal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNamaKaryawan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuran = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmMerk = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHarga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmJumlah = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblGrandtotal
        '
        Me.lblGrandtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGrandtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblGrandtotal.Enabled = False
        Me.lblGrandtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(625, 417)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(135, 23)
        Me.lblGrandtotal.TabIndex = 508
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(454, 417)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(165, 24)
        Me.Label6.TabIndex = 507
        Me.Label6.Text = "Grand Total ( IDR )"
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 54)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.dtp_sampai_tgl)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.dtp_dari_tgl)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtKdPenggajian)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Controls.Add(Me.dtpPantek)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(984, 394)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'dtp_sampai_tgl
        '
        Me.dtp_sampai_tgl.Location = New System.Drawing.Point(506, 80)
        Me.dtp_sampai_tgl.Name = "dtp_sampai_tgl"
        Me.dtp_sampai_tgl.Size = New System.Drawing.Size(236, 20)
        Me.dtp_sampai_tgl.TabIndex = 593
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(402, 79)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(98, 15)
        Me.Label2.TabIndex = 592
        Me.Label2.Text = "Sampai Tanggal"
        '
        'dtp_dari_tgl
        '
        Me.dtp_dari_tgl.Location = New System.Drawing.Point(158, 77)
        Me.dtp_dari_tgl.Name = "dtp_dari_tgl"
        Me.dtp_dari_tgl.Size = New System.Drawing.Size(236, 20)
        Me.dtp_dari_tgl.TabIndex = 591
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(18, 80)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(78, 15)
        Me.Label4.TabIndex = 590
        Me.Label4.Text = "Dari Tanggal"
        '
        'txtKdPenggajian
        '
        Me.txtKdPenggajian.AutoSize = True
        Me.txtKdPenggajian.Location = New System.Drawing.Point(155, 22)
        Me.txtKdPenggajian.Name = "txtKdPenggajian"
        Me.txtKdPenggajian.Size = New System.Drawing.Size(0, 13)
        Me.txtKdPenggajian.TabIndex = 589
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
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator4, Me.btnConfirms, Me.ToolStripSeparator1, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(1006, 54)
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
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKaryawan, Me.clmKdReferensi, Me.clmKdBarang, Me.clmTanggal, Me.clmNamaKaryawan, Me.clmUkuran, Me.clmMerk, Me.clmQty, Me.clmHarga, Me.clmJumlah})
        Me.gridBarang.Location = New System.Drawing.Point(18, 167)
        Me.gridBarang.Name = "gridBarang"
        Me.gridBarang.Size = New System.Drawing.Size(963, 244)
        Me.gridBarang.TabIndex = 509
        '
        'clmKdKaryawan
        '
        Me.clmKdKaryawan.HeaderText = "KdKaryawan"
        Me.clmKdKaryawan.Name = "clmKdKaryawan"
        Me.clmKdKaryawan.ReadOnly = True
        Me.clmKdKaryawan.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        '
        'clmKdReferensi
        '
        Me.clmKdReferensi.HeaderText = "KdReferensi"
        Me.clmKdReferensi.Name = "clmKdReferensi"
        Me.clmKdReferensi.ReadOnly = True
        '
        'clmKdBarang
        '
        Me.clmKdBarang.HeaderText = "KdBarang"
        Me.clmKdBarang.Name = "clmKdBarang"
        Me.clmKdBarang.ReadOnly = True
        '
        'clmTanggal
        '
        Me.clmTanggal.HeaderText = "Tanggal"
        Me.clmTanggal.Name = "clmTanggal"
        Me.clmTanggal.ReadOnly = True
        '
        'clmNamaKaryawan
        '
        Me.clmNamaKaryawan.HeaderText = "DR"
        Me.clmNamaKaryawan.Name = "clmNamaKaryawan"
        Me.clmNamaKaryawan.ReadOnly = True
        '
        'clmUkuran
        '
        Me.clmUkuran.HeaderText = "No"
        Me.clmUkuran.Name = "clmUkuran"
        Me.clmUkuran.ReadOnly = True
        '
        'clmMerk
        '
        Me.clmMerk.HeaderText = "Merk"
        Me.clmMerk.Name = "clmMerk"
        Me.clmMerk.ReadOnly = True
        '
        'clmQty
        '
        Me.clmQty.HeaderText = "Qty ( Pack )"
        Me.clmQty.Name = "clmQty"
        Me.clmQty.ReadOnly = True
        '
        'clmHarga
        '
        Me.clmHarga.HeaderText = "Harga *"
        Me.clmHarga.Name = "clmHarga"
        '
        'clmJumlah
        '
        Me.clmJumlah.HeaderText = "Jumlah"
        Me.clmJumlah.Name = "clmJumlah"
        Me.clmJumlah.ReadOnly = True
        '
        'FormPenggajianManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1006, 469)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Name = "FormPenggajianManagement"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Produksi Pantek"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBarang, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPantek As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtKdPenggajian As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents dtp_sampai_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents dtp_dari_tgl As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents clmKdKaryawan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdReferensi As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmTanggal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNamaKaryawan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuran As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmMerk As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmJumlah As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
