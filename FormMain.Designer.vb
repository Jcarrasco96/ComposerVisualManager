<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormMain))
        panelItems = New Panel()
        btnSearch = New Button()
        StatusStrip1 = New StatusStrip()
        tssStatus = New ToolStripStatusLabel()
        btnUpdateAll = New Button()
        btnRefresh = New Button()
        StatusStrip1.SuspendLayout()
        SuspendLayout()
        ' 
        ' panelItems
        ' 
        panelItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        panelItems.AutoScroll = True
        panelItems.BorderStyle = BorderStyle.FixedSingle
        panelItems.Location = New Point(11, 73)
        panelItems.Margin = New Padding(2, 3, 2, 3)
        panelItems.Name = "panelItems"
        panelItems.Size = New Size(1260, 535)
        panelItems.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSearch.Image = My.Resources.Resources.add
        btnSearch.Location = New Point(1216, 12)
        btnSearch.Margin = New Padding(2, 3, 2, 3)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(55, 55)
        btnSearch.TabIndex = 3
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(20, 20)
        StatusStrip1.Items.AddRange(New ToolStripItem() {tssStatus})
        StatusStrip1.Location = New Point(0, 607)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Size = New Size(1282, 26)
        StatusStrip1.TabIndex = 4
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' tssStatus
        ' 
        tssStatus.Name = "tssStatus"
        tssStatus.Size = New Size(125, 20)
        tssStatus.Text = "No path selected."
        ' 
        ' btnUpdateAll
        ' 
        btnUpdateAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUpdateAll.Location = New Point(982, 12)
        btnUpdateAll.Margin = New Padding(2, 3, 2, 3)
        btnUpdateAll.Name = "btnUpdateAll"
        btnUpdateAll.Size = New Size(171, 55)
        btnUpdateAll.TabIndex = 5
        btnUpdateAll.Text = "Update all"
        btnUpdateAll.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.repeat
        btnRefresh.Location = New Point(1157, 12)
        btnRefresh.Margin = New Padding(2, 3, 2, 3)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(55, 55)
        btnRefresh.TabIndex = 6
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' FormMain
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1282, 633)
        Controls.Add(btnRefresh)
        Controls.Add(btnUpdateAll)
        Controls.Add(StatusStrip1)
        Controls.Add(btnSearch)
        Controls.Add(panelItems)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 4, 3, 4)
        MinimumSize = New Size(1300, 680)
        Name = "FormMain"
        StartPosition = FormStartPosition.CenterScreen
        Text = "Composer Visual Manager"
        StatusStrip1.ResumeLayout(False)
        StatusStrip1.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents panelItems As Panel
    Friend WithEvents btnSearch As Button
    Friend WithEvents StatusStrip1 As StatusStrip
    Friend WithEvents tssStatus As ToolStripStatusLabel
    Friend WithEvents btnUpdateAll As Button
    Friend WithEvents btnRefresh As Button

End Class
