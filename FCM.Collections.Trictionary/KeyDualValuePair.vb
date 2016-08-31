Namespace Specialized
    <Serializable>
    Public Structure KeyDualValuePair(Of TKey, TValue1, TValue2)
        Public Sub New(key__1 As TKey, value1__2 As TValue1, value2__3 As TValue2)
            Me.New()
            Key = key__1
            Value1 = value1__2
            Value2 = value2__3
        End Sub

        Public Sub New(kvp As KeyValuePair(Of TKey, DualObjectContainer(Of TValue1, TValue2)))
            Me.New(kvp.Key, kvp.Value.Value1, kvp.Value.Value2)
        End Sub

        Public Property Key() As TKey
            Get
                Return m_Key
            End Get
            Set
                m_Key = Value
            End Set
        End Property
        Private m_Key As TKey
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

        Public Overrides Function ToString() As String
            Return String.Format("[{0}, {1}, {2}]", Key, Value1, Value2)
        End Function
    End Structure
End Namespace