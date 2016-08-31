Imports System.Reflection

Namespace Specialized
    Partial Public Class ValueCollection(Of TKey, TValue1, TValue2)
        <Serializable>
        Public Structure Enumerator
            Implements IEnumerator(Of DualObjectContainer(Of TValue1, TValue2))
            Private _enumerator As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator

            Friend Sub New(trictionary As Trictionary(Of TKey, TValue1, TValue2))
                _enumerator = DirectCast(Activator.CreateInstance(GetType(Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator), BindingFlags.NonPublic Or BindingFlags.Instance, Nothing, New Object() {trictionary}, Nothing), Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2)).Enumerator)
            End Sub

            Private ReadOnly Property IEnumerator_Current() As Object Implements IEnumerator.Current
                Get
                    Return _enumerator.Current
                End Get
            End Property

            Private ReadOnly Property IEnumerator_Current2() As DualObjectContainer(Of TValue1, TValue2) Implements IEnumerator(Of DualObjectContainer(Of TValue1, TValue2)).Current
                Get
                    Return _enumerator.Current.Value
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

'=======================================================
'Service provided by Telerik (www.telerik.com)
'Conversion powered by NRefactory.
'Twitter: @telerik
'Facebook: facebook.com/telerik
'=======================================================
