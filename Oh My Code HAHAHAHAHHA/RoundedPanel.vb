Imports System.Drawing.Drawing2D

Public Class RoundedPanel
    Inherits Panel

    Public Property BorderRadius As Integer = 20

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim path As New GraphicsPath()
        path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90)
        path.AddArc(Me.Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90)
        path.AddArc(Me.Width - BorderRadius, Me.Height - BorderRadius, BorderRadius, BorderRadius, 0, 90)
        path.AddArc(0, Me.Height - BorderRadius, BorderRadius, BorderRadius, 90, 90)
        path.CloseAllFigures()

        Me.Region = New Region(path)

        ' Optional: draw border
        Using pen As New Pen(Color.LightGray, 1)
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias
            e.Graphics.DrawPath(pen, path)
        End Using
    End Sub
End Class

