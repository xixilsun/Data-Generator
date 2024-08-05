<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmCategoryDetail
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
        Me.gcCategoryDetail = New DevExpress.XtraGrid.GridControl()
        Me.gvCategoryDetail = New DevExpress.XtraGrid.Views.Grid.GridView()
        CType(Me.gcCategoryDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.gvCategoryDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'gcCategoryDetail
        '
        Me.gcCategoryDetail.Dock = System.Windows.Forms.DockStyle.Fill
        Me.gcCategoryDetail.Location = New System.Drawing.Point(0, 0)
        Me.gcCategoryDetail.MainView = Me.gvCategoryDetail
        Me.gcCategoryDetail.Name = "gcCategoryDetail"
        Me.gcCategoryDetail.Size = New System.Drawing.Size(800, 450)
        Me.gcCategoryDetail.TabIndex = 0
        Me.gcCategoryDetail.ViewCollection.AddRange(New DevExpress.XtraGrid.Views.Base.BaseView() {Me.gvCategoryDetail})
        '
        'gvCategoryDetail
        '
        Me.gvCategoryDetail.GridControl = Me.gcCategoryDetail
        Me.gvCategoryDetail.Name = "gvCategoryDetail"
        Me.gvCategoryDetail.OptionsFind.AlwaysVisible = True
        Me.gvCategoryDetail.OptionsFind.ClearFindOnClose = False
        '
        'FrmCategoryDetail
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(800, 450)
        Me.Controls.Add(Me.gcCategoryDetail)
        Me.Name = "FrmCategoryDetail"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "FrmCategoryDetail"
        CType(Me.gcCategoryDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.gvCategoryDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents gcCategoryDetail As DevExpress.XtraGrid.GridControl
    Friend WithEvents gvCategoryDetail As DevExpress.XtraGrid.Views.Grid.GridView
End Class
