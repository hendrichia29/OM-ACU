<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMsFormula
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMsFormula))
        Me.Label18 = New System.Windows.Forms.Label
        Me.lblKodekaryawan = New System.Windows.Forms.Label
        Me.main_tool_strip = New System.Windows.Forms.ToolStrip
        Me.btnSave = New System.Windows.Forms.ToolStripButton
        Me.ToolStripSeparator5 = New System.Windows.Forms.ToolStripSeparator
        Me.btnExit = New System.Windows.Forms.ToolStripButton
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.txtQtyKlemMentah = New System.Windows.Forms.TextBox
        Me.cmbQtyKlemMentah = New System.Windows.Forms.ComboBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.txtQtyPaku = New System.Windows.Forms.TextBox
        Me.cmbQtyPaku = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.txtQtyKlemJadi = New System.Windows.Forms.TextBox
        Me.cmbUkuran = New System.Windows.Forms.ComboBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.cmbUkuranPaku = New System.Windows.Forms.ComboBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.cmbTipe = New System.Windows.Forms.ComboBox
        Me.main_tool_strip.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(50, 196)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(39, 16)
        Me.Label18.TabIndex = 493
        Me.Label18.Text = "Paku"
        '
        'lblKodekaryawan
        '
        Me.lblKodekaryawan.AutoSize = True
        Me.lblKodekaryawan.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblKodekaryawan.Location = New System.Drawing.Point(50, 168)
        Me.lblKodekaryawan.Name = "lblKodekaryawan"
        Me.lblKodekaryawan.Size = New System.Drawing.Size(85, 16)
        Me.lblKodekaryawan.TabIndex = 492
        Me.lblKodekaryawan.Text = "Klem Mentah"
        '
        'main_tool_strip
        '
        Me.main_tool_strip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden
        Me.main_tool_strip.ImageScalingSize = New System.Drawing.Size(32, 32)
        Me.main_tool_strip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.btnSave, Me.ToolStripSeparator5, Me.btnExit})
        Me.main_tool_strip.Location = New System.Drawing.Point(0, 0)
        Me.main_tool_strip.Name = "main_tool_strip"
        Me.main_tool_strip.Size = New System.Drawing.Size(542, 54)
        Me.main_tool_strip.TabIndex = 553
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
        'ToolStripSeparator5
        '
        Me.ToolStripSeparator5.Name = "ToolStripSeparator5"
        Me.ToolStripSeparator5.Size = New System.Drawing.Size(6, 54)
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
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(157, 224)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(190, 13)
        Me.Label24.TabIndex = 554
        Me.Label24.Text = "-------------------------------------------------------------"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(50, 246)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(67, 16)
        Me.Label3.TabIndex = 558
        Me.Label3.Text = "Klem Jadi"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(388, 168)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(31, 16)
        Me.Label9.TabIndex = 624
        Me.Label9.Text = "/ Kg"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(254, 165)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(69, 15)
        Me.Label10.TabIndex = 623
        Me.Label10.Text = "/ Karung Or"
        '
        'txtQtyKlemMentah
        '
        Me.txtQtyKlemMentah.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemMentah.Location = New System.Drawing.Point(187, 162)
        Me.txtQtyKlemMentah.MaxLength = 20
        Me.txtQtyKlemMentah.Name = "txtQtyKlemMentah"
        Me.txtQtyKlemMentah.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemMentah.TabIndex = 4
        '
        'cmbQtyKlemMentah
        '
        Me.cmbQtyKlemMentah.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQtyKlemMentah.FormattingEnabled = True
        Me.cmbQtyKlemMentah.Location = New System.Drawing.Point(329, 165)
        Me.cmbQtyKlemMentah.Name = "cmbQtyKlemMentah"
        Me.cmbQtyKlemMentah.Size = New System.Drawing.Size(53, 21)
        Me.cmbQtyKlemMentah.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(388, 196)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(31, 16)
        Me.Label1.TabIndex = 628
        Me.Label1.Text = "/ Kg"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(254, 193)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(68, 15)
        Me.Label5.TabIndex = 627
        Me.Label5.Text = "/ Kardus Or"
        '
        'txtQtyPaku
        '
        Me.txtQtyPaku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyPaku.Location = New System.Drawing.Point(187, 190)
        Me.txtQtyPaku.MaxLength = 20
        Me.txtQtyPaku.Name = "txtQtyPaku"
        Me.txtQtyPaku.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyPaku.TabIndex = 6
        '
        'cmbQtyPaku
        '
        Me.cmbQtyPaku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbQtyPaku.FormattingEnabled = True
        Me.cmbQtyPaku.Location = New System.Drawing.Point(329, 193)
        Me.cmbQtyPaku.Name = "cmbQtyPaku"
        Me.cmbQtyPaku.Size = New System.Drawing.Size(53, 21)
        Me.cmbQtyPaku.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(254, 249)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 580
        Me.Label4.Text = "/ Karung"
        '
        'txtQtyKlemJadi
        '
        Me.txtQtyKlemJadi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQtyKlemJadi.Location = New System.Drawing.Point(187, 243)
        Me.txtQtyKlemJadi.MaxLength = 20
        Me.txtQtyKlemJadi.Name = "txtQtyKlemJadi"
        Me.txtQtyKlemJadi.Size = New System.Drawing.Size(61, 22)
        Me.txtQtyKlemJadi.TabIndex = 8
        '
        'cmbUkuran
        '
        Me.cmbUkuran.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUkuran.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUkuran.FormattingEnabled = True
        Me.cmbUkuran.Location = New System.Drawing.Point(187, 104)
        Me.cmbUkuran.Name = "cmbUkuran"
        Me.cmbUkuran.Size = New System.Drawing.Size(59, 23)
        Me.cmbUkuran.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(50, 107)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(131, 16)
        Me.Label2.TabIndex = 631
        Me.Label2.Text = "Ukuran Klem Mentah"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(50, 136)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(85, 16)
        Me.Label6.TabIndex = 633
        Me.Label6.Text = "Ukuran Paku"
        '
        'cmbUkuranPaku
        '
        Me.cmbUkuranPaku.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbUkuranPaku.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbUkuranPaku.FormattingEnabled = True
        Me.cmbUkuranPaku.Location = New System.Drawing.Point(187, 133)
        Me.cmbUkuranPaku.Name = "cmbUkuranPaku"
        Me.cmbUkuranPaku.Size = New System.Drawing.Size(59, 23)
        Me.cmbUkuranPaku.TabIndex = 3
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(50, 78)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(36, 16)
        Me.Label7.TabIndex = 635
        Me.Label7.Text = "Tipe"
        '
        'cmbTipe
        '
        Me.cmbTipe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cmbTipe.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbTipe.FormattingEnabled = True
        Me.cmbTipe.Location = New System.Drawing.Point(187, 75)
        Me.cmbTipe.Name = "cmbTipe"
        Me.cmbTipe.Size = New System.Drawing.Size(136, 23)
        Me.cmbTipe.TabIndex = 1
        '
        'FormMsFormula
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(542, 343)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.cmbTipe)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.cmbUkuranPaku)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cmbUkuran)
        Me.Controls.Add(Me.txtQtyKlemJadi)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtQtyPaku)
        Me.Controls.Add(Me.cmbQtyPaku)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtQtyKlemMentah)
        Me.Controls.Add(Me.cmbQtyKlemMentah)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.main_tool_strip)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.lblKodekaryawan)
        Me.MaximizeBox = False
        Me.Name = "FormMsFormula"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Master Formula Produksi"
        Me.main_tool_strip.ResumeLayout(False)
        Me.main_tool_strip.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents lblKodekaryawan As System.Windows.Forms.Label
    Friend WithEvents main_tool_strip As System.Windows.Forms.ToolStrip
    Friend WithEvents btnSave As System.Windows.Forms.ToolStripButton
    Friend WithEvents ToolStripSeparator5 As System.Windows.Forms.ToolStripSeparator
    Friend WithEvents btnExit As System.Windows.Forms.ToolStripButton
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemMentah As System.Windows.Forms.TextBox
    Friend WithEvents cmbQtyKlemMentah As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtQtyPaku As System.Windows.Forms.TextBox
    Friend WithEvents cmbQtyPaku As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtQtyKlemJadi As System.Windows.Forms.TextBox
    Friend WithEvents cmbUkuran As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents cmbUkuranPaku As System.Windows.Forms.ComboBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents cmbTipe As System.Windows.Forms.ComboBox
End Class
