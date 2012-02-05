<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class sales_order
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
        Me.crv_sales_order = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'crv_sales_order
        '
        Me.crv_sales_order.ActiveViewIndex = -1
        Me.crv_sales_order.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.crv_sales_order.Dock = System.Windows.Forms.DockStyle.Fill
        Me.crv_sales_order.Location = New System.Drawing.Point(0, 0)
        Me.crv_sales_order.Name = "crv_sales_order"
        Me.crv_sales_order.SelectionFormula = ""
        Me.crv_sales_order.Size = New System.Drawing.Size(1362, 742)
        Me.crv_sales_order.TabIndex = 0
        Me.crv_sales_order.ViewTimeSelectionFormula = ""
        '
        'sales_order
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1362, 742)
        Me.Controls.Add(Me.crv_sales_order)
        Me.Name = "sales_order"
        Me.Text = "sales_order"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents crv_sales_order As CrystalDecisions.Windows.Forms.CrystalReportViewer
End Class
