<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to locate field value cells matching a particular condition


<p>The following example demonstrates how to handle the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomFieldValueCellstopic">CustomFieldValueCells</a> event to locate a specific column/row header identified by its column's/row's summary values.<br> In this example, a predicate is used to locate a column that contains only zero summary values. The column header is obtained by the event parameter's <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotCustomFieldValueCellsEventArgsBase~T1~T2~_FindCelltopic">FindCell</a> method, and then removed via the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridDataPivotCustomFieldValueCellsEventArgsBase_Removetopic">Remove</a> method.</p>

<br/>


