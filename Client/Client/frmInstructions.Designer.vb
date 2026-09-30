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
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.pnlFITB = New System.Windows.Forms.Panel()
        Me.cmdSubmitQuiz = New System.Windows.Forms.Button()
        Me.txtQuizAnswer = New System.Windows.Forms.TextBox()
        Me.pnlTF = New System.Windows.Forms.Panel()
        Me.cmdFalse = New System.Windows.Forms.Button()
        Me.cmdTrue = New System.Windows.Forms.Button()
        Me.pnlControl = New System.Windows.Forms.Panel()
        Me.cmdBack = New System.Windows.Forms.Button()
        Me.cmdNext = New System.Windows.Forms.Button()
        Me.cmdStart = New System.Windows.Forms.Button()
        Me.rtbAnswer = New System.Windows.Forms.RichTextBox()
        Me.pnlAnswer = New System.Windows.Forms.Panel()
        Me.pnlFITB.SuspendLayout()
        Me.pnlTF.SuspendLayout()
        Me.pnlControl.SuspendLayout()
        Me.pnlAnswer.SuspendLayout()
        Me.SuspendLayout()
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.White
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.Location = New System.Drawing.Point(75, 563)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.RichTextBox1.Size = New System.Drawing.Size(667, 252)
        Me.RichTextBox1.TabIndex = 11
        Me.RichTextBox1.TabStop = False
        Me.RichTextBox1.Text = ""
        '
        'pnlFITB
        '
        Me.pnlFITB.Controls.Add(Me.cmdSubmitQuiz)
        Me.pnlFITB.Controls.Add(Me.txtQuizAnswer)
        Me.pnlFITB.Location = New System.Drawing.Point(784, 610)
        Me.pnlFITB.Name = "pnlFITB"
        Me.pnlFITB.Size = New System.Drawing.Size(667, 67)
        Me.pnlFITB.TabIndex = 17
        Me.pnlFITB.Visible = False
        '
        'cmdSubmitQuiz
        '
        Me.cmdSubmitQuiz.FlatAppearance.BorderSize = 2
        Me.cmdSubmitQuiz.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdSubmitQuiz.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSubmitQuiz.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cmdSubmitQuiz.Location = New System.Drawing.Point(367, 3)
        Me.cmdSubmitQuiz.Name = "cmdSubmitQuiz"
        Me.cmdSubmitQuiz.Size = New System.Drawing.Size(164, 57)
        Me.cmdSubmitQuiz.TabIndex = 17
        Me.cmdSubmitQuiz.Text = "Submit"
        Me.cmdSubmitQuiz.UseVisualStyleBackColor = True
        '
        'txtQuizAnswer
        '
        Me.txtQuizAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtQuizAnswer.Font = New System.Drawing.Font("Calibri", 26.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtQuizAnswer.Location = New System.Drawing.Point(145, 6)
        Me.txtQuizAnswer.Name = "txtQuizAnswer"
        Me.txtQuizAnswer.Size = New System.Drawing.Size(216, 50)
        Me.txtQuizAnswer.TabIndex = 16
        Me.txtQuizAnswer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'pnlTF
        '
        Me.pnlTF.BackColor = System.Drawing.Color.White
        Me.pnlTF.Controls.Add(Me.cmdFalse)
        Me.pnlTF.Controls.Add(Me.cmdTrue)
        Me.pnlTF.Location = New System.Drawing.Point(784, 537)
        Me.pnlTF.Name = "pnlTF"
        Me.pnlTF.Size = New System.Drawing.Size(667, 67)
        Me.pnlTF.TabIndex = 18
        Me.pnlTF.Visible = False
        '
        'cmdFalse
        '
        Me.cmdFalse.FlatAppearance.BorderSize = 2
        Me.cmdFalse.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdFalse.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFalse.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cmdFalse.Location = New System.Drawing.Point(358, 7)
        Me.cmdFalse.Name = "cmdFalse"
        Me.cmdFalse.Size = New System.Drawing.Size(164, 57)
        Me.cmdFalse.TabIndex = 19
        Me.cmdFalse.TabStop = False
        Me.cmdFalse.Text = "False"
        Me.cmdFalse.UseVisualStyleBackColor = True
        '
        'cmdTrue
        '
        Me.cmdTrue.FlatAppearance.BorderSize = 2
        Me.cmdTrue.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdTrue.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTrue.ForeColor = System.Drawing.Color.FromArgb(CType(CType(47, Byte), Integer), CType(CType(93, Byte), Integer), CType(CType(197, Byte), Integer))
        Me.cmdTrue.Location = New System.Drawing.Point(178, 7)
        Me.cmdTrue.Name = "cmdTrue"
        Me.cmdTrue.Size = New System.Drawing.Size(164, 57)
        Me.cmdTrue.TabIndex = 17
        Me.cmdTrue.TabStop = False
        Me.cmdTrue.Text = "True"
        Me.cmdTrue.UseVisualStyleBackColor = True
        '
        'pnlControl
        '
        Me.pnlControl.Controls.Add(Me.cmdBack)
        Me.pnlControl.Controls.Add(Me.cmdNext)
        Me.pnlControl.Controls.Add(Me.cmdStart)
        Me.pnlControl.Location = New System.Drawing.Point(784, 683)
        Me.pnlControl.Name = "pnlControl"
        Me.pnlControl.Size = New System.Drawing.Size(667, 67)
        Me.pnlControl.TabIndex = 18
        Me.pnlControl.Visible = False
        '
        'cmdBack
        '
        Me.cmdBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBack.Location = New System.Drawing.Point(22, 33)
        Me.cmdBack.Name = "cmdBack"
        Me.cmdBack.Size = New System.Drawing.Size(85, 31)
        Me.cmdBack.TabIndex = 17
        Me.cmdBack.Text = "<< Back"
        Me.cmdBack.UseVisualStyleBackColor = True
        Me.cmdBack.Visible = False
        '
        'cmdNext
        '
        Me.cmdNext.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.cmdNext.FlatAppearance.BorderSize = 0
        Me.cmdNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdNext.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdNext.ForeColor = System.Drawing.Color.White
        Me.cmdNext.Location = New System.Drawing.Point(482, 3)
        Me.cmdNext.Name = "cmdNext"
        Me.cmdNext.Size = New System.Drawing.Size(164, 57)
        Me.cmdNext.TabIndex = 16
        Me.cmdNext.Text = "Continue"
        Me.cmdNext.UseVisualStyleBackColor = False
        '
        'cmdStart
        '
        Me.cmdStart.BackColor = System.Drawing.Color.FromArgb(CType(CType(30, Byte), Integer), CType(CType(142, Byte), Integer), CType(CType(62, Byte), Integer))
        Me.cmdStart.FlatAppearance.BorderSize = 0
        Me.cmdStart.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cmdStart.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdStart.ForeColor = System.Drawing.Color.White
        Me.cmdStart.Location = New System.Drawing.Point(239, 3)
        Me.cmdStart.Name = "cmdStart"
        Me.cmdStart.Size = New System.Drawing.Size(164, 57)
        Me.cmdStart.TabIndex = 15
        Me.cmdStart.Text = "Start"
        Me.cmdStart.UseVisualStyleBackColor = False
        Me.cmdStart.Visible = False
        '
        'rtbAnswer
        '
        Me.rtbAnswer.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.rtbAnswer.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.rtbAnswer.Font = New System.Drawing.Font("Calibri", 18.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rtbAnswer.Location = New System.Drawing.Point(14, 14)
        Me.rtbAnswer.Name = "rtbAnswer"
        Me.rtbAnswer.ReadOnly = True
        Me.rtbAnswer.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None
        Me.rtbAnswer.Size = New System.Drawing.Size(639, 101)
        Me.rtbAnswer.TabIndex = 19
        Me.rtbAnswer.TabStop = False
        Me.rtbAnswer.Text = ""
        '
        'pnlAnswer
        '
        Me.pnlAnswer.BackColor = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(244, Byte), Integer), CType(CType(234, Byte), Integer))
        Me.pnlAnswer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pnlAnswer.Controls.Add(Me.rtbAnswer)
        Me.pnlAnswer.Location = New System.Drawing.Point(75, 821)
        Me.pnlAnswer.Name = "pnlAnswer"
        Me.pnlAnswer.Size = New System.Drawing.Size(667, 123)
        Me.pnlAnswer.TabIndex = 20
        Me.pnlAnswer.Visible = False
        '
        'frmInstructions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(1904, 1041)
        Me.ControlBox = False
        Me.Controls.Add(Me.pnlAnswer)
        Me.Controls.Add(Me.pnlControl)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.pnlTF)
        Me.Controls.Add(Me.pnlFITB)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmInstructions"
        Me.Text = "Quiz"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.pnlFITB.ResumeLayout(False)
        Me.pnlFITB.PerformLayout()
        Me.pnlTF.ResumeLayout(False)
        Me.pnlControl.ResumeLayout(False)
        Me.pnlAnswer.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents pnlFITB As Panel
    Friend WithEvents cmdSubmitQuiz As Button
    Friend WithEvents txtQuizAnswer As TextBox
    Friend WithEvents pnlTF As Panel
    Friend WithEvents cmdTrue As Button
    Friend WithEvents cmdFalse As Button
    Friend WithEvents pnlControl As Panel
    Friend WithEvents cmdBack As Button
    Friend WithEvents cmdNext As Button
    Friend WithEvents cmdStart As Button
    Friend WithEvents rtbAnswer As RichTextBox
    Friend WithEvents pnlAnswer As Panel
End Class
