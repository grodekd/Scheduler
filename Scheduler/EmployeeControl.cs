using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class EmployeeControl : UserControl
    {
        public EmployeeControl(Employee employee, DataTable table)
        {
            InitializeComponent();
            this.label1.Text = employee.FirstName + " " + employee.LastName;
            this.dataGridView1.DataSource = table;
        }
    }
}
