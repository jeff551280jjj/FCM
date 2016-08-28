Imports System.Drawing


Public Class ColorClass
    Public Shared Function GetAverageColor(ByVal image As Bitmap)
        Dim R, G, B, T As Integer
        For x = 0 To image.Width - 1
            For y = 0 To image.Height - 1
                R += image.GetPixel(x, y).R
                G += image.GetPixel(x, y).G
                B += image.GetPixel(x, y).B
                T += 1

            Next
        Next
        Return Color.FromArgb(R / T, G / T, B / T)

    End Function

    Public Shared Function NegativeOF(ByVal colorD As Color) As Color
        Return Color.FromArgb(255 - colorD.R, 255 - colorD.G, 255 - colorD.B)
    End Function
End Class
