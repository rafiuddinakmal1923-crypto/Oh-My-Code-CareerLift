Imports System.Data.OleDb

Public Class Form22
    Private Sub FormHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If UserType = "JobSeeker" Then
            LoadJobSeekerHistory()
        ElseIf UserType = "Company" Then
            LoadCompanyHistory()
        End If
    End Sub

    Private Sub LoadJobSeekerHistory()
        flowpanelHistory.Controls.Clear()


        Try
            con.Open()

            Dim cmd As New OleDbCommand("SELECT [Job Title], [Location], [Salary], [Company Applied], [Application Type],[Application Status] FROM [JobSeeker Application] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)

            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                Dim card As New UserControl1()
                card.Title = reader("Job Title").ToString()
                card.Description = reader("Application Type").ToString()
                card.CompanyName_ = reader("Company Applied").ToString()
                card.Salary = "RM " & reader("Salary").ToString()
                card.Company_Location = reader("Location").ToString()
                card.applicationstatus = reader("Application Status").ToString()

                Dim verificationStat As New OleDbCommand("SELECT [Verified] FROM [Company Information] WHERE [Company Name] = ?", con)
                verificationStat.Parameters.AddWithValue("?", reader("Company Applied").ToString())
                Dim statusReader As OleDbDataReader = verificationStat.ExecuteReader()
                If statusReader.Read() Then
                    card.VerificationStatus = statusReader("Verified").ToString()
                End If

                ' Get company logo
                Dim company As String = reader("Company Applied").ToString()
                Using logoCmd As New OleDbCommand("SELECT [Logo Path] FROM [Company Information] WHERE [Company Name] = ?", con)
                    logoCmd.Parameters.AddWithValue("?", company)
                    Using logoReader As OleDbDataReader = logoCmd.ExecuteReader()
                        If logoReader.Read() AndAlso Not IsDBNull(logoReader("Logo Path")) Then
                            Dim logoBytes As Byte() = CType(logoReader("Logo Path"), Byte())
                            Using ms As New IO.MemoryStream(logoBytes)
                                card.Logo = Image.FromStream(ms)
                            End Using
                        End If
                    End Using
                End Using

                flowpanelHistory.Controls.Add(card)
            End While

            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading jobseeker history: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadCompanyHistory()
        flowpanelHistory.Controls.Clear()

        lblTitle.Text = "Posting History"
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT [Job Title], [Location], [Salary], [Logo Path], [Company Name] FROM [Job Posting] WHERE Email = ?", con)
            cmd.Parameters.AddWithValue("?", LoggedInEmail)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()
            While reader.Read()
                Dim card As New UserControl1()
                card.Title = reader("Job Title").ToString()
                card.Description = reader("Location").ToString()
                card.Salary = "RM " & reader("Salary").ToString()
                card.CompanyName_ = reader("Company Name").ToString()
                card.Company_Location = ""
                card.applicationstatus = ""
                card.VerificationStatus = ""


                If Not IsDBNull(reader("Logo Path")) Then
                    Dim logoBytes As Byte() = CType(reader("Logo Path"), Byte())
                    Using ms As New IO.MemoryStream(logoBytes)
                        card.Logo = Image.FromStream(ms)
                    End Using
                End If
                flowPanelHistory.Controls.Add(card)
            End While
            reader.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading company history: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub
End Class