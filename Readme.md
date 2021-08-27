<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128582275/10.2.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E2772)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
<!-- default file list end -->
# How to locate field value cells matching a particular condition


<p>The following example demonstrates how to handle the <a href="https://documentation.devexpress.com/#WindowsForms/DevExpressXtraPivotGridPivotGridControl_CustomFieldValueCellstopic">CustomFieldValueCells</a> event to locate a specific column/row header identified by its column's/row's summary values.<br> In this example, a predicate is used to locate a column that contains only zero summary values. The column header is obtained by the event parameter's <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridPivotCustomFieldValueCellsEventArgsBase~T1~T2~_FindCelltopic">FindCell</a> method, and then removed via the <a href="https://documentation.devexpress.com/#CoreLibraries/DevExpressXtraPivotGridDataPivotCustomFieldValueCellsEventArgsBase_Removetopic">Remove</a> method.</p>

<br/>


