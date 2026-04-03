Imports Newtonsoft.Json

Public Class PackagistResponse

    <JsonProperty(NameOf(Results))>
    Public Property Results As List(Of PackageResult)

    <JsonProperty(NameOf(Total))>
    Public Property Total As Integer

    <JsonProperty(NameOf([Next]))>
    Public Property [Next] As String

    Public Shared Async Function SearchPackages(query As String) As Task(Of PackagistResponse)
        Dim httpResponse As HttpRequest.HttpResponseData = Await My.Application.Http.MakeRequest2($"https://packagist.org/search.json?q={query}", headers:=My.Application.HttpHeaders)

        Debug.WriteLine($"Making request to: https://packagist.org/search.json?q={query}")

        Return JsonConvert.DeserializeObject(Of PackagistResponse)(httpResponse.GetBodyAsString)
    End Function

End Class