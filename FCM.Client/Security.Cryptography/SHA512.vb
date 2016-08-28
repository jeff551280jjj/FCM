Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace Security.Cryptography
    Public Class SHA512
        Public Shared Function GetHashFromString(ByVal SourceText As String) As String 'SHA-512 -- HASH
            Dim Encoder As New UnicodeEncoding()
            Dim ByteSource() As Byte = Encoder.GetBytes(SourceText)
            Dim Md5Provider As New SHA256CryptoServiceProvider
            Dim SystemMD5 As System.Security.Cryptography.MD5

            Dim ByteHash() As Byte = SystemMD5.ComputeHash(ByteSource)
            Return Convert.ToBase64String(ByteHash)
        End Function

        Public Shared Function GetGashFromFile(ByVal HashFile As String) As String
            Dim Hash = System.Security.Cryptography.SHA512.Create()

            ' We declare a variable to be an array of bytes
            Dim HashValue() As Byte

            ' We create a FileStream for the file passed as a parameter
            Dim Stream As FileStream = File.OpenRead(HashFile)
            ' We position the cursor at the beginning of stream
            Stream.Position = 0
            ' We calculate the hash of the file
            HashValue = Hash.ComputeHash(Stream)
            ' The array of bytes is converted into hexadecimal before it can be read easily
            Dim HashHex = CryptographyBase.PrintByteArray(HashValue)

            ' We close the open file
            Stream.Close()

            ' The hash is returned
            Return HashHex

        End Function
    End Class
End Namespace