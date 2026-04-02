Imports Newtonsoft.Json
Imports NuGet.Versioning

Public Class ItemComposer

    Public Package As String
    Public InstalledVersion As String
    Public ConstraintVersion As String
    Public IsDev As Boolean = False



    Private StatusColor As Color = Color.LightGray

    Private Sub ItemComposer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPackage.Text = Package
        lblInstalled.Text = InstalledVersion

        For Each ctrl As Control In Controls
            AddHandler ctrl.MouseEnter, Sub() BackColor = StatusColor
            AddHandler ctrl.MouseLeave, Sub() BackColor = SystemColors.Control
        Next

        RefreshData()
    End Sub

    Private Sub ItemComposer_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        BackColor = StatusColor
    End Sub

    Private Sub ItemComposer_MouseLeave(sender As Object, e As EventArgs) Handles Me.MouseLeave
        BackColor = SystemColors.Control
    End Sub

    Private Async Sub RefreshData()
        lblLatest.Text = "LOADING..."
        lblUpdated.Text = "LOADING..."
        lblLastUpdated.Text = "LOADING..."

        lblPackage.Text = Package & " (" & ConstraintVersion & ")"

        If IsDev Then
            lblRequire.Text = "dev"
        Else
            lblRequire.Text = "app"
        End If

        Dim pd = Await PackageData.GetInfo(Package)

        Dim pFirst = pd.Packages.First

        'Dim name As String = pFirst.Key
        Dim versions = pFirst.Value

        Dim latest = versions.First()

        lblLatest.Text = latest.VersionNormalized
        lblUpdated.Text = latest.GetUpdateType(InstalledVersion)
        'lblUpdated.Text = latest.GetRealUpdateType(InstalledVersion, ConstraintVersion)
        lblLastUpdated.Text = latest.LastUpdated

        StatusColor = latest.Color(InstalledVersion)

        lblUpdated.BackColor = StatusColor
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        RefreshData()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RaiseEvent UpdateRequested(Me)
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result = MsgBox("Are you sure you want to remove the extension `" & Package & "`?", MsgBoxStyle.YesNo + MsgBoxStyle.Question)

        If result = MsgBoxResult.Yes Then
            RaiseEvent DeleteRequested(Me)
        End If
    End Sub

    Private Sub LblPackage_Click(sender As Object, e As EventArgs) Handles lblPackage.Click
        Dim psi As New ProcessStartInfo("https://packagist.org/packages/" & Package) With {
            .UseShellExecute = True
        }
        Process.Start(psi)
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

    Public Event DeleteRequested(sender As ItemComposer)
    Public Event UpdateRequested(sender As ItemComposer)

End Class
