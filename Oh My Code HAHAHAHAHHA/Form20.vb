Imports System.Data.OleDb

Public Class Form20
    Private Sub Form20_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Subscription Plan], [CardHolder Name], [Card Number], [Expiration Date], CVV FROM [Company Banking Details] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                txtCardName.Text = reader("CardHolder Name").ToString()
                txtCardNumber.Text = reader("Card Number").ToString()
                txtExpirationdate.Text = reader("Expiration Date").ToString()
                txtCVV.Text = reader("CVV").ToString()
            End If
            reader.Close()
        Catch ex As Exception
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub txtCardName_Leave(sender As Object, e As EventArgs) Handles txtCardName.Leave
        If txtCardName.Text.Any(Function(c) Char.IsDigit(c)) Then
            MessageBox.Show("Cardholder name should not contain numbers.", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCardName.Focus()
        End If
    End Sub

    Private Sub txtCardNumber_Leave(sender As Object, e As EventArgs) Handles txtCardNumber.Leave
        If Not txtCardNumber.Text.All(AddressOf Char.IsDigit) Then
            MessageBox.Show("Card number must only contain numbers.", "Invalid Card Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCardNumber.Focus()
        ElseIf txtCardNumber.Text.Length < 13 Or txtCardNumber.Text.Length > 19 Then
            MessageBox.Show("Card number should be between 13 and 19 digits.", "Invalid Card Number", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCardNumber.Focus()
        End If
    End Sub

    Private Sub txtExpirationdate_Leave(sender As Object, e As EventArgs) Handles txtExpirationdate.Leave
        Dim pattern As String = "^(0[1-9]|1[0-2])/(\d{2}|\d{4})$"
        If Not System.Text.RegularExpressions.Regex.IsMatch(txtExpirationdate.Text, pattern) Then
            MessageBox.Show("Expiration date must be in MM/YY or MM/YYYY format.", "Invalid Expiration Date", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtExpirationdate.Focus()
        End If
    End Sub

    Private Sub txtCVV_Leave(sender As Object, e As EventArgs) Handles txtCVV.Leave
        If Not txtCVV.Text.All(AddressOf Char.IsDigit) OrElse (txtCVV.Text.Length <> 3 AndAlso txtCVV.Text.Length <> 4) Then
            MessageBox.Show("CVV must be 3 or 4 digits.", "Invalid CVV", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtCVV.Focus()
        End If
    End Sub

    Private Sub btnConfirm_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If txtCardName.Text = "" Or txtCardNumber.Text = "" Or txtExpirationdate.Text = "" Or txtCVV.Text = "" Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Exit Sub
        End If

        Dim purchaseDate As Date = DateTime.Now.ToString("yyyy-MM-dd HH : mm : ss")
        Dim totalAmount As Double = 20.0

        con.Open()
        Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM [Company Banking Details] WHERE Email = ?", con)
        checkCmd.Parameters.AddWithValue("?", LoggedInEmail)
        Dim count As Integer = CInt(checkCmd.ExecuteScalar())

        If count > 0 Then
            ' Update
            Dim updateCmd As New OleDbCommand("UPDATE [Company Banking Details] SET [CardHolder Name]=?, [Card Number]=?, [Expiration Date]=?, CVV=?, [PurchaseDate]=?, [TotalPayment]=? WHERE Email=?", con)
            updateCmd.Parameters.AddWithValue("?", txtCardName.Text)
            updateCmd.Parameters.AddWithValue("?", txtCardNumber.Text)
            updateCmd.Parameters.AddWithValue("?", txtExpirationdate.Text)
            updateCmd.Parameters.AddWithValue("?", txtCVV.Text)
            updateCmd.Parameters.AddWithValue("?", purchaseDate)
            updateCmd.Parameters.AddWithValue("?", totalAmount)
            updateCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Try
                Dim historyCmd As New OleDbCommand("INSERT INTO [Company Purchase History] ([Company Email], [PurchaseDate]) VALUES (?, ?)", con)
                historyCmd.Parameters.AddWithValue("?", LoggedInEmail)
                historyCmd.Parameters.AddWithValue("?", purchaseDate)
                historyCmd.ExecuteNonQuery()
            Catch ex2 As Exception
                MessageBox.Show("Error saving to Company Purchase History: " & ex2.Message)
            End Try

            Try
                updateCmd.ExecuteNonQuery()
                MessageBox.Show("Purchase updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error updating purchase: " & ex.Message)
            End Try
        Else
            ' Insert
            Dim insertCmd As New OleDbCommand("INSERT INTO [Company Banking Details] (Email, [CardHolder Name], [Card Number], [Expiration Date], CVV, [PurchaseDate], [TotalPayment]) VALUES (?, ?, ?, ?, ?, ?, ?)", con)
            insertCmd.Parameters.AddWithValue("?", LoggedInEmail)
            insertCmd.Parameters.AddWithValue("?", txtCardName.Text)
            insertCmd.Parameters.AddWithValue("?", txtCardNumber.Text)
            insertCmd.Parameters.AddWithValue("?", txtExpirationdate.Text)
            insertCmd.Parameters.AddWithValue("?", txtCVV.Text)
            insertCmd.Parameters.AddWithValue("?", purchaseDate)
            insertCmd.Parameters.AddWithValue("?", totalAmount)
            Try
                Dim historyCmd As New OleDbCommand("INSERT INTO [Company Purchase History] ([Company Email], [PurchaseDate]) VALUES (?, ?)", con)
                historyCmd.Parameters.AddWithValue("?", LoggedInEmail)
                historyCmd.Parameters.AddWithValue("?", purchaseDate)
                historyCmd.ExecuteNonQuery()
            Catch ex2 As Exception
                MessageBox.Show("Error saving to Company Purchase History: " & ex2.Message)
            End Try

            Try
                insertCmd.ExecuteNonQuery()
            Catch ex As Exception
                MessageBox.Show("Error saving purchase: " & ex.Message)
            End Try
        End If

        con.Close()

        ' Upload poster image
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Select a Profile Picture"
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim imgData As Byte() = IO.File.ReadAllBytes(openFileDialog.FileName)

            Try
                con.Open()
                Dim cmdPoster As New OleDbCommand("INSERT INTO [poster database] ([poster image], [Company Email]) VALUES (?, ?)", con)
                cmdPoster.Parameters.AddWithValue("?", imgData)
                cmdPoster.Parameters.AddWithValue("?", LoggedInEmail)
                cmdPoster.ExecuteNonQuery()
                MessageBox.Show("Poster added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error saving image: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If

        MessageBox.Show("Purchase completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Form10.Show()
        Me.Close()
    End Sub
End Class
