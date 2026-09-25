<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmNames
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmNames))
        Me.lblEarnings = New System.Windows.Forms.Label()
        Me.lbl1 = New System.Windows.Forms.Label()
        Me.cmdSubmit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lblEarnings
        '
        Me.lblEarnings.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEarnings.Location = New System.Drawing.Point(12, 9)
        Me.lblEarnings.Name = "lblEarnings"
        Me.lblEarnings.Size = New System.Drawing.Size(376, 33)
        Me.lblEarnings.TabIndex = 34
        Me.lblEarnings.Text = "Your Earnings Are: $000.00"
        Me.lblEarnings.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lbl1
        '
        Me.lbl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl1.Location = New System.Drawing.Point(12, 59)
        Me.lbl1.Name = "lbl1"
        Me.lbl1.Size = New System.Drawing.Size(355, 58)
        Me.lbl1.TabIndex = 35
        Me.lbl1.Text = "Click the button below to continue to a questionnaire."
        Me.lbl1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'cmdSubmit
        '
        Me.cmdSubmit.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.cmdSubmit.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmit.Location = New System.Drawing.Point(45, 131)
        Me.cmdSubmit.Name = "cmdSubmit"
        Me.cmdSubmit.Size = New System.Drawing.Size(306, 42)
        Me.cmdSubmit.TabIndex = 36
        Me.cmdSubmit.Text = "Continue"
        Me.cmdSubmit.UseVisualStyleBackColor = False
        '
        'frmNames
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(379, 185)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdSubmit)
        Me.Controls.Add(Me.lblEarnings)
        Me.Controls.Add(Me.lbl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Name = "frmNames"
        Me.Text = "Enter Your Name"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents lblEarnings As Label
    Friend WithEvents lbl1 As Label
    Friend WithEvents cmdSubmit As Button
End Class
