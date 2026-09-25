Public Class node
    Public id As Integer
    Public myPeriod As Integer

    Public myNodeList(100, 100) As node

    Public subNode1Id As Integer
    Public subNode2Id As Integer
    Public subNode3Id As Integer

    Public payoff11 As Double
    Public payoff12 As Double
    Public payoff21 As Double
    Public payoff22 As Double
    Public payoff31 As Double
    Public payoff32 As Double

    Public payoffLabel1 As String
    Public payoffLabel2 As String
    Public payoffLabel3 As String

    Public subNodeLabel1 As String
    Public subNodeLabel2 As String
    Public subNodeLabel3 As String

    Public owner As Integer
    Public pt1 As Point
    Public pt2 As Point
    Public pt3 As Point
    Public pt4 As Point

    Public status As String

    Dim f1 As New Font("Calibri", 40, FontStyle.Bold)
    Dim f2 As New Font("Calibri", 16, FontStyle.Bold)
    Dim f3 As New Font("Calibri", 10, FontStyle.Bold)
    Dim f14 As New Font("Calibri", 14, FontStyle.Bold)

    Dim p1 As New Pen(Brushes.Black, 8)
    Dim p2 As New Pen(Brushes.CornflowerBlue, 8)
    Dim p3 As New Pen(Brushes.Coral, 8)
    Dim p4 As New Pen(Brushes.Black, 8)
    Dim p5 As New Pen(Brushes.LightGray, 8)

    Dim fmt As New StringFormat 'center alignment
    Dim fmt2 As New StringFormat 'left alignment
    Public myColor As Color

    Public Sub New(ByRef myNodeList(,) As node)
        Try
            fmt.Alignment = StringAlignment.Center
            p1.EndCap = Drawing2D.LineCap.ArrowAnchor
            p1.Alignment = Drawing2D.PenAlignment.Center

            p2.EndCap = Drawing2D.LineCap.ArrowAnchor
            p2.Alignment = Drawing2D.PenAlignment.Center

            p3.EndCap = Drawing2D.LineCap.ArrowAnchor
            p3.Alignment = Drawing2D.PenAlignment.Center

            p4.Alignment = Drawing2D.PenAlignment.Center
            p4.EndCap = Drawing2D.LineCap.Triangle

            p5.Alignment = Drawing2D.PenAlignment.Center
            p5.EndCap = Drawing2D.LineCap.ArrowAnchor

            Me.myNodeList = myNodeList
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Dim tempP As Pen
    Public Sub drawNode(g As Graphics)
        Try

            If payoff11 >= 0 And payoff12 >= 0 Then
                drawPayoff(pt3, g, payoff11, payoff12, payoffLabel1)
            End If

            If payoff21 >= 0 And payoff22 >= 0 Then
                drawPayoff(pt2, g, payoff21, payoff22, payoffLabel2)
            End If

            If payoff31 >= 0 And payoff32 >= 0 Then
                drawPayoff(pt4, g, payoff31, payoff32, payoffLabel3)
            End If

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            If owner = 1 Then
                g.FillEllipse(Brushes.CornflowerBlue, New Rectangle(pt1.X - 25, pt1.Y - 25, 50, 50))
            Else
                g.FillEllipse(Brushes.Coral, New Rectangle(pt1.X - 25, pt1.Y - 25, 50, 50))
            End If

            g.DrawEllipse(Pens.Black, New Rectangle(pt1.X - 25, pt1.Y - 25, 50, 50))

            g.SmoothingMode = Drawing2D.SmoothingMode.None

            g.DrawString(owner, f2, Brushes.Black, pt1.X - g.MeasureString(owner, f2).Width / 2, pt1.Y - 15)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawConnection(startPt As Point, endPt As Point, g As Graphics, tempP As Pen)
        Try

            Dim d As Double = Math.Sqrt((endPt.X - startPt.X) ^ 2 + (endPt.Y - startPt.Y) ^ 2)
            Dim r As Double = 28 / d

            Dim x3 As Integer = Math.Round(r * startPt.X + (1 - r) * endPt.X)
            Dim y3 As Integer = Math.Round(r * startPt.Y + (1 - r) * endPt.Y)

            g.DrawLine(tempP, startPt.X, startPt.Y, x3, y3)
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub drawBranchLabel(g As Graphics, branchLabel As String, startPt As Point, endPt As Point)
        Try
            If branchLabel = "" Then Exit Sub

            Dim labelPt As New Point(endPt.X, CInt((startPt.Y + endPt.Y) / 2))

            If endPt.X > startPt.X Then
                g.DrawString(branchLabel, f14, Brushes.DimGray, labelPt.X, labelPt.Y - 16, fmt)
            Else
                g.DrawString(branchLabel, f14, Brushes.DimGray, labelPt.X, labelPt.Y - 16, fmt)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub drawPayoff(startPt As Point, g As Graphics, payOffTop As String, payOffBottom As String, payOffLabel As String)
        Try
            If showInstructions Then
                payOffTop = returnInsructionPayoff(payOffTop)
                payOffBottom = returnInsructionPayoff(payOffBottom)
            ElseIf decimalFormat Then
                payOffTop = Format(CDbl(payOffTop), "0.00")
                payOffBottom = Format(CDbl(payOffBottom), "0.00")
            End If

            g.DrawString(getPayoffParenthesis(payOffTop, payOffBottom), f1, Brushes.Black, startPt.X, startPt.Y - g.MeasureString("(  )", f1).Height / 2, fmt)

            If payoffMode = "dollars" Then
                payOffTop = "$" & payOffTop
                payOffBottom = "$" & payOffBottom
            ElseIf payoffMode = "cents" Then
                payOffTop = payOffTop & "¢"
                payOffBottom = payOffBottom & "¢"
            Else
                payOffTop = "£" & payOffTop
                payOffBottom = "£" & payOffBottom
            End If

            g.DrawString(payOffTop, f2, Brushes.CornflowerBlue, startPt.X, startPt.Y - 22, fmt)
            g.DrawString(payOffBottom, f2, Brushes.Coral, startPt.X, startPt.Y - 2, fmt)

            'draw the label if it exists below the payoffs
            If payOffLabel <> "" Then
                g.DrawString(payOffLabel, f14, Brushes.DimGray, startPt.X, startPt.Y + 22, fmt)
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Function getPayoffParenthesis(payOffTop As String, payOffBottom As String) As String
        Try
            Dim tempN2 As Integer = Len(payOffTop)
            Dim tempN3 As Integer = Len(payOffBottom)

            If InStr(payOffTop, ".") > 0 Then
                tempN2 -= 1
            End If

            If InStr(payOffBottom, ".") > 0 Then
                tempN3 -= 1
            End If

            Dim tempN1 As Integer = Math.Max(tempN2, tempN3)

            Dim temps As String = "("

            For i As Integer = 1 To tempN1 + 1 'for $,cents sign
                temps &= " "
            Next

            temps &= ")"

            Return temps

        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Private Function getDisplayedPayoff(payoff As Double) As String
        If decimalFormat Then
            Return Format(payoff, "0.00")
        End If

        Return payoff.ToString()
    End Function

    Public Sub drawNodeArrows(g As Graphics)
        Try

            g.SmoothingMode = Drawing2D.SmoothingMode.AntiAlias

            If currentNode = id And status = "open" Then
                If myColor = Color.CornflowerBlue Then
                    tempP = p2
                Else
                    tempP = p3
                End If

                'colored choice arrow
                'ElseIf status = "down" Or status = "right" Then
                '    tempP = p4
                '    'chosen path arrow
                'ElseIf status = "dead" Then
                '    tempP = p5
                '    'gray arrow
            ElseIf status = "open" Then
                tempP = p1
                'standard black
            Else
                tempP = p5
            End If

            Dim tempNodeCount As Integer

            If showInstructions Then
                tempNodeCount = nodeCountInstructions(currentPeriodInstruction)
            Else
                tempNodeCount = nodeCount(currentPeriod)
            End If

            'draw sub node arrows
            If tickTock = 4 Or currentNode <> id Then
                If subNode1Id > 0 Then
                    If tempNodeCount >= subNode1Id Then

                        If status = "sub1" Then
                            drawConnection(pt1, myNodeList(subNode1Id, myPeriod).pt1, g, p4)
                        Else
                            drawConnection(pt1, myNodeList(subNode1Id, myPeriod).pt1, g, tempP)
                        End If
                    End If
                End If
            End If

            'allways draw the label for subnode 1, even if it is not the current node
            If subNode1Id > 0 Then
                If tempNodeCount >= subNode1Id Then
                    drawBranchLabel(g, subNodeLabel1, pt1, myNodeList(subNode1Id, myPeriod).pt1)
                End If
            End If

            If tickTock = 5 Or currentNode <> id Then
                If subNode2Id > 0 Then
                    If tempNodeCount >= subNode2Id Then

                        If status = "sub2" Then
                            drawConnection(pt1, myNodeList(subNode2Id, myPeriod).pt1, g, p4)
                        Else
                            drawConnection(pt1, myNodeList(subNode2Id, myPeriod).pt1, g, tempP)
                        End If

                        drawBranchLabel(g, subNodeLabel2, pt1, myNodeList(subNode2Id, myPeriod).pt1)

                    End If
                End If
            End If

            'allways draw the label for subnode 2, even if it is not the current node
            If subNode2Id > 0 Then
                If tempNodeCount >= subNode2Id Then
                    drawBranchLabel(g, subNodeLabel2, pt1, myNodeList(subNode2Id, myPeriod).pt1)
                End If
            End If


            If tickTock = 6 Or currentNode <> id Then
                If subNode3Id > 0 Then
                    If tempNodeCount >= subNode3Id Then

                        If status = "sub3" Then
                            drawConnection(pt1, myNodeList(subNode3Id, myPeriod).pt1, g, p4)
                        Else
                            drawConnection(pt1, myNodeList(subNode3Id, myPeriod).pt1, g, tempP)
                        End If

                        drawBranchLabel(g, subNodeLabel3, pt1, myNodeList(subNode3Id, myPeriod).pt1)

                    End If
                End If
            End If

            'allways draw the label for subnode 3, even if it is not the current node
            If subNode3Id > 0 Then
                If tempNodeCount >= subNode3Id Then
                    drawBranchLabel(g, subNodeLabel3, pt1, myNodeList(subNode3Id, myPeriod).pt1)
                End If
            End If

            'draw payoff arrows
            If tickTock = 1 Or currentNode <> id Then
                If payoff11 >= 0 And payoff12 >= 0 Then

                    'Dim tempD As Double = g.MeasureString(getPayoffParenthesis(getDisplayedPayoff(payoff11), getDisplayedPayoff(payoff12)), f1).Width

                    If status = "pay1" Then
                        g.DrawLine(p4, pt1.X, pt1.Y, pt3.X, pt2.Y - 25)
                    Else

                        g.DrawLine(tempP, pt1.X, pt1.Y, pt3.X, pt2.Y - 25)
                    End If

                    'drawBranchLabel(g, payoffLabel1, pt1, New Point(pt3.X, pt2.Y - 25))

                End If
            End If

            If tickTock = 2 Or currentNode <> id Then
                If payoff21 >= 0 And payoff22 >= 0 Then

                    If status = "pay2" Then
                        g.DrawLine(p4, pt1.X, pt1.Y, pt2.X, pt2.Y - 25)
                    Else
                        g.DrawLine(tempP, pt1.X, pt1.Y, pt2.X, pt2.Y - 25)
                    End If

                    ' drawBranchLabel(g, payoffLabel2, pt1, New Point(pt2.X, pt2.Y - 25))

                End If
            End If

            If tickTock = 3 Or currentNode <> id Then
                If payoff31 >= 0 And payoff32 >= 0 Then

                    'Dim tempD As Double = g.MeasureString(getPayoffParenthesis(getDisplayedPayoff(payoff31), getDisplayedPayoff(payoff32)), f1).Width

                    If status = "pay3" Then
                        g.DrawLine(p4, pt1.X, pt1.Y, pt4.X, pt4.Y - 25)
                    Else
                        g.DrawLine(tempP, pt1.X, pt1.Y, pt4.X, pt4.Y - 25)
                    End If

                    ' drawBranchLabel(g, payoffLabel3, pt1, New Point(pt4.X, pt4.Y - 25))

                End If
            End If

            g.SmoothingMode = Drawing2D.SmoothingMode.None

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function isOverPT(x As Integer, y As Integer, pt As Point) As Boolean
        If x >= pt.X - 25 And x <= pt.X + 25 And y >= pt.Y - 25 And y <= pt.Y + 25 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
