using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using System.Xml;

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

        public DataTable GetChildDataTable()
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

        public static List<Child> UpdateKidList(string nameXml, string timeXml, string dayOfWeek, List<Child> kids)
        {
            var firstName = nameXml.Split(' ')[1];
            var lastName = nameXml.Split(' ')[0].TrimEnd(new[] { ',' });

            var times = Time.GetTimeSpans(timeXml);

            var id = firstName + lastName;

            var index = kids.FindIndex(kid => kid.id == id);

            var kidToUpdate = index >= 0 ? kids[index] : new Child(id, firstName, lastName, "");

            switch (dayOfWeek)
            {
                case ("Monday"):
                    if (kidToUpdate.MonStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.MonStart) < 0)
                        kidToUpdate.MonStart = times[0];
                    if (kidToUpdate.MonEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.MonEnd) > 0)
                        kidToUpdate.MonEnd = times[1];
                    break;

                case ("Tuesday"):
                    if (kidToUpdate.TuesStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.TuesStart) < 0)
                        kidToUpdate.TuesStart = times[0];
                    if (kidToUpdate.TuesEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.TuesEnd) > 0)
                        kidToUpdate.TuesEnd = times[1];
                    break;

                case ("Wednesday"):
                    if (kidToUpdate.WedStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.WedStart) < 0)
                        kidToUpdate.WedStart = times[0];
                    if (kidToUpdate.WedEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.WedEnd) > 0)
                        kidToUpdate.WedEnd = times[1];
                    break;

                case ("Thursday"):
                    if (kidToUpdate.ThurStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.ThurStart) < 0)
                        kidToUpdate.ThurStart = times[0];
                    if (kidToUpdate.ThurEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.ThurEnd) > 0)
                        kidToUpdate.ThurEnd = times[1];
                    break;

                case ("Friday"):
                    if (kidToUpdate.FriStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.FriStart) < 0)
                        kidToUpdate.FriStart = times[0];
                    if (kidToUpdate.FriEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.FriEnd) > 0)
                        kidToUpdate.FriEnd = times[1];
                    break;
            }

            if (index >= 0)
                kids[index] = kidToUpdate;
            else
                kids.Add(kidToUpdate);

            return kids;
        }

        public static void Import()
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                InitialDirectory = "C:\\",
                Filter = "xml files (*.xml)|*.xml",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            XmlDocument doc = new XmlDocument();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var x = File.ReadAllText(ofd.FileName);
                doc.LoadXml(x);
            }

            //XmlDocument doc = new XmlDocument();
            //doc.LoadXml(File.ReadAllText("C:\\Users\\cgroded\\Downloads\\Daily Schedule for Child care 3.xml"));

            XmlNamespaceManager manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("ns", "urn:crystal-reports:schemas:report-detail");
            XmlNode root = doc.DocumentElement;
            var y = doc.SelectNodes("//ns:CrystalReport/ns:Group[@Level=\"1\"]", manager);

            var kids = new List<Child>();

            for (int i = 0; i < y.Count; i++)
            {
                var data = y[i];
                var q = data.SelectNodes("descendant::ns:Group[@Level=\"2\"]", manager);
                var room = data.SelectSingleNode("descendant::ns:GroupHeader", manager)
                    .SelectSingleNode("descendant::ns:TextValue", manager).InnerText;

                for (int ii = 0; ii < q.Count; ii++)
                {
                    var ew = q[ii].SelectNodes("descendant::ns:Details[@Level=\"3\"]", manager);
                    var day = q[ii].SelectSingleNode("descendant::ns:Text[@Name=\"Text2\"]", manager)
                                .SelectSingleNode("descendant::ns:TextValue", manager)
                                .InnerText.Split(new[] { ", " }, StringSplitOptions.None)[0];

                    for (int iii = 0; iii < ew.Count; iii++)
                    {
                        var times =
                            ew[iii].SelectSingleNode("descendant::ns:Field[@Name=\"ScheduleTimes1\"]", manager)
                                .SelectSingleNode("descendant::ns:Value", manager)
                                .InnerText;

                        var name =
                            ew[iii].SelectSingleNode("descendant::ns:Field[@Name=\"ChildName2\"]", manager)
                                .SelectSingleNode("descendant::ns:Value", manager)
                                .InnerText;
                        kids = UpdateKidList(name, times, day, kids);
                    }
                }

            }
        }
    }
}
