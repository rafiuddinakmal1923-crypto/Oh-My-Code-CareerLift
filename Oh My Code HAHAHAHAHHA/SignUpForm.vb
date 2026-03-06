Imports System.Data.OleDb

Public Class SignUpForm
    Private Sub btnSignUp_Click(sender As Object, e As EventArgs) Handles btnSignUp.Click
        Dim username As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()
        Dim confirm As String = txtConfirm.Text.Trim()
        Dim userType As String = ""

        ' Email validation: must contain "@" and ".com"
        If Not (username.Contains("@") And username.EndsWith(".com")) Then
            MessageBox.Show("Please enter valid Email")
            Return
        End If

        ' Password validation: at least 8 characters, contains letters and numbers
        If password.Length < 8 OrElse Not password.Any(AddressOf Char.IsLetter) OrElse Not password.Any(AddressOf Char.IsDigit) Then
            MessageBox.Show("Password must be at least 8 characters long and contain both letters and numbers.")
            Return
        End If

        If txtEmail.Text = "" Or txtPassword.Text = "" Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If

        If rdoJobSeeker.Checked Then
            userType = "JobSeeker"
            Signindata(username, password, confirm, userType)
        ElseIf rdoCompany.Checked Then
            userType = "Company"
            Signindata(username, password, confirm, userType)
        Else
            MessageBox.Show("Please select user type.")
            Return
        End If

        If username = "" Or password = "" Then
            MessageBox.Show("Please fill in all fields.")
            Return
        End If
    End Sub

    Private Sub Signindata(ByRef username As String, ByRef password As String, ByRef confirm As String, ByRef userType As String)

        If userType = "JobSeeker" Then
            Try
                If password <> confirm Then
                    MessageBox.Show("Passwords do not match. Please try again.")
                    txtPassword.Clear()
                    txtConfirm.Clear()
                    Return
                End If

                con.Open()
                ' Check if the email already exists in the JobSeeker Information table
                Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM [JobSeeker Information] WHERE Email = ?", con)
                checkCmd.Parameters.AddWithValue("?", username)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Email already exists. Please use a different one.")
                    txtEmail.Clear()
                    txtPassword.Clear()
                    Exit Sub
                End If

                Dim cmd As New OleDbCommand("INSERT INTO [JobSeeker Information] (Email, [Password], [User Type], [Sign Up Date]) VALUES (?, ?, ?, ?)", con)
                cmd.Parameters.AddWithValue("?", username)
                cmd.Parameters.AddWithValue("?", password)
                cmd.Parameters.AddWithValue("?", userType)
                cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))
                cmd.ExecuteNonQuery()

                MessageBox.Show("Account created successfully!")
                Me.Hide()
                Form4.Show()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                con.Close()
            End Try

        ElseIf userType = "Company" Then
            Try
                If password <> confirm Then
                    MessageBox.Show("Passwords do not match. Please try again.")
                    txtPassword.Clear()
                    txtConfirm.Clear()
                    Return
                End If
                con.Open()
                ' Check if the email already exists in the Company Information table
                Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM [Company Information] WHERE [Company Email] = ?", con)
                checkCmd.Parameters.AddWithValue("?", username)
                Dim count As Integer = CInt(checkCmd.ExecuteScalar())

                If count > 0 Then
                    MessageBox.Show("Email already exists. Please use a different one.")
                    txtEmail.Clear()
                    txtPassword.Clear()
                    Exit Sub
                End If

                Dim cmd As New OleDbCommand("INSERT INTO [Company Information] ([Company Email], [Password], [User Type], [Sign Up Date]) VALUES (?, ?, ?, ?)", con)
                cmd.Parameters.AddWithValue("?", username)
                cmd.Parameters.AddWithValue("?", password)
                cmd.Parameters.AddWithValue("?", userType)
                cmd.Parameters.AddWithValue("?", DateTime.Now.ToString("yyyy-MM-dd"))
                cmd.ExecuteNonQuery()

                MessageBox.Show("Account created successfully!")
                Me.Hide()
                Form4.Show()
            Catch ex As Exception
                MessageBox.Show("Error: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If

        ' Clear form
        txtEmail.Clear()
        txtPassword.Clear()
        txtConfirm.Clear()
        rdoJobSeeker.Checked = False
        rdoCompany.Checked = False
    End Sub

    Private Sub LinkLabel3_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblLogIn.LinkClicked
        Me.Hide()
        Form4.Show()
    End Sub

    Private Sub Form16_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class