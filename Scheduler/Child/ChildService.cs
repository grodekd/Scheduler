using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Scheduler
{
    public class ChildService
    {
        private static ChildService ChildServiceInstance;
        private List<Child> children;

        private ChildService()
        {
            children = new List<Child>();
            //children.Add(new Child("5", "Luke", "Kruschel", "SA", new List<TimeSpan> { TimeSpan.Zero, TimeSpan.Zero }, new List<TimeSpan> { TimeSpan.Zero, TimeSpan.Zero }, new List<TimeSpan> { TimeSpan.Zero, TimeSpan.Zero }, new List<TimeSpan> { TimeSpan.Zero, TimeSpan.Zero }, new List<TimeSpan> { TimeSpan.Zero, TimeSpan.Zero }, new List<bool> { false, false, false, false, false }, 0));
        }

        public static ChildService GetChildService()
        {
            if (ChildServiceInstance != null)
            {
                return ChildServiceInstance;
            }
            ChildServiceInstance = new ChildService();
            return ChildServiceInstance;
        }

        public bool AddOrUpdate(Child child, string id)
        {
            if (id == "-1")
            {
                //todo - need to make the db call to add it first 
                children.Add(child);
                return true;
            }

            var index = children.FindIndex(kid => kid.id == id);
            ReplaceChild(child, index);
            return true;
        }

        public Dictionary<string, int> GetChildData()
        {
            return new Dictionary<string, int>
            {
                { "ll", children.Count(x => x.RoomLabel == "LL") },
                { "tt", children.Count(x => x.RoomLabel == "TT") },
                { "ff1", children.Count(x => x.RoomLabel == "FF1") },
                { "ff2", children.Count(x => x.RoomLabel == "FF2") },
                { "bb1", children.Count(x => x.RoomLabel == "BB1") },
                { "bb2", children.Count(x => x.RoomLabel == "BB2") },
                { "bh", children.Count(x => x.RoomLabel == "BH") },
                { "bm", children.Count(x => x.RoomLabel == "BM") },
                { "sa", children.Count(x => x.RoomLabel == "SA") },
                { "total", children.Count },
            };
        }

        public Dictionary<string, DataTable> GetChildDataTables()
        {
            var tables = new Dictionary<string, DataTable>();

            var llTable = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "LL"))
            {
                llTable.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("LL", llTable);

            var ttTable = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "TT"))
            {
                ttTable.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("TT", ttTable);

            var bb1Table = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "BB1"))
            {
                bb1Table.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("BB1", bb1Table);

            var bb2Table = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "BB2"))
            {
                bb2Table.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("BB2", bb2Table);

            var ff1Table = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "FF1"))
            {
                ff1Table.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("FF1", ff1Table);

            var ff2Table = GetTable(false);
            foreach (var child in children.Where(child => child.RoomLabel == "FF2"))
            {
                ff2Table.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd));
            }
            tables.Add("FF2", ff2Table);

            var bhTable = GetTable(true);
            foreach (var child in children.Where(child => child.RoomLabel == "BH"))
            {
                bhTable.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd),
                    child.GetSchool());
            }
            tables.Add("BH", bhTable);

            var bmTable = GetTable(true);
            foreach (var child in children.Where(child => child.RoomLabel == "BM"))
            {
                bmTable.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd),
                    child.GetSchool());
            }
            tables.Add("BM", bmTable);

            var saTable = GetTable(true);
            foreach (var child in children.Where(child => child.RoomLabel == "SA"))
            {
                saTable.Rows.Add(child.FirstName, child.LastName,
                    Time.GetTimeString(child.MonStart, child.MonEnd),
                    Time.GetTimeString(child.TuesStart, child.TuesEnd),
                    Time.GetTimeString(child.WedStart, child.WedEnd),
                    Time.GetTimeString(child.ThurStart, child.ThurEnd),
                    Time.GetTimeString(child.FriStart, child.FriEnd),
                    child.GetSchool());
            }
            tables.Add("SA", saTable);

            return tables;
        }

        private static DataTable GetTable(bool school)
        {
            var table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Monday", typeof(string));
            table.Columns.Add("Tuesday", typeof(string));
            table.Columns.Add("Wednesday", typeof(string));
            table.Columns.Add("Thursday", typeof(string));
            table.Columns.Add("Friday", typeof(string));

            if (school) table.Columns.Add("School Impact", typeof(string));

            return table;
        }

        public bool AnyChildren()
        {
            return children.Any();
        }

        public List<Child> GetChildrenByRoom(string roomCode)
        {
            return children.Where(x => x.RoomLabel == roomCode).ToList();
        }

        public Child GetChild(string id)
        {
            return children.First(child => child.id == id);
        }


        public static List<Child> UpdateKidList(string nameXml, string timeXml, string dayOfWeek, string roomName, List<Child> kids)
        {
            var firstName = nameXml.Split(' ')[1];
            var lastName = nameXml.Split(' ')[0].TrimEnd(new[] { ',' });

            var times = Time.GetTimeSpans(timeXml);

            var id = firstName + lastName;

            var index = kids.FindIndex(kid => kid.id == id);

            var roomLabel = Room.GetRoomLabelFromName(roomName);

            var kidToUpdate = index >= 0 ? kids[index] : new Child(id, firstName, lastName, "");

            switch (dayOfWeek)
            {
                case ("Monday"):
                    if (kidToUpdate.MonStart != TimeSpan.Zero && kidToUpdate.MonEnd != TimeSpan.Zero)
                    {
                        switch (roomLabel)
                        {
                            case "SA":
                                kidToUpdate.MonSchool = true;
                                break;
                            case "BM":
                                kidToUpdate.MonSchool = true;
                                if (kidToUpdate.SchoolType == 0) kidToUpdate.SchoolType = kidToUpdate.MonEnd.Hours == 12 ? 1 : 2;
                                break;
                        }
                    }
                    if (kidToUpdate.MonStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.MonStart) < 0)
                        kidToUpdate.MonStart = times[0];
                    if (kidToUpdate.MonEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.MonEnd) > 0)
                        kidToUpdate.MonEnd = times[1];
                    break;

                case ("Tuesday"):
                    if (kidToUpdate.TuesStart != TimeSpan.Zero && kidToUpdate.TuesEnd != TimeSpan.Zero)
                    {
                        switch (roomLabel)
                        {
                            case "BH":
                            case "SA":
                                kidToUpdate.TuesSchool = true;
                                break;
                            case "BM":
                                kidToUpdate.TuesSchool = true;
                                kidToUpdate.SchoolType = 1;
                                break;
                        }
                    }
                    if (kidToUpdate.TuesStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.TuesStart) < 0)
                        kidToUpdate.TuesStart = times[0];
                    if (kidToUpdate.TuesEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.TuesEnd) > 0)
                        kidToUpdate.TuesEnd = times[1];
                    break;

                case ("Wednesday"):
                    if (kidToUpdate.WedStart != TimeSpan.Zero && kidToUpdate.WedEnd != TimeSpan.Zero)
                    {
                        switch (roomLabel)
                        {
                            case "SA":
                                kidToUpdate.WedSchool = true;
                                break;
                            case "BM":
                                kidToUpdate.WedSchool = true;
                                if (kidToUpdate.SchoolType == 0) kidToUpdate.SchoolType = kidToUpdate.MonEnd.Hours == 12 ? 1 : 2;
                                break;
                        }
                    }
                    if (kidToUpdate.WedStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.WedStart) < 0)
                        kidToUpdate.WedStart = times[0];
                    if (kidToUpdate.WedEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.WedEnd) > 0)
                        kidToUpdate.WedEnd = times[1];
                    break;

                case ("Thursday"):
                    if (kidToUpdate.ThurStart != TimeSpan.Zero && kidToUpdate.ThurEnd != TimeSpan.Zero)
                    {
                        switch (roomLabel)
                        {
                            case "BH":
                            case "SA":
                                kidToUpdate.ThurSchool = true;
                                break;
                            case "BM":
                                kidToUpdate.ThurSchool = true;
                                kidToUpdate.SchoolType = 1;
                                break;
                        }
                    }
                    if (kidToUpdate.ThurStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.ThurStart) < 0)
                        kidToUpdate.ThurStart = times[0];
                    if (kidToUpdate.ThurEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.ThurEnd) > 0)
                        kidToUpdate.ThurEnd = times[1];
                    break;

                case ("Friday"):
                    if (kidToUpdate.FriStart != TimeSpan.Zero && kidToUpdate.FriEnd != TimeSpan.Zero)
                    {
                        switch (roomLabel)
                        {
                            case "SA":
                                kidToUpdate.FriSchool = true;
                                break;
                            case "BM":
                                kidToUpdate.FriSchool = true;
                                if (kidToUpdate.SchoolType == 0) kidToUpdate.SchoolType = kidToUpdate.MonEnd.Hours == 12 ? 1 : 2;
                                break;
                        }
                    }
                    if (kidToUpdate.FriStart == TimeSpan.Zero || TimeSpan.Compare(times[0], kidToUpdate.FriStart) < 0)
                        kidToUpdate.FriStart = times[0];
                    if (kidToUpdate.FriEnd == TimeSpan.Zero || TimeSpan.Compare(times[1], kidToUpdate.FriEnd) > 0)
                        kidToUpdate.FriEnd = times[1];
                    break;
            }

            kidToUpdate.RoomLabel = roomLabel;

            if (index >= 0)
                kids[index] = kidToUpdate;
            else
                kids.Add(kidToUpdate);

            return kids;
        }

        public void Import(out string filename, string tryFile = "")
        {
            var doc = new XmlDocument();
            string returnFilename;
            if (tryFile == "")
            {
                var ofd = new OpenFileDialog
                {
                    InitialDirectory = "C:\\SchedulerStuff\\",
                    Filter = "xml files (*.xml)|*.xml",
                    Title = "Import Child Data",
                    FilterIndex = 1,
                    RestoreDirectory = true
                };

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    returnFilename = ofd.FileName;
                    var x = File.ReadAllText(ofd.FileName);
                    doc.LoadXml(x);
                }
                else
                {
                    filename = "";
                    return;
                }
            }
            else
            {
                returnFilename = tryFile;
                var x = File.ReadAllText(tryFile);
                doc.LoadXml(x);
            }
            
            

            var manager = new XmlNamespaceManager(doc.NameTable);
            manager.AddNamespace("ns", "urn:crystal-reports:schemas:report-detail");
            var y = doc.SelectNodes("//ns:CrystalReport/ns:Group[@Level=\"1\"]", manager);

            var kids = new List<Child>();

            for (int i = 0; i < y.Count; i++)
            {
                var data = y[i];
                var headers = data.SelectNodes("descendant::ns:GroupHeader", manager);
                var roomName = headers[0].SelectSingleNode("descendant::ns:TextValue", manager).InnerText;
                var q = data.SelectNodes("descendant::ns:Group[@Level=\"2\"]", manager);

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
                        kids = UpdateKidList(name, times, day, roomName, kids);
                    }
                }
            }

            if (!kids.Any())
            {
                filename = returnFilename;
                return;
            }

            if (tryFile != "")
            {
                var result = MessageBox.Show("The given file was detected as an child data file.  Would you like to import these children instead?", "Import Failed", MessageBoxButtons.YesNo);
                if (result == DialogResult.No)
                {
                    filename = "";
                    return;
                }
            }
            
            children.Clear();
            children.AddRange(kids);
            filename = "";
        }

        public string GetIdFromName(string first, string last)
        {
            return children.Where(child => child.FirstName == first && child.LastName == last).Select(child => child.id).FirstOrDefault();
        }

        private void ReplaceChild(Child child, int index)
        {
            children[index].FirstName = child.FirstName;
            children[index].LastName = child.LastName;
            children[index].RoomLabel = child.RoomLabel;
            children[index].SchoolType = child.SchoolType;

            children[index].MonStart = child.MonStart;
            children[index].MonEnd = child.MonEnd;
            children[index].MonSchool = child.MonSchool;

            children[index].TuesStart = child.TuesStart;
            children[index].TuesEnd = child.TuesEnd;
            children[index].TuesSchool = child.TuesSchool;

            children[index].WedStart = child.WedStart;
            children[index].WedEnd = child.WedEnd;
            children[index].WedSchool = child.WedSchool;

            children[index].ThurStart = child.ThurStart;
            children[index].ThurEnd = child.ThurEnd;
            children[index].ThurSchool = child.ThurSchool;

            children[index].FriStart = child.FriStart;
            children[index].FriEnd = child.FriEnd;
            children[index].FriSchool = child.FriSchool;
        }
    }
}
