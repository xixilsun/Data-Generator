Imports System.Data
Imports DevExpress.XtraGrid.Views.Grid

Public Class FrmCategoryDetail
    Private Sub FrmCategoryDetail_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        gcCategoryDetail.DataSource = BogusDatatable()
        'gvCategoryDetail.OptionsView.ColumnAutoWidth = False

        gvCategoryDetail.Columns("Tag").GroupIndex = 0
        gvCategoryDetail.Columns("Category").GroupIndex = 1
        gvCategoryDetail.Columns("Tag").SortOrder = DevExpress.Data.ColumnSortOrder.Descending
        gvCategoryDetail.ExpandAllGroups()
        gvCategoryDetail.BestFitColumns()
    End Sub
End Class