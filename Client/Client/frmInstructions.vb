Public Class frmInstructions
    Dim tempS As Boolean
    Dim startPressed As Boolean

    Public pageDone(20) As Boolean
    Public results(20) As String

    Dim page5Text As String = "Person 1 earns #payoff1#." & vbCrLf & "Person 2 earns #payoff2#."
    Dim page6Text As String = "Person #person# now makes the next decision.  He or she will choose a set of payoffs."
    Dim page7Text As String = "Person #person# now makes the next decision to choose the payoffs (#payoff11#/#payoff12#) or (#payoff21#/#payoff22#)"
    Dim continueText As String = vbCrLf & vbCrLf & "Continue to the next page of instructions."

    Public startTimeOnPage As Date
    Public lastInstruction As Integer
    Public lastTimeOnPage As TimeSpan

    Public Sub nextInstruction()
        Try
            'load the next page of instructions

            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath & _
                 "\instructions\page" & currentInstruction & ".rtf")

            variables()

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()

            If Not startPressed Then wskClient.Send("01", currentInstruction & ";" & lastInstruction & ";" & lastTimeOnPage.TotalMilliseconds)

            If currentInstruction = 5 Or currentInstruction = 6 Or currentInstruction = 7 Then
                cmdReset.Visible = True
            Else
                cmdReset.Visible = False
            End If
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

                    pageDone(currentInstruction) = True
                Case 3

                    pageDone(currentInstruction) = True
                Case 4

                    pageDone(currentInstruction) = True
                Case 5

                    If Not pageDone(currentInstruction) Then
                        Call RepRTBfield("Result", " ")
                        Call RepRTBfield("Continue", " ")
                        Call RepRTBfield("done", " ")
                        frmMain.cmdSubmit.Visible = True
                        currentPeriodInstruction = 1
                        frmMain.pnlMain.Enabled = True
                        currentNode = 1
                        selection = ""
                    Else
                        Call RepRTBfield("Result", page5Text)
                        Call RepRTBfield("Continue", continueText)
                        Call RepRTBfield("done", "(done)")

                        RichTextBox1.Find("Person 1")
                        RichTextBox1.SelectionColor = Color.CornflowerBlue

                        RichTextBox1.Find("Person 2")
                        RichTextBox1.SelectionColor = Color.Coral

                        RichTextBox1.Find("#payoff1#")
                        RichTextBox1.SelectionColor = Color.CornflowerBlue

                        RichTextBox1.Find("#payoff2#")
                        RichTextBox1.SelectionColor = Color.Coral

                        If results(currentInstruction) = "pay1" Then
                            Call RepRTBfield("payoff1", returnInsructionPayoff(nodeListInstructions(1, 1).payoff11))
                            Call RepRTBfield("payoff2", returnInsructionPayoff(nodeListInstructions(1, 1).payoff12))
                        Else
                            Call RepRTBfield("payoff1", returnInsructionPayoff(nodeListInstructions(1, 1).payoff21))
                            Call RepRTBfield("payoff2", returnInsructionPayoff(nodeListInstructions(1, 1).payoff22))
                        End If
                    End If
                Case 6
                    If myType = 1 Then
                        Call RepRTBfield("circleColor", "Orange")
                        RichTextBox1.Find("Orange")
                        RichTextBox1.SelectionColor = Color.Coral
                    Else
                        Call RepRTBfield("circleColor", "Blue")
                        RichTextBox1.Find("Blue")
                        RichTextBox1.SelectionColor = Color.CornflowerBlue
                    End If

                    If Not pageDone(currentInstruction) Then
                        Call RepRTBfield("Result", " ")
                        Call RepRTBfield("Continue", " ")
                        Call RepRTBfield("done", " ")

                        frmMain.cmdSubmit.Visible = True
                        currentPeriodInstruction = 2
                        frmMain.pnlMain.Enabled = True
                        currentNode = 1
                        selection = ""
                    Else
                        Call RepRTBfield("Result", page6Text)
                        Call RepRTBfield("Continue", continueText)
                        Call RepRTBfield("done", "(done)")

                        If myType = 1 Then
                            Call RepRTBfield("person", "2")

                            RichTextBox1.Find("Person 2")
                            RichTextBox1.SelectionColor = Color.Coral
                        Else
                            Call RepRTBfield("person", "1")

                            RichTextBox1.Find("Person 1")
                            RichTextBox1.SelectionColor = Color.CornflowerBlue
                        End If
                    End If
                Case 7
                    If Not pageDone(currentInstruction) Then
                        Call RepRTBfield("Result", " ")
                        Call RepRTBfield("Continue", " ")
                        Call RepRTBfield("done", " ")

                        frmMain.cmdSubmit.Visible = True
                        currentPeriodInstruction = 3
                        frmMain.pnlMain.Enabled = True
                        currentNode = 1
                        selection = ""
                    Else
                        Call RepRTBfield("Result", page7Text)
                        Call RepRTBfield("Continue", continueText)
                        Call RepRTBfield("done", "(done)")

                        RichTextBox1.Find("#payoff11#")
                        RichTextBox1.SelectionColor = Color.CornflowerBlue

                        RichTextBox1.Find("#payoff12#")
                        RichTextBox1.SelectionColor = Color.Coral

                        RichTextBox1.Find("#payoff21#")
                        RichTextBox1.SelectionColor = Color.CornflowerBlue

                        RichTextBox1.Find("#payoff22#")
                        RichTextBox1.SelectionColor = Color.Coral

                        If results(currentInstruction) = "sub2" Then
                            Call RepRTBfield("payoff11", returnInsructionPayoff(nodeListInstructions(2, 3).payoff11))
                            Call RepRTBfield("payoff12", returnInsructionPayoff(nodeListInstructions(2, 3).payoff12))

                            Call RepRTBfield("payoff21", returnInsructionPayoff(nodeListInstructions(2, 3).payoff21))
                            Call RepRTBfield("payoff22", returnInsructionPayoff(nodeListInstructions(2, 3).payoff22))

                            Call RepRTBfield("person", myType)
                            RichTextBox1.Find("Person " & myType)

                            If myType = 1 Then
                                RichTextBox1.SelectionColor = Color.CornflowerBlue
                            Else
                                RichTextBox1.SelectionColor = Color.Coral
                            End If

                        Else
                            Call RepRTBfield("payoff11", returnInsructionPayoff(nodeListInstructions(3, 3).payoff11))
                            Call RepRTBfield("payoff12", returnInsructionPayoff(nodeListInstructions(3, 3).payoff12))

                            Call RepRTBfield("payoff21", returnInsructionPayoff(nodeListInstructions(3, 3).payoff21))
                            Call RepRTBfield("payoff22", returnInsructionPayoff(nodeListInstructions(3, 3).payoff22))

                            'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff11))
                            'RichTextBox1.SelectionColor = Color.CornflowerBlue

                            'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff21))
                            'RichTextBox1.SelectionColor = Color.CornflowerBlue

                            'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff12))
                            'RichTextBox1.SelectionColor = Color.Coral

                            'RichTextBox1.Find(returnInsructionPayoff(nodeListInstructions(3, 3).payoff22))
                            'RichTextBox1.SelectionColor = Color.Coral

                            If myType = 1 Then
                                Call RepRTBfield("person", "2")
                                RichTextBox1.Find("Person 2")
                                RichTextBox1.SelectionColor = Color.Coral
                            Else
                                Call RepRTBfield("person", "1")
                                RichTextBox1.Find("Person 1")
                                RichTextBox1.SelectionColor = Color.CornflowerBlue
                            End If
                        End If
                    End If
                Case 8
                    pageDone(currentInstruction) = True
                    Call RepRTBfield("iPage8Text", iPage8Text)
            End Select

            Me.Text = "Instructions " & currentInstruction & "/8"
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

            If currentInstruction = 8 Then Exit Sub

            lastInstruction = currentInstruction
            lastTimeOnPage = Now - startTimeOnPage
            startTimeOnPage = Now

            currentInstruction += 1

            cmdBack.Visible = True

            If currentInstruction = 8 Then cmdNext.Visible = False

            If currentInstruction = 8 And Not tempS Then
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

    Private Sub cmdReset_Click(sender As System.Object, e As System.EventArgs) Handles cmdReset.Click
        Try
            pageDone(currentInstruction) = False
            selection = ""
            results(currentInstruction) = ""

            nodeListInstructions(1, currentInstruction - 4).status = "open"
            currentNode = 1

            RichTextBox1.LoadFile(System.Windows.Forms.Application.StartupPath & _
                 "\instructions\page" & currentInstruction & ".rtf")

            variables()

            RichTextBox1.SelectionStart = 1
            RichTextBox1.ScrollToCaret()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class