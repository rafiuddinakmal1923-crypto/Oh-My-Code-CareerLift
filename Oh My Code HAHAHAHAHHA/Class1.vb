Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class RoundedTextBox
    Inherits UserControl

    Private WithEvents textBox As New TextBox()

    Public Sub New()
        Me.DoubleBuffered = True
        Me.Size = New Size(200, 30)

        textBox.BorderStyle = BorderStyle.None
        textBox.Location = New Point(10, 7)
        textBox.Width = Me.Width - 20
        textBox.Font = New Font("Segoe UI", 10)
        textBox.BackColor = Me.BackColor

        Me.Controls.Add(textBox)
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim radius As Integer = 15
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)
        Using pen As New Pen(Color.Gray, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub

    ' Optional: Forward Text property
    Public Overrides Property Text As String
        Get
            Return textBox.Text
        End Get
        Set(value As String)
            textBox.Text = value
        End Set
    End Property
End Class
