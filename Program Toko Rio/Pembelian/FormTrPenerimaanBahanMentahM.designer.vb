<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormTrPenerimaanBahanMentahM
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormTrPenerimaanBahanMentahM))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.txtKdSupplier = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.txtTglPO = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.BrowsePO = New System.Windows.Forms.Button
        Me.cmbPO = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpPB = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.SeparatorAdd = New System.Windows.Forms.ToolStripSeparator
        Me.SeparatorConfirm = New System.Windows.Forms.ToolStripSeparator
        Me.gridBahanMentah = New System.Windows.Forms.DataGridView
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.txt_jumlah = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_disc_faktur = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.clmPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuran = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHarga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty2 = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyReal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        CType(Me.gridBahanMentah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.main_tool_strip.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtKdSupplier)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.txtTglPO)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.txtSupplier)
        Me.GroupBox2.Controls.Add(Me.BrowsePO)
        Me.GroupBox2.Controls.Add(Me.cmbPO)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpPB)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(859, 195)
        Me.GroupBox2.TabIndex = 505
        Me.GroupBox2.TabStop = False
        '
        'txtKdSupplier
        '
        Me.txtKdSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtKdSupplier.Enabled = False
        Me.txtKdSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtKdSupplier.Location = New System.Drawing.Point(165, 130)
        Me.txtKdSupplier.MaxLength = 20
        Me.txtKdSupplier.Name = "txtKdSupplier"
        Me.txtKdSupplier.Size = New System.Drawing.Size(236, 22)
        Me.txtKdSupplier.TabIndex = 583
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.Location = New System.Drawing.Point(25, 133)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(85, 15)
        Me.Label14.TabIndex = 582
        Me.Label14.Text = "Kode Supplier"
        '
        'txtTglPO
        '
        Me.txtTglPO.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtTglPO.Enabled = False
        Me.txtTglPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTglPO.Location = New System.Drawing.Point(165, 102)
        Me.txtTglPO.MaxLength = 20
        Me.txtTglPO.Name = "txtTglPO"
        Me.txtTglPO.Size = New System.Drawing.Size(236, 22)
        Me.txtTglPO.TabIndex = 581
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(25, 105)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 15)
        Me.Label3.TabIndex = 580
        Me.Label3.Text = "Tanggal PO"
        '
        'txtSupplier
        '
        Me.txtSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplier.Enabled = False
        Me.txtSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(165, 158)
        Me.txtSupplier.MaxLength = 20
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(236, 22)
        Me.txtSupplier.TabIndex = 579
        '
        'BrowsePO
        '
        Me.BrowsePO.Location = New System.Drawing.Point(378, 74)
        Me.BrowsePO.Name = "BrowsePO"
        Me.BrowsePO.Size = New System.Drawing.Size(23, 21)
        Me.BrowsePO.TabIndex = 577
        Me.BrowsePO.Text = "..."
        Me.BrowsePO.UseVisualStyleBackColor = True
        '
        'cmbPO
        '
        Me.cmbPO.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPO.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPO.FormattingEnabled = True
        Me.cmbPO.Location = New System.Drawing.Point(165, 72)
        Me.cmbPO.Name = "cmbPO"
        Me.cmbPO.Size = New System.Drawing.Size(207, 24)
        Me.cmbPO.TabIndex = 576
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(25, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(46, 15)
        Me.Label13.TabIndex = 575
        Me.Label13.Text = "No. PO"
        '
        'dtpPB
        '
        Me.dtpPB.Location = New System.Drawing.Point(165, 46)
        Me.dtpPB.Name = "dtpPB"
        Me.dtpPB.Size = New System.Drawing.Size(236, 20)
        Me.dtpPB.TabIndex = 570
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(25, 49)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(94, 15)
        Me.Label12.TabIndex = 569
        Me.Label12.Text = "Tanggal Terima"
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
        Me.Label1.Location = New System.Drawing.Point(25, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 15)
        Me.Label1.TabIndex = 482
        Me.Label1.Text = "Nama Supplier"
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(25, 23)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(97, 15)
        Me.lblKodekaryawan.TabIndex = 480
        Me.lblKodekaryawan.Text = "No. Penerimaan"
        '
        'SeparatorAdd
        '
        Me.SeparatorAdd.Name = "SeparatorAdd"
        Me.SeparatorAdd.Size = New System.Drawing.Size(6, 54)
        '
        'SeparatorConfirm
        '
        Me.SeparatorConfirm.Name = "SeparatorConfirm"
        Me.SeparatorConfirm.Size = New System.Drawing.Size(6, 54)
        '
        'gridBahanMentah
        '
        Me.gridBahanMentah.AllowUserToAddRows = False
        Me.gridBahanMentah.AllowUserToDeleteRows = False
        Me.gridBahanMentah.AllowUserToOrderColumns = True
        Me.gridBahanMentah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBahanMentah.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmPartNo, Me.clmNamaBarang, Me.clmUkuran, Me.clmHarga, Me.clmQty, Me.clmQty2, Me.clmDisc, Me.clmSubtotal, Me.clmQtyReal})
        Me.gridBahanMentah.Location = New System.Drawing.Point(12, 265)
        Me.gridBahanMentah.Name = "gridBahanMentah"
        Me.gridBahanMentah.Size = New System.Drawing.Size(947, 263)
        Me.gridBahanMentah.TabIndex = 509
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.SeparatorAdd, Me.btnConfirms, Me.SeparatorConfirm, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(986, 54)
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
        'lblGrandtotal
        '
        Me.lblGrandtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGrandtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblGrandtotal.Enabled = False
        Me.lblGrandtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(655, 534)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(105, 22)
        Me.lblGrandtotal.TabIndex = 585
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(484, 534)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 584
        Me.Label6.Text = "Jumlah ( IDR )"
        '
        'txt_jumlah
        '
        Me.txt_jumlah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_jumlah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_jumlah.Enabled = False
        Me.txt_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah.Location = New System.Drawing.Point(621, 605)
        Me.txt_jumlah.Multiline = True
        Me.txt_jumlah.Name = "txt_jumlah"
        Me.txt_jumlah.Size = New System.Drawing.Size(139, 24)
        Me.txt_jumlah.TabIndex = 589
        Me.txt_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(484, 605)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 24)
        Me.Label25.TabIndex = 588
        Me.Label25.Text = "Jumlah ( IDR )"
        '
        'txt_disc_faktur
        '
        Me.txt_disc_faktur.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_disc_faktur.Location = New System.Drawing.Point(719, 562)
        Me.txt_disc_faktur.MaxLength = 20
        Me.txt_disc_faktur.Name = "txt_disc_faktur"
        Me.txt_disc_faktur.Size = New System.Drawing.Size(41, 22)
        Me.txt_disc_faktur.TabIndex = 590
        Me.txt_disc_faktur.Text = "0"
        Me.txt_disc_faktur.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(462, 587)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(334, 13)
        Me.Label24.TabIndex = 587
        Me.Label24.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(484, 562)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 24)
        Me.Label23.TabIndex = 586
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
        'clmUkuran
        '
        Me.clmUkuran.HeaderText = "Ukuran"
        Me.clmUkuran.Name = "clmUkuran"
        Me.clmUkuran.ReadOnly = True
        '
        'clmHarga
        '
        Me.clmHarga.HeaderText = "Harga *"
        Me.clmHarga.Name = "clmHarga"
        '
        'clmQty
        '
        Me.clmQty.HeaderText = "Jumlah ( Kg ) *"
        Me.clmQty.Name = "clmQty"
        '
        'clmQty2
        '
        Me.clmQty2.HeaderText = "Jumlah"
        Me.clmQty2.Name = "clmQty2"
        Me.clmQty2.ReadOnly = True
        Me.clmQty2.Width = 120
        '
        'clmDisc
        '
        Me.clmDisc.HeaderText = "Disc ( % ) *"
        Me.clmDisc.Name = "clmDisc"
        Me.clmDisc.Visible = False
        '
        'clmSubtotal
        '
        Me.clmSubtotal.HeaderText = "Subtotal ( Kg )"
        Me.clmSubtotal.Name = "clmSubtotal"
        Me.clmSubtotal.ReadOnly = True
        '
        'clmQtyReal
        '
        Me.clmQtyReal.HeaderText = "realPemesanan"
        Me.clmQtyReal.Name = "clmQtyReal"
        Me.clmQtyReal.Visible = False
        '
        'FormTrPenerimaanBahanMentahM
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(986, 651)
        Me.Controls.Add(Me.txt_jumlah)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_disc_faktur)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.gridBahanMentah)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Name = "FormTrPenerimaanBahanMentahM"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Penerimaan Bahan Mentah"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.gridBahanMentah, System.ComponentModel.ISupportInitialize).EndInit()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents BrowsePO As System.Windows.Forms.Button
    Friend WithEvents cmbPO As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents dtpPB As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtID As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorAdd As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorConfirm As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents gridBahanMentah As System.Windows.Forms.DataGridView
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents txtTglPO As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtKdSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txt_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_disc_faktur As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents clmPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuran As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSubtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyReal As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
