Public Class Form11
    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        Form13.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnSearchJobs.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Form11_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton1_Click_1(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Form18.Show()
    End Sub
End Class