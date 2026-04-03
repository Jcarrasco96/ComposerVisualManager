Public Class FormInstall

    Private Path As String
    Private LockData As ComposerLock

    Public Sub New(path As String)
        InitializeComponent()

        Me.Path = path
        LockData = GetLockData($"{path}\composer.lock")
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchPackages()
    End Sub

    Private Async Sub SearchPackages()
        btnSearch.Enabled = False
        txtSearch.Enabled = False

        panelItems.Controls.Clear()
        panelItems.Visible = False

        Dim result As PackagistResponse = Await PackagistResponse.SearchPackages(txtSearch.Text)

        If result.Results IsNot Nothing Then
            For Each item As PackageResult In result.Results
                Dim newPanel As New ItemPackage(item, IsInstalled(item.Name))

                AddHandler newPanel.InstallRequested, AddressOf InstallItem

                panelItems.Controls.Add(newPanel)
                panelItems.Controls.SetChildIndex(newPanel, 0)
            Next
        End If

        panelItems.Visible = True
        panelItems.Select()

        btnSearch.Enabled = True
        txtSearch.Enabled = True
    End Sub

    Private Sub InstallItem(package As String)
        Dim installDev As DialogResult = MessageBox.Show("Do you want to install this package as Dev (--dev)?", "Instalar como Dev", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If installDev = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim command As String = $"require {package}"

        If installDev = DialogResult.Yes Then
            command &= " --dev"
        End If

        DialogProgressComposer.Show(Path, command)
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchPackages()
            e.SuppressKeyPress = True
        End If
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