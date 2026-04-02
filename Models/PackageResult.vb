Imports Newtonsoft.Json

Public Class PackageResult

    <JsonProperty(NameOf(Name))>
    Public Property Name As String

    <JsonProperty(NameOf(description))>
    Public Property description As String

    <JsonProperty(NameOf(url))>
    Public Property url As String

    <JsonProperty(NameOf(repository))>
    Public Property repository As String

    <JsonProperty(NameOf(Downloads))>
    Public Property Downloads As Integer

    <JsonProperty(NameOf(Favers))>
    Public Property Favers As Integer

End Class