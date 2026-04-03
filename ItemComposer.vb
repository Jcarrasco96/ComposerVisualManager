Public Class ItemComposer

    Public Event DeleteRequested(package As String, isDev As Boolean)
    Public Event UpdateRequested(package As String, isDev As Boolean, forceUpdate As Boolean, latestVersion As String)

    Private Package As String = Nothing
    Private IsDev As Boolean = False
    Private Path As String = Nothing

    Private LatastVersion As String = Nothing

    Private StatusColor As Color = Color.LightGray

    Public Sub New(package As String, constraintVersion As String, isDev As Boolean, path As String)
        InitializeComponent()

        Dock = DockStyle.Top

        For Each ctrl As Control In Controls
            AddHandler ctrl.MouseEnter, Sub() BackColor = StatusColor
            AddHandler ctrl.MouseLeave, Sub() BackColor = SystemColors.Control
        Next

        AddHandler MouseEnter, Sub() BackColor = StatusColor
        AddHandler MouseLeave, Sub() BackColor = SystemColors.Control

        Me.Package = package
        Me.IsDev = isDev
        Me.Path = path

        lblPackage.Text = package & " (" & constraintVersion & ")"
    End Sub

    Public Async Function RefreshData() As Task
        lblInstalled.Text = "LOADING..."
        lblLatest.Text = "LOADING..."
        lblUpdated.Text = "LOADING..."
        lblLastUpdated.Text = "LOADING..."

        If IsDev Then
            lblRequire.Text = "dev"
            lblRequire.BackColor = Color.FromArgb(226, 227, 229)
        Else
            lblRequire.Text = "app"
            lblRequire.BackColor = Color.FromArgb(207, 226, 255) ' primary cfe2ff
        End If

        Dim pd As PackageData = Await PackageData.GetInfo(Package)

        Dim installedVersion As String = GetInstalledVersion($"{Path}\composer.lock", Package)

        lblInstalled.Text = installedVersion

        Dim pFirst As KeyValuePair(Of String, List(Of PackageVersion)) = pd.Packages.First

        'Dim name As String = pFirst.Key
        Dim versions As List(Of PackageVersion) = pFirst.Value

        If versions.Count = 0 Then
            lblLatest.Text = "NO INFO"
            lblUpdated.Text = "NO INFO"
            lblLastUpdated.Text = "NO INFO"
            Exit Function
        End If

        Dim latest As PackageVersion = versions.First()

        LatastVersion = latest.VersionNormalized

        lblLatest.Text = latest.VersionNormalized
        lblUpdated.Text = latest.GetUpdateType(installedVersion)
        'lblUpdated.Text = latest.GetRealUpdateType(InstalledVersion, ConstraintVersion)
        lblLastUpdated.Text = latest.LastUpdated

        StatusColor = latest.Color(installedVersion)

        lblUpdated.BackColor = StatusColor

        If latest.GetUpdateType(installedVersion) = "UP-TO-DATE" Then
            btnUpdate.Enabled = False
        End If
    End Function

    Private Async Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        btnRefresh.Enabled = False

        Await RefreshData()

        btnRefresh.Enabled = True
        btnRefresh.Focus()
    End Sub

    Private Async Sub BbnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        Dim isForce As Boolean = (ModifierKeys And Keys.Shift) = Keys.Shift

        RaiseEvent UpdateRequested(Package, IsDev, isForce, LatastVersion)

        Await RefreshData()
    End Sub

    Private Sub BtnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As MsgBoxResult = MsgBox("Are you sure you want to remove the extension `" & Package & "`?", CType(MsgBoxStyle.YesNo + MsgBoxStyle.Question, MsgBoxStyle))

        If result = MsgBoxResult.Yes Then
            RaiseEvent DeleteRequested(Package, IsDev)
        End If
    End Sub

    Private Sub LblPackage_Click(sender As Object, e As EventArgs) Handles lblPackage.Click
        OpenUrl("https://packagist.org/packages/" & Package)
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
