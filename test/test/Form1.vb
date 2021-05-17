
Public Class Form1

    Function csv_spriter(file As String)

        Dim Reader As New IO.StreamReader(file, System.Text.Encoding.GetEncoding("Shift-JIS"))
        Dim Items() As String                'CSVの各項目を表す配列
        Dim Line As String = Reader.ReadLine

        Items = Line.Split(",")                   '一行を, (カンマ)で区切って項目ごとに分解
        Reader.Close()

        Return Items

    End Function

    Function csv_list(path As String)

        Dim folders As New IO.DirectoryInfo(path)
        Dim csvs() As IO.FileInfo = folders.GetFiles
        Dim Times(csvs.Length - 1) As Date

        For i = 0 To csvs.Length - 1
            Times(i) = csvs(i).LastWriteTime
        Next

        Array.Sort(Times, csvs)

        Return csvs

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim main_path As String
        Dim csv_path As String
        Dim fname() As IO.FileInfo
        Dim flength As Integer
        Dim csv_items() As String
        Dim file As String
        Dim j_num As Integer

        main_path = System.IO.Directory.GetCurrentDirectory()
        csv_path = main_path & "\ALDEA"

        fname = csv_list(csv_path)
        flength = fname.Length

        For i As Integer = 0 To flength - 1

            file = csv_path & "\" & fname(i).ToString
            csv_items = csv_spriter(file)
            Console.WriteLine(csv_items(0))
            Console.WriteLine(csv_items(1))
            Console.WriteLine(csv_items(2))

            If csv_items(0) = "J" Then
                j_num = j_num + 1

            End If

        Next

        Console.WriteLine(j_num)
    End Sub
End Class
