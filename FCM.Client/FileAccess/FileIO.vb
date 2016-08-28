Imports System.IO
Imports System.IO.Compression
Imports FCM.Client.Security
Public Class FileIO

    Public Shared Sub __UA_SaveWorkspace(ByVal user As String, ByVal password As String, overide As Boolean)
        If __S_SHA512(password) = My.Computer.FileSystem.ReadAllText("sechash") Then
            __IO_Compress(My.Computer.FileSystem.CurrentDirectory & "\working", "data.zip")
            __SE_EncryptF("data.zip", password, "Edata.zip")
            My.Computer.FileSystem.WriteAllText("tmp.hex", __S_SHA512(password), False)
            Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
            Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

            Dim byteforge(__TMP_ofstream.Length) As Byte

            __TMP_ofstream.Read(byteforge, 0, byteforge.Length)
            __TMP_ifstream.Write(byteforge, 511, byteforge.Length)
            __TMP_ofstream.Close()
            __TMP_ifstream.Close()
            My.Computer.FileSystem.WriteAllText("tmp.hex", __S_SHA512F("tmp.hex"), True)
            FileCopy("tmp.hex", __IO_GetUserIMG(user))
            Kill("data.zip")
            Kill("Edata.zip")
            Kill("tmp.hex")
            Console.Write("0x009")
        Else
            Console.Write("0xc03")
            If overide Then
                __IO_Compress(My.Computer.FileSystem.CurrentDirectory & "\working", "data.zip")
                __SE_EncryptF("data.zip", password, "Edata.zip")
                My.Computer.FileSystem.WriteAllText("tmp.hex", __S_SHA512(password), False)
                Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
                Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

                Dim byteforge(__TMP_ofstream.Length) As Byte

                __TMP_ofstream.Read(byteforge, 0, byteforge.Length)
                __TMP_ifstream.Write(byteforge, 511, byteforge.Length)
                __TMP_ofstream.Close()
                __TMP_ifstream.Close()
                My.Computer.FileSystem.WriteAllText("tmp.hex", __S_SHA512F("tmp.hex"), True)
                FileCopy("tmp.hex", __IO_GetUserIMG(user))
                Kill("data.zip")
                Kill("Edata.zip")
                Kill("tmp.hex")
                Console.Write("0x009")
            End If
        End If


    End Sub

    Public Shared Sub __UA_OpenUserDir(ByVal user As String, ByVal password As String)
        If __IO_UserExists(user) Then
            If __IO_VerifyIMG(__IO_GetUserIMG(user)) Then
                FileCopy(__IO_GetUserIMG(user), "tmp.hex")
                My.Computer.FileSystem.WriteAllText("sechash", __IO_ReadIMGSecHash("tmp.hex"), False)
                Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
                Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

                Dim byteforge(__TMP_ifstream.Length - 1024) As Byte
                __TMP_ifstream.Read(byteforge, 511, byteforge.Length)
                __TMP_ofstream.Write(byteforge, 0, byteforge.Length)
                __TMP_ofstream.Close()
                __TMP_ifstream.Close()

                __SE_DecryptF("Edata.zip", password, "data.zip")
                __IO_Decompress("data.zip", My.Computer.FileSystem.CurrentDirectory & "\working")
                Console.Write("0x0fe")
                Kill("data.zip")
                Kill("Edata.zip")
                Kill("tmp.hex")
            Else
                MsgBox("Your data has been comprimised!", MsgBoxStyle.Critical, "Fire Company Management")

            End If


        Else
            Console.Write("0x402")

        End If
    End Sub

    Public Shared Function __IO_GetUserIMG(ByVal user As String) As String
        Return My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & user & ".img"
    End Function

    Public Shared Function __IO_UserExists(ByVal Username As String) As Boolean
        If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & Username & ".UAP") Then
            Return True
        Else
            Return False
        End If
    End Function

    Public Shared Sub __UA_MakeAccount(ByVal username As String, ByVal password As String)
        ' This is a temp fix: create the directory before user creation to avoid DirectoryNotFound exceptions.
        Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\")
        My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & username & ".UAP", __S_SHA512(password), False)

    End Sub

    Public Shared Sub __IO_Compress(ByVal __TMP_Directory As String, ByVal __TMP_ZFile As String)
        ZipFile.CreateFromDirectory(__TMP_Directory, __TMP_ZFile)
    End Sub

    Public Shared Sub __IO_Decompress(ByVal __TMP_ZFile As String, ByVal __TMP_Directory As String)
        ZipFile.ExtractToDirectory(__TMP_ZFile, __TMP_Directory)
    End Sub

    Public Shared Function __IO_VerifyIMG(ByVal image As String) As Boolean
        My.Computer.FileSystem.WriteAllBytes("TMP", My.Computer.FileSystem.ReadAllBytes(image), False)
        Dim vartos As New FileStream("TMP", FileMode.Open)
        vartos.SetLength(vartos.Length - 512)
        vartos.Close()
        If __S_SHA512F("TMP") = __IO_ReadIMGEndHash(image) Then
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

    Public Shared Function __IO_ReadIMGSecHash(ByVal image As String) As String
        Dim __TMP_StreamReader As New FileStream(image, FileMode.OpenOrCreate)
        Dim __TMP_BYTEArray(512) As Byte
        Dim __TMP_SecString As String = ""
        __TMP_StreamReader.Read(__TMP_BYTEArray, 0, __TMP_BYTEArray.Length)
        __TMP_StreamReader.Close()
        __TMP_SecString = System.Text.Encoding.Default.GetString(__TMP_BYTEArray)
        Return __TMP_SecString

    End Function

    Public Shared Function __IO_ReadIMGEndHash(ByVal image As String) As String
        Dim __TMP_StreamReader As New FileStream(image, FileMode.OpenOrCreate)
        Dim __TMP_BYTEArray(512) As Byte
        Dim __TMP_SecString As String = ""
        __TMP_StreamReader.Read(__TMP_BYTEArray, __TMP_StreamReader.Length - (512), __TMP_BYTEArray.Length)
        __TMP_StreamReader.Close()
        __TMP_SecString = System.Text.Encoding.Default.GetString(__TMP_BYTEArray)
        Return __TMP_SecString

    End Function


End Class
