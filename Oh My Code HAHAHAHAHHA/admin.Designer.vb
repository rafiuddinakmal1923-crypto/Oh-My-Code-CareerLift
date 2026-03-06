<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Admin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim ChartArea2 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend2 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series2 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Admin))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnLogOut = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnUserFeedback = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnViewStatistics = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnManagePosters = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnManageUsers = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.jobCreatedChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.RoundedPanel1 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.lblTCompany = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.lblTSeeker = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.UserChart = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.RoundedButton1 = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Panel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.jobCreatedChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.RoundedPanel1.SuspendLayout()
        CType(Me.UserChart, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.RoundedButton1)
        Me.Panel1.Controls.Add(Me.btnLogOut)
        Me.Panel1.Controls.Add(Me.btnUserFeedback)
        Me.Panel1.Controls.Add(Me.btnViewStatistics)
        Me.Panel1.Controls.Add(Me.btnManagePosters)
        Me.Panel1.Controls.Add(Me.btnManageUsers)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 721)
        Me.Panel1.TabIndex = 0
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnLogOut.FlatAppearance.BorderSize = 0
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.ForeColor = System.Drawing.Color.White
        Me.btnLogOut.Location = New System.Drawing.Point(21, 472)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(202, 52)
        Me.btnLogOut.TabIndex = 7
        Me.btnLogOut.Text = "Log Out"
        Me.btnLogOut.UseVisualStyleBackColor = False
        '
        'btnUserFeedback
        '
        Me.btnUserFeedback.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnUserFeedback.FlatAppearance.BorderSize = 0
        Me.btnUserFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUserFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUserFeedback.ForeColor = System.Drawing.Color.White
        Me.btnUserFeedback.Location = New System.Drawing.Point(21, 334)
        Me.btnUserFeedback.Name = "btnUserFeedback"
        Me.btnUserFeedback.Size = New System.Drawing.Size(202, 52)
        Me.btnUserFeedback.TabIndex = 6
        Me.btnUserFeedback.Text = "User Feedback"
        Me.btnUserFeedback.UseVisualStyleBackColor = False
        '
        'btnViewStatistics
        '
        Me.btnViewStatistics.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnViewStatistics.FlatAppearance.BorderSize = 0
        Me.btnViewStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewStatistics.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewStatistics.Location = New System.Drawing.Point(20, 183)
        Me.btnViewStatistics.Name = "btnViewStatistics"
        Me.btnViewStatistics.Size = New System.Drawing.Size(200, 52)
        Me.btnViewStatistics.TabIndex = 4
        Me.btnViewStatistics.Text = "View Statistics"
        Me.btnViewStatistics.UseVisualStyleBackColor = False
        '
        'btnManagePosters
        '
        Me.btnManagePosters.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnManagePosters.FlatAppearance.BorderSize = 0
        Me.btnManagePosters.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManagePosters.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManagePosters.Location = New System.Drawing.Point(20, 260)
        Me.btnManagePosters.Name = "btnManagePosters"
        Me.btnManagePosters.Size = New System.Drawing.Size(202, 52)
        Me.btnManagePosters.TabIndex = 3
        Me.btnManagePosters.Text = "Manage Poster"
        Me.btnManagePosters.UseVisualStyleBackColor = False
        '
        'btnManageUsers
        '
        Me.btnManageUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnManageUsers.FlatAppearance.BorderSize = 0
        Me.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageUsers.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageUsers.Location = New System.Drawing.Point(19, 111)
        Me.btnManageUsers.Name = "btnManageUsers"
        Me.btnManageUsers.Size = New System.Drawing.Size(200, 52)
        Me.btnManageUsers.TabIndex = 1
        Me.btnManageUsers.Text = "Manage Users"
        Me.btnManageUsers.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 50)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(208, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Admin Dashboard"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.BorderRadius = 20
        Me.RoundedPanel2.Controls.Add(Me.Label5)
        Me.RoundedPanel2.Controls.Add(Me.jobCreatedChart)
        Me.RoundedPanel2.Location = New System.Drawing.Point(276, 376)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(1048, 333)
        Me.RoundedPanel2.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(31, 11)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(287, 38)
        Me.Label5.TabIndex = 7
        Me.Label5.Text = "Job Created Statistics"
        '
        'jobCreatedChart
        '
        ChartArea1.Name = "ChartArea1"
        Me.jobCreatedChart.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.jobCreatedChart.Legends.Add(Legend1)
        Me.jobCreatedChart.Location = New System.Drawing.Point(3, 80)
        Me.jobCreatedChart.Name = "jobCreatedChart"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.jobCreatedChart.Series.Add(Series1)
        Me.jobCreatedChart.Size = New System.Drawing.Size(866, 250)
        Me.jobCreatedChart.TabIndex = 7
        Me.jobCreatedChart.Text = "Chart2"
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.BorderRadius = 20
        Me.RoundedPanel1.Controls.Add(Me.lblTCompany)
        Me.RoundedPanel1.Controls.Add(Me.Label6)
        Me.RoundedPanel1.Controls.Add(Me.lblTSeeker)
        Me.RoundedPanel1.Controls.Add(Me.Label4)
        Me.RoundedPanel1.Controls.Add(Me.Label3)
        Me.RoundedPanel1.Controls.Add(Me.UserChart)
        Me.RoundedPanel1.Controls.Add(Me.Label2)
        Me.RoundedPanel1.Location = New System.Drawing.Point(276, 14)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(1048, 342)
        Me.RoundedPanel1.TabIndex = 1
        '
        'lblTCompany
        '
        Me.lblTCompany.AutoSize = True
        Me.lblTCompany.BackColor = System.Drawing.SystemColors.Window
        Me.lblTCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTCompany.ForeColor = System.Drawing.Color.Black
        Me.lblTCompany.Location = New System.Drawing.Point(743, 246)
        Me.lblTCompany.Name = "lblTCompany"
        Me.lblTCompany.Size = New System.Drawing.Size(109, 17)
        Me.lblTCompany.TabIndex = 6
        Me.lblTCompany.Text = "Total JobSeeker :"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BackColor = System.Drawing.SystemColors.Window
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.Black
        Me.Label6.Location = New System.Drawing.Point(743, 229)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(106, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Total Company :"
        '
        'lblTSeeker
        '
        Me.lblTSeeker.AutoSize = True
        Me.lblTSeeker.BackColor = System.Drawing.SystemColors.Window
        Me.lblTSeeker.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTSeeker.ForeColor = System.Drawing.Color.Black
        Me.lblTSeeker.Location = New System.Drawing.Point(743, 188)
        Me.lblTSeeker.Name = "lblTSeeker"
        Me.lblTSeeker.Size = New System.Drawing.Size(109, 17)
        Me.lblTSeeker.TabIndex = 4
        Me.lblTSeeker.Text = "Total JobSeeker :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.SystemColors.Window
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(743, 169)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(109, 17)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Total JobSeeker :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(196, 63)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(344, 23)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Monthly Sign Up of JobSeeker vs Company"
        '
        'UserChart
        '
        ChartArea2.Name = "ChartArea1"
        Me.UserChart.ChartAreas.Add(ChartArea2)
        Legend2.Name = "Legend1"
        Me.UserChart.Legends.Add(Legend2)
        Me.UserChart.Location = New System.Drawing.Point(3, 89)
        Me.UserChart.Name = "UserChart"
        Series2.ChartArea = "ChartArea1"
        Series2.Legend = "Legend1"
        Series2.Name = "Series1"
        Me.UserChart.Series.Add(Series2)
        Me.UserChart.Size = New System.Drawing.Size(866, 250)
        Me.UserChart.TabIndex = 1
        Me.UserChart.Text = "Chart1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 16.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(31, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 38)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "User Statistics"
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.RoundedButton1.FlatAppearance.BorderSize = 0
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.Color.White
        Me.RoundedButton1.Location = New System.Drawing.Point(21, 405)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(202, 52)
        Me.RoundedButton1.TabIndex = 8
        Me.RoundedButton1.Text = "Revenue Statistics"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'Admin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.WhiteSmoke
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Admin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        CType(Me.jobCreatedChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        CType(Me.UserChart, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents btnManageUsers As RoundedButton
    Friend WithEvents btnManagePosters As RoundedButton
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents UserChart As DataVisualization.Charting.Chart
    Friend WithEvents Label3 As Label
    Friend WithEvents lblTCompany As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents lblTSeeker As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents jobCreatedChart As DataVisualization.Charting.Chart
    Friend WithEvents btnViewStatistics As RoundedButton
    Friend WithEvents btnUserFeedback As RoundedButton
    Friend WithEvents btnLogOut As RoundedButton
    Friend WithEvents RoundedButton1 As RoundedButton
End Class
