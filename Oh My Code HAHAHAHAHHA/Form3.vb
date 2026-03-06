Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Public Class Form3
    Dim result As String
    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnSend.Click
        ' Validate input
        Dim Message As String = txtMessage.Text
        Dim Suggestions As String = txtSuggestions.Text
        con.Open()
        Dim cmd As New OleDbCommand("INSERT INTO [Customer Feedback] (Email, [Message], [Suggestions]) VALUES (?, ?, ?)", con)
        cmd.Parameters.AddWithValue("?", LoggedInEmail)
        cmd.Parameters.AddWithValue("?", Message)
        cmd.Parameters.AddWithValue("?", Suggestions)
        cmd.ExecuteNonQuery()
        con.Close()
        MessageBox.Show("Thank you for your feedback!", "Feedback Sent", MessageBoxButtons.OK, MessageBoxIcon.Information)
        txtMessage.Clear()
        txtSuggestions.Clear()
    End Sub

    Private Sub btnPositive_Click(sender As Object, e As EventArgs) Handles btnPositive.Click, btnNegative.Click

        Dim FeedbackType As Button = CType(sender, Button)

        If btnPositive Is FeedbackType Then
            result = "Positive"
        ElseIf btnNegative Is FeedbackType Then
            result = "Negative"
        End If

    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        If result = "Positive" Then
            MessageBox.Show("Thank you for your positive feedback!", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information)
        ElseIf result = "Negative" Then
            MessageBox.Show("We're sorry to hear that. Please let us know how we can improve.", "Feedback", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Please provide feedback before proceeding.", "Feedback Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If

    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnFaq1.Click
        MsgBox("Go to your profile and hover over it. Click 'Reset Password' to change it.", MsgBoxStyle.Information, "Reset Password")
    End Sub

    Private Sub btnfaq2_Click(sender As Object, e As EventArgs) Handles btnfaq2.Click
        MsgBox("Click on the 'Profile' tab at the top and update your details there.", MsgBoxStyle.Information, "Update Profile")
    End Sub
    Private Sub btnfaq3_Click(sender As Object, e As EventArgs) Handles btnFaq3.Click
        MsgBox("Not yet, but we’re working on it. Please use our website for now.", MsgBoxStyle.Information, "Mobile App Availability")
    End Sub
    Private Sub btnFaq4_Click(sender As Object, e As EventArgs) Handles btnFaq4.Click
        MsgBox("Go to the 'Feedback' page or email us at support@careerlift.com.", MsgBoxStyle.Information, "Contact Support")
    End Sub

    Private Sub btnBack_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Me.Close()
    End Sub
End Class