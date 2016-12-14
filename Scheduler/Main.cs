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
            newButton.Visible = false;
            editButton.Visible = false;
            updateButton.Visible = false;
            label1.Text = "Main";
        }

        private void sdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new MainControl());
            newButton.Visible = false;
            editButton.Visible = false;
            updateButton.Visible = false;
            label1.Text = "Main";
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
            newButton.Visible = true;
            editButton.Visible = true;
            updateButton.Visible = true;
            label1.Text = "Employees";
        }

        private void childrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new ChildrenControl(childService.GetChildDataTable()));
            newButton.Visible = true;
            editButton.Visible = true;
            updateButton.Visible = true;
            label1.Text = "Children";
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new RoomsControl());
            newButton.Visible = true;
            editButton.Visible = true;
            updateButton.Visible = false;
            label1.Text = "Rooms";
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            var failed = childService.Import();
            groupBox1.Controls.Add(new UploadControl(failed));
            newButton.Visible = false;
            editButton.Visible = false;
            updateButton.Visible = false;
            label1.Text = "Upload";
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new AddNewControl(label1.Text, null));
            newButton.Visible = false;
            editButton.Visible = false;
            updateButton.Visible = false;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            Person person = null;
            if (label1.Text == "Children") person = childService.GetChildren()[0];
            else if (label1.Text == "Employees") person = employeeService.GetEmployee();

            var oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new AddNewControl(label1.Text, person));
            newButton.Visible = false;
            editButton.Visible = false;
            updateButton.Visible = false;
        }
    }
}
