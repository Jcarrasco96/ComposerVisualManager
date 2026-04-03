Public Class DialogProgressComposer

    'Public Path As String
    'Public Command As String

    Public Sub New(path As String, command As String)
        InitializeComponent()

        'Me.Path = path
        'Me.Command = command

        Text = $"composer {command} --no-progress --no-scripts"

        EjecutarComposer(path, command)
    End Sub

    Private Sub AppendTextSafe(text As String)
        If txtOutput.InvokeRequired Then
            txtOutput.Invoke(Sub() txtOutput.AppendText(text & Environment.NewLine))
        Else
            txtOutput.AppendText(text & Environment.NewLine)
        End If
    End Sub

    Private Async Sub EjecutarComposer(path As String, command As String)
        txtOutput.Clear()
        ControlBox = False

        Dim psi As New ProcessStartInfo With {
            .FileName = "cmd.exe",
            .Arguments = $"/c composer {command} --no-progress --no-scripts 2>&1",
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .WorkingDirectory = path
        }

        Dim proc As New Process With {
            .StartInfo = psi
        }

        AddHandler proc.OutputDataReceived, AddressOf WriteOutput

        proc.Start()
        proc.BeginOutputReadLine()
        proc.BeginErrorReadLine()

        Await Task.Run(Sub() proc.WaitForExit())

        AppendTextSafe("----- EOF -----")

        ControlBox = True
    End Sub

    Private Sub WriteOutput(sender As Object, e As DataReceivedEventArgs)
        If String.IsNullOrEmpty(e.Data) Then
            Return
        End If

        If e.Data.Contains("packages you are using are looking for funding") Then
            Exit Sub
        End If
        If e.Data.Contains("composer fund") Then
            Exit Sub
        End If

        AppendTextSafe(e.Data)
    End Sub

    Public Overloads Shared Sub Show(path As String, command As String)
        Dim d As New DialogProgressComposer(path, command)

        d.ShowDialog()
    End Sub


End Class
