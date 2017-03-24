using System;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class ConfirmImportForm : Form
    {
        private int buttonClicked;
        public ConfirmImportForm(string[] replacementStrings, bool showExport)
        {
            InitializeComponent();
            importLabel.Text = importLabel.Text.Replace("[0]", replacementStrings[0]).Replace("[1]", replacementStrings[1]);

            if (showExport)
            {
                exportLabel.Text = exportLabel.Text.Replace("[1]", replacementStrings[1]);
            }
            else
            {
                exportLabel.Visible = false;
                exportButton.Visible = false;
            }
        }

        private void yesButton_Click(object sender, EventArgs e)
        {
            buttonClicked = 1;
            this.Close();
        }

        private void noButton_Click(object sender, EventArgs e)
        {
            buttonClicked = 2;
            this.Close();
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            buttonClicked = 3;
            this.Close();
        }

        public int GetButtonClicked()
        {
            return buttonClicked;
        }
    }
}
