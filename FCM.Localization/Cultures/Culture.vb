Public Class Culture
    Implements ICulture
#Region "Base Class"

#End Region
    Private CultureCodeValue As Integer
    Private LongNameValue As String
    Private EventsValue As System.ComponentModel.EventHandlerList
    Private AudioDictionary As Dictionary(Of String, String)
    Private ImageDictionary As Dictionary(Of String, String)
    Private StringDictionary As Dictionary(Of String, String)

    Public ReadOnly Property Audio As Dictionary(Of String, String) Implements ICulture.Audio
        Get
            Return AudioDictionary
        End Get
    End Property
    Public ReadOnly Property CultureCode As Integer Implements ICulture.CultureCode
        Get
            Return CultureCodeValue
        End Get
    End Property
    Public ReadOnly Property Events As System.ComponentModel.EventHandlerList Implements ICulture.Events
        Get
            Return EventsValue
        End Get
    End Property
    Public ReadOnly Property Images As Dictionary(Of String, String) Implements ICulture.Images
        Get
            Return ImageDictionary
        End Get
    End Property
    Public ReadOnly Property LongName As String Implements ICulture.LongName
        Get
            Return LongNameValue
        End Get
    End Property
    Public ReadOnly Property Strings As Dictionary(Of String, String) Implements ICulture.Strings
        Get
            Return StringDictionary
        End Get
    End Property
    Public Custom Event CultureChange As EventHandler Implements ICulture.CultureChange
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("CultureChange", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("CultureChange", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("CultureChange"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event CultureLoaded As EventHandler Implements ICulture.CultureLoaded
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("CultureLoaded", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("CultureLoaded", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("CultureLoaded"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event CultureLoading As EventHandler Implements ICulture.CultureLoading
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("CultureLoading", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("CultureLoading", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("CultureLoading"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event ImageLoaded As EventHandler Implements ICulture.ImageLoaded
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("ImageLoaded", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("ImageLoaded", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("ImageLoaded"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event ImageLoading As EventHandler Implements ICulture.ImageLoading
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("ImageLoading", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("ImageLoading", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("ImageLoading"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event StringLoaded As EventHandler Implements ICulture.StringLoaded
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("StringLoaded", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("StringLoaded", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("StringLoaded"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event
    Public Custom Event StringLoading As EventHandler Implements ICulture.StringLoading
        AddHandler(ByVal value As EventHandler)
            Me.Events.AddHandler("StringLoading", value)
        End AddHandler

        RemoveHandler(ByVal value As EventHandler)
            Me.Events.RemoveHandler("StringLoading", value)
        End RemoveHandler

        RaiseEvent(ByVal sender As Object, ByVal e As System.EventArgs)
            CType(Me.Events("StringLoading"), EventHandler).Invoke(sender, e)
        End RaiseEvent
    End Event

    Public Sub AddString(ID As String, Value As String) Implements ICulture.AddString
        StringDictionary.Add(ID, Value)
    End Sub
    Public Sub AddImage(ID As String, Value As String) Implements ICulture.AddImage
        ImageDictionary.Add(ID, Value)
    End Sub
    Public Function GetImage(ID As String) As String Implements ICulture.GetImage
        Return ImageDictionary(ID)
    End Function
    Public Function GetString(ID As String) As String Implements ICulture.GetString
        Return StringDictionary(ID)
    End Function

    Public Sub LoadAudio() Implements ICulture.LoadAudio
        Dim DictionaryIsEmpty As Boolean
        If StringDictionary.Count > 0 Then

        End If
        If Not DictionaryIsEmpty Then
            StringDictionary = New Dictionary(Of String, String)
        Else
            AddString("", "")
        End If
    End Sub

    Public Sub LoadImages() Implements ICulture.LoadImages
        Throw New NotImplementedException()
    End Sub

    Public Sub LoadStrings() Implements ICulture.LoadStrings
        Throw New NotImplementedException()
    End Sub

    Public Sub Load() Implements ICulture.Load
        Throw New NotImplementedException()
    End Sub
End Class

End Class
