using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class EmployeeControl : UserControl, PersonControl
    {
        public EmployeeControl(DataTable table)
        {
            InitializeComponent();

            if (table.Rows.Count == 0)
            {
                this.dataGridView1.Visible = false;
                this.emptyLabel.Visible = true;
            }
            else
            {
                this.dataGridView1.DataSource = table;
                //Todo - Change back to 3 and 1 when done with id in table
                this.dataGridView1.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Sort(this.dataGridView1.Columns[2], ListSortDirection.Ascending);
            }
        }

        public List<String> GetSelected()
        {
            DataGridViewRow row;
            if (this.dataGridView1.SelectedRows.Count > 0) row = this.dataGridView1.SelectedRows[0];
            else if (this.dataGridView1.SelectedCells.Count > 0) row = this.dataGridView1.SelectedCells[0].OwningRow;
            else return null;

            return new List<String>
            {
                //Todo - Change back to 0 and 1 when done with id in table
                row.Cells[1].Value.ToString(),
                row.Cells[2].Value.ToString()
            };
        }

        private void DataGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
