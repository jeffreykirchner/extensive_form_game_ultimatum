<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmInstructions
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmInstructions))
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlFITB = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSubmitQuiz = New System.Windows.Forms.Button()
        Me.txtQuizAnswer = New System.Windows.Forms.TextBox()
        Me.pnlTF = New System.Windows.Forms.Panel()
        Me.cmdFalse = New System.Windows.Forms.Button()
        Me.cmdTrue = New System.Windows.Forms.Button()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.pnlFITB.SuspendLayout()
        Me.pnlTF.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(13, 499)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(85, 31)
        Me.cmdBack.TabIndex = 14
        Me.cmdBack.Text = "<< Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        Me.cmdBack.Visible = False
        '
        'cmdNext
        '
        Me.cmdNext.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.Location = New System.Drawing.Point(325, 499)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(85, 31)
        Me.cmdNext.TabIndex = 13
        Me.cmdNext.Text = "Next >>"
        Me.cmdNext.UseVisualStyleBackColor = True
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(128, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.cmdStart.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.Location = New System.Drawing.Point(168, 499)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(85, 31)
        Me.cmdStart.TabIndex = 12
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = False
        Me.cmdStart.Visible = False
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(8, 10)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox1.Size = New System.Drawing.Size(384, 386)
        Me.RichTextBox1.TabIndex = 11
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = ""
        '
        'pnlFITB
        '
        Me.pnlFITB.Controls.Add(Me.Label1)
        Me.pnlFITB.Controls.Add(Me.cmdSubmitQuiz)
        Me.pnlFITB.Controls.Add(Me.txtQuizAnswer)
        Me.pnlFITB.Location = New System.Drawing.Point(13, 426)
        Me.pnlFITB.Name = "pnlFITB"
        Me.pnlFITB.Size = New System.Drawing.Size(401, 67)
        Me.pnlFITB.TabIndex = 17
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(98, 20)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Quiz Answer"
        '
        'cmdSubmitQuiz
        '
        Me.cmdSubmitQuiz.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmitQuiz.Location = New System.Drawing.Point(313, 30)
        Me.cmdSubmitQuiz.Name = "cmdSubmitQuiz"
        Me.cmdSubmitQuiz.Size = New System.Drawing.Size(78, 32)
        Me.cmdSubmitQuiz.TabIndex = 17
        Me.cmdSubmitQuiz.Text = "Submit"
        Me.cmdSubmitQuiz.UseVisualStyleBackColor = True
        '
        'txtQuizAnswer
        '
        Me.txtQuizAnswer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuizAnswer.Location = New System.Drawing.Point(3, 30)
        Me.txtQuizAnswer.Name = "txtQuizAnswer"
        Me.txtQuizAnswer.Size = New System.Drawing.Size(304, 29)
        Me.txtQuizAnswer.TabIndex = 16
        Me.txtQuizAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlTF
        '
        Me.pnlTF.BackColor = System.Drawing.Color.White
        Me.pnlTF.Controls.Add(Me.cmdFalse)
        Me.pnlTF.Controls.Add(Me.cmdTrue)
        Me.pnlTF.Location = New System.Drawing.Point(13, 318)
        Me.pnlTF.Name = "pnlTF"
        Me.pnlTF.Size = New System.Drawing.Size(401, 92)
        Me.pnlTF.TabIndex = 18
        '
        'cmdFalse
        '
        Me.cmdFalse.FlatAppearance.BorderSize = 2
        Me.cmdFalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFalse.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFalse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cmdFalse.Location = New System.Drawing.Point(204, 30)
        Me.cmdFalse.Name = "cmdFalse"
        Me.cmdFalse.Size = New System.Drawing.Size(103, 35)
        Me.cmdFalse.TabIndex = 19
        Me.cmdFalse.TabStop = False
        Me.cmdFalse.Text = "False"
        Me.cmdFalse.UseVisualStyleBackColor = True
        '
        'cmdTrue
        '
        Me.cmdTrue.FlatAppearance.BorderSize = 2
        Me.cmdTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTrue.Font = New System.Drawing.Font("Calibri", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTrue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cmdTrue.Location = New System.Drawing.Point(79, 30)
        Me.cmdTrue.Name = "cmdTrue"
        Me.cmdTrue.Size = New System.Drawing.Size(103, 35)
        Me.cmdTrue.TabIndex = 17
        Me.cmdTrue.TabStop = False
        Me.cmdTrue.Text = "True"
        Me.cmdTrue.UseVisualStyleBackColor = True
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Panel1.Controls.Add(Me.RichTextBox1)
        Me.Panel1.Location = New System.Drawing.Point(12, 12)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(402, 300)
        Me.Panel1.TabIndex = 19
        '
        'frmInstructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(423, 542)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.pnlTF)
        Me.Controls.Add(Me.pnlFITB)
        Me.Controls.Add(Me.cmdBack)
        Me.Controls.Add(Me.cmdNext)
        Me.Controls.Add(Me.cmdStart)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInstructions"
        Me.Text = "Instructions"
        Me.TopMost = True
        Me.pnlFITB.ResumeLayout(False)
        Me.pnlFITB.PerformLayout()
        Me.pnlTF.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdBack As System.Windows.Forms.Button
    Friend WithEvents cmdNext As System.Windows.Forms.Button
    Friend WithEvents cmdStart As System.Windows.Forms.Button
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlFITB As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents cmdSubmitQuiz As Button
    Friend WithEvents txtQuizAnswer As TextBox
    Friend WithEvents pnlTF As Panel
    Friend WithEvents cmdTrue As Button
    Friend WithEvents cmdFalse As Button
    Friend WithEvents Panel1 As Panel
End Class
