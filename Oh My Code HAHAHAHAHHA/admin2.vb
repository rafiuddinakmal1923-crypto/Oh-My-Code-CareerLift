Imports System.Data.OleDb
Imports System.IO

Public Class admin2

    Dim selectedPosterID As Integer = -1 ' To track the selected poster ID

    Private Sub RoundedButton6_Click(sender As Object, e As EventArgs) Handles btnUserFeedBack.Click
        Admin3.Show()
        Me.Hide()
    End Sub

    Private Sub FormPosterManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadPosters()
    End Sub

    Private Sub LoadPosters()

        Try
            con.Open()
            ' Clear previous data
            Dim cmd As New OleDbCommand("SELECT [Poster ID], [Company Email], [Poster Image], [Verification] FROM [Poster Database] ", con)

            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt

        Catch ex As Exception
            MessageBox.Show("Error loading posters: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        ' e = DataGridViewCellEventArgs
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)

            ' Display image
            If Not IsDBNull(row.Cells("Poster Image").Value) Then
                selectedPosterID = CInt(row.Cells("Poster ID").Value)
                Dim imageData As Byte() = CType(row.Cells("Poster Image").Value, Byte())
                Using ms As New MemoryStream(imageData)
                    PictureBox2.Image = Image.FromStream(ms)
                End Using
            Else
                PictureBox2.Image = Nothing
            End If
        End If
    End Sub

    Private Sub btnVerify_Click(sender As Object, e As EventArgs) Handles btnVerify.Click

        ' Check if a poster is selected
        If selectedPosterID = -1 Then
            MessageBox.Show("Please select a poster.")
        Else
            Try
                con.Open()
                Dim cmd As New OleDbCommand("UPDATE [Poster Database] SET [Verification] = 'Verified' WHERE [Poster ID] = ?", con)
                cmd.Parameters.AddWithValue("?", selectedPosterID)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Poster verified successfully.")
                con.Close()
                LoadPosters()
            Catch ex As Exception
                MessageBox.Show("Error verifying: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If

    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If selectedPosterID = -1 Then
            MessageBox.Show("Please select a poster.")
        Else
            Try
                con.Open()
                Dim cmd As New OleDbCommand("UPDATE [Poster Database] SET [Verification] = 'Rejected' WHERE [Poster ID] = ?", con)
                cmd.Parameters.AddWithValue("?", selectedPosterID)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Poster rejected successfully.")
                con.Close()
                LoadPosters()
            Catch ex As Exception
                MessageBox.Show("Error rejecting: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        ' Open file dialog to select an image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Try
                Dim imageData As Byte() = File.ReadAllBytes(filePath)
                Using ms As New MemoryStream(imageData)
                    PictureBox2.Image = Image.FromStream(ms)
                End Using
                ' Save to database
                con.Open()
                Dim cmd As New OleDbCommand("INSERT INTO [Poster Database] ([Poster Image], [Company Email]) VALUES (?, ?)", con)
                cmd.Parameters.AddWithValue("?", imageData)
                cmd.Parameters.AddWithValue("?", LoggedInEmail)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Poster uploaded successfully.")
                con.Close()
                LoadPosters()
            Catch ex As Exception
                MessageBox.Show("Error uploading poster: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        admin1vb.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnViewStatistics.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo, "Logout Confirmation")
        If result = MsgBoxResult.Yes Then
            Form4.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub admin2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton1_Click_1(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Admin4.Show()
        Me.Hide()

    End Sub
End Class