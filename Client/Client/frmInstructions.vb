Imports System.Windows.Forms.VisualStyles.VisualStyleElement

Public Class frmInstructions
    Dim tempS As Boolean
    Dim startPressed As Boolean

    Public pageDone(20) As Boolean
    Public results(20) As String

    Dim pageCorrectText() As String = {"Correct: True." & vbCrLf & vbCrLf & "Player 1 chooses between Offer A and Offer B.",
                                       "Correct: $12." & vbCrLf & vbCrLf & "If Player 2 accepts Offer A, both players receive $12.",
                                       "Correct: $21." & vbCrLf & vbCrLf & "If Player 2 accepts Offer B, Player 1 receives $21 and Player 2 receives $3.",
                                       "Correct: $0." & vbCrLf & vbCrLf & "If Player 2 rejects an offer, both amounts are set to zero.",
                                       "Correct: True." & vbCrLf & vbCrLf & "Player 2’s choice to accept or reject determines both players’ earnings.",
                                       "Correct: True." & vbCrLf & vbCrLf & "You will complete this task only one time."}

    Dim pageCorrectAnswers() As String = {"true",
                                          "12,$12,12.00,$12.00",
                                          "21,$21,21.00,$21.00",
                                          "0,$0,0.00,$0.00,zero",
                                          "true",
                                          "true",
                                          "true"}

    Dim pageType() As String = {"tf", "fitb", "fitb", "fitb", "tf", "fitb", "tf", "noquiz"}   'tf = true/false, fitb = fill in the blank, noquiz = no quiz on this page

    Dim errorText As String = "Incorrect" & vbCrLf & vbCrLf & "That answer is not correct. Please review the instructions and try again."

    Public startTimeOnPage As Date
    Public lastInstruction As Integer
    Public lastTimeOnPage As TimeSpan

    Public Sub nextInstruction()
        Try
            'load the next page of instructions

            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath &
                 "\instructions\page" & currentInstruction & ".rtf")

            variables()

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()

            If Not startPressed Then wskClient.Send("01", currentInstruction & ";" & lastInstruction & ";" & lastTimeOnPage.TotalMilliseconds)

            If pageType(currentInstruction - 1) = "fitb" Then
                cmdNext.Visible = False
                pnlFITB.Visible = True
                pnlTF.Visible = False

                Panel1.Height = 405
                pnlFITB.Top = 426
            ElseIf pageType(currentInstruction - 1) = "tf" Then
                cmdNext.Visible = False
                pnlFITB.Visible = False
                pnlTF.Visible = True

                Panel1.Height = 405
                pnlTF.Top = 426
            Else
                cmdNext.Visible = True
                pnlFITB.Visible = False
                pnlTF.Visible = False

                Panel1.Height = 480
            End If

            Call RepRTBfield("correct", " ")
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub variables()
        Try
            'load variables into instructions

            Dim tempN As Integer = 0
            Dim outstr As String = ""
            Select Case currentInstruction
                Case 1
                    'Use the following command to insert varibles into the instructions.
                    'Call RepRTBfield("playerCount-1", numberOfPlayers - 1)

                    pageDone(currentInstruction) = True
                Case 2
                    nodeListInstructions(1, 1).status = "sub2"
                    nodeListInstructions(2, 1).status = "closed"
                    currentNode = 3
                    pageDone(currentInstruction) = True
                Case 3
                    nodeListInstructions(1, 1).status = "closed"
                    nodeListInstructions(2, 1).status = "sub1"
                    currentNode = 2
                    pageDone(currentInstruction) = True
                Case 4

                    pageDone(currentInstruction) = True
                Case 5

                    If Not pageDone(currentInstruction) Then
                        'Call RepRTBfield("Result", " ")
                        'Call RepRTBfield("Continue", " ")
                        'Call RepRTBfield("done", " ")
                        'frmMain.cmdSubmit.Visible = True
                        'currentPeriodInstruction = 1
                        'frmMain.pnlMain.Enabled = True
                        'currentNode = 1
                        'selection = ""
                    Else

                    End If
                Case 6
                    'If myType = 1 Then
                    '    Call RepRTBfield("circleColor", "Orange")
                    '    RichTextBox1.Find("Orange")
                    '    RichTextBox1.SelectionColor = Color.Coral
                    'Else
                    '    Call RepRTBfield("circleColor", "Blue")
                    '    RichTextBox1.Find("Blue")
                    '    RichTextBox1.SelectionColor = Color.CornflowerBlue
                    'End If

                    'If Not pageDone(currentInstruction) Then
                    '    Call RepRTBfield("Result", " ")
                    '    Call RepRTBfield("Continue", " ")
                    '    Call RepRTBfield("done", " ")

                    '    frmMain.cmdSubmit.Visible = True
                    '    currentPeriodInstruction = 2
                    '    frmMain.pnlMain.Enabled = True
                    '    currentNode = 1
                    '    selection = ""
                    'Else

                    '    Call RepRTBfield("done", "(done)")

                    '    If myType = 1 Then
                    '        Call RepRTBfield("person", "2")

                    '        RichTextBox1.Find("Person 2")
                    '        RichTextBox1.SelectionColor = Color.Coral
                    '    Else
                    '        Call RepRTBfield("person", "1")

                    '        RichTextBox1.Find("Person 1")
                    '        RichTextBox1.SelectionColor = Color.CornflowerBlue
                    '    End If
                    'End If
                Case 7
                    'If Not pageDone(currentInstruction) Then
                    '    Call RepRTBfield("Result", " ")
                    '    Call RepRTBfield("Continue", " ")
                    '    Call RepRTBfield("done", " ")

                    '    frmMain.cmdSubmit.Visible = True
                    '    currentPeriodInstruction = 3
                    '    frmMain.pnlMain.Enabled = True
                    '    currentNode = 1
                    '    selection = ""
                    'Else
                    '    Call RepRTBfield("done", "(done)")

                    '    RichTextBox1.Find("#payoff11#")
                    '    RichTextBox1.SelectionColor = Color.CornflowerBlue

                    '    RichTextBox1.Find("#payoff12#")
                    '    RichTextBox1.SelectionColor = Color.Coral

                    '    RichTextBox1.Find("#payoff21#")
                    '    RichTextBox1.SelectionColor = Color.CornflowerBlue

                    '    RichTextBox1.Find("#payoff22#")
                    '    RichTextBox1.SelectionColor = Color.Coral

                    '    If results(currentInstruction) = "sub2" Then
                    '        Call RepRTBfield("payoff11", returnInsructionPayoff(nodeListInstructions(2, 3).payoff11))
                    '        Call RepRTBfield("payoff12", returnInsructionPayoff(nodeListInstructions(2, 3).payoff12))

                    '        Call RepRTBfield("payoff21", returnInsructionPayoff(nodeListInstructions(2, 3).payoff21))
                    '        Call RepRTBfield("payoff22", returnInsructionPayoff(nodeListInstructions(2, 3).payoff22))

                    '        Call RepRTBfield("person", myType)
                    '        RichTextBox1.Find("Person " & myType)

                    '        If myType = 1 Then
                    '            RichTextBox1.SelectionColor = Color.CornflowerBlue
                    '        Else
                    '            RichTextBox1.SelectionColor = Color.Coral
                    '        End If

                    '    Else
                    '        Call RepRTBfield("payoff11", returnInsructionPayoff(nodeListInstructions(3, 3).payoff11))
                    '        Call RepRTBfield("payoff12", returnInsructionPayoff(nodeListInstructions(3, 3).payoff12))

                    '        Call RepRTBfield("payoff21", returnInsructionPayoff(nodeListInstructions(3, 3).payoff21))
                    '        Call RepRTBfield("payoff22", returnInsructionPayoff(nodeListInstructions(3, 3).payoff22))

                    '        'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff11))
                    '        'RichTextBox1.SelectionColor = Color.CornflowerBlue

                    '        'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff21))
                    '        'RichTextBox1.SelectionColor = Color.CornflowerBlue

                    '        'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff12))
                    '        'RichTextBox1.SelectionColor = Color.Coral

                    '        'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff22))
                    '        'RichTextBox1.SelectionColor = Color.Coral

                    '        If myType = 1 Then
                    '            Call RepRTBfield("person", "2")
                    '            RichTextBox1.Find("Person 2")
                    '            RichTextBox1.SelectionColor = Color.Coral
                    '        Else
                    '            Call RepRTBfield("person", "1")
                    '            RichTextBox1.Find("Person 1")
                    '            RichTextBox1.SelectionColor = Color.CornflowerBlue
                    '        End If
                    '    End If
                    'End If
                Case 8
                    'pageDone(currentInstruction) = True
                    'Call RepRTBfield("iPage8Text", iPage8Text)
            End Select

            'Me.Text = "Instructions " & currentInstruction & "/7"
        Catch ex As Exception
            appEventLog_Write("error variables:", ex)
        End Try
    End Sub

    Public Sub RepRTBfield(ByVal sField As String, ByVal sValue As String)
        Try
            'when the instructions are loaded into the rich text box control this function will
            'replace the variable place holders with variables.

            RichTextBox1.Find("#" & sField & "#")
            RichTextBox1.SelectedText = sValue
        Catch ex As Exception
            appEventLog_Write("error RepRTBfield:", ex)
        End Try
    End Sub

    Private Sub frmInstructions_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            For i As Integer = 1 To 20
                pageDone(i) = False
            Next

            startPressed = False
            currentInstruction = 1
            nextInstruction()
            tempS = False

        Catch ex As Exception
            appEventLog_Write("error frmInstructions_Load:", ex)
        End Try
    End Sub

    Private Sub cmdStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdStart.Click
        Try
            startAction()
        Catch ex As Exception
            appEventLog_Write("error instructinos start:", ex)
        End Try
    End Sub

    Public Sub startAction()
        Try
            'client done with instructions
            Dim outstr As String = ""

            Dim ts As TimeSpan = Now - startTimeOnPage

            outstr = ts.TotalMilliseconds

            wskClient.Send("02", outstr)
            cmdStart.Visible = False
            startPressed = True
        Catch ex As Exception
            appEventLog_Write("error instructinos start:", ex)
        End Try
    End Sub

    Private Sub cmdNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNext.Click
        Try
            cmdNextAction()
        Catch ex As Exception
            appEventLog_Write("error cmdNext_Click:", ex)
        End Try
    End Sub

    Public Sub cmdNextAction()
        Try
            'load next page of instructions


            If pageDone(currentInstruction) = False Then
                MessageBox.Show("Please take the required action before continuing.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If

            If currentInstruction = 7 Then Exit Sub

            lastInstruction = currentInstruction
            lastTimeOnPage = Now - startTimeOnPage
            startTimeOnPage = Now

            currentInstruction += 1

            cmdBack.Visible = True

            If currentInstruction = 7 Then cmdNext.Visible = False

            If currentInstruction = 7 And Not tempS Then
                cmdStart.Visible = True
                tempS = True
            End If

            nextInstruction()
        Catch ex As Exception
            appEventLog_Write("error cmdNext_Click:", ex)
        End Try
    End Sub

    Private Sub cmdBack_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBack.Click
        Try
            'previous page of instructions

            cmdNext.Visible = True

            If currentInstruction = 1 Then
                Exit Sub
            End If

            lastInstruction = currentInstruction
            lastTimeOnPage = Now - startTimeOnPage
            startTimeOnPage = Now

            currentInstruction -= 1

            If currentInstruction = 1 Then cmdBack.Visible = False

            nextInstruction()
        Catch ex As Exception
            appEventLog_Write("error cmdBack_Click :", ex)
        End Try
    End Sub

    Private Sub cmdTrue_Click(sender As Object, e As EventArgs) Handles cmdTrue.Click
        Try
            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath &
                 "\instructions\page" & currentInstruction & ".rtf")

            If pageCorrectAnswers(currentInstruction - 1) = "true" Then
                pageDone(currentInstruction) = True
                cmdNext.Visible = True

                Call RepRTBfield("correct", pageCorrectText(currentInstruction - 1))

                pnlTF.Visible = False
            Else
                Call RepRTBfield("correct", errorText)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdFalse_Click(sender As Object, e As EventArgs) Handles cmdFalse.Click
        Try
            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath &
                "\instructions\page" & currentInstruction & ".rtf")

            If pageCorrectAnswers(currentInstruction - 1) = "false" Then
                pageDone(currentInstruction) = True
                cmdNext.Visible = True

                Call RepRTBfield("correct", pageCorrectText(currentInstruction - 1))

                pnlTF.Visible = False
            Else
                Call RepRTBfield("correct", errorText)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdSubmitQuiz_Click(sender As Object, e As EventArgs) Handles cmdSubmitQuiz.Click
        Try
            Dim correctAnswers = pageCorrectAnswers(currentInstruction - 1).Split(","c)

            If correctAnswers.Contains(txtQuizAnswer.Text.ToLower.Trim) Then
                pageDone(currentInstruction) = True
                cmdNext.Visible = True
                Call RepRTBfield("correct", pageCorrectText(currentInstruction - 1))
                pnlFITB.Visible = False
            Else
                Call RepRTBfield("correct", errorText)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class