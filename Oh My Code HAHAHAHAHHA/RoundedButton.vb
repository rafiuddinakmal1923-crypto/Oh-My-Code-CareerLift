Imports System.Drawing.Drawing2D
Public Class RoundedButton
    Inherits Button

    Protected Overrides Sub OnPaint(pevent As PaintEventArgs)
        Dim radius As Integer = 20
        Dim path As New GraphicsPath()
        path.AddArc(0, 0, radius, radius, 180, 90)
        path.AddArc(Me.Width - radius, 0, radius, radius, 270, 90)
        path.AddArc(Me.Width - radius, Me.Height - radius, radius, radius, 0, 90)
        path.AddArc(0, Me.Height - radius, radius, radius, 90, 90)
        path.CloseAllFigures()
        Me.Region = New Region(path)
        MyBase.OnPaint(pevent)
    End Sub

    Private Sub InitializeComponent()
        Me.SuspendLayout()
        Me.ResumeLayout(False)

    End Sub
End Class
