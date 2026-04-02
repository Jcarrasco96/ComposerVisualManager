Imports System.IO
Imports Newtonsoft.Json.Linq

Public Class FormMain

    Private Path As String

    'Private LockData As ComposerLock = Nothing

    'Private Sub BtnOpenProject_Click(sender As Object, e As EventArgs) Handles btnOpenProject.Click
    '    LoadComposerJson()
    'End Sub

    Private Sub LoadComposerJson()
        If Not File.Exists($"{Path}\composer.json") Then
            MessageBox.Show("composer.json not found.")
            Path = Nothing
            tssStatus.Text = "No path selected."
            Exit Sub
        End If

        Dim lockData = GetLockData($"{Path}\composer.lock")

        If lockData Is Nothing Then
            If MessageBox.Show("There is no lock file. Doy you want run `composer update` to generate a lock file?", "", MessageBoxButtons.YesNo) = DialogResult.No Then
                Exit Sub
            End If

            Dim d As New DialogProgressComposer With {
                .Path = Path,
                .Command = "update"
            }

            d.ShowDialog()

            LoadComposerJson()
        End If

        Dim requireList As New List(Of RequireComposerItem)

        Dim jsonText As String = File.ReadAllText($"{Path}\composer.json")
        Dim json As JObject = JObject.Parse(jsonText)

        Dim require = json.SelectToken("require")

        If require IsNot Nothing Then
            AddRows(requireList, require)
        End If

        Dim requireDev = json.SelectToken("require-dev")

        If requireDev IsNot Nothing Then
            AddRows(requireList, requireDev, True)
        End If

        Dim requireListSorted = requireList _
            .OrderBy(Function(x) Not x.IsDev) _
            .ThenByDescending(Function(x) x.Package) _
            .ToList()

        panelItems.Controls.Clear()

        For Each item As RequireComposerItem In requireListSorted
            Dim newPanel As New ItemComposer With {
                .Dock = DockStyle.Top,
                .Package = item.Package,
                .InstalledVersion = item.InstalledVersion,
                .ConstraintVersion = item.ConstraintVersion,
                .IsDev = item.IsDev
            }

            AddHandler newPanel.DeleteRequested, AddressOf DeleteItem
            AddHandler newPanel.UpdateRequested, AddressOf UpdateItem

            panelItems.Controls.Add(newPanel)
        Next

        panelItems.Select()
    End Sub

    Private Sub AddRows(ByRef array As List(Of RequireComposerItem), require As JToken, Optional isDev As Boolean = False)
        Dim item As RequireComposerItem

        For Each prop As JProperty In require
            If Not IsRealPackage(prop.Name) Then
                Continue For
            End If

            item = New RequireComposerItem With {
                .Package = prop.Name,
                .InstalledVersion = GetInstalledVersion($"{Path}\composer.lock", prop.Name),
                .ConstraintVersion = prop.Value.ToString(),
                .IsDev = isDev
            }

            array.Add(item)

            tssStatus.Text = $"Adding: {prop.Name}"
        Next

        tssStatus.Text = $"Working on: {Path}"
    End Sub

    Private Sub UpdateItem(sender As ItemComposer)
        Dim command As String = $"update {sender.Package}"

        If sender.IsDev Then
            command &= " --dev"
        End If

        Dim d As New DialogProgressComposer With {
            .Path = Path,
            .Command = command
        }

        d.ShowDialog()
    End Sub

    Private Sub DeleteItem(sender As ItemComposer)
        Dim command As String = $"remove {sender.Package}"

        If sender.IsDev Then
            command &= " --dev"
        End If

        Dim d As New DialogProgressComposer With {
            .Path = Path,
            .Command = command
        }

        d.ShowDialog()

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

            tssStatus.Text = $"Working on: {Path}"

            LoadComposerJson()
        Else
            tssStatus.Text = "Only folders are allowed."
            MessageBox.Show("Only folders are allowed.")
        End If
    End Sub

    Private Sub BtnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        If Path Is Nothing Then
            MessageBox.Show("To add any library or extension, you must first select a Composer folder or project.")
            Exit Sub
        End If

        Dim formInstall As New FormInstall With {
            .Path = Path
        }

        formInstall.ShowDialog()

        LoadComposerJson()
    End Sub

    Private Sub btnUpdateAll_Click(sender As Object, e As EventArgs) Handles btnUpdateAll.Click
        Dim d As New DialogProgressComposer With {
            .Path = Path,
            .Command = "update"
        }

        d.ShowDialog()

        LoadComposerJson()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
        LoadComposerJson()
    End Sub

End Class
