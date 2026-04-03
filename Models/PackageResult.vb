Imports Newtonsoft.Json

Public Class PackageResult

    <JsonProperty(NameOf(Name))>
    Public Property Name As String

    <JsonProperty(NameOf(Description))>
    Public Property Description As String

    <JsonProperty(NameOf(Url))>
    Public Property Url As String

    <JsonProperty(NameOf(Repository))>
    Public Property Repository As String

    <JsonProperty(NameOf(Downloads))>
    Public Property Downloads As Integer

    <JsonProperty(NameOf(Favers))>
    Public Property Favers As Integer

End Class