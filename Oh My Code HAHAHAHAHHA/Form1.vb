Imports System.Data.OleDb

Public Class Form1

    Private ApplicantsList As New List(Of Applicants)
    Private currentIndex As Integer = 0
    Private companyNameCache As String = ""
    Private selectedStatusFilter As String = "" ' "" = all, "Approved", "Pending", "Rejected"

    Public Class Applicants
        Public Property Email As String
        Public Property AppliedJobTitle As String
        Public Property ApplicantsName As String
        Public Property ApplicantsInstitutions As String
        Public Property ApplicantsCGPA As String
        Public Property ApplicantsField As String
        Public Property ResumeData As Byte()
        Public Property ApplicantsSkills As String
        Public Property ApplicantsImage As Image
        Public Property ApplicationStatus As String
    End Class

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    Private Sub LoadFilteredApplicants()
        ApplicantsList.Clear()

        Try
            con.Open()

            If companyNameCache = "" Then
                Using cmd As New OleDbCommand("SELECT [Company Name] FROM [Company Information] WHERE [Company Email] = ?", con)
                    cmd.Parameters.AddWithValue("?", LoggedInEmail)
                    Using r = cmd.ExecuteReader()
                        If r.Read() Then
                            companyNameCache = r("Company Name").ToString()
                        End If
                    End Using
                End Using
            End If

            If companyNameCache = "" Then
                MessageBox.Show("Company not found.")
                Exit Sub
            End If

            Dim keyword As String = txtSearch.Text.Trim()
            Dim statusCondition As String = ""
            If selectedStatusFilter <> "" Then
                statusCondition = " AND [Application Status] = ?"
            End If

            Dim applicantApps As New List(Of (Email As String, JobTitle As String, Status As String))

            Using cmd As New OleDbCommand(
                "SELECT [Email], [Job Title], [Application Status] FROM [JobSeeker Application] " &
                "WHERE [Company Applied] = ? AND [Job Title] LIKE ?" & statusCondition, con)

                cmd.Parameters.AddWithValue("?", companyNameCache)
                cmd.Parameters.AddWithValue("?", "%" & keyword & "%")
                If selectedStatusFilter <> "" Then
                    cmd.Parameters.AddWithValue("?", selectedStatusFilter)
                End If

                Using r = cmd.ExecuteReader()
                    While r.Read()
                        applicantApps.Add((
                            r("Email").ToString(),
                            r("Job Title").ToString(),
                            r("Application Status").ToString()
                        ))
                    End While
                End Using
            End Using

            For Each app In applicantApps
                Using infoCmd As New OleDbCommand(
                    "SELECT [Full Name], [Institution], [CGPA], [Field Of Study], [Skills], [User Picture], [Resume Path] " &
                    "FROM [JobSeeker Information] WHERE Email = ?", con)

                    infoCmd.Parameters.AddWithValue("?", app.Email)
                    Using r = infoCmd.ExecuteReader()
                        If r.Read() Then
                            Dim a As New Applicants With {
                                .Email = app.Email,
                                .AppliedJobTitle = app.JobTitle,
                                .ApplicantsName = r("Full Name").ToString(),
                                .ApplicantsInstitutions = r("Institution").ToString(),
                                .ApplicantsCGPA = r("CGPA").ToString(),
                                .ApplicantsField = r("Field Of Study").ToString(),
                                .ApplicantsSkills = r("Skills").ToString(),
                                .ApplicationStatus = app.Status
                            }

                            If Not IsDBNull(r("User Picture")) Then
                                Using ms As New IO.MemoryStream(CType(r("User Picture"), Byte()))
                                    a.ApplicantsImage = Image.FromStream(ms)
                                End Using
                            End If
                            If Not IsDBNull(r("Resume Path")) Then
                                a.ResumeData = CType(r("Resume Path"), Byte())
                            End If
                            ApplicantsList.Add(a)
                        End If
                    End Using
                End Using
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading applicants: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DisplayApplicants()
        Dim maxDisplay As Integer = 6
        Dim controlsCount As Integer = Math.Min(maxDisplay, ApplicantsList.Count - currentIndex)

        Dim btnResumes = New List(Of Button) From {btnViewResume1, btnViewResume2, btnViewResume3, btnViewResume4, btnViewResume5, btnViewResume6}
        Dim btnApproves = New List(Of Button) From {btnApprove1, btnApprove2, btnApprove3, btnApprove4, btnApprove5, btnApprove6}
        Dim btnRejects = New List(Of Button) From {btnReject1, btnReject2, btnReject3, btnReject4, btnReject5, btnReject6}
        Dim lblNames = New List(Of Label) From {lblName1, lblName2, lblName3, lblName4, lblName5, lblName6}
        Dim lblInstitutions = New List(Of Label) From {lblInstitution1, lblInstitution2, lblInstitution3, lblInstitution4, lblInstitution5, lblInstitution6}
        Dim lblCGPAs = New List(Of Label) From {lblCGPA1, lblCGPA2, lblCGPA3, lblCGPA4, lblCGPA5, lblCGPA6}
        Dim lblFields = New List(Of Label) From {lblField1, lblField2, lblField3, lblField4, lblField5, lblField6}
        Dim lblSkills = New List(Of Label) From {lblSkills1, lblSkills2, lblSkills3, lblSkills4, lblSkills5, lblSkills6}
        Dim picLogos = New List(Of PictureBox) From {ProfileImage1, ProfileImage2, ProfileImage3, ProfileImage4, ProfileImage5, ProfileImage6}

        For Each b In btnResumes : RemoveHandler b.Click, AddressOf ViewResume_Click : Next
        For Each b In btnApproves : RemoveHandler b.Click, AddressOf Approve_Click : Next
        For Each b In btnRejects : RemoveHandler b.Click, AddressOf Reject_Click : Next

        For i = 0 To 5
            If i < controlsCount Then
                Dim a = ApplicantsList(currentIndex + i)
                lblNames(i).Text = "Name : " & a.ApplicantsName
                lblInstitutions(i).Text = "Institution : " & a.ApplicantsInstitutions
                lblCGPAs(i).Text = "CGPA : " & a.ApplicantsCGPA
                lblFields(i).Text = "Field : " & a.ApplicantsField
                lblSkills(i).Text = "Skills : " & a.ApplicantsSkills
                picLogos(i).Image = a.ApplicantsImage
                btnResumes(i).Visible = True : btnResumes(i).Tag = a
                btnApproves(i).Visible = True : btnApproves(i).Tag = a
                btnRejects(i).Visible = True : btnRejects(i).Tag = a
                AddHandler btnResumes(i).Click, AddressOf ViewResume_Click
                If a.ApplicationStatus = "Pending" Or a.ApplicationStatus = "Rejected" Then
                    btnApproves(i).Visible = True : btnApproves(i).Tag = a
                    btnRejects(i).Visible = True : btnRejects(i).Tag = a
                    AddHandler btnApproves(i).Click, AddressOf Approve_Click
                    AddHandler btnRejects(i).Click, AddressOf Reject_Click
                Else
                    btnApproves(i).Visible = False
                    btnRejects(i).Visible = False
                End If
            Else
                lblNames(i).Text = ""
                lblInstitutions(i).Text = ""
                lblCGPAs(i).Text = ""
                lblFields(i).Text = ""
                lblSkills(i).Text = ""
                picLogos(i).Image = Nothing

                btnResumes(i).Visible = False
                btnApproves(i).Visible = False
                btnRejects(i).Visible = False
            End If
        Next
    End Sub

    Private Sub ViewResume_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        Dim a = TryCast(btn.Tag, Applicants)
        If a IsNot Nothing AndAlso a.ResumeData IsNot Nothing Then
            Dim tempPath = IO.Path.Combine(IO.Path.GetTempPath(), $"{a.ApplicantsName}_Resume.pdf")
            IO.File.WriteAllBytes(tempPath, a.ResumeData)
            Process.Start(tempPath)
        Else
            MessageBox.Show("No resume found.")
        End If
    End Sub

    Private Sub Approve_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        Dim a = TryCast(btn.Tag, Applicants)
        If a Is Nothing Then Return
        If MessageBox.Show("Advance this applicant for Interview ?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            UpdateApplicationStatus(a.Email, a.AppliedJobTitle, "Advanced")
        End If
    End Sub

    Private Sub Reject_Click(sender As Object, e As EventArgs)
        Dim btn = CType(sender, Button)
        Dim a = TryCast(btn.Tag, Applicants)
        If a Is Nothing Then Return
        If MessageBox.Show("Reject this application?", "Confirm", MessageBoxButtons.YesNo) = DialogResult.Yes Then
            UpdateApplicationStatus(a.Email, a.AppliedJobTitle, "Rejected")
        End If
    End Sub

    Private Sub UpdateApplicationStatus(email As String, jobTitle As String, status As String)
        Try
            con.Open()
            Using cmd As New OleDbCommand("UPDATE [JobSeeker Application] SET [Application Status] = ? WHERE Email = ? AND [Company Applied] = ? AND [Job Title] = ?", con)
                cmd.Parameters.AddWithValue("?", status)
                cmd.Parameters.AddWithValue("?", email)
                cmd.Parameters.AddWithValue("?", companyNameCache)
                cmd.Parameters.AddWithValue("?", jobTitle)
                cmd.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Error updating status: " & ex.Message)
        Finally
            con.Close()
        End Try

        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    ' === Status Filter Buttons ===
    Private Sub btnShowApproved_Click(sender As Object, e As EventArgs) Handles btnShowApproved.Click
        selectedStatusFilter = "Advanced"
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    Private Sub btnShowPending_Click(sender As Object, e As EventArgs) Handles btnShowPending.Click
        selectedStatusFilter = "Pending"
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    Private Sub btnShowRejected_Click(sender As Object, e As EventArgs) Handles btnShowRejected.Click
        selectedStatusFilter = "Rejected"
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    Private Sub btnShowAll_Click(sender As Object, e As EventArgs) Handles btnShowAll.Click
        selectedStatusFilter = "" ' Kosongkan filter status
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub


    ' === Search Box ===
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    ' === Navigation ===
    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex + 6 < ApplicantsList.Count Then
            currentIndex += 6
            DisplayApplicants()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex - 6 >= 0 Then
            currentIndex -= 6
            DisplayApplicants()
        End If
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

    Private Sub Form1_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Interview.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        Job_Offering.Show()
        Me.Hide()
    End Sub

    Private Sub btnShowInterview_Click(sender As Object, e As EventArgs) Handles btnShowInterview.Click
        selectedStatusFilter = "Interview"
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub

    Private Sub btnShowOnBoard_Click(sender As Object, e As EventArgs) Handles btnShowOnBoard.Click
        selectedStatusFilter = "Welcome On Board"
        currentIndex = 0
        LoadFilteredApplicants()
        DisplayApplicants()
    End Sub
End Class
