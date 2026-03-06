Imports System.Data.OleDb
Imports System.IO

Public Class Job_Offering
    Dim InterviewCompanyName As String = ""
    Dim selectedEmail As String = ""

    Private Sub Job_Offering_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        GetCompanyName()
        LoadApplicants()
    End Sub

    Private Sub GetCompanyName()
        If con.State <> ConnectionState.Closed Then
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
        FlowInterviewee.Controls.Clear()
        Try
            con.Open()
            Dim query As String = "SELECT * FROM [JobSeeker Application] WHERE [Company Applied] =? AND [Application Status] = 'Interview'"
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
                    FlowInterviewee.Controls.Add(uc)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Error loading jobseeker info: " & ex.Message)
        End Try
    End Sub

    Private Sub DisplayDetails(applicant As CompanyInterview.Applicant)
        Panel3.Visible = True
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

        LoadInterviewDetails(selectedEmail, InterviewCompanyName)
    End Sub

    Private Sub LoadInterviewDetails(email As String, company As String)
        Try
            con.Open()
            Dim query As String = "SELECT [Interview Date], [Interview Time], [Interview Mode], [Interview Location], [Interview Link] FROM [JobSeeker Application] WHERE [Email]=? AND [Company Applied]=?"
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
            MessageBox.Show("Failed to open link: " & ex.Message)
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
        Panel3.Visible = False
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

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnUploadOfferLetter.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "PDF Files|*.pdf"
        openFileDialog.Title = "Select Offer Letter PDF"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim filePath As String = openFileDialog.FileName
            Dim fileData() As Byte = File.ReadAllBytes(filePath)

            Try
                con.Open()
                Dim query As String = "UPDATE [JobSeeker Application] SET [Offer Letter] = ? WHERE [Email] = ? AND [Company Applied] = ?"
                Dim cmd As New OleDbCommand(query, con)
                cmd.Parameters.AddWithValue("?", fileData)
                cmd.Parameters.AddWithValue("?", selectedEmail)
                cmd.Parameters.AddWithValue("?", InterviewCompanyName)

                Dim rowsAffected As Integer = cmd.ExecuteNonQuery()
                If rowsAffected > 0 Then
                    MessageBox.Show("Offer letter uploaded successfully.")
                Else
                    MessageBox.Show("No record updated. Please check the selected applicant.")
                End If

            Catch ex As Exception
                MessageBox.Show("Error uploading offer letter: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If

    End Sub

    Private Sub btnWelcomeOnBoard_Click(sender As Object, e As EventArgs) Handles btnWelcomeOnBoard.Click
        If selectedEmail = "" OrElse InterviewCompanyName = "" Then
            MessageBox.Show("Please select an applicant first.")
            Return
        End If

        Dim result As DialogResult = MessageBox.Show("Are you sure you want to mark this applicant as 'Welcome On Board'?", "Confirm", MessageBoxButtons.YesNo)
        If result = DialogResult.No Then
            Return
        End If

        Try
            con.Open()

            ' Check if Offer Letter exists
            Dim checkQuery As String = "SELECT [Offer Letter] FROM [JobSeeker Application] WHERE [Email] = ? AND [Company Applied] = ?"
            Dim checkCmd As New OleDbCommand(checkQuery, con)
            checkCmd.Parameters.AddWithValue("?", selectedEmail)
            checkCmd.Parameters.AddWithValue("?", InterviewCompanyName)

            Dim reader As OleDbDataReader = checkCmd.ExecuteReader()
            If reader.Read() Then
                If IsDBNull(reader("Offer Letter")) Then
                    MessageBox.Show("Please upload the offer letter before proceeding.")
                    reader.Close()
                    Return
                End If
            End If
            reader.Close()

            ' If offer letter exists, update status
            Dim updateQuery As String = "UPDATE [JobSeeker Application] SET [Application Status] = 'Welcome On Board' WHERE [Email] = ? AND [Company Applied] = ?"
            Dim updateCmd As New OleDbCommand(updateQuery, con)
            updateCmd.Parameters.AddWithValue("?", selectedEmail)
            updateCmd.Parameters.AddWithValue("?", InterviewCompanyName)
            updateCmd.ExecuteNonQuery()

            MessageBox.Show("Application status updated to 'Welcome On Board'.")

        Catch ex As Exception
            MessageBox.Show("Error: " & ex.Message)
        Finally
            con.Close()
        End Try

        ' ClearLabels()

        lblAddress.Text = ""
        lblCity.Text = "City :"
        lblEducation.Text = "Education :"
        lblInstitution.Text = "Institution :"
        lblField.Text = "Field :"
        lblGradYear.Text = "Graduation Year :"
        lblCGPA.Text = "CGPA :"
        lblSkills.Text = ""
        lblExperience.Text = ""
        picprofile.Image = Nothing
        lblFullName.Text = "Name :"
        lblEmail.Text = "Email :"
        lblPhone.Text = "Phone :"
        lblDOB.Text = "Date Of Birth :"
        lblGender.Text = "Gender :"
        lblAddress.Text = "Address :"
        lblCity.Text = "City :"
        lblEducation.Text = "Education :"
        lblGradYear.Text = "Graduation Year :"
        lblExperience.Text = "Experience :"
        txtDate.Text = ""
        txtTime.Text = ""
        txtMode.Text = ""
        txtLocation.Text = ""
        lblLink.Text = ""
        selectedEmail = ""
        LoadApplicants()


    End Sub

End Class
