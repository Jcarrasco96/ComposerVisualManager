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
        btnDelete.Location = New Point(971, 3)
        btnDelete.Margin = New Padding(2, 3, 2, 3)
        btnDelete.Name = "btnDelete"
        btnDelete.Size = New Size(55, 55)
        btnDelete.TabIndex = 2
        btnDelete.UseVisualStyleBackColor = True
        ' 
        ' lblPackage
        ' 
        lblPackage.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        lblPackage.BorderStyle = BorderStyle.FixedSingle
        lblPackage.Location = New Point(2, 3)
        lblPackage.Margin = New Padding(2, 3, 2, 3)
        lblPackage.Name = "lblPackage"
        lblPackage.Size = New Size(228, 54)
        lblPackage.TabIndex = 2
        lblPackage.Text = "PACKAGE"
        lblPackage.TextAlign = ContentAlignment.MiddleLeft
        ' 
        ' lblInstalled
        ' 
        lblInstalled.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblInstalled.BorderStyle = BorderStyle.FixedSingle
        lblInstalled.ImageAlign = ContentAlignment.MiddleLeft
        lblInstalled.Location = New Point(235, 3)
        lblInstalled.Margin = New Padding(2, 3, 2, 3)
        lblInstalled.Name = "lblInstalled"
        lblInstalled.Size = New Size(103, 54)
        lblInstalled.TabIndex = 4
        lblInstalled.Text = "INSTALLED"
        lblInstalled.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblRequire
        ' 
        lblRequire.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblRequire.BorderStyle = BorderStyle.FixedSingle
        lblRequire.Location = New Point(450, 3)
        lblRequire.Margin = New Padding(2, 3, 2, 3)
        lblRequire.Name = "lblRequire"
        lblRequire.Size = New Size(103, 54)
        lblRequire.TabIndex = 5
        lblRequire.Text = "DEV"
        lblRequire.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblUpdated
        ' 
        lblUpdated.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblUpdated.BorderStyle = BorderStyle.FixedSingle
        lblUpdated.Location = New Point(558, 3)
        lblUpdated.Margin = New Padding(2, 3, 2, 3)
        lblUpdated.Name = "lblUpdated"
        lblUpdated.Size = New Size(114, 54)
        lblUpdated.TabIndex = 7
        lblUpdated.Text = "UP-TO-DATE"
        lblUpdated.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLatest
        ' 
        lblLatest.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblLatest.BorderStyle = BorderStyle.FixedSingle
        lblLatest.ImageAlign = ContentAlignment.MiddleLeft
        lblLatest.Location = New Point(343, 3)
        lblLatest.Margin = New Padding(2, 3, 2, 3)
        lblLatest.Name = "lblLatest"
        lblLatest.Size = New Size(103, 54)
        lblLatest.TabIndex = 8
        lblLatest.Text = "LATEST"
        lblLatest.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' lblLastUpdated
        ' 
        lblLastUpdated.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        lblLastUpdated.BorderStyle = BorderStyle.FixedSingle
        lblLastUpdated.Location = New Point(677, 3)
        lblLastUpdated.Margin = New Padding(2, 3, 2, 3)
        lblLastUpdated.Name = "lblLastUpdated"
        lblLastUpdated.Size = New Size(171, 54)
        lblLastUpdated.TabIndex = 9
        lblLastUpdated.Text = "LAST UPDATED"
        lblLastUpdated.TextAlign = ContentAlignment.MiddleCenter
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.repeat
        btnRefresh.Location = New Point(912, 3)
        btnRefresh.Margin = New Padding(2, 3, 2, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(55, 55)
        btnRefresh.TabIndex = 10
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Right
        Button1.Image = My.Resources.Resources.cloud_computing
        Button1.Location = New Point(853, 3)
        Button1.Margin = New Padding(2, 3, 2, 3)
        Button1.Name = "Button1"
        Button1.Size = New Size(55, 55)
        Button1.TabIndex = 11
        Button1.UseVisualStyleBackColor = True
        ' 
        ' ItemComposer
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
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
        Margin = New Padding(3, 4, 3, 4)
        MinimumSize = New Size(1029, 60)
        Name = "ItemComposer"
        Size = New Size(1029, 60)
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
