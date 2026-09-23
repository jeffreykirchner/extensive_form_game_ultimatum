Imports System.Drawing.Drawing2D

Public Class player
    Public inumber As Integer            'ID number
    Public sname As String               'name of person
    Public studentID As String           'student ID number
    Public socketNumber As String        'winsock ID number
    Public relativeNumber As Integer     'either buyer or seller number
    Public earnings As Double            'experimental earnings
    Public ipAddress As String           'IP address of player's machine 
    Public myIPAddress As String         'IP address of player's machine 
    Public roundEarnings As Integer      'earnings for a induvidual round/period
    Public exchangeRate As Integer       'conversion rate from experimental dollars to $
    Public colorName As String           'colorName of player

    Public nodeList(100, 100) As node  'ID/Period
    Public partnerList(100) As Integer
    Public myType As Integer
    Public currentNode As Integer
    Public finalNode As Integer

    Public periodEarnings As Double
    Public instructionLength(100) As Double

    Public downCount(100) As Integer

    Public dataSortScore As Integer
    Public dataDuration As Integer

    Public lastIDSent As String
    Public lastMessageSent As String


    Public Sub player()

    End Sub

    Public Sub begin()
        Try
            With frmServer

                If inumber <= numberOfPlayers / 2 Then
                    myType = 1
                Else
                    myType = 2
                End If

                For i As Integer = 1 To instructionCount
                    instructionLength(i) = 0
                Next

                For i As Integer = 1 To 100
                    downCount(i) = 0
                Next

                'singal to clients to start the experiment

                .DataGridView1.Rows(inumber - 1).Cells(4).Value = partnerList(1)

                currentNode = 1

                'winsock can send character strings to the clients
                Dim outstr As String = ""

                'create parseable string to send to clients by putting ";" between each value
                outstr = numberOfPeriods & ";"
                outstr &= numberOfPlayers & ";"
                outstr &= showInstructions & ";"

                outstr &= instructionX & ";"
                outstr &= instructionY & ";"
                outstr &= windowX & ";"
                outstr &= windowY & ";"

                outstr &= surveyLink & ";"

                outstr &= myType & ";"
                outstr &= payoffMode & ";"
                outstr &= testMode & ";"

                outstr &= iPage8Text & ";"

                For i As Integer = 1 To numberOfPeriods
                    outstr &= nodeCount(i) & ";"

                    For j As Integer = 1 To nodeCount(i)

                        outstr &= nodeList(j, i).id & ";"
                        outstr &= nodeList(j, i).myPeriod & ";"

                        outstr &= nodeList(j, i).status & ";"

                        outstr &= nodeList(j, i).owner & ";"
                        outstr &= nodeList(j, i).payoff11 & ";"
                        outstr &= nodeList(j, i).payoff12 & ";"
                        outstr &= nodeList(j, i).payoff21 & ";"
                        outstr &= nodeList(j, i).payoff22 & ";"
                        outstr &= nodeList(j, i).payoff31 & ";"
                        outstr &= nodeList(j, i).payoff32 & ";"

                        outstr &= nodeList(j, i).pt1.ToString & ";"
                        outstr &= nodeList(j, i).pt2.ToString & ";"
                        outstr &= nodeList(j, i).pt3.ToString & ";"
                        outstr &= nodeList(j, i).pt4.ToString & ";"

                        outstr &= nodeList(j, i).subNode1Id & ";"
                        outstr &= nodeList(j, i).subNode2Id & ";"
                        outstr &= nodeList(j, i).subNode3Id & ";"
                    Next
                Next

                For i As Integer = 1 To 3
                    outstr &= nodeCountInstructions(i) & ";"

                    For j As Integer = 1 To nodeCountInstructions(i)

                        outstr &= nodeListInstructions(j, i).id & ";"
                        outstr &= nodeListInstructions(j, i).myPeriod & ";"

                        outstr &= nodeListInstructions(j, i).status & ";"

                        outstr &= nodeListInstructions(j, i).owner & ";"
                        outstr &= nodeListInstructions(j, i).payoff11 & ";"
                        outstr &= nodeListInstructions(j, i).payoff12 & ";"
                        outstr &= nodeListInstructions(j, i).payoff21 & ";"
                        outstr &= nodeListInstructions(j, i).payoff22 & ";"
                        outstr &= nodeListInstructions(j, i).payoff31 & ";"
                        outstr &= nodeListInstructions(j, i).payoff32 & ";"

                        outstr &= nodeListInstructions(j, i).pt1.ToString & ";"
                        outstr &= nodeListInstructions(j, i).pt2.ToString & ";"
                        outstr &= nodeListInstructions(j, i).pt3.ToString & ";"
                        outstr &= nodeListInstructions(j, i).pt4.ToString & ";"

                        outstr &= nodeListInstructions(j, i).subNode1Id & ";"
                        outstr &= nodeListInstructions(j, i).subNode2Id & ";"
                        outstr &= nodeListInstructions(j, i).subNode3Id & ";"
                    Next
                Next

                'call the send command (message ID found in takeMessage function,winsock ID,data) 
                sendMessageToClient("02", outstr)
            End With

        Catch ex As Exception
            appEventLog_Write("error player begin:", ex)
        End Try
    End Sub

    Public Sub sendMessageToClient(messageId As String, messageString As String)
        With frmServer
            lastMessageSent = messageString
            lastIDSent = messageId

            .wsk_Col.Send(messageId, socketNumber, messageString)
        End With
    End Sub

    Public Sub resendLastMessage()
        Try
            With frmServer
                sendMessageToClient(lastIDSent, lastMessageSent)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function setupNodes() As Boolean
        Try
            For i As Integer = 1 To numberOfPeriods
                nodeCount(i) = getINI(sfile, "nodeCount", CStr(i))

                For j As Integer = 1 To nodeCount(i)
                    nodeList(j, i) = New node

                    nodeList(j, i).id = j
                    nodeList(j, i).myPeriod = i

                    nodeList(j, i).status = "open"

                    nodeList(j, i).owner = getINI(sfile, "node" & i & "-" & j, "owner")
                    nodeList(j, i).payoff11 = getINI(sfile, "node" & i & "-" & j, "payoff11")
                    nodeList(j, i).payoff12 = getINI(sfile, "node" & i & "-" & j, "payoff12")
                    nodeList(j, i).payoff21 = getINI(sfile, "node" & i & "-" & j, "payoff21")
                    nodeList(j, i).payoff22 = getINI(sfile, "node" & i & "-" & j, "payoff22")
                    nodeList(j, i).payoff31 = getINI(sfile, "node" & i & "-" & j, "payoff31")
                    nodeList(j, i).payoff32 = getINI(sfile, "node" & i & "-" & j, "payoff32")

                    nodeList(j, i).pt1 = pointFromString(getINI(sfile, "node" & i & "-" & j, "pt1"))
                    nodeList(j, i).pt2 = pointFromString(getINI(sfile, "node" & i & "-" & j, "pt2"))
                    nodeList(j, i).pt3 = pointFromString(getINI(sfile, "node" & i & "-" & j, "pt3"))
                    nodeList(j, i).pt4 = pointFromString(getINI(sfile, "node" & i & "-" & j, "pt4"))

                    nodeList(j, i).subNode1Id = getINI(sfile, "node" & i & "-" & j, "subNode1Id")
                    nodeList(j, i).subNode2Id = getINI(sfile, "node" & i & "-" & j, "subNode2Id")
                    nodeList(j, i).subNode3Id = getINI(sfile, "node" & i & "-" & j, "subNode3Id")

                    nodeList(j, i).sortValue = getINI(sfile, "node" & i & "-" & j, "sortValue")
                    nodeList(j, i).sortValue1 = getINI(sfile, "node" & i & "-" & j, "sortValue1")
                    nodeList(j, i).sortValue2 = getINI(sfile, "node" & i & "-" & j, "sortValue2")
                    nodeList(j, i).sortValue3 = getINI(sfile, "node" & i & "-" & j, "sortValue3")
                Next

                If inumber <= numberOfPlayers / 2 Then
                    partnerList(i) = getINI(sfile, "partners", i & "-" & inumber)

                    If partnerList(i) > numberOfPlayers Then Return False

                    playerList(partnerList(i)).partnerList(i) = inumber
                End If
            Next

            Return True
        Catch ex As Exception
            appEventLog_Write("error :", ex)

            Return False
        End Try
    End Function


    Public Sub resetClient()
        Try
            'kill client
            With frmServer
                '.wsk_Col.Send("01", socketNumber, "")
                sendMessageToClient("01", "")
            End With
        Catch ex As Exception
            appEventLog_Write("error resetClient:", ex)
        End Try
    End Sub

    Public Sub requsetIP(ByVal count As Integer)
        Try
            'request the client send it's IP address
            With frmServer
                '.wsk_Col.Send("05", socketNumber, CStr(count))
                sendMessageToClient("05", CStr(count))
            End With
        Catch ex As Exception
            appEventLog_Write("error requsetIP:", ex)
        End Try
    End Sub

    Public Sub endGame()
        Try
            'tell clients to end the game
            With frmServer
                Dim outstr As String = ""

                ' .wsk_Col.Send("06", socketNumber, outstr)
                sendMessageToClient("06", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endGame:", ex)
        End Try
    End Sub

    Public Sub takeName(ByVal sinstr As String)
        Try
            'get the subject's name

            With frmServer
                sname = sinstr
                .DataGridView1.Rows(inumber - 1).Cells(1).Value = sname
            End With
        Catch ex As Exception
            appEventLog_Write("error takeName:", ex)
        End Try
    End Sub

    Public Sub endEarly()
        Try
            'end experiment early

            With frmServer
                Dim outstr As String

                outstr = numberOfPeriods & ";"
                '.wsk_Col.Send("12", socketNumber, outstr)

                sendMessageToClient("12", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error endEarly:", ex)
        End Try
    End Sub

    Public Sub finishedInstructions()
        Try
            With frmServer

                ' .wsk_Col.Send("04", socketNumber, "")
                sendMessageToClient("04", "")
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub sendChoice()
        Try
            With frmServer
                Dim outstr As String = ""

                If myType = 1 Then
                    outstr = currentNode & ";"
                    outstr &= returnTreeStatus()

                    If currentNode = 0 Then
                        .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Waiting"
                    Else
                        If nodeList(currentNode, currentPeriod).owner = myType Then
                            .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Playing"
                        Else
                            .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Waiting"
                        End If
                    End If

                Else
                    outstr = playerList(partnerList(currentPeriod)).currentNode & ";"
                    outstr &= playerList(partnerList(currentPeriod)).returnTreeStatus()

                    If playerList(partnerList(currentPeriod)).currentNode = 0 Then
                        .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Waiting"
                    Else
                        If playerList(partnerList(currentPeriod)).nodeList(playerList(partnerList(currentPeriod)).currentNode, currentPeriod).owner = myType Then
                            .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Playing"
                        Else
                            .DataGridView1.Rows(inumber - 1).Cells(2).Value = "Waiting"
                        End If
                    End If
                End If

                '.wsk_Col.Send("07", socketNumber, outstr)
                sendMessageToClient("07", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub sendPeriodResults()
        Try
            With frmServer
                Dim outstr As String = ""

                earnings += periodEarnings

                If payoffMode = "dollars" Or payoffMode = "pounds" Then
                    .DataGridView1.Rows(inumber - 1).Cells(3).Value = FormatCurrency(earnings)
                Else
                    .DataGridView1.Rows(inumber - 1).Cells(3).Value = FormatCurrency(earnings / 100)
                End If

                outstr = periodEarnings & ";"
                outstr &= earnings & ";"


                If myType = 1 Then
                    outstr &= currentNode & ";"
                    outstr &= returnTreeStatus()
                Else
                    outstr &= playerList(partnerList(currentPeriod)).currentNode & ";"
                    outstr &= playerList(partnerList(currentPeriod)).returnTreeStatus()
                End If

                '.wsk_Col.Send("08", socketNumber, outstr)

                sendMessageToClient("08", outstr)

                'write summary data
                '"Period,Player,Partner,FinalNode,FinalDirection,MyPayoff,PartnerPayoff,MyType,MadeFinalDecision,"

                outstr = currentPeriod & ","
                outstr &= inumber & ","
                outstr &= partnerList(currentPeriod) & ","

                If myType = 1 Then
                    outstr &= finalNode & ","
                    outstr &= nodeList(finalNode, currentPeriod).status & ","
                Else
                    outstr &= finalNode & ","
                    outstr &= playerList(partnerList(currentPeriod)).nodeList(finalNode, currentPeriod).status & ","
                End If

                outstr &= periodEarnings & ","
                outstr &= playerList(partnerList(currentPeriod)).periodEarnings & ","
                outstr &= myType & ","

                If myType = 1 Then
                    If nodeList(finalNode, currentPeriod).owner = myType Then
                        outstr &= "True,"
                    Else
                        outstr &= "False,"
                    End If
                Else
                    If playerList(partnerList(currentPeriod)).nodeList(finalNode, currentPeriod).owner = myType Then
                        outstr &= "True,"
                    Else
                        outstr &= "False,"
                    End If
                End If

                outstr &= dataDuration & ","
                outstr &= dataSortScore & ","

                playerDf.WriteLine(outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub startNextPeriod()
        Try
            With frmServer

                .DataGridView1.Rows(inumber - 1).Cells(4).Value = partnerList(currentPeriod)

                currentNode = 1

                Dim outstr As String = ""

                outstr &= currentPeriod & ";"

                '.wsk_Col.Send("09", socketNumber, outstr)
                sendMessageToClient("09", outstr)
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub killPath(ByRef tempN As node)
        Try
            tempN.status = "dead"

            If tempN.subNode1Id >= 1 Then
                killPath(nodeList(tempN.subNode1Id, currentPeriod))
            End If

            If tempN.subNode2Id >= 1 Then
                killPath(nodeList(tempN.subNode2Id, currentPeriod))
            End If

            If tempN.subNode3Id >= 1 Then
                killPath(nodeList(tempN.subNode3Id, currentPeriod))
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function returnTreeStatus() As String
        Try
            Dim outstr As String = ""

            For i As Integer = 1 To nodeCount(currentPeriod)
                outstr &= nodeList(i, currentPeriod).status & ";"
            Next

            Return outstr
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return ""
        End Try
    End Function

    Public Function returnSortScore() As Integer
        Try
            Dim tempN As Integer = 0

            For i As Integer = Math.Max(1, currentPeriod - sortWindow + 1) To currentPeriod
                If regimeList(i) = "Sorted" Then
                    tempN += downCount(i)
                End If
            Next

            Return tempN
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function

    Public Function returnDuration() As Integer
        Try
            Dim tempN As Integer = 0

            For i As Integer = currentPeriod To 1 Step -1

                If regimeList(i) = "Sorted" And partnerList(i) = partnerList(currentPeriod + 1) Then
                    tempN += 1
                Else
                    Exit For
                End If
            Next

            Return tempN
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return 0
        End Try
    End Function
End Class
