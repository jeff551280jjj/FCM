Imports FCM.Localization.Resource

Public MustInherit Class Resource

    Public Sub AddAudio(ID As String)
        Audio.Add(ID, Nothing)
    End Sub

    Public Sub AddAudio(ID As String, Value As String)
        Audio.Add(ID, Value)
    End Sub

    Public Function GetAudio(ID As String) As String
        Return Me(ID)
    End Function

    Public Sub LoadAudio()
        If Count > 0 Then
        End If
        AddAudio("", "")
    End Sub

    Public Sub ClearResources()

    End Sub

    Public Sub InitializeResources()

    End Sub
End Class
