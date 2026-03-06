Imports System.Data.OleDb
Imports System.IO

Public Class interview
    Dim InterviewCompanyName As String = ""
    Dim selectedEmail As String = ""

    Private Sub interview_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        GetCompanyName()
        LoadApplicants()
    End Sub

    Private Sub GetCompanyName()
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Try
            con.Open()
            Dim query As String = "SELECT [Company Name] FROM [Company Information] WHERE [Company Email] =?"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader = cmd.ExecuteReader()
            If reader.Read() Then
                InterviewCompanyName = reader("Company Name").ToString()
            End If
        Catch ex As Exception
            MessageBox.Show("Error getting company name: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadApplicants()
        FlowApplicants.Controls.Clear()
        Try
            con.Open()
            Dim query As String = "SELECT * FROM [JobSeeker Application] WHERE [Company Applied] =? AND [Application Status] = 'Advanced'"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("?", InterviewCompanyName)
            Dim reader = cmd.ExecuteReader()

            While reader.Read()
                Dim jobseekerEmail = reader("Email").ToString()
                LoadJobSeekerInfo(jobseekerEmail)
            End While

        Catch ex As Exception
            MessageBox.Show("Error loading applicants: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadJobSeekerInfo(email As String)
        Try
            Using con2 As New OleDbConnection(con.ConnectionString)
                con2.Open()
                Dim query As String = "SELECT * FROM [JobSeeker Information] WHERE [Email] =?"
                Dim cmd As New OleDbCommand(query, con2)
                cmd.Parameters.AddWithValue("?", email)
                Dim reader = cmd.ExecuteReader()

                If reader.Read() Then
                    Dim uc As New CompanyInterview()
                    uc.ApplicantName = reader("Full Name").ToString()
                    uc.ApplicantInstitution = reader("Institution").ToString()
                    uc.ApplicantCGPA = reader("CGPA").ToString()
                    uc.ApplicantSkills = reader("Skills").ToString()
                    uc.ApplicantField = reader("Field Of Study").ToString()
                    uc.ApplicantEmail = reader("Email").ToString()

                    If Not IsDBNull(reader("Resume Path")) Then
                        uc.ApplicantResume = CType(reader("Resume Path"), Byte())
                    End If

                    If Not IsDBNull(reader("User Picture")) Then
                        Dim imgBytes = CType(reader("User Picture"), Byte())
                        Using ms As New MemoryStream(imgBytes)
                            uc.ApplicantProfileImage = Image.FromStream(ms)
                        End Using
                    End If

                    AddHandler uc.ApplicantClicked, AddressOf DisplayDetails
                    FlowApplicants.Controls.Add(uc)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading jobseeker info: " & ex.Message)
        End Try
    End Sub

    Private Sub DisplayDetails(applicant As CompanyInterview.Applicant)
        Panel2.Visible = True
        lblFullName.Text = "Name: " & applicant.Name
        lblInstitution.Text = "Institution: " & applicant.Institution
        lblCGPA.Text = "CGPA: " & applicant.CGPA
        lblField.Text = "Field: " & applicant.Field
        lblSkills.Text = applicant.Skills
        lblEmail.Text = "Email: " & applicant.Email
        selectedEmail = applicant.Email

        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT * FROM [JobSeeker Information] WHERE [Email] =?", con)
            cmd.Parameters.AddWithValue("?", applicant.Email)
            Dim reader = cmd.ExecuteReader()

            If reader.Read() Then
                lblPhone.Text = "Phone: " & reader("Phone Number").ToString()
                lblDOB.Text = "DOB: " & reader("Date Of Birth").ToString()
                lblGender.Text = "Gender: " & reader("Gender").ToString()
                lblAddress.Text = reader("Address").ToString()
                lblCity.Text = "City: " & reader("City").ToString()
                lblEducation.Text = "Education: " & reader("Education Level").ToString()
                lblGradYear.Text = "Graduation Year: " & reader("Graduation Year").ToString()
                lblExperience.Text = reader("Experience").ToString()
                If Not IsDBNull(reader("User Picture")) Then
                    Dim imgBytes = CType(reader("User Picture"), Byte())
                    Using ms As New MemoryStream(imgBytes)
                        picprofile.Image = Image.FromStream(ms)
                    End Using
                Else
                    picprofile.Image = Nothing

                End If
            End If
        Catch ex As Exception
            MessageBox.Show("Error loading additional applicant info: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnReject_Click(sender As Object, e As EventArgs) Handles btnReject.Click
        If selectedEmail = "" Then
            MessageBox.Show("Please select an applicant first.")
            Return
        End If

        If MessageBox.Show("Are you sure you want to reject this applicant?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            Try
                con.Open()
                Dim query As String = "UPDATE [JobSeeker Application] SET [Application Status] = 'Rejected' WHERE [Email] =? AND [Company Applied] =?"
                Dim cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("?", selectedEmail)
                cmd.Parameters.AddWithValue("?", InterviewCompanyName)
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error rejecting applicant: " & ex.Message)
            Finally
                con.Close()
                ClearLabels()
                LoadApplicants()
            End Try
        End If
    End Sub

    Private Sub btnViewResume_Click(sender As Object, e As EventArgs) Handles btnViewResume.Click
        If selectedEmail = "" Then
            MessageBox.Show("Please select an applicant first.")
            Return
        End If

        Try
            con.Open()
            Dim query As String = "SELECT [Resume Path] FROM [JobSeeker Information] WHERE [Email] =?"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("?", selectedEmail)
            Dim resumeBytes As Byte() = CType(cmd.ExecuteScalar(), Byte())

            If resumeBytes IsNot Nothing Then
                Dim tempPath As String = IO.Path.GetTempFileName().Replace(".tmp", ".pdf")
                IO.File.WriteAllBytes(tempPath, resumeBytes)
                Process.Start(tempPath)
            Else
                MessageBox.Show("No resume found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error viewing resume: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub btnAdvanceInterview_Click(sender As Object, e As EventArgs) Handles btnInviteForInterview.Click
        If selectedEmail = "" Then
            MessageBox.Show("Please select an applicant first.")
            Return
        End If

        Dim mode As String = If(rbtnOnline.Checked, "Online", If(rbtnPhysical.Checked, "Physical", ""))
        If mode = "" Then
            MessageBox.Show("Please select an interview mode.")
            Return
        End If

        Dim location As String = txtLocation.Text.Trim()
        If String.IsNullOrEmpty(location) Then
            MessageBox.Show("Please provide the interview location or link.")
            Return
        End If

        Try
            con.Open()
            Dim query As String = "UPDATE [JobSeeker Application] SET [Application Status] = 'Interview', [Interview Mode] =?, [Interview Date] =?, [Interview Time] =?, [Interview Link] =?, [Interview Location] =? WHERE [Email] =? AND [Company Applied] =?"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("?", mode)
            cmd.Parameters.AddWithValue("?", dtpDate.Value.ToShortDateString())
            cmd.Parameters.AddWithValue("?", dtpTime.Value.ToShortTimeString())
            cmd.Parameters.AddWithValue("?", If(mode = "Online", location, ""))
            cmd.Parameters.AddWithValue("?", If(mode = "Physical", location, ""))
            cmd.Parameters.AddWithValue("?", selectedEmail)
            cmd.Parameters.AddWithValue("?", InterviewCompanyName)
            cmd.ExecuteNonQuery()

            MessageBox.Show("Applicant successfully advanced to interview stage.")
        Catch ex As Exception
            MessageBox.Show("Error advancing to interview: " & ex.Message)
        Finally
            con.Close()
            ClearLabels()
            LoadApplicants()
        End Try
    End Sub

    Private Sub ClearLabels()
        lblFullName.Text = "Name :"
        lblEmail.Text = "Email :"
        lblPhone.Text = "Phone :"
        lblDOB.Text = "DOB :"
        lblGender.Text = "Gender :"
        lblAddress.Text = ""
        lblCity.Text = "City :"
        lblEducation.Text = "Education :"
        lblInstitution.Text = "Institution :"
        lblField.Text = "Field :"
        lblGradYear.Text = "Graduation Year :"
        lblCGPA.Text = "CGPA :"
        lblSkills.Text = ""
        lblExperience.Text = ""
        selectedEmail = ""
        picprofile.Image = Nothing
        txtLocation.Clear()
        dtpDate.Value = DateTime.Now
        dtpTime.Value = DateTime.Now
        rbtnOnline.Checked = False
        rbtnPhysical.Checked = False
        Panel2.Visible = False
    End Sub

    Private Sub btnViewApplicants_Click(sender As Object, e As EventArgs) Handles btnViewApplicants.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub btnFeedBack_Click(sender As Object, e As EventArgs) Handles btnFeedBack.Click
        Form3.Show()
    End Sub

    Private Sub btnPosting_Click(sender As Object, e As EventArgs) Handles btnPosting.Click
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form2.Show()
        Me.Hide()
    End Sub

    Private Sub Interview_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub


End Class
