Imports System.Data.OleDb
Imports System.Windows.Forms.DataVisualization.Charting


Public Class admin4

    Private Sub RevenueDashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        cboMonthFilter.Items.Clear()
        cboMonthFilter.Items.Add("All")

        ' Populate ComboBox with available months in format yyyy-MM
        Try
            con.Open()
            Dim cmd As New OleDbCommand("SELECT DISTINCT Format([PurchaseDate], 'yyyy-MM') AS PurchaseMonth FROM [Banking Details] UNION SELECT DISTINCT Format([PurchaseDate], 'yyyy-MM') FROM [Company Banking Details]", con)
            Dim reader As OleDbDataReader = cmd.ExecuteReader()

            While reader.Read()
                cboMonthFilter.Items.Add(reader(0).ToString())
            End While
            reader.Close()
            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading months: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        cboMonthFilter.SelectedIndex = 0 ' Default to All
    End Sub

    Private Sub cboMonthFilter_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMonthFilter.SelectedIndexChanged
        Dim selectedMonth = cboMonthFilter.SelectedItem.ToString()

        If selectedMonth = "All" Then
            LoadRevenueChart()
            LoadTotalRevenue()
        Else
            LoadRevenueChart(selectedMonth)

            ' Extract revenue only for selected month
            Dim jsRevenue As Decimal = 0
            Dim companyRevenue As Decimal = 0

            Try
                Dim yearPart As String = selectedMonth.Split("-"c)(0)
                Dim monthPart As String = selectedMonth.Split("-"c)(1)

                con.Open()

                ' JobSeeker revenue for selected month (PurchaseDate and TotalPayment stored as Short Text)
                Dim cmdJS As New OleDbCommand("SELECT SUM(Val([TotalPayment])) FROM [Banking Details] WHERE [Subscription Plan] IS NOT NULL AND Format([PurchaseDate], 'yyyy') = ? AND Format([PurchaseDate], 'mm') = ?", con)
                cmdJS.Parameters.AddWithValue("?", yearPart)
                cmdJS.Parameters.AddWithValue("?", monthPart)
                jsRevenue = If(IsDBNull(cmdJS.ExecuteScalar()), 0, Convert.ToDecimal(cmdJS.ExecuteScalar()))

                ' Company revenue for selected month
                Dim cmdCompany As New OleDbCommand("SELECT SUM(Val([TotalPayment])) FROM [Company Banking Details] WHERE Format([PurchaseDate], 'yyyy') = ? AND Format([PurchaseDate], 'mm') = ?", con)
                cmdCompany.Parameters.AddWithValue("?", yearPart)
                cmdCompany.Parameters.AddWithValue("?", monthPart)
                companyRevenue = If(IsDBNull(cmdCompany.ExecuteScalar()), 0, Convert.ToDecimal(cmdCompany.ExecuteScalar()))

                con.Close()
            Catch ex As Exception
                MessageBox.Show("Error loading month revenue: " & ex.Message)
                If con.State = ConnectionState.Open Then con.Close()
            End Try

            lblJobSeekerRevenue.Text = "RM " & jsRevenue.ToString("N2")
            lblCompanyRevenue.Text = "RM " & companyRevenue.ToString("N2")
            lblTotalRevenue.Text = "RM " & (jsRevenue + companyRevenue).ToString("N2")
        End If
    End Sub



    Private Sub LoadTotalRevenue()
        Dim jsRevenue As Decimal = 0
        Dim companyRevenue As Decimal = 0

        Try
            con.Open()

            ' For all data
            Dim cmdJS As New OleDbCommand("SELECT SUM(Val([TotalPayment])) FROM [Banking Details] WHERE [Subscription Plan] IS NOT NULL", con)
            jsRevenue = If(IsDBNull(cmdJS.ExecuteScalar()), 0, Convert.ToDecimal(cmdJS.ExecuteScalar()))

            Dim cmdCompany As New OleDbCommand("SELECT SUM(Val([TotalPayment])) FROM [Company Banking Details]", con)
            companyRevenue = If(IsDBNull(cmdCompany.ExecuteScalar()), 0, Convert.ToDecimal(cmdCompany.ExecuteScalar()))

            con.Close()
        Catch ex As Exception
            MessageBox.Show("Error loading total revenue: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try

        lblJobSeekerRevenue.Text = "RM " & jsRevenue.ToString("N2")
        lblCompanyRevenue.Text = "RM " & companyRevenue.ToString("N2")
        lblTotalRevenue.Text = "RM " & (jsRevenue + companyRevenue).ToString("N2")
    End Sub

    Private Sub LoadRevenueChart(Optional selectedMonth As String = "All")
        Chart1.Series.Clear()
        Chart1.ChartAreas(0).AxisX.Title = "Month"
        Chart1.ChartAreas(0).AxisY.Title = "Revenue (RM)"

        Dim jsSeries As New Series("JobSeeker Revenue")
        jsSeries.ChartType = SeriesChartType.Line
        jsSeries.BorderWidth = 2

        Dim companySeries As New Series("Company Revenue")
        companySeries.ChartType = SeriesChartType.Line
        companySeries.BorderWidth = 2

        Try
            con.Open()

            ' Use dictionary to accumulate revenue by month
            Dim jsDict As New Dictionary(Of String, Decimal)
            Dim companyDict As New Dictionary(Of String, Decimal)

            ' JobSeeker revenue
            Dim cmdJS As New OleDbCommand("SELECT PurchaseDate, TotalPayment FROM [Banking Details] WHERE [Subscription Plan] IS NOT NULL", con)
            Dim readerJS = cmdJS.ExecuteReader()
            While readerJS.Read()
                Dim dateStr As String = readerJS("PurchaseDate").ToString()
                Dim paymentStr As String = readerJS("TotalPayment").ToString()
                If Date.TryParse(dateStr, Nothing) AndAlso Decimal.TryParse(paymentStr, Nothing) Then
                    Dim dt = Date.Parse(dateStr)
                    Dim key = dt.ToString("yyyy-MM")
                    Dim value = Decimal.Parse(paymentStr)
                    If jsDict.ContainsKey(key) Then
                        jsDict(key) += value
                    Else
                        jsDict(key) = value
                    End If
                End If
            End While
            readerJS.Close()

            ' Company revenue
            Dim cmdCompany As New OleDbCommand("SELECT PurchaseDate, TotalPayment FROM [Company Banking Details] WHERE [PurchaseDate] IS NOT NULL", con)
            Dim readerCompany = cmdCompany.ExecuteReader()
            While readerCompany.Read()
                Dim dateStr As String = readerCompany("PurchaseDate").ToString()
                Dim paymentStr As String = readerCompany("TotalPayment").ToString()
                If Date.TryParse(dateStr, Nothing) AndAlso Decimal.TryParse(paymentStr, Nothing) Then
                    Dim dt = Date.Parse(dateStr)
                    Dim key = dt.ToString("yyyy-MM")
                    Dim value = Decimal.Parse(paymentStr)
                    If companyDict.ContainsKey(key) Then
                        companyDict(key) += value
                    Else
                        companyDict(key) = value
                    End If
                End If
            End While
            readerCompany.Close()

            con.Close()

            ' Sort and bind to chart
            For Each monthKey In jsDict.Keys.OrderBy(Function(k) k)
                jsSeries.Points.AddXY(monthKey, jsDict(monthKey))
            Next
            For Each monthKey In companyDict.Keys.OrderBy(Function(k) k)
                companySeries.Points.AddXY(monthKey, companyDict(monthKey))
            Next

            Chart1.Series.Add(jsSeries)
            Chart1.Series.Add(companySeries)

        Catch ex As Exception
            MessageBox.Show("Error loading revenue chart: " & ex.Message)
            If con.State = ConnectionState.Open Then con.Close()
        End Try
    End Sub

    Private Sub btnManageUsers_Click(sender As Object, e As EventArgs) Handles btnManageUsers.Click
        admin1vb.Show()
        Me.Hide()
    End Sub

    Private Sub btnStatistics_Click(sender As Object, e As EventArgs) Handles btnStatistics.Click
        Admin.Show()
        Me.Hide()
    End Sub

    Private Sub btnManagePoster_Click(sender As Object, e As EventArgs) Handles btnManagePoster.Click
        admin2.Show()
        Me.Hide()
    End Sub

    Private Sub btnUserFeedback_Click(sender As Object, e As EventArgs) Handles btnUserFeedback.Click
        Admin3.Show()
        Me.Hide()
    End Sub

    Private Sub btnLogOut_Click(sender As Object, e As EventArgs) Handles btnLogOut.Click
        Dim result As DialogResult = MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)
        If result = DialogResult.Yes Then
            Form4.Show()
            Me.Close()
        End If
    End Sub
End Class

