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
        Dim imgPath As String = DemoSetup()


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

#Region "Utility Methods"
    Private Function GetWorkingDir() As String
        Dim cwd As String = System.IO.Directory.GetCurrentDirectory()

        If cwd.EndsWith("\bin\Debug") Then
            cwd = cwd.Replace("\bin\Debug", "\..\..\")
        End If

        Return cwd
    End Function


    ''' <summary>
    ''' This is only for setting up the console app demo files and is not really much to do 
    ''' directly with DotImage. It just ensures that it copies Tiger.jpg into the right location
    ''' </summary>
    ''' <returns></returns>
    Private Function DemoSetup() As String
        Dim setupDir As String = Path.Combine(GetWorkingDir(), "_CUSTFILES")
        If (Not Directory.Exists(setupDir)) Then
            Directory.CreateDirectory(setupDir)
            File.Copy("images\Tiger.jpg", Path.Combine(setupDir, "Tiger.jpg"))
        End If

        Return GetWorkingDir()
    End Function
#End Region
End Module


