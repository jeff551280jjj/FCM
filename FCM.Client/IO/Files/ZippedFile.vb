Imports System.IO.Compression

Namespace IO.Files
    Public Class ZippedFile
        Public Shared Sub Compress(ByVal ExtractDirectory As String, ByVal ZippedFile As String)
            ZipFile.CreateFromDirectory(ExtractDirectory, ZippedFile)
        End Sub

        Public Shared Sub Decompress(ByVal ZippedFile As String, ByVal ExtractDirectory As String)
            ZipFile.ExtractToDirectory(ZippedFile, ExtractDirectory)
        End Sub
    End Class
End Namespace