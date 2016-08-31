Imports System.Collections
Imports System.Collections.Generic

Namespace Specialized
    Public Interface ITrictionary
        Inherits ICollection
        Sub Add(key As Object, value1 As Object, value2 As Object)
        Sub Clear()
        Function Contains(key As Object) As Boolean
        Sub Remove(key As Object)

        ReadOnly Property IsFixedSize() As Boolean
        ReadOnly Property IsReadOnly() As Boolean
        Default Property Item(key As Object) As DualObjectContainer(Of Object, Object)
        ReadOnly Property Keys() As ICollection
        ReadOnly Property Values() As ICollection
    End Interface

    Public Interface ITrictionary(Of TKey, TValue1, TValue2)
        Inherits ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2))
        Sub Add(key As TKey, value1 As TValue1, value2 As TValue2)
        Function ContainsKey(key As TKey) As Boolean
        Function Remove(key As TKey) As Boolean
        Function TryGetValue(key As TKey, ByRef value1 As TValue1, ByRef value2 As TValue2) As Boolean

        Default Property Item(key As TKey) As DualObjectContainer(Of TValue1, TValue2)
        ReadOnly Property Keys() As ICollection(Of TKey)
        ReadOnly Property Values() As ICollection(Of DualObjectContainer(Of TValue1, TValue2))
    End Interface
End Namespace