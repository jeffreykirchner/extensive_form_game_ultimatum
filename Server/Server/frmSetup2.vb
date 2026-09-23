Public Class frmSetup2

    Private Sub cmdSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSave.Click
        Try
            For i As Integer = 1 To DataGridView1.RowCount
                writeINI(sfile,
                         "partners",
                         DataGridView1.Rows(i - 1).Cells(0).Value & "-" & DataGridView1.Rows(i - 1).Cells(1).Value,
                         DataGridView1.Rows(i - 1).Cells(2).Value)
            Next

            For i As Integer = 1 To numberOfPeriods
                writeINI(sfile, "pairingRule", CStr(i), DataGridView2.Rows(i - 1).Cells(1).Value)
            Next

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error:", ex)
        End Try
    End Sub

    Private Sub frmPeriodSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            DataGridView1.RowCount = (numberOfPlayers / 2) * numberOfPeriods

            Dim tempN As Integer = 0
            For j As Integer = 1 To numberOfPeriods
                For i As Integer = 1 To numberOfPlayers / 2
                    DataGridView1.Rows(tempN).Cells(0).Value = j
                    DataGridView1.Rows(tempN).Cells(1).Value = i

                    DataGridView1.Rows(tempN).Cells(2).Value = getINI(sfile, "partners", j & "-" & i)

                    tempN += 1
                Next
            Next

            DataGridView2.RowCount = numberOfPeriods

            For i As Integer = 1 To numberOfPeriods
                DataGridView2.Rows(i - 1).Cells(0).Value = i

                Dim cb As New DataGridViewComboBoxCell
                cb.Items.Add("Random")
                cb.Items.Add("Fixed")
                cb.Items.Add("Sorted")

                DataGridView2.Rows(i - 1).Cells(1) = cb

                Dim tempValue As String = getINI(sfile, "pairingRule", CStr(i))

                If tempValue <> "?" Then DataGridView2.Rows(i - 1).Cells(1).Value = tempValue
            Next

        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try

    End Sub

    Private Sub cmdRandom_Click(sender As System.Object, e As System.EventArgs) Handles cmdRandom.Click
        Try
            Dim tempNPeriod As Integer = 0
            Dim tempNPlayer As Integer = 0

            For i As Integer = 1 To DataGridView1.RowCount
                DataGridView1.Rows(i - 1).Cells(2).Value = Nothing
            Next

            For j As Integer = 1 To numberOfPeriods

                If j = 1 Or DataGridView2.Rows(j - 1).Cells(1).Value = "Random" Then
                    For i As Integer = 1 To numberOfPlayers / 2

                        'find random partner
                        Dim tempP As Integer = rand(numberOfPlayers, numberOfPlayers / 2 + 1)
                        Dim go As Boolean = True

                        While go
                            go = False

                            For k As Integer = tempNPeriod To tempNPeriod + numberOfPlayers / 2 - 1
                                If DataGridView1.Rows(k).Cells(2).Value = tempP Then
                                    go = True
                                End If
                            Next

                            If go Then
                                tempP = rand(numberOfPlayers, numberOfPlayers / 2 + 1)
                            End If
                        End While

                        DataGridView1.Rows(tempNPlayer).Cells(2).Value = tempP

                        tempNPlayer += 1
                    Next
                Else
                    For i As Integer = 1 To numberOfPlayers / 2
                        DataGridView1.Rows(tempNPlayer).Cells(2).Value = DataGridView1.Rows(tempNPlayer - (numberOfPlayers / 2)).Cells(2).Value

                        tempNPlayer += 1
                    Next
                End If

                tempNPeriod = tempNPlayer
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub cmdCopyDown_Click(sender As System.Object, e As System.EventArgs) Handles cmdCopyDown.Click
        Try
            Dim tempValue As String = DataGridView2.Rows(DataGridView2.CurrentRow.Index).Cells(1).Value
            Dim tempIndex As Integer = DataGridView2.CurrentRow.Index

            For i As Integer = tempIndex + 1 To DataGridView2.RowCount - 1
                DataGridView2.Rows(i).Cells(1).Value = tempValue
            Next
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class