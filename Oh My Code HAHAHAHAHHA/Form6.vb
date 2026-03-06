Imports System.Data.OleDb
Public Class Form6
    Dim purchase As String = "Free" ' Default plan for demonstration purposes
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnResume.Click
        Dim plan As String = GetUserSubscriptionPlan()

        If plan = "Free" Then
            MessageBox.Show("You are currently on the Free plan. Please upgrade to access this feature.", "Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form7.Show()
        Else
            Form12.Show()
        End If
        Me.Hide()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles btnGuidance.Click
        Dim plan As String = GetUserSubscriptionPlan()
        Dim availabletokens As Integer = GetUserTokens()

        If plan <> "Exclusive" Then
            MessageBox.Show("You have not purchased any tokens. Please purchase Add-Ons to access this feature.", "Upgrade Required", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form7.Show()
        Else
            ' Show the tokens available
            MsgBox("Current tokens in your account = " & availabletokens, MsgBoxStyle.Information, "Tokens")
            Form11.Show()
        End If
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnSearchJobs.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub Form6_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub
End Class