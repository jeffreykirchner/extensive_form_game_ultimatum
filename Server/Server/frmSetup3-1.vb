Public Class frmSetup3_1
    Public currentNode As Integer
    Public currentPeriod As Integer

    Private Sub cmdDone_Click(sender As System.Object, e As System.EventArgs) Handles cmdDone.Click
        Try
            With frmSetup3

                nodeList(currentNode, currentPeriod).payoff11 = txtTop1.Text
                nodeList(currentNode, currentPeriod).payoff12 = txtBottom1.Text

                nodeList(currentNode, currentPeriod).payoff21 = txtTop2.Text
                nodeList(currentNode, currentPeriod).payoff22 = txtBottom2.Text

                nodeList(currentNode, currentPeriod).payoff31 = txtTop3.Text
                nodeList(currentNode, currentPeriod).payoff32 = txtBottom3.Text

                nodeList(currentNode, currentPeriod).owner = nudOwner.Value
                nodeList(currentNode, currentPeriod).id = currentNode


                nodeList(currentNode, currentPeriod).pt3 =
                    New Point(nodeList(currentNode, currentPeriod).pt1.X + 100, nodeList(currentNode, currentPeriod).pt1.Y)

                nodeList(currentNode, currentPeriod).subNode1Id = txtSubNode1.Text


                nodeList(currentNode, currentPeriod).pt2 =
                    New Point(nodeList(currentNode, currentPeriod).pt1.X, nodeList(currentNode, currentPeriod).pt1.Y + 100)

                nodeList(currentNode, currentPeriod).subNode2Id = txtSubNode2.Text

                nodeList(currentNode, currentPeriod).pt4 =
                    New Point(nodeList(currentNode, currentPeriod).pt1.X - 100, nodeList(currentNode, currentPeriod).pt1.Y)

                nodeList(currentNode, currentPeriod).subNode3Id = txtSubNode3.Text

                nodeList(currentNode, currentPeriod).sortValue = txtSortValue.Text
                nodeList(currentNode, currentPeriod).sortValue1 = txtSortValue1.Text
                nodeList(currentNode, currentPeriod).sortValue2 = txtSortValue2.Text
                nodeList(currentNode, currentPeriod).sortValue3 = txtSortValue3.Text

            End With


            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmSetup3_1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Try

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

   
End Class