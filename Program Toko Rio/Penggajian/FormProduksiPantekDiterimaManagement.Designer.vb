<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProduksiPantekDiterimaManagement
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProduksiPantekDiterimaManagement))
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtKaryawan = New System.Windows.Forms.TextBox
        Me.browsePantekKeluar = New System.Windows.Forms.Button
        Me.txtKdPantek = New System.Windows.Forms.Label
        Me.cmbPantekKeluar = New System.Windows.Forms.ComboBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTelepon = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.dtpPantek = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
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
        Me.clmQtyKlem = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuranPaku = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyPaku = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmPerkiraan = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyDiterima = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
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
        Me.GroupBox2.Controls.Add(Me.txtKaryawan)
        Me.GroupBox2.Controls.Add(Me.browsePantekKeluar)
        Me.GroupBox2.Controls.Add(Me.txtKdPantek)
        Me.GroupBox2.Controls.Add(Me.cmbPantekKeluar)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Controls.Add(Me.txtAlamat)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTelepon)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.dtpPantek)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(900, 236)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'txtKaryawan
        '
        Me.txtKaryawan.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtKaryawan.Enabled = False
        Me.txtKaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKaryawan.Location = New System.Drawing.Point(158, 108)
        Me.txtKaryawan.MaxLength = 20
        Me.txtKaryawan.Name = "txtKaryawan"
        Me.txtKaryawan.Size = New System.Drawing.Size(236, 22)
        Me.txtKaryawan.TabIndex = 590
        '
        'browsePantekKeluar
        '
        Me.browsePantekKeluar.Location = New System.Drawing.Point(371, 78)
        Me.browsePantekKeluar.Name = "browsePantekKeluar"
        Me.browsePantekKeluar.Size = New System.Drawing.Size(23, 21)
        Me.browsePantekKeluar.TabIndex = 572
        Me.browsePantekKeluar.Text = "..."
        Me.browsePantekKeluar.UseVisualStyleBackColor = True
        '
        'txtKdPantek
        '
        Me.txtKdPantek.AutoSize = True
        Me.txtKdPantek.Location = New System.Drawing.Point(155, 22)
        Me.txtKdPantek.Name = "txtKdPantek"
        Me.txtKdPantek.Size = New System.Drawing.Size(0, 13)
        Me.txtKdPantek.TabIndex = 589
        '
        'cmbPantekKeluar
        '
        Me.cmbPantekKeluar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPantekKeluar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPantekKeluar.FormattingEnabled = True
        Me.cmbPantekKeluar.Location = New System.Drawing.Point(158, 76)
        Me.cmbPantekKeluar.Name = "cmbPantekKeluar"
        Me.cmbPantekKeluar.Size = New System.Drawing.Size(207, 24)
        Me.cmbPantekKeluar.TabIndex = 571
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(21, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(106, 15)
        Me.Label21.TabIndex = 505
        Me.Label21.Text = "No. Pantek Keluar"
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(18, 19)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(109, 15)
        Me.lblKodekaryawan.TabIndex = 588
        Me.lblKodekaryawan.Text = "No. Pantek Terima"
        '
        'txtAlamat
        '
        Me.txtAlamat.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtAlamat.Enabled = False
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(158, 136)
        Me.txtAlamat.MaxLength = 20
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(236, 22)
        Me.txtAlamat.TabIndex = 587
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(18, 139)
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
        Me.txtTelepon.Location = New System.Drawing.Point(158, 164)
        Me.txtTelepon.MaxLength = 20
        Me.txtTelepon.Name = "txtTelepon"
        Me.txtTelepon.Size = New System.Drawing.Size(236, 22)
        Me.txtTelepon.TabIndex = 585
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(18, 167)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(129, 15)
        Me.Label3.TabIndex = 584
        Me.Label3.Text = "Handphone Karyawan"
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
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(18, 108)
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
        Me.gridBarang.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmKdKlem, Me.clmKdPaku, Me.clmUkuranKlem, Me.clmQtyKlem, Me.clmUkuranPaku, Me.clmQtyPaku, Me.clmPerkiraan, Me.clmQtyDiterima})
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
        'clmQtyKlem
        '
        Me.clmQtyKlem.HeaderText = "Jumlah Klem ( Karung )"
        Me.clmQtyKlem.Name = "clmQtyKlem"
        Me.clmQtyKlem.ReadOnly = True
        Me.clmQtyKlem.Width = 140
        '
        'clmUkuranPaku
        '
        Me.clmUkuranPaku.HeaderText = "Ukuran Paku"
        Me.clmUkuranPaku.Name = "clmUkuranPaku"
        Me.clmUkuranPaku.ReadOnly = True
        '
        'clmQtyPaku
        '
        Me.clmQtyPaku.HeaderText = "Jumlah Paku ( Kardus )"
        Me.clmQtyPaku.Name = "clmQtyPaku"
        Me.clmQtyPaku.ReadOnly = True
        Me.clmQtyPaku.Width = 140
        '
        'clmPerkiraan
        '
        Me.clmPerkiraan.HeaderText = "Perkiraan ( Klem - Paku )"
        Me.clmPerkiraan.Name = "clmPerkiraan"
        Me.clmPerkiraan.ReadOnly = True
        Me.clmPerkiraan.Width = 150
        '
        'clmQtyDiterima
        '
        Me.clmQtyDiterima.HeaderText = "Jumlah Klem Diterima *"
        Me.clmQtyDiterima.Name = "clmQtyDiterima"
        Me.clmQtyDiterima.Width = 140
        '
        'FormProduksiPantekDiterimaManagement
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(926, 649)
        Me.Controls.Add(Me.gridBarang)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Name = "FormProduksiPantekDiterimaManagement"
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
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents dtpPantek As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents browsePantekKeluar As System.Windows.Forms.Button
    Friend WithEvents cmbPantekKeluar As System.Windows.Forms.ComboBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents gridBarang As System.Windows.Forms.DataGridView
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtTelepon As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKdPantek As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents txtKaryawan As System.Windows.Forms.TextBox
    Friend WithEvents clmKdKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmKdPaku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyKlem As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuranPaku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyPaku As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmPerkiraan As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyDiterima As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
