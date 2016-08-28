Imports System.IO
Imports System.Security.Cryptography
Imports System.Text

Namespace Security.Cryptography
    Public Class AES
        Public Shared Function Decrypt(Cipher As String, Password As String) As String
            Dim EncryptionKey As String = SHA512.GetHashFromString(Password)
            Dim CipherBytes As Byte() = Convert.FromBase64String(Cipher)
            Dim DecryptedText As String

            Using AesEncryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
                Dim PDB As New Rfc2898DeriveBytes(EncryptionKey, CryptographyBase.EncryptionSalt)
                AesEncryptor.Key = PDB.GetBytes(32)
                AesEncryptor.IV = PDB.GetBytes(16)
                Using MemStream As New MemoryStream()
                    Using CryptStream As New CryptoStream(MemStream, AesEncryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        CryptStream.Write(CipherBytes, 0, CipherBytes.Length)
                        CryptStream.Close()
                    End Using
                    DecryptedText = Encoding.Unicode.GetString(MemStream.ToArray())
                End Using
            End Using

            Return DecryptedText
        End Function

        Public Shared Sub Decrypt(EncryptedFile As String, Password As String, OutputFile As String)
            Dim EncryptionKey As String = SHA512.GetHashFromString(Password)
            Dim CipherBytes As Byte() = My.Computer.FileSystem.ReadAllBytes(EncryptedFile)
            Using AesEncryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
                Dim PDB As New Rfc2898DeriveBytes(EncryptionKey, CryptographyBase.EncryptionSalt)
                AesEncryptor.Key = PDB.GetBytes(32)
                AesEncryptor.IV = PDB.GetBytes(16)
                Using MemStream As New MemoryStream()
                    Using CryptStream As New CryptoStream(MemStream, AesEncryptor.CreateDecryptor(), CryptoStreamMode.Write)
                        CryptStream.Write(CipherBytes, 0, CipherBytes.Length)
                        CryptStream.Close()
                    End Using
                    My.Computer.FileSystem.WriteAllBytes(OutputFile, MemStream.ToArray(), False)
                End Using
            End Using
        End Sub

        Public Shared Sub Encrypt(File As String, Password As String, OutputFile As String) 'AES-STANDARD -- Encryption
            Dim EncryptionKey As String = SHA512.GetHashFromString(Password)
            Dim Bytes As Byte() = My.Computer.FileSystem.ReadAllBytes(File)
            Using AesEncryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
                Dim PDB As New Rfc2898DeriveBytes(EncryptionKey, CryptographyBase.EncryptionSalt)
                AesEncryptor.Key = PDB.GetBytes(32)
                AesEncryptor.IV = PDB.GetBytes(16)
                Using MemStream As New MemoryStream()
                    Using CryptStream As New CryptoStream(MemStream, AesEncryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        CryptStream.Write(Bytes, 0, Bytes.Length)
                        CryptStream.Close()
                    End Using
                    My.Computer.FileSystem.WriteAllBytes(OutputFile, MemStream.ToArray(), False)
                End Using
            End Using

        End Sub

        Public Shared Function Encrypt(Text As String, Password As String) As String 'AES-STANDARD -- Encryption
            Dim EncryptionKey As String = SHA512.GetHashFromString(Password)
            Dim Bytes As Byte() = Encoding.Unicode.GetBytes(Text)
            Dim EncryptedText As String
            Using AesEncryptor As System.Security.Cryptography.Aes = System.Security.Cryptography.Aes.Create()
                Dim PDB As New Rfc2898DeriveBytes(EncryptionKey, CryptographyBase.EncryptionSalt)
                AesEncryptor.Key = PDB.GetBytes(32)
                AesEncryptor.IV = PDB.GetBytes(16)
                Using MemStream As New MemoryStream()
                    Using CryptStream As New CryptoStream(MemStream, AesEncryptor.CreateEncryptor(), CryptoStreamMode.Write)
                        CryptStream.Write(Bytes, 0, Bytes.Length)
                        CryptStream.Close()
                    End Using

                    EncryptedText = Convert.ToBase64String(MemStream.ToArray())
                End Using
            End Using
            Return EncryptedText
        End Function
    End Class
End Namespace