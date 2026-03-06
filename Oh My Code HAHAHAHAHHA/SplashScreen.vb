Imports AxWMPLib
Imports System.IO
Public Class SplashScreen

    Private Sub FormSplash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        AxWindowsMediaPlayer1.URL = "..\bin\Debug\0617-copy.mp4"
        AxWindowsMediaPlayer1.uiMode = "none" 'Hide Controls
        AxWindowsMediaPlayer1.settings.autoStart = True
        Me.StartPosition = FormStartPosition.Manual

        ' Calculate screen center
        Dim screenWidth As Integer = Screen.PrimaryScreen.WorkingArea.Width
        Dim screenHeight As Integer = Screen.PrimaryScreen.WorkingArea.Height

        Dim formWidth As Integer = Me.Width
        Dim formHeight As Integer = Me.Height

        Dim x As Integer = (screenWidth - formWidth) \ 2
        Dim y As Integer = (screenHeight - formHeight) \ 2

        ' Apply location
        Me.Location = New Point(x, y)
    End Sub

    Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As _WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
        If e.newState = 8 Then ' 8 = Media Ended (code for Media Ended)/ cant be changed
            Me.Hide()
            Form4.Show()
        End If
    End Sub

    Private Sub AxWindowsMediaPlayer1_Enter(sender As Object, e As EventArgs) Handles AxWindowsMediaPlayer1.Enter

    End Sub
End Class