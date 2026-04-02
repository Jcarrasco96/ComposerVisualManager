Imports System.IO
Imports System.Net.Http
Imports Newtonsoft.Json

Public Class FormInstall

    Private http As New HttpRequest
    Private httpResponse As HttpRequest.HttpResponseData
    Private headers As New Dictionary(Of String, String) From {
        {"Content-Type", "application/json"}
    }

    Public Path As String

    Private Async Function BuscarPaquetes(query As String) As Task(Of PackagistResponse)
        Using client As New HttpClient()
            httpResponse = Await http.MakeRequest2($"https://packagist.org/search.json?q={query}", headers:=headers) ' &per_page=5

            Return JsonConvert.DeserializeObject(Of PackagistResponse)(httpResponse.GetBodyAsString)
        End Using
    End Function

    Private Async Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim result = Await BuscarPaquetes(txtSearch.Text)

        gridPackages.DataSource = result.results

        gridPackages.Columns("name").HeaderText = "Package"
        gridPackages.Columns("description").HeaderText = "Descripción"
        gridPackages.Columns("downloads").HeaderText = "Downloads"
        gridPackages.Columns("favers").HeaderText = "Stars"

        gridPackages.Columns("url").Visible = False
        gridPackages.Columns("repository").Visible = False

        gridPackages.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If gridPackages.CurrentRow Is Nothing Then
            Exit Sub
        End If

        Dim packageName As String = gridPackages.CurrentRow.Cells("name").Value.ToString()

        Dim command = $"require {packageName}"

        Dim installDev As DialogResult = MessageBox.Show("Do you want to install this package as Dev (--dev)?", "Instalar como Dev", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If installDev = DialogResult.Yes Then
            command &= " --dev"
        End If

        Dim d As New DialogProgressComposer With {
            .Path = Path,
            .Command = command
        }

        d.ShowDialog()
    End Sub
End Class