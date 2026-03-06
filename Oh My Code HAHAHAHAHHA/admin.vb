Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting

Public Class Admin

    Private Sub Admin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadSignupChart()
        LoadJobCreatedchart()
    End Sub

    Private Sub LoadSignupChart()
        UserChart.Series.Clear()
        UserChart.ChartAreas(0).AxisX.Title = "Month"
        UserChart.ChartAreas(0).AxisY.Title = "Number of Signups"
        UserChart.Titles.Clear()

        ' Series 1: Company
        Dim seriesCompany As New Series("Company")
        seriesCompany.ChartType = SeriesChartType.Column
        seriesCompany.IsValueShownAsLabel = True
        seriesCompany.Color = Color.DodgerBlue
        UserChart.Series.Add(seriesCompany)

        ' Series 2: JobSeeker
        Dim seriesJobSeeker As New Series("JobSeeker")
        seriesJobSeeker.ChartType = SeriesChartType.Column
        seriesJobSeeker.IsValueShownAsLabel = True
        seriesJobSeeker.Color = Color.MediumSeaGreen
        UserChart.Series.Add(seriesJobSeeker)

        ' Dictionary to hold data
        Dim monthData As New Dictionary(Of String, (Integer, Integer)) ' (CompanyCount, JobSeekerCount)

        Try
            con.Open()

            ' Load Company signups
            Dim cmdCompany As New OleDbCommand("
                 SELECT Format([Sign Up Date], 'yyyy-mm') AS [Month], COUNT(*) AS [Total]
                FROM [Company Information]
                GROUP BY Format([Sign Up Date], 'yyyy-mm')
            ", con)
            Dim readercompany = cmdCompany.ExecuteReader()
            Dim totalCompany As Integer = 0
            While readercompany.Read()
                Dim month = readercompany("Month").ToString()
                Dim total = CInt(readercompany("Total"))
                totalCompany += total
                monthData(month) = (total, 0)
            End While
            lblTCompany.Text = totalCompany.ToString()

            ' Load JobSeeker signups
            Dim cmdJobSeeker As New OleDbCommand("
                SELECT Format([Sign Up Date], 'yyyy-mm') AS [Month], COUNT(*) AS [Total]
                FROM [JobSeeker Information]
                GROUP BY Format([Sign Up Date], 'yyyy-mm')
            ", con)
            Dim readerseeker = cmdJobSeeker.ExecuteReader()
            Dim totalSeeker As Integer = 0
            While readerseeker.Read()
                Dim month = readerseeker("Month").ToString()
                Dim total = CInt(readerseeker("Total"))
                totalSeeker += total
                If monthData.ContainsKey(month) Then
                    Dim existing = monthData(month)
                    monthData(month) = (existing.Item1, total)
                Else
                    monthData(month) = (0, total)
                End If
            End While
            lblTSeeker.Text = totalSeeker.ToString()
            readerseeker.Close()

            ' Sort and display
            For Each entry In monthData.OrderBy(Function(k) k.Key)
                Dim month = entry.Key
                Dim companyCount = entry.Value.Item1
                Dim jobseekerCount = entry.Value.Item2

                seriesCompany.Points.AddXY(month, companyCount)
                seriesJobSeeker.Points.AddXY(month, jobseekerCount)
            Next

        Catch ex As Exception
            MessageBox.Show("Error loading chart: " & ex.Message)
        Finally
            con.Close()
        End Try
    End Sub

    Private Sub LoadJobCreatedchart()
        jobCreatedChart.Series.Clear()
        jobCreatedChart.ChartAreas(0).AxisX.Title = "Month"
        jobCreatedChart.ChartAreas(0).AxisY.Title = "Number of Jobs Created"
        jobCreatedChart.Titles.Clear()

        Dim jobCreatedData As New Dictionary(Of String, Integer)
        Dim seriesJobs As New Series("JobsPosted")
        seriesJobs.ChartType = SeriesChartType.Line
        seriesJobs.IsValueShownAsLabel = True
        jobCreatedChart.Series.Add(seriesJobs)
        seriesJobs.Color = Color.Red
        jobCreatedChart.ChartAreas(0).AxisX.Title = "Month"
        jobCreatedChart.ChartAreas(0).AxisY.Title = "Jobs Created"

        Try
            con.Open()

            ' SQL: tarik bulan dari Application Deadline (atau guna tarikh lain jika lebih sesuai)
            Dim cmdJobCreated As New OleDbCommand("
                SELECT Format([Application Deadline], 'yyyy-mm') AS [Month], COUNT(*) AS [Total]
                FROM [Job Posting]
                GROUP BY Format([Application Deadline], 'yyyy-mm')", con)

            Dim readerJobs = cmdJobCreated.ExecuteReader()
            While readerJobs.Read()
                Dim month = readerJobs("Month").ToString()
                Dim total = CInt(readerJobs("Total"))
                jobCreatedData(month) = total
            End While
            readerJobs.Close()

            ' Papar atas chart
            For Each entry In jobCreatedData.OrderBy(Function(k) k.Key)
                seriesJobs.Points.AddXY(entry.Key, entry.Value)
            Next


        Catch ex As Exception
            MessageBox.Show("Error loading job created chart: " & ex.Message)
        Finally
            con.Close()
        End Try

    End Sub

    Private Sub RoundedButton1_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        Me.Hide()
        admin1vb.Show()
    End Sub

    Private Sub RoundedButton3_Click(sender As Object, e As EventArgs) Handles btnManagePosters.Click
        admin2.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton4_Click(sender As Object, e As EventArgs) Handles btnUserFeedback.Click
        Admin3.Show()
        Me.Hide()
    End Sub

    Private Sub RoundedButton5_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to log out?", MsgBoxStyle.YesNo, "Logout Confirmation")
        If result = MsgBoxResult.Yes Then
            Form4.Show()
            Me.Hide()
        End If

    End Sub

    Private Sub Admin_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
        If con.State = ConnectionState.Open Then
            con.Close()
        End If
        Application.Exit()
    End Sub

    Private Sub RoundedButton1_Click_1(sender As Object, e As EventArgs) Handles RoundedButton1.Click
        Admin4.Show()
        Me.Hide()
    End Sub
End Class

