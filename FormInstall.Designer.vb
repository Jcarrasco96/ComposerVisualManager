<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormInstall
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormInstall))
        btnSearch = New Button()
        txtSearch = New TextBox()
        panelItems = New Panel()
        SuspendLayout()
        ' 
        ' btnSearch
        ' 
        btnSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        btnSearch.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        btnSearch.Location = New Point(821, 11)
        btnSearch.Margin = New Padding(3, 2, 3, 2)
        btnSearch.Name = "btnSearch"
        btnSearch.Size = New Size(120, 50)
        btnSearch.TabIndex = 1
        btnSearch.Text = "Search"
        btnSearch.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.Font = New Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        txtSearch.Location = New Point(497, 26)
        txtSearch.Margin = New Padding(3, 2, 3, 2)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(318, 35)
        txtSearch.TabIndex = 2
        ' 
        ' panelItems
        ' 
        panelItems.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        panelItems.AutoScroll = True
        panelItems.BorderStyle = BorderStyle.FixedSingle
        panelItems.Location = New Point(10, 65)
        panelItems.Margin = New Padding(2)
        panelItems.Name = "panelItems"
        panelItems.Size = New Size(932, 565)
        panelItems.TabIndex = 4
        ' 
        ' FormInstall
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(953, 641)
        Controls.Add(panelItems)
        Controls.Add(txtSearch)
        Controls.Add(btnSearch)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Margin = New Padding(3, 2, 3, 2)
        MinimizeBox = False
        MinimumSize = New Size(969, 680)
        Name = "FormInstall"
        ShowInTaskbar = False
        StartPosition = FormStartPosition.CenterParent
        Text = "Composer Visual Manager - Install"
        ResumeLayout(False)
        PerformLayout()
    End Sub
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents panelItems As Panel
End Class
