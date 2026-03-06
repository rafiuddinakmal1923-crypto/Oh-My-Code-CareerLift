Imports System.Drawing.Drawing2D
Imports System.Windows.Forms

Public Class Class5
    Inherits PictureBox

    Protected Overrides Sub OnResize(e As EventArgs)
        MyBase.OnResize(e)
        SetCircleShape()
    End Sub

    Private Sub SetCircleShape()
        Dim path As New GraphicsPath()
        path.AddEllipse(0, 0, Me.Width, Me.Height)
        Me.Region = New Region(path)
    End Sub

    Protected Overrides Sub OnPaint(pe As PaintEventArgs)
        Me.SetCircleShape()
        MyBase.OnPaint(pe)
    End Sub
End Class


