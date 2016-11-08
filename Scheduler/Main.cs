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
        public Main()
        {
            InitializeComponent();
            groupBox1.Controls.Add(new MainControl());
        }

        private void sdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new MainControl());
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new EmployeeControl());
        }

        private void childrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new ChildrenControl());
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserControl oldView = groupBox1.Controls[0] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new RoomsControl());
        }
    }
}
