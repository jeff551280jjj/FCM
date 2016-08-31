Imports System.Runtime.Serialization
Imports System.Security.Permissions

' Copyright (c) Joe Enos 2009
' * http://www.jtenos.com/
' * You are free to use this code in your own projects, and modify it to suit your needs,
' * provided you keep this copyright intact.
' * 

Namespace Specialized
    ''' <summary>
    ''' Wrapper to a Dictionary&lt;TKey, TValue&gt;, except it stores two values.
    ''' </summary>
    ''' <typeparam name="TKey">Type of the key.</typeparam>
    ''' <typeparam name="TValue1">Type of the first value.</typeparam>
    ''' <typeparam name="TValue2">Type of the second value.</typeparam>
    Public Class Trictionary(Of TKey, TValue1, TValue2)
        Implements ITrictionary(Of TKey, TValue1, TValue2)
        Implements ITrictionary
        Implements ISerializable
        Implements IDeserializationCallback
        Private ReadOnly _dictionary As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2))

        Private _keys As KeyCollection(Of TKey, TValue1, TValue2)
        Private _values As ValueCollection(Of TKey, TValue1, TValue2)

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that is empty, has the default initial capacity, and uses the default equality comparer for the key type.
        ''' </summary>
        Public Sub New()
            Me.New(0, Nothing)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that contains elements copied from the specified ITrictionary and uses the default equality comparer for the key type.
        ''' </summary>
        ''' <param name="trictionary__1">The ITrictionary whose elements are copied to the new Trictionary.</param>
        ''' <exception cref="ArgumentException">trictionary contains one or more duplicate keys.</exception>
        ''' <exception cref="ArgumentNullException">trictionary is null.</exception>
        Public Sub New(trictionary__1 As ITrictionary(Of TKey, TValue1, TValue2))
            Me.New(trictionary__1, Nothing)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that is empty, has the default initial capacity, and uses the specified IEqualityComparer.
        ''' </summary>
        ''' <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or null to use the default EqualityComparer for the type of the key.</param>
        Public Sub New(comparer As IEqualityComparer(Of TKey))
            Me.New(0, comparer)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that is empty, has the specified initial capacity, and uses the default equality comparer for the key type.
        ''' </summary>
        ''' <param name="capacity">The initial number of elements that the Trictionary can contain.</param>
        ''' <exception cref="ArgumentOutOfRangeException">capacity is less than 0.</exception>
        Public Sub New(capacity As Integer)
            Me.New(capacity, Nothing)
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that contains elements copied from the specified ITrictionary and uses the specified IEqualityComparer.
        ''' </summary>
        ''' <param name="trictionary">The ITrictionary whose elements are copied to the new Trictionary.</param>
        ''' <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or null to use the default EqualityComparer for the type of the key.</param>
        ''' <exception cref="ArgumentException">trictionary contains one or more duplicate keys.</exception>
        ''' <exception cref="ArgumentNullException">trictionary is null.</exception>
        Public Sub New(trictionary__1 As ITrictionary(Of TKey, TValue1, TValue2), comparer As IEqualityComparer(Of TKey))
            Me.New(If((trictionary__1 IsNot Nothing), trictionary__1.Count, 0), comparer)
            If trictionary__1 Is Nothing Then
                Throw New ArgumentNullException("trictionary")
            End If
            For Each kdvp As KeyDualValuePair(Of TKey, TValue1, TValue2) In trictionary__1
                Add(kdvp.Key, kdvp.Value1, kdvp.Value2)
            Next
        End Sub

        ''' <summary>
        ''' Initializes a new instance of the Trictionary class that is empty, has the specified initial capacity, and uses the specified IEqualityComparer.
        ''' </summary>
        ''' <param name="capacity">The initial number of elements that the Trictionary can contain.</param>
        ''' <param name="comparer">The IEqualityComparer implementation to use when comparing keys, or null to use the default EqualityComparer for the type of the key.</param>
        ''' <exception cref="ArgumentOutOfRangeException">capacity is less than 0.</exception>
        Public Sub New(capacity As Integer, comparer As IEqualityComparer(Of TKey))
            _dictionary = New Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2))(capacity, comparer)
        End Sub

        ''' <summary>
        ''' Retrieves the inner dictionary.
        ''' </summary>
        Friend ReadOnly Property InnerDictionary() As Dictionary(Of TKey, DualObjectContainer(Of TValue1, TValue2))
            Get
                Return _dictionary
            End Get
        End Property

        ''' <summary>
        ''' Adds the specified key and values to the dictionary.
        ''' </summary>
        ''' <param name="key">The key of the element to add.</param>
        ''' <param name="value1">The first value of the element to add.  This can be null for reference types.</param>
        ''' <param name="value2">The second value of the element to add.  This can be null for reference types.</param>
        ''' <exception cref="ArgumentException">An element with the same key already exists in the Trictionary.</exception>
        ''' <exception cref="ArgumentNullException">key is null.</exception>
        Public Sub Add(key As TKey, value1 As TValue1, value2 As TValue2) Implements ITrictionary(Of TKey, TValue1, TValue2).Add
            _dictionary.Add(key, New DualObjectContainer(Of TValue1, TValue2)(value1, value2))
        End Sub

        Private Sub ICollection_Add(keyDualValuePair As KeyDualValuePair(Of TKey, TValue1, TValue2)) Implements ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).Add
            Add(keyDualValuePair.Key, keyDualValuePair.Value1, keyDualValuePair.Value2)
        End Sub

        Private Sub ITrictionary_Add(key As Object, value1 As Object, value2 As Object) Implements ITrictionary.Add
            VerifyKey(key)
            VerifyValueType1(value1)
            VerifyValueType2(value2)
            Add(DirectCast(key, TKey), DirectCast(value1, TValue1), DirectCast(value2, TValue2))
        End Sub

        ''' <summary>
        ''' Removes all keys and values from the Trictionary.
        ''' </summary>
        Public Sub Clear() Implements ITrictionary.Clear, ITrictionary(Of TKey, TValue1, TValue2).Clear
            _dictionary.Clear()
        End Sub

        ''' <summary>
        ''' Gets the IEqualityComparer that is used to determine equality of keys for the trictionary.
        ''' </summary>
        ''' <value>The IEqualityComparer generic interface implementation that is used to determine equality of keys for the current Trictionary and to provide hash values for the keys.</value>
        Public ReadOnly Property Comparer() As IEqualityComparer(Of TKey)
            Get
                Return _dictionary.Comparer
            End Get
        End Property

        Private Function ICollection_Contains(item As KeyDualValuePair(Of TKey, TValue1, TValue2)) As Boolean Implements ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).Contains
            If ContainsKey(item.Key) Then
                Dim container As DualObjectContainer(Of TValue1, TValue2) = Me(item.Key)
                Return ((EqualityComparer(Of TValue1).[Default].Equals(container.Value1, item.Value1)) AndAlso (EqualityComparer(Of TValue2).[Default].Equals(container.Value2, item.Value2)))
            End If
            Return False
        End Function

        Private Function ITrictionary_Contains(key As Object) As Boolean Implements ITrictionary.Contains
            Return (IsCompatibleKey(key) AndAlso ContainsKey(DirectCast(key, TKey)))
        End Function

        ''' <summary>
        ''' Determines whether the Trictionary contains the specified key.
        ''' </summary>
        ''' <param name="key">The key to locate in the Trictionary.</param>
        ''' <returns>true if the Trictionary contains an element with the specified key; otherwise, false.</returns>
        ''' <exception cref="ArgumentNullException">key is null.</exception>
        Public Function ContainsKey(key As TKey) As Boolean Implements ITrictionary(Of TKey, TValue1, TValue2).ContainsKey
            Return _dictionary.ContainsKey(key)
        End Function

        Private Sub CopyTo(array As KeyDualValuePair(Of TKey, TValue1, TValue2)(), index As Integer)
            If array Is Nothing Then
                Throw New ArgumentNullException("array")
            End If
            If (index < 0) OrElse (index > array.Length) Then
                Throw New ArgumentOutOfRangeException("index must be non-negative")
            End If
            If (array.Length - index) < Count Then
                Throw New ArgumentException("Array plus offset too small")
            End If

            For Each kdvp As KeyDualValuePair(Of TKey, TValue1, TValue2) In Me
                array(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)) = kdvp
            Next
        End Sub

        Private Sub ICollection_CopyTo(array As Array, index As Integer) Implements ICollection.CopyTo
            If array Is Nothing Then
                Throw New ArgumentNullException("array")
            End If
            If array.Rank <> 1 Then
                Throw New ArgumentException("Multi dim not supported")
            End If
            If array.GetLowerBound(0) <> 0 Then
                Throw New ArgumentException("NonZero lower bound")
            End If
            If (index < 0) OrElse (index > array.Length) Then
                Throw New ArgumentOutOfRangeException("index must be non-negative")
            End If
            If (array.Length - index) < Count Then
                Throw New ArgumentException("Array plus offset too small")
            End If
            Dim pairArray As KeyDualValuePair(Of TKey, TValue1, TValue2)() = TryCast(array, KeyDualValuePair(Of TKey, TValue1, TValue2)())
            If pairArray IsNot Nothing Then
                CopyTo(pairArray, index)
            ElseIf TypeOf array Is DictionaryEntry() Then
                Dim entryArray As DictionaryEntry() = TryCast(array, DictionaryEntry())
                For Each key As TKey In Keys
                    entryArray(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)) = New DictionaryEntry(key, Me(key))
                Next
            Else
                Dim objArray As Object() = TryCast(array, Object())
                If objArray Is Nothing Then
                    Throw New ArgumentException("Invalid array type")
                End If
                Try
                    For Each key As TKey In Keys
                        Dim container As DualObjectContainer(Of TValue1, TValue2) = Me(key)
                        objArray(System.Math.Max(System.Threading.Interlocked.Increment(index), index - 1)) = New KeyDualValuePair(Of TKey, TValue1, TValue2)(key, container.Value1, container.Value2)
                    Next
                Catch generatedExceptionName As ArrayTypeMismatchException
                    Throw New ArgumentException("Invalid array type")
                End Try
            End If
        End Sub

        Private Sub ICollection_CopyTo(array As KeyDualValuePair(Of TKey, TValue1, TValue2)(), arrayIndex As Integer) Implements ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).CopyTo
            CopyTo(array, arrayIndex)
        End Sub

        ''' <summary>
        ''' Gets the number of key/value pairs contained in the Trictionary.
        ''' </summary>
        ''' <value>The number of key/value pairs contained in the Trictionary.</value>
        Public ReadOnly Property Count() As Integer Implements ITrictionary.Count, ITrictionary(Of TKey, TValue1, TValue2).Count
            Get
                Return _dictionary.Count
            End Get
        End Property

        ''' <summary>
        ''' Retrieves the values for a given key.  Throws a KeyNotFoundException if the key does not exist in the dictionary.
        ''' </summary>
        ''' <param name="key">The key of the element to find.</param>
        ''' <param name="value1">Variable to store the first value in.</param>
        ''' <param name="value2">Variable to store the second value in.</param>
        Public Sub [Get](key As TKey, ByRef value1 As TValue1, ByRef value2 As TValue2)
            Dim container As DualObjectContainer(Of TValue1, TValue2) = _dictionary(key)
            value1 = container.Value1
            value2 = container.Value2
        End Sub

        ''' <summary>
        ''' Returns an enumerator that iterates through the Trictionary.
        ''' </summary>
        ''' <returns>A Enumerator structure for the Trictionary.</returns>
        Private Function IEnumerable_GetEnumerator() As IEnumerator Implements IEnumerable.GetEnumerator
            Return _dictionary.GetEnumerator()
        End Function

        Private Function IEnumerable_GetEnumerator2() As IEnumerator(Of KeyDualValuePair(Of TKey, TValue1, TValue2)) Implements IEnumerable(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).GetEnumerator
            Return DirectCast(_dictionary, IEnumerable(Of KeyDualValuePair(Of TKey, TValue1, TValue2))).GetEnumerator()
        End Function

        ''' <summary>
        ''' Implements the ISerializable interface and returns the data needed to serialize the Trictionary instance.
        ''' </summary>
        ''' <param name="info">A SerializationInfo object that contains the information required to serialize the Trictionary instance.</param>
        ''' <param name="context">A StreamingContext structure that contains the source and destination of the serialized stream associated with the Trictionary instance.</param>
        ''' <exception cref="ArgumentNullException">info is null.</exception>
        <SecurityPermission(SecurityAction.LinkDemand, Flags:=SecurityPermissionFlag.SerializationFormatter)>
        Public Overridable Sub GetObjectData(info As SerializationInfo, context As StreamingContext) Implements ISerializable.GetObjectData
            _dictionary.GetObjectData(info, context)
        End Sub

        Private Shared Function IsCompatibleKey(key As Object) As Boolean
            If key Is Nothing Then
                Throw New ArgumentNullException("key")
            End If
            Return (TypeOf key Is TKey)
        End Function

        Private ReadOnly Property ITrictionary_IsFixedSize() As Boolean Implements ITrictionary.IsFixedSize
            Get
                Return DirectCast(_dictionary, ITrictionary).IsFixedSize
            End Get
        End Property

        Private ReadOnly Property ITrictionary_IsReadOnly() As Boolean Implements ITrictionary.IsReadOnly
            Get
                Return DirectCast(_dictionary, ITrictionary).IsReadOnly
            End Get
        End Property

        Private ReadOnly Property ICollection_IsReadOnly() As Boolean Implements ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).IsReadOnly
            Get
                Return DirectCast(_dictionary, ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2))).IsReadOnly
            End Get
        End Property

        Private ReadOnly Property ICollection_IsSynchronized() As Boolean Implements ICollection.IsSynchronized
            Get
                Return DirectCast(_dictionary, ICollection).IsSynchronized
            End Get
        End Property

        Private ReadOnly Property ITrictionary_Keys2() As ICollection(Of TKey) Implements ITrictionary(Of TKey, TValue1, TValue2).Keys
            Get
                If _keys Is Nothing Then
                    _keys = New KeyCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _keys
            End Get
        End Property

        Private ReadOnly Property ITrictionary_Keys() As ICollection Implements ITrictionary.Keys
            Get
                If _keys Is Nothing Then
                    _keys = New KeyCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _keys
            End Get
        End Property

        ''' <summary>
        ''' Gets a collection containing the keys in the Trictionary.
        ''' </summary>
        ''' <value>A KeyCollection containing the keys in the Trictionary.</value>
        Public ReadOnly Property Keys() As KeyCollection(Of TKey, TValue1, TValue2)
            Get
                If _keys Is Nothing Then
                    _keys = New KeyCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _keys
            End Get
        End Property

        ''' <summary>
        ''' Implements the ISerializable interface and raises the deserialization event when the deserialization is complete.
        ''' </summary>
        ''' <param name="sender">The source of the deserialization event.</param>
        ''' <exception cref="SerializationException">The SerializationInfo object associated with the current Trictionary instance is invalid.</exception>
        Public Overridable Sub OnDeserialization(sender As Object) Implements IDeserializationCallback.OnDeserialization
            _dictionary.OnDeserialization(sender)
        End Sub

        ''' <summary>
        ''' Removes the value with the specified key from the trictionary.
        ''' </summary>
        ''' <param name="key">The key of the element to remove.</param>
        ''' <returns>true if the element is successfully found and removed; otherwise, false. This method returns false if key is not found in the Trictionary.</returns>
        ''' <exception cref="ArgumentNullException">key is null.</exception>
        Public Function Remove(key As TKey) As Boolean Implements ITrictionary(Of TKey, TValue1, TValue2).Remove
            Return _dictionary.Remove(key)
        End Function

        Private Sub ITrictionary_Remove(key As Object) Implements ITrictionary.Remove
            If IsCompatibleKey(key) Then
                Remove(DirectCast(key, TKey))
            End If
        End Sub

        Private Function ICollection_Remove(keyDualValuePair As KeyDualValuePair(Of TKey, TValue1, TValue2)) As Boolean Implements ICollection(Of KeyDualValuePair(Of TKey, TValue1, TValue2)).Remove
            If ContainsKey(keyDualValuePair.Key) Then
                Dim container As DualObjectContainer(Of TValue1, TValue2) = Me(keyDualValuePair.Key)
                If (EqualityComparer(Of TValue1).[Default].Equals(container.Value1)) AndAlso (EqualityComparer(Of TValue2).[Default].Equals(container.Value2)) Then
                    Remove(keyDualValuePair.Key)
                    Return True
                End If
            End If
            Return False
        End Function

        Private ReadOnly Property ICollection_SyncRoot() As Object Implements ICollection.SyncRoot
            Get
                Return DirectCast(_dictionary, ICollection).SyncRoot
            End Get
        End Property

        ''' <summary>
        ''' Gets the values associated with the specified key.  If this fails, it sets the output params to the default values for their types.
        ''' </summary>
        ''' <param name="key">The key to find.</param>
        ''' <param name="value1">First value of the found record.</param>
        ''' <param name="value2">Second value of the found record.</param>
        ''' <returns>true if successfully retrieved values, otherwise false.</returns>
        Public Function TryGetValue(key As TKey, ByRef value1 As TValue1, ByRef value2 As TValue2) As Boolean Implements ITrictionary(Of TKey, TValue1, TValue2).TryGetValue
            Dim container As DualObjectContainer(Of TValue1, TValue2)
            If _dictionary.TryGetValue(key, container) Then
                value1 = container.Value1
                value2 = container.Value2
                Return True
            End If
            value1 = Nothing
            value2 = Nothing
            Return False
        End Function

        Private ReadOnly Property ITrictionary_Values2() As ICollection(Of DualObjectContainer(Of TValue1, TValue2)) Implements ITrictionary(Of TKey, TValue1, TValue2).Values
            Get
                If _values Is Nothing Then
                    _values = New ValueCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _values
            End Get
        End Property

        Private Shared Sub VerifyKey(key As Object)
            If key Is Nothing Then
                Throw New ArgumentNullException("key")
            End If
            If Not (TypeOf key Is TKey) Then
                Throw New ArgumentException(String.Format("key must be of type {0}", GetType(TKey).Name))
            End If
        End Sub

        Private Shared Sub VerifyValueType1(value1 As Object)
            If Not (TypeOf value1 Is TValue1) AndAlso ((value1 IsNot Nothing) OrElse GetType(TValue1).IsValueType) Then
                Throw New ArgumentException(String.Format("value1 must be of type {0}", GetType(TValue1).Name))
            End If
        End Sub

        Private Shared Sub VerifyValueType2(value2 As Object)
            If Not (TypeOf value2 Is TValue2) AndAlso ((value2 IsNot Nothing) OrElse GetType(TValue2).IsValueType) Then
                Throw New ArgumentException(String.Format("value2 must be of type {0}", GetType(TValue2).Name))
            End If
        End Sub

        Private ReadOnly Property ITrictionary_Values() As ICollection Implements ITrictionary.Values
            Get
                If _values Is Nothing Then
                    _values = New ValueCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _values
            End Get
        End Property

        Public ReadOnly Property Values() As ValueCollection(Of TKey, TValue1, TValue2)
            Get
                If _values Is Nothing Then
                    _values = New ValueCollection(Of TKey, TValue1, TValue2)(Me)
                End If
                Return _values
            End Get
        End Property

        ''' <summary>
        ''' Gets or sets the value associated with the specified key.
        ''' </summary>
        ''' <param name="key">The key of the value to get or set.</param>
        ''' <returns>The value associated with the specified key. If the specified key is not found, a get operation throws a KeyNotFoundException, and a set operation creates a new element with the specified key.</returns>
        ''' <exception cref="ArgumentNullException">key is null.</exception>
        ''' <exception cref="KeyNotFoundException">The property is retrieved and key does not exist in the collection.</exception>
        Default Public Property Item(key As TKey) As DualObjectContainer(Of TValue1, TValue2) Implements ITrictionary(Of TKey, TValue1, TValue2).Item
            Get
                Return _dictionary(key)
            End Get
            Set
                _dictionary(key) = Value
            End Set
        End Property

        Public Property ITrictionary_Item(key As Object) As DualObjectContainer(Of Object, Object) Implements ITrictionary.Item
            Get
                If IsCompatibleKey(key) Then
                    Dim goodKey As TKey = DirectCast(key, TKey)
                    If _dictionary.ContainsKey(goodKey) Then
                        Dim container As DualObjectContainer(Of TValue1, TValue2) = _dictionary(goodKey)
                        Return New DualObjectContainer(Of Object, Object)(container.Value1, container.Value2)
                    End If
                End If
                Return Nothing
            End Get
            Set
                VerifyKey(key)
                VerifyValueType1(Value.Value1)
                VerifyValueType2(Value.Value2)
                Me(DirectCast(key, TKey)) = New DualObjectContainer(Of TValue1, TValue2)(DirectCast(Value.Value1, TValue1), DirectCast(Value.Value2, TValue2))
            End Set
        End Property
    End Class
End Namespace