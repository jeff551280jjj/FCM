Imports System.Collections
Imports System.Collections.Generic
Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace Specialized
    Partial Public Class KeyCollection(Of TKey, TValue1, TValue2)
        <Serializable>
        Public Structure Enumerator
            Implements IEnumerator(Of TKey)
            Private _enumerator As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator

            Friend Sub New(trictionary As Trictionary(Of TKey, TValue1, TValue2))
                _enumerator = DirectCast(Activator.CreateInstance(GetType(Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator), BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Object() {trictionary}, Nothing), Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator)
            End Sub

            Private ReadOnly Property IEnumerator_Current2() As TKey Implements IEnumerator(Of TKey).Current
                Get
                    Return _enumerator.Current.Key
                End Get
            End Property

            Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
                Get
                    Return _enumerator.Current
                End Get
            End Property

            Public Sub Dispose() Implements IDisposable.Dispose
                _enumerator.Dispose()
            End Sub

            Public Function MoveNext() As Boolean Implements IEnumerator.MoveNext
                Return _enumerator.MoveNext()
            End Function

            Private Sub IEnumerator_Reset() Implements IEnumerator.Reset
                DirectCast(_enumerator, IEnumerator).Reset()
            End Sub
        End Structure
    End Class
End Namespace