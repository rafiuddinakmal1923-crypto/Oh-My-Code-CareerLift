Imports System.Data.OleDb
Imports System.IO

Public Class Form8
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPosting.Click
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnViewApplicants.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private posterList As New List(Of Byte())
    Private currentIndex As Integer = 0

    Private Sub FormPosterGallery_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPosters()
        DisplayCurrentPoster()
    End Sub

    Private Sub LoadPosters()
        posterList.Clear()
        Try
            con.Open()
            ' Only Choose verified poster = Verified
            Dim cmd As New OleDbCommand("SELECT [poster image] FROM [Poster Database] WHERE [Verification]='Verified'", con)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                If Not IsDBNull(reader("poster image")) Then
                    posterList.Add(CType(reader("poster image"), Byte()))
                End If
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading posters: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DisplayCurrentPoster()
        If posterList.Count > 0 AndAlso currentIndex >= 0 AndAlso currentIndex < posterList.Count Then
            Dim imgBytes As Byte() = posterList(currentIndex)
            Using ms As New MemoryStream(imgBytes)
                PictureBox1.Image = Image.FromStream(ms)
                PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
            End Using
        Else
            PictureBox1.Image = Nothing
        End If
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex + 1 < posterList.Count Then
            currentIndex += 1
            DisplayCurrentPoster()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex - 1 >= 0 Then
            currentIndex -= 1
            DisplayCurrentPoster()
        End If
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnView.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Form8_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub
End Class