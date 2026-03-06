<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class admin4
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim ChartArea1 As System.Windows.Forms.DataVisualization.Charting.ChartArea = New System.Windows.Forms.DataVisualization.Charting.ChartArea()
        Dim Legend1 As System.Windows.Forms.DataVisualization.Charting.Legend = New System.Windows.Forms.DataVisualization.Charting.Legend()
        Dim Series1 As System.Windows.Forms.DataVisualization.Charting.Series = New System.Windows.Forms.DataVisualization.Charting.Series()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(admin4))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.RoundedButton1 = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnLogOut = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnUserFeedback = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnStatistics = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnManagePoster = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnManageUsers = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Chart1 = New System.Windows.Forms.DataVisualization.Charting.Chart()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.lblJobSeekerRevenue = New System.Windows.Forms.Label()
        Me.lblCompanyRevenue = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblTotalRevenue = New System.Windows.Forms.Label()
        Me.label34 = New System.Windows.Forms.Label()
        Me.cboMonthFilter = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(58, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Panel1.Controls.Add(Me.RoundedButton1)
        Me.Panel1.Controls.Add(Me.btnLogOut)
        Me.Panel1.Controls.Add(Me.btnUserFeedback)
        Me.Panel1.Controls.Add(Me.btnStatistics)
        Me.Panel1.Controls.Add(Me.btnManagePoster)
        Me.Panel1.Controls.Add(Me.btnManageUsers)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(244, 721)
        Me.Panel1.TabIndex = 12
        '
        'RoundedButton1
        '
        Me.RoundedButton1.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.RoundedButton1.FlatAppearance.BorderSize = 0
        Me.RoundedButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.RoundedButton1.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.RoundedButton1.ForeColor = System.Drawing.Color.White
        Me.RoundedButton1.Location = New System.Drawing.Point(21, 399)
        Me.RoundedButton1.Name = "RoundedButton1"
        Me.RoundedButton1.Size = New System.Drawing.Size(202, 52)
        Me.RoundedButton1.TabIndex = 9
        Me.RoundedButton1.Text = "Revenue Statistics"
        Me.RoundedButton1.UseVisualStyleBackColor = False
        '
        'btnLogOut
        '
        Me.btnLogOut.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnLogOut.FlatAppearance.BorderSize = 0
        Me.btnLogOut.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnLogOut.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnLogOut.ForeColor = System.Drawing.Color.White
        Me.btnLogOut.Location = New System.Drawing.Point(21, 465)
        Me.btnLogOut.Name = "btnLogOut"
        Me.btnLogOut.Size = New System.Drawing.Size(202, 52)
        Me.btnLogOut.TabIndex = 8
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
        Me.btnUserFeedback.Location = New System.Drawing.Point(21, 328)
        Me.btnUserFeedback.Name = "btnUserFeedback"
        Me.btnUserFeedback.Size = New System.Drawing.Size(202, 52)
        Me.btnUserFeedback.TabIndex = 5
        Me.btnUserFeedback.Text = "User Feedback"
        Me.btnUserFeedback.UseVisualStyleBackColor = False
        '
        'btnStatistics
        '
        Me.btnStatistics.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnStatistics.FlatAppearance.BorderSize = 0
        Me.btnStatistics.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStatistics.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStatistics.ForeColor = System.Drawing.Color.White
        Me.btnStatistics.Location = New System.Drawing.Point(20, 183)
        Me.btnStatistics.Name = "btnStatistics"
        Me.btnStatistics.Size = New System.Drawing.Size(200, 52)
        Me.btnStatistics.TabIndex = 4
        Me.btnStatistics.Text = "View Statistics"
        Me.btnStatistics.UseVisualStyleBackColor = False
        '
        'btnManagePoster
        '
        Me.btnManagePoster.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnManagePoster.FlatAppearance.BorderSize = 0
        Me.btnManagePoster.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManagePoster.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManagePoster.ForeColor = System.Drawing.Color.White
        Me.btnManagePoster.Location = New System.Drawing.Point(20, 260)
        Me.btnManagePoster.Name = "btnManagePoster"
        Me.btnManagePoster.Size = New System.Drawing.Size(202, 52)
        Me.btnManagePoster.TabIndex = 3
        Me.btnManagePoster.Text = "Manage Posters"
        Me.btnManagePoster.UseVisualStyleBackColor = False
        '
        'btnManageUsers
        '
        Me.btnManageUsers.BackColor = System.Drawing.Color.FromArgb(CType(CType(108, Byte), Integer), CType(CType(117, Byte), Integer), CType(CType(125, Byte), Integer))
        Me.btnManageUsers.FlatAppearance.BorderSize = 0
        Me.btnManageUsers.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnManageUsers.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnManageUsers.ForeColor = System.Drawing.Color.White
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
        'Chart1
        '
        ChartArea1.Name = "ChartArea1"
        Me.Chart1.ChartAreas.Add(ChartArea1)
        Legend1.Name = "Legend1"
        Me.Chart1.Legends.Add(Legend1)
        Me.Chart1.Location = New System.Drawing.Point(261, 72)
        Me.Chart1.Name = "Chart1"
        Series1.ChartArea = "ChartArea1"
        Series1.Legend = "Legend1"
        Series1.Name = "Series1"
        Me.Chart1.Series.Add(Series1)
        Me.Chart1.Size = New System.Drawing.Size(917, 637)
        Me.Chart1.TabIndex = 13
        Me.Chart1.Text = "Chart1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(296, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(391, 45)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "Total Purchases Statistics"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(1006, 300)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(300, 28)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "Total Revenue from JobSeeker :"
        '
        'lblJobSeekerRevenue
        '
        Me.lblJobSeekerRevenue.AutoSize = True
        Me.lblJobSeekerRevenue.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobSeekerRevenue.Location = New System.Drawing.Point(1006, 329)
        Me.lblJobSeekerRevenue.Name = "lblJobSeekerRevenue"
        Me.lblJobSeekerRevenue.Size = New System.Drawing.Size(250, 28)
        Me.lblJobSeekerRevenue.TabIndex = 16
        Me.lblJobSeekerRevenue.Text = "Total JobSeeker Revenue :"
        '
        'lblCompanyRevenue
        '
        Me.lblCompanyRevenue.AutoSize = True
        Me.lblCompanyRevenue.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyRevenue.Location = New System.Drawing.Point(1006, 426)
        Me.lblCompanyRevenue.Name = "lblCompanyRevenue"
        Me.lblCompanyRevenue.Size = New System.Drawing.Size(250, 28)
        Me.lblCompanyRevenue.TabIndex = 18
        Me.lblCompanyRevenue.Text = "Total JobSeeker Revenue :"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(1006, 397)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(292, 28)
        Me.Label5.TabIndex = 17
        Me.Label5.Text = "Total Revenue from Company :"
        '
        'lblTotalRevenue
        '
        Me.lblTotalRevenue.AutoSize = True
        Me.lblTotalRevenue.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalRevenue.Location = New System.Drawing.Point(1006, 521)
        Me.lblTotalRevenue.Name = "lblTotalRevenue"
        Me.lblTotalRevenue.Size = New System.Drawing.Size(250, 28)
        Me.lblTotalRevenue.TabIndex = 20
        Me.lblTotalRevenue.Text = "Total JobSeeker Revenue :"
        '
        'label34
        '
        Me.label34.AutoSize = True
        Me.label34.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.label34.Location = New System.Drawing.Point(1006, 492)
        Me.label34.Name = "label34"
        Me.label34.Size = New System.Drawing.Size(219, 28)
        Me.label34.TabIndex = 19
        Me.label34.Text = "Overall Total Revenue :"
        '
        'cboMonthFilter
        '
        Me.cboMonthFilter.FormattingEnabled = True
        Me.cboMonthFilter.Location = New System.Drawing.Point(1011, 240)
        Me.cboMonthFilter.Name = "cboMonthFilter"
        Me.cboMonthFilter.Size = New System.Drawing.Size(237, 24)
        Me.cboMonthFilter.TabIndex = 21
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(1006, 193)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 28)
        Me.Label4.TabIndex = 22
        Me.Label4.Text = "Filter By Month :"
        '
        'admin4
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cboMonthFilter)
        Me.Controls.Add(Me.lblTotalRevenue)
        Me.Controls.Add(Me.label34)
        Me.Controls.Add(Me.lblCompanyRevenue)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.lblJobSeekerRevenue)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Chart1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "admin4"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.Chart1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Panel1 As Panel
    Friend WithEvents RoundedButton1 As RoundedButton
    Friend WithEvents btnLogOut As RoundedButton
    Friend WithEvents btnUserFeedback As RoundedButton
    Friend WithEvents btnStatistics As RoundedButton
    Friend WithEvents btnManagePoster As RoundedButton
    Friend WithEvents btnManageUsers As RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents Chart1 As DataVisualization.Charting.Chart
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents lblJobSeekerRevenue As Label
    Friend WithEvents lblCompanyRevenue As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents lblTotalRevenue As Label
    Friend WithEvents label34 As Label
    Friend WithEvents cboMonthFilter As ComboBox
    Friend WithEvents Label4 As Label
End Class
