using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class ChildrenControl : UserControl, PersonControl
    {
        public Dictionary<string, DataTable> dataTables;
        private string selectedRoom = "LL";
        public ChildrenControl(Dictionary<string, DataTable> tables)
        {
            InitializeComponent();
            var nonEmpties = tables.Where(x => x.Value.Rows.Count != 0);

            if (!nonEmpties.Any())
            {
                dataGridView1.Visible = false;
                roomsBox.Visible = false;
                emptyLabel.Visible = true;
            }
            else
            {
                dataTables = tables;
                lambRadio_CheckedChanged(null, null);
            }
        }

        public string GetSelectedRoom()
        {
            return selectedRoom;
        }

        public List<String> GetSelected()
        {
            DataGridViewRow row;
            if (this.dataGridView1.SelectedRows.Count > 0) row = this.dataGridView1.SelectedRows[0];
            else if (this.dataGridView1.SelectedCells.Count > 0) row = this.dataGridView1.SelectedCells[0].OwningRow;
            else return null;

            return new List<String>
            {
                row.Cells[0].Value.ToString(),
                row.Cells[1].Value.ToString()
            };
        }

        private void DataGrid_MouseEnter(object sender, EventArgs e)
        {
            dataGridView1.Focus();
        }

        private void lambRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (sender == null && e == null)
            {
                this.dataGridView1.DataSource = dataTables["LL"];
                dataGridView1.Height = dataGridView1.ColumnHeadersHeight + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height-2);
                return;
            }
            if (!lambRadio.Checked) return;
            selectedRoom = "LL";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["LL"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void turtleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!turtleRadio.Checked) return;
            selectedRoom = "TT";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["TT"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void forest1Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest1Radio.Checked) return;
            selectedRoom = "BB1";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["BB1"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void forest2Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest2Radio.Checked) return;
            selectedRoom = "BB2";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["BB2"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void firefly1Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!firefly1Radio.Checked) return;
            selectedRoom = "FF1";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["FF1"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void firefly2Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!firefly2Radio.Checked) return;
            selectedRoom = "FF2";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["FF2"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void horizonsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!horizonsRadio.Checked) return;
            selectedRoom = "BH";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["BH"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void mindsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!mindsRadio.Checked) return;
            selectedRoom = "BM";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["BM"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void saRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!saRadio.Checked) return;
            selectedRoom = "SA";
            this.dataGridView1.Visible = false;
            this.dataGridView1.DataSource = dataTables["SA"];
            this.dataGridView1.Visible = true;
            dataGridView1.Height = 23 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }
    }
}
