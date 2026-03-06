Imports System.Data.OleDb
Imports System.IO

Public Class admin1vb

    Private dtCompany As DataTable
    Private dtSeeker As DataTable

    Private Sub admin1vb_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadCompanyData()
        LoadSeekerData()
    End Sub

    '================ Load Company Data ================
    Private Sub LoadCompanyData()
        Try
            con.Open()
            Dim query As String = "SELECT [Company ID], [Company Name], [Company Email], [User Type], [SSM Attachment], [Verified], [Blacklisted] FROM [Company Information]"
            Dim adapter As New OleDbDataAdapter(query, con)
            dtCompany = New DataTable()
            adapter.Fill(dtCompany)
            DataGridView1.DataSource = dtCompany
            If DataGridView1.Columns.Contains("SSM Attachment") Then
                DataGridView1.Columns("SSM Attachment").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading company data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    '================ Load Seeker Data ================
    Private Sub LoadSeekerData()
        Try
            con.Open()
            Dim query As String = "SELECT [JobSeeker ID], [Full Name], [Email], [User Type], [Resume Path], [Blacklisted] FROM [JobSeeker Information]"
            Dim adapter As New OleDbDataAdapter(query, con)
            dtSeeker = New DataTable()
            adapter.Fill(dtSeeker)
            DataGridView2.DataSource = dtSeeker
            If DataGridView2.Columns.Contains("Resume Path") Then
                DataGridView2.Columns("Resume Path").Visible = False
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading seeker data: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    '================ Filter Company ===================
    Private Sub txtCompanyFilter_TextChanged(sender As Object, e As EventArgs) Handles txtCompanyFilter.TextChanged
        Dim filterText As String = txtCompanyFilter.Text.ToLower()
        Dim filterExpr = $"[Company Name] LIKE '%{filterText}%' OR [Verified] LIKE '%{filterText}%' OR [Blacklisted] LIKE '%{filterText}%'"
        dtCompany.DefaultView.RowFilter = filterExpr
    End Sub

    '================ Filter Job Seeker ================
    Private Sub txtSeekerFilter_TextChanged(sender As Object, e As EventArgs) Handles txtSeekerFilter.TextChanged
        Dim filterText As String = txtSeekerFilter.Text.ToLower()
        Dim filterExpr = $"[Full Name] LIKE '%{filterText}%' OR [Email] LIKE '%{filterText}%'   OR [Blacklisted] LIKE '%{filterText}%'"
        dtSeeker.DefaultView.RowFilter = filterExpr
    End Sub

    '================ View SSM ========================
    Private Sub btnViewSSM_Click(sender As Object, e As EventArgs) Handles btnViewSSM.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim ssmData As Byte() = TryCast(DataGridView1.SelectedRows(0).Cells("SSM Attachment").Value, Byte())
            If ssmData IsNot Nothing Then
                Dim tempPath = Path.Combine(Path.GetTempPath(), "SSM_" & Guid.NewGuid().ToString() & ".pdf")
                File.WriteAllBytes(tempPath, ssmData)
                Process.Start(tempPath)
            Else
                MessageBox.Show("No SSM Attachment found.")
            End If
        End If
    End Sub

    '================ View Resume =====================
    Private Sub btnViewResume_Click(sender As Object, e As EventArgs) Handles btnViewResume.Click
        If DataGridView2.SelectedRows.Count > 0 Then
            Dim resumeData As Byte() = TryCast(DataGridView2.SelectedRows(0).Cells("Resume Path").Value, Byte())
            If resumeData IsNot Nothing Then
                Dim tempPath = Path.Combine(Path.GetTempPath(), "Resume_" & Guid.NewGuid().ToString() & ".pdf")
                File.WriteAllBytes(tempPath, resumeData)
                Process.Start(tempPath)
            Else
                MessageBox.Show("No resume found.")
            End If
        End If
    End Sub

    '================ Verify Company ==================
    Private Sub btnVerifyCompany_Click(sender As Object, e As EventArgs) Handles btnVerifyCompany.Click
        Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
        If selectedRow Is Nothing Then
            MessageBox.Show("Please select a company row to verify.")
            Return
        End If

        Dim companyId As String = selectedRow.Cells("Company ID").Value.ToString()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("UPDATE [Company Information] SET [Verified]='Verified' WHERE [Company ID]=?", con)
            cmd.Parameters.AddWithValue("?", companyId)
            cmd.ExecuteNonQuery()

            If selectedRow.Cells("Blacklisted").Value.ToString() = "Yes" Then
                Dim cmd2 As New OleDbCommand("UPDATE [Company Information] SET [Blacklisted]='No' WHERE [Company ID]=?", con)
                cmd2.Parameters.AddWithValue("?", companyId)
                cmd2.ExecuteNonQuery()
            End If

            MessageBox.Show("Company verified successfully.")
        Catch ex As Exception
            MessageBox.Show("Error verifying company: " & ex.Message)
        Finally
            con.Close()
            LoadCompanyData()
        End Try
    End Sub

    '================ Blacklist Company ===============
    Private Sub btnBlacklistCompany_Click(sender As Object, e As EventArgs) Handles btnBlacklistCompany.Click
        Dim selectedRow As DataGridViewRow = DataGridView1.CurrentRow
        If selectedRow Is Nothing Then
            MessageBox.Show("Please select a company row to blacklist.")
            Return
        End If

        If MessageBox.Show("Blacklist this company?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.No Then Return

        Dim companyId As String = selectedRow.Cells("Company ID").Value.ToString()
        Dim companyName As String = selectedRow.Cells("Company Name").Value.ToString()

        Try
            con.Open()
            Dim cmd1 As New OleDbCommand("UPDATE [Company Information] SET [Blacklisted]='Yes', [Verified]='Unverified' WHERE [Company ID]=?", con)
            cmd1.Parameters.AddWithValue("?", companyId)
            cmd1.ExecuteNonQuery()

            Dim cmd2 As New OleDbCommand("DELETE FROM [Job Posting] WHERE [Company Name]=?", con)
            cmd2.Parameters.AddWithValue("?", companyName)
            cmd2.ExecuteNonQuery()

            Dim cmd3 As New OleDbCommand("DELETE FROM [JobSeeker Application] WHERE [Company Applied]=?", con)
            cmd3.Parameters.AddWithValue("?", companyName)
            cmd3.ExecuteNonQuery()

            MessageBox.Show("Company blacklisted and related data removed.")
        Catch ex As Exception
            MessageBox.Show("Error blacklisting company: " & ex.Message)
        Finally
            con.Close()
            LoadCompanyData()
        End Try
    End Sub

    '================ Block Job Seeker ===============
    Private Sub btnBlockSeeker_Click(sender As Object, e As EventArgs) Handles btnBlockSeeker.Click
        If DataGridView2.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a seeker to block.")
            Return
        End If

        Dim seekerId = DataGridView2.SelectedRows(0).Cells("JobSeeker ID").Value.ToString()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [Blacklisted] = 'Yes' WHERE [JobSeeker ID] = ?", con)
            cmd.Parameters.AddWithValue("?", seekerId)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Job seeker blacklisted.")
        Catch ex As Exception
            MessageBox.Show("Error blocking seeker: " & ex.Message)
        Finally
            con.Close()
            LoadSeekerData()
        End Try
    End Sub

    '================ Undo Blacklist Seeker ===========
    Private Sub btnUndoBlockSeeker_Click(sender As Object, e As EventArgs) Handles btnUndoBlockSeeker.Click
        If DataGridView2.SelectedRows.Count = 0 Then
            MessageBox.Show("Please select a seeker to unblock.")
            Return
        End If

        Dim seekerId = DataGridView2.SelectedRows(0).Cells("JobSeeker ID").Value.ToString()

        Try
            con.Open()
            Dim cmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [Blacklisted] = 'No' WHERE [JobSeeker ID] = ?", con)
            cmd.Parameters.AddWithValue("?", seekerId)
            cmd.ExecuteNonQuery()
            MessageBox.Show("Blacklist removed for job seeker.")
        Catch ex As Exception
            MessageBox.Show("Error unblocking seeker: " & ex.Message)
        Finally
            con.Close()
            LoadSeekerData()
        End Try
    End Sub

    '================ Navigation =======================
    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnViewStatistics.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles btnManagePosters.Click
        admin2.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles btnUserFeedbacks.Click
        Admin3.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        If MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Form4.Show()
            Me.Hide()
        End If
    End Sub

    Private Sub admin1vb_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Admin4.Show()
        Me.Hide()
    End Sub
End Class
