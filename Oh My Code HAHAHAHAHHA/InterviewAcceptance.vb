
Imports System.Drawing
Public Class InterviewAcceptance

    ' Declare properties
    Public Property InterviewerCompanyName As String
        Get
            Return lblCompanyName.Text
        End Get
        Set(value As String)
            lblCompanyName.Text = value
        End Set
    End Property

    Public Property JobTitleOffered As String
        Get
            Return lblJobTitle.Text
        End Get
        Set(value As String)
            lblJobTitle.Text = value
        End Set
    End Property

    Public Property InterviewEmploymentType As String
        Get
            Return lblEmploymentType.Text
        End Get
        Set(value As String)
            lblEmploymentType.Text = value
        End Set
    End Property

    Public Property InterviewSalary As String
        Get
            Return lblSalary.Text
        End Get
        Set(value As String)
            lblSalary.Text = value
        End Set
    End Property

    Public Property InterviewCompanyLocation As String
        Get
            Return lblLocation.Text
        End Get
        Set(value As String)
            lblLocation.Text = value
        End Set
    End Property

    Public Property interviewerCompanyEmail As String
    Public Property InterviewerrCompanyImage As Image
        Get
            Return ProfileImage.Image
        End Get
        Set(value As Image)
            ProfileImage.Image = value
        End Set
    End Property

    ' Custom Applicant class for transfer
    Public Class Interviewer
        Public Property CompanyName As String
        Public Property JobTitle As String
        Public Property EmploymentType As String
        Public Property Salary As String
        Public Property CompanyLocation As String
        Public Property Email As String
        Public Property ResumeData As Byte() ' Optional if needed
        Public Property ProfileImage As Image
    End Class

    ' Declare event to pass data to parent form
    Public Event ApplicantClicked(CompanyInterviewer As Interviewer)

    ' Trigger when control or inner labels/images clicked
    Private Sub ApplicantCard_Click(sender As Object, e As EventArgs) _
            Handles MyBase.Click, lblCompanyName.Click, lblJobTitle.Click,
                    lblEmploymentType.Click, lblSalary.Click, lblLocation.Click, ProfileImage.Click

        Dim a As New Interviewer With {
                .CompanyName = lblCompanyName.Text,
                .JobTitle = lblJobTitle.Text,
                .EmploymentType = lblEmploymentType.Text,
                .Salary = lblSalary.Text,
                .CompanyLocation = lblLocation.Text,
                .Email = Me.interviewerCompanyEmail,
                .ProfileImage = ProfileImage.Image
            }

        RaiseEvent ApplicantClicked(a)
    End Sub

    Private Sub InterviewAcceptance_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
