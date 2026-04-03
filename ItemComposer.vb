Public Class ItemComposer

    Public Event DeleteRequested(sender As ItemComposer)
    Public Event UpdateRequested(sender As ItemComposer)

    Public Package As String
    Public InstalledVersion As String
    Public ConstraintVersion As String
    Public IsDev As Boolean = False
    Public Path As String

    Private StatusColor As Color = Color.LightGray

    Private Sub ItemComposer_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        lblPackage.Text = Package
        lblInstalled.Text = InstalledVersion

        For Each ctrl As Control In Controls
            AddHandler ctrl.MouseEnter, Sub() BackColor = StatusColor
            AddHandler ctrl.MouseLeave, Sub() BackColor = SystemColors.Control
        Next

        AddHandler MouseEnter, Sub() BackColor = StatusColor
        AddHandler MouseLeave, Sub() BackColor = SystemColors.Control

        RefreshData()
    End Sub

    Private Async Sub RefreshData()
        lblInstalled.Text = "LOADING..."
        lblLatest.Text = "LOADING..."
        lblUpdated.Text = "LOADING..."
        lblLastUpdated.Text = "LOADING..."

        lblPackage.Text = Package & " (" & ConstraintVersion & ")"

        If IsDev Then
            lblRequire.Text = "dev"
            lblRequire.BackColor = Color.FromArgb(226, 227, 229)
        Else
            lblRequire.Text = "app"
            lblRequire.BackColor = Color.FromArgb(207, 226, 255) ' primary cfe2ff
        End If

        Dim pd = Await PackageData.GetInfo(Package)

        Dim pFirst = pd.Packages.First

        'Dim name As String = pFirst.Key
        Dim versions = pFirst.Value

        Dim latest = versions.First()

        lblInstalled.Text = GetInstalledVersion($"{Path}\composer.lock", Package)
        lblLatest.Text = latest.VersionNormalized
        lblUpdated.Text = latest.GetUpdateType(InstalledVersion)
        'lblUpdated.Text = latest.GetRealUpdateType(InstalledVersion, ConstraintVersion)
        lblLastUpdated.Text = latest.LastUpdated

        StatusColor = latest.Color(InstalledVersion)

        lblUpdated.BackColor = StatusColor
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        btnRefresh.Enabled = False

        RefreshData()

        btnRefresh.Enabled = True
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
        OpenUrl("https://packagist.org/packages/" & Package)
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

End Class
