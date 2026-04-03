<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemPackage
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        btnDownload = New Button()
        lblStars = New Label()
        lblDownloads = New Label()
        lblPackage = New Label()
        lblDescription = New Label()
        SuspendLayout()
        ' 
        ' btnDownload
        ' 
        btnDownload.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        btnDownload.Image = My.Resources.Resources.cloud_computing
        btnDownload.Location = New Point(850, 2)
        btnDownload.Margin = New Padding(2)
        btnDownload.Name = "btnDownload"
        btnDownload.Size = New Size(48, 41)
        btnDownload.TabIndex = 18
        btnDownload.UseVisualStyleBackColor = True
        ' 
        ' lblStars
        ' 
        lblStars.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblStars.BorderStyle = BorderStyle.FixedSingle
        lblStars.Location = New Point(746, 2)
        lblStars.Margin = New Padding(2)
        lblStars.Name = "lblStars"
        lblStars.Size = New Size(100, 41)
        lblStars.TabIndex = 17
        lblStars.Text = "STARS"
        lblStars.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblDownloads
        ' 
        lblDownloads.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblDownloads.BorderStyle = BorderStyle.FixedSingle
        lblDownloads.Location = New Point(642, 2)
        lblDownloads.Margin = New Padding(2)
        lblDownloads.Name = "lblDownloads"
        lblDownloads.Size = New Size(100, 41)
        lblDownloads.TabIndex = 15
        lblDownloads.Text = "DOWNLOADS"
        lblDownloads.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblPackage
        ' 
        lblPackage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left
        lblPackage.BorderStyle = BorderStyle.FixedSingle
        lblPackage.Location = New Point(2, 2)
        lblPackage.Margin = New Padding(2)
        lblPackage.Name = "lblPackage"
        lblPackage.Size = New Size(230, 41)
        lblPackage.TabIndex = 12
        lblPackage.Text = "PACKAGE"
        lblPackage.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblDescription
        ' 
        lblDescription.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblDescription.BorderStyle = BorderStyle.FixedSingle
        lblDescription.Location = New Point(236, 2)
        lblDescription.Margin = New Padding(2)
        lblDescription.Name = "lblDescription"
        lblDescription.Size = New Size(402, 41)
        lblDescription.TabIndex = 14
        lblDescription.Text = "DESCRIPTION"
        lblDescription.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' ItemPackage
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(btnDownload)
        Controls.Add(lblStars)
        Controls.Add(lblDownloads)
        Controls.Add(lblPackage)
        Controls.Add(lblDescription)
        Name = "ItemPackage"
        Size = New Size(900, 45)
        ResumeLayout(False)
    End Sub

    Friend WithEvents btnDownload As Button
    Friend WithEvents lblStars As Label
    Friend WithEvents lblDownloads As Label
    Friend WithEvents lblPackage As Label
    Friend WithEvents lblDescription As Label

End Class
