Imports System.Data.OleDb
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class Form4

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogIn.Click
        Dim email As String = txtEmail.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If email = "" Or password = "" Then
            MessageBox.Show("Please enter both email and password.")
            Exit Sub

        ElseIf email = "admin@example.com" AndAlso password = "admin123" Then
            LoggedInEmail = email
            CurrentPassword = password
            UserType = "Admin"
            Admin.Show()
            Me.Hide()
            txtEmail.Text = ""
            txtPassword.Text = ""
            Exit Sub
        Else
            con.Open()

            ' Check if the email exists in either JobSeeker or Company tables

            'Jobseeker checking
            ' === JobSeeker Case-Sensitive Check ===
            Dim seekerCmd As New OleDbCommand("SELECT * FROM [JobSeeker Information] WHERE Email = ?", con)
            seekerCmd.Parameters.AddWithValue("?", email)
            Dim seekerReader As OleDbDataReader = seekerCmd.ExecuteReader()

            If seekerReader.Read() Then
                Dim dbPassword As String = seekerReader("Password").ToString()
                Dim dbEmail As String = seekerReader("Email").ToString()

                ' Manual case-sensitive comparison
                If dbEmail = email AndAlso dbPassword = password Then
                    Dim checkblacklist As New OleDbCommand("SELECT Blacklisted FROM [JobSeeker Information] WHERE Email=?", con)
                    checkblacklist.Parameters.AddWithValue("?", email)
                    Dim blacklistStatus = checkblacklist.ExecuteScalar()

                    If blacklistStatus = "Yes" Then
                        MessageBox.Show("You are blacklisted. Please contact support for assistance.", "Blacklisted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        seekerReader.Close()
                        con.Close()
                        Exit Sub ' Stop further processing is blacklisted
                    Else
                        LoggedInEmail = email
                        CurrentPassword = password
                        UserType = "JobSeeker"
                        seekerReader.Close()
                        con.Close()
                        Form5.Show()
                        Me.Hide()
                        txtEmail.Text = ""
                        txtPassword.Text = ""
                        Exit Sub ' Stop further processing if login successful
                    End If
                End If
            End If
            seekerReader.Close()


            ' if not found in JobSeeker, check Company
            ' === Company Case-Sensitive Check ===
            Dim companyCmd As New OleDbCommand("SELECT * FROM [Company Information] WHERE [Company Email] = ?", con)
            companyCmd.Parameters.AddWithValue("?", email)
            Dim companyReader As OleDbDataReader = companyCmd.ExecuteReader()

            If companyReader.Read() Then
                Dim dbPassword As String = companyReader("Password").ToString()
                Dim dbEmail As String = companyReader("Company Email").ToString()

                ' Manual case-sensitive comparison
                If dbEmail = email AndAlso dbPassword = password Then
                    Dim checkblacklist As New OleDbCommand("SELECT Blacklisted FROM [Company Information] WHERE [Company Email]=?", con)
                    checkblacklist.Parameters.AddWithValue("?", email)
                    Dim blacklistStatus = checkblacklist.ExecuteScalar()

                    If blacklistStatus = "Yes" Then
                        MessageBox.Show("You are blacklisted. Please contact support for assistance.", "Blacklisted", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                        companyReader.Close()
                        con.Close()
                        Exit Sub ' Stop further processing if blacklisted
                    Else
                        LoggedInEmail = email
                        CurrentPassword = password
                        UserType = "Company"
                        companyReader.Close()
                        con.Close()
                        Form8.Show()
                        Me.Hide()
                        txtEmail.Text = ""
                        txtPassword.Text = ""
                        Exit Sub ' Stop further processing if login successful
                    End If
                End If
            End If
            companyReader.Close()

            con.Close()
            MessageBox.Show("Invalid email or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblSignUp.LinkClicked
        SignUpForm.Show()
        Me.Hide()
    End Sub

    Private Sub LinkLabel2_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles lnklblForgotPassword.LinkClicked
        Dim Forgot As String
        Forgot = InputBox("Enter your email address to reset your password:", "Forgot Password")
        con.Open()

        Dim checkJobSeeker As New OleDbCommand("SELECT COUNT(*) FROM [JobSeeker Information] WHERE Email = ?", con)
        checkJobSeeker.Parameters.AddWithValue("?", Forgot)
        Dim jsCount As Integer = CInt(checkJobSeeker.ExecuteScalar())

        If jsCount > 0 Then
            MsgBox("Password sent to your email.")
            Exit Sub
        Else
            Dim checkCompany As New OleDbCommand("SELECT COUNT(*) FROM [Company Information] WHERE [Company Email] = ?", con)
            checkCompany.Parameters.AddWithValue("?", Forgot)
            Dim compCount As Integer = CInt(checkCompany.ExecuteScalar())

            If compCount > 0 Then
                MsgBox("Password sent to your email.")
                Exit Sub
            Else
                MsgBox("Email not found. Please sign up first.")
                SignUpForm.Show()
                Me.Hide()
            End If
        End If

    End Sub

    Private Sub Form4_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

End Class