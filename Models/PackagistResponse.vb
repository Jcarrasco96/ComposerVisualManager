Imports Newtonsoft.Json

Public Class PackagistResponse

    <JsonProperty(NameOf(Results))>
    Public Property Results As List(Of PackageResult)

    <JsonProperty(NameOf(Total))>
    Public Property Total As Integer

    <JsonProperty(NameOf([Next]))>
    Public Property [Next] As String

End Class