Imports System
Imports System.Globalization
Imports System.Windows.Forms
Imports DevExpress.XtraPivotGrid

Namespace XtraPivotGrid_FindCells
    Partial Public Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            AddHandler pivotGridControl1.CustomFieldValueCells, AddressOf pivotGrid_CustomFieldValueCells
        End Sub
        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
            PivotHelper.FillPivot(pivotGridControl1)
            pivotGridControl1.DataSource = PivotHelper.GetDataTable()
            pivotGridControl1.BestFit()
        End Sub

        ' Handles the CustomFieldValueCells event to remove columns with
        ' zero summary values.
        Protected Sub pivotGrid_CustomFieldValueCells(ByVal sender As Object, 
                            ByVal e As PivotCustomFieldValueCellsEventArgs)
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            If pivot.DataSource Is Nothing Then
                Return
            End If
            If radioGroup1.SelectedIndex = 0 Then
                Return
            End If

            ' Obtains the first encountered column header whose column
            ' matches the specified condition, represented by a predicate.
            Dim cell As FieldValueCell = e.FindCell(True,
                            New Predicate(Of Object())(Function(dataCellValues() As Object)
                ' Defines the predicate returning true for columns
                ' that contain only zero summary values.
                For Each value As Object In dataCellValues
                    If Not Object.Equals(CDec(0), value) Then
                        Return False
                    End If
                Next value
                Return True
            End Function))

            ' If any column header matches the condition, this column is removed.
            If cell IsNot Nothing Then
                e.Remove(cell)
            End If
        End Sub
        Private Sub pivotGridControl1_FieldValueDisplayText(ByVal sender As Object,
                       ByVal e As PivotFieldDisplayTextEventArgs) Handles pivotGridControl1.FieldValueDisplayText
            Dim pivot As PivotGridControl = TryCast(sender, PivotGridControl)
            If e.Field Is pivot.Fields(PivotHelper.Month) Then
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(CInt((e.Value)))
            End If
        End Sub
        Private Sub radioGroup1_SelectedIndexChanged(ByVal sender As Object,
                            ByVal e As EventArgs) Handles radioGroup1.SelectedIndexChanged
            Me.pivotGridControl1.LayoutChanged()
        End Sub
    End Class
End Namespace