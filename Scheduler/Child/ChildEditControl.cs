using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class ChildEditControl : UserControl
    {
        public readonly string childId;
        public readonly ChildrenControl parentControl;
        public ChildEditControl(Child child, string selectedRoom, ChildrenControl parentControl)
        {
            InitializeComponent();
            this.parentControl = parentControl;
            if (child != null)
            {
                childId = child.id;
                firstNameBox.Text = child.FirstName;
                lastNameBox.Text = child.LastName;

                switch (child.RoomLabel)
                {
                    case "LL":
                        littleLambRadio.Checked = true;
                        break;
                    case "TT":
                        tinyTurtlesRadio.Checked = true;
                        break;
                    case "BB1":
                        forest1Radio.Checked = true;
                        break;
                    case "BB2":
                        forest2Radio.Checked = true;
                        break;
                    case "FF1":
                        fireflies1Radio.Checked = true;
                        break;
                    case "FF2":
                        fireflies2Radio.Checked = true;
                        break;
                    case "BH":
                        horizonsRadio.Checked = true;
                        schoolCombo.SelectedIndex = child.GetSchool() == "Yes" ? 0 : 1;
                        break;
                    case "BM":
                        mindsRadio.Checked = true;
                        switch (child.GetSchool())
                        {
                            case "AM":
                                schoolCombo.SelectedIndex = 0;
                                break;
                            case "PM":
                                schoolCombo.SelectedIndex = 1;
                                break;
                            default:
                                schoolCombo.SelectedIndex = 2;
                                break;
                        }
                        break;
                    case "SA":
                        schoolAgeRadio.Checked = true;
                        schoolCombo.SelectedIndex = child.GetSchool() == "Yes" ? 0 : 1;
                        break;
                }
                if (child.MonStart.Hours != 0)
                {
                    monCheckBox.Checked = true;
                    if (child.MonStart.Hours > 12)
                    {
                        monStartHour.Text = (child.MonStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        monStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        monStartHour.Text = child.MonStart.Hours.ToString(CultureInfo.InvariantCulture);
                        monStartAm.SelectedIndex = child.MonStart.Hours == 12 ? 1 : 0;
                    }

                    switch (child.MonStart.Minutes)
                    {
                        case 15:
                            monStartMin.SelectedIndex = 1;
                            break;
                        case 30:
                            monStartMin.SelectedIndex = 2;
                            break;
                        case 45:
                            monStartMin.SelectedIndex = 3;
                            break;
                        default:
                            monStartMin.SelectedIndex = 0;
                            break;
                    }

                    if (child.MonEnd.Hours > 12)
                    {
                        monEndHour.Text = (child.MonEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        monEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        monEndHour.Text = child.MonEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        monEndAm.SelectedIndex = child.MonEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (child.MonEnd.Minutes)
                    {
                        case 15:
                            monEndMin.SelectedIndex = 1;
                            break;
                        case 30:
                            monEndMin.SelectedIndex = 2;
                            break;
                        case 45:
                            monEndMin.SelectedIndex = 3;
                            break;
                        default:
                            monEndMin.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    monCheckBox.Checked = false;
                    monCheckBox_CheckedChanged(null, null);
                }

                if (child.TuesStart.Hours != 0)
                {
                    tuesCheckBox.Checked = true;
                    if (child.TuesStart.Hours > 12)
                    {
                        tuesStartHour.Text = (child.TuesStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        tuesStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        tuesStartHour.Text = child.TuesStart.Hours.ToString(CultureInfo.InvariantCulture);
                        tuesStartAm.SelectedIndex = child.TuesStart.Hours == 12 ? 1 : 0;
                    }

                    switch (child.TuesStart.Minutes)
                    {
                        case 15:
                            tuesStartMin.SelectedIndex = 1;
                            break;
                        case 30:
                            tuesStartMin.SelectedIndex = 2;
                            break;
                        case 45:
                            tuesStartMin.SelectedIndex = 3;
                            break;
                        default:
                            tuesStartMin.SelectedIndex = 0;
                            break;
                    }

                    if (child.TuesEnd.Hours > 12)
                    {
                        tuesEndHour.Text = (child.TuesEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        tuesEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        tuesEndHour.Text = child.TuesEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        tuesEndAm.SelectedIndex = child.TuesEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (child.TuesEnd.Minutes)
                    {
                        case 15:
                            tuesEndMin.SelectedIndex = 1;
                            break;
                        case 30:
                            tuesEndMin.SelectedIndex = 2;
                            break;
                        case 45:
                            tuesEndMin.SelectedIndex = 3;
                            break;
                        default:
                            tuesEndMin.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    tuesCheckBox.Checked = false;
                    tuesCheckBox_CheckedChanged(null, null);
                }

                if (child.WedStart.Hours != 0)
                {
                    wedCheckBox.Checked = true;
                    if (child.WedStart.Hours > 12)
                    {
                        wedStartHour.Text = (child.WedStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        wedStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        wedStartHour.Text = child.WedStart.Hours.ToString(CultureInfo.InvariantCulture);
                        wedStartAm.SelectedIndex = child.WedStart.Hours == 12 ? 1 : 0;
                    }

                    switch (child.WedStart.Minutes)
                    {
                        case 15:
                            wedStartMin.SelectedIndex = 1;
                            break;
                        case 30:
                            wedStartMin.SelectedIndex = 2;
                            break;
                        case 45:
                            wedStartMin.SelectedIndex = 3;
                            break;
                        default:
                            wedStartMin.SelectedIndex = 0;
                            break;
                    }

                    if (child.WedEnd.Hours > 12)
                    {
                        wedEndHour.Text = (child.WedEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        wedEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        wedEndHour.Text = child.WedEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        wedEndAm.SelectedIndex = child.WedEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (child.WedEnd.Minutes)
                    {
                        case 15:
                            wedEndMin.SelectedIndex = 1;
                            break;
                        case 30:
                            wedEndMin.SelectedIndex = 2;
                            break;
                        case 45:
                            wedEndMin.SelectedIndex = 3;
                            break;
                        default:
                            wedEndMin.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    wedCheckBox.Checked = false;
                    wedCheckBox_CheckedChanged(null, null);
                }

                if (child.ThurStart.Hours != 0)
                {
                    thurCheckBox.Checked = true;
                    if (child.ThurStart.Hours > 12)
                    {
                        thurStartHour.Text = (child.ThurStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        thurStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        thurStartHour.Text = child.ThurStart.Hours.ToString(CultureInfo.InvariantCulture);
                        thurStartAm.SelectedIndex = child.ThurStart.Hours == 12 ? 1 : 0;
                    }

                    switch (child.ThurStart.Minutes)
                    {
                        case 15:
                            thurStartMin.SelectedIndex = 1;
                            break;
                        case 30:
                            thurStartMin.SelectedIndex = 2;
                            break;
                        case 45:
                            thurStartMin.SelectedIndex = 3;
                            break;
                        default:
                            thurStartMin.SelectedIndex = 0;
                            break;
                    }

                    if (child.ThurEnd.Hours > 12)
                    {
                        thurEndHour.Text = (child.ThurEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        thurEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        thurEndHour.Text = child.ThurEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        thurEndAm.SelectedIndex = child.ThurEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (child.ThurEnd.Minutes)
                    {
                        case 15:
                            thurEndMin.SelectedIndex = 1;
                            break;
                        case 30:
                            thurEndMin.SelectedIndex = 2;
                            break;
                        case 45:
                            thurEndMin.SelectedIndex = 3;
                            break;
                        default:
                            thurEndMin.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    thurCheckBox.Checked = false;
                    thurCheckBox_CheckedChanged(null, null);
                }

                if(child.FriStart.Hours != 0)
                {
                    friCheckBox.Checked = true;
                    if (child.FriStart.Hours > 12)
                    {
                        friStartHour.Text = (child.FriStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        friStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        friStartHour.Text = child.FriStart.Hours.ToString(CultureInfo.InvariantCulture);
                        friStartAm.SelectedIndex = child.FriStart.Hours == 12 ? 1 : 0;
                    }

                    switch (child.FriStart.Minutes)
                    {
                        case 15:
                            friStartMin.SelectedIndex = 1;
                            break;
                        case 30:
                            friStartMin.SelectedIndex = 2;
                            break;
                        case 45:
                            friStartMin.SelectedIndex = 3;
                            break;
                        default:
                            friStartMin.SelectedIndex = 0;
                            break;
                    }

                    if (child.FriEnd.Hours > 12)
                    {
                        friEndHour.Text = (child.FriEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        friEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        friEndHour.Text = child.FriEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        friEndAm.SelectedIndex = child.FriEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (child.FriEnd.Minutes)
                    {
                        case 15:
                            friEndMin.SelectedIndex = 1;
                            break;
                        case 30:
                            friEndMin.SelectedIndex = 2;
                            break;
                        case 45:
                            friEndMin.SelectedIndex = 3;
                            break;
                        default:
                            friEndMin.SelectedIndex = 0;
                            break;
                    }
                }
                else
                {
                    friCheckBox.Checked = false;
                    friCheckBox_CheckedChanged(null, null);
                }
            }
            else
            {
                childId = "-1";
                monStartMin.SelectedIndex = 0;
                monStartAm.SelectedIndex = 0;
                monEndMin.SelectedIndex = 0;
                monEndAm.SelectedIndex = 0;
                monCheckBox_CheckedChanged(null, null);

                tuesStartMin.SelectedIndex = 0;
                tuesStartAm.SelectedIndex = 0;
                tuesEndMin.SelectedIndex = 0;
                tuesEndAm.SelectedIndex = 0;
                tuesCheckBox_CheckedChanged(null, null);

                wedStartMin.SelectedIndex = 0;
                wedStartAm.SelectedIndex = 0;
                wedEndMin.SelectedIndex = 0;
                wedEndAm.SelectedIndex = 0;
                wedCheckBox_CheckedChanged(null, null);

                thurStartMin.SelectedIndex = 0;
                thurStartAm.SelectedIndex = 0;
                thurEndMin.SelectedIndex = 0;
                thurEndAm.SelectedIndex = 0;
                thurCheckBox_CheckedChanged(null, null);

                friStartMin.SelectedIndex = 0;
                friStartAm.SelectedIndex = 0;
                friEndMin.SelectedIndex = 0;
                friEndAm.SelectedIndex = 0;
                friCheckBox_CheckedChanged(null, null);

                switch (selectedRoom)
                {
                    case "LL":
                        littleLambRadio.Checked = true;
                        break;
                    case "TT":
                        tinyTurtlesRadio.Checked = true;
                        break;
                    case "BB1":
                        forest1Radio.Checked = true;
                        break;
                    case "BB2":
                        forest2Radio.Checked = true;
                        break;
                    case "FF1":
                        fireflies1Radio.Checked = true;
                        break;
                    case "FF2":
                        fireflies2Radio.Checked = true;
                        break;
                    case "BH":
                        horizonsRadio.Checked = true;
                        break;
                    case "BM":
                        mindsRadio.Checked = true;
                        break;
                    case "SA":
                        schoolAgeRadio.Checked = true;
                        break;
                }
            }

            monStartHour.KeyPress += hour_KeyPress;
            monEndHour.KeyPress += hour_KeyPress;
            tuesStartHour.KeyPress += hour_KeyPress;
            tuesEndHour.KeyPress += hour_KeyPress;
            wedStartHour.KeyPress += hour_KeyPress;
            wedEndHour.KeyPress += hour_KeyPress;
            thurStartHour.KeyPress += hour_KeyPress;
            thurEndHour.KeyPress += hour_KeyPress;
            friStartHour.KeyPress += hour_KeyPress;
            friEndHour.KeyPress += hour_KeyPress;
        }

        private void hour_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
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
            schoolCombo.DataSource = null;
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

        public Child GetChildFromData()
        {
            if (monCheckBox.Checked && (monStartHour.Text == "" || Convert.ToInt32(monStartHour.Text) > 12))
            {
                MessageBox.Show("Monday's start hour is not a valid hour.", "Invalid Entry");
                monStartHour.Text = "";
                return null;
            }
            if (monCheckBox.Checked && (monEndHour.Text == "" || Convert.ToInt32(monEndHour.Text) > 12))
            {
                MessageBox.Show("Monday's end hour is not a valid hour.", "Invalid Entry");
                monEndHour.Text = "";
                return null;
            }
            var monday = new List<TimeSpan>
            {
                Time.GetTimeSpan(monStartHour.Text ?? "0", monStartMin.Text ?? "0", monStartAm.SelectedIndex == 1),
                Time.GetTimeSpan(monEndHour.Text ?? "0", monEndMin.Text ?? "0", monEndAm.SelectedIndex == 1)
            };

            if (tuesCheckBox.Checked && (tuesStartHour.Text == "" || Convert.ToInt32(tuesStartHour.Text) > 12))
            {
                MessageBox.Show("Tuesday's start hour is not a valid hour.", "Invalid Entry");
                tuesStartHour.Text = "";
                return null;
            }
            if (tuesCheckBox.Checked && (tuesEndHour.Text == "" || Convert.ToInt32(tuesEndHour.Text) > 12))
            {
                MessageBox.Show("Tuesday's end hour is not a valid hour.", "Invalid Entry");
                tuesEndHour.Text = "";
                return null;
            }
            var tuesday = new List<TimeSpan>
            {
                Time.GetTimeSpan(tuesStartHour.Text ?? "0", tuesStartMin.Text ?? "0", tuesStartAm.SelectedIndex == 1),
                Time.GetTimeSpan(tuesEndHour.Text ?? "0", tuesEndMin.Text ?? "0", tuesEndAm.SelectedIndex == 1)
            };

            if (wedCheckBox.Checked && (wedStartHour.Text == "" || Convert.ToInt32(wedStartHour.Text) > 12))
            {
                MessageBox.Show("Wednesday's start hour is not a valid hour.", "Invalid Entry");
                wedStartHour.Text = "";
                return null;
            }
            if (wedCheckBox.Checked && (wedEndHour.Text == "" || Convert.ToInt32(wedEndHour.Text) > 12))
            {
                MessageBox.Show("Wednesday's end hour is not a valid hour.", "Invalid Entry");
                wedEndHour.Text = "";
                return null;
            }
            var wednesday = new List<TimeSpan>
            {
                Time.GetTimeSpan(wedStartHour.Text ?? "0", wedStartMin.Text ?? "0", wedStartAm.SelectedIndex == 1),
                Time.GetTimeSpan(wedEndHour.Text ?? "0", wedEndMin.Text ?? "0", wedEndAm.SelectedIndex == 1)
            };

            if (thurCheckBox.Checked && (thurStartHour.Text == "" || Convert.ToInt32(thurStartHour.Text) > 12))
            {
                MessageBox.Show("Thursday's start hour is not a valid hour.", "Invalid Entry");
                thurStartHour.Text = "";
                return null;
            }
            if (thurCheckBox.Checked && (thurEndHour.Text == "" || Convert.ToInt32(thurEndHour.Text) > 12))
            {
                MessageBox.Show("Thursday's end hour is not a valid hour.", "Invalid Entry");
                thurEndHour.Text = "";
                return null;
            }
            var thursday = new List<TimeSpan>
            {
                Time.GetTimeSpan(thurStartHour.Text ?? "0", thurStartMin.Text ?? "0", thurStartAm.SelectedIndex == 1),
                Time.GetTimeSpan(thurEndHour.Text ?? "0", thurEndMin.Text ?? "0", thurEndAm.SelectedIndex == 1)
            };

            if (friCheckBox.Checked && (friStartHour.Text == "" || Convert.ToInt32(friStartHour.Text) > 12))
            {
                MessageBox.Show("Friday's start hour is not a valid hour.", "Invalid Entry");
                friStartHour.Text = "";
                return null;
            }
            if (friCheckBox.Checked && (friEndHour.Text == "" || Convert.ToInt32(friEndHour.Text) > 12))
            {
                MessageBox.Show("Friday's end hour is not a valid hour.", "Invalid Entry");
                friEndHour.Text = "";
                return null;
            }
            var friday = new List<TimeSpan>
            {
                Time.GetTimeSpan(friStartHour.Text ?? "0", friStartMin.Text ?? "0", friStartAm.SelectedIndex == 1),
                Time.GetTimeSpan(friEndHour.Text ?? "0", friEndMin.Text ?? "0", friEndAm.SelectedIndex == 1)
            };

            if (firstNameBox.Text == "")
            {
                MessageBox.Show("First name can't be empty.", "Invalid Entry");
                return null;
            }
            if (lastNameBox.Text == "")
            {
                MessageBox.Show("Last name can't be empty.", "Invalid Entry");
                return null;
            }

            int type;
            return new Child("-1", firstNameBox.Text, lastNameBox.Text, GetRoom(), monday, tuesday, wednesday, thursday, friday, GetSchool(out type), type);
        }

        private string GetRoom()
        {
            if (littleLambRadio.Checked) return "LL";
            if (tinyTurtlesRadio.Checked) return "TT";
            if (forest1Radio.Checked) return "BB1";
            if (forest2Radio.Checked) return "BB2";
            if (fireflies1Radio.Checked) return "FF1";
            if (fireflies2Radio.Checked) return "FF2";
            if (horizonsRadio.Checked) return "BH";
            return mindsRadio.Checked ? "BM" : "SA";
        }

        private List<bool> GetSchool(out int type)
        {
            type = 0;
            if (horizonsRadio.Checked && schoolCombo.SelectedIndex == 0) return new List<bool>{false, true, false, true, false};
            if (mindsRadio.Checked)
            {
                switch (schoolCombo.SelectedIndex)
                {
                    case 0:
                        type = 2;
                        return new List<bool>{true, false, true, false, true};
                    case 1:
                        type = 1;
                        return new List<bool> { true, true, true, true, true };
                    default:
                        return new List<bool> { false, false, false, false, false };
                }
            }
            if (schoolAgeRadio.Checked && schoolCombo.SelectedIndex == 0) return new List<bool> { true, true, true, true, true };

            return new List<bool> { false, false, false, false, false };
        }

        private void monCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!monCheckBox.Checked)
            {
                monStartHour.Text = "";
                monStartHour.Enabled = false;
                monStartMin.Enabled = false;
                monStartAm.Enabled = false;
                monEndHour.Text = "";
                monEndHour.Enabled = false;
                monEndMin.Enabled = false;
                monEndAm.Enabled = false;
                monStartMin.SelectedIndex = 0;
                monStartAm.SelectedIndex = 0;
                monEndMin.SelectedIndex = 0;
                monEndAm.SelectedIndex = 0;
            }
            else
            {
                monStartHour.Enabled = true;
                monStartMin.Enabled = true;
                monStartAm.Enabled = true;
                monEndHour.Enabled = true;
                monEndMin.Enabled = true;
                monEndAm.Enabled = true;
            }
        }

        private void tuesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!tuesCheckBox.Checked)
            {
                tuesStartHour.Text = "";
                tuesStartHour.Enabled = false;
                tuesStartMin.Enabled = false;
                tuesStartAm.Enabled = false;
                tuesEndHour.Text = "";
                tuesEndHour.Enabled = false;
                tuesEndMin.Enabled = false;
                tuesEndAm.Enabled = false;
                tuesStartMin.SelectedIndex = 0;
                tuesStartAm.SelectedIndex = 0;
                tuesEndMin.SelectedIndex = 0;
                tuesEndAm.SelectedIndex = 0;
            }
            else
            {
                tuesStartHour.Enabled = true;
                tuesStartMin.Enabled = true;
                tuesStartAm.Enabled = true;
                tuesEndHour.Enabled = true;
                tuesEndMin.Enabled = true;
                tuesEndAm.Enabled = true;
            }
        }

        private void wedCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!wedCheckBox.Checked)
            {
                wedStartHour.Text = "";
                wedStartHour.Enabled = false;
                wedStartMin.Enabled = false;
                wedStartAm.Enabled = false;
                wedEndHour.Text = "";
                wedEndHour.Enabled = false;
                wedEndMin.Enabled = false;
                wedEndAm.Enabled = false;
                wedStartMin.SelectedIndex = 0;
                wedStartAm.SelectedIndex = 0;
                wedEndMin.SelectedIndex = 0;
                wedEndAm.SelectedIndex = 0;
            }
            else
            {
                wedStartHour.Enabled = true;
                wedStartMin.Enabled = true;
                wedStartAm.Enabled = true;
                wedEndHour.Enabled = true;
                wedEndMin.Enabled = true;
                wedEndAm.Enabled = true;
            }
        }

        private void thurCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!thurCheckBox.Checked)
            {
                thurStartHour.Text = "";
                thurStartHour.Enabled = false;
                thurStartMin.Enabled = false;
                thurStartAm.Enabled = false;
                thurEndHour.Text = "";
                thurEndHour.Enabled = false;
                thurEndMin.Enabled = false;
                thurEndAm.Enabled = false;
                thurStartMin.SelectedIndex = 0;
                thurStartAm.SelectedIndex = 0;
                thurEndMin.SelectedIndex = 0;
                thurEndAm.SelectedIndex = 0;
            }
            else
            {
                thurStartHour.Enabled = true;
                thurStartMin.Enabled = true;
                thurStartAm.Enabled = true;
                thurEndHour.Enabled = true;
                thurEndMin.Enabled = true;
                thurEndAm.Enabled = true;
            }
        }

        private void friCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (!friCheckBox.Checked)
            {
                friStartHour.Text = "";
                friStartHour.Enabled = false;
                friStartMin.Enabled = false;
                friStartAm.Enabled = false;
                friEndHour.Text = "";
                friEndHour.Enabled = false;
                friEndMin.Enabled = false;
                friEndAm.Enabled = false;
                friStartMin.SelectedIndex = 0;
                friStartAm.SelectedIndex = 0;
                friEndMin.SelectedIndex = 0;
                friEndAm.SelectedIndex = 0;
            }
            else
            {
                friStartHour.Enabled = true;
                friStartMin.Enabled = true;
                friStartAm.Enabled = true;
                friEndHour.Enabled = true;
                friEndMin.Enabled = true;
                friEndAm.Enabled = true;
            }
        }
    }
}
