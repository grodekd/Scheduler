using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class WeeklySchedulesForm : Form
    {
        private readonly Dictionary<string, string> lambShifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> turtleShifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> bee1Shifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> bee2Shifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> fly1Shifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> fly2Shifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> horShifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> mindShifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        private readonly Dictionary<string, string> saShifts = new Dictionary<string, string>() { { "monday", string.Empty }, { "tuesday", string.Empty }, { "wednesday", string.Empty }, { "thursday", string.Empty }, { "friday", string.Empty } };
        public WeeklySchedulesForm(Dictionary<string, Dictionary<string, List<Shift>>> employeeShifts)
        {
            InitializeComponent();

            employeeShifts["LL"]["monday"].ForEach(x => lambShifts["monday"] += StyleShiftTime(x));
            employeeShifts["LL"]["tuesday"].ForEach(x => lambShifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["LL"]["wednesday"].ForEach(x => lambShifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["LL"]["thursday"].ForEach(x => lambShifts["thursday"] += StyleShiftTime(x));
            employeeShifts["LL"]["friday"].ForEach(x => lambShifts["friday"] += StyleShiftTime(x));

            employeeShifts["TT"]["monday"].ForEach(x => turtleShifts["monday"] += StyleShiftTime(x));
            employeeShifts["TT"]["tuesday"].ForEach(x => turtleShifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["TT"]["wednesday"].ForEach(x => turtleShifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["TT"]["thursday"].ForEach(x => turtleShifts["thursday"] += StyleShiftTime(x));
            employeeShifts["TT"]["friday"].ForEach(x => turtleShifts["friday"] += StyleShiftTime(x));

            employeeShifts["BB1"]["monday"].ForEach(x => bee1Shifts["monday"] += StyleShiftTime(x));
            employeeShifts["BB1"]["tuesday"].ForEach(x => bee1Shifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["BB1"]["wednesday"].ForEach(x => bee1Shifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["BB1"]["thursday"].ForEach(x => bee1Shifts["thursday"] += StyleShiftTime(x));
            employeeShifts["BB1"]["friday"].ForEach(x => bee1Shifts["friday"] += StyleShiftTime(x));

            employeeShifts["BB2"]["monday"].ForEach(x => bee2Shifts["monday"] += StyleShiftTime(x));
            employeeShifts["BB2"]["tuesday"].ForEach(x => bee2Shifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["BB2"]["wednesday"].ForEach(x => bee2Shifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["BB2"]["thursday"].ForEach(x => bee2Shifts["thursday"] += StyleShiftTime(x));
            employeeShifts["BB2"]["friday"].ForEach(x => bee2Shifts["friday"] += StyleShiftTime(x));

            employeeShifts["FF1"]["monday"].ForEach(x => fly1Shifts["monday"] += StyleShiftTime(x));
            employeeShifts["FF1"]["tuesday"].ForEach(x => fly1Shifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["FF1"]["wednesday"].ForEach(x => fly1Shifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["FF1"]["thursday"].ForEach(x => fly1Shifts["thursday"] += StyleShiftTime(x));
            employeeShifts["FF1"]["friday"].ForEach(x => fly1Shifts["friday"] += StyleShiftTime(x));

            employeeShifts["FF2"]["monday"].ForEach(x => fly2Shifts["monday"] += StyleShiftTime(x));
            employeeShifts["FF2"]["tuesday"].ForEach(x => fly2Shifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["FF2"]["wednesday"].ForEach(x => fly2Shifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["FF2"]["thursday"].ForEach(x => fly2Shifts["thursday"] += StyleShiftTime(x));
            employeeShifts["FF2"]["friday"].ForEach(x => fly2Shifts["friday"] += StyleShiftTime(x));

            employeeShifts["BH"]["monday"].ForEach(x => horShifts["monday"] += StyleShiftTime(x));
            employeeShifts["BH"]["tuesday"].ForEach(x => horShifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["BH"]["wednesday"].ForEach(x => horShifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["BH"]["thursday"].ForEach(x => horShifts["thursday"] += StyleShiftTime(x));
            employeeShifts["BH"]["friday"].ForEach(x => horShifts["friday"] += StyleShiftTime(x));

            employeeShifts["BM"]["monday"].ForEach(x => mindShifts["monday"] += StyleShiftTime(x));
            employeeShifts["BM"]["tuesday"].ForEach(x => mindShifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["BM"]["wednesday"].ForEach(x => mindShifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["BM"]["thursday"].ForEach(x => mindShifts["thursday"] += StyleShiftTime(x));
            employeeShifts["BM"]["friday"].ForEach(x => mindShifts["friday"] += StyleShiftTime(x));

            employeeShifts["SA"]["monday"].ForEach(x => saShifts["monday"] += StyleShiftTime(x));
            employeeShifts["SA"]["tuesday"].ForEach(x => saShifts["tuesday"] += StyleShiftTime(x));
            employeeShifts["SA"]["wednesday"].ForEach(x => saShifts["wednesday"] += StyleShiftTime(x));
            employeeShifts["SA"]["thursday"].ForEach(x => saShifts["thursday"] += StyleShiftTime(x));
            employeeShifts["SA"]["friday"].ForEach(x => saShifts["friday"] += StyleShiftTime(x));

            lambRadio_CheckedChanged(null, null);
        }

        private void lambRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!lambRadio.Checked) return;

            mondayTextBox.Text = lambShifts["monday"];
            tuesdayTextBox.Text = lambShifts["tuesday"];
            wednesdayTextBox.Text = lambShifts["wednesday"];
            thursdayTextBox.Text = lambShifts["thursday"];
            fridayTextBox.Text = lambShifts["friday"];
        }

        private void turtleRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!turtleRadio.Checked) return;

            mondayTextBox.Text = turtleShifts["monday"];
            tuesdayTextBox.Text = turtleShifts["tuesday"];
            wednesdayTextBox.Text = turtleShifts["wednesday"];
            thursdayTextBox.Text = turtleShifts["thursday"];
            fridayTextBox.Text = turtleShifts["friday"];
        }

        private void forest1Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest1Radio.Checked) return;

            mondayTextBox.Text = bee1Shifts["monday"];
            tuesdayTextBox.Text = bee1Shifts["tuesday"];
            wednesdayTextBox.Text = bee1Shifts["wednesday"];
            thursdayTextBox.Text = bee1Shifts["thursday"];
            fridayTextBox.Text = bee1Shifts["friday"];
        }

        private void forest2Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!forest2Radio.Checked) return;

            mondayTextBox.Text = bee2Shifts["monday"];
            tuesdayTextBox.Text = bee2Shifts["tuesday"];
            wednesdayTextBox.Text = bee2Shifts["wednesday"];
            thursdayTextBox.Text = bee2Shifts["thursday"];
            fridayTextBox.Text = bee2Shifts["friday"];
        }

        private void firefly1Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!firefly1Radio.Checked) return;

            mondayTextBox.Text = fly1Shifts["monday"];
            tuesdayTextBox.Text = fly1Shifts["tuesday"];
            wednesdayTextBox.Text = fly1Shifts["wednesday"];
            thursdayTextBox.Text = fly1Shifts["thursday"];
            fridayTextBox.Text = fly1Shifts["friday"];
        }

        private void firefly2Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (!firefly2Radio.Checked) return;

            mondayTextBox.Text = fly2Shifts["monday"];
            tuesdayTextBox.Text = fly2Shifts["tuesday"];
            wednesdayTextBox.Text = fly2Shifts["wednesday"];
            thursdayTextBox.Text = fly2Shifts["thursday"];
            fridayTextBox.Text = fly2Shifts["friday"];
        }

        private void horizonsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!horizonsRadio.Checked) return;

            mondayTextBox.Text = horShifts["monday"];
            tuesdayTextBox.Text = horShifts["tuesday"];
            wednesdayTextBox.Text = horShifts["wednesday"];
            thursdayTextBox.Text = horShifts["thursday"];
            fridayTextBox.Text = horShifts["friday"];
        }

        private void mindsRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!mindsRadio.Checked) return;

            mondayTextBox.Text = mindShifts["monday"];
            tuesdayTextBox.Text = mindShifts["tuesday"];
            wednesdayTextBox.Text = mindShifts["wednesday"];
            thursdayTextBox.Text = mindShifts["thursday"];
            fridayTextBox.Text = mindShifts["friday"];
        }

        private void saRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (!saRadio.Checked) return;

            mondayTextBox.Text = saShifts["monday"];
            tuesdayTextBox.Text = saShifts["tuesday"];
            wednesdayTextBox.Text = saShifts["wednesday"];
            thursdayTextBox.Text = saShifts["thursday"];
            fridayTextBox.Text = saShifts["friday"];
        }

        private string StyleShiftTime(Shift shift)
        {
            return string.Format("{0}: {1}\r\n\r\n", shift.EmployeeName, Time.GetTimeString(shift.StartTime, shift.EndTime));
        }
    }
}
