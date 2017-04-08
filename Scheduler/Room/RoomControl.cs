using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class RoomControl : UserControl
    {
        public RoomControl(DataTable table)
        {
            InitializeComponent();
            this.dataGridView1.DataSource = table;

            dataGridView1.Height = 5 + dataGridView1.Rows.Cast<DataGridViewRow>().Sum(row => row.Height);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public string GetSelected()
        {
            DataGridViewRow row;
            if (this.dataGridView1.SelectedRows.Count > 0) row = this.dataGridView1.SelectedRows[0];
            else if (this.dataGridView1.SelectedCells.Count > 0) row = this.dataGridView1.SelectedCells[0].OwningRow;
            else return null;

            return row.Cells[2].Value.ToString();
        }
    }
}
