Imports System.Data.OleDb
Imports System.IO

Public Class Form2


    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles btnHome.Click
        Form8.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles btnFeedback.Click
        Form3.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles btnSubscription.Click
        Form10.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton2_Click(sender As Object, e As EventArgs) Handles btnViewApplicants.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub UpdateProgress()
        Dim totalFields As Integer = 6
        Dim filledFields As Integer = 0

        If txtCompanyName.Text.Trim() <> "" Then filledFields += 1
        If cboCompanySize.Text.Trim() <> "" Then filledFields += 1
        If txtIndustry.Text.Trim() <> "" Then filledFields += 1
        If txtContactName.Text.Trim() <> "" Then filledFields += 1
        If txtContactNumber.Text.Trim() <> "" Then filledFields += 1
        If txtDescription.Text.Trim() <> "" Then filledFields += 1

        Dim percent As Integer = CInt((filledFields / totalFields) * 100)
        pgbUpdate.Value = percent
        lblProgress.Text = "Your company profile is " & percent.ToString() & "% complete."
    End Sub


    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        lblProgress.Visible = True
        txtCompanyName.ReadOnly = False
        txtCompanyEmail.ReadOnly = True
        txtIndustry.ReadOnly = False
        btnComplete.Visible = True
        pgbUpdate.Visible = True
        txtDescription.ReadOnly = False
        txtContactName.ReadOnly = False
        txtContactNumber.ReadOnly = False
        cboCompanySize.Enabled = True
        btnUploadSSM.Visible = True
        btnViewSSM.Visible = False
        txtCompanyName.Focus()
    End Sub

    Private Sub AllTextBox_TextChanged(sender As Object, e As EventArgs) _
    Handles txtCompanyName.TextChanged,
            txtCompanyEmail.TextChanged, txtIndustry.TextChanged, txtContactName.TextChanged, txtContactNumber.TextChanged, txtDescription.TextChanged, cboCompanySize.TextChanged

        UpdateProgress()
    End Sub

    ' Check word and space only
    Private Function IsTextOnly(text As String) As Boolean
        Return text.All(Function(c) Char.IsLetter(c) OrElse Char.IsWhiteSpace(c))
    End Function

    ' Check numbers only
    Private Function IsDigitsOnly(text As String) As Boolean
        Return text.All(AddressOf Char.IsDigit)
    End Function

    ' Company Name
    Private Sub txtCompanyName_Leave(sender As Object, e As EventArgs) Handles txtCompanyName.Leave
        If Not IsTextOnly(txtCompanyName.Text) Then
            MessageBox.Show("Company Name should only contain letters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' Contact Person Name
    Private Sub txtContactName_Leave(sender As Object, e As EventArgs) Handles txtContactName.Leave
        If Not IsTextOnly(txtContactName.Text) Then
            MessageBox.Show("Contact Name should only contain letters and spaces.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' Contact Person Number
    Private Sub txtContactNumber_Leave(sender As Object, e As EventArgs) Handles txtContactNumber.Leave
        If Not IsDigitsOnly(txtContactNumber.Text) Then
            MessageBox.Show("Contact Number should only contain digits.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' must be choosed
    Private Sub txtIndustry_Leave(sender As Object, e As EventArgs) Handles txtIndustry.Leave
        If txtIndustry.Text.Trim() = "" Then
            MessageBox.Show("Industry field cannot be empty.", "Missing Field", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub

    ' must be choosed
    Private Sub cboCompanySize_Leave(sender As Object, e As EventArgs) Handles cboCompanySize.Leave
        If cboCompanySize.SelectedIndex = -1 Then
            MessageBox.Show("Please select a Company Size.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)

        End If
    End Sub


    Private Sub btnComplete_Click(sender As Object, e As EventArgs) Handles btnComplete.Click
        ' Validation
        If txtCompanyName.Text = "" Or txtCompanyEmail.Text = "" Or txtIndustry.Text = "" Or
       txtContactName.Text = "" Or txtContactNumber.Text = "" Or cboCompanySize.Text = "" Then
            MessageBox.Show("Please fill in all fields before saving.", "Incomplete Data", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        ' UI Lock after submission
        lblProgress.Visible = False
        txtCompanyName.ReadOnly = True
        txtCompanyEmail.ReadOnly = True
        txtContactName.ReadOnly = True
        txtContactNumber.ReadOnly = True
        cboCompanySize.Enabled = False
        txtDescription.ReadOnly = True
        txtIndustry.ReadOnly = True
        btnComplete.Visible = False
        pgbUpdate.Visible = False
        btnUploadSSM.Visible = False
        btnViewSSM.Visible = True

        Try
            con.Open()

            ' Get old company name
            Dim oldCompanyName As String = ""
            Dim getOldCmd As New OleDbCommand("SELECT [Company Name] FROM [Company Information] WHERE [Company Email] = ?", con)
            getOldCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader = getOldCmd.ExecuteReader()
            If reader.Read() Then
                oldCompanyName = reader("Company Name").ToString()
            End If
            reader.Close()

            ' Check if company record exists
            Dim checkCmd As New OleDbCommand("SELECT COUNT(*) FROM [Company Information] WHERE [Company Email] = ?", con)
            checkCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim count As Integer = CInt(checkCmd.ExecuteScalar())

            If count > 0 Then
                ' Update Company Information
                Dim updateCmd As New OleDbCommand("UPDATE [Company Information] SET [Company Name]=?, [Company Size]=?, [Company Industry]=?, [Contact Person Name]=?, [Contact Person Number]=?, [Company Description]=? WHERE [Company Email]=?", con)
                updateCmd.Parameters.AddWithValue("?", txtCompanyName.Text)
                updateCmd.Parameters.AddWithValue("?", cboCompanySize.Text)
                updateCmd.Parameters.AddWithValue("?", txtIndustry.Text)
                updateCmd.Parameters.AddWithValue("?", txtContactName.Text)
                updateCmd.Parameters.AddWithValue("?", txtContactNumber.Text)
                updateCmd.Parameters.AddWithValue("?", txtDescription.Text)
                updateCmd.Parameters.AddWithValue("?", LoggedInEmail)
                updateCmd.ExecuteNonQuery()

                ' Update related tables with new company name
                If oldCompanyName <> txtCompanyName.Text Then
                    ' 1. Job Posting table
                    Dim updatePost As New OleDbCommand("UPDATE [Job Posting] SET [Company Name] = ? WHERE [Company Name] = ?", con)
                    updatePost.Parameters.AddWithValue("?", txtCompanyName.Text)
                    updatePost.Parameters.AddWithValue("?", oldCompanyName)
                    updatePost.ExecuteNonQuery()

                    ' 2. JobSeeker Application table
                    Dim updateApplication As New OleDbCommand("UPDATE [JobSeeker Application] SET [Company Applied] = ? WHERE [Company Applied] = ?", con)
                    updateApplication.Parameters.AddWithValue("?", txtCompanyName.Text)
                    updateApplication.Parameters.AddWithValue("?", oldCompanyName)
                    updateApplication.ExecuteNonQuery()

                End If

                MessageBox.Show("Company profile and related data updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                ' Insert new company
                Dim insertCmd As New OleDbCommand("INSERT INTO [Company Information] ([Company Name], [Company Email], [Company Size], [Company Industry], [Contact Person Name], [Contact Person Number], [Company Description]) VALUES (?, ?, ?, ?, ?, ?, ?)", con)
                insertCmd.Parameters.AddWithValue("?", txtCompanyName.Text)
                insertCmd.Parameters.AddWithValue("?", LoggedInEmail)
                insertCmd.Parameters.AddWithValue("?", cboCompanySize.Text)
                insertCmd.Parameters.AddWithValue("?", txtIndustry.Text)
                insertCmd.Parameters.AddWithValue("?", txtContactName.Text)
                insertCmd.Parameters.AddWithValue("?", txtContactNumber.Text)
                insertCmd.Parameters.AddWithValue("?", txtDescription.Text)
                insertCmd.ExecuteNonQuery()

                MessageBox.Show("Company profile created successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            End If

            UpdateProgress()

        Catch ex As Exception
            MessageBox.Show("Error saving profile: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Activated
        txtCompanyEmail.Text = LoggedInEmail
        Try
            con.Open()

            Dim cmd As New OleDbCommand("SELECT [Company Name], [Company Email], [Company Size], [Company Industry], [Contact Person Name], [Contact Person Number], [Company Description], [SSM Attachment], [Logo Path], Verified FROM [Company Information] WHERE [Company Email] = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            If reader.Read() Then
                txtCompanyName.Text = reader("Company Name").ToString()
                txtCompanyEmail.Text = reader("Company Email").ToString()
                cboCompanySize.Text = reader("Company Size").ToString()
                txtIndustry.Text = reader("Company Industry").ToString()
                txtContactName.Text = reader("Contact Person Name").ToString()
                txtContactNumber.Text = reader("Contact Person Number").ToString()
                txtDescription.Text = reader("Company Description").ToString()
                lblVerifiedStatus.Text = reader("Verified").ToString()

                If lblVerifiedStatus.Text = "Verified" Then
                    lblVerifiedStatus.ForeColor = Color.LimeGreen
                Else
                    lblVerifiedStatus.ForeColor = Color.Red
                End If


                ' Load SSM Attachment if it exists
                If Not IsDBNull(reader("SSM Attachment")) Then
                    btnViewSSM.Visible = True
                Else
                    btnViewSSM.Visible = False
                End If

                ' Load Company Logo if it exists
                If Not IsDBNull(reader("Logo Path")) Then
                    Dim logoBytes As Byte() = CType(reader("Logo Path"), Byte())
                    Using ms As New IO.MemoryStream(logoBytes)
                        PictureBoxCompanyLogo.Image = Image.FromStream(ms)
                    End Using
                End If


            End If

            reader.Close()
        Catch ex As Exception
            'MessageBox.Show("Error loading company profile: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result = MsgBox("Are you sure you want to exit", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "Log Out Confirmation")

        If result = MsgBoxResult.Yes Then
            Form4.Show()
            LoggedInEmail = ""
            Me.Hide()
        End If

    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Dim result = InputBox("Please enter your current password for confirmation:", "Password Confirmation")
        If result = CurrentPassword Then
            Dim newpassword = InputBox("Please enter your new password:", "New Password")
            If newpassword = "" Then
                MessageBox.Show("Password cannot be empty.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Else
                CurrentPassword = newpassword
                ' Update the new password in the database
                Dim updateCmd As New OleDbCommand("UPDATE [Company Information] SET [Password]=? WHERE [Company Email]=?", con)
                updateCmd.Parameters.AddWithValue("?", newpassword)
                updateCmd.Parameters.AddWithValue("?", LoggedInEmail)
                Try
                    con.Open()
                    updateCmd.ExecuteNonQuery()
                    MessageBox.Show("Password updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    CurrentPassword = newpassword
                Catch ex As Exception
                    MessageBox.Show("Error updating password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Finally
                    con.Close()
                End Try
            End If
        Else
            MessageBox.Show("Incorrect password. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub

    Private Sub btnUploadImage_Click(sender As Object, e As EventArgs) Handles btnUploadImage.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Title = "Select a Profile Picture"
        openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            PictureBoxCompanyLogo.Image = Image.FromFile(openFileDialog.FileName)
            PictureBoxCompanyLogo.SizeMode = PictureBoxSizeMode.StretchImage
        End If

        Dim imgData As Byte() = Nothing

        If PictureBoxCompanyLogo.Image IsNot Nothing Then
            Using ms As New IO.MemoryStream()
                Dim bmp As New Bitmap(PictureBoxCompanyLogo.Image)
                bmp.Save(ms, Imaging.ImageFormat.Jpeg)
                imgData = ms.ToArray()
            End Using
        End If

        Try
            con.Open()

            ' Get current company name
            Dim companyName As String = ""
            Dim getNameCmd As New OleDbCommand("SELECT [Company Name] FROM [Company Information] WHERE [Company Email] = ?", con)
            getNameCmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader = getNameCmd.ExecuteReader()
            If reader.Read() Then
                companyName = reader("Company Name").ToString()
            End If
            reader.Close()

            ' Update logo in Company Information
            Dim cmd As New OleDbCommand("UPDATE [Company Information] SET [Logo Path] = ? WHERE [Company Email] = ?", con)
            cmd.Parameters.AddWithValue("?", imgData)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim result As Integer = cmd.ExecuteNonQuery()
            If result > 0 Then
                ' Also update Job Posting table logo
                Dim updateJobPostLogo As New OleDbCommand("UPDATE [Job Posting] SET [Logo Path] = ? WHERE [Company Name] = ?", con)
                updateJobPostLogo.Parameters.AddWithValue("?", imgData)
                updateJobPostLogo.Parameters.AddWithValue("?", companyName)
                updateJobPostLogo.ExecuteNonQuery()

                MessageBox.Show("Profile picture saved and updated in all related records!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Else
                MessageBox.Show("Email not found or update failed.")
            End If
        Catch ex As Exception
            MessageBox.Show("Error saving image: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub


    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnUploadSSM.Click
        Dim openFileDialog As New OpenFileDialog()
        openFileDialog.Filter = "PDF Files|*.pdf"

        If openFileDialog.ShowDialog() = DialogResult.OK Then
            Dim fileData As Byte() = IO.File.ReadAllBytes(openFileDialog.FileName)
            Try
                con.Open()
                Dim cmd As New OleDbCommand("UPDATE [Company Information] SET [SSM Attachment]=? WHERE [Company Email]=?", con)
                cmd.Parameters.AddWithValue("?", fileData)
                cmd.Parameters.AddWithValue("?", LoggedInEmail)
                cmd.ExecuteNonQuery()

                MessageBox.Show("SSM Document uploaded successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)
            Catch ex As Exception
                MessageBox.Show("Error uploading SSM: " & ex.Message)
            Finally
                con.Close()
            End Try
        End If
    End Sub

    Private Sub RoundedButton1_Click_1(sender As Object, e As EventArgs) Handles btnViewSSM.Click
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [SSM Attachment] FROM [Company Information] WHERE [Company Email]=?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            If reader.Read() AndAlso Not IsDBNull(reader("SSM Attachment")) Then
                Dim fileData As Byte() = CType(reader("SSM Attachment"), Byte())
                Dim tempPath As String = Path.Combine(IO.Path.GetTempPath(), "SSM_Document.pdf")
                IO.File.WriteAllBytes(tempPath, fileData)
                Process.Start(tempPath)
            Else
                MessageBox.Show("No SSM document found.")
            End If
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error viewing SSM: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub Button2_Click_1(sender As Object, e As EventArgs) Handles btnPostingHistory.Click
        Form22.Show()
    End Sub

    Private Sub Form2_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub Form2_Load_1(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class