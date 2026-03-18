Imports Atalasoft.Imaging
Imports System.IO

Module Module1

    Sub Main()
        '' NOTE: to add support for PDF as an input file formatyou need:
        '' - activate a license (paid or eval) for our PdfReader Addon if you don't already have one
        '' - reference Atalasoft.dotIamge.PdfReader.dll
        '' - uncomment the following line of code
        'RegisteredDecoders.Decoders.Add(New PdfDecoder() With {.Resolution = 200})

        Console.WriteLine("SimpleAtalaConsole Starting...")
        Dim imgPath As String = GetWorkingDir()
        If (Not Directory.Exists(Path.Combine(imgPath, "_CUSTFILES"))) Then
            Directory.CreateDirectory(Path.Combine(imgPath, "_CUSTFILES"))
            File.Copy("images\Tiger.jpg", Path.Combine(imgPath, "_CUSTFILES", "Tiger.jpg"))
        End If

        Dim inFile As String = imgPath & "_CUSTFILES\Tiger.jpg"
        Console.WriteLine("  inFile: " & inFile)

        Dim outFile As String = imgPath & "out.png"
        Console.WriteLine("  outFile: " & outFile)

        Console.WriteLine("BEGIN Processing")

        Dim img As AtalaImage = New AtalaImage(inFile, 0, Nothing)

        Console.WriteLine("Hi, I am an AtalaImage: " & img.ToString())
        Console.WriteLine("  PixelFormat: " & img.PixelFormat.ToString())
        Console.WriteLine("  Size: " & img.Size.ToString())

        'Console.WriteLine("saving...")
        'img.Save(outFile, New PngEncoder(), Nothing)

        Console.WriteLine("END Processing")
        Console.WriteLine("SimpleAtalaConsole finished... press RETURN to exit")
        Console.ReadLine()
    End Sub

    Private Function GetWorkingDir() As String
        Dim cwd As String = System.IO.Directory.GetCurrentDirectory()

        If cwd.EndsWith("\bin\Debug") Then
            cwd = cwd.Replace("\bin\Debug", "\..\..\")
        End If

        Return cwd
    End Function

End Module


