Imports System.Data.OleDb
Imports System.IO

Public Class Admin3
    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        admin1vb.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles btnManagePoster.Click
        admin2.Show()
        Me.Hide()
    End Sub

    Private Sub Admin3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadFeedbackData()
    End Sub

    Private Sub LoadFeedbackData()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Feedback ID], [Email], [Message], [Suggestions], [Feedback], [Status] FROM [Customer Feedback]", con)
            Dim adapter As New OleDbDataAdapter(cmd)
            Dim dt As New DataTable()
            adapter.Fill(dt)
            DataGridView1.DataSource = dt
        Catch ex As Exception
            MessageBox.Show("Error loading feedback data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            ' Display feedback details in text boxes
            lblStatus.Text = row.Cells("Status").Value.ToString()
            lblType.Text = row.Cells("Feedback").Value.ToString()
            txtMessage.Text = row.Cells("Message").Value.ToString()
            txtSuggestions.Text = row.Cells("Suggestions").Value.ToString()
        End If
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo, "Logout Confirmation")
        If result = MsgBoxResult.Yes Then
            Form4.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to close the case?", MsgBoxStyle.YesNo, "Close Confirmation")
        If result = MsgBoxResult.Yes Then
            con.Open()
            Try
                Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
                If selectedRow IsNot Nothing Then
                    Dim feedbackId As Integer = CInt(selectedRow.Cells("Feedback ID").Value)
                    Dim cmd As New OleDbCommand("UPDATE [Customer Feedback] SET [Status] = 'Closed' WHERE [Feedback ID] = @FeedbackId", con)
                    cmd.Parameters.AddWithValue("@FeedbackId", feedbackId)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Case closed successfully.")
                    con.Close()
                    LoadFeedbackData() ' Refresh the data grid view
                Else
                    MessageBox.Show("Please select a feedback entry to close.")
                End If
            Catch ex As Exception
                MessageBox.Show("Error closing case: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub Admin3_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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