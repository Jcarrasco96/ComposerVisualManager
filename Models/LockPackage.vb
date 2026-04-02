Imports Newtonsoft.Json

Public Class LockPackage

    <JsonProperty(NameOf(Name))>
    Public Property Name As String

    <JsonProperty(NameOf(Version))>
    Public Property Version As String

End Class