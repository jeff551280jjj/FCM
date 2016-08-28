Imports System.ComponentModel

Public Class SideMenuItem

    Private ImageValue As Image
    <Browsable(True)>
    Public Property Image() As Image
        Get
            Return ImageValue
        End Get
        Set(ByVal value As Image)
            ImageValue = value
            PictureBox1.Image = ImageValue
        End Set
    End Property

    Private TextValue As String
    <Browsable(True)>
    <DefaultValue("Menu Text")>
    Public Overrides Property Text() As String
        Get
            Return TextValue
        End Get
        Set(ByVal value As String)
            TextValue = value
            MetroLabel1.Text = TextValue
        End Set
    End Property

    Private Sub SideMenuItem_MouseEnter(sender As Object, e As EventArgs) Handles PictureBox1.MouseEnter, MyBase.MouseEnter, MetroLabel1.MouseEnter
        MetroLabel1.UseStyleColors = True
    End Sub

    Private Sub SideMenuItem_MouseLeave(sender As Object, e As EventArgs) Handles PictureBox1.MouseLeave, MyBase.MouseLeave, MetroLabel1.MouseLeave
        MetroLabel1.UseStyleColors = False
    End Sub

    Private Sub MetroLabel1_Click(sender As Object, e As EventArgs) Handles MetroLabel1.Click

    End Sub
End Class