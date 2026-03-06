Public Class Form13


    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedBack.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnJobSearch.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub


    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles btnBook1.Click, btnBook2.Click, btnBook3.Click, btnBook4.Click
        Dim button As Button = CType(sender, Button)

        If sender Is btnBook1 Then
            ConsultantName = "Michelle"
            Consultantpicture = ImageToByteArray(ConsultantProfile1.Image)
        ElseIf sender Is btnBook2 Then
            ConsultantName = "David"
            Consultantpicture = ImageToByteArray(ConsultantProfile2.Image)
        ElseIf sender Is btnBook3 Then
            ConsultantName = "Ana"
            Consultantpicture = ImageToByteArray(ConsultantProfile3.Image)
        ElseIf sender Is btnBook4 Then
            ConsultantName = "James"
            Consultantpicture = ImageToByteArray(ConsultantProfile4.Image)
        End If
        Form23.Show()
    End Sub

    Private Function ImageToByteArray(img As Image) As Byte()
        Using ms As New System.IO.MemoryStream()
            img.Save(ms, Imaging.ImageFormat.Jpeg)
            Return ms.ToArray()
        End Using
    End Function

    Private Sub Form13_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class