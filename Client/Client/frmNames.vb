Public Class frmNames
    Private Sub cmdSubmit_Click(sender As Object, e As EventArgs) Handles cmdSubmit.Click
        Try
            'If txtName.Text = "<Your Name Here>" Then Exit Sub
            'If txtName.Text.Trim = "" Then Exit Sub

            Dim str As String = ""

            str = launchID & ";"
            str &= "" & ";"

            wskClient.Send("SUBJECT_NAME", str)

            cmdSubmit.Visible = False

            If surveyLink <> "" Then
                'Process.Start("C:\Program Files\Google\Chrome\Application\chrome.exe", surveyLink & "&student_id=" & txtIDNumber.Text & " --incognito --kiosk")
                Process.Start("C:\Program Files\Google\Chrome\Application\chrome.exe", surveyLink & " --incognito --kiosk")
            End If

            Me.Close()
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub

    Private Sub frmNames_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cmdSubmit.Focus()
            Me.AcceptButton = cmdSubmit
        Catch ex As Exception
            appEventLog_Write("error :", ex)
        End Try
    End Sub
End Class