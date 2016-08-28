Imports FCM.Client.FileIO
Public Class LoginForm
    Public __PSW As String = ""
    Public __OLDLENGTH As Integer = 1


    Private Sub LoginForm_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        Dim CloseResult As MsgBoxResult = MsgBox("Are you sure you would like to exit?", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Fire Company Management")
        If CloseResult = MsgBoxResult.No Then
            e.Cancel = True
        ElseIf CloseResult = MsgBoxResult.Yes Then
            Application.ExitThread() ' Use ExitThread to avoid the CloseResult message to be displayed again.
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub MetroTextBox2_ButtonClick(sender As Object, e As EventArgs) Handles MetroTextBox2.ButtonClick
        ' This is where the application will check the input,
        ' determine if the username/password is correct,
        ' and have the MainForm load the user data.

        'For recovery purposes a whiterabbit.obj will be inserted as the form of bypass hexs that will temporarily turn
        'off image hash verification

        If __IO_UserExists(MetroTextBox1.Text) Then
        Else
            Dim CloseResult As MsgBoxResult = MsgBox("Account non-existant, create account?", MsgBoxStyle.Question & MsgBoxStyle.YesNo, "Fire Company Management")
            If CloseResult = MsgBoxResult.No Then

            ElseIf CloseResult = MsgBoxResult.Yes Then
                AddUser.Show()
                AddUser.UNBox.Text = MetroTextBox1.Text
                AddUser.MetroTextBox1.Text = MetroTextBox2.Text


            Else

            End If


        End If


    End Sub

    Private Sub LoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class
