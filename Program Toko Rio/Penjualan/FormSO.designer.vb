<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSO
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSO))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnCari = New System.Windows.Forms.Button
        Me.lblSeperator = New System.Windows.Forms.Label
        Me.dtpTo = New System.Windows.Forms.DateTimePicker
        Me.dtpFrom = New System.Windows.Forms.DateTimePicker
        Me.btnReset = New System.Windows.Forms.Button
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.cmbCari = New System.Windows.Forms.ComboBox
        Me.Label17 = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnAdd = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator1 = New System.Windows.Forms.ToolStripSeparator
        Me.btnUpdate = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator
        Me.btnBuka = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnDelete = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator4 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.sales_order_tab = New System.Windows.Forms.TabControl
        Me.sales_order_main = New System.Windows.Forms.TabPage
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.main_tool_strip.SuspendLayout()
        Me.sales_order_tab.SuspendLayout()
        Me.sales_order_main.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        Me.DataGridView1.Location = New System.Drawing.Point(3, 6)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersWidth = 40
        Me.DataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DataGridView1.Size = New System.Drawing.Size(856, 478)
        Me.DataGridView1.TabIndex = 17
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnCari)
        Me.GroupBox1.Controls.Add(Me.lblSeperator)
        Me.GroupBox1.Controls.Add(Me.dtpTo)
        Me.GroupBox1.Controls.Add(Me.dtpFrom)
        Me.GroupBox1.Controls.Add(Me.btnReset)
        Me.GroupBox1.Controls.Add(Me.txtCari)
        Me.GroupBox1.Controls.Add(Me.cmbCari)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 57)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(859, 55)
        Me.GroupBox1.TabIndex = 471
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pencarian"
        '
        'btnCari
        '
        Me.btnCari.Location = New System.Drawing.Point(714, 22)
        Me.btnCari.Name = "btnCari"
        Me.btnCari.Size = New System.Drawing.Size(75, 23)
        Me.btnCari.TabIndex = 356
        Me.btnCari.Text = "Cari"
        Me.btnCari.UseVisualStyleBackColor = True
        '
        'lblSeperator
        '
        Me.lblSeperator.AutoSize = True
        Me.lblSeperator.Location = New System.Drawing.Point(486, 24)
        Me.lblSeperator.Name = "lblSeperator"
        Me.lblSeperator.Size = New System.Drawing.Size(16, 13)
        Me.lblSeperator.TabIndex = 355
        Me.lblSeperator.Text = " - "
        '
        'dtpTo
        '
        Me.dtpTo.Location = New System.Drawing.Point(508, 22)
        Me.dtpTo.Name = "dtpTo"
        Me.dtpTo.Size = New System.Drawing.Size(200, 20)
        Me.dtpTo.TabIndex = 354
        '
        'dtpFrom
        '
        Me.dtpFrom.Location = New System.Drawing.Point(279, 22)
        Me.dtpFrom.Name = "dtpFrom"
        Me.dtpFrom.Size = New System.Drawing.Size(200, 20)
        Me.dtpFrom.TabIndex = 353
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(521, 19)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(64, 23)
        Me.btnReset.TabIndex = 16
        Me.btnReset.Text = "RESET"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(279, 20)
        Me.txtCari.MaxLength = 100
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(236, 22)
        Me.txtCari.TabIndex = 15
        '
        'cmbCari
        '
        Me.cmbCari.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbCari.FormattingEnabled = True
        Me.cmbCari.Location = New System.Drawing.Point(136, 18)
        Me.cmbCari.Name = "cmbCari"
        Me.cmbCari.Size = New System.Drawing.Size(137, 24)
        Me.cmbCari.TabIndex = 14
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(12, 21)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 16)
        Me.Label17.TabIndex = 351
        Me.Label17.Text = "Berdasarkan"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnAdd, Me.ToolStripSeparator1, Me.btnUpdate, Me.ToolStripSeparator2, Me.ToolStripButton1, Me.ToolStripSeparator3, Me.btnBuka, Me.ToolStripSeparator5, Me.btnDelete, Me.ToolStripSeparator4, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(912, 52)
        Me.main_tool_strip.TabIndex = 481
        Me.main_tool_strip.Text = "Tool Strip"
        '
        'btnAdd
        '
        Me.btnAdd.Image = CType(resources.GetObject("btnAdd.Image"), System.Drawing.Image)
        Me.btnAdd.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(49, 49)
        Me.btnAdd.Text = "Tambah"
        Me.btnAdd.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnAdd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator1
        '
        Me.ToolStripSeparator1.Name = "ToolStripSeparator1"
        Me.ToolStripSeparator1.Size = New System.Drawing.Size(6, 52)
        '
        'btnUpdate
        '
        Me.btnUpdate.Image = CType(resources.GetObject("btnUpdate.Image"), System.Drawing.Image)
        Me.btnUpdate.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnUpdate.Name = "btnUpdate"
        Me.btnUpdate.Size = New System.Drawing.Size(36, 49)
        Me.btnUpdate.Text = "Ubah"
        Me.btnUpdate.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnUpdate.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 52)
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), System.Drawing.Image)
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(36, 49)
        Me.ToolStripButton1.Text = "Print"
        Me.ToolStripButton1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ToolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 52)
        '
        'btnBuka
        '
        Me.btnBuka.Image = CType(resources.GetObject("btnBuka.Image"), System.Drawing.Image)
        Me.btnBuka.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnBuka.Name = "btnBuka"
        Me.btnBuka.Size = New System.Drawing.Size(81, 49)
        Me.btnBuka.Text = "Buka Dokumen"
        Me.btnBuka.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnBuka.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        Me.btnBuka.Visible = False
        '
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 52)
        Me.ToolStripSeparator5.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Image = CType(resources.GetObject("btnDelete.Image"), System.Drawing.Image)
        Me.btnDelete.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(41, 49)
        Me.btnDelete.Text = "Hapus"
        Me.btnDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'ToolStripSeparator4
        '
        Me.ToolStripSeparator4.Name = "ToolStripSeparator4"
        Me.ToolStripSeparator4.Size = New System.Drawing.Size(6, 52)
        '
        'btnExit
        '
        Me.btnExit.Image = CType(resources.GetObject("btnExit.Image"), System.Drawing.Image)
        Me.btnExit.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(41, 49)
        Me.btnExit.Text = "Keluar"
        Me.btnExit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.btnExit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText
        '
        'sales_order_tab
        '
        Me.sales_order_tab.AccessibleName = "sales_order_tab"
        Me.sales_order_tab.Controls.Add(Me.sales_order_main)
        Me.sales_order_tab.Location = New System.Drawing.Point(12, 118)
        Me.sales_order_tab.Name = "sales_order_tab"
        Me.sales_order_tab.SelectedIndex = 0
        Me.sales_order_tab.Size = New System.Drawing.Size(870, 516)
        Me.sales_order_tab.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight
        Me.sales_order_tab.TabIndex = 482
        '
        'sales_order_main
        '
        Me.sales_order_main.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.sales_order_main.Controls.Add(Me.DataGridView1)
        Me.sales_order_main.Location = New System.Drawing.Point(4, 22)
        Me.sales_order_main.Name = "sales_order_main"
        Me.sales_order_main.Padding = New System.Windows.Forms.Padding(3)
        Me.sales_order_main.Size = New System.Drawing.Size(862, 490)
        Me.sales_order_main.TabIndex = 0
        Me.sales_order_main.Text = "Pemesanan Pennjuala"
        Me.sales_order_main.UseVisualStyleBackColor = True
        '
        'FormSO
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(912, 646)
        Me.Controls.Add(Me.sales_order_tab)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSO"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pemesanan Penjualan"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        Me.sales_order_tab.ResumeLayout(False)
        Me.sales_order_main.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents cmbCari As System.Windows.Forms.ComboBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnAdd As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator1 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnUpdate As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator2 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnDelete As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator3 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents lblSeperator As System.Windows.Forms.Label
    Friend WithEvents dtpTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnCari As System.Windows.Forms.Button
    Friend WithEvents sales_order_tab As System.Windows.Forms.TabControl
    Friend WithEvents sales_order_main As System.Windows.Forms.TabPage
    Friend WithEvents ToolStripSeparator4 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents ToolStripButton1 As System.Windows.Forms.ToolStripButton
    Friend WithEvents btnBuka As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator

End Class
