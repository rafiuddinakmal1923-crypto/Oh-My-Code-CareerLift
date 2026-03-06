<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserControl1
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(UserControl1))
        Me.RoundedPanel2 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblApplicationStatus = New System.Windows.Forms.Label()
        Me.lblVerified = New System.Windows.Forms.Label()
        Me.lblCompany = New System.Windows.Forms.Label()
        Me.lblDescription = New System.Windows.Forms.Label()
        Me.picLogo = New System.Windows.Forms.PictureBox()
        Me.lblSalary = New System.Windows.Forms.Label()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.RoundedPanel2.SuspendLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BackColor = System.Drawing.Color.White
        Me.RoundedPanel2.BorderRadius = 20
        Me.RoundedPanel2.Controls.Add(Me.Label1)
        Me.RoundedPanel2.Controls.Add(Me.lblApplicationStatus)
        Me.RoundedPanel2.Controls.Add(Me.lblVerified)
        Me.RoundedPanel2.Controls.Add(Me.lblCompany)
        Me.RoundedPanel2.Controls.Add(Me.lblDescription)
        Me.RoundedPanel2.Controls.Add(Me.picLogo)
        Me.RoundedPanel2.Controls.Add(Me.lblSalary)
        Me.RoundedPanel2.Controls.Add(Me.lblLocation)
        Me.RoundedPanel2.Controls.Add(Me.lblTitle)
        Me.RoundedPanel2.Location = New System.Drawing.Point(0, 0)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(509, 117)
        Me.RoundedPanel2.TabIndex = 26
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(415, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 20)
        Me.Label1.TabIndex = 40
        Me.Label1.Text = "Status :"
        '
        'lblApplicationStatus
        '
        Me.lblApplicationStatus.AutoSize = True
        Me.lblApplicationStatus.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblApplicationStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblApplicationStatus.Location = New System.Drawing.Point(416, 70)
        Me.lblApplicationStatus.Name = "lblApplicationStatus"
        Me.lblApplicationStatus.Size = New System.Drawing.Size(68, 17)
        Me.lblApplicationStatus.TabIndex = 39
        Me.lblApplicationStatus.Text = "Approved"
        '
        'lblVerified
        '
        Me.lblVerified.AutoSize = True
        Me.lblVerified.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblVerified.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblVerified.Location = New System.Drawing.Point(106, 9)
        Me.lblVerified.Name = "lblVerified"
        Me.lblVerified.Size = New System.Drawing.Size(52, 17)
        Me.lblVerified.TabIndex = 38
        Me.lblVerified.Text = "Verified"
        '
        'lblCompany
        '
        Me.lblCompany.AutoSize = True
        Me.lblCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompany.Location = New System.Drawing.Point(105, 26)
        Me.lblCompany.Name = "lblCompany"
        Me.lblCompany.Size = New System.Drawing.Size(84, 20)
        Me.lblCompany.TabIndex = 37
        Me.lblCompany.Text = "PETRONAS"
        '
        'lblDescription
        '
        Me.lblDescription.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDescription.Location = New System.Drawing.Point(339, 11)
        Me.lblDescription.Name = "lblDescription"
        Me.lblDescription.Size = New System.Drawing.Size(149, 20)
        Me.lblDescription.TabIndex = 36
        Me.lblDescription.Text = "Full-Time"
        Me.lblDescription.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'picLogo
        '
        Me.picLogo.Image = CType(resources.GetObject("picLogo.Image"), System.Drawing.Image)
        Me.picLogo.Location = New System.Drawing.Point(17, 11)
        Me.picLogo.Name = "picLogo"
        Me.picLogo.Size = New System.Drawing.Size(82, 83)
        Me.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picLogo.TabIndex = 35
        Me.picLogo.TabStop = False
        '
        'lblSalary
        '
        Me.lblSalary.AutoSize = True
        Me.lblSalary.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalary.Location = New System.Drawing.Point(104, 66)
        Me.lblSalary.Name = "lblSalary"
        Me.lblSalary.Size = New System.Drawing.Size(165, 20)
        Me.lblSalary.TabIndex = 31
        Me.lblSalary.Text = "FROM RM3500 /month"
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblLocation.Location = New System.Drawing.Point(105, 86)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(166, 17)
        Me.lblLocation.TabIndex = 21
        Me.lblLocation.Text = "Petronas Digital - Petaling"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.Location = New System.Drawing.Point(104, 46)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(138, 20)
        Me.lblTitle.TabIndex = 20
        Me.lblTitle.Text = "Software Engineer "
        '
        'UserControl1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Name = "UserControl1"
        Me.Size = New System.Drawing.Size(515, 120)
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        CType(Me.picLogo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents picLogo As PictureBox
    Friend WithEvents lblSalary As Label
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblDescription As Label
    Friend WithEvents lblCompany As Label
    Friend WithEvents lblVerified As Label
    Friend WithEvents lblApplicationStatus As Label
    Friend WithEvents Label1 As Label
End Class
