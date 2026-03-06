Imports System.Data.OleDb

Public Class Form18
    Private Sub Form18_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadBookings()
    End Sub

    Private Sub LoadBookings()
        FlowLayoutPanel1.Controls.Clear()

        Dim query As String = "SELECT [Booking Date], [Time], [Consultant Name], [Consultant Picture], [Consultation Link] FROM Booking WHERE Email = ? AND [Booking Date] >= Date()"
        Dim cmd As New OleDbCommand(query, con)
        cmd.Parameters.AddWithValue("?", LoggedInEmail)
        con.Open()
        Dim reader As OleDbDataReader = cmd.ExecuteReader()

        While reader.Read()
            Dim bookingControl As New UserConsultationBookingvb()
            bookingControl.BookingDate = Convert.ToDateTime(reader("Booking Date")).ToString("dd/MM/yyyy")
            bookingControl.Time = reader("Time").ToString()
            bookingControl.ConsultantName = reader("Consultant Name").ToString()
            bookingControl.ConsultationLink = reader("Consultation Link").ToString()

            ' Convert Byte() to Image
            Dim pictureData As Byte() = CType(reader("Consultant Picture"), Byte())
            Using ms As New IO.MemoryStream(pictureData)
                bookingControl.ConsultantPicture = Image.FromStream(ms)
            End Using

            FlowLayoutPanel1.Controls.Add(bookingControl)
        End While

        con.Close()
    End Sub

End Class