Imports System.Reflection

Namespace Specialized
    <Serializable>
    Friend Structure Enumerator(Of TKey, TValue1, TValue2)
        Implements IEnumerator(Of KeyDualValuePair(Of TKey, TValue1, TValue2))
        Implements IDictionaryEnumerator
        Private _enumerator As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator

        Friend Sub New(trictionary As Trictionary(Of TKey, TValue1, TValue2), getEnumeratorRetType As Integer)
            Dim args As Object() = {trictionary.InnerDictionary, getEnumeratorRetType}
            _enumerator = DirectCast(Activator.CreateInstance(GetType(Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator), BindingFlags.NonPublic Or BindingFlags.Instance, args, Nothing), Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator)
        End Sub

        Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
            Get
                Return DirectCast(_enumerator, IEnumerator).Current
            End Get
        End Property

        Private ReadOnly Property IEnumerator_Current2() As KeyDualValuePair(Of TKey, TValue1, TValue2) Implements IEnumerator(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).Current
            Get
                Dim kvp As KeyValuePair(Of TKey, DualObjectContainer(Of TValue1, TValue2)) = _enumerator.Current
                Return New KeyDualValuePair(Of TKey, TValue1, TValue2)(kvp)
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            _enumerator.Dispose()
        End Sub

        Private ReadOnly Property IDictionaryEnumerator_Entry() As DictionaryEntry Implements IDictionaryEnumerator.Entry
            Get
                Return DirectCast(_enumerator, IDictionaryEnumerator).Entry
            End Get
        End Property

        Private ReadOnly Property IDictionaryEnumerator_Key() As Object Implements IDictionaryEnumerator.Key
            Get
                Return DirectCast(_enumerator, IDictionaryEnumerator).Key
            End Get
        End Property

        Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
            Return _enumerator.MoveNext()
        End Function

        Private Sub IEnumerator_Reset() Implements IEnumerator.Reset
            DirectCast(_enumerator, IEnumerator).Reset()
        End Sub

        Private ReadOnly Property IDictionaryEnumerator_Value() As Object Implements IDictionaryEnumerator.Value
            Get
                Return DirectCast(_enumerator, IDictionaryEnumerator).Value
            End Get
        End Property
    End Structure
End Namespace