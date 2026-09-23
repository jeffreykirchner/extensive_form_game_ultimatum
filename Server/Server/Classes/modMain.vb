'Programmed by Jeffrey Kirchner and Your Name Here
'kirchner@chapman.edu/jkirchner@gmail.com
'Economic Science Institute, Chapman University 2008-2010 ©

Imports System.IO

Module modMain
#Region " General Variables "
    Public playerList(100) As player                  'array of players
    Public playerCount As Integer                    'number of players connected
    Public numberOfPlayers As Integer                'number of desired players
    Public sfile As String                           'location of intialization file  
    Public checkin As Integer                        'global counter 
    Public connectionCount As Integer                'total number of connections made since server start 
    Public portNumber As Integer                     'port number sockect traffic is operation on 
    Public summaryDf As StreamWriter                 'data file
    Public playerDf As StreamWriter                 'data file
    Public replayDf As StreamWriter                 'data file
    Public frmServer As New frmMain                  'main form 
    Public filename As String                        'location of data file
    Public filename2 As String                       'location of data file
    Public showInstructions As Boolean               'show client instructions  
    Public currentInstruction As Integer             'current page of instructions 
#End Region

    'global variables here
    Public numberOfPeriods As Integer     'number of periods
    Public currentPeriod As Integer       'current period 

    Public instructionX As Integer            'start up locations of windows
    Public instructionY As Integer
    Public windowX As Integer
    Public windowY As Integer

    Public surveyLink As String                                 'link to post experiment survey

    Public payoffMode As String
    Public testMode As String
    Public periodStart As Date

    Public nodeListInstructions(3, 3) As node
    Public nodeCountInstructions(3) As Integer

    Public iPage8Text As String

    Public instructionCount As Integer = 8
    Public sortWindow As Integer

    Public regimeList(100) As String

    Public nodeList(100, 100) As node  'ID/Period
    Public nodeCount(100) As Integer

#Region " General Functions "
    Public Sub main(ByVal args() As String)
        connectionCount = 0

        AppEventLog_Init()
        appEventLog_Write("Load")

        ToggleScreenSaverActive(False)

        Application.EnableVisualStyles()
        Application.Run(frmServer)

        ToggleScreenSaverActive(True)

        appEventLog_Write("Exit")
        AppEventLog_Close()
    End Sub

    Public Sub takeIP(ByVal sinstr As String, ByVal index As Integer)
        Try
            playerList(index).ipAddress = sinstr
        Catch ex As Exception
            appEventLog_Write("error takeIP:", ex)
        End Try
    End Sub

    Public Function roundUp(ByVal value As Double) As Integer
        Try
            Dim msgtokens() As String

            If InStr(CStr(value), ".") Then
                msgtokens = CStr(value).Split(".")

                roundUp = msgtokens(0)
                roundUp += 1
            Else
                roundUp = value
            End If
        Catch ex As Exception
            Return CInt(value)
            appEventLog_Write("error roundUp:", ex)
        End Try
    End Function

    Public Function getMyColor(ByVal index As Integer) As Color
        Try
            'appEventLog_Write("get color")

            Select Case index
                Case 1
                    getMyColor = Color.Blue
                Case 2
                    getMyColor = Color.Red
                Case 3
                    getMyColor = Color.Teal
                Case 4
                    getMyColor = Color.Green
                Case 5
                    getMyColor = Color.Purple
                Case 6
                    getMyColor = Color.Orange
                Case 7
                    getMyColor = Color.Brown
                Case 8
                    getMyColor = Color.Gray
            End Select
        Catch ex As Exception
            appEventLog_Write("error getMyColor:", ex)
        End Try
    End Function

    Public Function colorToId(ByVal str As String) As Integer
        Try
            Dim i As Integer

            'appEventLog_Write("color to id :" & str)

            For i = 1 To numberOfPlayers
                If str = playerList(i).colorName Then
                    colorToId = i
                    Exit Function
                End If
            Next

            colorToId = -1
        Catch ex As Exception
            Return 0
            appEventLog_Write("error colorToId:", ex)
        End Try
    End Function
#End Region

    Public Sub takeMessage(ByVal sinstr As String)
        'when a message is received from a client it is parsed here
        'msgtokens(1) has type of message sent, having different types of messages allows you to send different formats for different actions.
        'msgtokens(2) has the semicolon delimited data that is to be parsed and acted upon.  
        'index has the client ID that sent the data.  Client ID is assigned by connection order, indexed from 1.

        Try
            With frmServer
                Dim msgtokens() As String

                msgtokens = sinstr.Split("|")

                Dim index As Integer
                index = msgtokens(0)

                Application.DoEvents()

                Select Case msgtokens(1) 'case statement to handle each of the different types of messages
                    Case "SUBJECT_NAME"
                        takeNames(msgtokens(2), index)
                    Case "01"
                        updateInstructionDisplay(msgtokens(2), index)
                    Case "02"
                        finishedInstructions(msgtokens(2), index)
                    Case "03"
                        takeIP(msgtokens(2), index)
                    Case "04"
                        takeChoice(msgtokens(2), index)
                    Case "05"
                        finishedReviewingResults(msgtokens(2), index)
                    Case "06"

                    Case "08"

                    Case "09"

                    Case "10"

                    Case "11"

                    Case "12"

                    Case "13"


                End Select

                Application.DoEvents()

            End With
            'all subs/functions should have an error trap
        Catch ex As Exception
            appEventLog_Write("error takeMessage: " & sinstr & " : ", ex)
        End Try

    End Sub

    Public Sub finishedInstructions(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim msgtokens() As String = sinstr.Split(";")
                checkin += 1
                .DataGridView1.Rows(index - 1).Cells(2).Value = "Waiting"

                playerList(index).instructionLength(instructionCount) += msgtokens(0)

                If checkin = numberOfPlayers Then
                    showInstructions = False
                    checkin = 0

                    MessageBox.Show("Begin Game.", "Start", MessageBoxButtons.OK, MessageBoxIcon.Information)

                    periodStart = Now

                    For i As Integer = 1 To numberOfPlayers
                        playerList(i).finishedInstructions()
                        .DataGridView1.Rows(i - 1).Cells(2).Value = "Playing"
                    Next i

                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error: ", ex)
        End Try
    End Sub

    Public Sub takeNames(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim outstr As String = ""
                Dim msgtokens() As String = sinstr.Split(";")
                Dim nextToken As Integer = 0

                'playerList(index).takeName(msgtokens(0))

                playerList(index).sname = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                playerList(index).studentID = msgtokens(nextToken).Replace(",", "<COMMA>")
                nextToken += 1

                '.dgMain(1, index - 1).Value = playerList(index).name
                .DataGridView1.Rows(index - 1).Cells(1).Value = playerList(index).sname

                checkin += 1

                If checkin = numberOfPlayers Then

                    playerDf.WriteLine("")

                    playerDf.WriteLine("Earnings")
                    outstr = "Name,Earnings,Student ID,"
                    playerDf.WriteLine(outstr)
                    For i As Integer = 1 To numberOfPlayers

                        outstr = .DataGridView1.Rows(i - 1).Cells(1).Value & ","
                        outstr &= .DataGridView1.Rows(i - 1).Cells(3).Value & ","
                        outstr &= playerList(index).studentID & ","
                        playerDf.WriteLine(outstr)
                    Next

                    playerDf.WriteLine("")
                    playerDf.WriteLine("Instruction Length")
                    outstr = "Player,"
                    For i As Integer = 1 To instructionCount
                        outstr &= "Page " & i & ","
                    Next

                    playerDf.WriteLine(outstr)

                    For i As Integer = 1 To numberOfPlayers
                        outstr = i & ",N\A,"

                        For j As Integer = 2 To instructionCount
                            outstr &= Math.Round(playerList(i).instructionLength(j), 1) & ","
                        Next

                        playerDf.WriteLine(outstr)
                    Next

                    playerDf.Close()
                    summaryDf.Close()
                    replayDf.Close()
                End If
            End With
        Catch ex As Exception
            appEventLog_Write("error: ", ex)
        End Try
    End Sub

    Public Sub loadParameters()
        Try
            'load parameters from server.ini

            numberOfPlayers = getINI(sfile, "gameSettings", "numberOfPlayers")
            numberOfPeriods = getINI(sfile, "gameSettings", "numberOfPeriods")
            showInstructions = getINI(sfile, "gameSettings", "showInstructions")
            portNumber = getINI(sfile, "gameSettings", "port")

            instructionX = getINI(sfile, "gameSettings", "instructionX")
            instructionY = getINI(sfile, "gameSettings", "instructionY")
            windowX = getINI(sfile, "gameSettings", "windowX")
            windowY = getINI(sfile, "gameSettings", "windowY")

            surveyLink = getINI(sfile, "gameSettings", "surveyLink")

            payoffMode = getINI(sfile, "gameSettings", "payoffMode")
            testMode = getINI(sfile, "gameSettings", "testMode")

            iPage8Text = getINI(sfile, "gameSettings", "iPage8Text")
            sortWindow = getINI(sfile, "gameSettings", "sortWindow")
        Catch ex As Exception
            appEventLog_Write("error loadParameters:", ex)
        End Try
    End Sub

    Public Sub writeSummaryData(ByVal sinstr As String, ByVal index As Integer)
        Try
            'write data to output file
            Dim outstr As String = ""

            summaryDf.WriteLine(outstr)
        Catch ex As Exception
            appEventLog_Write("error write summary data:", ex)
        End Try
    End Sub

    Public Sub updateInstructionDisplay(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim msgtokens() As String = sinstr.Split(";")
                Dim nextToken As Integer = 0

                Dim tempPage As Integer = msgtokens(nextToken)
                nextToken += 1

                Dim tempLastPage As Integer = msgtokens(nextToken)
                nextToken += 1

                Dim tempTime As Double = msgtokens(nextToken)
                nextToken += 1

                .DataGridView1.Rows(index - 1).Cells(2).Value = "Page " & tempPage

                playerList(index).instructionLength(tempLastPage) += tempTime
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function pointFromString(str As String) As Point
        Try

            Dim msgtokens() As String = str.Split({"{", "X", "=", ",", "Y", "}"}, StringSplitOptions.RemoveEmptyEntries)

            Return New Point(msgtokens(0), msgtokens(1))
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return New Point(0, 0)
        End Try
    End Function

    Public Sub takeChoice(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim msgtokens() As String = sinstr.Split(";")
                Dim nextToken As Integer = 0

                Dim tempP1 As Integer
                Dim tempP2 As Integer
                Dim tempDecisionType As String = ""
                Dim tempDecisionInfo As String = ""

                If playerList(index).myType = 1 Then
                    tempP1 = index
                    tempP2 = playerList(index).partnerList(currentPeriod)
                Else
                    tempP1 = playerList(index).partnerList(currentPeriod)
                    tempP2 = index
                End If

                Dim tempChoice As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempDecisionLength As Double = msgtokens(nextToken)
                nextToken += 1

                Dim tempDecisionStartTime As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempDecisionEndTime As String = msgtokens(nextToken)
                nextToken += 1

                Dim tempNode As node = playerList(tempP1).nodeList(playerList(tempP1).currentNode, currentPeriod)

                tempNode.status = tempChoice

                If InStr(tempChoice, "pay") Then
                    checkin += 1

                    Dim tempPayoff1 As Double
                    Dim tempPayoff2 As Double

                    If tempChoice = "pay1" Then
                        tempPayoff1 = tempNode.payoff11
                        tempPayoff2 = tempNode.payoff12

                        nodeList(tempNode.id, currentPeriod).countRight += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.id, currentPeriod).sortValue1
                    ElseIf tempChoice = "pay2" Then
                        tempPayoff1 = tempNode.payoff21
                        tempPayoff2 = tempNode.payoff22

                        nodeList(tempNode.id, currentPeriod).countDown += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.id, currentPeriod).sortValue2
                    ElseIf tempChoice = "pay3" Then
                        tempPayoff1 = tempNode.payoff31
                        tempPayoff2 = tempNode.payoff32

                        nodeList(tempNode.id, currentPeriod).countLeft += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.id, currentPeriod).sortValue3
                    End If

                    playerList(tempP1).periodEarnings = tempPayoff1
                    playerList(tempP2).periodEarnings = tempPayoff2

                    playerList(tempP1).finalNode = playerList(tempP1).currentNode
                    playerList(tempP2).finalNode = playerList(tempP1).currentNode

                    tempDecisionType = "PayOff"
                    tempDecisionInfo = tempPayoff1 & "\" & tempPayoff2

                    playerList(tempP1).currentNode = 0

                    If tempNode.subNode1Id > 0 Then
                        playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode1Id, currentPeriod))
                    End If

                    If tempNode.subNode2Id > 0 Then
                        playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode2Id, currentPeriod))
                    End If

                    If tempNode.subNode3Id > 0 Then
                        playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode3Id, currentPeriod))
                    End If

                Else

                    If tempChoice = "sub1" Then
                        playerList(tempP1).currentNode = tempNode.subNode1Id

                        tempDecisionType = "Node"
                        tempDecisionInfo = tempNode.subNode1Id

                        nodeList(tempNode.subNode1Id, currentPeriod).count += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.subNode1Id, currentPeriod).sortValue

                        If tempNode.subNode2Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode2Id, currentPeriod))
                        End If

                        If tempNode.subNode3Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode3Id, currentPeriod))
                        End If
                    ElseIf tempChoice = "sub2" Then
                        playerList(tempP1).currentNode = tempNode.subNode2Id

                        tempDecisionType = "Node"
                        tempDecisionInfo = tempNode.subNode2Id

                        nodeList(tempNode.subNode2Id, currentPeriod).count += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.subNode2Id, currentPeriod).sortValue

                        If tempNode.subNode1Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode1Id, currentPeriod))
                        End If

                        If tempNode.subNode3Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode3Id, currentPeriod))
                        End If
                    ElseIf tempChoice = "sub3" Then
                        playerList(tempP1).currentNode = tempNode.subNode3Id

                        tempDecisionType = "Node"
                        tempDecisionInfo = tempNode.subNode3Id

                        nodeList(tempNode.subNode3Id, currentPeriod).count += 1

                        playerList(index).downCount(currentPeriod) += nodeList(tempNode.subNode3Id, currentPeriod).sortValue

                        If tempNode.subNode1Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode1Id, currentPeriod))
                        End If

                        If tempNode.subNode2Id > 0 Then
                            playerList(tempP1).killPath(playerList(tempP1).nodeList(tempNode.subNode2Id, currentPeriod))
                        End If
                    End If


                End If

                Dim outstr As String = ""

                outstr = currentPeriod & ","
                outstr &= index & ","
                outstr &= playerList(index).partnerList(currentPeriod) & ","
                outstr &= playerList(index).myType & ","
                outstr &= tempDecisionType & ","
                outstr &= tempDecisionLength & ","
                outstr &= tempChoice & ","
                outstr &= tempDecisionInfo & ","
                outstr &= tempNode.id & ","

                Dim ts As TimeSpan
                ts = Now - periodStart

                outstr &= ts.TotalMilliseconds & ","
                outstr &= tempDecisionStartTime & ","
                outstr &= tempDecisionEndTime & ","

                summaryDf.WriteLine(outstr)

                'send results
                If checkin = numberOfPlayers / 2 Then
                        checkin = 0

                        For i As Integer = 1 To numberOfPlayers
                            playerList(i).sendPeriodResults()

                            .DataGridView1.Rows(i - 1).Cells(2).Value = "Reviewing Results"
                        Next
                    Else
                        playerList(tempP1).sendChoice()
                        playerList(tempP2).sendChoice()
                    End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub finishedReviewingResults(ByVal sinstr As String, ByVal index As Integer)
        Try
            With frmServer
                Dim msgtokens() As String = sinstr.Split(";")
                Dim nextToken As Integer = 0

                checkin += 1

                .DataGridView1.Rows(index - 1).Cells(2).Value = "Waiting"

                If checkin = numberOfPlayers Then
                    checkin = 0

                    If currentPeriod = numberOfPeriods Then
                        For i As Integer = 1 To numberOfPlayers
                            playerList(i).endGame()
                        Next
                    Else

                        If regimeList(currentPeriod) = "Sorted" Then
                            sortPlayers()
                            .DataGridView1.Columns(5).Visible = True
                            .DataGridView1.Columns(6).Visible = True
                        Else
                            .DataGridView1.Columns(5).Visible = False
                            .DataGridView1.Columns(6).Visible = False
                        End If

                        currentPeriod += 1

                        nodeList(1, currentPeriod).count = numberOfPlayers / 2

                        .txtPeriod.Text = currentPeriod

                        For i As Integer = 1 To numberOfPlayers
                            playerList(i).startNextPeriod()

                            .DataGridView1.Rows(i - 1).Cells(2).Value = "Playing"
                        Next

                        periodStart = Now
                    End If
                End If

            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function setupInstructionNodes() As Boolean
        Try
            nodeCountInstructions(1) = 1
            nodeCountInstructions(2) = 2
            nodeCountInstructions(3) = 3

            For i As Integer = 1 To 3
                For j As Integer = 1 To nodeCountInstructions(i)
                    nodeListInstructions(j, i) = New node

                    nodeListInstructions(j, i).id = j
                    nodeListInstructions(j, i).myPeriod = i

                    nodeListInstructions(j, i).status = "open"

                    nodeListInstructions(j, i).owner = getINI(sfile, "nodeI" & i & "-" & j, "owner")

                    nodeListInstructions(j, i).payoff11 = getINI(sfile, "nodeI" & i & "-" & j, "payoff11")
                    nodeListInstructions(j, i).payoff12 = getINI(sfile, "nodeI" & i & "-" & j, "payoff12")
                    nodeListInstructions(j, i).payoff21 = getINI(sfile, "nodeI" & i & "-" & j, "payoff21")
                    nodeListInstructions(j, i).payoff22 = getINI(sfile, "nodeI" & i & "-" & j, "payoff22")
                    nodeListInstructions(j, i).payoff31 = getINI(sfile, "nodeI" & i & "-" & j, "payoff31")
                    nodeListInstructions(j, i).payoff32 = getINI(sfile, "nodeI" & i & "-" & j, "payoff32")

                    nodeListInstructions(j, i).pt1 = pointFromString(getINI(sfile, "nodeI" & i & "-" & j, "pt1"))
                    nodeListInstructions(j, i).pt2 = pointFromString(getINI(sfile, "nodeI" & i & "-" & j, "pt2"))
                    nodeListInstructions(j, i).pt3 = pointFromString(getINI(sfile, "nodeI" & i & "-" & j, "pt3"))
                    nodeListInstructions(j, i).pt4 = pointFromString(getINI(sfile, "nodeI" & i & "-" & j, "pt4"))

                    nodeListInstructions(j, i).subNode1Id = getINI(sfile, "nodeI" & i & "-" & j, "subNode1Id")
                    nodeListInstructions(j, i).subNode2Id = getINI(sfile, "nodeI" & i & "-" & j, "subNode2Id")
                    nodeListInstructions(j, i).subNode3Id = getINI(sfile, "nodeI" & i & "-" & j, "subNode3Id")
                Next
            Next

            Return True
        Catch ex As Exception
            appEventLog_Write("error :", ex)

            Return False
        End Try
    End Function

    Public Function checkValidText(ByVal sinstr As String) As Boolean
        Try
            If InStr(sinstr, "|") > 0 Then
                MsgBox("Please do not use the ""|"" character.", MsgBoxStyle.Critical)
                sinstr = ""
                Return False
            End If

            If InStr(sinstr, "#") > 0 Then
                MsgBox("Please do not use the ""#"" character.", MsgBoxStyle.Critical)
                sinstr = ""
                Return False
            End If

            If InStr(sinstr, ";") > 0 Then
                MsgBox("Please do not use the "";"" character.", MsgBoxStyle.Critical)
                sinstr = ""
                Return False
            End If

            Return True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Function

    Public Sub sortPlayers()
        Try
            With frmServer
                Dim p1List(100) As Integer
                Dim p2List(100) As Integer

                'sort person 1's
                p1List(1) = 1

                For i As Integer = 2 To numberOfPlayers / 2
                    Dim tempScore As Integer = playerList(i).returnSortScore
                    Dim tempSpot As Integer = -1

                    For j As Integer = 1 To i - 1
                        If tempScore > playerList(p1List(j)).returnSortScore Then
                            tempSpot = j
                            Exit For
                        End If
                    Next

                    If tempSpot = -1 Then
                        p1List(i) = i
                    Else
                        For j As Integer = i To tempSpot + 1 Step -1
                            p1List(j) = p1List(j - 1)
                        Next

                        p1List(tempSpot) = i
                    End If
                Next

                'sort person 2s
                p2List(1) = 1

                For i As Integer = 2 To numberOfPlayers / 2
                    Dim tempScore As Integer = playerList(i + numberOfPlayers / 2).returnSortScore
                    Dim tempSpot As Integer = -1

                    For j As Integer = 1 To i - 1
                        If tempScore > playerList(p2List(j) + numberOfPlayers / 2).returnSortScore Then
                            tempSpot = j
                            Exit For
                        End If
                    Next

                    If tempSpot = -1 Then
                        p2List(i) = i
                    Else
                        For j As Integer = i To tempSpot + 1 Step -1
                            p2List(j) = p2List(j - 1)
                        Next

                        p2List(tempSpot) = i
                    End If
                Next

                'match partners

                For i As Integer = 1 To numberOfPlayers / 2
                    playerList(p1List(i)).partnerList(currentPeriod + 1) = p2List(i) + numberOfPlayers / 2
                    playerList(p2List(i) + numberOfPlayers / 2).partnerList(currentPeriod + 1) = p1List(i)
                Next

                'update display
                For i As Integer = 1 To numberOfPlayers
                    playerList(i).dataDuration = playerList(i).returnDuration
                    playerList(i).dataSortScore = playerList(i).returnSortScore

                    .DataGridView1.Rows(i - 1).Cells(5).Value = playerList(i).dataDuration
                    .DataGridView1.Rows(i - 1).Cells(6).Value = playerList(i).dataSortScore
                Next
            End With
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Function validateInt(ByVal sinstr As String, ByVal maxLength As Integer,
                                ByVal allowDecimal As Boolean, ByVal allowNegative As Boolean) As Boolean
        Try
            If Not IsNumeric(sinstr) Then Return False

            If Not allowDecimal Then
                If InStr(sinstr, ".") Then
                    Return False
                End If
            End If

            Dim msgtokens() As String = sinstr.Split(".")
            If Len(msgtokens(0)) > maxLength Then
                Return False
            End If

            If Not allowNegative Then
                If CDbl(sinstr) < 0 Then
                    Return False
                End If
            End If

            Return True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
            Return False
        End Try
    End Function
End Module
