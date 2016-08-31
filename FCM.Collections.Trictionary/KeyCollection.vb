Imports System.Collections
Imports System.Collections.Generic

Namespace Specialized
    <Serializable>
    Partial Public NotInheritable Class KeyCollection(Of TKey, TValue1, TValue2)
        Implements ICollection(Of TKey)
        Implements ICollection
        Private ReadOnly _keyCollection As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).KeyCollection

        Public Sub New(trictionary As Trictionary(Of TKey, TValue1, TValue2))
            _keyCollection = New Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).KeyCollection(trictionary.InnerDictionary)
        End Sub

        Private Sub ICollection_Add(item As TKey) Implements ICollection(Of TKey).Add
            DirectCast(_keyCollection, ICollection(Of TKey)).Add(item)
        End Sub

        Private Sub ICollection_Clear() Implements ICollection(Of TKey).Clear
            DirectCast(_keyCollection, ICollection(Of TKey)).Clear()
        End Sub

        Private Function ICollection_Contains(item As TKey) As Boolean Implements ICollection(Of TKey).Contains
            Return DirectCast(_keyCollection, ICollection(Of TKey)).Contains(item)
        End Function

        Public Sub CopyTo(KeyArray As TKey(), KeyIndex As Integer) Implements ICollection(Of TKey).CopyTo
            _keyCollection.CopyTo(KeyArray, KeyIndex)
        End Sub

        Private Sub ICollection_CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
            DirectCast(_keyCollection, ICollection).CopyTo(array, index)
        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection.Count
            Get
                Return _keyCollection.Count
            End Get
        End Property

        Private Function IEnumerable_GetEnumerator2() As IEnumerator(Of TKey) Implements IEnumerable(Of TKey).GetEnumerator
            Return DirectCast(_keyCollection, IEnumerable(Of TKey)).GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_keyCollection, IEnumerable).GetEnumerator()
        End Function

        Private ReadOnly Property ICollection_IsReadOnly() As Boolean Implements ICollection(Of TKey).IsReadOnly
            Get
                Return DirectCast(_keyCollection, ICollection(Of TKey)).IsReadOnly
            End Get
        End Property

        Private ReadOnly Property ICollection_IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
                Return DirectCast(_keyCollection, ICollection).IsSynchronized
            End Get
        End Property

        Private Function ICollection_Remove(item As TKey) As Boolean Implements ICollection(Of TKey).Remove
            Return DirectCast(_keyCollection, ICollection(Of TKey)).Remove(item)
        End Function

        Private ReadOnly Property ICollection_SyncRoot() As Object Implements ICollection.SyncRoot
            Get
                Return DirectCast(_keyCollection, ICollection).SyncRoot
            End Get
        End Property

        Private ReadOnly Property ICollection_Count As Integer Implements ICollection(Of TKey).Count
            Get
                Return _keyCollection.Count
            End Get
        End Property
    End Class
End Namespace