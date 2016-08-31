Imports FCM.Management.Accounts.Local
Imports FCM.Security.Cryptography.SHA512
Public Class AddUser
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MetroTile1_Click(sender As Object, e As EventArgs) Handles MetroTile1.Click
        Me.Close()
    End Sub

    Private Sub MetroTile2_Click(sender As Object, e As EventArgs) Handles MetroTile2.Click
        CreateWorkspace(UNBox.Text, MetroTextBox1.Text)
        MkDir(My.Computer.FileSystem.CurrentDirectory & "\working")
        My.Computer.FileSystem.WriteAllText("sechash", GetHashFromString(MetroTextBox1.Text), False)


    End Sub
End Class