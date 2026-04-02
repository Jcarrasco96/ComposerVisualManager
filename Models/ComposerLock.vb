Imports Newtonsoft.Json

Public Class ComposerLock

    <JsonProperty(NameOf(Packages))>
    Public Property Packages As List(Of LockPackage)

    <JsonProperty("packages-dev")>
    Public Property PackagesDev As List(Of LockPackage)

End Class