Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmCategoryDetail
    Private Sub FrmCategoryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcCategoryDetail.DataSource = BogusDatatable()
        'gvCategoryDetail.OptionsView.ColumnAutoWidth = False

        gvCategoryDetail.Columns("Category").GroupIndex = 0

        gvCategoryDetail.ExpandAllGroups()
        gvCategoryDetail.BestFitColumns()
    End Sub
End Class