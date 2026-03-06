<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SignUpForm
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SignUpForm))
        Me.RoundedPanel2 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.txtConfirm = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.rdoJobSeeker = New System.Windows.Forms.RadioButton()
        Me.rdoCompany = New System.Windows.Forms.RadioButton()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.lnklblLogIn = New System.Windows.Forms.LinkLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnSignUp = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtEmail = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel1 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RoundedPanel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BorderRadius = 20
        Me.RoundedPanel2.Controls.Add(Me.txtConfirm)
        Me.RoundedPanel2.Controls.Add(Me.Label5)
        Me.RoundedPanel2.Controls.Add(Me.rdoJobSeeker)
        Me.RoundedPanel2.Controls.Add(Me.rdoCompany)
        Me.RoundedPanel2.Controls.Add(Me.txtPassword)
        Me.RoundedPanel2.Controls.Add(Me.lnklblLogIn)
        Me.RoundedPanel2.Controls.Add(Me.Label2)
        Me.RoundedPanel2.Controls.Add(Me.btnSignUp)
        Me.RoundedPanel2.Controls.Add(Me.Label4)
        Me.RoundedPanel2.Controls.Add(Me.Label3)
        Me.RoundedPanel2.Controls.Add(Me.txtEmail)
        Me.RoundedPanel2.Controls.Add(Me.Label1)
        Me.RoundedPanel2.Location = New System.Drawing.Point(878, 159)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(363, 513)
        Me.RoundedPanel2.TabIndex = 5
        '
        'txtConfirm
        '
        Me.txtConfirm.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtConfirm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtConfirm.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtConfirm.Location = New System.Drawing.Point(40, 313)
        Me.txtConfirm.Name = "txtConfirm"
        Me.txtConfirm.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtConfirm.Size = New System.Drawing.Size(272, 38)
        Me.txtConfirm.TabIndex = 26
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.Black
        Me.Label5.Location = New System.Drawing.Point(35, 282)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(168, 28)
        Me.Label5.TabIndex = 25
        Me.Label5.Text = "Confirm Password"
        '
        'rdoJobSeeker
        '
        Me.rdoJobSeeker.AutoSize = True
        Me.rdoJobSeeker.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoJobSeeker.Location = New System.Drawing.Point(179, 92)
        Me.rdoJobSeeker.Name = "rdoJobSeeker"
        Me.rdoJobSeeker.Size = New System.Drawing.Size(114, 27)
        Me.rdoJobSeeker.TabIndex = 24
        Me.rdoJobSeeker.TabStop = True
        Me.rdoJobSeeker.Text = "Job Seeker"
        Me.rdoJobSeeker.UseVisualStyleBackColor = True
        '
        'rdoCompany
        '
        Me.rdoCompany.AutoSize = True
        Me.rdoCompany.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rdoCompany.Location = New System.Drawing.Point(37, 92)
        Me.rdoCompany.Name = "rdoCompany"
        Me.rdoCompany.Size = New System.Drawing.Size(105, 27)
        Me.rdoCompany.TabIndex = 23
        Me.rdoCompany.TabStop = True
        Me.rdoCompany.Text = "Company"
        Me.rdoCompany.UseVisualStyleBackColor = True
        '
        'txtPassword
        '
        Me.txtPassword.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtPassword.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPassword.Location = New System.Drawing.Point(40, 237)
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.PasswordChar = Global.Microsoft.VisualBasic.ChrW(42)
        Me.txtPassword.Size = New System.Drawing.Size(272, 38)
        Me.txtPassword.TabIndex = 22
        '
        'lnklblLogIn
        '
        Me.lnklblLogIn.AutoSize = True
        Me.lnklblLogIn.BackColor = System.Drawing.Color.White
        Me.lnklblLogIn.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lnklblLogIn.Location = New System.Drawing.Point(34, 462)
        Me.lnklblLogIn.Name = "lnklblLogIn"
        Me.lnklblLogIn.Size = New System.Drawing.Size(70, 28)
        Me.lnklblLogIn.TabIndex = 21
        Me.lnklblLogIn.TabStop = True
        Me.lnklblLogIn.Text = "Log In"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.White
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(34, 431)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(249, 28)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Already have an account ?"
        '
        'btnSignUp
        '
        Me.btnSignUp.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnSignUp.FlatAppearance.BorderSize = 0
        Me.btnSignUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSignUp.Font = New System.Drawing.Font("Segoe UI Emoji", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSignUp.ForeColor = System.Drawing.Color.White
        Me.btnSignUp.Location = New System.Drawing.Point(36, 367)
        Me.btnSignUp.Name = "btnSignUp"
        Me.btnSignUp.Size = New System.Drawing.Size(276, 61)
        Me.btnSignUp.TabIndex = 19
        Me.btnSignUp.Text = "Sign Up"
        Me.btnSignUp.UseVisualStyleBackColor = False
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.Black
        Me.Label4.Location = New System.Drawing.Point(35, 206)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(93, 28)
        Me.Label4.TabIndex = 15
        Me.Label4.Text = "Password"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(33, 130)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(59, 28)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Email"
        '
        'txtEmail
        '
        Me.txtEmail.BackColor = System.Drawing.Color.WhiteSmoke
        Me.txtEmail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtEmail.Font = New System.Drawing.Font("Segoe UI", 13.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEmail.Location = New System.Drawing.Point(40, 161)
        Me.txtEmail.Name = "txtEmail"
        Me.txtEmail.Size = New System.Drawing.Size(272, 38)
        Me.txtEmail.TabIndex = 14
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.White
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 19.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.Label1.Location = New System.Drawing.Point(29, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(141, 45)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Sign Up"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.WhiteSmoke
        Me.RoundedPanel1.BorderRadius = 20
        Me.RoundedPanel1.Location = New System.Drawing.Point(890, 146)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(363, 512)
        Me.RoundedPanel1.TabIndex = 4
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Button3)
        Me.Panel1.Controls.Add(Me.Button1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1348, 84)
        Me.Panel1.TabIndex = 3
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(1127, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(158, 41)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "CareerLift"
        '
        'Button3
        '
        Me.Button3.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button3.FlatAppearance.BorderSize = 0
        Me.Button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button3.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button3.ForeColor = System.Drawing.Color.White
        Me.Button3.Location = New System.Drawing.Point(157, 0)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(157, 84)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "Contact "
        Me.Button3.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Dock = System.Windows.Forms.DockStyle.Left
        Me.Button1.FlatAppearance.BorderSize = 0
        Me.Button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Button1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Button1.ForeColor = System.Drawing.Color.White
        Me.Button1.Location = New System.Drawing.Point(0, 0)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(157, 84)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Home"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'SignUpForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(1348, 721)
        Me.Controls.Add(Me.RoundedPanel2)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Controls.Add(Me.Panel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "SignUpForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.RoundedPanel2.ResumeLayout(False)
        Me.RoundedPanel2.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents txtPassword As TextBox
    Friend WithEvents lnklblLogIn As LinkLabel
    Friend WithEvents Label2 As Label
    Friend WithEvents btnSignUp As RoundedButton
    Friend WithEvents Label4 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtEmail As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label6 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button1 As Button
    Friend WithEvents txtConfirm As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents rdoJobSeeker As RadioButton
    Friend WithEvents rdoCompany As RadioButton
End Class
