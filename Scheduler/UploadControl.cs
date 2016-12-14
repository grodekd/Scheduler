﻿using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class UploadControl : UserControl
    {
        public UploadControl(IReadOnlyCollection<Child> failed)
        {
            InitializeComponent();
            string labelText;
            if (failed == null)
                labelText = "Nothing Uploaded";
            else
            {
                if (failed.Count > 0)
                {
                    labelText = failed.Aggregate("The following kids failed to upload:\r\n\r\n", (current, child) => current + (child.FirstName + " " + child.LastName + "\r\n"));
                    labelText += "\r\nIf these kids are new please add them manually first.";
                }
                else
                {
                    labelText = "Upload Was Successful.";
                }
            }

            this.textBox1.Text = labelText;
        }
    }
}
