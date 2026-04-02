Imports System.Text.RegularExpressions
Imports Newtonsoft.Json
Imports NuGet.Versioning

Public Class PackageVersion

    <JsonProperty(NameOf(Version))>
    Public Property Version As String

    <JsonProperty("version_normalized")>
    Public Property VersionNormalized As String

    '<JsonProperty(NameOf(Require))>
    'Public Property Require As Dictionary(Of String, String)

    <JsonProperty(NameOf(Time))>
    Public Property Time As String

    <JsonProperty(NameOf(Type))>
    Public Property Type As String

    Public ReadOnly Property LastUpdated As String
        Get
            Return DateTime.Parse(Time).ToString("MM/dd/yyyy HH:mm:ss")
        End Get
    End Property

    Private Shared ReadOnly separator As String() = {"||"}

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

    Public Function GetRealUpdateType(installed As String, constraint As String) As String
        Dim vInstalled As New NuGetVersion(0, 0, 0)
        Dim vLatest As New NuGetVersion(0, 0, 0)

        Dim isInstalledSemantic As Boolean = NuGetVersion.TryParse(installed, vInstalled)
        Dim isLatestSemantic As Boolean = NuGetVersion.TryParse(VersionNormalized, vLatest)

        If Not isInstalledSemantic OrElse Not isLatestSemantic Then
            If installed <> VersionNormalized Then
                Return "NON-SEMANTIC-DIFFERENT"
            Else
                Return "UP-TO-DATE"
            End If
        End If

        Dim canUpdate As Boolean

        Try
            If constraint.StartsWith("~") Then
                Dim baseVersion As NuGetVersion = NuGetVersion.Parse(constraint.Substring(1))
                canUpdate = (vLatest.Major = baseVersion.Major AndAlso vLatest.Minor = baseVersion.Minor AndAlso vLatest >= baseVersion)
            ElseIf constraint.StartsWith("^") Then
                Dim baseVersion As NuGetVersion = NuGetVersion.Parse(constraint.Substring(1))
                canUpdate = (vLatest.Major = baseVersion.Major AndAlso vLatest >= baseVersion)
            ElseIf constraint = "*" Then
                canUpdate = True
            Else
                If constraint.EndsWith(".*") Then
                    Dim majorMinor = constraint.Replace(".*", "").Split("."c)
                    Dim major = Integer.Parse(majorMinor(0))
                    Dim minor = Integer.Parse(majorMinor(1))
                    canUpdate = (vLatest.Major = major AndAlso vLatest.Minor = minor)
                Else
                    canUpdate = CumpleConstraint(installed, constraint, VersionNormalized)
                End If
            End If
        Catch ex As Exception
            canUpdate = CumpleConstraint(installed, constraint, VersionNormalized)
        End Try

        If Not canUpdate Then
            Return "CANNOT-UPDATE"
        End If

        If vLatest.Major > vInstalled.Major Then
            Return "MAJOR"
        End If

        If vLatest.Minor > vInstalled.Minor Then
            Return "MINOR"
        End If

        If vLatest.Patch > vInstalled.Patch Then
            Return "PATCH"
        End If

        Return "UP-TO-DATE"
    End Function

    Public Shared Function CumpleConstraint(installedVersion As String, constraint As String, Optional latestVersion As String = Nothing) As Boolean
        Dim rangos() As String = constraint.Split({"||"}, StringSplitOptions.RemoveEmptyEntries)

        For Each r In rangos
            Dim rangoTrim = r.Trim()

            If rangoTrim = installedVersion Then
                Return True
            End If

            Dim match = Regex.Match(rangoTrim, "(>=|<=|>|<)\s*([\d\.]+)")
            If match.Success Then
                Dim op = match.Groups(1).Value
                Dim ver = match.Groups(2).Value

                Dim vInst As Version
                Dim vReq As Version

                Try
                    vInst = New Version(installedVersion)
                    vReq = New Version(ver)
                Catch
                    Continue For
                End Try

                Select Case op
                    Case ">=" : If vInst >= vReq Then Return True
                    Case "<=" : If vInst <= vReq Then Return True
                    Case ">" : If vInst > vReq Then Return True
                    Case "<" : If vInst < vReq Then Return True
                End Select
            End If

            If latestVersion IsNot Nothing AndAlso rangoTrim = latestVersion Then
                Return True
            End If
        Next

        Return False
    End Function

    Public Function Color(installed As String) As Color
        Dim updateType = GetUpdateType(installed)

        Select Case updateType
            Case "MAJOR"
                Return Color.FromArgb(248, 215, 218) ' danger
                Exit Select

            Case "UP-TO-DATE"
                Return Color.FromArgb(209, 231, 221) ' success
                Exit Select

            Case "UNKNOWN"
                Return Color.FromArgb(207, 244, 252) ' info
                Exit Select

            Case "MINOR"
                Return Color.FromArgb(226, 227, 229) ' secondary
                Exit Select

            Case "PATCH"
                Return Color.FromArgb(255, 243, 205) ' warning
                Exit Select

            Case Else
                Return Color.LightGray
        End Select
    End Function

End Class
