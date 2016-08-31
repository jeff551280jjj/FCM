Namespace Specialized
    <Serializable>
    Partial Public NotInheritable Class ValueCollection(Of TKey, TValue1, TValue2)
        Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2))
        Implements ICollection
        Private ReadOnly _valueCollection As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).ValueCollection

        Public Sub New(Trict As Trictionary(Of TKey, TValue1, TValue2))
            _valueCollection = New Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).ValueCollection(Trict.InnerDictionary)
        End Sub

        Private Sub ICollection_Add(item As DualObjectContainer(Of TValue1, TValue2)) Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).Add
            DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).Add(item)
        End Sub

        Private Sub ICollection_Clear() Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).Clear
            DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).Clear()
        End Sub

        Private Function ICollection_Contains(item As DualObjectContainer(Of TValue1, TValue2)) As Boolean Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).Contains
            Return DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).Contains(item)
        End Function

        Private Sub ICollection_CopyTo(array As DualObjectContainer(Of TValue1, TValue2)(), index As Integer) Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).CopyTo
            DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).CopyTo(array, index)
        End Sub

        Private Sub ICollection_CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
            DirectCast(_valueCollection, ICollection).CopyTo(array, index)
        End Sub

        Public ReadOnly Property Count() As Integer Implements ICollection.Count, ICollection(Of DualObjectContainer(Of TValue1, TValue2)).Count
            Get
                Return _valueCollection.Count
            End Get
        End Property

        Private Function IEnumerable_GetEnumerator2() As IEnumerator(Of DualObjectContainer(Of TValue1, TValue2)) Implements IEnumerable(Of DualObjectContainer(Of TValue1, TValue2)).GetEnumerator
            Return DirectCast(_valueCollection, IEnumerable(Of DualObjectContainer(Of TValue1, TValue2))).GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return DirectCast(_valueCollection, IEnumerable).GetEnumerator()
        End Function

        Private ReadOnly Property ICollection_IsReadOnly() As Boolean Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).IsReadOnly
            Get
                Return DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).IsReadOnly
            End Get
        End Property

        Private ReadOnly Property ICollection_IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
                Return DirectCast(_valueCollection, ICollection).IsSynchronized
            End Get
        End Property

        Private Function ICollection_Remove(item As DualObjectContainer(Of TValue1, TValue2)) As Boolean Implements ICollection(Of DualObjectContainer(Of TValue1, TValue2)).Remove
            Return DirectCast(_valueCollection, ICollection(Of DualObjectContainer(Of TValue1, TValue2))).Remove(item)
        End Function

        Private ReadOnly Property ICollection_SyncRoot() As Object Implements ICollection.SyncRoot
            Get
                Return DirectCast(_valueCollection, ICollection).SyncRoot
            End Get
        End Property
    End Class
End Namespace