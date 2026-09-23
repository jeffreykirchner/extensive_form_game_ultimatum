<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmSetup
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmSetup))
        Me.txtPort = New System.Windows.Forms.TextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.txtPeriods = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.chkShowInstructions = New System.Windows.Forms.CheckBox()
        Me.txtPlayers = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdSave = New System.Windows.Forms.Button()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.Label24 = New System.Windows.Forms.Label()
        Me.txtWindowX = New System.Windows.Forms.TextBox()
        Me.txtWindowY = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtInstructionX = New System.Windows.Forms.TextBox()
        Me.txtInstructionY = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.rbCents = New System.Windows.Forms.RadioButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.rbDollars = New System.Windows.Forms.RadioButton()
        Me.chkTestMode = New System.Windows.Forms.CheckBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtIpage8 = New System.Windows.Forms.TextBox()
        Me.txtSortWindow = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbPounds = New System.Windows.Forms.RadioButton()
        Me.txtSurveyLink = New System.Windows.Forms.TextBox()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.chkDecimalFormat = New System.Windows.Forms.CheckBox()
        Me.SuspendLayout()
        '
        'txtPort
        '
        Me.txtPort.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPort.Location = New System.Drawing.Point(308, 95)
        Me.txtPort.Name = "txtPort"
        Me.txtPort.Size = New System.Drawing.Size(162, 26)
        Me.txtPort.TabIndex = 50
        Me.txtPort.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(8, 98)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(204, 20)
        Me.Label10.TabIndex = 49
        Me.Label10.Text = "Port # (Requires restart)"
        '
        'txtPeriods
        '
        Me.txtPeriods.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPeriods.Location = New System.Drawing.Point(308, 63)
        Me.txtPeriods.Name = "txtPeriods"
        Me.txtPeriods.Size = New System.Drawing.Size(162, 26)
        Me.txtPeriods.TabIndex = 48
        Me.txtPeriods.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(8, 69)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(157, 20)
        Me.Label7.TabIndex = 47
        Me.Label7.Text = "Number of Periods"
        '
        'chkShowInstructions
        '
        Me.chkShowInstructions.AutoSize = True
        Me.chkShowInstructions.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkShowInstructions.Location = New System.Drawing.Point(300, 449)
        Me.chkShowInstructions.Name = "chkShowInstructions"
        Me.chkShowInstructions.Size = New System.Drawing.Size(172, 24)
        Me.chkShowInstructions.TabIndex = 46
        Me.chkShowInstructions.Text = "Show Instructions"
        Me.chkShowInstructions.UseVisualStyleBackColor = True
        '
        'txtPlayers
        '
        Me.txtPlayers.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlayers.Location = New System.Drawing.Point(308, 12)
        Me.txtPlayers.Name = "txtPlayers"
        Me.txtPlayers.Size = New System.Drawing.Size(162, 26)
        Me.txtPlayers.TabIndex = 45
        Me.txtPlayers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(294, 20)
        Me.Label1.TabIndex = 44
        Me.Label1.Text = "Number of Players (Even #, 30 Max)"
        '
        'cmdSave
        '
        Me.cmdSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSave.Location = New System.Drawing.Point(14, 496)
        Me.cmdSave.Name = "cmdSave"
        Me.cmdSave.Size = New System.Drawing.Size(457, 27)
        Me.cmdSave.TabIndex = 43
        Me.cmdSave.Text = "Save and Close"
        Me.cmdSave.UseVisualStyleBackColor = True
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(406, 162)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(21, 20)
        Me.Label23.TabIndex = 101
        Me.Label23.Text = "Y"
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label24.Location = New System.Drawing.Point(333, 162)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(21, 20)
        Me.Label24.TabIndex = 100
        Me.Label24.Text = "X"
        '
        'txtWindowX
        '
        Me.txtWindowX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowX.Location = New System.Drawing.Point(357, 159)
        Me.txtWindowX.Name = "txtWindowX"
        Me.txtWindowX.Size = New System.Drawing.Size(39, 26)
        Me.txtWindowX.TabIndex = 99
        Me.txtWindowX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtWindowY
        '
        Me.txtWindowY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWindowY.Location = New System.Drawing.Point(430, 159)
        Me.txtWindowY.Name = "txtWindowY"
        Me.txtWindowY.Size = New System.Drawing.Size(39, 26)
        Me.txtWindowY.TabIndex = 98
        Me.txtWindowY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label25
        '
        Me.Label25.AutoSize = True
        Me.Label25.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label25.Location = New System.Drawing.Point(8, 162)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(228, 20)
        Me.Label25.TabIndex = 97
        Me.Label25.Text = "Main Window Start Position"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label22.Location = New System.Drawing.Point(406, 130)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(21, 20)
        Me.Label22.TabIndex = 96
        Me.Label22.Text = "Y"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(333, 130)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(21, 20)
        Me.Label21.TabIndex = 95
        Me.Label21.Text = "X"
        '
        'txtInstructionX
        '
        Me.txtInstructionX.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionX.Location = New System.Drawing.Point(357, 127)
        Me.txtInstructionX.Name = "txtInstructionX"
        Me.txtInstructionX.Size = New System.Drawing.Size(39, 26)
        Me.txtInstructionX.TabIndex = 94
        Me.txtInstructionX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtInstructionY
        '
        Me.txtInstructionY.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtInstructionY.Location = New System.Drawing.Point(430, 127)
        Me.txtInstructionY.Name = "txtInstructionY"
        Me.txtInstructionY.Size = New System.Drawing.Size(39, 26)
        Me.txtInstructionY.TabIndex = 93
        Me.txtInstructionY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label20.Location = New System.Drawing.Point(8, 130)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(209, 20)
        Me.Label20.TabIndex = 92
        Me.Label20.Text = "Instruction Start Position"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DimGray
        Me.Label2.Location = New System.Drawing.Point(44, 41)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(317, 15)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "*Persons of Type 1 will be Player 1 to Player n/2."
        '
        'rbCents
        '
        Me.rbCents.AutoSize = True
        Me.rbCents.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbCents.Location = New System.Drawing.Point(396, 285)
        Me.rbCents.Name = "rbCents"
        Me.rbCents.Size = New System.Drawing.Size(74, 24)
        Me.rbCents.TabIndex = 103
        Me.rbCents.TabStop = True
        Me.rbCents.Text = "Cents"
        Me.rbCents.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(8, 285)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(167, 20)
        Me.Label3.TabIndex = 104
        Me.Label3.Text = "Unit Denominations"
        '
        'rbDollars
        '
        Me.rbDollars.AutoSize = True
        Me.rbDollars.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbDollars.Location = New System.Drawing.Point(308, 285)
        Me.rbDollars.Name = "rbDollars"
        Me.rbDollars.Size = New System.Drawing.Size(83, 24)
        Me.rbDollars.TabIndex = 105
        Me.rbDollars.TabStop = True
        Me.rbDollars.Text = "Dollars"
        Me.rbDollars.UseVisualStyleBackColor = True
        '
        'chkTestMode
        '
        Me.chkTestMode.AutoSize = True
        Me.chkTestMode.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkTestMode.Location = New System.Drawing.Point(78, 449)
        Me.chkTestMode.Name = "chkTestMode"
        Me.chkTestMode.Size = New System.Drawing.Size(112, 24)
        Me.chkTestMode.TabIndex = 106
        Me.chkTestMode.Text = "Test Mode"
        Me.chkTestMode.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 367)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(457, 23)
        Me.Label4.TabIndex = 107
        Me.Label4.Text = "Instruction Text on Round Length and Pairings (Page 8)"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtIpage8
        '
        Me.txtIpage8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtIpage8.Location = New System.Drawing.Point(14, 393)
        Me.txtIpage8.Multiline = True
        Me.txtIpage8.Name = "txtIpage8"
        Me.txtIpage8.Size = New System.Drawing.Size(457, 47)
        Me.txtIpage8.TabIndex = 108
        Me.txtIpage8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSortWindow
        '
        Me.txtSortWindow.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSortWindow.Location = New System.Drawing.Point(309, 191)
        Me.txtSortWindow.Name = "txtSortWindow"
        Me.txtSortWindow.Size = New System.Drawing.Size(162, 26)
        Me.txtSortWindow.TabIndex = 110
        Me.txtSortWindow.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(9, 194)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(256, 20)
        Me.Label5.TabIndex = 109
        Me.Label5.Text = "Sorting Regime Period Window"
        '
        'rbPounds
        '
        Me.rbPounds.AutoSize = True
        Me.rbPounds.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbPounds.Location = New System.Drawing.Point(219, 285)
        Me.rbPounds.Name = "rbPounds"
        Me.rbPounds.Size = New System.Drawing.Size(87, 24)
        Me.rbPounds.TabIndex = 111
        Me.rbPounds.TabStop = True
        Me.rbPounds.Text = "Pounds"
        Me.rbPounds.UseVisualStyleBackColor = True
        '
        'txtSurveyLink
        '
        Me.txtSurveyLink.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSurveyLink.Location = New System.Drawing.Point(130, 223)
        Me.txtSurveyLink.Name = "txtSurveyLink"
        Me.txtSurveyLink.Size = New System.Drawing.Size(341, 26)
        Me.txtSurveyLink.TabIndex = 113
        '
        'Label28
        '
        Me.Label28.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label28.Location = New System.Drawing.Point(12, 226)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(112, 23)
        Me.Label28.TabIndex = 112
        Me.Label28.Text = "Survey Link"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'chkDecimalFormat
        '
        Me.chkDecimalFormat.AutoSize = True
        Me.chkDecimalFormat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.chkDecimalFormat.Location = New System.Drawing.Point(300, 324)
        Me.chkDecimalFormat.Name = "chkDecimalFormat"
        Me.chkDecimalFormat.Size = New System.Drawing.Size(154, 24)
        Me.chkDecimalFormat.TabIndex = 114
        Me.chkDecimalFormat.Text = "Decimal Format"
        Me.chkDecimalFormat.UseVisualStyleBackColor = True
        '
        'frmSetup
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(483, 539)
        Me.ControlBox = False
        Me.Controls.Add(Me.chkDecimalFormat)
        Me.Controls.Add(Me.txtSurveyLink)
        Me.Controls.Add(Me.Label28)
        Me.Controls.Add(Me.rbPounds)
        Me.Controls.Add(Me.txtSortWindow)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtIpage8)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.chkTestMode)
        Me.Controls.Add(Me.rbDollars)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.rbCents)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label23)
        Me.Controls.Add(Me.Label24)
        Me.Controls.Add(Me.txtWindowX)
        Me.Controls.Add(Me.txtWindowY)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label22)
        Me.Controls.Add(Me.Label21)
        Me.Controls.Add(Me.txtInstructionX)
        Me.Controls.Add(Me.txtInstructionY)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtPort)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.txtPeriods)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.chkShowInstructions)
        Me.Controls.Add(Me.txtPlayers)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmSetup"
        Me.Text = "Setup"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtPort As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents txtPeriods As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents chkShowInstructions As System.Windows.Forms.CheckBox
    Friend WithEvents txtPlayers As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdSave As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents txtWindowX As System.Windows.Forms.TextBox
    Friend WithEvents txtWindowY As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtInstructionX As System.Windows.Forms.TextBox
    Friend WithEvents txtInstructionY As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents rbCents As System.Windows.Forms.RadioButton
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents rbDollars As System.Windows.Forms.RadioButton
    Friend WithEvents chkTestMode As System.Windows.Forms.CheckBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtIpage8 As System.Windows.Forms.TextBox
    Friend WithEvents txtSortWindow As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents rbPounds As System.Windows.Forms.RadioButton
    Friend WithEvents txtSurveyLink As TextBox
    Friend WithEvents Label28 As Label
    Friend WithEvents chkDecimalFormat As CheckBox
End Class
