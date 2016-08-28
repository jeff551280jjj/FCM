Namespace Security
    Public Class CryptographyBase
        Public Shared ReadOnly EncryptionSalt As Byte() = {&H49, &H76, &H61, &H6E, &H20, &H4D, &H65, &H64, &H76, &H65, &H64, &H65, &H76}

        Public Shared Function PrintByteArray(ByVal Array() As Byte) 'ADDON function for the MD5 function, has to be in the same namespace with the same access level
            Dim HexValue As String = ""

            ' We traverse the array of bytes
            Dim i As Integer
            For i = 0 To Array.Length - 1

                ' We convert each byte in hexadecimal
                HexValue += Array(i).ToString("X2")
            Next i

            ' We return the string in lowercase
            Return HexValue.ToLower

        End Function
    End Class
End Namespace