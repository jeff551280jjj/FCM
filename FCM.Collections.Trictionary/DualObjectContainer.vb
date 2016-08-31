Namespace Specialized
    Public Class DualObjectContainer(Of TValue1, TValue2)
        Implements IEquatable(Of DualObjectContainer(Of TValue1, TValue2))
        Public Sub New(value1__1 As TValue1, value2__2 As TValue2)
            Value1 = value1__1
            Value2 = value2__2
        End Sub

        Public Property Value1() As TValue1
            Get
                Return m_Value1
            End Get
            Set
                m_Value1 = Value
            End Set
        End Property
        Private m_Value1 As TValue1
        Public Property Value2() As TValue2
            Get
                Return m_Value2
            End Get
            Set
                m_Value2 = Value
            End Set
        End Property
        Private m_Value2 As TValue2

        Public Overloads Function Equals(other As DualObjectContainer(Of TValue1, TValue2)) As Boolean Implements IEquatable(Of DualObjectContainer(Of TValue1, TValue2)).Equals
            Return (EqualityComparer(Of TValue1).[Default].Equals(Value1, other.Value1)) AndAlso (EqualityComparer(Of TValue2).[Default].Equals(Value2, other.Value2))
        End Function

        Public Overrides Function ToString() As String
            Return String.Format("[{0}, {1}]", Value1, Value2)
        End Function
    End Class
End Namespace