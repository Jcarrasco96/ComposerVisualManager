Public Class FormInstall

    Public Path As String
    Private LockData As ComposerLock

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        SearchPackages()
    End Sub

    Private Async Sub SearchPackages()
        btnSearch.Enabled = False

        Dim result = Await PackagistResponse.SearchPackages(txtSearch.Text)

        panelItems.Controls.Clear()

        If result.Results IsNot Nothing Then
            For Each item As PackageResult In result.Results
                Dim newPanel As New ItemPackage With {
                    .Dock = DockStyle.Top,
                    .Package = item,
                    .LockData = LockData
                }

                AddHandler newPanel.InstallRequested, AddressOf InstallItem

                panelItems.Controls.Add(newPanel)
                panelItems.Controls.SetChildIndex(newPanel, 0)
            Next
        End If

        panelItems.Select()

        btnSearch.Enabled = True
    End Sub

    Private Sub InstallItem(package As String)
        Dim installDev As DialogResult = MessageBox.Show("Do you want to install this package as Dev (--dev)?", "Instalar como Dev", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

        If installDev = DialogResult.Cancel Then
            Exit Sub
        End If

        Dim command = $"require {package}"

        If installDev = DialogResult.Yes Then
            command &= " --dev"
        End If

        LoadDialog(Path, command)
    End Sub

    Private Sub FormInstall_Load(sender As Object, e As EventArgs) Handles Me.Load
        LockData = GetLockData($"{Path}\composer.lock")
    End Sub

    Private Sub TxtSearch_KeyDown(sender As Object, e As KeyEventArgs) Handles txtSearch.KeyDown
        If e.KeyCode = Keys.Enter Then
            SearchPackages()
            e.SuppressKeyPress = True
        End If
    End Sub

End Class