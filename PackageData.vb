Imports Newtonsoft.Json
Imports NuGet.Versioning

Public Class PackageData

    <JsonProperty(NameOf(Packages))>
    Public Property Packages As Dictionary(Of String, List(Of PackageVersion))

End Class

Public Class PackageVersion

    <JsonProperty(NameOf(Version))>
    Public Property Version As String

    <JsonProperty("version_normalized")>
    Public Property VersionNormalized As String

    <JsonProperty(NameOf(Require))>
    Public Property Require As Dictionary(Of String, String)

    <JsonProperty(NameOf(Time))>
    Public Property Time As String

    <JsonProperty(NameOf(Type))>
    Public Property Type As String

    Public ReadOnly Property LastUpdated As String
        Get
            Return DateTime.Parse(Time).ToString("MM/dd/yyyy HH:mm:ss")
        End Get
    End Property

    Public Function GetUpdateType(installed As String) As String
        Dim v1, v2 As New NuGetVersion(0, 0, 0)

        If Not NuGetVersion.TryParse(installed, v1) OrElse Not NuGetVersion.TryParse(VersionNormalized, v2) Then
            Return "UNKNOWN"
        End If

        If v2.Major > v1.Major Then
            Return "MAJOR"
        End If

        If v2.Minor > v1.Minor Then
            Return "MINOR"
        End If

        If v2.Patch > v1.Patch Then
            Return "PATCH"
        End If

        Return "UP-TO-DATE"
    End Function

End Class

Public Class ComposerLock

    <JsonProperty(NameOf(Packages))>
    Public Property Packages As List(Of LockPackage)

    <JsonProperty("packages-dev")>
    Public Property PackagesDev As List(Of LockPackage)

End Class

Public Class LockPackage

    <JsonProperty(NameOf(Name))>
    Public Property Name As String

    <JsonProperty(NameOf(Version))>
    Public Property Version As String

End Class

Public Class RequireComposerItem

    Public Property Package As String
    Public Property InstalledVersion As String
    Public Property ConstraintVersion As String
    Public Property IsDev As Boolean

End Class

Public Class PackagistResponse
    Public Property results As List(Of PackageResult)
    Public Property total As Integer
    Public Property [next] As String
End Class

Public Class PackageResult
    Public Property name As String
    Public Property description As String
    Public Property url As String
    Public Property repository As String
    Public Property downloads As Integer
    Public Property favers As Integer
End Class