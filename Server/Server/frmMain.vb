Imports System
Imports System.ComponentModel
Imports System.Threading
Imports System.Windows.Forms
Imports System.Drawing.Drawing2D
Imports System.IO

Public Class frmMain
#Region " Winsock Code "
    Public WithEvents wsk_Col As New WinsockCollection
    Private _users As New UserCollection
    Public WithEvents wskListener As Winsock


    Private Sub wskListener_ConnectionRequest(ByVal sender As Object, ByVal e As WinsockClientReceivedEventArgs) Handles wskListener.ConnectionRequest
        Try
            'Log("Connection received from: " & e.ClientIP)
            Dim y As New clsUser
            Dim i As Integer
            Dim ID As String = connectionCount + 1

            connectionCount += 1

            _users.Add(y)
            Dim x As New Winsock(Me)
            wsk_Col.Add(x, ID)
            x.Accept(e.Client)

            If cmdBegin.Enabled = False Then
                For i = 1 To playerCount
                    If playerList(i).myIPAddress = e.ClientIP Then
                        playerList(i).socketNumber = ID 'wsk_Col.Count - 1
                        Exit For
                    End If
                Next

                Exit Sub
            End If

            playerCount += 1
            playerList(playerCount) = New player()
            playerList(playerCount).inumber = playerCount
            playerList(playerCount).socketNumber = ID 'wsk_Col.Count - 1
            playerList(playerCount).myIPAddress = e.ClientIP

            playerList(playerCount).requsetIP(playerCount)

            lblConnections.Text = CInt(lblConnections.Text) + 1

            'appEventLog_Write("connection request: " & e.ClientIP)
        Catch ex As Exception
            appEventLog_Write("error wskListener_ConnectionRequest:", ex)
        End Try
    End Sub

    Private Sub wskListener_ErrorReceived(ByVal sender As System.Object, ByVal e As WinsockErrorEventArgs) Handles wskListener.ErrorReceived
        Try
            appEventLog_Write("winsock error: " & e.Message)
        Catch ex As Exception
            appEventLog_Write("error wskListener_ErrorReceived:", ex)
        End Try
    End Sub

    Private Sub wskListener_StateChanged(ByVal sender As Object, ByVal e As WinsockStateChangingEventArgs) Handles wskListener.StateChanged
        'Log("Listener state changed from " & e.Old_State.ToString & " to " & e.New_State.ToString)
        'lblListenState.Text = "State: " & e.New_State.ToString
        'cmdListen.Enabled = False
        'cmdClose.Enabled = False
        'Select Case e.New_State
        '    Case WinsockStates.Closed
        '        cmdListen.Enabled = True
        '    Case WinsockStates.Listening
        '        cmdClose.Enabled = True
        'End Select
    End Sub

    'Private Sub Log(ByVal val As String)
    '    lstLog.SelectedIndex = lstLog.Items.Add(val)
    '    lstLog.SelectedIndex = -1
    'End Sub

    Private Sub Wsk_DataArrival(ByVal sender As Object, ByVal e As WinsockDataArrivalEventArgs) Handles wsk_Col.DataArrival
        Try
            Dim sender_key As String = wsk_Col.GetKey(sender)
            Dim buf As String = Nothing
            CType(sender, Winsock).Get(buf)

            Dim msgtokens() As String = buf.Split("#")
            Dim i As Integer

            'appEventLog_Write("data arrival: " & buf)

            For i = 1 To msgtokens.Length - 1
                takeMessage(msgtokens(i - 1))
            Next

        Catch ex As Exception
            appEventLog_Write("error Wsk_DataArrival:", ex)
        End Try
    End Sub

    Private Sub Wsk_Disconnected(ByVal sender As Object, ByVal e As System.EventArgs) Handles wsk_Col.Disconnected
        Try
            wsk_Col.Remove(sender)
            If cmdBegin.Enabled Then Exit Sub
            MsgBox("A client has been disconnected.", MsgBoxStyle.Critical)
            appEventLog_Write("client disconnected")
            'lblConNum.Text = "Connected: " & wsk_Col.Count
        Catch ex As Exception
            appEventLog_Write("error Wsk_Disconnected:", ex)
        End Try
    End Sub
    Private Sub Wsk_Connected(ByVal sender As Object, ByVal e As System.EventArgs) Handles wsk_Col.Connected
        'lblConNum.Text = "Connected: " & wsk_Col.Count
    End Sub

    Private Sub ShutDownServer()
        Try
            GC.Collect()
        Catch ex As Exception
            appEventLog_Write("error ShutDownServer:", ex)
        End Try

    End Sub
#End Region    'communication code

#Region " Extra Functions "
    Public Function convertY(ByVal p As Integer, ByVal graphMin As Integer, ByVal graphMax As Integer, _
                                 ByVal panelHeight As Integer, ByVal bottomOffset As Integer, ByVal topOffset As Integer) As Double
        Try
            Dim tempD As Double

            tempD = p - graphMin

            tempD = (tempD * (panelHeight - bottomOffset - topOffset)) / (graphMax - graphMin)
            tempD = panelHeight - (bottomOffset + topOffset) - tempD

            convertY = tempD + topOffset
        Catch ex As Exception
            Return 0
            appEventLog_Write("error convertY:", ex)
        End Try
    End Function

    Private Sub PrintDocument1_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Try
            Dim i As Integer
            Dim f As New Font("Arial", 8, FontStyle.Bold)
            Dim tempN As Integer

            e.Graphics.DrawString(filename2, f, Brushes.Black, 10, 10)

            f = New Font("Arial", 15, FontStyle.Bold)

            e.Graphics.DrawString("Name", f, Brushes.Black, 10, 30)
            e.Graphics.DrawString("Earnings", f, Brushes.Black, 400, 30)

            f = New Font("Arial", 12, FontStyle.Bold)

            tempN = 55

            For i = 1 To DataGridView1.RowCount
                If i Mod 2 = 0 Then
                    e.Graphics.FillRectangle(Brushes.Aqua, 0, tempN, 500, 19)
                End If
                e.Graphics.DrawString(DataGridView1.Rows(i - 1).Cells(1).Value, f, Brushes.Black, 10, tempN)
                e.Graphics.DrawString(DataGridView1.Rows(i - 1).Cells(3).Value, f, Brushes.Black, 400, tempN)

                tempN += 20
            Next

        Catch ex As Exception
            appEventLog_Write("error PrintDocument1_PrintPage:", ex)
        End Try

    End Sub
#End Region

    Public tempTime As String 'time stamp at start of experiment
    Public mainScreen As Screen



    Public replayDfSummary() As String
    Public replayDfEvents() As String

    Dim replaySpeed As Integer = 100


    Private Sub frmMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Try
            mainScreen = New Screen(pnlMain, New Rectangle(0, 0, pnlMain.Width, pnlMain.Height))

            sfile = System.Windows.Forms.Application.StartupPath & "\server.ini"
            loadParameters()

            Dim i As Integer           ', j As Integer

            For i = 1 To 4
                DataGridView1.Columns(i - 1).SortMode = DataGridViewColumnSortMode.NotSortable
            Next

            'setup communication on load
            wskListener = New Winsock
            wskListener.BufferSize = 8192
            wskListener.LegacySupport = False
            wskListener.LocalPort = portNumber
            wskListener.MaxPendingConnections = 1
            wskListener.Protocol = WinsockProtocols.Tcp
            wskListener.RemotePort = 8080
            wskListener.RemoteServer = "localhost"
            wskListener.SynchronizingObject = Me

            wskListener.Listen()

            playerCount = 0

            lblIP.Text = wskListener.LocalIP
            lblLocalHost.Text = SystemInformation.ComputerName
        Catch ex As Exception
            appEventLog_Write("error frmSvr_Load:", ex)
        End Try

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Try
            drawScreen()
        Catch ex As Exception
            appEventLog_Write("error Timer1_Tick:", ex)
        End Try
    End Sub

    Public Sub drawScreen()
        Try
            mainScreen.erase1()
            Dim g As Graphics = mainScreen.GetGraphics

            For i As Integer = 1 To nodeCount(currentPeriod)
                If nodeList(i, currentPeriod) IsNot Nothing Then
                    nodeList(i, currentPeriod).drawNode(g, True)
                End If
            Next

            mainScreen.flip()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdBegin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBegin.Click
        Try

            'when a button is pressed it's click event is fired

            loadParameters()

            Dim nextToken As Integer = 0
            Dim str As String

            If CInt(lblConnections.Text) <> numberOfPlayers Then
                MsgBox("Incorrect number of connections.", MsgBoxStyle.Exclamation)
                Exit Sub
            End If

            'define timestamp for recording data
            tempTime = DateTime.Now.Month & "-" & DateTime.Now.Day & "-" & DateTime.Now.Year & "_" & DateTime.Now.Hour & _
                     "_" & DateTime.Now.Minute & "_" & DateTime.Now.Second

            'create unique file name for storing data, CSVs are excel readable, Comma Separted Value files.
            filename = "event_data_" & tempTime & ".csv"
            filename = System.Windows.Forms.Application.StartupPath & "\datafiles\" & filename

            summaryDf = File.CreateText(filename)
            str = "Period,Player,Partner,PlayerType,DecisionType,DecisionLength,DecisionDirection,DecisionInfo,DecisionNode,PeriodTime,DecisionStartTime,DecisionClickTime,DecisionEndTime"
            summaryDf.WriteLine(str)

            filename = "summary_data_" & tempTime & ".csv"
            filename = System.Windows.Forms.Application.StartupPath & "\datafiles\" & filename

            playerDf = File.CreateText(filename)
            str = "Period,Player,Partner,FinalNode,FinalDirection,MyPayoff,PartnerPayoff,MyType,MadeFinalDecision,DecisionStartTime,DecisionClickTime,DecisionEndTime,ReviewStartTime,ReviewClickTime,ReviewEndTime"
            playerDf.WriteLine(str)

            filename = "replay_data_" & tempTime & ".csv"
            filename = System.Windows.Forms.Application.StartupPath & "\datafiles\" & filename

            replayDf = File.CreateText(filename)

            Dim msgtokens() As String = My.Computer.FileSystem.ReadAllText(sfile).Split(vbCrLf)

            For i As Integer = 0 To msgtokens.Length - 1
                replayDf.Write(msgtokens(i))
            Next

            DataGridView1.RowCount = numberOfPlayers

            showInstructions = getINI(sfile, "gameSettings", "showInstructions")

            'setup for display results
            'setup player type
            For i As Integer = 1 To numberOfPlayers
                DataGridView1.Rows(i - 1).Cells(0).Value = i

                playerList(i).earnings = 0
                playerList(i).roundEarnings = 0
                playerList(i).exchangeRate = getINI(sfile, "exchangeRate", CStr(i))

                DataGridView1.Rows(i - 1).Cells(0).Value = i
                DataGridView1.Rows(i - 1).Cells(1).Value = playerList(i).myIPAddress

                If showInstructions Then
                    DataGridView1.Rows(i - 1).Cells(2).Value = "Page 1"
                Else
                    DataGridView1.Rows(i - 1).Cells(2).Value = "Playing"
                End If

                DataGridView1.Rows(i - 1).Cells(3).Value = "0"
            Next


            currentPeriod = 1
            txtPeriod.Maximum = numberOfPeriods
            txtPeriod.Text = currentPeriod
            txtPeriod.Enabled = False
            checkin = 0

            'disable/enable buttons needed when the experiment starts

            filename2 = filename

            showInstructions = getINI(sfile, "gameSettings", "showInstructions")

            For i As Integer = 1 To numberOfPeriods
                nodeCount(i) = getINI(sfile, "nodeCount", CStr(i))
            Next

            For i As Integer = 1 To numberOfPlayers
                If Not playerList(i).setupNodes() Then
                    MessageBox.Show("Pair Setup Error, change the pairings then press Begin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
            Next

            'check no duplicate partners
            For i As Integer = 1 To numberOfPlayers / 2
                For j As Integer = 1 To numberOfPlayers / 2
                    If j <> i Then
                        If playerList(i).partnerList(1) = playerList(j).partnerList(1) Then
                            MessageBox.Show("Pair Setup Error, change the pairings then press Begin.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                            Exit Sub
                        End If
                    End If
                Next
            Next

            setupInstructionNodes()

            'signal clients to begin
            For i As Integer = 1 To numberOfPlayers
                playerList(i).begin()

                DataGridView1.Rows(i - 1).Cells(2).Value = "Playing"
            Next

            DataGridView1.Columns(5).Visible = False
            DataGridView1.Columns(6).Visible = False

            checkin = 0

            setupNodes(sfile)

            nodeList(1, currentPeriod).count = numberOfPlayers / 2

            Timer1.Enabled = True

            periodStart = Now

            cmdLoad.Enabled = False
            cmdGameSetup.Enabled = False
            cmdExchange.Enabled = False
            cmdSetup2.Enabled = False
            cmdExit.Enabled = False
            cmdBegin.Enabled = False
            cmdEnd.Enabled = True
            cmdExchange.Enabled = False
            cmdTreeSetup.Enabled = False
            cmdPlayData.Enabled = False
            cmdLoadData.Enabled = False
            cmdRecoverClient.Enabled = True

        Catch ex As Exception
            appEventLog_Write("error cmdBegin_Click:", ex)
        End Try

    End Sub

    Private Sub cmdReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdReset.Click
        Try
            'when reset is pressed bring server back to state to start another experiment

            'disable timers
            Timer1.Enabled = False
            Timer2.Enabled = False
            Timer3.Enabled = False

            'close data files
            If summaryDf IsNot Nothing Then summaryDf.Close()
            If playerDf IsNot Nothing Then playerDf.Close()
            If replayDf IsNot Nothing Then replayDf.Close()

            'shut down clients
            Dim i As Integer
            For i = 1 To CInt(lblConnections.Text)
                playerList(i).resetClient()
            Next

            'enable/disable buttons
            cmdLoad.Enabled = True
            cmdGameSetup.Enabled = True
            cmdBegin.Enabled = True
            cmdExit.Enabled = True
            cmdEnd.Enabled = False
            cmdExchange.Enabled = True
            cmdSetup2.Enabled = True
            cmdExchange.Enabled = True
            cmdTreeSetup.Enabled = True
            cmdLoadData.Enabled = True
            cmdRecoverClient.Enabled = False

            lblConnections.Text = 0
            playerCount = 0

            DataGridView1.RowCount = 0

            frmInstructions.Close()

        Catch ex As Exception
            appEventLog_Write("error cmdReset_Click:", ex)
        End Try
    End Sub

    Private Sub cmdExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExit.Click
        Try
            'exit program

            Timer1.Enabled = False
            ShutDownServer()

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error cmdExit_Click:", ex)
        End Try
    End Sub

    Private Sub cmdGameSetup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdGameSetup.Click
        Try
            frmSetup.Show()
        Catch ex As Exception
            appEventLog_Write("error cmdGameSetup_Click:", ex)
        End Try
    End Sub

    Dim replayMS As Integer
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick
        Try
            resetNodeCounts()

            replayMS += replaySpeed

            Dim msgtokens() As String
            Dim tempPeriod As Integer
            Dim tempLength As Integer
            Dim tempNode As Integer
            Dim tempType As String
            Dim tempInfo As String
            Dim tempDirection As String
            Dim tempPayoffCount As Integer = 0

            For i As Integer = 1 To replayDfEvents.Length - 1
                msgtokens = replayDfEvents(i).Split(",")

                If IsNumeric(msgtokens(0)) Then
                    tempPeriod = msgtokens(0)
                    tempType = msgtokens(4)
                    tempDirection = msgtokens(6)
                    tempInfo = msgtokens(7)
                    tempNode = msgtokens(8)
                    tempLength = msgtokens(9)

                    If tempPeriod = currentPeriod And tempLength <= replayMS Then

                        If tempDirection = "pay1" Then
                            nodeList(tempNode, currentPeriod).countRight += 1
                        ElseIf tempDirection = "pay2" Then
                            nodeList(tempNode, currentPeriod).countDown += 1
                        ElseIf tempDirection = "pay3" Then
                            nodeList(tempNode, currentPeriod).countLeft += 1
                        ElseIf tempDirection = "sub1" Then
                            nodeList(nodeList(tempNode, currentPeriod).subNode1Id, currentPeriod).count += 1
                        ElseIf tempDirection = "sub2" Then
                            nodeList(nodeList(tempNode, currentPeriod).subNode2Id, currentPeriod).count += 1
                        ElseIf tempDirection = "sub3" Then
                            nodeList(nodeList(tempNode, currentPeriod).subNode3Id, currentPeriod).count += 1
                        End If

                        If tempType = "PayOff" Then
                            tempPayoffCount += 1
                        End If

                    End If
                End If
            Next

            If tempPayoffCount = numberOfPlayers / 2 Then
                Timer2.Enabled = False
            End If

            lblReplayTime.Text = Format(replayMS / 1000, "0.0")
        Catch ex As Exception
            appEventLog_Write("error Timer2_Tick:", ex)
        End Try
    End Sub

    Private Sub cmdLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdLoad.Click
        Try

            Dim tempS As String
            Dim sinstr As String

            'dispaly open file dialog to select file
            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath

            OpenFileDialog1.ShowDialog()

            'if filename is not empty then continue with load
            If OpenFileDialog1.FileName = "" Then
                Exit Sub
            End If

            tempS = OpenFileDialog1.FileName

            sinstr = getINI(tempS, "gameSettings", "gameName")

            'check that this is correct type of file to load
            If sinstr <> "EFG3" Then
                MsgBox("Invalid file", vbExclamation)
                Exit Sub
            End If

            'copy file to be loaded into server.ini
            FileCopy(OpenFileDialog1.FileName, sfile)

            'load new parameters into server
            loadParameters()
        Catch ex As Exception
            appEventLog_Write("error cmdLoad_Click:", ex)
        End Try
    End Sub

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            'save current parameters to a text file so they can be loaded at a later time

            SaveFileDialog1.FileName = ""
            SaveFileDialog1.Filter = "Parameter Files (*.txt)|*.txt"
            SaveFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName = "" Then
                Exit Sub
            End If

            FileCopy(sfile, SaveFileDialog1.FileName)

        Catch ex As Exception
            appEventLog_Write("error cmdSave_Click:", ex)
        End Try
    End Sub



    Private Sub cmdEnd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEnd.Click
        Try
            'end experiment early

            Dim i As Integer
            cmdEnd.Enabled = False

            numberOfPeriods = currentPeriod

            For i = 1 To numberOfPlayers
                playerList(i).endEarly()
            Next
        Catch ex As Exception
            appEventLog_Write("error cmdEnd_Click:", ex)
        End Try
    End Sub

    Private Sub txtExchange_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdExchange.Click
        Try
            frmExchange.Show()
        Catch ex As Exception
            appEventLog_Write("error txtExchange:", ex)
        End Try
    End Sub

    Private Sub Timer3_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer3.Tick
        Try

        Catch ex As Exception
            appEventLog_Write("error timer3 tick:", ex)
        End Try
    End Sub

    Private Sub cmdSetup2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSetup2.Click
        Try
            frmSetup2.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub llESI_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llESI.LinkClicked
        Try
            System.Diagnostics.Process.Start("http://www.chapman.edu/esi/")
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdPrint.Click
        Try

            If PrintDialog1.ShowDialog = DialogResult.OK Then
                PrintDocument1.Print()
            End If

        Catch ex As Exception
            appEventLog_Write("error cmdPrint_Click:", ex)
        End Try
    End Sub

    Private Sub cmdTreeSetup_Click(sender As System.Object, e As System.EventArgs) Handles cmdTreeSetup.Click
        Try
            frmSetup3.Show()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub setupNodes(tempFile As String)
        Try
            For i As Integer = 1 To numberOfPeriods
                nodeCount(i) = getINI(tempFile, "nodeCount", CStr(i))

                For j As Integer = 1 To nodeCount(i)
                    nodeList(j, i) = New node

                    nodeList(j, i).id = j
                    nodeList(j, i).myPeriod = i

                    nodeList(j, i).status = "open"

                    If getINI(tempFile, "node" & i & "-" & j, "owner") <> "?" Then

                        nodeList(j, i).owner = getINI(tempFile, "node" & i & "-" & j, "owner")

                        nodeList(j, i).payoff11 = getINI(tempFile, "node" & i & "-" & j, "payoff11")
                        nodeList(j, i).payoff12 = getINI(tempFile, "node" & i & "-" & j, "payoff12")
                        nodeList(j, i).payoff21 = getINI(tempFile, "node" & i & "-" & j, "payoff21")
                        nodeList(j, i).payoff22 = getINI(tempFile, "node" & i & "-" & j, "payoff22")
                        nodeList(j, i).payoff31 = getINI(tempFile, "node" & i & "-" & j, "payoff31")
                        nodeList(j, i).payoff32 = getINI(tempFile, "node" & i & "-" & j, "payoff32")

                        nodeList(j, i).pt1 = pointFromString(getINI(tempFile, "node" & i & "-" & j, "pt1"))
                        nodeList(j, i).pt2 = pointFromString(getINI(tempFile, "node" & i & "-" & j, "pt2"))
                        nodeList(j, i).pt3 = pointFromString(getINI(tempFile, "node" & i & "-" & j, "pt3"))
                        nodeList(j, i).pt4 = pointFromString(getINI(tempFile, "node" & i & "-" & j, "pt4"))

                        nodeList(j, i).subNode1Id = getINI(tempFile, "node" & i & "-" & j, "subNode1Id")
                        nodeList(j, i).subNode2Id = getINI(tempFile, "node" & i & "-" & j, "subNode2Id")
                        nodeList(j, i).subNode3Id = getINI(tempFile, "node" & i & "-" & j, "subNode3Id")

                        nodeList(j, i).payoffLabel1 = getINI(tempFile, "node" & i & "-" & j, "payoffLabel1")
                        nodeList(j, i).payoffLabel2 = getINI(tempFile, "node" & i & "-" & j, "payoffLabel2")
                        nodeList(j, i).payoffLabel3 = getINI(tempFile, "node" & i & "-" & j, "payoffLabel3")
                        nodeList(j, i).subNodeLabel1 = getINI(tempFile, "node" & i & "-" & j, "subNodeLabel1")
                        nodeList(j, i).subNodeLabel2 = getINI(tempFile, "node" & i & "-" & j, "subNodeLabel2")
                        nodeList(j, i).subNodeLabel3 = getINI(tempFile, "node" & i & "-" & j, "subNodeLabel3")

                        If nodeList(j, i).payoffLabel1 = "?" Then nodeList(j, i).payoffLabel1 = ""
                        If nodeList(j, i).payoffLabel2 = "?" Then nodeList(j, i).payoffLabel2 = ""
                        If nodeList(j, i).payoffLabel3 = "?" Then nodeList(j, i).payoffLabel3 = ""
                        If nodeList(j, i).subNodeLabel1 = "?" Then nodeList(j, i).subNodeLabel1 = ""
                        If nodeList(j, i).subNodeLabel2 = "?" Then nodeList(j, i).subNodeLabel2 = ""
                        If nodeList(j, i).subNodeLabel3 = "?" Then nodeList(j, i).subNodeLabel3 = ""

                        nodeList(j, i).sortValue = getINI(tempFile, "node" & i & "-" & j, "sortValue")
                        nodeList(j, i).sortValue1 = getINI(tempFile, "node" & i & "-" & j, "sortValue1")
                        nodeList(j, i).sortValue2 = getINI(tempFile, "node" & i & "-" & j, "sortValue2")
                        nodeList(j, i).sortValue3 = getINI(tempFile, "node" & i & "-" & j, "sortValue3")
                    End If

                Next

                regimeList(i) = getINI(sfile, "pairingRule", CStr(i))
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdLoadData_Click(sender As System.Object, e As System.EventArgs) Handles cmdLoadData.Click
        Try
            Dim sinstr As String = ""

            OpenFileDialog1.FileName = ""
            OpenFileDialog1.Filter = "Data Files (*.csv)|*.csv"
            OpenFileDialog1.InitialDirectory = System.Windows.Forms.Application.StartupPath

            OpenFileDialog1.ShowDialog()

            sinstr = OpenFileDialog1.FileName

            If OpenFileDialog1.FileName = "" Then
                Exit Sub
            End If

            Dim d(3) As String
            d(0) = "summary_data_"
            d(1) = "event_data_"
            d(2) = "replay_data_"

            Dim msgtokens2() As String = OpenFileDialog1.FileName.Split(d, StringSplitOptions.RemoveEmptyEntries)

            Dim tempFileName As String
            Dim replayDF As String

            'read peasant data
            replayDF = msgtokens2(0) & "replay_data_" & msgtokens2(1)

            'read peasant data
            tempFileName = msgtokens2(0) & "summary_data_" & msgtokens2(1)
            replayDfEvents = My.Computer.FileSystem.ReadAllText(tempFileName).Split(vbCrLf)

            'read peasant data
            tempFileName = msgtokens2(0) & "event_data_" & msgtokens2(1)
            replayDfEvents = My.Computer.FileSystem.ReadAllText(tempFileName).Split(vbCrLf)

            numberOfPlayers = getINI(replayDF, "gameSettings", "numberOfPlayers")
            numberOfPeriods = getINI(replayDF, "gameSettings", "numberOfPeriods")

            setupNodes(replayDF)

            txtPeriod.Minimum = 1
            txtPeriod.Maximum = numberOfPeriods
            txtPeriod.Value = 1
            txtPeriod.Enabled = True

            currentPeriod = 1
            replayMS = 0

            nodeList(1, currentPeriod).count = numberOfPlayers / 2

            Timer1.Enabled = True

            cmdPlayData.Enabled = True
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdPlayData_Click(sender As System.Object, e As System.EventArgs) Handles cmdPlayData.Click
        Try
            replayMS = 0
            Timer2.Enabled = True
            currentPeriod = txtPeriod.Value

            resetNodeCounts()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Public Sub resetNodeCounts()
        Try
            For i As Integer = 1 To nodeCount(currentPeriod)
                nodeList(i, currentPeriod).count = 0
                nodeList(i, currentPeriod).countDown = 0
                nodeList(i, currentPeriod).countRight = 0
                nodeList(i, currentPeriod).countLeft = 0
            Next

            nodeList(1, currentPeriod).count = numberOfPlayers / 2
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub txtPeriod_ValueChanged(sender As System.Object, e As System.EventArgs) Handles txtPeriod.ValueChanged
        Try
            If cmdPlayData.Enabled = True Then
                replayMS = 0
                Timer2.Enabled = False

                currentPeriod = txtPeriod.Value
                lblReplayTime.Text = "-"
            End If
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdRecoverClient_Click(sender As System.Object, e As System.EventArgs) Handles cmdRecoverClient.Click
        Try
            Dim tempI As Integer = DataGridView1.SelectedRows(0).Index + 1

            playerList(tempI).resendLastMessage()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub tbSpeed_Scroll(sender As Object, e As EventArgs) Handles tbSpeed.Scroll
        Try
            replaySpeed = tbSpeed.Value
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class
