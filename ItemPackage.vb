Public Class ItemPackage

    Public Event InstallRequested(package As String)

    Public Package As PackageResult
    Public LockData As ComposerLock

    Private Sub ItemPackage_Load(sender As Object, e As EventArgs) Handles Me.Load
        lblPackage.Text = Package.Name
        lblDescription.Text = Package.Description
        lblDownloads.Text = Package.Downloads
        lblStars.Text = Package.Favers

        For Each ctrl As Control In Controls
            AddHandler ctrl.MouseEnter, Sub() BackColor = Color.DarkGray
            AddHandler ctrl.MouseLeave, Sub() BackColor = SystemColors.Control
        Next

        AddHandler MouseEnter, Sub() BackColor = Color.DarkGray
        AddHandler MouseLeave, Sub() BackColor = SystemColors.Control

        If IsInstalled(Package.Name) Then
            lblPackage.Text = Package.Name & " (INSTALLED)"
        End If
    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        RaiseEvent InstallRequested(Package.Name)
    End Sub

    Private Sub LblPackage_Click(sender As Object, e As EventArgs) Handles lblPackage.Click
        OpenUrl("https://packagist.org/packages/" & Package.Name)
    End Sub

    Private Sub LblPackage_MouseEnter(sender As Label, e As EventArgs) Handles lblPackage.MouseEnter
        sender.ForeColor = Color.Blue
        sender.Font = New Font(sender.Font, FontStyle.Underline)
        sender.Cursor = Cursors.Hand
    End Sub

    Private Sub LblPackage_MouseLeave(sender As Label, e As EventArgs) Handles lblPackage.MouseLeave
        sender.ForeColor = SystemColors.ControlText
        sender.Font = New Font(sender.Font, FontStyle.Regular)
        sender.Cursor = Cursors.Default
    End Sub

    Public Function IsInstalled(packageName As String) As Boolean
        If LockData Is Nothing Then
            Return False
        End If

        If LockData.Packages.Any(Function(p) p.Name = packageName) Then
            Return True
        End If

        If LockData.PackagesDev.Any(Function(p) p.Name = packageName) Then
            Return True
        End If

        Return False
    End Function

End Class
