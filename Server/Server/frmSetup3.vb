Public Class frmSetup3

    Public mainScreen As Screen
    'Public nodeList(100, 100) As node  'ID/Period
    'Public nodeCount(100) As Integer
    Public currentPeriod As Integer = 1

    Public currentNode As Integer = 1

    Dim p1 As Pen

    Private Sub cmdSave_Click(sender As System.Object, e As System.EventArgs) Handles cmdSave.Click
        Try
            For i As Integer = 1 To numberOfPeriods
                writeINI(sfile, "nodeCount", CStr(i), nodeCount(i))

                For j As Integer = 1 To nodeCount(i)
                    writeINI(sfile, "node" & i & "-" & j, "owner", nodeList(j, i).owner)
                    writeINI(sfile, "node" & i & "-" & j, "payoff11", nodeList(j, i).payoff11)
                    writeINI(sfile, "node" & i & "-" & j, "payoff12", nodeList(j, i).payoff12)
                    writeINI(sfile, "node" & i & "-" & j, "payoff21", nodeList(j, i).payoff21)
                    writeINI(sfile, "node" & i & "-" & j, "payoff22", nodeList(j, i).payoff22)
                    writeINI(sfile, "node" & i & "-" & j, "payoff31", nodeList(j, i).payoff31)
                    writeINI(sfile, "node" & i & "-" & j, "payoff32", nodeList(j, i).payoff32)

                    writeINI(sfile, "node" & i & "-" & j, "pt1", nodeList(j, i).pt1.ToString)
                    writeINI(sfile, "node" & i & "-" & j, "pt2", nodeList(j, i).pt2.ToString)
                    writeINI(sfile, "node" & i & "-" & j, "pt3", nodeList(j, i).pt3.ToString)
                    writeINI(sfile, "node" & i & "-" & j, "pt4", nodeList(j, i).pt4.ToString)

                    writeINI(sfile, "node" & i & "-" & j, "subNode1Id", nodeList(j, i).subNode1Id)
                    writeINI(sfile, "node" & i & "-" & j, "subNode2Id", nodeList(j, i).subNode2Id)
                    writeINI(sfile, "node" & i & "-" & j, "subNode3Id", nodeList(j, i).subNode3Id)

                    writeINI(sfile, "node" & i & "-" & j, "sortValue", nodeList(j, i).sortValue)
                    writeINI(sfile, "node" & i & "-" & j, "sortValue1", nodeList(j, i).sortValue1)
                    writeINI(sfile, "node" & i & "-" & j, "sortValue2", nodeList(j, i).sortValue2)
                    writeINI(sfile, "node" & i & "-" & j, "sortValue3", nodeList(j, i).sortValue3)

                Next
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick
        Try
            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSetup3_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try
            With frmMain
                mainScreen = New Screen(pnlMain, New Rectangle(0, 0, pnlMain.Width, pnlMain.Height))
                Timer1.Enabled = True

                .setupNodes(sfile)

                p1 = New Pen(Brushes.Violet, 3)

                If nodeCount(currentPeriod) > 0 Then
                    currentNode = 1
                    lblCurrentNode.Text = "Current Node: 1"
                Else
                    currentNode = 0
                    lblCurrentNode.Text = "Current Node: --"
                End If

                currentPeriod = 1
                lblPeriod.Text = "Period: " & currentPeriod
                cmdMinus.Visible = False
                If numberOfPeriods = 1 Then cmdPlus.Visible = False
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub


    Public Sub drawScreen()
        Try
            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            'draw highlight
            If currentNode <= nodeCount(currentPeriod) And currentNode <> 0 And cbGrid.Checked Then
                g.FillRectangle(Brushes.Yellow,
                                New Rectangle(nodeList(currentNode, currentPeriod).pt1.X - 50,
                                              nodeList(currentNode, currentPeriod).pt1.Y - 50,
                                              100,
                                              100))
            End If

            'draw grid
            'halfs
            If cbGrid.Checked Then
                For i As Integer = 1 To 3

                    'vertical
                    If currentNode > 0 Then
                        If nodeList(currentNode, currentPeriod).pt1.X = CInt(pnlMain.Width / 4 * i) Then
                            g.DrawLine(Pens.Violet, CInt(pnlMain.Width / 4 * i), 0, CInt(pnlMain.Width / 4 * i), pnlMain.Height)
                        Else
                            g.DrawLine(Pens.LightGray, CInt(pnlMain.Width / 4 * i), 0, CInt(pnlMain.Width / 4 * i), pnlMain.Height)
                        End If
                    Else
                        g.DrawLine(Pens.LightGray, CInt(pnlMain.Width / 4 * i), 0, CInt(pnlMain.Width / 4 * i), pnlMain.Height)
                    End If


                    'horizontal
                    If currentNode > 0 Then
                        If nodeList(currentNode, currentPeriod).pt1.Y = CInt(pnlMain.Height / 4 * i) Then
                            g.DrawLine(Pens.Violet, 0, CInt(pnlMain.Height / 4 * i), pnlMain.Width, CInt(pnlMain.Height / 4 * i))
                        Else
                            g.DrawLine(Pens.LightGray, 0, CInt(pnlMain.Height / 4 * i), pnlMain.Width, CInt(pnlMain.Height / 4 * i))
                        End If
                    Else
                        g.DrawLine(Pens.LightGray, 0, CInt(pnlMain.Height / 4 * i), pnlMain.Width, CInt(pnlMain.Height / 4 * i))
                    End If

                Next
            End If

            'draw nodes
            For i As Integer = 1 To nodeCount(currentPeriod)
                If nodeList(i, currentPeriod) IsNot Nothing Then
                    nodeList(i, currentPeriod).drawNode(g, False, cbGrid.Checked)
                End If
            Next

            'draw alignment lines
            If cbGrid.Checked Then
                For i As Integer = 1 To nodeCount(currentPeriod)

                    If i <> currentNode Then
                        If nodeList(i, currentPeriod).pt1.X = nodeList(currentNode, currentPeriod).pt1.X Or
                           nodeList(i, currentPeriod).pt1.Y = nodeList(currentNode, currentPeriod).pt1.Y Then

                            g.DrawLine(p1, nodeList(currentNode, currentPeriod).pt1, nodeList(i, currentPeriod).pt1)

                        End If
                    End If
                Next
            End If


            mainScreen.flip()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdAddNode_Click(sender As System.Object, e As System.EventArgs) Handles cmdAddNode.Click
        Try
            nodeCount(currentPeriod) += 1
            nodeList(nodeCount(currentPeriod), currentPeriod) = New node

            frmSetup3_1.Show()
            frmSetup3_1.currentPeriod = currentPeriod
            frmSetup3_1.currentNode = nodeCount(currentPeriod)

            currentNode = nodeCount(currentPeriod)

            lblCurrentNode.Text = "Current Node: " & currentNode

            nodeList(currentNode, currentPeriod).pt1 = New Point(100, 100)
            nodeList(currentNode, currentPeriod).pt2 = New Point(100, 200)
            nodeList(currentNode, currentPeriod).pt3 = New Point(200, 100)
            nodeList(currentNode, currentPeriod).pt4 = New Point(0, 200)

            nodeList(currentNode, currentPeriod).id = currentNode
            nodeList(currentNode, currentPeriod).myPeriod = currentPeriod
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Dim mouseIsDown = False
    Dim oldMouseX As Integer = 0
    Dim oldMouseY As Integer = 0

    Private Sub pnlMain_MouseDown(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseDown
        Try

            If nodeCount(currentPeriod) = 0 Then Exit Sub

            For i As Integer = 1 To nodeCount(currentPeriod)
                If nodeList(i, currentPeriod).isOver(e.X, e.Y) Then
                    currentNode = i
                    lblCurrentNode.Text = "Current Node: " & currentNode
                    Exit For
                End If
            Next

            mouseIsDown = True
            oldMouseX = e.X
            oldMouseY = e.Y

            pnlMain.Focus()

            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub pnlMain_MouseUp(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseUp
        Try
            mouseIsDown = False
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

  
    Private Sub pnlMain_MouseMove(sender As System.Object, e As System.Windows.Forms.MouseEventArgs) Handles pnlMain.MouseMove
        Try
            If mouseIsDown And currentNode <= nodeCount(currentPeriod) Then

                Dim tempDifX As Integer = oldMouseX - e.X
                Dim tempDifY As Integer = oldMouseY - e.Y

                nodeList(currentNode, currentPeriod).pt1.X -= tempDifX
                nodeList(currentNode, currentPeriod).pt2.X -= tempDifX
                nodeList(currentNode, currentPeriod).pt3.X -= tempDifX
                nodeList(currentNode, currentPeriod).pt4.X -= tempDifX

                nodeList(currentNode, currentPeriod).pt1.Y -= tempDifY
                nodeList(currentNode, currentPeriod).pt2.Y -= tempDifY
                nodeList(currentNode, currentPeriod).pt3.Y -= tempDifY
                nodeList(currentNode, currentPeriod).pt4.Y -= tempDifY

                oldMouseX = e.X
                oldMouseY = e.Y
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub nudCurrentNode_ValueChanged(sender As System.Object, e As System.EventArgs)
        Try

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdEditNode_Click(sender As System.Object, e As System.EventArgs) Handles cmdEditNode.Click
        Try
            frmSetup3_1.Show()
            frmSetup3_1.currentPeriod = currentPeriod
            frmSetup3_1.currentNode = currentNode

            frmSetup3_1.txtTop1.Text = nodeList(currentNode, currentPeriod).payoff11
            frmSetup3_1.txtBottom1.Text = nodeList(currentNode, currentPeriod).payoff12

            frmSetup3_1.txtTop2.Text = nodeList(currentNode, currentPeriod).payoff21
            frmSetup3_1.txtBottom2.Text = nodeList(currentNode, currentPeriod).payoff22

            frmSetup3_1.txtTop3.Text = nodeList(currentNode, currentPeriod).payoff31
            frmSetup3_1.txtBottom3.Text = nodeList(currentNode, currentPeriod).payoff32

            frmSetup3_1.nudOwner.Value = nodeList(currentNode, currentPeriod).owner

            frmSetup3_1.txtSubNode1.Text = nodeList(currentNode, currentPeriod).subNode1Id
            frmSetup3_1.txtSubNode2.Text = nodeList(currentNode, currentPeriod).subNode2Id
            frmSetup3_1.txtSubNode3.Text = nodeList(currentNode, currentPeriod).subNode3Id

            frmSetup3_1.txtSortValue.Text = nodeList(currentNode, currentPeriod).sortValue
            frmSetup3_1.txtSortValue1.Text = nodeList(currentNode, currentPeriod).sortValue1
            frmSetup3_1.txtSortValue2.Text = nodeList(currentNode, currentPeriod).sortValue2
            frmSetup3_1.txtSortValue3.Text = nodeList(currentNode, currentPeriod).sortValue3


        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdConnectNode_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyNext.Click
        Try
            frmSetup3_2.Show()

            For i As Integer = 1 To nodeCount(currentPeriod)
                frmSetup3_2.cboSource.Items.Add("Node " & i)
                frmSetup3_2.cboTarget.Items.Add("Node " & i)
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdDeleteNode_Click(sender As System.Object, e As System.EventArgs) Handles cmdDeleteNode.Click
        Try
            If MessageBox.Show("Delect Selected Node?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
               Windows.Forms.DialogResult.No Then Exit Sub

            For i As Integer = currentNode To nodeCount(currentPeriod) - 1
                nodeList(i, currentPeriod) = nodeList(i + 1, currentPeriod)

                nodeList(i, currentPeriod).id = i

                If nodeList(i, currentPeriod).subNode1Id > 0 Then nodeList(i, currentPeriod).subNode1Id -= 1
                If nodeList(i, currentPeriod).subNode2Id > 0 Then nodeList(i, currentPeriod).subNode2Id -= 1
            Next

            nodeCount(currentPeriod) -= 1
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyPrevious_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyPrevious.Click
        Try

            'If currentPeriod = 1 Then Exit Sub

            Dim originalTree = InputBox("Which period do you want to copy?", "Copy Period")

            If Not validateInt(originalTree, 2, False, False) Then Exit Sub

            If originalTree > numberOfPeriods Then Exit Sub

            For i As Integer = 1 To nodeCount(originalTree)
                nodeList(i, currentPeriod) = New node

                nodeList(i, currentPeriod).fromString(nodeList(i, originalTree).toString)

                nodeList(i, currentPeriod).myPeriod = currentPeriod
            Next

            nodeCount(currentPeriod) = nodeCount(originalTree)

            currentNode = 1
            lblCurrentNode.Text = "Current Node: " & currentNode
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdClear_Click(sender As System.Object, e As System.EventArgs) Handles cmdClear.Click
        Try
            If MessageBox.Show("Delect ALL Nodes?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) =
               Windows.Forms.DialogResult.No Then Exit Sub

            nodeCount(currentPeriod) = 0
            currentNode = 0
            lblCurrentNode.Text = "Current Node: --"
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSetup3_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
        Try

            If nodeCount(currentPeriod) = 0 Then Exit Sub
            If currentNode = 0 Then Exit Sub

            If e.KeyCode = Keys.D Then
                nodeList(currentNode, currentPeriod).nudge(1, 0)
            ElseIf e.KeyCode = Keys.A Then
                nodeList(currentNode, currentPeriod).nudge(-1, 0)
            ElseIf e.KeyCode = Keys.W Then
                nodeList(currentNode, currentPeriod).nudge(0, -1)
            ElseIf e.KeyCode = Keys.S Then
                nodeList(currentNode, currentPeriod).nudge(0, 1)
            End If

            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPlus_Click(sender As Object, e As EventArgs) Handles cmdPlus.Click
        Try
            currentPeriod += 1

            If currentPeriod = numberOfPeriods Then
                cmdPlus.Visible = False
            End If

            cmdMinus.Visible = True

            lblPeriod.Text = "Period: " & currentPeriod
            currentNode = 1
            lblCurrentNode.Text = "Current Node: " & currentNode

            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdMinus_Click(sender As Object, e As EventArgs) Handles cmdMinus.Click
        Try
            currentPeriod -= 1

            If currentPeriod = 1 Then
                cmdMinus.Visible = False
            End If

            cmdPlus.Visible = True

            lblPeriod.Text = "Period: " & currentPeriod
            currentNode = 1
            lblCurrentNode.Text = "Current Node: " & currentNode

            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class