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
        panelItems.Location = New Point(10, 65)
        panelItems.Margin = New Padding(2)
        panelItems.Name = "panelItems"
        panelItems.Size = New Size(1103, 672)
        panelItems.TabIndex = 0
        ' 
        ' btnSearch
        ' 
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSearch.Image = My.Resources.Resources.add
        btnSearch.Location = New Point(1064, 11)
        btnSearch.Margin = New Padding(2)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(50, 50)
        btnSearch.TabIndex = 3
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' StatusStrip1
        ' 
        StatusStrip1.ImageScalingSize = New Size(20, 20)
        StatusStrip1.Items.AddRange(New ToolStripItem() {tssStatus})
        StatusStrip1.Location = New Point(0, 739)
        StatusStrip1.Name = "StatusStrip1"
        StatusStrip1.Padding = New Padding(1, 0, 12, 0)
        StatusStrip1.Size = New Size(1124, 22)
        StatusStrip1.TabIndex = 4
        StatusStrip1.Text = "StatusStrip1"
        ' 
        ' tssStatus
        ' 
        tssStatus.Name = "tssStatus"
        tssStatus.Size = New Size(99, 17)
        tssStatus.Text = "No path selected."
        ' 
        ' btnUpdateAll
        ' 
        btnUpdateAll.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnUpdateAll.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnUpdateAll.Location = New Point(886, 11)
        btnUpdateAll.Margin = New Padding(2)
        btnUpdateAll.Name = "btnUpdateAll"
        btnUpdateAll.Size = New Size(120, 50)
        btnUpdateAll.TabIndex = 5
        btnUpdateAll.Text = "Update all"
        btnUpdateAll.UseVisualStyleBackColor = True
        ' 
        ' btnRefresh
        ' 
        btnRefresh.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnRefresh.Image = My.Resources.Resources.repeat
        btnRefresh.Location = New Point(1010, 11)
        btnRefresh.Margin = New Padding(2)
        btnRefresh.Name = "btnRefresh"
        btnRefresh.Size = New Size(50, 50)
        btnRefresh.TabIndex = 6
        btnRefresh.UseVisualStyleBackColor = True
        ' 
        ' FormMain
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1124, 761)
        Controls.Add(btnRefresh)
        Controls.Add(btnUpdateAll)
        Controls.Add(StatusStrip1)
        Controls.Add(btnSearch)
        Controls.Add(panelItems)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        MinimumSize = New Size(1140, 800)
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
