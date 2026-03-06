<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form23
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form23))
        Me.RoundedPanel1 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.dtpAppointmentDate = New System.Windows.Forms.DateTimePicker()
        Me.btnBook = New Oh_My_Code_HAHAHAHAHHA.RoundedButton()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RoundedPanel2 = New Oh_My_Code_HAHAHAHAHHA.RoundedPanel()
        Me.cboTimePicker = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.RoundedPanel1.SuspendLayout()
        Me.RoundedPanel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'RoundedPanel1
        '
        Me.RoundedPanel1.BackColor = System.Drawing.Color.White
        Me.RoundedPanel1.BorderRadius = 70
        Me.RoundedPanel1.Controls.Add(Me.dtpAppointmentDate)
        Me.RoundedPanel1.Controls.Add(Me.btnBook)
        Me.RoundedPanel1.Controls.Add(Me.Label3)
        Me.RoundedPanel1.Controls.Add(Me.RoundedPanel2)
        Me.RoundedPanel1.Controls.Add(Me.Label2)
        Me.RoundedPanel1.Controls.Add(Me.Label1)
        Me.RoundedPanel1.Location = New System.Drawing.Point(37, 39)
        Me.RoundedPanel1.Name = "RoundedPanel1"
        Me.RoundedPanel1.Size = New System.Drawing.Size(356, 479)
        Me.RoundedPanel1.TabIndex = 23
        '
        'dtpAppointmentDate
        '
        Me.dtpAppointmentDate.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtpAppointmentDate.Location = New System.Drawing.Point(41, 181)
        Me.dtpAppointmentDate.Name = "dtpAppointmentDate"
        Me.dtpAppointmentDate.Size = New System.Drawing.Size(271, 25)
        Me.dtpAppointmentDate.TabIndex = 87
        '
        'btnBook
        '
        Me.btnBook.BackColor = System.Drawing.Color.FromArgb(CType(CType(63, Byte), Integer), CType(CType(81, Byte), Integer), CType(CType(181, Byte), Integer))
        Me.btnBook.FlatAppearance.BorderSize = 0
        Me.btnBook.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBook.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBook.ForeColor = System.Drawing.Color.White
        Me.btnBook.Location = New System.Drawing.Point(41, 363)
        Me.btnBook.Name = "btnBook"
        Me.btnBook.Size = New System.Drawing.Size(271, 50)
        Me.btnBook.TabIndex = 86
        Me.btnBook.Text = "Book Now"
        Me.btnBook.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BackColor = System.Drawing.Color.Transparent
        Me.Label3.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Gray
        Me.Label3.Location = New System.Drawing.Point(126, 238)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(109, 23)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Choose Time"
        '
        'RoundedPanel2
        '
        Me.RoundedPanel2.BorderRadius = 30
        Me.RoundedPanel2.Controls.Add(Me.cboTimePicker)
        Me.RoundedPanel2.Location = New System.Drawing.Point(41, 276)
        Me.RoundedPanel2.Name = "RoundedPanel2"
        Me.RoundedPanel2.Size = New System.Drawing.Size(271, 50)
        Me.RoundedPanel2.TabIndex = 24
        '
        'cboTimePicker
        '
        Me.cboTimePicker.BackColor = System.Drawing.Color.White
        Me.cboTimePicker.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.cboTimePicker.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboTimePicker.FormattingEnabled = True
        Me.cboTimePicker.Items.AddRange(New Object() {"9:00 AM", "10:00 AM", "11:00 AM", "2:00 PM", "4:00 PM"})
        Me.cboTimePicker.Location = New System.Drawing.Point(17, 10)
        Me.cboTimePicker.Name = "cboTimePicker"
        Me.cboTimePicker.Size = New System.Drawing.Size(238, 31)
        Me.cboTimePicker.TabIndex = 23
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.Transparent
        Me.Label2.Font = New System.Drawing.Font("Segoe UI Semibold", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.Gray
        Me.Label2.Location = New System.Drawing.Point(69, 140)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(214, 23)
        Me.Label2.TabIndex = 22
        Me.Label2.Text = "Choose Appointment Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 18.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(41, Byte), Integer), CType(CType(95, Byte), Integer), CType(CType(152, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(287, 41)
        Me.Label1.TabIndex = 21
        Me.Label1.Text = "Book Appointment"
        '
        'Form23
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(202, Byte), Integer), CType(CType(233, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(434, 559)
        Me.Controls.Add(Me.RoundedPanel1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form23"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "CareerLift"
        Me.RoundedPanel1.ResumeLayout(False)
        Me.RoundedPanel1.PerformLayout()
        Me.RoundedPanel2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents RoundedPanel1 As RoundedPanel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents RoundedPanel2 As RoundedPanel
    Friend WithEvents cboTimePicker As ComboBox
    Friend WithEvents btnBook As RoundedButton
    Friend WithEvents dtpAppointmentDate As DateTimePicker
End Class
