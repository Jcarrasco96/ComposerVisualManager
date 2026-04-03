<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ItemComposer
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
        btnDelete = New Button()
        lblPackage = New Label()
        lblInstalled = New Label()
        lblRequire = New Label()
        lblUpdated = New Label()
        lblLatest = New Label()
        lblLastUpdated = New Label()
        btnRefresh = New Button()
        Button1 = New Button()
        SuspendLayout()
        ' 
        ' btnDelete
        ' 
        btnDelete.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        btnDelete.Image = My.Resources.Resources.trash1
        btnDelete.Location = New Point(848, 2)
        btnDelete.Margin = New Padding(2)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(50, 50)
        btnDelete.TabIndex = 3
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' lblPackage
        ' 
        lblPackage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPackage.BorderStyle = BorderStyle.FixedSingle
        lblPackage.Location = New Point(2, 2)
        lblPackage.Margin = New Padding(2)
        lblPackage.Name = "lblPackage"
        lblPackage.Size = New Size(200, 50)
        lblPackage.TabIndex = 2
        lblPackage.Text = "PACKAGE"
        lblPackage.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblInstalled
        ' 
        lblInstalled.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblInstalled.BorderStyle = BorderStyle.FixedSingle
        lblInstalled.ImageAlign = ContentAlignment.MiddleLeft
        lblInstalled.Location = New Point(206, 2)
        lblInstalled.Margin = New Padding(2)
        lblInstalled.Name = "lblInstalled"
        lblInstalled.Size = New Size(90, 50)
        lblInstalled.TabIndex = 4
        lblInstalled.Text = "INSTALLED"
        lblInstalled.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblRequire
        ' 
        lblRequire.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblRequire.BorderStyle = BorderStyle.FixedSingle
        lblRequire.Location = New Point(394, 2)
        lblRequire.Margin = New Padding(2)
        lblRequire.Name = "lblRequire"
        lblRequire.Size = New Size(90, 50)
        lblRequire.TabIndex = 5
        lblRequire.Text = "REQUIRED"
        lblRequire.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblUpdated
        ' 
        lblUpdated.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblUpdated.BorderStyle = BorderStyle.FixedSingle
        lblUpdated.Location = New Point(488, 2)
        lblUpdated.Margin = New Padding(2)
        lblUpdated.Name = "lblUpdated"
        lblUpdated.Size = New Size(100, 50)
        lblUpdated.TabIndex = 7
        lblUpdated.Text = "UP-TO-DATE"
        lblUpdated.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLatest
        ' 
        lblLatest.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblLatest.BorderStyle = BorderStyle.FixedSingle
        lblLatest.ImageAlign = ContentAlignment.MiddleLeft
        lblLatest.Location = New Point(300, 2)
        lblLatest.Margin = New Padding(2)
        lblLatest.Name = "lblLatest"
        lblLatest.Size = New Size(90, 50)
        lblLatest.TabIndex = 8
        lblLatest.Text = "LATEST"
        lblLatest.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLastUpdated
        ' 
        lblLastUpdated.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblLastUpdated.BorderStyle = BorderStyle.FixedSingle
        lblLastUpdated.Location = New Point(592, 2)
        lblLastUpdated.Margin = New Padding(2)
        lblLastUpdated.Name = "lblLastUpdated"
        lblLastUpdated.Size = New Size(144, 50)
        lblLastUpdated.TabIndex = 9
        lblLastUpdated.Text = "LAST UPDATED"
        lblLastUpdated.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.repeat
        btnRefresh.Location = New Point(794, 2)
        btnRefresh.Margin = New Padding(2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(50, 50)
        btnRefresh.TabIndex = 2
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Button1.Image = My.Resources.Resources.cloud_computing
        Button1.Location = New Point(740, 2)
        Button1.Margin = New Padding(2)
        Button1.Name = "Button1"
        Button1.Size = New Size(50, 50)
        Button1.TabIndex = 1
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ItemComposer
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        Controls.Add(Button1)
        Controls.Add(btnRefresh)
        Controls.Add(lblLastUpdated)
        Controls.Add(lblLatest)
        Controls.Add(lblUpdated)
        Controls.Add(lblPackage)
        Controls.Add(btnDelete)
        Controls.Add(lblInstalled)
        Controls.Add(lblRequire)
        MinimumSize = New Size(900, 45)
        Name = "ItemComposer"
        Size = New Size(900, 54)
        ResumeLayout(False)
        'components = New System.ComponentModel.Container()
        'Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    End Sub

    Friend WithEvents btnDelete As Button
    Friend WithEvents lblPackage As Label
    Friend WithEvents lblInstalled As Label
    Friend WithEvents lblRequire As Label
    Friend WithEvents lblUpdated As Label
    Friend WithEvents lblLatest As Label
    Friend WithEvents lblLastUpdated As Label
    Friend WithEvents btnRefresh As Button
    Friend WithEvents Button1 As Button

End Class
