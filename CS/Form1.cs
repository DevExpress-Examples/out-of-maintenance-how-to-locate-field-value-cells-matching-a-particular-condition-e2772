using System;
using System.Globalization;
using System.Windows.Forms;
using DevExpress.XtraPivotGrid;

namespace XtraPivotGrid_FindCells {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            pivotGridControl1.CustomFieldValueCells += 
                new PivotCustomFieldValueCellsEventHandler(pivotGrid_CustomFieldValueCells);
        }
        void Form1_Load(object sender, EventArgs e) {
            PivotHelper.FillPivot(pivotGridControl1);
            pivotGridControl1.DataSource = PivotHelper.GetDataTable();
            pivotGridControl1.BestFit();
        }

        // Handles the CustomFieldValueCells event to remove columns with
        // zero summary values.
        protected void pivotGrid_CustomFieldValueCells(object sender,
                             PivotCustomFieldValueCellsEventArgs e) {
            if (pivotGridControl1.DataSource == null) return;
            if (radioGroup1.SelectedIndex == 0) return;

            // Obtains the first encountered column header whose column
            // matches the specified condition, represented by a predicate.
            FieldValueCell cell = e.FindCell(true, new Predicate<object[]>(

                // Defines the predicate returning true for columns
                // that contain only zero summary values.
                delegate(object[] dataCellValues) {
                    foreach (object value in dataCellValues) {
                        if (!object.Equals((decimal)0, value))
                            return false;
                    }
                    return true;
            }));

            // If any column header matches the condition, this column is removed.
            if (cell != null) e.Remove(cell);
        }
        void pivotGridControl1_FieldValueDisplayText(object sender, 
                                        PivotFieldDisplayTextEventArgs e) {
            if(e.Field == pivotGridControl1.Fields[PivotHelper.Month]) {
                e.DisplayText = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName((int)e.Value);
            }
        }
        void radioGroup1_SelectedIndexChanged(object sender, EventArgs e) {
            this.pivotGridControl1.LayoutChanged();
            pivotGridControl1.BestFit();
        }        
    }
}