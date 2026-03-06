<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form10
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form10))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnView = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnHome = New System.Windows.Forms.Button()
        Me.btnFeedback = New System.Windows.Forms.Button()
        Me.btnPosting = New System.Windows.Forms.Button()
        Me.btnProfile = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.btnUpload = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.btnJobPosting = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.fbdPoster = New System.Windows.Forms.FolderBrowserDialog()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnView)
        Me.Panel1.Controls.Add(Me.btnHome)
        Me.Panel1.Controls.Add(Me.btnFeedback)
        Me.Panel1.Controls.Add(Me.btnPosting)
        Me.Panel1.Controls.Add(Me.btnProfile)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1348, 84)
        Me.Panel1.TabIndex = 51
        '
        'btnView
        '
        Me.btnView.FlatAppearance.BorderSize = 0
        Me.btnView.ForeColor = System.Drawing.Color.Black
        Me.btnView.Image = CType(resources.GetObject("btnView.Image"), System.Drawing.Image)
        Me.btnView.Location = New System.Drawing.Point(261, 31)
        Me.btnView.Name = "btnView"
        Me.btnView.Size = New System.Drawing.Size(179, 29)
        Me.btnView.TabIndex = 10
        Me.btnView.Text = "View Applicants"
        Me.btnView.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnView.UseVisualStyleBackColor = True
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
        'btnFeedback
        '
        Me.btnFeedback.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnFeedback.FlatAppearance.BorderSize = 0
        Me.btnFeedback.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnFeedback.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnFeedback.ForeColor = System.Drawing.Color.White
        Me.btnFeedback.Location = New System.Drawing.Point(709, 0)
        Me.btnFeedback.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.btnFeedback.Name = "btnFeedback"
        Me.btnFeedback.Size = New System.Drawing.Size(213, 84)
        Me.btnFeedback.TabIndex = 6
        Me.btnFeedback.Text = "Feedback"
        Me.btnFeedback.UseVisualStyleBackColor = True
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
        'btnUpload
        '
        Me.btnUpload.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUpload.Image = CType(resources.GetObject("btnUpload.Image"), System.Drawing.Image)
        Me.btnUpload.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnUpload.Location = New System.Drawing.Point(89, 418)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(494, 264)
        Me.btnUpload.TabIndex = 53
        Me.btnUpload.Text = "Upload Poster "
        Me.btnUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'btnJobPosting
        '
        Me.btnJobPosting.Font = New System.Drawing.Font("Segoe UI Semibold", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnJobPosting.Image = CType(resources.GetObject("btnJobPosting.Image"), System.Drawing.Image)
        Me.btnJobPosting.Location = New System.Drawing.Point(89, 131)
        Me.btnJobPosting.Name = "btnJobPosting"
        Me.btnJobPosting.Size = New System.Drawing.Size(494, 264)
        Me.btnJobPosting.TabIndex = 52
        Me.btnJobPosting.Text = "Job Posting"
        Me.btnJobPosting.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnJobPosting.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText
        Me.btnJobPosting.UseVisualStyleBackColor = True
        '
        'Form10
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.btnUpload)
        Me.Controls.Add(Me.btnJobPosting)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form10"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents btnView As RoundedButton
    Friend WithEvents btnHome As Button
    Friend WithEvents btnFeedback As Button
    Friend WithEvents btnPosting As Button
    Friend WithEvents btnProfile As Button
    Friend WithEvents Label6 As Label
    Friend WithEvents btnUpload As RoundedButton
    Friend WithEvents btnJobPosting As RoundedButton
    Friend WithEvents fbdPoster As FolderBrowserDialog
End Class
