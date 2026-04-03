Imports Newtonsoft.Json

Public Class PackageData

    <JsonProperty(NameOf(Packages))>
    Public Property Packages As Dictionary(Of String, List(Of PackageVersion))

    Public Shared Async Function GetInfo(Package As String) As Task(Of PackageData)
        Dim httpResponse As HttpRequest.HttpResponseData = Await My.Application.Http.MakeRequest2($"https://repo.packagist.org/p2/{Package}.json", headers:=My.Application.HttpHeaders)

        Debug.WriteLine($"Making request to: https://repo.packagist.org/p2/{Package}.json")

        Return JsonConvert.DeserializeObject(Of PackageData)(httpResponse.GetBodyAsString)
    End Function

End Class