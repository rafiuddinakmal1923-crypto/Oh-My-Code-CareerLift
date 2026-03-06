<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CompanyInterview
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
        Me.lblSkills = New System.Windows.Forms.Label()
        Me.lblField = New System.Windows.Forms.Label()
        Me.lblCGPA = New System.Windows.Forms.Label()
        Me.lblInstitution = New System.Windows.Forms.Label()
        Me.lblName = New System.Windows.Forms.Label()
        Me.panelInterview.SuspendLayout()
        CType(Me.ProfileImage, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'panelInterview
        '
        Me.panelInterview.BorderRadius = 20
        Me.panelInterview.Controls.Add(Me.ProfileImage)
        Me.panelInterview.Controls.Add(Me.lblSkills)
        Me.panelInterview.Controls.Add(Me.lblField)
        Me.panelInterview.Controls.Add(Me.lblCGPA)
        Me.panelInterview.Controls.Add(Me.lblInstitution)
        Me.panelInterview.Controls.Add(Me.lblName)
        Me.panelInterview.Location = New System.Drawing.Point(3, 3)
        Me.panelInterview.Name = "panelInterview"
        Me.panelInterview.Size = New System.Drawing.Size(413, 134)
        Me.panelInterview.TabIndex = 42
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
        'lblSkills
        '
        Me.lblSkills.AutoSize = True
        Me.lblSkills.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSkills.Location = New System.Drawing.Point(128, 107)
        Me.lblSkills.Name = "lblSkills"
        Me.lblSkills.Size = New System.Drawing.Size(35, 20)
        Me.lblSkills.TabIndex = 33
        Me.lblSkills.Text = "</>"
        '
        'lblField
        '
        Me.lblField.AutoSize = True
        Me.lblField.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblField.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblField.Location = New System.Drawing.Point(129, 77)
        Me.lblField.Name = "lblField"
        Me.lblField.Size = New System.Drawing.Size(31, 17)
        Me.lblField.TabIndex = 32
        Me.lblField.Text = "</>"
        '
        'lblCGPA
        '
        Me.lblCGPA.AutoSize = True
        Me.lblCGPA.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCGPA.Location = New System.Drawing.Point(128, 57)
        Me.lblCGPA.Name = "lblCGPA"
        Me.lblCGPA.Size = New System.Drawing.Size(35, 20)
        Me.lblCGPA.TabIndex = 31
        Me.lblCGPA.Text = "</>"
        '
        'lblInstitution
        '
        Me.lblInstitution.AutoSize = True
        Me.lblInstitution.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblInstitution.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.lblInstitution.Location = New System.Drawing.Point(129, 35)
        Me.lblInstitution.Name = "lblInstitution"
        Me.lblInstitution.Size = New System.Drawing.Size(31, 17)
        Me.lblInstitution.TabIndex = 21
        Me.lblInstitution.Text = "</>"
        '
        'lblName
        '
        Me.lblName.AutoSize = True
        Me.lblName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblName.Location = New System.Drawing.Point(128, 11)
        Me.lblName.Name = "lblName"
        Me.lblName.Size = New System.Drawing.Size(35, 20)
        Me.lblName.TabIndex = 20
        Me.lblName.Text = "</>"
        '
        'CompanyInterview
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.panelInterview)
        Me.Name = "CompanyInterview"
        Me.Padding = New System.Windows.Forms.Padding(5)
        Me.Size = New System.Drawing.Size(433, 145)
        Me.panelInterview.ResumeLayout(False)
        Me.panelInterview.PerformLayout()
        CType(Me.ProfileImage, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents panelInterview As RoundedPanel
    Friend WithEvents ProfileImage As PictureBox
    Friend WithEvents lblSkills As Label
    Friend WithEvents lblField As Label
    Friend WithEvents lblCGPA As Label
    Friend WithEvents lblInstitution As Label
    Friend WithEvents lblName As Label

End Class
