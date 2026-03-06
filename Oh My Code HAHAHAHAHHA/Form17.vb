Imports System.Data.OleDb
Imports System.Diagnostics.Tracing

Public Class Form17

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnViewApplicants.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnPosting.Click
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub FieldChanged(sender As Object, e As EventArgs) Handles txtJobTitle.TextChanged, txtSalary.TextChanged,
    txtLocation.TextChanged, txtSkils.TextChanged, txtjobDescription.TextChanged, cboEmploymentType.SelectedIndexChanged, dtpDeadline.ValueChanged

        UpdateProgress()
    End Sub

    Private Function IsCompanyProfileComplete() As Boolean
        Dim isComplete As Boolean = False
        ' Check if the company profile is complete
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Company Name], [Company Size], [Company Industry], [Contact Person Name], [Contact Person Number], [Company Description], [Logo Path], [SSM Attachment] FROM [Company Information] WHERE [Company Email] = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                isComplete = True
                For i As Integer = 0 To reader.FieldCount - 1
                    If IsDBNull(reader(i)) OrElse reader(i).ToString().Trim() = "" Then
                        isComplete = False
                        Exit For
                    End If
                Next
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error checking company profile: " & ex.Message)
        Finally
            con.Close()
        End Try
        Return isComplete
    End Function

    Private Sub UpdateProgress()
        Dim totalFields As Integer = 7
        Dim filledFields As Integer = 0

        If txtJobTitle.Text.Trim() <> "" Then filledFields += 1
        If txtSalary.Text.Trim() <> "" Then filledFields += 1
        If txtLocation.Text.Trim() <> "" Then filledFields += 1
        If txtSkils.Text.Trim() <> "" Then filledFields += 1
        If cboEmploymentType.SelectedIndex <> -1 Then filledFields += 1
        If txtjobDescription.Text.Trim() <> "" Then filledFields += 1
        If dtpDeadline.Value > DateTime.Today Then filledFields += 1

        Dim percent As Integer = CInt((filledFields / totalFields) * 100)
        pgbUpdate.Value = percent
        lblProgress.Text = "Your job posting is " & percent.ToString() & "% complete."
    End Sub

    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If Not IsCompanyProfileComplete() Then
            MessageBox.Show("Please complete your company profile before posting a job.", "Incomplete Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If



        ' STEP 1: find the logo and company name
        Dim logoBytes As Byte() = Nothing
        Dim companyName As String = ""
        Try
            con.Open()
            Dim getLogoCmd As New OleDbCommand("SELECT [Logo Path], [Company Name] FROM [Company Information] WHERE [Company Email] = ?", con)
            getLogoCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim logoReader As OleDbDataReader = getLogoCmd.ExecuteReader()
            If logoReader.Read() Then
                If Not IsDBNull(logoReader("Logo Path")) Then
                    logoBytes = CType(logoReader("Logo Path"), Byte())
                End If
                companyName = logoReader("Company Name").ToString()
            End If
            logoReader.Close()
        Catch ex As Exception
            MessageBox.Show("Error retrieving logo/company name: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            con.Close()
            Return
        End Try
        con.Close()

        ' STEP 2: Insert into Job Posting table
        If txtJobTitle.Text = "" Or txtSalary.Text = "" Or txtLocation.Text = "" Or txtSkils.Text = "" Or cboEmploymentType.SelectedIndex = -1 Or txtjobDescription.Text = "" Or dtpDeadline.Value <= DateTime.Today Then
            MessageBox.Show("Please fill in all fields before saving.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Try
                con.Open()
                Dim cmd As New OleDbCommand("INSERT INTO [Job Posting] 
            ([Email], [Job Title], [Location], [Employment Type], [Salary], [Application Deadline], [Skills], [Job Description], [Logo Path], [Company Name]) 
            VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", con)

                cmd.Parameters.AddWithValue("?", LoggedInEmail)
                cmd.Parameters.AddWithValue("?", txtJobTitle.Text)
                cmd.Parameters.AddWithValue("?", txtLocation.Text)
                cmd.Parameters.AddWithValue("?", cboEmploymentType.Text)
                cmd.Parameters.AddWithValue("?", txtSalary.Text)
                cmd.Parameters.AddWithValue("?", dtpDeadline.Value) ' Application Deadline
                cmd.Parameters.AddWithValue("?", txtSkils.Text)
                cmd.Parameters.AddWithValue("?", txtjobDescription.Text)
                cmd.Parameters.AddWithValue("?", logoBytes)
                cmd.Parameters.AddWithValue("?", companyName)

                cmd.ExecuteNonQuery()
                MessageBox.Show("Job posted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                MessageBox.Show("Error posting job: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End If

        txtjobDescription.Clear()
        txtJobTitle.Clear()
        txtLocation.Clear()
        txtSkils.Clear()
        txtSalary.Clear()
        cboEmploymentType.SelectedIndex = -1
        dtpDeadline.Value = DateTime.Today

    End Sub

    ' === Job Title Validation ===
    Private Sub txtJobTitle_Leave(sender As Object, e As EventArgs) Handles txtJobTitle.Leave
        If txtJobTitle.Text.Trim() = "" Then
            MessageBox.Show("Job Title cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtJobTitle.BackColor = Color.MistyRose
            txtJobTitle.Focus()
        Else
            txtJobTitle.BackColor = Color.White
        End If
    End Sub

    ' === Salary Validation ===
    Private Sub txtSalary_Leave(sender As Object, e As EventArgs) Handles txtSalary.Leave
        Dim salary As Decimal
        If Not Decimal.TryParse(txtSalary.Text.Trim(), salary) OrElse salary <= 0 Then
            MessageBox.Show("Please enter a valid salary. (integer only)", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSalary.BackColor = Color.MistyRose
            txtSalary.Focus()
        Else
            txtSalary.BackColor = Color.White
        End If
    End Sub

    ' === Location Validation ===
    Private Sub txtLocation_Leave(sender As Object, e As EventArgs) Handles txtLocation.Leave
        If txtLocation.Text.Trim() = "" Then
            MessageBox.Show("Location cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtLocation.BackColor = Color.MistyRose
            txtLocation.Focus()
        Else
            txtLocation.BackColor = Color.White
        End If
    End Sub

    ' === Skills Validation ===
    Private Sub txtSkils_Leave(sender As Object, e As EventArgs) Handles txtSkils.Leave
        If txtSkils.Text.Trim() = "" Then
            MessageBox.Show("Please enter required skills.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtSkils.BackColor = Color.MistyRose
            txtSkils.Focus()
        Else
            txtSkils.BackColor = Color.White
        End If
    End Sub

    ' === Employment Type Validation ===
    Private Sub cboEmploymentType_Leave(sender As Object, e As EventArgs) Handles cboEmploymentType.Leave
        If cboEmploymentType.SelectedIndex = -1 Then
            MessageBox.Show("Please select an employment type.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            cboEmploymentType.BackColor = Color.MistyRose
            cboEmploymentType.Focus()
        Else
            cboEmploymentType.BackColor = Color.White
        End If
    End Sub

    ' === Job Description Validation ===
    Private Sub txtjobDescription_Leave(sender As Object, e As EventArgs) Handles txtjobDescription.Leave
        If txtjobDescription.Text.Trim() = "" Then
            MessageBox.Show("Job Description cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtjobDescription.BackColor = Color.MistyRose
            txtjobDescription.Focus()
        Else
            txtjobDescription.BackColor = Color.White
        End If
    End Sub

    ' === Deadline Validation ===
    Private Sub dtpDeadline_Leave(sender As Object, e As EventArgs) Handles dtpDeadline.Leave
        If dtpDeadline.Value <= DateTime.Today Then
            MessageBox.Show("Deadline must be a future date.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            dtpDeadline.CalendarMonthBackground = Color.MistyRose
            dtpDeadline.Focus()
        Else
            dtpDeadline.CalendarMonthBackground = Color.White
        End If
    End Sub


    Private Sub Form17_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class