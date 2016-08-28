<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AddUser
    Inherits MetroFramework.Forms.MetroForm

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UNBox = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTextBox1 = New MetroFramework.Controls.MetroTextBox()
        Me.MetroTile1 = New MetroFramework.Controls.MetroTile()
        Me.MetroTile2 = New MetroFramework.Controls.MetroTile()
        Me.SuspendLayout()
        '
        'UNBox
        '
        '
        '
        '
        Me.UNBox.CustomButton.Image = Nothing
        Me.UNBox.CustomButton.Location = New System.Drawing.Point(263, 1)
        Me.UNBox.CustomButton.Name = ""
        Me.UNBox.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.UNBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.UNBox.CustomButton.TabIndex = 1
        Me.UNBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.UNBox.CustomButton.UseSelectable = True
        Me.UNBox.CustomButton.Visible = False
        Me.UNBox.Lines = New String(-1) {}
        Me.UNBox.Location = New System.Drawing.Point(23, 99)
        Me.UNBox.MaxLength = 32767
        Me.UNBox.Name = "UNBox"
        Me.UNBox.PasswordChar = Global.Microsoft.VisualBasic.ChrW(0)
        Me.UNBox.PromptText = "Username"
        Me.UNBox.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.UNBox.SelectedText = ""
        Me.UNBox.SelectionLength = 0
        Me.UNBox.SelectionStart = 0
        Me.UNBox.ShortcutsEnabled = True
        Me.UNBox.Size = New System.Drawing.Size(285, 23)
        Me.UNBox.Style = MetroFramework.MetroColorStyle.Green
        Me.UNBox.TabIndex = 0
        Me.UNBox.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.UNBox.UseSelectable = True
        Me.UNBox.WaterMark = "Username"
        Me.UNBox.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.UNBox.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroTextBox1
        '
        '
        '
        '
        Me.MetroTextBox1.CustomButton.Image = Nothing
        Me.MetroTextBox1.CustomButton.Location = New System.Drawing.Point(263, 1)
        Me.MetroTextBox1.CustomButton.Name = ""
        Me.MetroTextBox1.CustomButton.Size = New System.Drawing.Size(21, 21)
        Me.MetroTextBox1.CustomButton.Style = MetroFramework.MetroColorStyle.Blue
        Me.MetroTextBox1.CustomButton.TabIndex = 1
        Me.MetroTextBox1.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light
        Me.MetroTextBox1.CustomButton.UseSelectable = True
        Me.MetroTextBox1.CustomButton.Visible = False
        Me.MetroTextBox1.Lines = New String(-1) {}
        Me.MetroTextBox1.Location = New System.Drawing.Point(23, 128)
        Me.MetroTextBox1.MaxLength = 32767
        Me.MetroTextBox1.Name = "MetroTextBox1"
        Me.MetroTextBox1.PasswordChar = Global.Microsoft.VisualBasic.ChrW(9679)
        Me.MetroTextBox1.PromptText = "Password"
        Me.MetroTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.MetroTextBox1.SelectedText = ""
        Me.MetroTextBox1.SelectionLength = 0
        Me.MetroTextBox1.SelectionStart = 0
        Me.MetroTextBox1.ShortcutsEnabled = True
        Me.MetroTextBox1.Size = New System.Drawing.Size(285, 23)
        Me.MetroTextBox1.Style = MetroFramework.MetroColorStyle.Green
        Me.MetroTextBox1.TabIndex = 1
        Me.MetroTextBox1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTextBox1.UseSelectable = True
        Me.MetroTextBox1.UseStyleColors = True
        Me.MetroTextBox1.WaterMark = "Password"
        Me.MetroTextBox1.WaterMarkColor = System.Drawing.Color.FromArgb(CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer), CType(CType(109, Byte), Integer))
        Me.MetroTextBox1.WaterMarkFont = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel)
        '
        'MetroTile1
        '
        Me.MetroTile1.ActiveControl = Nothing
        Me.MetroTile1.Location = New System.Drawing.Point(23, 174)
        Me.MetroTile1.Name = "MetroTile1"
        Me.MetroTile1.Size = New System.Drawing.Size(75, 64)
        Me.MetroTile1.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroTile1.TabIndex = 3
        Me.MetroTile1.Text = "< Back"
        Me.MetroTile1.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTile1.UseSelectable = True
        '
        'MetroTile2
        '
        Me.MetroTile2.ActiveControl = Nothing
        Me.MetroTile2.Location = New System.Drawing.Point(233, 174)
        Me.MetroTile2.Name = "MetroTile2"
        Me.MetroTile2.Size = New System.Drawing.Size(75, 64)
        Me.MetroTile2.Style = MetroFramework.MetroColorStyle.Silver
        Me.MetroTile2.TabIndex = 4
        Me.MetroTile2.Text = "Add >"
        Me.MetroTile2.TextAlign = System.Drawing.ContentAlignment.BottomRight
        Me.MetroTile2.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.MetroTile2.UseSelectable = True
        '
        'AddUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 263)
        Me.Controls.Add(Me.MetroTile2)
        Me.Controls.Add(Me.MetroTile1)
        Me.Controls.Add(Me.MetroTextBox1)
        Me.Controls.Add(Me.UNBox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Movable = False
        Me.Name = "AddUser"
        Me.Resizable = False
        Me.ShowInTaskbar = False
        Me.Style = MetroFramework.MetroColorStyle.Silver
        Me.Text = "Add User"
        Me.Theme = MetroFramework.MetroThemeStyle.Dark
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UNBox As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTextBox1 As MetroFramework.Controls.MetroTextBox
    Friend WithEvents MetroTile1 As MetroFramework.Controls.MetroTile
    Friend WithEvents MetroTile2 As MetroFramework.Controls.MetroTile
End Class
