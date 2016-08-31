Imports System.IO
Imports FCM.IO.Files
Imports FCM.Security.Cryptography

Namespace Management.Accounts
    Public Class Local
        Public Shared Sub SaveWorkspace(ByVal Username As String, ByVal Password As String, Override As Boolean)
            If SHA512.GetHashFromString(Password) = My.Computer.FileSystem.ReadAllText("sechash") Then
                ZippedFile.Compress(My.Computer.FileSystem.CurrentDirectory & "\working", "data.zip")
                AES.Encrypt("data.zip", Password, "Edata.zip")
                My.Computer.FileSystem.WriteAllText("tmp.hex", SHA512.GetHashFromString(Password), False)
                Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
                Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

                Dim byteforge(__TMP_ofstream.Length) As Byte

                __TMP_ofstream.Read(byteforge, 0, byteforge.Length)
                __TMP_ifstream.Write(byteforge, 511, byteforge.Length)
                __TMP_ofstream.Close()
                __TMP_ifstream.Close()
                My.Computer.FileSystem.WriteAllText("tmp.hex", SHA512.GetHashFromFile("tmp.hex"), True)
                FileCopy("tmp.hex", GetWorkspaceImg(Username))
                Kill("data.zip")
                Kill("Edata.zip")
                Kill("tmp.hex")
                Console.Write("0x009")
            Else
                Console.Write("0xc03")
                If Override Then
                    ZippedFile.Compress(My.Computer.FileSystem.CurrentDirectory & "\working", "data.zip")
                    AES.Encrypt("data.zip", Password, "Edata.zip")
                    My.Computer.FileSystem.WriteAllText("tmp.hex", SHA512.GetHashFromString(Password), False)
                    Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
                    Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

                    Dim byteforge(__TMP_ofstream.Length) As Byte

                    __TMP_ofstream.Read(byteforge, 0, byteforge.Length)
                    __TMP_ifstream.Write(byteforge, 511, byteforge.Length)
                    __TMP_ofstream.Close()
                    __TMP_ifstream.Close()
                    My.Computer.FileSystem.WriteAllText("tmp.hex", SHA512.GetHashFromFile("tmp.hex"), True)
                    FileCopy("tmp.hex", GetWorkspaceImg(Username))
                    Kill("data.zip")
                    Kill("Edata.zip")
                    Kill("tmp.hex")
                    Console.Write("0x009")
                End If
            End If


        End Sub

        Public Shared Sub LoadWorkspace(ByVal Username As String, ByVal Password As String)
            If WorkspaceExists(Username) Then
                If ImgFile.Verify(GetWorkspaceImg(Username)) Then
                    FileCopy(GetWorkspaceImg(Username), "tmp.hex")
                    My.Computer.FileSystem.WriteAllText("sechash", ImgFile.GetHash("tmp.hex"), False)
                    Dim __TMP_ifstream As New FileStream("tmp.hex", FileMode.Open, FileAccess.ReadWrite)
                    Dim __TMP_ofstream As New FileStream("Edata.zip", FileMode.Open, FileAccess.ReadWrite)

                    Dim byteforge(__TMP_ifstream.Length - 1024) As Byte
                    __TMP_ifstream.Read(byteforge, 511, byteforge.Length)
                    __TMP_ofstream.Write(byteforge, 0, byteforge.Length)
                    __TMP_ofstream.Close()
                    __TMP_ifstream.Close()

                    AES.Decrypt("Edata.zip", Password, "data.zip")
                    ZippedFile.Decompress("data.zip", My.Computer.FileSystem.CurrentDirectory & "\working")
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

        Public Shared Function GetWorkspaceImg(ByVal Username As String) As String
            Return My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & Username & ".img"
        End Function

        Public Shared Function WorkspaceExists(ByVal Username As String) As Boolean
            If My.Computer.FileSystem.FileExists(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & Username & ".UAP") Then
                Return True
            Else
                Return False
            End If
        End Function

        Public Shared Sub CreateWorkspace(ByVal Username As String, ByVal Password As String)
            ' This is a temp fix: create the directory before Username creation to avoid DirectoryNotFound exceptions.
            Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\")
            My.Computer.FileSystem.WriteAllText(My.Computer.FileSystem.SpecialDirectories.AllUsersApplicationData & "\FCM\Drives\" & Username & ".UAP", SHA512.GetHashFromString(Password), False)

        End Sub
    End Class
End Namespace