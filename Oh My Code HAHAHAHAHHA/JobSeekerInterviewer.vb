Imports System.Data.OleDb
Imports System.IO

Public Class JobSeekerInterviewer
    Dim SelectedEmail As String = ""

    Private Sub JobSeekerInterviewer_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadInterviewApplications()
        Panel2.Visible = False
        lblCompanyFullName.Text = ""
        lblJobTitle.Text = ""
        lblEmploymentType.Text = ""
        lblSalary.Text = ""
        lblJobSkills.Text = ""
        lblIndustry.Text = ""
        lblSize.Text = ""
        lblCompanyDescription.Text = ""
        lblLocation.Text = ""
        txtDate.Text = ""
        txtTime.Text = ""
        txtMode.Text = ""
        txtLocation.Text = ""
        lblLink.Visible = False
        picprofile.Image = Nothing
        lblLink.Text = ""
        lblStatus.Text = ""


    End Sub

    Private Sub LoadInterviewApplications()
        FlowInterviewer.Controls.Clear()

        Dim query As String = "SELECT * FROM [JobSeeker Application] WHERE [Email] = ? AND [Application Status] = 'Interview'"
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("?", loggedInEmail)

        Try
            con.Open()
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            'If Not reader.HasRows Then
            '    reader.Close()
            '    MessageBox.Show("You have no interviews scheduled at the moment. Redirecting to job listings.", "No Interviews", MessageBoxButtons.OK, MessageBoxIcon.Information)
            '    Me.Close()
            '    Form14.Show()
            '    Exit Sub
            'End If

            While reader.Read()
                Dim companyName As String = reader("Company Applied").ToString()
                Dim jobTitle As String = reader("Job Title").ToString()

                ' Get company info
                Dim compCmd As New OleDbCommand("SELECT * FROM [Company Information] WHERE [Company Name] = ?", con)
                compCmd.Parameters.AddWithValue("?", companyName)
                Dim compReader As OleDbDataReader = compCmd.ExecuteReader()

                Dim industry As String = "", size As String = "", compDesc As String = "", logo As Image = Nothing, location As String = ""

                If compReader.Read() Then
                    industry = compReader("Company Industry").ToString()
                    size = compReader("Company Size").ToString()
                    compDesc = compReader("Company Description").ToString()
                    location = compReader("Location").ToString()

                    If Not IsDBNull(compReader("Logo Path")) Then
                        Dim bytes() As Byte = CType(compReader("Logo Path"), Byte())
                        Using ms As New MemoryStream(bytes)
                            logo = Image.FromStream(ms)
                        End Using
                    End If
                End If
                compReader.Close()

                ' Get job info
                Dim jobCmd As New OleDbCommand("SELECT * FROM [Job Posting] WHERE [Company Name] = ? AND [Job Title] = ?", con)
                jobCmd.Parameters.AddWithValue("?", companyName)
                jobCmd.Parameters.AddWithValue("?", jobTitle)
                Dim jobReader As OleDbDataReader = jobCmd.ExecuteReader()

                Dim employmentType As String = "", salary As String = "", jobDesc As String = "", skills As String = ""

                If jobReader.Read() Then
                    employmentType = jobReader("Employment Type").ToString()
                    salary = jobReader("Salary").ToString()
                    jobDesc = jobReader("Job Description").ToString()
                    skills = jobReader("Skills").ToString()
                End If
                jobReader.Close()

                ' Create and populate InterviewAcceptance UserControl
                Dim uc As New InterviewAcceptance()
                uc.InterviewerCompanyName = companyName
                uc.JobTitleOffered = jobTitle
                uc.InterviewEmploymentType = employmentType
                uc.InterviewSalary = salary
                uc.InterviewCompanyLocation = location
                uc.interviewerCompanyEmail = reader("Email").ToString() ' adjust if needed
                uc.InterviewerrCompanyImage = logo

                AddHandler uc.ApplicantClicked, AddressOf OnApplicantClicked
                FlowInterviewer.Controls.Add(uc)
            End While
            reader.Close()

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    ' Triggered when applicant is clicked from InterviewAcceptance control
    Private Sub OnApplicantClicked(applicant As InterviewAcceptance.Interviewer)
        ' make all visible = false to visible = true
        Panel2.Visible = True
        lblDescription.Visible = True
        LabelJobTitle.Visible = True
        LabelEmploymentType.Visible = True
        LabelSalary.Visible = True
        labelLocation.Visible = True
        labelDescription.Visible = True
        LabelHeader2.Visible = True
        lblHeader1.Visible = True
        LabelDate.Visible = True
        LabelTime.Visible = True
        LabelMode.Visible = True
        labelLocation.Visible = True
        Labelstatus.Visible = True

        lblCompanyFullName.Text = applicant.CompanyName
        lblJobTitle.Text = applicant.JobTitle
        lblEmploymentType.Text = applicant.EmploymentType
        lblSalary.Text = applicant.Salary
        lblLocation.Text = applicant.CompanyLocation
        SelectedEmail = applicant.Email
        picprofile.Image = applicant.ProfileImage

        Try
            con.Open()

            ' --- Get Company Info ---
            Dim compCmd As New OleDbCommand("SELECT * FROM [Company Information] WHERE [Company Name] = ?", con)
            compCmd.Parameters.AddWithValue("?", applicant.CompanyName)
            Dim compReader As OleDbDataReader = compCmd.ExecuteReader()
            If compReader.Read() Then
                lblIndustry.Text = "Industry : " & compReader("Company Industry").ToString()
                lblSize.Text = "Size : " & compReader("Company Size").ToString()
                lblCompanyDescription.Text = compReader("Company Description").ToString()
            End If
            compReader.Close()

            ' --- Get Job Posting Info ---
            Dim jobCmd As New OleDbCommand("SELECT * FROM [Job Posting] WHERE [Job Title] = ? AND [Company Name] = ?", con)
            jobCmd.Parameters.AddWithValue("?", applicant.JobTitle)
            jobCmd.Parameters.AddWithValue("?", applicant.CompanyName)
            Dim jobReader As OleDbDataReader = jobCmd.ExecuteReader()
            If jobReader.Read() Then
                lblJobDescription.Text = jobReader("Job Description").ToString()
                lblJobSkills.Text = jobReader("Skills").ToString()
                lblJobSkills.Text = jobReader("Skills").ToString()

            End If
            jobReader.Close()

        Catch ex As Exception
            MessageBox.Show("Error fetching detailed info: " & ex.Message)
        End Try

        LoadInterviewDetails(applicant.Email, applicant.CompanyName)

    End Sub

    Private Sub LoadInterviewDetails(email As String, company As String)

        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Try
            con.Open()
            Dim query As String = "SELECT [Interview Date], [Interview Time], [Interview Mode], [Interview Location], [Interview Link], [Application Status] FROM [JobSeeker Application] WHERE [Email]=? AND [Company Applied]=?"
            Dim cmd As New OleDbCommand(query, con)
            cmd.Parameters.AddWithValue("?", email)
            cmd.Parameters.AddWithValue("?", company)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                If Not IsDBNull(reader("Interview Date")) Then
                    txtDate.Text = Convert.ToDateTime(reader("Interview Date"))
                End If
                If Not IsDBNull(reader("Interview Time")) Then
                    txtTime.Text = Convert.ToDateTime(reader("Interview Time"))
                End If
                If Not IsDBNull(reader("Application Status")) Then
                    lblStatus.Text = reader("Application Status").ToString()
                End If

                Dim mode As String = reader("Interview Mode").ToString()
                If mode = "Online" Then
                    txtMode.Text = "Online"
                    lblLink.Visible = True
                    lblLink.Text = reader("Interview Link").ToString()
                    lblLink.ForeColor = Color.Blue
                    lblLink.Cursor = Cursors.Hand
                    AddHandler lblLink.Click, AddressOf lblLink_Click
                ElseIf mode = "Physical" Then
                    txtMode.Text = "Physical"
                    txtLocation.Text = reader("Interview Location").ToString()
                    lblLink.Visible = False
                End If
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading interview details: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub lblLink_Click(sender As Object, e As EventArgs)
        Try
            Process.Start(lblLink.Text)
        Catch ex As Exception
            MessageBox.Show("Unable to open link: " & ex.Message)
        End Try
    End Sub


    Private Sub btnViewJobs_Click(sender As Object, e As EventArgs) Handles btnViewJobs.Click
        Form14.Show()
        Me.Hide()
    End Sub

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub btnFeedBack_Click(sender As Object, e As EventArgs) Handles btnFeedBack.Click
        Form3.Show()
    End Sub

    Private Sub btnSubscription_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub btnProfile_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub JobSeekerInterviewer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
