using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Main : Form
    {
        private readonly EmployeeService employeeService;
        private readonly ChildService childService;
        public Main(EmployeeService employeeService, ChildService childService)
        {
            this.employeeService = employeeService;
            this.childService = childService;
            InitializeComponent();
            groupBox1.Controls.Add(new MainControl());
        }

        private void sdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new MainControl());
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //var table = new DataTable();
            //table.Columns.Add("First Name", typeof(string));
            //table.Columns.Add("Last Name", typeof(string));
            //table.Columns.Add("Max Hours", typeof(int));
            //table.Columns.Add("Rooms", typeof(string));
            //table.Rows.Add("Testy", "McTest", 40, "TT LL");

            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            //groupBox1.Controls.Add(new EmployeeControl(new Employee("1", "Testy", "McTest", 40, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, new List<string>()), table));
            groupBox1.Controls.Add(new EmployeeControl(employeeService.GetEmployee(), employeeService.GetEmployeeDataTable()));
        }

        private void childrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new ChildrenControl(childService.GetChildDataTable()));
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new RoomsControl());
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            var failed = childService.Import();
            groupBox1.Controls.Add(new UploadControl(failed));
        }
    }
}
