Imports System.IO
Imports FCM.Security.Cryptography

Namespace IO.Files
    Public Class ImgFile
        Public Shared Function Verify(ByVal Image As String) As Boolean
            My.Computer.FileSystem.WriteAllBytes("TMP", My.Computer.FileSystem.ReadAllBytes(Image), False)
            Dim vartos As New FileStream("TMP", FileMode.Open)
            vartos.SetLength(vartos.Length - 512)
            vartos.Close()
            If SHA512.GetHashFromFile("TMP") = GetEndHash(Image) Then
                Return True
                Dim vartos2 As New FileStream("TMP", FileMode.Open)
                vartos2.SetLength(0) 'Kill method moves file to system recycle bin
                vartos2.Close()
            Else
                Return False
                Dim vartos2 As New FileStream("TMP", FileMode.Open)
                vartos2.SetLength(0) 'Kill method moves file to system recycle bin
                vartos2.Close()
            End If

        End Function

        Public Shared Function GetHash(ByVal Image As String) As String
            Dim __TMP_StreamReader As New FileStream(Image, FileMode.OpenOrCreate)
            Dim __TMP_BYTEArray(512) As Byte
            Dim __TMP_SecString As String = ""
            __TMP_StreamReader.Read(__TMP_BYTEArray, 0, __TMP_BYTEArray.Length)
            __TMP_StreamReader.Close()
            __TMP_SecString = System.Text.Encoding.Default.GetString(__TMP_BYTEArray)
            Return __TMP_SecString

        End Function

        Public Shared Function GetEndHash(ByVal Image As String) As String
            Dim __TMP_StreamReader As New FileStream(Image, FileMode.OpenOrCreate)
            Dim __TMP_BYTEArray(512) As Byte
            Dim __TMP_SecString As String = ""
            __TMP_StreamReader.Read(__TMP_BYTEArray, __TMP_StreamReader.Length - (512), __TMP_BYTEArray.Length)
            __TMP_StreamReader.Close()
            __TMP_SecString = System.Text.Encoding.Default.GetString(__TMP_BYTEArray)
            Return __TMP_SecString
        End Function
    End Class
End Namespace