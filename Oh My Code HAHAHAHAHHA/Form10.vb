Public Class Form10
    Private Sub btnResume_Click(sender As Object, e As EventArgs) Handles btnJobPosting.Click
        Form17.Show()
        Me.Hide()
    End Sub

    Private Sub btnGuidance_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        Form20.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub btnView_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form10_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class