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
                //Todo - Change to 4 and 2 for id in table
                this.dataGridView1.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                this.dataGridView1.Sort(this.dataGridView1.Columns[1], ListSortDirection.Ascending);
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
                //Todo - Change to 1 and 2 for id in table
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString()
            };
        }

        private void DataGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }
    }
}
