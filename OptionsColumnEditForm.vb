Imports DevExpress.XtraGrid.Views.Grid
Imports System.Windows.Forms

Public Class OptionsColumnEditForm
    Inherits DevExpress.XtraEditors.XtraForm

    Public Property ParentTable As String
    Public Property ParentID As String
    Public Property Rules As String

    Private parentTableTextEdit As New DevExpress.XtraEditors.TextEdit()
    Private parentIDTextEdit As New DevExpress.XtraEditors.TextEdit()
    Private rulesTextEdit As New DevExpress.XtraEditors.TextEdit()
    Private okButton As New DevExpress.XtraEditors.SimpleButton()
    Private cancelButton As New DevExpress.XtraEditors.SimpleButton()

    Public Sub New(view As GridView, rowHandle As Integer)
        ' Initialize form controls
        Me.Text = "Edit Options"

        ' Initialize properties from the GridView values
        Me.ParentTable = view.GetRowCellValue(rowHandle, "ParentTable").ToString()
        Me.ParentID = view.GetRowCellValue(rowHandle, "ParentID").ToString()
        Me.Rules = view.GetRowCellValue(rowHandle, "Rules").ToString()

        ' Layout controls
        Dim layout As New DevExpress.XtraLayout.LayoutControl()
        layout.Dock = DockStyle.Fill

        ' Parent Table
        parentTableTextEdit.Text = Me.ParentTable
        layout.AddItem("Parent Table:", parentTableTextEdit)

        ' Parent ID
        parentIDTextEdit.Text = Me.ParentID
        layout.AddItem("Parent ID:", parentIDTextEdit)

        ' Rules
        rulesTextEdit.Text = Me.Rules
        layout.AddItem("Rules:", rulesTextEdit)

        ' Buttons
        okButton.Text = "OK"
        AddHandler okButton.Click, AddressOf OkButton_Click
        layout.AddItem("", okButton)

        cancelButton.Text = "Cancel"
        AddHandler cancelButton.Click, AddressOf CancelButton_Click
        layout.AddItem("", cancelButton)

        Me.Controls.Add(layout)
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs)
        ' Save the values and close the form
        Me.ParentTable = parentTableTextEdit.Text
        Me.ParentID = parentIDTextEdit.Text
        Me.Rules = rulesTextEdit.Text
        Me.DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs)
        ' Close the form without saving
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
End Class