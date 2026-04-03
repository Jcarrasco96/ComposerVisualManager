Public Class DialogProgressComposer

    Public Path As String
    Public Command As String

    Private Sub Dialog1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Text = $"composer {Command} --no-scripts"

        EjecutarComposer()
    End Sub

    Private Sub AppendTextSafe(text As String)
        If txtOutput.InvokeRequired Then
            txtOutput.Invoke(Sub() txtOutput.AppendText(text & Environment.NewLine))
        Else
            txtOutput.AppendText(text & Environment.NewLine)
        End If
    End Sub

    Private Async Sub EjecutarComposer()
        txtOutput.Clear()
        ControlBox = False

        Dim psi As New ProcessStartInfo With {
            .FileName = "cmd.exe",
            .Arguments = $"/c composer {Command} --no-scripts 2>&1",
            .RedirectStandardOutput = True,
            .RedirectStandardError = True,
            .UseShellExecute = False,
            .CreateNoWindow = True,
            .WorkingDirectory = Path
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

        'Close()
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

End Class
