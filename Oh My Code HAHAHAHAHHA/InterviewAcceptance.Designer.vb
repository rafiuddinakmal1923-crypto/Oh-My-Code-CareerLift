<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InterviewAcceptance
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
        Me.panelInterview = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.ProfileImage = New System.Windows.Forms.PictureBox()
        Me.lblLocation = New System.Windows.Forms.Label()
        Me.lblSalary = New System.Windows.Forms.Label()
        Me.lblEmploymentType = New System.Windows.Forms.Label()
        Me.lblJobTitle = New System.Windows.Forms.Label()
        Me.lblCompanyName = New System.Windows.Forms.Label()
        Me.panelInterview.SuspendLayout()
        CType(Me.ProfileImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelInterview
        '
        Me.panelInterview.BorderRadius = 20
        Me.panelInterview.Controls.Add(Me.ProfileImage)
        Me.panelInterview.Controls.Add(Me.lblLocation)
        Me.panelInterview.Controls.Add(Me.lblSalary)
        Me.panelInterview.Controls.Add(Me.lblEmploymentType)
        Me.panelInterview.Controls.Add(Me.lblJobTitle)
        Me.panelInterview.Controls.Add(Me.lblCompanyName)
        Me.panelInterview.Location = New System.Drawing.Point(10, 5)
        Me.panelInterview.Name = "panelInterview"
        Me.panelInterview.Size = New System.Drawing.Size(413, 134)
        Me.panelInterview.TabIndex = 43
        '
        'ProfileImage
        '
        Me.ProfileImage.Location = New System.Drawing.Point(17, 11)
        Me.ProfileImage.Name = "ProfileImage"
        Me.ProfileImage.Size = New System.Drawing.Size(107, 114)
        Me.ProfileImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.ProfileImage.TabIndex = 35
        Me.ProfileImage.TabStop = False
        '
        'lblLocation
        '
        Me.lblLocation.AutoSize = True
        Me.lblLocation.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLocation.Location = New System.Drawing.Point(128, 107)
        Me.lblLocation.Name = "lblLocation"
        Me.lblLocation.Size = New System.Drawing.Size(35, 20)
        Me.lblLocation.TabIndex = 33
        Me.lblLocation.Text = "</>"
        '
        'lblSalary
        '
        Me.lblSalary.AutoSize = True
        Me.lblSalary.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSalary.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblSalary.Location = New System.Drawing.Point(129, 77)
        Me.lblSalary.Name = "lblSalary"
        Me.lblSalary.Size = New System.Drawing.Size(31, 17)
        Me.lblSalary.TabIndex = 32
        Me.lblSalary.Text = "</>"
        '
        'lblEmploymentType
        '
        Me.lblEmploymentType.AutoSize = True
        Me.lblEmploymentType.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEmploymentType.Location = New System.Drawing.Point(128, 57)
        Me.lblEmploymentType.Name = "lblEmploymentType"
        Me.lblEmploymentType.Size = New System.Drawing.Size(35, 20)
        Me.lblEmploymentType.TabIndex = 31
        Me.lblEmploymentType.Text = "</>"
        '
        'lblJobTitle
        '
        Me.lblJobTitle.AutoSize = True
        Me.lblJobTitle.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblJobTitle.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblJobTitle.Location = New System.Drawing.Point(129, 35)
        Me.lblJobTitle.Name = "lblJobTitle"
        Me.lblJobTitle.Size = New System.Drawing.Size(31, 17)
        Me.lblJobTitle.TabIndex = 21
        Me.lblJobTitle.Text = "</>"
        '
        'lblCompanyName
        '
        Me.lblCompanyName.AutoSize = True
        Me.lblCompanyName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCompanyName.Location = New System.Drawing.Point(128, 11)
        Me.lblCompanyName.Name = "lblCompanyName"
        Me.lblCompanyName.Size = New System.Drawing.Size(35, 20)
        Me.lblCompanyName.TabIndex = 20
        Me.lblCompanyName.Text = "</>"
        '
        'InterviewAcceptance
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.panelInterview)
        Me.Name = "InterviewAcceptance"
        Me.Size = New System.Drawing.Size(433, 145)
        Me.panelInterview.ResumeLayout(False)
        Me.panelInterview.PerformLayout()
        CType(Me.ProfileImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelInterview As RoundedPanel
    Friend WithEvents ProfileImage As PictureBox
    Friend WithEvents lblLocation As Label
    Friend WithEvents lblSalary As Label
    Friend WithEvents lblEmploymentType As Label
    Friend WithEvents lblJobTitle As Label
    Friend WithEvents lblCompanyName As Label
End Class
