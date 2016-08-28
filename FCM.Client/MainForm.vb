

Public Class MainForm
    Private Sub MainForm_Shown(sender As Object, e As EventArgs) Handles MyBase.Shown
        LoginForm.ShowDialog() ' shows the LoginForm when the MainForm is displayed.
        'AddUser.ShowDialog()



    End Sub

    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class