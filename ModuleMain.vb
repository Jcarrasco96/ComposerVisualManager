Imports System.IO
Imports Newtonsoft.Json
Imports NuGet.Versioning

Module ModuleMain

    Public Function IsRealPackage(name As String) As Boolean
        Return name <> "php" AndAlso Not name.StartsWith("ext-") AndAlso Not name.StartsWith("lib-")
    End Function

    Public Function GetLockData(path As String) As ComposerLock
        If Not File.Exists(path) Then
            Return Nothing
        End If

        Dim jsonText As String = File.ReadAllText(path)

        Dim lockData As ComposerLock = JsonConvert.DeserializeObject(Of ComposerLock)(jsonText)

        If lockData.Packages Is Nothing Then
            lockData.Packages = New List(Of LockPackage)
        End If

        If lockData.PackagesDev Is Nothing Then
            lockData.PackagesDev = New List(Of LockPackage)
        End If

        Return lockData
    End Function

    Public Function IsInstalled(fileLock As String, packageName As String) As Boolean
        Dim LockData = GetLockData(fileLock)

        If lockData Is Nothing Then
            Return False
        End If

        Return lockData.Packages.Any(Function(p) p.Name = packageName)
    End Function

    Public Function GetInstalledPackages(fileLock As String) As Dictionary(Of String, String)
        Dim result As New Dictionary(Of String, String)

        Dim LockData = GetLockData(fileLock)

        If lockData Is Nothing Then
            Return result
        End If

        For Each pkg In lockData.Packages
            result(pkg.Name) = pkg.Version
        Next

        Return result
    End Function

    Public Function GetInstalledVersion(fileLock As String, packageName As String) As String
        Dim LockData = GetLockData(fileLock)

        If LockData Is Nothing Then
            Return Nothing
        End If

        Dim pkg = LockData.Packages.FirstOrDefault(Function(p) p.Name = packageName)

        If pkg IsNot Nothing Then
            Return pkg.Version.TrimStart("v"c)
        End If

        pkg = LockData.PackagesDev.FirstOrDefault(Function(p) p.Name = packageName)

        If pkg IsNot Nothing Then
            Return pkg.Version.TrimStart("v"c)
        End If

        Return Nothing
    End Function

    Public  Function GetComposerUpdateType(installed As String, latest As String, constraint As String) As String
        Dim vInstalled As New NuGetVersion(0, 0, 0)
        Dim vLatest As New NuGetVersion(0, 0, 0)

        Dim isInstalledSemantic As Boolean = NuGetVersion.TryParse(installed, vInstalled)
        Dim isLatestSemantic As Boolean = NuGetVersion.TryParse(latest, vLatest)

        If Not isInstalledSemantic OrElse Not isLatestSemantic Then
            If installed <> latest Then
                Return "NON-SEMANTIC-DIFFERENT"
            Else
                Return "UP-TO-DATE"
            End If
        End If

        Dim canUpdate As Boolean

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
                canUpdate = (vLatest = vInstalled)
            End If
        End If

        If Not canUpdate Then
            Return "CANNOT-UPDATE"
        End If

        If vLatest.Major > vInstalled.Major Then Return "MAJOR"
        If vLatest.Minor > vInstalled.Minor Then Return "MINOR"
        If vLatest.Patch > vInstalled.Patch Then Return "PATCH"

        Return "UP-TO-DATE"
    End Function

End Module
