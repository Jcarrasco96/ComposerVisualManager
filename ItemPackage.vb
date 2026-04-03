Public Class ItemPackage

    Public Event InstallRequested(package As String)

    Private PackageName As String = Nothing

    Public Sub New(packageResult As PackageResult, isInstalled As Boolean)
        InitializeComponent()

        Dock = DockStyle.Top

        PackageName = packageResult.Name

        lblPackage.Text = packageResult.Name
        lblDescription.Text = packageResult.Description
        lblDownloads.Text = packageResult.Downloads.ToString
        lblStars.Text = packageResult.Favers.ToString

        If isInstalled Then
            lblPackage.Text = packageResult.Name & " (INSTALLED)"
        End If

        For Each ctrl As Control In Controls
            AddHandler ctrl.MouseEnter, Sub() BackColor = Color.DarkGray
            AddHandler ctrl.MouseLeave, Sub() BackColor = SystemColors.Control
        Next

        AddHandler MouseEnter, Sub() BackColor = Color.DarkGray
        AddHandler MouseLeave, Sub() BackColor = SystemColors.Control
    End Sub

    Private Sub BtnDownload_Click(sender As Object, e As EventArgs) Handles btnDownload.Click
        RaiseEvent InstallRequested(PackageName)
    End Sub

    Private Sub LblPackage_Click(sender As Object, e As EventArgs) Handles lblPackage.Click
        OpenUrl("https://packagist.org/packages/" & PackageName)
    End Sub

    Private Sub LblPackage_MouseEnter(sender As Object, e As EventArgs) Handles lblPackage.MouseEnter
        If TypeOf sender Is Label Then
            Dim lbl As Label = DirectCast(sender, Label)

            lbl.ForeColor = Color.Blue
            lbl.Font = New Font(lbl.Font, FontStyle.Underline)
            lbl.Cursor = Cursors.Hand
        End If
    End Sub

    Private Sub LblPackage_MouseLeave(sender As Object, e As EventArgs) Handles lblPackage.MouseLeave
        If TypeOf sender Is Label Then
            Dim lbl As Label = DirectCast(sender, Label)
            lbl.ForeColor = SystemColors.ControlText
            lbl.Font = New Font(lbl.Font, FontStyle.Regular)
            lbl.Cursor = Cursors.Default
        End If
    End Sub

End Class
