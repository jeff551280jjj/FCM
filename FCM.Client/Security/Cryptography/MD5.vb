Imports System.Security.Cryptography
Imports System.Text

Namespace Security.Cryptography
    Public Class MD5
        Public Shared Function GetHasFromString(ByVal SourceText As String) As String
            Dim Encoder As New UnicodeEncoding()
            Dim ByteSource() As Byte = Encoder.GetBytes(SourceText)
            Dim Md5Provider As New MD5CryptoServiceProvider()
            Dim ByteHash() As Byte = Md5Provider.ComputeHash(ByteSource)
            Return Convert.ToBase64String(ByteHash)
        End Function
    End Class
End Namespace