using System;
using System.Linq;
using System.Windows.Forms;

namespace Scheduler
{
    public partial class Main : Form
    {
        private readonly EmployeeService employeeService;
        private readonly ChildService childService;
        private readonly RoomService roomService;
        private readonly ScheduleService scheduleService;
        private ViewType currentView;

        private bool employeesEdited;
        private string lastEmployeesUploadedPath;
        public Main(EmployeeService employeeService, ChildService childServ, RoomService roomService, ScheduleService scheduleService)
        {
            this.employeeService = employeeService;
            childService = childServ;
            this.roomService = roomService;
            this.scheduleService = scheduleService;
            InitializeComponent();
            groupBox1.Controls.Add(new MainControl(childService.GetChildData(), employeeService.GetEmployeeData(), roomService.GetRoomsLookup()));
            newButton.Visible = false;
            editButton.Visible = false;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            scheduleButton.Visible = true;
            currentView = ViewType.Main;
            titleLabel.Text = "Home";
            this.FormClosing += MainFormClosing;
        }

        private void sdgToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[1] as UserControl;
            groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new MainControl(childService.GetChildData(), employeeService.GetEmployeeData(), roomService.GetRoomsLookup()));
            newButton.Visible = false;
            editButton.Visible = false;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            scheduleButton.Visible = true;
            currentView = ViewType.Main;
            titleLabel.Text = "Home";
        }

        private void employeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadingLabel.Visible = true;
            var oldView = groupBox1.Controls[1] as UserControl;
            if (oldView != null) groupBox1.Controls.Remove(oldView);
            this.Refresh();

            EmployeeControl control = new EmployeeControl(employeeService.GetEmployeeDataTable());
            groupBox1.Controls.Add(control);

            loadingLabel.Visible = false;
            newButton.Visible = true;
            editButton.Visible = true;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            scheduleButton.Visible = false;
            currentView = ViewType.Employee;
            titleLabel.Text = "Employees";
        }

        private void childrenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadingLabel.Visible = true;
            var oldView = groupBox1.Controls[1] as UserControl;
            if (oldView != null) groupBox1.Controls.Remove(oldView);
            this.Refresh();

            ChildrenControl control = new ChildrenControl(childService.GetChildDataTables());
            groupBox1.Controls.Add(control);

            loadingLabel.Visible = false;
            newButton.Visible = true;
            editButton.Visible = true;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            scheduleButton.Visible = false;
            currentView = ViewType.Child;
            titleLabel.Text = "Children";
        }

        private void roomsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var oldView = groupBox1.Controls[1] as UserControl;
            if (oldView != null) groupBox1.Controls.Remove(oldView);
            groupBox1.Controls.Add(new RoomControl(roomService.GetRoomDataTable()));
            newButton.Visible = false; //should be true for adding rooms in the future
            editButton.Visible = true;
            saveButton.Visible = false;
            cancelButton.Visible = false;
            scheduleButton.Visible = false;
            currentView = ViewType.Room;
            titleLabel.Text = "Rooms";
        }

        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (childService.AnyChildren())
            {
                var strings = new [] { "children", "child"};
                var confirmForm = new ConfirmImportForm(strings, false);
                confirmForm.FormClosed += ConfirmImportFormClosed;
                confirmForm.ShowDialog();
            }
            else
            {
                childService.Import();
                childrenToolStripMenuItem_Click(sender, e);
            }
        }

        private void newButton_Click(object sender, EventArgs e)
        {
            Control control;
            if (currentView == ViewType.Child)
            {
                var oldView = groupBox1.Controls[1] as ChildrenControl;
                control = new ChildEditControl(null, oldView.GetSelectedRoom(), oldView);
                if (oldView != null) groupBox1.Controls.Remove(oldView);
                titleLabel.Text = "Add New Child";
            }
            else
            {
                control = new EmployeeEditControl(null, employeeService.GetNextEmployeeId());
                var oldView = groupBox1.Controls[1] as EmployeeControl;
                if (oldView != null) groupBox1.Controls.Remove(oldView);
                titleLabel.Text = "Add New Employee";
            }

            groupBox1.Controls.Add(control);
            newButton.Visible = false;
            editButton.Visible = false;
            saveButton.Visible = true;
            cancelButton.Visible = true;
            scheduleButton.Visible = false;
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (currentView == ViewType.Child)
            {
                var oldView = groupBox1.Controls[1] as ChildrenControl;
                var names = oldView.GetSelected();

                if (names == null) return;

                var control = new ChildEditControl(childService.GetChild(childService.GetIdFromName(names[0], names[1])), null, oldView);
                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(control);
                titleLabel.Text = "Edit Child";
            }
            else if (currentView == ViewType.Employee)
            {
                var oldView = groupBox1.Controls[1] as EmployeeControl;
                var names = oldView.GetSelected();

                if (names == null) return;

                var control = new EmployeeEditControl(employeeService.GetEmployee(employeeService.GetIdFromName(names[0], names[1])), 0);
                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(control);
                titleLabel.Text = "Edit Employee";
            }
            else
            {
                var oldView = groupBox1.Controls[1] as RoomControl;
                var roomLabel = oldView.GetSelected();

                if (roomLabel == null) return;

                var control = new RoomEditControl(roomService.GetRoom(roomLabel));
                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(control);
                titleLabel.Text = "Edit Room";
            }

            newButton.Visible = false;
            editButton.Visible = false;
            saveButton.Visible = true;
            cancelButton.Visible = true;
            scheduleButton.Visible = false;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (currentView == ViewType.Child)
            {
                var oldView = groupBox1.Controls[1] as ChildEditControl;
                var child = oldView.GetChildFromData();
                if (child == null) return;

                var validTimes = child.CheckTimesForValidity();
                if (validTimes != "")
                {
                    MessageBox.Show(validTimes, "Invalid Entry");
                    return;
                }

                childService.AddOrUpdate(child, oldView.childId);

                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(new ChildrenControl(childService.GetChildDataTables()));
                newButton.Visible = true;
                editButton.Visible = true;
                saveButton.Visible = false;
                cancelButton.Visible = false;
                scheduleButton.Visible = false;
                titleLabel.Text = "Children";
            }
            else if (currentView == ViewType.Employee)
            {
                var oldView = groupBox1.Controls[1] as EmployeeEditControl;
                var employee = oldView.GetEmployeeFromData();
                if (employee == null) return;

                var validTimes = employee.CheckTimesForValidity();
                if (validTimes != "")
                {
                    MessageBox.Show(validTimes, "Invalid Entry");
                    return;
                }

                employeeService.AddOrUpdate(employee);
                employeesEdited = true;

                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(new EmployeeControl(employeeService.GetEmployeeDataTable()));
                newButton.Visible = true;
                editButton.Visible = true;
                saveButton.Visible = false;
                cancelButton.Visible = false;
                scheduleButton.Visible = false;
                titleLabel.Text = "Employees";
            }
            else
            {
                var oldView = groupBox1.Controls[1] as RoomEditControl;
                var room = oldView.GetRoomFromData();
                if (room == null) return;

                roomService.UpdateRoom(room);
                groupBox1.Controls.Remove(oldView);
                groupBox1.Controls.Add(new RoomControl(roomService.GetRoomDataTable()));
                newButton.Visible = false; //should be true for adding rooms in the future
                editButton.Visible = true;
                saveButton.Visible = false;
                cancelButton.Visible = false;
                scheduleButton.Visible = false;
                titleLabel.Text = "Rooms";
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            if (currentView == ViewType.Child)
                childrenToolStripMenuItem_Click(sender, e);
            else if (currentView == ViewType.Employee)
                employeesToolStripMenuItem_Click(sender, e);
            else
                roomsToolStripMenuItem_Click(sender, e);
        }

        private void scheduleButton_Click(object sender, EventArgs e)
        {
            scheduleService.ScheduleWeek(employeeService, childService, roomService);
        }

        private void uploadEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (employeeService.AnyEmployees())
            {
                var strings = new[] { "employees", "employee" };
                var confirmForm = new ConfirmImportForm(strings, true);
                confirmForm.FormClosed += EmployeeConfirmImportFormClosed;
                confirmForm.ShowDialog();
            }
            else
            {
                var returnString = employeeService.Import();
                lastEmployeesUploadedPath = returnString != "" ? returnString : lastEmployeesUploadedPath;
                employeesToolStripMenuItem_Click(sender, e);
            }
        }

        private void exportEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            employeeService.Export(lastEmployeesUploadedPath);
            employeesToolStripMenuItem_Click(sender, e);
        }

        private void MainFormClosing(object sender, FormClosingEventArgs formClosingEventArgs)
        {
            if (!employeeService.AnyEmployees() || !employeesEdited)
                return;

            DialogResult dialogResult = MessageBox.Show("You have made changes to the employees, would you like to export your employee data before exiting?",
                                "Scheduler is Closing", MessageBoxButtons.YesNoCancel);
            if (dialogResult == DialogResult.Yes)
            {
                employeeService.Export(lastEmployeesUploadedPath);
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                formClosingEventArgs.Cancel = true;
            }
        }

        private void ConfirmImportFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            var importForm = sender as ConfirmImportForm;

            if (importForm.GetButtonClicked() == 1)
            {
                childService.Import();
                childrenToolStripMenuItem_Click(sender, formClosedEventArgs);
            }
        }

        private void EmployeeConfirmImportFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
            var importForm = sender as ConfirmImportForm;
            string returnString;
            switch (importForm.GetButtonClicked())
            {
                case 1:
                    returnString = employeeService.Import();
                    lastEmployeesUploadedPath = returnString != "" ? returnString : lastEmployeesUploadedPath;
                    employeesToolStripMenuItem_Click(sender, formClosedEventArgs);
                    break;
                case 3:
                    employeeService.Export(lastEmployeesUploadedPath);
                    returnString = employeeService.Import();
                    lastEmployeesUploadedPath = returnString != "" ? returnString : lastEmployeesUploadedPath;
                    employeesToolStripMenuItem_Click(sender, formClosedEventArgs);
                    break;
            }
        }
    }
}
