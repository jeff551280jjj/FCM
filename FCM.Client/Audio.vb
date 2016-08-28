Imports System.IO

Public Class Audio
    Public Shared __A_IsPlaying As Boolean 'This is so we can check to see if we have audio playing
    Public Shared __A_File As String 'We need to be able to access the players resources easily
    ' Public Shared __A_AudioStream As Stream 'This is so we apply modulation effects and break down the audio buffer
    'This is to be implemented


    Private Sub Audio_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        'This type of class cannot be ran outside of a form so we are going to invoke
        'this form as a child element and it will auto hide itself
        Me.Visible = False


    End Sub

    Public Shared Sub __A_Play() 'Simplifies the call
        Audio.AxWindowsMediaPlayer1.Ctlcontrols.play()

    End Sub
    Public Shared Sub __A_Pause() 'Simplifies the call
        Audio.AxWindowsMediaPlayer1.Ctlcontrols.pause()

    End Sub
    Public Shared Sub __A_Stop() 'Simplifies the call
        Audio.AxWindowsMediaPlayer1.Ctlcontrols.stop()

    End Sub

    Public Shared Sub __A_PlayAudio(ByVal stream As String) 'Supports URLs in the form of files or remote resources
        Audio.AxWindowsMediaPlayer1.URL = stream
        __A_Play()


    End Sub

    Sub _a_SetPlaying(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange 'Changes our public variables
        If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
            __A_IsPlaying = True
        Else
            __A_IsPlaying = False
        End If

    End Sub

    Sub _a_SetFile(sender As Object, e As AxWMPLib._WMPOCXEvents_CurrentItemChangeEvent) Handles AxWindowsMediaPlayer1.CurrentItemChange 'Changes variables
        __A_File = AxWindowsMediaPlayer1.URL

    End Sub



End Class