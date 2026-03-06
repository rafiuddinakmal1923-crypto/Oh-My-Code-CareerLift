Imports System.Data.OleDb

Public Class Form23
    Private Sub btnBook_Click(sender As Object, e As EventArgs) Handles btnBook.Click
        Dim availableTokens As Integer = GetUserTokens()
        Dim selectedTime As String = ""
        Dim selectedDate As Date = dtpAppointmentDate.Value.Date
        Dim selectedConsultant As String = ConsultantName

        ' ============ Validation ==============
        If cboTimePicker.SelectedItem Is Nothing Then
            MsgBox("Please select a time for the consultation.", MsgBoxStyle.Exclamation, "Time Selection Required")
            Exit Sub
        End If
        selectedTime = cboTimePicker.SelectedItem.ToString()

        If selectedDate <= DateTime.Now.Date Then
            MsgBox("Please select a valid future date for the consultation.", MsgBoxStyle.Exclamation, "Invalid Date")
            Exit Sub
        End If

        If availableTokens <= 0 Then
            MsgBox("You do not have enough tokens to book a consultation.", MsgBoxStyle.Critical, "Insufficient Tokens")
            Form7.Show()
            Me.Close()
            If con.State = ConnectionState.Open Then
                con.Close()
            End If
            Exit Sub
        End If

        ' ========== Check slot already booked for same consultant ==========
        Try
            con.Open()
            Dim checkBooking As New OleDbCommand(
                "SELECT COUNT(*) FROM [Booking] WHERE [Time] = ? AND [Booking Date] = ? AND [Consultant Name] = ?", con)
            checkBooking.Parameters.AddWithValue("?", selectedTime)
            checkBooking.Parameters.AddWithValue("?", selectedDate)
            checkBooking.Parameters.AddWithValue("?", selectedConsultant)
            Dim bookingCount As Integer = CInt(checkBooking.ExecuteScalar())
            If bookingCount > 0 Then
                MsgBox("Consultation slot is already booked for this consultant.", MsgBoxStyle.Exclamation, "Booking Conflict")
                con.Close()
                Exit Sub
            End If

        Catch ex As Exception

            MsgBox("Error checking existing bookings: " & ex.Message)
            Exit Sub
        End Try
        con.Close()

        ' ========== Check if same user booked same consultant, date & time ==========
        Try
            con.Open()
            Dim checkUserBooking As New OleDbCommand(
                "SELECT COUNT(*) FROM [Booking] WHERE [Email] = ? AND [Booking Date] = ? AND [Time] = ? AND [Consultant Name] = ?", con)
            checkUserBooking.Parameters.AddWithValue("?", LoggedInEmail)
            checkUserBooking.Parameters.AddWithValue("?", selectedDate)
            checkUserBooking.Parameters.AddWithValue("?", selectedTime)
            checkUserBooking.Parameters.AddWithValue("?", selectedConsultant)
            Dim userBookingCount As Integer = CInt(checkUserBooking.ExecuteScalar())
            If userBookingCount > 0 Then
                MsgBox("You have already booked this slot with the selected consultant.", MsgBoxStyle.Exclamation, "Duplicate Booking")
                con.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error checking your previous bookings: " & ex.Message)
            Exit Sub
        End Try
        con.Close()

        ' ========== Check if user booked same time slot with different consultant ==========
        Try
            con.Open()
            Dim checkUserTimeConflict As New OleDbCommand(
        "SELECT COUNT(*) FROM [Booking] WHERE [Email] = ? AND [Booking Date] = ? AND [Time] = ?", con)
            checkUserTimeConflict.Parameters.AddWithValue("?", LoggedInEmail)
            checkUserTimeConflict.Parameters.AddWithValue("?", selectedDate)
            checkUserTimeConflict.Parameters.AddWithValue("?", selectedTime)
            Dim conflictCount As Integer = CInt(checkUserTimeConflict.ExecuteScalar())
            If conflictCount > 0 Then
                MsgBox("You already have a booking at this date and time with another consultant.", MsgBoxStyle.Exclamation, "Booking Conflict")
                con.Close()
                Exit Sub
            End If
        Catch ex As Exception
            MsgBox("Error checking for conflicting bookings: " & ex.Message)
            Exit Sub
        End Try
        con.Close()


        ' ========== Save Booking ==========
        Try
            con.Open()
            Dim insertBooking As New OleDbCommand(
                "INSERT INTO [Booking] ([Email], [Booking Date], [Time], [Consultant Name], [Consultant Picture]) VALUES (?, ?, ?, ?, ?)", con)
            insertBooking.Parameters.AddWithValue("?", LoggedInEmail)
            insertBooking.Parameters.AddWithValue("?", selectedDate)
            insertBooking.Parameters.AddWithValue("?", selectedTime)
            insertBooking.Parameters.AddWithValue("?", selectedConsultant)
            insertBooking.Parameters.AddWithValue("?", Consultantpicture)
            insertBooking.ExecuteNonQuery()
            con.Close()

            ' Reduce tokens after successful booking
            availableTokens -= 1
            con.Open()
            Dim updateTokens As New OleDbCommand(
                "UPDATE [Banking Details] SET [Tokens] = ? WHERE [Email] = ?", con)
            updateTokens.Parameters.AddWithValue("?", availableTokens)
            updateTokens.Parameters.AddWithValue("?", LoggedInEmail)
            updateTokens.ExecuteNonQuery()


            MsgBox("Booking successful! Token left = " & availableTokens, MsgBoxStyle.Information, "Success")
            Me.Close()
        Catch ex As Exception
            MsgBox("Database error: " & ex.Message, MsgBoxStyle.Critical, "Error")
        End Try
        con.Close()
    End Sub

    Private Sub Form23_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
