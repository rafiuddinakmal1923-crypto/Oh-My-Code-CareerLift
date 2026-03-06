Imports System.Data.OleDb

Public Class Form15
    Dim Purchase As String
    Dim tokens As Integer = 0


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

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnConfirm.Click
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        If txtCardName.Text = "" Or txtCardNumber.Text = "" Or txtExpirationdate.Text = "" Or txtCVV.Text = "" Or Purchase = "" Then
            MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        Try
            con.Open()

            ' Dapatkan pelan dan maklumat semasa
            Dim planCmd As New OleDbCommand("SELECT [Subscription Plan], Tokens, TotalPayment FROM [Banking Details] WHERE Email = ?", con)
            planCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader As OleDbDataReader = planCmd.ExecuteReader()

            Dim currentPlan As String = ""
            Dim currentTokens As Integer = 0
            Dim currentTotalPayment As Decimal = 0D

            If reader.Read() Then
                currentPlan = reader("Subscription Plan").ToString()
                currentTokens = If(IsDBNull(reader("Tokens")), 0, Convert.ToInt32(reader("Tokens")))
                currentTotalPayment = If(IsDBNull(reader("TotalPayment")), 0D, Convert.ToDecimal(reader("TotalPayment")))
            End If
            reader.Close()

            ' Elakkan langganan berganda
            If Purchase = "Premium" AndAlso (currentPlan = "Premium" OrElse currentPlan = "Exclusive") Then
                MessageBox.Show("You already have a Premium or Exclusive subscription. You cannot purchase Premium again.", "Subscription Exists", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                lblTotal.Text = ""
                Purchase = ""
                Return
            End If

            ' Kira token dan payment baru
            tokens += currentTokens
            Dim newPayment As Decimal = Convert.ToDecimal(lblTotal.Text)
            Try
                Dim rawTotal As String = lblTotal.Text.Replace("RM", "").Replace("MYR", "").Trim()
                newPayment = Decimal.Parse(rawTotal, Globalization.CultureInfo.InvariantCulture)
            Catch parseEx As Exception
                MessageBox.Show("Invalid amount format in lblTotal: " & lblTotal.Text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return
            End Try
            Dim updatedTotalPayment As Decimal = currentTotalPayment + newPayment

            ' Semak kewujudan
            Dim countCmd As New OleDbCommand("SELECT COUNT(*) FROM [Banking Details] WHERE Email = ?", con)
            countCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim exists As Integer = Convert.ToInt32(countCmd.ExecuteScalar())

            If exists > 0 Then
                ' Update
                Dim updateCmd As New OleDbCommand("UPDATE [Banking Details] SET [Subscription Plan]=?, [CardHolder Name]=?, [Card Number]=?, [Expiration Date]=?, CVV=?, Tokens=?, PurchaseDate=?, TotalPayment=? WHERE Email=?", con)
                updateCmd.Parameters.AddWithValue("?", Purchase)
                updateCmd.Parameters.AddWithValue("?", txtCardName.Text)
                updateCmd.Parameters.AddWithValue("?", txtCardNumber.Text)
                updateCmd.Parameters.AddWithValue("?", txtExpirationdate.Text)
                updateCmd.Parameters.AddWithValue("?", txtCVV.Text)
                updateCmd.Parameters.AddWithValue("?", tokens.ToString()) ' Integer to String
                updateCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")) ' DateTime to String
                updateCmd.Parameters.AddWithValue("?", updatedTotalPayment.ToString("F2")) ' Decimal to String
                updateCmd.Parameters.AddWithValue("?", LoggedInEmail)
                updateCmd.ExecuteNonQuery()
                Try
                    Dim historyCmd As New OleDbCommand("INSERT INTO [JobSeeker Purchase History] (Email, PurchaseDate) VALUES (?, ?)", con)
                    historyCmd.Parameters.AddWithValue("?", LoggedInEmail)
                    historyCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    historyCmd.ExecuteNonQuery()
                Catch ex2 As Exception
                    MessageBox.Show("Error saving to Purchase History: " & ex2.Message, "History Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            Else
                ' Insert
                Dim insertCmd As New OleDbCommand("INSERT INTO [Banking Details] (Email, [Subscription Plan], [CardHolder Name], [Card Number], [Expiration Date], CVV, Tokens, PurchaseDate, TotalPayment) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?)", con)
                insertCmd.Parameters.AddWithValue("?", LoggedInEmail)
                insertCmd.Parameters.AddWithValue("?", Purchase)
                insertCmd.Parameters.AddWithValue("?", txtCardName.Text)
                insertCmd.Parameters.AddWithValue("?", txtCardNumber.Text)
                insertCmd.Parameters.AddWithValue("?", txtExpirationdate.Text)
                insertCmd.Parameters.AddWithValue("?", txtCVV.Text)
                insertCmd.Parameters.AddWithValue("?", tokens.ToString())
                insertCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                insertCmd.Parameters.AddWithValue("?", newPayment.ToString("F2"))
                insertCmd.ExecuteNonQuery()
                Try
                    Dim historyCmd As New OleDbCommand("INSERT INTO [JobSeeker Purchase History] (Email, PurchaseDate) VALUES (?, ?)", con)
                    historyCmd.Parameters.AddWithValue("?", LoggedInEmail)
                    historyCmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"))
                    historyCmd.ExecuteNonQuery()
                Catch ex2 As Exception
                    MessageBox.Show("Error saving to Purchase History: " & ex2.Message, "History Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End Try
            End If

            MessageBox.Show("Purchase completed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Form6.Show()
            Form7.Hide()
            Me.Hide()

        Catch ex As Exception
            MessageBox.Show("Error during purchase: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles btnBack.Click
        Form6.Show()
        Form7.Hide()
        Me.Hide()
    End Sub

    Private Sub btnPremium_Click(sender As Object, e As EventArgs) Handles btnPremium.Click, btnExclusive.Click
        Dim tap As Button = CType(sender, Button)
        If tap Is btnExclusive Then
            Purchase = "Exclusive"
        ElseIf tap Is btnPremium Then
            Purchase = "Premium"
        End If
        Call PurchaseData(Purchase)
    End Sub

    Function PurchaseData(ByRef Purchase As String) As String
        con.Open()

        ' Semak subscription sekarang
        Dim checkCmd As New OleDbCommand("SELECT [Subscription Plan] FROM [Banking Details] WHERE Email = ?", con)
        checkCmd.Parameters.AddWithValue("?", LoggedInEmail)
        Dim currentPlan As String = CStr(checkCmd.ExecuteScalar())
        con.Close()

        ' Kalau dah Premium atau Exclusive, tak boleh beli Premium lagi
        If Purchase = "Premium" AndAlso (currentPlan = "Premium" OrElse currentPlan = "Exclusive") Then
            MessageBox.Show("You already have a Premium or Exclusive subscription. Purchase not allowed.", "Subscription Active", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Purchase = ""
            lblTotal.Text = ""
            Return currentPlan
        End If

        ' Tetapkan harga dan tokens
        Dim price As Decimal = 0
        If Purchase = "Premium" Then
            price = 19.9
            tokens = 0
        ElseIf Purchase = "Exclusive" Then
            price = 109.9
            tokens = 5
        End If

        lblTotal.Text = price
        Return Purchase
    End Function
End Class
