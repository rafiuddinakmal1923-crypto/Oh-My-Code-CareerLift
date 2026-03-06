Imports System.Data.OleDb
Imports System.IO

Public Class Form9

    Private Sub btnHome_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form5.Show()
        Me.Hide()
    End Sub

    Private Sub btnFeedback_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub btnSubscription_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form6.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButttnJobSearch_Click(sender As Object, e As EventArgs) Handles btnSearchJobs.Click
        Form14.Show()
        Me.Hide()
    End Sub

    ' Called when profile field values are changed
    Private Sub AllTextBox_TextChanged(sender As Object, e As EventArgs) Handles _
        txtName.TextChanged, txtNo.TextChanged, txtAddress.TextChanged,
        txtEmail.TextChanged, txtCity.TextChanged, txtEducation.TextChanged,
        txtInstitution.TextChanged, txtFOS.TextChanged, txtGraduation.TextChanged,
        txtCGPA.TextChanged, txtExperience.TextChanged, txtSkills.TextChanged
        UpdateProgress()
    End Sub

    ' Update progress bar for profile completeness
    Private Sub UpdateProgress()
        Dim totalFields As Integer = 13
        Dim filledFields As Integer = 0

        If txtName.Text.Trim() <> "" Then filledFields += 1
        If txtNo.Text.Trim() <> "" Then filledFields += 1
        If txtAddress.Text.Trim() <> "" Then filledFields += 1
        If cboGender.Text.Trim() <> "" Then filledFields += 1
        If dtpDOB.Text.Trim() <> "" Then filledFields += 1
        If txtCity.Text.Trim() <> "" Then filledFields += 1
        If txtEducation.Text.Trim() <> "" Then filledFields += 1
        If txtInstitution.Text.Trim() <> "" Then filledFields += 1
        If txtFOS.Text.Trim() <> "" Then filledFields += 1
        If txtGraduation.Text.Trim() <> "" Then filledFields += 1
        If txtCGPA.Text.Trim() <> "" Then filledFields += 1
        If txtExperience.Text.Trim() <> "" Then filledFields += 1
        If txtSkills.Text.Trim() <> "" Then filledFields += 1

        Dim percent As Integer = CInt((filledFields / totalFields) * 100)
        pgbUpdate.Value = percent
        lblProgress.Text = "Your profile is " & percent.ToString() & "% complete."
    End Sub

    ' Enable profile editing
    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblProgress.Visible = True
        btnComplete.Visible = True
        btnUploadResume.Visible = True
        btnViewResume.Visible = False
        pgbUpdate.Visible = True

        txtName.ReadOnly = False
        txtNo.ReadOnly = False
        txtAddress.ReadOnly = False
        dtpDOB.Enabled = True
        cboGender.Enabled = True
        txtCity.ReadOnly = False
        txtEducation.ReadOnly = False
        txtInstitution.ReadOnly = False
        txtFOS.ReadOnly = False
        txtGraduation.ReadOnly = False
        txtCGPA.ReadOnly = False
        txtExperience.ReadOnly = False
        txtSkills.ReadOnly = False
        txtName.Focus()
    End Sub

    ' Name validation - only letters and spaces allowed
    Private Function IsNameValid(name As String) As Boolean
        Return name.All(Function(c) Char.IsLetter(c) OrElse Char.IsWhiteSpace(c))
    End Function

    ' Phone validation - only digits allowed
    Private Function IsPhoneNumberValid(phone As String) As Boolean
        Return phone.All(Function(c) Char.IsDigit(c))
    End Function

    ' CGPA validation - must be between 0 and 4
    Private Function IsValidCGPA(cgpaText As String) As Boolean
        Dim cgpa As Double
        Return Double.TryParse(cgpaText, cgpa) AndAlso cgpa >= 0 AndAlso cgpa <= 4
    End Function

    ' Save or update profile data
    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        If txtName.Text.Trim() = "" OrElse txtNo.Text.Trim() = "" OrElse txtAddress.Text.Trim() = "" OrElse
           cboGender.Text.Trim() = "" OrElse dtpDOB.Text.Trim() = "" OrElse txtCity.Text.Trim() = "" OrElse
           txtEducation.Text.Trim() = "" OrElse txtInstitution.Text.Trim() = "" OrElse txtFOS.Text.Trim() = "" OrElse
           txtGraduation.Text.Trim() = "" OrElse txtCGPA.Text.Trim() = "" OrElse txtExperience.Text.Trim() = "" OrElse
           txtSkills.Text.Trim() = "" Then

            MessageBox.Show("Please fill in all fields before saving.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' Disable editing
        txtName.ReadOnly = True
        txtNo.ReadOnly = True
        txtAddress.ReadOnly = True
        dtpDOB.Enabled = False
        cboGender.Enabled = False
        txtCity.ReadOnly = True
        txtEducation.ReadOnly = True
        txtInstitution.ReadOnly = True
        txtFOS.ReadOnly = True
        txtGraduation.ReadOnly = True
        txtCGPA.ReadOnly = True
        txtExperience.ReadOnly = True
        txtSkills.ReadOnly = True

        btnComplete.Visible = False
        pgbUpdate.Visible = False
        btnUploadResume.Visible = False
        btnViewResume.Visible = True
        lblProgress.Visible = False

        Try
            con.Open()

            ' Check if profile already exists
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM [JobSeeker Information] WHERE Email = ?", con)
            checkCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim count As Integer = CInt(checkCmd.ExecuteScalar())

            If count > 0 Then
                ' Update profile
                Dim updateCmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [Full Name]=?, [Date Of Birth]=?, [Phone Number]=?, [Gender]=?, [Address]=?, [City]=?, [Education Level]=?, [Institution]=?, [Field Of Study]=?, [Graduation Year]=?, [CGPA]=?, [Skills]=?, [Experience]=? WHERE Email=?", con)
                updateCmd.Parameters.AddWithValue("?", txtName.Text)
                updateCmd.Parameters.AddWithValue("?", dtpDOB.Value)
                updateCmd.Parameters.AddWithValue("?", txtNo.Text)
                updateCmd.Parameters.AddWithValue("?", cboGender.Text)
                updateCmd.Parameters.AddWithValue("?", txtAddress.Text)
                updateCmd.Parameters.AddWithValue("?", txtCity.Text)
                updateCmd.Parameters.AddWithValue("?", txtEducation.Text)
                updateCmd.Parameters.AddWithValue("?", txtInstitution.Text)
                updateCmd.Parameters.AddWithValue("?", txtFOS.Text)
                updateCmd.Parameters.AddWithValue("?", txtGraduation.Text)
                updateCmd.Parameters.AddWithValue("?", txtCGPA.Text)
                updateCmd.Parameters.AddWithValue("?", txtSkills.Text)
                updateCmd.Parameters.AddWithValue("?", txtExperience.Text)
                updateCmd.Parameters.AddWithValue("?", LoggedInEmail)
                updateCmd.ExecuteNonQuery()
                MessageBox.Show("Profile updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Insert new profile
                Dim insertCmd As New OleDbCommand("INSERT INTO [JobSeeker Information] (Email, [Full Name], [Phone Number], [Date Of Birth], [Gender], [Address], [City], [Education Level], [Institution], [Field Of Study], [Graduation Year], [CGPA], [Skills], [Experience]) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)", con)
                insertCmd.Parameters.AddWithValue("?", LoggedInEmail)
                insertCmd.Parameters.AddWithValue("?", txtName.Text)
                insertCmd.Parameters.AddWithValue("?", txtNo.Text)
                insertCmd.Parameters.AddWithValue("?", dtpDOB.Value)
                insertCmd.Parameters.AddWithValue("?", cboGender.Text)
                insertCmd.Parameters.AddWithValue("?", txtAddress.Text)
                insertCmd.Parameters.AddWithValue("?", txtCity.Text)
                insertCmd.Parameters.AddWithValue("?", txtEducation.Text)
                insertCmd.Parameters.AddWithValue("?", txtInstitution.Text)
                insertCmd.Parameters.AddWithValue("?", txtFOS.Text)
                insertCmd.Parameters.AddWithValue("?", txtGraduation.Text)
                insertCmd.Parameters.AddWithValue("?", txtCGPA.Text)
                insertCmd.Parameters.AddWithValue("?", txtSkills.Text)
                insertCmd.Parameters.AddWithValue("?", txtExperience.Text)
                insertCmd.ExecuteNonQuery()
                MessageBox.Show("Profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If
        Catch ex As Exception
            MessageBox.Show("Database error: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    ' Form load - fetch saved data
    Private Sub Form9_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        lblSubscription.Text = GetUserSubscriptionPlan() & " Plan"
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT * FROM [JobSeeker Information] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() Then
                txtName.Text = reader("Full Name").ToString()
                txtEmail.Text = LoggedInEmail
                txtNo.Text = reader("Phone Number").ToString()
                dtpDOB.Value = Convert.ToDateTime(reader("Date Of Birth"))
                cboGender.Text = reader("Gender").ToString()
                txtAddress.Text = reader("Address").ToString()
                txtCity.Text = reader("City").ToString()
                txtEducation.Text = reader("Education Level").ToString()
                txtInstitution.Text = reader("Institution").ToString()
                txtFOS.Text = reader("Field Of Study").ToString()
                txtGraduation.Text = reader("Graduation Year").ToString()
                txtCGPA.Text = reader("CGPA").ToString()
                txtSkills.Text = reader("Skills").ToString()
                txtExperience.Text = reader("Experience").ToString()

                If Not IsDBNull(reader("User Picture")) Then
                    Dim imgBytes As Byte() = CType(reader("User Picture"), Byte())
                    Using ms As New MemoryStream(imgBytes)
                        PictureBox1.Image = Image.FromStream(ms)
                    End Using
                End If

                btnViewResume.Visible = Not IsDBNull(reader("Resume Path"))
            End If
            reader.Close()
        Catch ex As Exception
            'MessageBox.Show("Error loading profile data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub

    ' Upload profile picture
    Private Sub btnUploadImage_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
        Dim dlg As New OpenFileDialog() With {
            .Title = "Select a Profile Picture",
            .Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            PictureBox1.Image = Image.FromFile(dlg.FileName)
            PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage

            Using ms As New MemoryStream()
                PictureBox1.Image.Save(ms, Imaging.ImageFormat.Jpeg)
                Dim imgData As Byte() = ms.ToArray()

                Try
                    con.Open()
                    Dim cmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [User Picture] = ? WHERE Email = ?", con)
                    cmd.Parameters.AddWithValue("?", imgData)
                    cmd.Parameters.AddWithValue("?", LoggedInEmail)
                    cmd.ExecuteNonQuery()
                    MessageBox.Show("Profile picture uploaded!", "Success")
                Catch ex As Exception
                    MessageBox.Show("Error saving picture: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End Using
        End If
    End Sub

    ' Upload resume as byte array
    Private Sub btnUploadResume_Click(sender As Object, e As EventArgs) Handles btnUploadResume.Click
        Dim dlg As New OpenFileDialog() With {
            .Title = "Select Resume",
            .Filter = "PDF Files|*.pdf|Word Documents|*.doc;*.docx"
        }

        If dlg.ShowDialog() = DialogResult.OK Then
            Dim resumeData As Byte() = File.ReadAllBytes(dlg.FileName)

            Try
                con.Open()
                Dim cmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [Resume Path] = ? WHERE Email = ?", con)
                cmd.Parameters.AddWithValue("?", resumeData)
                cmd.Parameters.AddWithValue("?", LoggedInEmail)
                cmd.ExecuteNonQuery()
                MessageBox.Show("Resume uploaded successfully!", "Success")
            Catch ex As Exception
                MessageBox.Show("Error uploading resume: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    ' View saved resume
    Private Sub btnViewResume_Click(sender As Object, e As EventArgs) Handles btnViewResume.Click
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Resume Path] FROM [JobSeeker Information] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() AndAlso Not IsDBNull(reader("Resume Path")) Then
                Dim resumeData As Byte() = CType(reader("Resume Path"), Byte())
                Dim filePath As String = Path.Combine(Path.GetTempPath(), "CareerLift_Resume.pdf")
                File.WriteAllBytes(filePath, resumeData)
                Process.Start(filePath)
            Else
                MessageBox.Show("No resume found.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error opening resume: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    ' Logout and return to login
    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        If MsgBox("Are you sure you want to exit?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Log Out Confirmation") = MsgBoxResult.Yes Then
            Form4.Show()
            LoggedInEmail = ""
            Me.Hide()
        End If
    End Sub

    ' Change password
    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim result = InputBox("Please enter your current password for confirmation:", "Password Confirmation")
        If result = CurrentPassword Then
            Dim newPass = InputBox("Please enter your new password:", "New Password")
            If newPass = "" Then
                MessageBox.Show("Password cannot be empty.")
            Else
                Try
                    con.Open()
                    Dim cmd As New OleDbCommand("UPDATE [JobSeeker Information] SET [Password]=? WHERE Email=?", con)
                    cmd.Parameters.AddWithValue("?", newPass)
                    cmd.Parameters.AddWithValue("?", LoggedInEmail)
                    cmd.ExecuteNonQuery()
                    CurrentPassword = newPass
                    MessageBox.Show("Password updated!")
                Catch ex As Exception
                    MessageBox.Show("Error updating password: " & ex.Message)
                Finally
                    con.Close()
                End Try
            End If
        Else
            MessageBox.Show("Incorrect password!")
        End If
    End Sub

    ' Validation on leave events
    Private Sub txtName_Leave(sender As Object, e As EventArgs) Handles txtName.Leave
        If Not IsNameValid(txtName.Text) Then
            MessageBox.Show("Name should contain only letters and spaces.")
            txtName.Clear()
        End If
    End Sub

    Private Sub txtNo_Leave(sender As Object, e As EventArgs) Handles txtNo.Leave
        If Not IsPhoneNumberValid(txtNo.Text) Then
            MessageBox.Show("Phone number should contain only digits.")
            txtNo.Clear()
        End If
    End Sub

    Private Sub txtCGPA_Leave(sender As Object, e As EventArgs) Handles txtCGPA.Leave
        If Not IsValidCGPA(txtCGPA.Text) Then
            MessageBox.Show("CGPA must be between 0.00 to 4.00")
            txtCGPA.Clear()
        End If
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnHistory.Click
        Form22.Show()
    End Sub

    Private Sub Form9_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        TestingAI.Show()
    End Sub

    Private Sub Form9_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
