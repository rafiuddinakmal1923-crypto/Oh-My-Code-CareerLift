Imports System.Data.OleDb

Public Class Form14

    Private jobList As New List(Of JobPosting)
    Private currentDisplayList As New List(Of JobPosting) ' NEW: display list
    Private currentIndex As Integer = 0

    ' JobPosting structure
    Public Class JobPosting
        Public Property JobTitle As String
        Public Property JobLocation As String
        Public Property EmploymentType As String
        Public Property Salary As String
        Public Property Deadline As String
        Public Property Description As String
        Public Property Skills As String
        Public Property LogoImage As Image
        Public Property Company_Name As String
        Public Property verified_status As String
    End Class

    Private Sub Form14_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadJobsFromDatabase()
        currentDisplayList = jobList
        DisplayJobs()

        ' Setup Click Event only ONCE
        AddHandler btnType1.Click, Sub(s, args) HandleJobClick(0)
        AddHandler btnType2.Click, Sub(s, args) HandleJobClick(1)
        AddHandler btnType3.Click, Sub(s, args) HandleJobClick(2)
        AddHandler btnType4.Click, Sub(s, args) HandleJobClick(3)
        AddHandler btnType5.Click, Sub(s, args) HandleJobClick(4)
        AddHandler btnType6.Click, Sub(s, args) HandleJobClick(5)
    End Sub

    Private Sub HandleJobClick(indexOffset As Integer)
        If currentIndex + indexOffset < currentDisplayList.Count Then
            Dim job = currentDisplayList(currentIndex + indexOffset)
            OpenJobDetails(job)
        End If
    End Sub

    Private Sub OpenJobDetails(job As JobPosting)
        Dim detailForm As New Form21()
        detailForm.JobTitle = job.JobTitle
        detailForm.JobLocation = job.JobLocation
        detailForm.EmploymentType = job.EmploymentType
        detailForm.Salary = job.Salary
        detailForm.Deadline = job.Deadline
        detailForm.Description = job.Description
        detailForm.Skills = job.Skills
        detailForm.LogoImage = job.LogoImage
        detailForm.Company_Name = job.Company_Name
        detailForm.ShowDialog()
    End Sub

    Private Sub LoadJobsFromDatabase()
        jobList.Clear()
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Job Title], [Location], [Employment Type], [Salary], [Application Deadline], [Job Description], [Skills], [Logo Path], [Company Name] FROM [Job Posting] WHERE [Application Deadline] >= ?", con)
            cmd.Parameters.AddWithValue("?", Date.Today)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim deadlineDate As Date
                If Not Date.TryParse(reader("Application Deadline").ToString(), deadlineDate) OrElse deadlineDate < Date.Today Then
                    Continue While ' Skip if invalid date or already passed
                End If

                Dim job As New JobPosting With {
                    .JobTitle = reader("Job Title").ToString(),
                    .JobLocation = reader("Location").ToString(),
                    .EmploymentType = reader("Employment Type").ToString(),
                    .Salary = reader("Salary").ToString(),
                    .Deadline = Convert.ToDateTime(reader("Application Deadline")).ToShortDateString(),
                    .Description = reader("Job Description").ToString(),
                    .Skills = reader("Skills").ToString(),
                    .Company_Name = reader("Company Name").ToString()
                }

                Dim verifiedCmd As New OleDbCommand("SELECT [Verified] FROM [Company Information] WHERE [Company Name] = ?", con)
                verifiedCmd.Parameters.AddWithValue("?", job.Company_Name)
                Dim verifiedReader As OleDbDataReader = verifiedCmd.ExecuteReader()

                If verifiedReader.Read() Then
                    job.verified_status = verifiedReader("Verified").ToString()
                Else
                    job.verified_status = "Unverified"
                End If

                verifiedReader.Close()

                If Not IsDBNull(reader("Logo Path")) Then
                    Dim logoBytes As Byte() = CType(reader("Logo Path"), Byte())
                    Using ms As New IO.MemoryStream(logoBytes)
                        job.LogoImage = Image.FromStream(ms)
                    End Using
                End If

                jobList.Add(job)
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading jobs: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub DisplayJobs(Optional listToShow As List(Of JobPosting) = Nothing)
        If listToShow Is Nothing Then listToShow = jobList
        currentDisplayList = listToShow ' Store filtered/full list

        Dim maxDisplay As Integer = 6
        Dim controlsCount As Integer = Math.Min(maxDisplay, currentDisplayList.Count - currentIndex)

        Dim lblTitles = New List(Of Label) From {lblTitle1, lblTitle2, lblTitle3, lblTitle4, lblTitle5, lblTitle6}
        Dim lblLocations = New List(Of Label) From {lblLocation1, lblLocation2, lblLocation3, lblLocation4, lblLocation5, lblLocation6}
        Dim btnTypes = New List(Of Button) From {btnType1, btnType2, btnType3, btnType4, btnType5, btnType6}
        Dim lblSalaries = New List(Of Label) From {lblSalary1, lblSalary2, lblSalary3, lblSalary4, lblSalary5, lblSalary6}
        Dim lblDeadlines = New List(Of Label) From {lblDeadLine1, lblDeadLine2, lblDeadLine3, lblDeadline4, lblDeadline5, lblDeadline6}
        Dim lblDescriptions = New List(Of Label) From {lblDescription1, lblDescription2, lblDescription3, lblDescription4, lblDescription5, lblDescription6}
        Dim lblSkills = New List(Of Label) From {lblSkills1, lblSkills2, lblSkills3, lblSkills4, lblSkills5, lblSkills6}
        Dim picLogos = New List(Of PictureBox) From {picLogo1, picLogo2, picLogo3, picLogo4, picLogo5, picLogo6}
        Dim lblverified = New List(Of Label) From {lblVerified1, lblVerified2, lblVerified3, lblVerified4, lblVerified5, lblVerified6}

        For i = 0 To 5
            If i < controlsCount Then
                Dim job = currentDisplayList(currentIndex + i)
                lblTitles(i).Text = job.JobTitle
                lblLocations(i).Text = job.JobLocation
                btnTypes(i).Text = job.EmploymentType
                lblSalaries(i).Text = job.Salary
                lblDeadlines(i).Text = "Application Deadline: " & job.Deadline
                lblDescriptions(i).Text = job.Description
                lblSkills(i).Text = job.Skills
                picLogos(i).Image = job.LogoImage
                lblverified(i).Text = job.verified_status

                If job.verified_status = "Yes" Then
                    lblverified(i).Visible = True
                    lblverified(i).ForeColor = Color.LimeGreen
                Else
                    lblverified(i).Visible = False
                End If

                ' Set color
                If job.EmploymentType = "Part-Time" Then
                    btnTypes(i).BackColor = ColorTranslator.FromHtml("#5ce37d")
                ElseIf job.EmploymentType = "Internship" Then
                    btnTypes(i).BackColor = ColorTranslator.FromHtml("#E48FC2")
                    btnTypes(i).ForeColor = Color.Black
                End If
            Else
                ' Clear controls if no job to display
                lblTitles(i).Text = ""
                lblLocations(i).Text = ""
                btnTypes(i).Text = ""
                lblSalaries(i).Text = ""
                lblDeadlines(i).Text = ""
                lblDescriptions(i).Text = ""
                lblSkills(i).Text = ""
                picLogos(i).Image = Nothing
                lblverified(i).Text = ""

            End If
        Next
    End Sub

    Private Sub FilterJobs(keyword As String)
        If String.IsNullOrWhiteSpace(keyword) Then
            currentIndex = 0
            DisplayJobs(jobList)
            Return
        End If
        ' Filter jobs based on keyword in JobTitle, JobLocation, or EmploymentType
        Dim filteredJobs = jobList.Where(Function(j) _
            (If(j.JobTitle, "").ToLower().Contains(keyword.ToLower()) OrElse
             If(j.JobLocation, "").ToLower().Contains(keyword.ToLower()) OrElse
             If(j.EmploymentType, "").ToLower().Contains(keyword.ToLower()))
        ).ToList()

        currentIndex = 0
        DisplayJobs(filteredJobs)
    End Sub

    ' -- Button Events --

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles BtnSearch.Click
        Dim keyword As String = txtSearch.Text.Trim()
        FilterJobs(keyword)
    End Sub

    Private Sub btnNext_Click(sender As Object, e As EventArgs) Handles btnNext.Click
        If currentIndex + 6 < currentDisplayList.Count Then
            currentIndex += 6
            DisplayJobs()
        End If
    End Sub

    Private Sub btnPrevious_Click(sender As Object, e As EventArgs) Handles btnPrevious.Click
        If currentIndex - 6 >= 0 Then
            currentIndex -= 6
            DisplayJobs()
        End If
    End Sub

    ' Navigation Buttons
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnProfile.Click
        Form9.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub Form14_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles RoundedButton2.Click
        JobSeekerInterviewer.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        ViewInterviewresults.Show()
        Me.Hide()
    End Sub
End Class