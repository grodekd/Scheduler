using System.Collections.Generic;
using System.Data;

namespace Scheduler
{
    public class ChildService
    {
        private static ChildService ChildServiceInstance;
        private readonly DatabaseAccess db;
        private readonly List<Child> children;

        private ChildService(DatabaseAccess db)
        {
            this.db = db;
            children = this.db.GetChildren();
        }

        public static ChildService GetEmployeeService(DatabaseAccess db)
        {
            if (ChildServiceInstance != null)
            {
                return ChildServiceInstance;
            }
            ChildServiceInstance = new ChildService(db);
            return ChildServiceInstance;
        }

        public DataTable GetEmployeeDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Room", typeof(string));
            table.Columns.Add("Monday", typeof(string));
            table.Columns.Add("Tuesday", typeof(string));
            table.Columns.Add("Wednesday", typeof(string));
            table.Columns.Add("Thursday", typeof(string));
            table.Columns.Add("Friday", typeof(string));
            table.Columns.Add("School Impact", typeof(string));

            foreach (var child in children)
            {
                table.Rows.Add(child.FirstName, child.LastName, child.RoomLabel,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd),
                    child.GetSchool());
            }

            return table;
        }
    }
}
