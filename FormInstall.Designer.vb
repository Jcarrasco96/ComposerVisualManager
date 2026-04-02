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
        gridPackages = New DataGridView()
        Button1 = New Button()
        txtSearch = New TextBox()
        Button2 = New Button()
        CType(gridPackages, ComponentModel.ISupportInitialize).BeginInit()
        SuspendLayout()
        ' 
        ' gridPackages
        ' 
        gridPackages.AllowUserToAddRows = False
        gridPackages.AllowUserToDeleteRows = False
        gridPackages.Anchor = AnchorStyles.Top Or AnchorStyles.Bottom Or AnchorStyles.Left Or AnchorStyles.Right
        gridPackages.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        gridPackages.Location = New Point(12, 47)
        gridPackages.Name = "gridPackages"
        gridPackages.ReadOnly = True
        gridPackages.RowHeadersWidth = 51
        gridPackages.Size = New Size(958, 394)
        gridPackages.TabIndex = 0
        ' 
        ' Button1
        ' 
        Button1.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button1.Location = New Point(776, 12)
        Button1.Name = "Button1"
        Button1.Size = New Size(94, 29)
        Button1.TabIndex = 1
        Button1.Text = "Search"
        Button1.UseVisualStyleBackColor = True
        ' 
        ' txtSearch
        ' 
        txtSearch.Anchor = AnchorStyles.Top Or AnchorStyles.Left Or AnchorStyles.Right
        txtSearch.Location = New Point(12, 12)
        txtSearch.Name = "txtSearch"
        txtSearch.Size = New Size(758, 27)
        txtSearch.TabIndex = 2
        ' 
        ' Button2
        ' 
        Button2.Anchor = AnchorStyles.Top Or AnchorStyles.Right
        Button2.Location = New Point(876, 12)
        Button2.Name = "Button2"
        Button2.Size = New Size(94, 29)
        Button2.TabIndex = 3
        Button2.Text = "Install"
        Button2.UseVisualStyleBackColor = True
        ' 
        ' FormInstall
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(982, 453)
        Controls.Add(Button2)
        Controls.Add(txtSearch)
        Controls.Add(Button1)
        Controls.Add(gridPackages)
        Icon = CType(resources.GetObject("$this.Icon"), Icon)
        Name = "FormInstall"
        StartPosition = FormStartPosition.CenterParent
        Text = "FormInstall"
        CType(gridPackages, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents gridPackages As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents txtSearch As TextBox
    Friend WithEvents Button2 As Button
End Class
