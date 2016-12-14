using System.Globalization;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class AddNewControl : UserControl
    {
        public AddNewControl(string caller, Person someone)
        {
            InitializeComponent();
            switch (caller)
            {
                case "Employees":
                    groupBox1.Text = "Rooms (Select All That Apply)";
                    littleLambRadio.Visible = false;
                    tinyTurtlesRadio.Visible = false;
                    forest1Radio.Visible = false;
                    forest2Radio.Visible = false;
                    fireflies1Radio.Visible = false;
                    fireflies2Radio.Visible = false;
                    horizonsRadio.Visible = false;
                    mindsRadio.Visible = false;
                    schoolAgeRadio.Visible = false;

                    if (someone != null)
                    {
                        var employee = (Employee)someone;

                        firstNameBox.Text = employee.FirstName;
                        maxHoursBox.Text = employee.MaxHours.ToString(CultureInfo.InvariantCulture);
                    }
                    
                    break;
                case "Children":
                    maxHoursBox.Visible = false;
                    maxHoursLabel.Visible = false;
                    groupBox1.Text = "Room";
                    littleLambCheck.Visible = false;
                    tinyTurtlesCheck.Visible = false;
                    forest1Check.Visible = false;
                    forest2Check.Visible = false;
                    fireflies1Check.Visible = false;
                    fireflies2Check.Visible = false;
                    horizonsCheck.Visible = false;
                    mindsCheck.Visible = false;
                    schoolAgeCheck.Visible = false;

                    if (someone != null)
                    {
                        var child = (Child)someone;

                        firstNameBox.Text = child.FirstName;
                    }
                    break;
                default:
                    littleLambRadio.Visible = false;
                    tinyTurtlesRadio.Visible = false;
                    forest1Radio.Visible = false;
                    forest2Radio.Visible = false;
                    fireflies1Radio.Visible = false;
                    fireflies2Radio.Visible = false;
                    horizonsRadio.Visible = false;
                    mindsRadio.Visible = false;
                    schoolAgeRadio.Visible = false;
                    littleLambCheck.Visible = false;
                    tinyTurtlesCheck.Visible = false;
                    forest1Check.Visible = false;
                    forest2Check.Visible = false;
                    fireflies1Check.Visible = false;
                    fireflies2Check.Visible = false;
                    horizonsCheck.Visible = false;
                    mindsCheck.Visible = false;
                    schoolAgeCheck.Visible = false;
                    break;
            }
            monStartMin.SelectedIndex = 0;
            monStartAm.SelectedIndex = 0;
            monEndMin.SelectedIndex = 0;
            monEndAm.SelectedIndex = 0;

            tuesStartMin.SelectedIndex = 0;
            tuesStartAm.SelectedIndex = 0;
            tuesEndMin.SelectedIndex = 0;
            tuesEndAm.SelectedIndex = 0;

            wedStartMin.SelectedIndex = 0;
            wedStartAm.SelectedIndex = 0;
            wedEndMin.SelectedIndex = 0;
            wedEndAm.SelectedIndex = 0;

            thurStartMin.SelectedIndex = 0;
            thurStartAm.SelectedIndex = 0;
            thurEndMin.SelectedIndex = 0;
            thurEndAm.SelectedIndex = 0;

            friStartMin.SelectedIndex = 0;
            friStartAm.SelectedIndex = 0;
            friEndMin.SelectedIndex = 0;
            friEndAm.SelectedIndex = 0;
        }

        private void littleLambRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
            schoolCombo.DataSource = null;
        }

        private void tinyTurtlesRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
            schoolCombo.DataSource = null;
        }

        private void forest1Radio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
        }

        private void forest2Radio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
            schoolCombo.DataSource = null;
        }

        private void fireflies1Radio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
            schoolCombo.DataSource = null;
        }

        private void fireflies2Radio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = false;
            schoolCombo.DataSource = null;
        }

        private void horizonsRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = true;
            schoolCombo.DataSource = new[] { "Yes", "No" };
        }

        private void mindsRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = true;
            schoolCombo.DataSource = new[] { "AM", "PM", "No" };
        }

        private void schoolAgeRadio_CheckedChanged(object sender, System.EventArgs e)
        {
            schoolCombo.Enabled = true;
            schoolCombo.DataSource = new[] { "Yes", "No" };
        }
    }
}
