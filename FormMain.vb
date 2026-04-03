Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class FormMain

    ' TODO composer config allow-plugins.* true

    Private Path As String ' = "C:\DEVELOP\PROGRAMMING\WEB\SISTEMAS_TCM\your_project"

    Private Async Sub LoadComposerJson()
        panelItems.Controls.Clear()

        btnRefresh.Enabled = False
        btnUpdateAll.Enabled = False
        btnSearch.Enabled = False

        tssStatus.Text = $"Loading: {Path}"

        If Not File.Exists($"{Path}\composer.json") Then
            MessageBox.Show("composer.json not found.")
            Path = Nothing
            tssStatus.Text = "No path selected."
            Exit Sub
        End If

        Dim lockData As ComposerLock = GetLockData($"{Path}\composer.lock")

        If lockData Is Nothing Then
            If MessageBox.Show("There is no lock file. Doy you want run `composer update` to generate a lock file?", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            DialogProgressComposer.Show(Path, "update")

            LoadComposerJson()
        End If

        Dim requireList As New List(Of RequireComposerItem)

        Dim jsonText As String = File.ReadAllText($"{Path}\composer.json")
        Dim json As JObject = JObject.Parse(jsonText)

        Dim require As JToken = json.SelectToken("require")

        If require IsNot Nothing Then
            AddRows(requireList, require)
        End If

        Dim requireDev As JToken = json.SelectToken("require-dev")

        If requireDev IsNot Nothing Then
            AddRows(requireList, requireDev, True)
        End If

        Dim requireListSorted As List(Of RequireComposerItem) = requireList _
            .OrderBy(Function(x) x.IsDev) _
            .ThenBy(Function(x) x.Package) _
            .ToList()

        panelItems.Visible = False

        For Each item As RequireComposerItem In requireListSorted
            Dim newPanel As New ItemComposer(item.Package, item.ConstraintVersion, item.IsDev, Path)

            Await newPanel.RefreshData()

            AddHandler newPanel.DeleteRequested, AddressOf DeleteItem
            AddHandler newPanel.UpdateRequested, AddressOf UpdateItem

            panelItems.Controls.Add(newPanel)
            panelItems.Controls.SetChildIndex(newPanel, 0)

            tssStatus.Text = $"Adding package `{item.Package}`."
        Next

        panelItems.Visible = True
        panelItems.Select()

        btnRefresh.Enabled = True
        btnUpdateAll.Enabled = True
        btnSearch.Enabled = True

        tssStatus.Text = $"Working on: {Path}"
    End Sub

    Private Sub AddRows(ByRef array As List(Of RequireComposerItem), require As JToken, Optional isDev As Boolean = False)
        Dim item As RequireComposerItem

        For Each prop As JProperty In require
            If Not IsRealPackage(prop.Name) Then
                Continue For
            End If

            item = New RequireComposerItem With {
                .Package = prop.Name,
                .ConstraintVersion = prop.Value.ToString(),
                .IsDev = isDev
            }

            array.Add(item)
        Next
    End Sub

    Private Sub UpdateItem(package As String, isDev As Boolean, forceUpdate As Boolean, latestVersion As String)
        Dim command As String = $"update {package} -W"

        If forceUpdate Then
            command = $"require {package}:{latestVersion} -W"
        End If

        If isDev Then
            command &= " --dev"
        End If

        DialogProgressComposer.Show(Path, command)
    End Sub

    Private Sub DeleteItem(package As String, isDev As Boolean)
        Dim command As String = $"remove {package}"

        If isDev Then
            command &= " --dev"
        End If

        DialogProgressComposer.Show(Path, command)

        LoadComposerJson()
    End Sub

    Private Sub FormMain_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        Else
            e.Effect = DragDropEffects.None
        End If
    End Sub

    Private Sub FormMain_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop
        Dim rutas() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

        If rutas.All(Function(r) Directory.Exists(r)) Then
            Path = rutas.First

            LoadComposerJson()
        Else
            Path = Nothing
            tssStatus.Text = "No path selected."
            MessageBox.Show("Only folders are allowed.")
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Path Is Nothing Then
            MessageBox.Show("To add any library or extension, you must first select a Composer folder or project.")
            Exit Sub
        End If

        Dim formInstall As New FormInstall(Path)

        formInstall.ShowDialog()

        LoadComposerJson()
    End Sub

    Private Sub BtnUpdateAll_Click(sender As Object, e As EventArgs) Handles btnUpdateAll.Click
        DialogProgressComposer.Show(Path, "update")

        LoadComposerJson()
    End Sub

    Private Sub BtnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadComposerJson()
    End Sub

    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles Me.Load
        If Path IsNot Nothing Then ' used in debug
            LoadComposerJson()
        End If
    End Sub

End Class
