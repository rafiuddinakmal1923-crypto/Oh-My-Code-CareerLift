<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UserConsultationBookingvb
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
        Me.picConsultant = New Oh_My_Code_HAHAHAHAHHA.Class5()
        Me.lblConsultantName = New System.Windows.Forms.Label()
        Me.lblDate = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.linkConsultation = New System.Windows.Forms.LinkLabel()
        CType(Me.picConsultant, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'picConsultant
        '
        Me.picConsultant.Location = New System.Drawing.Point(24, 21)
        Me.picConsultant.Name = "picConsultant"
        Me.picConsultant.Size = New System.Drawing.Size(106, 101)
        Me.picConsultant.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.picConsultant.TabIndex = 26
        Me.picConsultant.TabStop = False
        '
        'lblConsultantName
        '
        Me.lblConsultantName.AutoSize = True
        Me.lblConsultantName.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblConsultantName.Location = New System.Drawing.Point(152, 21)
        Me.lblConsultantName.Name = "lblConsultantName"
        Me.lblConsultantName.Size = New System.Drawing.Size(51, 20)
        Me.lblConsultantName.TabIndex = 27
        Me.lblConsultantName.Text = "Label1"
        '
        'lblDate
        '
        Me.lblDate.AutoSize = True
        Me.lblDate.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDate.Location = New System.Drawing.Point(152, 41)
        Me.lblDate.Name = "lblDate"
        Me.lblDate.Size = New System.Drawing.Size(51, 20)
        Me.lblDate.TabIndex = 28
        Me.lblDate.Text = "Label1"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTime.Location = New System.Drawing.Point(152, 61)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(53, 20)
        Me.lblTime.TabIndex = 29
        Me.lblTime.Text = "Label2"
        '
        'linkConsultation
        '
        Me.linkConsultation.AutoSize = True
        Me.linkConsultation.Font = New System.Drawing.Font("Segoe UI Semibold", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.linkConsultation.Location = New System.Drawing.Point(153, 94)
        Me.linkConsultation.Name = "linkConsultation"
        Me.linkConsultation.Size = New System.Drawing.Size(68, 17)
        Me.linkConsultation.TabIndex = 30
        Me.linkConsultation.TabStop = True
        Me.linkConsultation.Text = "LinkLabel1"
        '
        'UserConsultationBookingvb
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.linkConsultation)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.lblDate)
        Me.Controls.Add(Me.lblConsultantName)
        Me.Controls.Add(Me.picConsultant)
        Me.Name = "UserConsultationBookingvb"
        Me.Size = New System.Drawing.Size(460, 150)
        CType(Me.picConsultant, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents picConsultant As Class5
    Friend WithEvents lblConsultantName As Label
    Friend WithEvents lblDate As Label
    Friend WithEvents lblTime As Label
    Friend WithEvents linkConsultation As LinkLabel
End Class
