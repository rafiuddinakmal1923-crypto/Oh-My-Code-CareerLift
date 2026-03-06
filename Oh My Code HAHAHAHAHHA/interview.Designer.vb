<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class interview
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(interview))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnViewApplicants = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnFeedBack = New System.Windows.Forms.Button()
        Me.btnPosting = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.FlowApplicants = New System.Windows.Forms.FlowLayoutPanel()
        Me.picprofile = New System.Windows.Forms.PictureBox()
        Me.lbl = New System.Windows.Forms.Label()
        Me.lblFullName = New System.Windows.Forms.Label()
        Me.lblInstitution = New System.Windows.Forms.Label()
        Me.lblCGPA = New System.Windows.Forms.Label()
        Me.lblEducation = New System.Windows.Forms.Label()
        Me.lblSkills = New System.Windows.Forms.Label()
        Me.lblAddress = New System.Windows.Forms.Label()
        Me.labelAddress = New System.Windows.Forms.Label()
        Me.lblCity = New System.Windows.Forms.Label()
        Me.lblDOB = New System.Windows.Forms.Label()
        Me.lblGender = New System.Windows.Forms.Label()
        Me.lblPhone = New System.Windows.Forms.Label()
        Me.lblEmail = New System.Windows.Forms.Label()
        Me.lblExperience = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.LabelSkill = New System.Windows.Forms.Label()
        Me.lblGradYear = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dtpDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.dtpTime = New System.Windows.Forms.DateTimePicker()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rbtnPhysical = New System.Windows.Forms.RadioButton()
        Me.rbtnOnline = New System.Windows.Forms.RadioButton()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.txtLocation = New System.Windows.Forms.TextBox()
        Me.lblField = New System.Windows.Forms.Label()
        Me.btnInviteForInterview = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnViewResume = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnReject = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1.SuspendLayout()
        CType(Me.picprofile, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnViewApplicants)
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.btnFeedBack)
        Me.Panel1.Controls.Add(Me.btnPosting)
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1348, 84)
        Me.Panel1.TabIndex = 19
        '
        'btnViewApplicants
        '
        Me.btnViewApplicants.FlatAppearance.BorderSize = 0
        Me.btnViewApplicants.ForeColor = System.Drawing.Color.Black
        Me.btnViewApplicants.Image = CType(resources.GetObject("btnViewApplicants.Image"), System.Drawing.Image)
        Me.btnViewApplicants.Location = New System.Drawing.Point(261, 31)
        Me.btnViewApplicants.Name = "btnViewApplicants"
        Me.btnViewApplicants.Size = New System.Drawing.Size(179, 29)
        Me.btnViewApplicants.TabIndex = 10
        Me.btnViewApplicants.Text = "View Applicants"
        Me.btnViewApplicants.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnViewApplicants.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnViewApplicants.UseVisualStyleBackColor = True
        '
        'btnHome
        '
        Me.btnHome.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnHome.FlatAppearance.BorderSize = 0
        Me.btnHome.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnHome.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHome.ForeColor = System.Drawing.Color.White
        Me.btnHome.Location = New System.Drawing.Point(496, 0)
        Me.btnHome.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnHome.Name = "btnHome"
        Me.btnHome.Size = New System.Drawing.Size(213, 84)
        Me.btnHome.TabIndex = 7
        Me.btnHome.Text = "Home"
        Me.btnHome.UseVisualStyleBackColor = True
        '
        'btnFeedBack
        '
        Me.btnFeedBack.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFeedBack.FlatAppearance.BorderSize = 0
        Me.btnFeedBack.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFeedBack.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFeedBack.ForeColor = System.Drawing.Color.White
        Me.btnFeedBack.Location = New System.Drawing.Point(709, 0)
        Me.btnFeedBack.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFeedBack.Name = "btnFeedBack"
        Me.btnFeedBack.Size = New System.Drawing.Size(213, 84)
        Me.btnFeedBack.TabIndex = 6
        Me.btnFeedBack.Text = "Feedback"
        Me.btnFeedBack.UseVisualStyleBackColor = True
        '
        'btnPosting
        '
        Me.btnPosting.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnPosting.FlatAppearance.BorderSize = 0
        Me.btnPosting.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPosting.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPosting.ForeColor = System.Drawing.Color.White
        Me.btnPosting.Location = New System.Drawing.Point(922, 0)
        Me.btnPosting.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnPosting.Name = "btnPosting"
        Me.btnPosting.Size = New System.Drawing.Size(213, 84)
        Me.btnPosting.TabIndex = 5
        Me.btnPosting.Text = "Posting"
        Me.btnPosting.UseVisualStyleBackColor = True
        '
        'btnProfile
        '
        Me.btnProfile.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnProfile.FlatAppearance.BorderSize = 0
        Me.btnProfile.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnProfile.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnProfile.ForeColor = System.Drawing.Color.White
        Me.btnProfile.Location = New System.Drawing.Point(1135, 0)
        Me.btnProfile.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnProfile.Name = "btnProfile"
        Me.btnProfile.Size = New System.Drawing.Size(213, 84)
        Me.btnProfile.TabIndex = 4
        Me.btnProfile.Text = "Profile"
        Me.btnProfile.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(25, 19)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(152, 41)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "CareerLift"
        '
        'FlowApplicants
        '
        Me.FlowApplicants.AutoScroll = True
        Me.FlowApplicants.Dock = System.Windows.Forms.DockStyle.Left
        Me.FlowApplicants.FlowDirection = System.Windows.Forms.FlowDirection.TopDown
        Me.FlowApplicants.Location = New System.Drawing.Point(0, 84)
        Me.FlowApplicants.Name = "FlowApplicants"
        Me.FlowApplicants.Padding = New System.Windows.Forms.Padding(5)
        Me.FlowApplicants.Size = New System.Drawing.Size(406, 637)
        Me.FlowApplicants.TabIndex = 20
        '
        'picprofile
        '
        Me.picprofile.Location = New System.Drawing.Point(19, 32)
        Me.picprofile.Name = "picprofile"
        Me.picprofile.Size = New System.Drawing.Size(167, 192)
        Me.picprofile.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picprofile.TabIndex = 21
        Me.picprofile.TabStop = False
        '
        'lbl
        '
        Me.lbl.AutoSize = True
        Me.lbl.BackColor = System.Drawing.Color.Transparent
        Me.lbl.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbl.ForeColor = System.Drawing.Color.Black
        Me.lbl.Location = New System.Drawing.Point(205, 17)
        Me.lbl.Name = "lbl"
        Me.lbl.Size = New System.Drawing.Size(363, 54)
        Me.lbl.TabIndex = 23
        Me.lbl.Text = "Applicants Details"
        '
        'lblFullName
        '
        Me.lblFullName.AutoSize = True
        Me.lblFullName.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblFullName.ForeColor = System.Drawing.Color.Black
        Me.lblFullName.Location = New System.Drawing.Point(209, 75)
        Me.lblFullName.Name = "lblFullName"
        Me.lblFullName.Size = New System.Drawing.Size(70, 25)
        Me.lblFullName.TabIndex = 22
        Me.lblFullName.Text = "Name :"
        '
        'lblInstitution
        '
        Me.lblInstitution.AutoSize = True
        Me.lblInstitution.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstitution.ForeColor = System.Drawing.Color.Black
        Me.lblInstitution.Location = New System.Drawing.Point(209, 100)
        Me.lblInstitution.Name = "lblInstitution"
        Me.lblInstitution.Size = New System.Drawing.Size(117, 25)
        Me.lblInstitution.TabIndex = 24
        Me.lblInstitution.Text = "Institutions :"
        '
        'lblCGPA
        '
        Me.lblCGPA.AutoSize = True
        Me.lblCGPA.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCGPA.ForeColor = System.Drawing.Color.Black
        Me.lblCGPA.Location = New System.Drawing.Point(209, 175)
        Me.lblCGPA.Name = "lblCGPA"
        Me.lblCGPA.Size = New System.Drawing.Size(66, 25)
        Me.lblCGPA.TabIndex = 25
        Me.lblCGPA.Text = "CGPA :"
        '
        'lblEducation
        '
        Me.lblEducation.AutoSize = True
        Me.lblEducation.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEducation.ForeColor = System.Drawing.Color.Black
        Me.lblEducation.Location = New System.Drawing.Point(209, 125)
        Me.lblEducation.Name = "lblEducation"
        Me.lblEducation.Size = New System.Drawing.Size(103, 25)
        Me.lblEducation.TabIndex = 26
        Me.lblEducation.Text = "Education :"
        '
        'lblSkills
        '
        Me.lblSkills.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkills.ForeColor = System.Drawing.Color.Black
        Me.lblSkills.Location = New System.Drawing.Point(345, 266)
        Me.lblSkills.Name = "lblSkills"
        Me.lblSkills.Size = New System.Drawing.Size(207, 106)
        Me.lblSkills.TabIndex = 30
        '
        'lblAddress
        '
        Me.lblAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblAddress.ForeColor = System.Drawing.Color.Black
        Me.lblAddress.Location = New System.Drawing.Point(18, 448)
        Me.lblAddress.Name = "lblAddress"
        Me.lblAddress.Size = New System.Drawing.Size(242, 140)
        Me.lblAddress.TabIndex = 29
        '
        'labelAddress
        '
        Me.labelAddress.AutoSize = True
        Me.labelAddress.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.labelAddress.ForeColor = System.Drawing.Color.Black
        Me.labelAddress.Location = New System.Drawing.Point(14, 423)
        Me.labelAddress.Name = "labelAddress"
        Me.labelAddress.Size = New System.Drawing.Size(88, 25)
        Me.labelAddress.TabIndex = 28
        Me.labelAddress.Text = "Address :"
        '
        'lblCity
        '
        Me.lblCity.AutoSize = True
        Me.lblCity.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCity.ForeColor = System.Drawing.Color.Black
        Me.lblCity.Location = New System.Drawing.Point(14, 389)
        Me.lblCity.Name = "lblCity"
        Me.lblCity.Size = New System.Drawing.Size(53, 25)
        Me.lblCity.TabIndex = 27
        Me.lblCity.Text = "City :"
        '
        'lblDOB
        '
        Me.lblDOB.AutoSize = True
        Me.lblDOB.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDOB.ForeColor = System.Drawing.Color.Black
        Me.lblDOB.Location = New System.Drawing.Point(14, 340)
        Me.lblDOB.Name = "lblDOB"
        Me.lblDOB.Size = New System.Drawing.Size(131, 25)
        Me.lblDOB.TabIndex = 34
        Me.lblDOB.Text = "Date Of Birth :"
        '
        'lblGender
        '
        Me.lblGender.AutoSize = True
        Me.lblGender.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGender.ForeColor = System.Drawing.Color.Black
        Me.lblGender.Location = New System.Drawing.Point(14, 310)
        Me.lblGender.Name = "lblGender"
        Me.lblGender.Size = New System.Drawing.Size(83, 25)
        Me.lblGender.TabIndex = 33
        Me.lblGender.Text = "Gender :"
        '
        'lblPhone
        '
        Me.lblPhone.AutoSize = True
        Me.lblPhone.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPhone.ForeColor = System.Drawing.Color.Black
        Me.lblPhone.Location = New System.Drawing.Point(14, 275)
        Me.lblPhone.Name = "lblPhone"
        Me.lblPhone.Size = New System.Drawing.Size(74, 25)
        Me.lblPhone.TabIndex = 32
        Me.lblPhone.Text = "Phone :"
        '
        'lblEmail
        '
        Me.lblEmail.AutoSize = True
        Me.lblEmail.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmail.ForeColor = System.Drawing.Color.Black
        Me.lblEmail.Location = New System.Drawing.Point(14, 241)
        Me.lblEmail.Name = "lblEmail"
        Me.lblEmail.Size = New System.Drawing.Size(65, 25)
        Me.lblEmail.TabIndex = 31
        Me.lblEmail.Text = "Email :"
        '
        'lblExperience
        '
        Me.lblExperience.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblExperience.ForeColor = System.Drawing.Color.Black
        Me.lblExperience.Location = New System.Drawing.Point(345, 414)
        Me.lblExperience.Name = "lblExperience"
        Me.lblExperience.Size = New System.Drawing.Size(207, 91)
        Me.lblExperience.TabIndex = 37
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Black
        Me.Label16.Location = New System.Drawing.Point(345, 389)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(111, 25)
        Me.Label16.TabIndex = 36
        Me.Label16.Text = "Experience :"
        '
        'LabelSkill
        '
        Me.LabelSkill.AutoSize = True
        Me.LabelSkill.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSkill.ForeColor = System.Drawing.Color.Black
        Me.LabelSkill.Location = New System.Drawing.Point(345, 241)
        Me.LabelSkill.Name = "LabelSkill"
        Me.LabelSkill.Size = New System.Drawing.Size(63, 25)
        Me.LabelSkill.TabIndex = 35
        Me.LabelSkill.Text = "Skills :"
        '
        'lblGradYear
        '
        Me.lblGradYear.AutoSize = True
        Me.lblGradYear.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblGradYear.ForeColor = System.Drawing.Color.Black
        Me.lblGradYear.Location = New System.Drawing.Point(209, 200)
        Me.lblGradYear.Name = "lblGradYear"
        Me.lblGradYear.Size = New System.Drawing.Size(154, 25)
        Me.lblGradYear.TabIndex = 39
        Me.lblGradYear.Text = "Graduation Year :"
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(632, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(233, 118)
        Me.Label1.TabIndex = 42
        Me.Label1.Text = "Interview Details"
        '
        'dtpDate
        '
        Me.dtpDate.Location = New System.Drawing.Point(641, 186)
        Me.dtpDate.Name = "dtpDate"
        Me.dtpDate.Size = New System.Drawing.Size(230, 22)
        Me.dtpDate.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Black
        Me.Label2.Location = New System.Drawing.Point(636, 154)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 25)
        Me.Label2.TabIndex = 44
        Me.Label2.Text = "Date :"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(636, 225)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(62, 25)
        Me.Label4.TabIndex = 45
        Me.Label4.Text = "Time :"
        '
        'dtpTime
        '
        Me.dtpTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.dtpTime.Location = New System.Drawing.Point(641, 253)
        Me.dtpTime.Name = "dtpTime"
        Me.dtpTime.ShowUpDown = True
        Me.dtpTime.Size = New System.Drawing.Size(230, 22)
        Me.dtpTime.TabIndex = 46
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(636, 294)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(70, 25)
        Me.Label5.TabIndex = 47
        Me.Label5.Text = "Mode :"
        '
        'rbtnPhysical
        '
        Me.rbtnPhysical.AutoSize = True
        Me.rbtnPhysical.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPhysical.Location = New System.Drawing.Point(640, 326)
        Me.rbtnPhysical.Name = "rbtnPhysical"
        Me.rbtnPhysical.Size = New System.Drawing.Size(77, 21)
        Me.rbtnPhysical.TabIndex = 48
        Me.rbtnPhysical.TabStop = True
        Me.rbtnPhysical.Text = "Physical"
        Me.rbtnPhysical.UseVisualStyleBackColor = True
        '
        'rbtnOnline
        '
        Me.rbtnOnline.AutoSize = True
        Me.rbtnOnline.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnOnline.Location = New System.Drawing.Point(640, 352)
        Me.rbtnOnline.Name = "rbtnOnline"
        Me.rbtnOnline.Size = New System.Drawing.Size(68, 21)
        Me.rbtnOnline.TabIndex = 49
        Me.rbtnOnline.TabStop = True
        Me.rbtnOnline.Text = "Online"
        Me.rbtnOnline.UseVisualStyleBackColor = True
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.Color.Black
        Me.lblLocation.Location = New System.Drawing.Point(636, 384)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(92, 25)
        Me.lblLocation.TabIndex = 50
        Me.lblLocation.Text = "Location :"
        '
        'txtLocation
        '
        Me.txtLocation.Location = New System.Drawing.Point(640, 419)
        Me.txtLocation.Multiline = True
        Me.txtLocation.Name = "txtLocation"
        Me.txtLocation.Size = New System.Drawing.Size(230, 70)
        Me.txtLocation.TabIndex = 51
        '
        'lblField
        '
        Me.lblField.AutoSize = True
        Me.lblField.Font = New System.Drawing.Font("Segoe UI Semibold", 10.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField.ForeColor = System.Drawing.Color.Black
        Me.lblField.Location = New System.Drawing.Point(209, 150)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(61, 25)
        Me.lblField.TabIndex = 53
        Me.lblField.Text = "Field :"
        '
        'btnInviteForInterview
        '
        Me.btnInviteForInterview.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnInviteForInterview.FlatAppearance.BorderSize = 0
        Me.btnInviteForInterview.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnInviteForInterview.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnInviteForInterview.ForeColor = System.Drawing.Color.White
        Me.btnInviteForInterview.Location = New System.Drawing.Point(643, 532)
        Me.btnInviteForInterview.Name = "btnInviteForInterview"
        Me.btnInviteForInterview.Size = New System.Drawing.Size(164, 42)
        Me.btnInviteForInterview.TabIndex = 52
        Me.btnInviteForInterview.Text = "Invite for Interview"
        Me.btnInviteForInterview.UseVisualStyleBackColor = False
        '
        'btnViewResume
        '
        Me.btnViewResume.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnViewResume.FlatAppearance.BorderSize = 0
        Me.btnViewResume.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnViewResume.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnViewResume.ForeColor = System.Drawing.Color.White
        Me.btnViewResume.Location = New System.Drawing.Point(334, 548)
        Me.btnViewResume.Name = "btnViewResume"
        Me.btnViewResume.Size = New System.Drawing.Size(122, 40)
        Me.btnViewResume.TabIndex = 41
        Me.btnViewResume.Text = "View Resume"
        Me.btnViewResume.UseVisualStyleBackColor = False
        '
        'btnReject
        '
        Me.btnReject.BackColor = System.Drawing.Color.Red
        Me.btnReject.FlatAppearance.BorderSize = 0
        Me.btnReject.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnReject.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnReject.ForeColor = System.Drawing.Color.White
        Me.btnReject.Location = New System.Drawing.Point(462, 548)
        Me.btnReject.Name = "btnReject"
        Me.btnReject.Size = New System.Drawing.Size(90, 42)
        Me.btnReject.TabIndex = 40
        Me.btnReject.Text = "Reject"
        Me.btnReject.UseVisualStyleBackColor = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.lblField)
        Me.Panel2.Controls.Add(Me.btnInviteForInterview)
        Me.Panel2.Controls.Add(Me.txtLocation)
        Me.Panel2.Controls.Add(Me.lblLocation)
        Me.Panel2.Controls.Add(Me.rbtnOnline)
        Me.Panel2.Controls.Add(Me.rbtnPhysical)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.dtpTime)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.dtpDate)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Controls.Add(Me.btnViewResume)
        Me.Panel2.Controls.Add(Me.btnReject)
        Me.Panel2.Controls.Add(Me.lblGradYear)
        Me.Panel2.Controls.Add(Me.lblExperience)
        Me.Panel2.Controls.Add(Me.Label16)
        Me.Panel2.Controls.Add(Me.LabelSkill)
        Me.Panel2.Controls.Add(Me.lblDOB)
        Me.Panel2.Controls.Add(Me.lblGender)
        Me.Panel2.Controls.Add(Me.lblPhone)
        Me.Panel2.Controls.Add(Me.lblEmail)
        Me.Panel2.Controls.Add(Me.lblSkills)
        Me.Panel2.Controls.Add(Me.lblAddress)
        Me.Panel2.Controls.Add(Me.labelAddress)
        Me.Panel2.Controls.Add(Me.lblCity)
        Me.Panel2.Controls.Add(Me.lblEducation)
        Me.Panel2.Controls.Add(Me.lblCGPA)
        Me.Panel2.Controls.Add(Me.lblInstitution)
        Me.Panel2.Controls.Add(Me.lbl)
        Me.Panel2.Controls.Add(Me.lblFullName)
        Me.Panel2.Controls.Add(Me.picprofile)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(406, 84)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(942, 637)
        Me.Panel2.TabIndex = 54
        Me.Panel2.Visible = False
        '
        'interview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.FlowApplicants)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "interview"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.picprofile, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnViewApplicants As RoundedButton
    Friend WithEvents btnHome As Button
    Friend WithEvents btnFeedBack As Button
    Friend WithEvents btnPosting As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents FlowApplicants As FlowLayoutPanel
    Friend WithEvents picprofile As PictureBox
    Friend WithEvents lbl As Label
    Friend WithEvents lblFullName As Label
    Friend WithEvents lblInstitution As Label
    Friend WithEvents lblCGPA As Label
    Friend WithEvents lblEducation As Label
    Friend WithEvents lblSkills As Label
    Friend WithEvents lblAddress As Label
    Friend WithEvents labelAddress As Label
    Friend WithEvents lblCity As Label
    Friend WithEvents lblDOB As Label
    Friend WithEvents lblGender As Label
    Friend WithEvents lblPhone As Label
    Friend WithEvents lblEmail As Label
    Friend WithEvents lblExperience As Label
    Friend WithEvents Label16 As Label
    Friend WithEvents LabelSkill As Label
    Friend WithEvents lblGradYear As Label
    Friend WithEvents btnReject As RoundedButton
    Friend WithEvents btnViewResume As RoundedButton
    Friend WithEvents Label1 As Label
    Friend WithEvents dtpDate As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents dtpTime As DateTimePicker
    Friend WithEvents Label5 As Label
    Friend WithEvents rbtnPhysical As RadioButton
    Friend WithEvents rbtnOnline As RadioButton
    Friend WithEvents lblLocation As Label
    Friend WithEvents txtLocation As TextBox
    Friend WithEvents btnInviteForInterview As RoundedButton
    Friend WithEvents lblField As Label
    Friend WithEvents Panel2 As Panel
End Class
