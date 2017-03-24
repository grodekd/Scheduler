using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class EmployeeEditControl : UserControl
    {
        private readonly int employeeId;
        public EmployeeEditControl(Employee employee, int newId)
        {
            InitializeComponent();

            littleLambPriority.KeyPress += numberEntry_KeyPress;
            tinyTurtlesPriority.KeyPress += numberEntry_KeyPress;
            forest1Priority.KeyPress += numberEntry_KeyPress;
            forest2Priority.KeyPress += numberEntry_KeyPress;
            fireflies1Priority.KeyPress += numberEntry_KeyPress;
            fireflies2Priority.KeyPress += numberEntry_KeyPress;
            horizonsPriority.KeyPress += numberEntry_KeyPress;
            mindsPriority.KeyPress += numberEntry_KeyPress;
            schoolAgePriority.KeyPress += numberEntry_KeyPress;

            if (employee != null)
            {
                employeeId = employee.Id;
                firstNameBox.Text = employee.FirstName;
                lastNameBox.Text = employee.LastName;
                maxHoursBox.Text = employee.MaxHours.ToString(CultureInfo.InvariantCulture);

                if (employee.HasRoom("LL"))
                {
                    littleLambCheck.Checked = true;
                    littleLambPriority.Enabled = true;
                    littleLambPriority.Text = employee.GetRoomPriority("LL").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("TT"))
                {
                    tinyTurtlesCheck.Checked = true;
                    tinyTurtlesPriority.Enabled = true;
                    tinyTurtlesPriority.Text = employee.GetRoomPriority("TT").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("BB1"))
                {
                    forest1Check.Checked = true;
                    forest1Priority.Enabled = true;
                    forest1Priority.Text = employee.GetRoomPriority("BB1").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("BB2"))
                {
                    forest2Check.Checked = true;
                    forest2Priority.Enabled = true;
                    forest2Priority.Text = employee.GetRoomPriority("BB2").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("FF1"))
                {
                    fireflies1Check.Checked = true;
                    fireflies1Priority.Enabled = true;
                    fireflies1Priority.Text = employee.GetRoomPriority("FF1").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("FF2"))
                {
                    fireflies2Check.Checked = true;
                    fireflies2Priority.Enabled = true;
                    fireflies2Priority.Text = employee.GetRoomPriority("FF2").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("BH"))
                {
                    horizonsCheck.Checked = true;
                    horizonsPriority.Enabled = true;
                    horizonsPriority.Text = employee.GetRoomPriority("BH").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("BM"))
                {
                    mindsCheck.Checked = true;
                    mindsPriority.Enabled = true;
                    mindsPriority.Text = employee.GetRoomPriority("BM").ToString(CultureInfo.InvariantCulture);
                }
                if (employee.HasRoom("SA"))
                {
                    schoolAgeCheck.Checked = true;
                    schoolAgePriority.Enabled = true;
                    schoolAgePriority.Text = employee.GetRoomPriority("SA").ToString(CultureInfo.InvariantCulture);
                }

                if (employee.MonStart.Hours != 0)
                {
                    monCheckBox.Checked = true;
                    if (employee.MonStart.Hours > 12)
                    {
                        monStartHour.Text = (employee.MonStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        monStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        monStartHour.Text = employee.MonStart.Hours.ToString(CultureInfo.InvariantCulture);
                        monStartAm.SelectedIndex = employee.MonStart.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.MonStart.Minutes)
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

                    if (employee.MonEnd.Hours > 12)
                    {
                        monEndHour.Text = (employee.MonEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        monEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        monEndHour.Text = employee.MonEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        monEndAm.SelectedIndex = employee.MonEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.MonEnd.Minutes)
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

                if (employee.TuesStart.Hours != 0)
                {
                    tuesCheckBox.Checked = true;
                    if (employee.TuesStart.Hours > 12)
                    {
                        tuesStartHour.Text = (employee.TuesStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        tuesStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        tuesStartHour.Text = employee.TuesStart.Hours.ToString(CultureInfo.InvariantCulture);
                        tuesStartAm.SelectedIndex = employee.TuesStart.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.TuesStart.Minutes)
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

                    if (employee.TuesEnd.Hours > 12)
                    {
                        tuesEndHour.Text = (employee.TuesEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        tuesEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        tuesEndHour.Text = employee.TuesEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        tuesEndAm.SelectedIndex = employee.TuesEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.TuesEnd.Minutes)
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

                if (employee.WedStart.Hours != 0)
                {
                    wedCheckBox.Checked = true;
                    if (employee.WedStart.Hours > 12)
                    {
                        wedStartHour.Text = (employee.WedStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        wedStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        wedStartHour.Text = employee.WedStart.Hours.ToString(CultureInfo.InvariantCulture);
                        wedStartAm.SelectedIndex = employee.WedStart.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.WedStart.Minutes)
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

                    if (employee.WedEnd.Hours > 12)
                    {
                        wedEndHour.Text = (employee.WedEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        wedEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        wedEndHour.Text = employee.WedEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        wedEndAm.SelectedIndex = employee.WedEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.WedEnd.Minutes)
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

                if (employee.ThurStart.Hours != 0)
                {
                    thurCheckBox.Checked = true;
                    if (employee.ThurStart.Hours > 12)
                    {
                        thurStartHour.Text = (employee.ThurStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        thurStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        thurStartHour.Text = employee.ThurStart.Hours.ToString(CultureInfo.InvariantCulture);
                        thurStartAm.SelectedIndex = employee.ThurStart.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.ThurStart.Minutes)
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

                    if (employee.ThurEnd.Hours > 12)
                    {
                        thurEndHour.Text = (employee.ThurEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        thurEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        thurEndHour.Text = employee.ThurEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        thurEndAm.SelectedIndex = employee.ThurEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.ThurEnd.Minutes)
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

                if (employee.FriStart.Hours != 0)
                {
                    friCheckBox.Checked = true;
                    if (employee.FriStart.Hours > 12)
                    {
                        friStartHour.Text = (employee.FriStart.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        friStartAm.SelectedIndex = 1;
                    }
                    else
                    {
                        friStartHour.Text = employee.FriStart.Hours.ToString(CultureInfo.InvariantCulture);
                        friStartAm.SelectedIndex = employee.FriStart.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.FriStart.Minutes)
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

                    if (employee.FriEnd.Hours > 12)
                    {
                        friEndHour.Text = (employee.FriEnd.Hours - 12).ToString(CultureInfo.InvariantCulture);
                        friEndAm.SelectedIndex = 1;
                    }
                    else
                    {
                        friEndHour.Text = employee.FriEnd.Hours.ToString(CultureInfo.InvariantCulture);
                        friEndAm.SelectedIndex = employee.FriEnd.Hours == 12 ? 1 : 0;
                    }

                    switch (employee.FriEnd.Minutes)
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
                employeeId = newId;
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


                littleLambPriority.Enabled = false;
                tinyTurtlesPriority.Enabled = false;
                forest1Priority.Enabled = false;
                forest2Priority.Enabled = false;
                fireflies1Priority.Enabled = false;
                fireflies2Priority.Enabled = false;
                horizonsPriority.Enabled = false;
                mindsPriority.Enabled = false;
                schoolAgePriority.Enabled = false;
            }
            monStartHour.KeyPress += numberEntry_KeyPress;
            monEndHour.KeyPress += numberEntry_KeyPress;

            tuesStartHour.KeyPress += numberEntry_KeyPress;
            tuesEndHour.KeyPress += numberEntry_KeyPress;

            wedStartHour.KeyPress += numberEntry_KeyPress;
            wedEndHour.KeyPress += numberEntry_KeyPress;

            thurEndHour.KeyPress += numberEntry_KeyPress;
            thurStartHour.KeyPress += numberEntry_KeyPress;

            friStartHour.KeyPress += numberEntry_KeyPress;
            friEndHour.KeyPress += numberEntry_KeyPress;

            maxHoursBox.KeyPress += numberEntry_KeyPress;
        }

        private void numberEntry_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || e.KeyChar == 8);
        }

        public Employee GetEmployeeFromData()
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
            if (Convert.ToDouble(maxHoursBox.Text) > 40.0)
            {
                MessageBox.Show("Max Hours can't be more than 40.", "Invalid Entry");
                return null;
            }

            var rooms = GetRooms();
            return rooms == null ? null : new Employee(employeeId, firstNameBox.Text, lastNameBox.Text, Convert.ToDouble(maxHoursBox.Text), monday, tuesday, wednesday, thursday, friday, rooms);
        }

        private Dictionary<string, int> GetRooms()
        {
            var rooms = new Dictionary<string, int>();

            if (!CheckRoomPriorityValidity()) return null;

            var priorityValueList = GetRoomPriorityNumberList();

            if (priorityValueList.Distinct().Count() != priorityValueList.Count)
            {
                MessageBox.Show("Each room priority number must be unique.", "Invalid Entry");
                return null;
            }

            if (priorityValueList.Any(val => Convert.ToInt32(val) > priorityValueList.Count))
            {
                MessageBox.Show("Please use sequential numbers for the room priority values.", "Invalid Entry");
                return null;
            }
            
            if (littleLambCheck.Checked) rooms.Add("LL", Convert.ToInt32(littleLambPriority.Text));
            if (tinyTurtlesCheck.Checked) rooms.Add("TT", Convert.ToInt32(tinyTurtlesPriority.Text));
            if (forest1Check.Checked) rooms.Add("BB1", Convert.ToInt32(forest1Priority.Text));
            if (forest2Check.Checked) rooms.Add("BB2", Convert.ToInt32(forest2Priority.Text));
            if (fireflies1Check.Checked) rooms.Add("FF1", Convert.ToInt32(fireflies1Priority.Text));
            if (fireflies2Check.Checked) rooms.Add("FF2", Convert.ToInt32(fireflies2Priority.Text));
            if (horizonsCheck.Checked) rooms.Add("BH", Convert.ToInt32(horizonsPriority.Text));
            if (mindsCheck.Checked) rooms.Add("BM", Convert.ToInt32(mindsPriority.Text));
            if (schoolAgeCheck.Checked) rooms.Add("SA", Convert.ToInt32(schoolAgePriority.Text));

            return rooms;
        }

        private bool CheckRoomPriorityValidity()
        {
            if (littleLambPriority.Enabled && (littleLambPriority.Text == "" || Convert.ToInt32(littleLambPriority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(littleLambPriority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Little Lambs room is invalid.", "Invalid Entry");
                littleLambPriority.Text = "";
                return false;
            }

            if (tinyTurtlesPriority.Enabled && (tinyTurtlesPriority.Text == "" || Convert.ToInt32(tinyTurtlesPriority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(tinyTurtlesPriority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Tiny Turtles room is invalid.", "Invalid Entry");
                tinyTurtlesPriority.Text = "";
                return false;
            }

            if (forest1Priority.Enabled && (forest1Priority.Text == "" || Convert.ToInt32(forest1Priority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(forest1Priority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Bumblebee Forest 1 room is invalid.", "Invalid Entry");
                forest1Priority.Text = "";
                return false;
            }

            if (forest2Priority.Enabled && (forest2Priority.Text == "" || Convert.ToInt32(forest2Priority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(forest2Priority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Bumblebee Forest 2 room is invalid.", "Invalid Entry");
                forest2Priority.Text = "";
                return false;
            }

            if (fireflies1Priority.Enabled && (fireflies1Priority.Text == "" || Convert.ToInt32(fireflies1Priority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(fireflies1Priority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Fireflies 1 room is invalid.", "Invalid Entry");
                fireflies1Priority.Text = "";
                return false;
            }

            if (fireflies2Priority.Enabled && (fireflies2Priority.Text == "" || Convert.ToInt32(fireflies2Priority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(fireflies2Priority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Fireflies 2 room is invalid.", "Invalid Entry");
                fireflies2Priority.Text = "";
                return false;
            }

            if (horizonsPriority.Enabled && (horizonsPriority.Text == "" || Convert.ToInt32(horizonsPriority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(horizonsPriority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Bright Horizons room is invalid.", "Invalid Entry");
                horizonsPriority.Text = "";
                return false;
            }

            if (mindsPriority.Enabled && (mindsPriority.Text == "" || Convert.ToInt32(mindsPriority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(mindsPriority.Text) < 1))
            {
                MessageBox.Show("Priority number for the Bright Minds room is invalid.", "Invalid Entry");
                mindsPriority.Text = "";
                return false;
            }

            if (schoolAgePriority.Enabled && (schoolAgePriority.Text == "" || Convert.ToInt32(schoolAgePriority.Text) > 9 //TODO change to total room count from room service
                    || Convert.ToInt32(schoolAgePriority.Text) < 1))
            {
                MessageBox.Show("Priority number for the School Age room is invalid.", "Invalid Entry");
                schoolAgePriority.Text = "";
                return false;
            }

            return true;
        }

        private List<string> GetRoomPriorityNumberList()
        {
            var priorityList = new List<string>();

            if(littleLambPriority.Enabled) priorityList.Add(littleLambPriority.Text);
            if(tinyTurtlesPriority.Enabled) priorityList.Add(tinyTurtlesPriority.Text);
            if(forest1Priority.Enabled) priorityList.Add(forest1Priority.Text);
            if(forest2Priority.Enabled) priorityList.Add(forest2Priority.Text);
            if(fireflies1Priority.Enabled) priorityList.Add(fireflies1Priority.Text);
            if(fireflies2Priority.Enabled) priorityList.Add(fireflies2Priority.Text);
            if(horizonsPriority.Enabled) priorityList.Add(horizonsPriority.Text);
            if(mindsPriority.Enabled) priorityList.Add(mindsPriority.Text);
            if(schoolAgePriority.Enabled) priorityList.Add(schoolAgePriority.Text);

            return priorityList;
        }

        private void littleLambCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!littleLambCheck.Checked)
            {
                littleLambPriority.Text = "";
                littleLambPriority.Enabled = false;
            }
            else littleLambPriority.Enabled = true;
        }

        private void tinyTurtlesCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!tinyTurtlesCheck.Checked)
            {
                tinyTurtlesPriority.Text = "";
                tinyTurtlesPriority.Enabled = false;
            }
            else tinyTurtlesPriority.Enabled = true;
        }

        private void forest1Check_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest1Check.Checked)
            {
                forest1Priority.Text = "";
                forest1Priority.Enabled = false;
            }
            else forest1Priority.Enabled = true;
        }

        private void forest2Check_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest2Check.Checked)
            {
                forest2Priority.Text = "";
                forest2Priority.Enabled = false;
            }
            else forest2Priority.Enabled = true;
        }

        private void fireflies1Check_CheckedChanged(object sender, EventArgs e)
        {
            if (!fireflies1Check.Checked)
            {
                fireflies1Priority.Text = "";
                fireflies1Priority.Enabled = false;
            }
            else fireflies1Priority.Enabled = true;
        }

        private void fireflies2Check_CheckedChanged(object sender, EventArgs e)
        {
            if (!fireflies2Check.Checked)
            {
                fireflies2Priority.Text = "";
                fireflies2Priority.Enabled = false;
            }
            else fireflies2Priority.Enabled = true;
        }

        private void horizonsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!horizonsCheck.Checked)
            {
                horizonsPriority.Text = "";
                horizonsPriority.Enabled = false;
            }
            else horizonsPriority.Enabled = true;
        }

        private void mindsCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!mindsCheck.Checked)
            {
                mindsPriority.Text = "";
                mindsPriority.Enabled = false;
            }
            else mindsPriority.Enabled = true;
        }

        private void schoolAgeCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (!schoolAgeCheck.Checked)
            {
                schoolAgePriority.Text = "";
                schoolAgePriority.Enabled = false;
            }
            else schoolAgePriority.Enabled = true;
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
