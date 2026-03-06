Imports System.Data.OleDb

Public Class Form21
    ' Job Posting structure
    Public Property JobTitle As String
    Public Property JobLocation As String
    Public Property EmploymentType As String
    Public Property Salary As String
    Public Property Deadline As String
    Public Property Description As String
    Public Property Skills As String
    Public Property LogoImage As Image
    Public Property Company_Name As String

    Private Function IsJobSeekerProfileComplete() As Boolean
        ' Check if the job seeker's profile is complete, preventing them from applying if not
        Dim isComplete As Boolean = False
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Full Name], [Phone Number], [Date Of Birth], [Gender], [Address], [City], [Education Level], [Institution], [Field Of Study], [Graduation Year], [CGPA], [Skills], [Experience] FROM [JobSeeker Information] WHERE Email = ?", con)
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
            MessageBox.Show("Error checking profile completeness: " & ex.Message)
        Finally
            con.Close()
        End Try
        Return isComplete
    End Function

    Private Sub Form21_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not IsJobSeekerProfileComplete() Then
            MessageBox.Show("Please complete your profile before applying to jobs.", "Incomplete Profile", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Me.Close()
            Form14.Show()
        Else

            lblTitle.Text = JobTitle
            lblLocation.Text = JobLocation
            lblType.Text = EmploymentType
            lblSalary.Text = Salary
            lblDeadline.Text = Deadline
            lblDescription.Text = Description
            lblSkills.Text = Skills
            picLogo.Image = LogoImage
            lblCompanyName.Text = Company_Name

            Dim cmd As New OleDbCommand("SELECT [Company Email], [Company Description], [Company Industry] FROM [Company Information] WHERE [Company Name] = ?", con)
            cmd.Parameters.AddWithValue("?", Company_Name)
            Try
                con.Open()
                Dim reader As OleDbDataReader = cmd.ExecuteReader()
                If reader.Read() Then
                    lblEmail.Text = reader("Company Email").ToString()
                    lblCompanyDescription.Text = reader("Company Description").ToString()
                    lblIndustry.Text = reader("Company Industry").ToString()
                Else
                    MessageBox.Show("Company information not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End If
            Catch ex As Exception
                MessageBox.Show("Error loading company information: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Finally
                con.Close()
            End Try
        End If

    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            con.Open()

            ' STEP 1: Check if already applied (same job, same company, same deadline)
            Dim checkCmd As New OleDbCommand("
            SELECT COUNT(*) FROM [JobSeeker Application] 
            WHERE [Job Title] = ? AND [Email] = ? AND [Company Applied] = ? AND [Application Deadline] = ?", con)

            checkCmd.Parameters.AddWithValue("?", JobTitle)
            checkCmd.Parameters.AddWithValue("?", LoggedInEmail)
            checkCmd.Parameters.AddWithValue("?", lblCompanyName.Text)
            checkCmd.Parameters.AddWithValue("?", DateTime.Parse(lblDeadline.Text)) ' make sure this is a valid DateTime

            Dim alreadyApplied As Integer = CInt(checkCmd.ExecuteScalar())
            If alreadyApplied > 0 Then
                MessageBox.Show("You have already applied to this exact job posting.", "Duplicate Application", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Else
                Try
                    Dim cmd As New OleDbCommand("
                    INSERT INTO [JobSeeker Application] 
                    ( [Job Title], Email, [Company Applied], [Application Type], Salary, [Location],[Application Deadline]) 
                    VALUES (?, ?, ?, ?, ?, ?, ?)", con)

                    cmd.Parameters.AddWithValue("?", JobTitle)
                    cmd.Parameters.AddWithValue("?", LoggedInEmail)
                    cmd.Parameters.AddWithValue("?", lblCompanyName.Text)
                    cmd.Parameters.AddWithValue("?", EmploymentType)
                    cmd.Parameters.AddWithValue("?", Salary)
                    cmd.Parameters.AddWithValue("?", JobLocation)
                    cmd.Parameters.AddWithValue("?", DateTime.Parse(lblDeadline.Text))


                    cmd.ExecuteNonQuery()

                    MessageBox.Show("Thank you for applying!", "Application Received", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.Close()
                Catch ex As Exception
                    MessageBox.Show("Error submitting application: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End If
        Catch ex As Exception
            MessageBox.Show("Error checking application status: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try


    End Sub

End Class