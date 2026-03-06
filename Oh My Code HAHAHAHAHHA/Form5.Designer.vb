<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form5
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form5))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnSearchjobs = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnFeedback = New System.Windows.Forms.Button()
        Me.btnSubscription = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.pcbPoster = New System.Windows.Forms.PictureBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.btnPrevious = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnStartJobsearch = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Panel1.SuspendLayout()
        CType(Me.pcbPoster, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnSearchjobs)
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.btnFeedback)
        Me.Panel1.Controls.Add(Me.btnSubscription)
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1058, 68)
        Me.Panel1.TabIndex = 1
        '
        'btnSearchjobs
        '
        Me.btnSearchjobs.FlatAppearance.BorderSize = 0
        Me.btnSearchjobs.Image = CType(resources.GetObject("btnSearchjobs.Image"), System.Drawing.Image)
        Me.btnSearchjobs.Location = New System.Drawing.Point(220, 23)
        Me.btnSearchjobs.Name = "btnSearchjobs"
        Me.btnSearchjobs.Size = New System.Drawing.Size(179, 29)
        Me.btnSearchjobs.TabIndex = 8
        Me.btnSearchjobs.Text = "Search for jobs"
        Me.btnSearchjobs.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnSearchjobs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnSearchjobs.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Location = New System.Drawing.Point(418, 0)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(129, 68)
        Me.btnHome.TabIndex = 7
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnFeedback
        '
        Me.btnFeedback.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFeedback.FlatAppearance.BorderSize = 0
        Me.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFeedback.ForeColor = System.Drawing.Color.White
        Me.btnFeedback.Location = New System.Drawing.Point(547, 0)
        Me.btnFeedback.Name = "btnFeedback"
        Me.btnFeedback.Size = New System.Drawing.Size(160, 68)
        Me.btnFeedback.TabIndex = 6
        Me.btnFeedback.Text = "Feedback"
        Me.btnFeedback.UseVisualStyleBackColor = True
        '
        'btnSubscription
        '
        Me.btnSubscription.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnSubscription.FlatAppearance.BorderSize = 0
        Me.btnSubscription.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSubscription.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSubscription.ForeColor = System.Drawing.Color.White
        Me.btnSubscription.Location = New System.Drawing.Point(707, 0)
        Me.btnSubscription.Name = "btnSubscription"
        Me.btnSubscription.Size = New System.Drawing.Size(205, 68)
        Me.btnSubscription.TabIndex = 5
        Me.btnSubscription.Text = "Subscription"
        Me.btnSubscription.UseVisualStyleBackColor = True
        '
        'btnProfile
        '
        Me.btnProfile.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnProfile.FlatAppearance.BorderSize = 0
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.ForeColor = System.Drawing.Color.White
        Me.btnProfile.Location = New System.Drawing.Point(912, 0)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(146, 68)
        Me.btnProfile.TabIndex = 4
        Me.btnProfile.Text = "Profile"
        Me.btnProfile.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(33, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 41)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "CareerLift"
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 36.0!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(601, 162)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Landing Your " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "First Job Made Easy "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(22, 309)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(464, 62)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Discover opportunities for fresh graduates " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "and lift your career to new heights " &
    ""
        '
        'pcbPoster
        '
        Me.pcbPoster.Image = CType(resources.GetObject("pcbPoster.Image"), System.Drawing.Image)
        Me.pcbPoster.Location = New System.Drawing.Point(622, 129)
        Me.pcbPoster.Name = "pcbPoster"
        Me.pcbPoster.Size = New System.Drawing.Size(341, 400)
        Me.pcbPoster.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcbPoster.TabIndex = 8
        Me.pcbPoster.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(22, 498)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(228, 31)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "What we offers you :"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(423, 540)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(192, 31)
        Me.Label7.TabIndex = 12
        Me.Label7.Text = "Career Resources"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(181, 540)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(205, 31)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Resume Templates"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 13.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(22, 540)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(131, 31)
        Me.Label5.TabIndex = 14
        Me.Label5.Text = "Job Listing "
        '
        'btnPrevious
        '
        Me.btnPrevious.BackColor = System.Drawing.Color.White
        Me.btnPrevious.BackgroundImage = CType(resources.GetObject("btnPrevious.BackgroundImage"), System.Drawing.Image)
        Me.btnPrevious.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnPrevious.FlatAppearance.BorderSize = 0
        Me.btnPrevious.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPrevious.Location = New System.Drawing.Point(557, 314)
        Me.btnPrevious.Name = "btnPrevious"
        Me.btnPrevious.Size = New System.Drawing.Size(35, 40)
        Me.btnPrevious.TabIndex = 15
        Me.btnPrevious.UseVisualStyleBackColor = False
        '
        'btnNext
        '
        Me.btnNext.BackColor = System.Drawing.Color.White
        Me.btnNext.BackgroundImage = CType(resources.GetObject("btnNext.BackgroundImage"), System.Drawing.Image)
        Me.btnNext.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.btnNext.FlatAppearance.BorderSize = 0
        Me.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnNext.Location = New System.Drawing.Point(984, 314)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(35, 40)
        Me.btnNext.TabIndex = 16
        Me.btnNext.UseVisualStyleBackColor = False
        '
        'btnStartJobsearch
        '
        Me.btnStartJobsearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnStartJobsearch.FlatAppearance.BorderSize = 0
        Me.btnStartJobsearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnStartJobsearch.Font = New System.Drawing.Font("Segoe UI Emoji", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnStartJobsearch.ForeColor = System.Drawing.Color.White
        Me.btnStartJobsearch.Location = New System.Drawing.Point(28, 412)
        Me.btnStartJobsearch.Name = "btnStartJobsearch"
        Me.btnStartJobsearch.Size = New System.Drawing.Size(428, 66)
        Me.btnStartJobsearch.TabIndex = 5
        Me.btnStartJobsearch.Text = "Get Started"
        Me.btnStartJobsearch.UseVisualStyleBackColor = False
        '
        'Form5
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 17.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1058, 594)
        Me.Controls.Add(Me.btnNext)
        Me.Controls.Add(Me.btnPrevious)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.pcbPoster)
        Me.Controls.Add(Me.btnStartJobsearch)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form5"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.pcbPoster, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents btnHome As Button
    Friend WithEvents btnFeedback As Button
    Friend WithEvents btnSubscription As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents btnStartJobsearch As RoundedButton
    Friend WithEvents pcbPoster As PictureBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents btnSearchjobs As RoundedButton
    Friend WithEvents btnPrevious As Button
    Friend WithEvents btnNext As Button
End Class
