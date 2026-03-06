Imports System.Drawing

Public Class CompanyInterview

    ' Declare properties
    Public Property ApplicantName As String
        Get
            Return lblName.Text
        End Get
        Set(value As String)
            lblName.Text = value
        End Set
    End Property

    Public Property ApplicantInstitution As String
        Get
            Return lblInstitution.Text
        End Get
        Set(value As String)
            lblInstitution.Text = value
        End Set
    End Property

    Public Property ApplicantCGPA As String
        Get
            Return lblCGPA.Text
        End Get
        Set(value As String)
            lblCGPA.Text = value
        End Set
    End Property

    Public Property ApplicantField As String
        Get
            Return lblField.Text
        End Get
        Set(value As String)
            lblField.Text = value
        End Set
    End Property

    Public Property ApplicantSkills As String
        Get
            Return lblSkills.Text
        End Get
        Set(value As String)
            lblSkills.Text = value
        End Set
    End Property

    Public Property ApplicantEmail As String
    Public Property ApplicantResume As Byte()
    Public Property ApplicantProfileImage As Image
        Get
            Return ProfileImage.Image
        End Get
        Set(value As Image)
            ProfileImage.Image = value
        End Set
    End Property

    ' Custom Applicant class for transfer
    Public Class Applicant
        Public Property Name As String
        Public Property Institution As String
        Public Property CGPA As String
        Public Property Field As String
        Public Property Skills As String
        Public Property Email As String
        Public Property ResumeData As Byte()
        Public Property ProfileImage As Image
    End Class

    ' Declare event to pass data to parent form
    Public Event ApplicantClicked(applicant As Applicant)

    ' Trigger when control or inner labels/images clicked
    Private Sub ApplicantCard_Click(sender As Object, e As EventArgs) _
        Handles MyBase.Click, lblName.Click, lblInstitution.Click,
                lblCGPA.Click, lblField.Click, lblSkills.Click, ProfileImage.Click

        Dim a As New Applicant With {
            .Name = lblName.Text,
            .Institution = lblInstitution.Text,
            .CGPA = lblCGPA.Text,
            .Field = lblField.Text,
            .Skills = lblSkills.Text,
            .Email = Me.ApplicantEmail,
            .ResumeData = Me.ApplicantResume,
            .ProfileImage = ProfileImage.Image
        }

        RaiseEvent ApplicantClicked(a)
    End Sub

    Private Sub CompanyInterview_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
