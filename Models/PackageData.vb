Imports System.IO
Imports Newtonsoft.Json

Public Class PackageData

    <JsonProperty(NameOf(Packages))>
    Public Property Packages As Dictionary(Of String, List(Of PackageVersion))

    Public Shared Async Function GetInfo(Package As String) As Task(Of PackageData)
        Dim filePath As String = Path.Combine("cache", $"{Package}.json")

        Dim dir As String = Path.GetDirectoryName(filePath)
        Directory.CreateDirectory(dir)

        If File.Exists(filePath) Then
            Dim lastWrite As Date = File.GetLastWriteTime(filePath)

            If (DateTime.Now - lastWrite).TotalMinutes < 10 Then
                Dim json As String = Await File.ReadAllTextAsync(filePath)
                Return JsonConvert.DeserializeObject(Of PackageData)(json)
            End If
        End If

        Dim httpResponse As HttpRequest.HttpResponseData = Await My.Application.Http.MakeRequest2($"https://repo.packagist.org/p2/{Package}.json", headers:=My.Application.HttpHeaders)

        Debug.WriteLine($"Making request to: https://repo.packagist.org/p2/{Package}.json")

        Dim body As String = httpResponse.GetBodyAsString

        Await File.WriteAllTextAsync(filePath, body)

        Return JsonConvert.DeserializeObject(Of PackageData)(body)
    End Function

End Class