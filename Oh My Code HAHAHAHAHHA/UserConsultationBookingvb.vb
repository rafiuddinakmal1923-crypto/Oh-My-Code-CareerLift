Public Class UserConsultationBookingvb
    Public Property BookingDate As String
        Get
            Return lblDate.Text
        End Get
        Set(value As String)
            lblDate.Text = "Date: " & value
        End Set
    End Property

    Public Property Time As String
        Get
            Return lblTime.Text
        End Get
        Set(value As String)
            lblTime.Text = "Time: " & value
        End Set
    End Property

    Public Property ConsultantName As String
        Get
            Return lblConsultantName.Text
        End Get
        Set(value As String)
            lblConsultantName.Text = "Consultant: " & value
        End Set
    End Property

    Public Property ConsultantPicture As Image
        Get
            Return picConsultant.Image
        End Get
        Set(value As Image)
            picConsultant.Image = value
        End Set
    End Property

    Public Property ConsultationLink As String
        Get
            Return linkConsultation.Text
        End Get
        Set(value As String)
            linkConsultation.Text = value
        End Set
    End Property

    Private Sub linkConsultation_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles linkConsultation.LinkClicked
        Process.Start(ConsultationLink)
    End Sub
End Class
