<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormPurchasePaymentManagamen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPurchasePaymentManagamen))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.cmbBayar = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtNote = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txtSupplier = New System.Windows.Forms.TextBox
        Me.BrowsePB = New System.Windows.Forms.Button
        Me.cmbPB = New System.Windows.Forms.ComboBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.dtpPayment = New System.Windows.Forms.DateTimePicker
        Me.Label12 = New System.Windows.Forms.Label
        Me.txtID = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnConfirms = New System.Windows.Forms.ToolStripButton
        Me.SeparatorConfirm = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.gridBahanMentah = New System.Windows.Forms.DataGridView
        Me.Label6 = New System.Windows.Forms.Label
        Me.lblGrandtotal = New System.Windows.Forms.TextBox
        Me.txt_jumlah = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.txt_disc_payment = New System.Windows.Forms.TextBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.clmPartNo = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmNamaBarang = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmUkuran = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmHarga = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQty = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmQtyReal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmDisc = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmSubtotal = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.clmStatus = New System.Windows.Forms.DataGridViewTextBoxColumn
        Me.GroupBox2.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        CType(Me.gridBahanMentah, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.cmbBayar)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.txtNote)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtSupplier)
        Me.GroupBox2.Controls.Add(Me.BrowsePB)
        Me.GroupBox2.Controls.Add(Me.cmbPB)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.dtpPayment)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.txtID)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.lblKodekaryawan)
        Me.GroupBox2.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(998, 165)
        Me.GroupBox2.TabIndex = 476
        Me.GroupBox2.TabStop = False
        '
        'cmbBayar
        '
        Me.cmbBayar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbBayar.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbBayar.FormattingEnabled = True
        Me.cmbBayar.Items.AddRange(New Object() {"-  Cara Bayar -", "Giro", "Transfer", "Cheque", "Cash"})
        Me.cmbBayar.Location = New System.Drawing.Point(165, 129)
        Me.cmbBayar.Name = "cmbBayar"
        Me.cmbBayar.Size = New System.Drawing.Size(207, 24)
        Me.cmbBayar.TabIndex = 585
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(25, 132)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(67, 15)
        Me.Label2.TabIndex = 584
        Me.Label2.Text = "Cara Bayar"
        '
        'txtNote
        '
        Me.txtNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNote.Location = New System.Drawing.Point(574, 26)
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
        Me.Label9.Location = New System.Drawing.Point(483, 26)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(37, 16)
        Me.Label9.TabIndex = 583
        Me.Label9.Text = "Note"
        '
        'txtSupplier
        '
        Me.txtSupplier.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txtSupplier.Enabled = False
        Me.txtSupplier.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplier.Location = New System.Drawing.Point(165, 102)
        Me.txtSupplier.MaxLength = 20
        Me.txtSupplier.Name = "txtSupplier"
        Me.txtSupplier.Size = New System.Drawing.Size(236, 22)
        Me.txtSupplier.TabIndex = 578
        '
        'BrowsePB
        '
        Me.BrowsePB.Location = New System.Drawing.Point(378, 74)
        Me.BrowsePB.Name = "BrowsePB"
        Me.BrowsePB.Size = New System.Drawing.Size(23, 21)
        Me.BrowsePB.TabIndex = 577
        Me.BrowsePB.Text = "..."
        Me.BrowsePB.UseVisualStyleBackColor = True
        '
        'cmbPB
        '
        Me.cmbPB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbPB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPB.FormattingEnabled = True
        Me.cmbPB.Location = New System.Drawing.Point(165, 72)
        Me.cmbPB.Name = "cmbPB"
        Me.cmbPB.Size = New System.Drawing.Size(207, 24)
        Me.cmbPB.TabIndex = 576
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(25, 79)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(97, 15)
        Me.Label13.TabIndex = 575
        Me.Label13.Text = "No. Penerimaan"
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
        'txtID
        '
        Me.txtID.AutoSize = True
        Me.txtID.Location = New System.Drawing.Point(162, 26)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(0, 13)
        Me.txtID.TabIndex = 501
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(25, 105)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(90, 15)
        Me.Label18.TabIndex = 481
        Me.Label18.Text = "Nama Supplier"
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
        'gridBahanMentah
        '
        Me.gridBahanMentah.AllowUserToAddRows = False
        Me.gridBahanMentah.AllowUserToDeleteRows = False
        Me.gridBahanMentah.AllowUserToOrderColumns = True
        Me.gridBahanMentah.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.gridBahanMentah.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.clmPartNo, Me.clmNamaBarang, Me.clmUkuran, Me.clmHarga, Me.clmQty, Me.clmQtyReal, Me.clmDisc, Me.clmSubtotal, Me.clmStatus})
        Me.gridBahanMentah.Location = New System.Drawing.Point(12, 228)
        Me.gridBahanMentah.Name = "gridBahanMentah"
        Me.gridBahanMentah.ReadOnly = True
        Me.gridBahanMentah.Size = New System.Drawing.Size(998, 216)
        Me.gridBahanMentah.TabIndex = 504
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(494, 449)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(128, 24)
        Me.Label6.TabIndex = 502
        Me.Label6.Text = "Jumlah ( IDR )"
        '
        'lblGrandtotal
        '
        Me.lblGrandtotal.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.lblGrandtotal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.lblGrandtotal.Enabled = False
        Me.lblGrandtotal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGrandtotal.Location = New System.Drawing.Point(628, 449)
        Me.lblGrandtotal.Multiline = True
        Me.lblGrandtotal.Name = "lblGrandtotal"
        Me.lblGrandtotal.Size = New System.Drawing.Size(142, 24)
        Me.lblGrandtotal.TabIndex = 503
        Me.lblGrandtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'txt_jumlah
        '
        Me.txt_jumlah.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.txt_jumlah.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.txt_jumlah.Enabled = False
        Me.txt_jumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_jumlah.Location = New System.Drawing.Point(631, 522)
        Me.txt_jumlah.Multiline = True
        Me.txt_jumlah.Name = "txt_jumlah"
        Me.txt_jumlah.Size = New System.Drawing.Size(139, 24)
        Me.txt_jumlah.TabIndex = 599
        Me.txt_jumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(494, 522)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(128, 24)
        Me.Label25.TabIndex = 598
        Me.Label25.Text = "Jumlah ( IDR )"
        '
        'txt_disc_payment
        '
        Me.txt_disc_payment.Enabled = False
        Me.txt_disc_payment.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txt_disc_payment.Location = New System.Drawing.Point(729, 479)
        Me.txt_disc_payment.MaxLength = 20
        Me.txt_disc_payment.Name = "txt_disc_payment"
        Me.txt_disc_payment.Size = New System.Drawing.Size(41, 22)
        Me.txt_disc_payment.TabIndex = 600
        Me.txt_disc_payment.Text = "0"
        Me.txt_disc_payment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(472, 504)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(334, 13)
        Me.Label24.TabIndex = 597
        Me.Label24.Text = "---------------------------------------------------------------------------------" & _
            "-------------------------  -"
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(494, 479)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 24)
        Me.Label23.TabIndex = 596
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
        Me.clmHarga.HeaderText = "Harga"
        Me.clmHarga.Name = "clmHarga"
        Me.clmHarga.ReadOnly = True
        '
        'clmQty
        '
        Me.clmQty.HeaderText = "Qty ( kg )"
        Me.clmQty.Name = "clmQty"
        Me.clmQty.ReadOnly = True
        '
        'clmQtyReal
        '
        Me.clmQtyReal.HeaderText = "Qty Real"
        Me.clmQtyReal.Name = "clmQtyReal"
        Me.clmQtyReal.ReadOnly = True
        Me.clmQtyReal.Width = 115
        '
        'clmDisc
        '
        Me.clmDisc.HeaderText = "Disc ( % )"
        Me.clmDisc.Name = "clmDisc"
        Me.clmDisc.ReadOnly = True
        Me.clmDisc.Visible = False
        Me.clmDisc.Width = 80
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
        'FormPurchasePaymentManagamen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1022, 557)
        Me.Controls.Add(Me.txt_jumlah)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.txt_disc_payment)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.gridBahanMentah)
        Me.Controls.Add(Me.lblGrandtotal)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormPurchasePaymentManagamen"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pembayaran Pembelian Bahan Mentah"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        CType(Me.gridBahanMentah, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents dtpPayment As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents gridBahanMentah As System.Windows.Forms.DataGridView
    Friend WithEvents BrowsePB As System.Windows.Forms.Button
    Friend WithEvents cmbPB As System.Windows.Forms.ComboBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtSupplier As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents lblGrandtotal As System.Windows.Forms.TextBox
    Friend WithEvents btnConfirms As System.Windows.Forms.ToolStripButton
    Friend WithEvents SeparatorConfirm As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmbBayar As System.Windows.Forms.ComboBox
    Friend WithEvents txt_jumlah As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents txt_disc_payment As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents clmPartNo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmNamaBarang As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmUkuran As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmHarga As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQty As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmQtyReal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmDisc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmSubtotal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents clmStatus As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
