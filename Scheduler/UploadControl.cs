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
    public partial class UploadControl : UserControl
    {
        public UploadControl(IReadOnlyCollection<Child> failed)
        {
            InitializeComponent();
            string labelText;

            if (failed.Count > 0)
            {
                labelText = failed.Aggregate("The following kids failed to upload:\r\n\r\n", (current, child) => current + (child.FirstName + " " + child.LastName + "\r\n"));
                labelText += "\r\nIf these kids are new please add them manually first.";
            }
            else
            {
                labelText = "Upload Was Successful.";
            }

            this.textBox1.Text = labelText;
        }
    }
}
