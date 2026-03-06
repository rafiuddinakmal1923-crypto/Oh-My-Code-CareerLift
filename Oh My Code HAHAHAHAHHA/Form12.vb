Imports System.Data.OleDb
Imports System.IO

Public Class Form12

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
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

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnSearchJobs.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    '===== Resume Template Buttons =====

    Private Sub btnClassic_Click(sender As Object, e As EventArgs) Handles btnClassic.Click
        Try
            con.Open()
            Using cmd As New OleDbCommand("SELECT Template FROM [Resume Template] WHERE TemplateName = ?", con)
                cmd.Parameters.AddWithValue("?", "Classic")
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not IsDBNull(reader("Template")) Then
                        Dim fileData As Byte() = CType(reader("Template"), Byte())
                        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Classic_Resume.pdf")
                        File.WriteAllBytes(tempPath, fileData)
                        Process.Start(tempPath)
                    Else
                        MessageBox.Show("Template not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub btnModern_Click(sender As Object, e As EventArgs) Handles btnModern.Click
        Try
            con.Open()
            Using cmd As New OleDbCommand("SELECT Template FROM [Resume Template] WHERE TemplateName = ?", con)
                cmd.Parameters.AddWithValue("?", "Modern")
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not IsDBNull(reader("Template")) Then
                        Dim fileData As Byte() = CType(reader("Template"), Byte())
                        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Modern_Resume.pdf")
                        File.WriteAllBytes(tempPath, fileData)
                        Process.Start(tempPath)
                    Else
                        MessageBox.Show("Template not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub btnCreative_Click(sender As Object, e As EventArgs) Handles btnCreative.Click
        Try
            con.Open()
            Using cmd As New OleDbCommand("SELECT Template FROM [Resume Template] WHERE TemplateName = ?", con)
                cmd.Parameters.AddWithValue("?", "Creative")
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not IsDBNull(reader("Template")) Then
                        Dim fileData As Byte() = CType(reader("Template"), Byte())
                        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Creative_Resume.pdf")
                        File.WriteAllBytes(tempPath, fileData)
                        Process.Start(tempPath)
                    Else
                        MessageBox.Show("Template not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
    End Sub

    Private Sub btnProfessional_Click(sender As Object, e As EventArgs) Handles btnProfessional.Click
        Try
            con.Open()
            Using cmd As New OleDbCommand("SELECT Template FROM [Resume Template] WHERE TemplateName = ?", con)
                cmd.Parameters.AddWithValue("?", "Professional")
                Using reader As OleDbDataReader = cmd.ExecuteReader()
                    If reader.Read() AndAlso Not IsDBNull(reader("Template")) Then
                        Dim fileData As Byte() = CType(reader("Template"), Byte())
                        Dim tempPath As String = Path.Combine(Path.GetTempPath(), "Professional_Resume.pdf")
                        File.WriteAllBytes(tempPath, fileData)
                        Process.Start(tempPath)
                    Else
                        MessageBox.Show("Template not found.")
                    End If
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        End Try
        con.Close()
    End Sub
    Private Sub Form12_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If ConnectionState.Open = con.State Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class