Imports Newtonsoft.Json

Public Class PackageData

    '<JsonConverter(GetType(RequireConverter))>
    <JsonProperty(NameOf(Packages))>
    Public Property Packages As Dictionary(Of String, List(Of PackageVersion))

    Public Shared Async Function GetInfo(Package As String) As Task(Of PackageData)
        Dim headers As New Dictionary(Of String, String) From {
            {"Content-Type", "application/json"}
        }
        Dim http As New HttpRequest
        Dim httpResponse As HttpRequest.HttpResponseData = Await http.MakeRequest2($"https://repo.packagist.org/p2/{Package}.json", headers:=headers)

        Debug.WriteLine($"Making request to: https://repo.packagist.org/p2/{Package}.json")

        'Dim jsonString = httpResponse.GetBodyAsString()

        'Dim settings As New JsonSerializerSettings()
        'settings.Converters.Add(New RequireConverter())

        'Return JsonConvert.DeserializeObject(Of PackageData)(jsonString, settings)

        Return JsonConvert.DeserializeObject(Of PackageData)(httpResponse.GetBodyAsString)
    End Function

End Class