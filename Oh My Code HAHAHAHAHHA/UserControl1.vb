Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class UserControl1
    Public Property Logo As Image
        Get
            Return picLogo.Image
        End Get
        Set(value As Image)
            picLogo.Image = value
        End Set
    End Property

    Public Property Title As String
        Get
            Return lblTitle.Text
        End Get
        Set(value As String)
            lblTitle.Text = value
        End Set
    End Property

    Public Property Description As String
        Get
            Return lblDescription.Text
        End Get
        Set(value As String)
            lblDescription.Text = value
        End Set
    End Property

    Public Property Salary As String
        Get
            Return lblSalary.Text
        End Get
        Set(value As String)
            lblSalary.Text = value
        End Set
    End Property

    Public Property CompanyName_ As String
        Get
            Return lblCompany.Text
        End Get
        Set(value As String)
            lblCompany.Text = value
        End Set
    End Property

    Public Property Company_Location As String
        Get
            Return lblLocation.Text
        End Get
        Set(value As String)
            lblLocation.Text = value
        End Set
    End Property

    Public Property VerificationStatus As String
        Get
            Return lblVerified.Text
        End Get
        Set(value As String)
            lblVerified.Text = value
        End Set
    End Property

    Public Property applicationstatus As String
        Get
            Return lblApplicationStatus.Text
        End Get
        Set(value As String)
            lblApplicationStatus.Text = value
        End Set
    End Property

    Private Sub UserControl1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim checker As New OleDbCommand("SELECT COUNT(*) FROM [Company Information] WHERE [Company Email] = ?", con)
        checker.Parameters.AddWithValue("?", LoggedInEmail)
        Dim count As Integer = CInt(checker.ExecuteScalar())

        If count > 0 Then
            Label1.Visible = False
            Exit Sub
        End If
    End Sub

End Class
