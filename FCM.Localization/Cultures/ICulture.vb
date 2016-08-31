Imports System.ComponentModel
Public Interface ICulture
    ' Class Base --------------------------------------------
    ' Properties
    ReadOnly Property LongName As String
    ReadOnly Property CultureCode As Integer
    ReadOnly Property Events As EventHandlerList
    ReadOnly Property IsLoaded As Boolean

    ' Events
    Event CultureLoading As EventHandler
    Event CultureLoaded As EventHandler

    ' Functions
    Function GetResource(Type As ResourceType, ID As String)

    ' Subs
    Sub LoadResources()
    Sub RefreshResources()
    Sub AddResource()

    ' Audio Support -----------------------------------------
    ' Properites
    ReadOnly Property Audio As Dictionary(Of String, String)

    ' Events
    Event AudioLoading As EventHandler
    Event AudioLoaded As EventHandler

    ' Functions
    Function GetAudio(ID As String) As String

    'Subs
    Sub LoadAudio()
    Sub RefreshAudio()
    Sub AddAudio(ID As String, Value As String)

    ' Image Support -----------------------------------------
    ' Properites
    ReadOnly Property Images As Dictionary(Of String, String)

    ' Events
    Event ImageLoading As EventHandler
    Event ImageLoaded As EventHandler

    ' Functions
    Function GetImage(ID As String) As String

    'Subs
    Sub LoadImages()
    Sub RefreshImages()
    Sub AddImage(ID As String, Value As String)

    ' String Support -----------------------------------------
    ' Properites
    ReadOnly Property Strings As Dictionary(Of String, String)

    ' Events
    Event StringLoading As EventHandler
    Event StringLoaded As EventHandler

    ' Functions
    Function GetString(ID As String) As String

    'Subs
    Sub LoadStrings()
    Sub RefreshStrings()
    Sub AddString(ID As String, Value As String)

End Interface