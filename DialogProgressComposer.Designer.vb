<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DialogProgressComposer
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        txtOutput = New TextBox()
        SuspendLayout()
        ' 
        ' txtOutput
        ' 
        txtOutput.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        txtOutput.BorderStyle = BorderStyle.FixedSingle
        txtOutput.Location = New Point(10, 9)
        txtOutput.Margin = New Padding(3, 2, 3, 2)
        txtOutput.Multiline = True
        txtOutput.Name = "txtOutput"
        txtOutput.ReadOnly = True
        txtOutput.ScrollBars = ScrollBars.Vertical
        txtOutput.Size = New Size(784, 524)
        txtOutput.TabIndex = 1
        ' 
        ' DialogProgressComposer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(804, 541)
        Controls.Add(txtOutput)
        FormBorderStyle = FormBorderStyle.FixedDialog
        Margin = New Padding(4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "DialogProgressComposer"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "composer"
        ResumeLayout(False)
        PerformLayout()

    End Sub
    Friend WithEvents txtOutput As TextBox

End Class
