using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace Scheduler
{
    public class EmployeeService
    {
        private static EmployeeService EmployeeServiceInstance;
        private readonly DatabaseAccess db;
        private readonly List<Employee> employees;
        private Dictionary<int, double> scheduledHours; 
        private int nextId;

        private EmployeeService(DatabaseAccess db)
        {
            this.db = db;
            employees = this.db.GetEmployees();
        }

        private EmployeeService()
        {
            employees = new List<Employee>();
            scheduledHours = new Dictionary<int, double>();
            //{
            //    new Employee("1", "Testy", "McTest", 40, new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(6, 0, 0), new TimeSpan(6, 30, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)}, 
            //        new Dictionary<string, int>{{ "FF1", 1 }, { "FF2", 2 }, { "BH", 3 }, { "BM", 4 }, { "LL", 5 }}),
            //    new Employee("2", "Anotha", "One", 20, new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(6, 30, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)}, 
            //        new Dictionary<string, int>{{ "FF1", 1 }, { "LL", 2 }, { "TT", 3 }, { "BB1", 4 }}),
            //    new Employee("3", "One", "More", 20, new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(7, 0, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)}, 
            //        new Dictionary<string, int>{{ "BB2", 1 }, { "SA", 2 }, { "TT", 3 }, { "BB1", 4 }, { "LL", 5 }}),
            //    new Employee("3", "Even", "More", 20, new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(6, 15, 0), new TimeSpan(18, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(0, 0, 0), new TimeSpan(0, 0, 0)},
            //        new List<TimeSpan>{new TimeSpan(8, 0, 0), new TimeSpan(18, 0, 0)}, 
            //        new Dictionary<string, int>{{ "BB2", 1 }, { "SA", 2 }, { "TT", 3 }, { "BB1", 4 }, { "LL", 5 }})
            //};
        }

        public static EmployeeService GetEmployeeService(DatabaseAccess db)
        {
            if (EmployeeServiceInstance != null)
            {
                return EmployeeServiceInstance;
            }
            EmployeeServiceInstance = new EmployeeService(db);
            return EmployeeServiceInstance;
        }

        public static EmployeeService GetEmployeeService()
        {
            if (EmployeeServiceInstance != null)
            {
                return EmployeeServiceInstance;
            }
            EmployeeServiceInstance = new EmployeeService();
            return EmployeeServiceInstance;
        }

        public int GetNextEmployeeId()
        {
            nextId++;
            return nextId;
        }

        public bool AnyEmployees()
        {
            return employees.Any();
        }

        public Employee GetEmployee(int id)
        {
            return employees.First(employee => employee.Id == id);
        }

        public List<Employee> GetEmployeesByRoom(string roomCode)
        {
            return employees.Where(employee => employee.HasRoom(roomCode)).ToList();
        }

        public List<Employee> GetFilteredEmployees(string roomCode, string dayOfWeek, List<int> scheduledEmployees)
        {
            return employees.Where(employee => employee.HasRoom(roomCode) && scheduledHours[employee.Id] < employee.MaxHours 
                && !scheduledEmployees.Contains(employee.Id) && employee.HasDay(dayOfWeek)).ToList();
        }

        public void InitializeHoursDictionary()
        {
            scheduledHours = new Dictionary<int, double>();
            foreach (var employee in employees)
            {
                scheduledHours.Add(employee.Id, 0);
            }
        }

        public void GetIdealEmployee(string dayOfWeek, Dictionary<TimeSpan, int> times, string room = "")
        {
            var startTimes = new List<TimeSpan>();
            var endTimes = new List<TimeSpan>();

            int count = 0;
            foreach (var time in times)
            {
                if (time.Value > count)
                {
                    startTimes.Add(time.Key);
                    count++;
                }
                else
                {
                    endTimes.Add(time.Key);
                }
            }

            var scheduledStartTimes = new Dictionary<TimeSpan, int>();
            var scheduledEndTimes = new Dictionary<TimeSpan, int>();
            var scheduledEmployees = new List<int>();

            foreach (var time in startTimes)
            {
                var totalEmployees = GetFilteredEmployees(room, dayOfWeek, scheduledEmployees);
                totalEmployees = totalEmployees.Where(x => x.GetStart(dayOfWeek).CompareTo(time) <= 0).ToList();

                var highestPriority = totalEmployees.OrderBy(x => x.GetRoomPriority(room)).First().GetRoomPriority(room);
                var priorityEmployees = totalEmployees.Where(x => x.GetRoomPriority(room) == highestPriority).ToList();

                var employee = priorityEmployees.OrderByDescending(x => x.MaxHours - scheduledHours[x.Id]).First();
                var timeBetween = employee.GetEnd(dayOfWeek).Subtract(time);

                TimeSpan stopTime;
                if (timeBetween.Hours >= 8)
                {
                    stopTime = time.Add(new TimeSpan(8, 0, 0));
                }
                else
                {
                    stopTime = time.Add(timeBetween);
                }

                timeBetween = stopTime.Subtract(time);
                var hours = Convert.ToDouble(timeBetween.Hours);

                switch (timeBetween.Minutes)
                {
                    case 15:
                        hours += .25;
                        break;
                    case 30:
                        hours += .5;
                        break;
                    case 45:
                        hours += .75;
                        break;
                }

                scheduledHours[employee.Id] += hours;
                scheduledStartTimes.Add(time, 1);
                scheduledEndTimes.Add(stopTime, 0);
                scheduledEmployees.Add(employee.Id);
            }

            var orderedEndTimes = scheduledEndTimes.OrderByDescending(x => x.Key).ToList();

            var tempOrderedEnds = orderedEndTimes.ToList();
            var tempEnds = endTimes.ToList();
            foreach (var time in tempOrderedEnds)
            {
                if (time.Key.CompareTo(tempEnds[0]) < 0)
                {
                    break;
                }

                TimeSpan prevTime = new TimeSpan();
                foreach (var end in tempEnds)
                {
                    if (time.Key.CompareTo(end) >= 0)
                    {
                        prevTime = end;
                    }
                    else
                    {
                        orderedEndTimes.Remove(time);
                        tempEnds.Remove(prevTime);
                        break;
                    }
                }
            }

            //var employees = GetEmployeesForTime(dayOfWeek, startTime, room);

            //if (!employees.Any()) return null;

            //var firstPriorities = employees.Where(x => x.GetRoomPriority(room) == 1).ToList();

            //List<Employee> filteredEmployees;
            //if (firstPriorities.Any())
            //{
            //    if (firstPriorities.Count() == 1) return firstPriorities.First();

            //     var orderedList = firstPriorities.OrderBy(x => x.GetRooms().Count);

            //    filteredEmployees = orderedList.Where(x => x.GetRooms().Count == orderedList.First().GetRooms().Count).ToList();
            //}
            //else
            //{
            //    var orderedList = employees.OrderBy(x => x.GetRoomPriority(room));
            //    var orderedAgain = orderedList.Where(x => x.GetRoomPriority(room) == orderedList.First().GetRoomPriority(room)).OrderBy(x => x.GetRooms().Count);
            //    filteredEmployees = orderedAgain.Where(x => x.GetRooms().Count == orderedAgain.First().GetRooms().Count).ToList();
            //}

            //if (filteredEmployees.FirstOrDefault(x => x.GetEnd(dayOfWeek).CompareTo(endTime) >= 0) != null)
            //{
            //    filteredEmployees = filteredEmployees.Where(x => x.GetEnd(dayOfWeek).CompareTo(endTime) >= 0).ToList();
            //}
            //return filteredEmployees.First();
        }

        public Dictionary<string, int> GetEmployeeData()
        {
            return new Dictionary<string, int>
            {
                {"ll", GetEmployeesByRoom("LL").Count},
                {"tt", GetEmployeesByRoom("TT").Count},
                {"bb1", GetEmployeesByRoom("BB1").Count},
                {"bb2", GetEmployeesByRoom("BB2").Count},
                {"ff1", GetEmployeesByRoom("FF1").Count},
                {"ff2", GetEmployeesByRoom("FF2").Count},
                {"bh", GetEmployeesByRoom("BH").Count},
                {"bm", GetEmployeesByRoom("BM").Count},
                {"sa", GetEmployeesByRoom("SA").Count},
                {"total", employees.Count},
            };
        }

        public bool AddOrUpdate(Employee employee)
        {
            if (employees.FirstOrDefault(x => x.Id == employee.Id) == null)
            {
                //employees.Add(new Employee(db.AddEmployee(employee), employee));
                employees.Add(employee);
                return true;
            }

            var index = employees.FindIndex(emp => emp.id == employee.Id);
            //TODO - update employee in db.
            ReplaceEmployee(employee, index);
            return true;
        }

        public DataTable GetEmployeeDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Max Hours", typeof(int));
            table.Columns.Add("Rooms", typeof(string));
            table.Columns.Add("Monday", typeof(string));
            table.Columns.Add("Tuesday", typeof(string));
            table.Columns.Add("Wednesday", typeof(string));
            table.Columns.Add("Thursday", typeof(string));
            table.Columns.Add("Friday", typeof(string));

            foreach (var employee in employees)
            {
                table.Rows.Add(employee.FirstName, employee.LastName, employee.MaxHours, employee.GetRoomsString(), 
                    Time.GetTimeString(employee.MonStart, employee.MonEnd),
                    Time.GetTimeString(employee.TuesStart, employee.TuesEnd),
                    Time.GetTimeString(employee.WedStart, employee.WedEnd),
                    Time.GetTimeString(employee.ThurStart, employee.ThurEnd),
                    Time.GetTimeString(employee.FriStart, employee.FriEnd));
            }

            return table;
        }

        public int GetIdFromName(string first, string last)
        {
            return employees.Where(employee => employee.FirstName == first && employee.LastName == last).Select(employee => employee.Id).FirstOrDefault();
        }

        public string Import()
        {
            var ofd = new OpenFileDialog
            {
                InitialDirectory = "C:\\SchedulerStuff\\",
                Filter = "xml files (*.xml)|*.xml",
                Title = "Import Employee Data",
                FilterIndex = 1,
                RestoreDirectory = true
            };

            var doc = new XmlDocument();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                var x = File.ReadAllText(ofd.FileName);
                doc.LoadXml(x);
            }
            else
            {
                return "";
            }

            var importEmployees = doc.SelectNodes("//Employees/Employee");

            var newEmployees = new List<Employee>();

            for (var i = 0; i < importEmployees.Count; i++)
            {
                var import = importEmployees[i];

                var employeeId = Convert.ToInt32(import.SelectSingleNode("descendant::ID").InnerText);
                if (employeeId > nextId)
                    nextId = employeeId;

                var mondayNode = import.SelectSingleNode("descendant::Monday");
                var monday = new List<TimeSpan>
                {
                    new TimeSpan(Convert.ToInt32(mondayNode.SelectSingleNode("descendant::StartHour").InnerText), Convert.ToInt32(mondayNode.SelectSingleNode("descendant::StartMin").InnerText), 0),
                    new TimeSpan(Convert.ToInt32(mondayNode.SelectSingleNode("descendant::EndHour").InnerText), Convert.ToInt32(mondayNode.SelectSingleNode("descendant::EndMin").InnerText), 0)
                };
                var tuesdayNode = import.SelectSingleNode("descendant::Tuesday");
                var tuesday = new List<TimeSpan>
                {
                    new TimeSpan(Convert.ToInt32(tuesdayNode.SelectSingleNode("descendant::StartHour").InnerText), Convert.ToInt32(tuesdayNode.SelectSingleNode("descendant::StartMin").InnerText), 0),
                    new TimeSpan(Convert.ToInt32(tuesdayNode.SelectSingleNode("descendant::EndHour").InnerText), Convert.ToInt32(tuesdayNode.SelectSingleNode("descendant::EndMin").InnerText), 0)
                };
                var wednesdayNode = import.SelectSingleNode("descendant::Wednesday");
                var wednesday = new List<TimeSpan>
                {
                    new TimeSpan(Convert.ToInt32(wednesdayNode.SelectSingleNode("descendant::StartHour").InnerText), Convert.ToInt32(wednesdayNode.SelectSingleNode("descendant::StartMin").InnerText), 0),
                    new TimeSpan(Convert.ToInt32(wednesdayNode.SelectSingleNode("descendant::EndHour").InnerText), Convert.ToInt32(wednesdayNode.SelectSingleNode("descendant::EndMin").InnerText), 0)
                };
                var thursdayNode = import.SelectSingleNode("descendant::Thursday");
                var thursday = new List<TimeSpan>
                {
                    new TimeSpan(Convert.ToInt32(thursdayNode.SelectSingleNode("descendant::StartHour").InnerText), Convert.ToInt32(thursdayNode.SelectSingleNode("descendant::StartMin").InnerText), 0),
                    new TimeSpan(Convert.ToInt32(thursdayNode.SelectSingleNode("descendant::EndHour").InnerText), Convert.ToInt32(thursdayNode.SelectSingleNode("descendant::EndMin").InnerText), 0)
                };
                var fridayNode = import.SelectSingleNode("descendant::Friday");
                var friday = new List<TimeSpan>
                {
                    new TimeSpan(Convert.ToInt32(fridayNode.SelectSingleNode("descendant::StartHour").InnerText), Convert.ToInt32(fridayNode.SelectSingleNode("descendant::StartMin").InnerText), 0),
                    new TimeSpan(Convert.ToInt32(fridayNode.SelectSingleNode("descendant::EndHour").InnerText), Convert.ToInt32(fridayNode.SelectSingleNode("descendant::EndMin").InnerText), 0)
                };

                var rooms = new Dictionary<string, int>();

                if (import.SelectSingleNode("descendant::LL").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("LL", Convert.ToInt32(import.SelectSingleNode("descendant::LL").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::TT").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("TT", Convert.ToInt32(import.SelectSingleNode("descendant::TT").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::BB1").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("BB1", Convert.ToInt32(import.SelectSingleNode("descendant::BB1").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::BB2").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("BB2", Convert.ToInt32(import.SelectSingleNode("descendant::BB2").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::FF1").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("FF1", Convert.ToInt32(import.SelectSingleNode("descendant::FF1").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::FF2").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("FF2", Convert.ToInt32(import.SelectSingleNode("descendant::FF2").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::BH").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("BH", Convert.ToInt32(import.SelectSingleNode("descendant::BH").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::BM").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("BM", Convert.ToInt32(import.SelectSingleNode("descendant::BM").SelectSingleNode("descendant::Priority").InnerText));

                if (import.SelectSingleNode("descendant::SA").SelectSingleNode("descendant::Works").InnerText == "yes")
                    rooms.Add("SA", Convert.ToInt32(import.SelectSingleNode("descendant::SA").SelectSingleNode("descendant::Priority").InnerText));

                newEmployees.Add(new Employee(
                    employeeId, import.SelectSingleNode("descendant::FirstName").InnerText,
                    import.SelectSingleNode("descendant::LastName").InnerText, Convert.ToDouble(import.SelectSingleNode("descendant::MaxHours").InnerText),
                    monday, tuesday, wednesday, thursday, friday, rooms));
            }

            employees.Clear();
            employees.AddRange(newEmployees);

            return ofd.FileName;
        }

        public void Export(string path)
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = doc.DocumentElement;
            doc.InsertBefore(xmlDeclaration, root);

            XmlElement employeesTag = doc.CreateElement(string.Empty, "Employees", string.Empty);
            doc.AppendChild(employeesTag);

            foreach (var worker in employees)
            {
                XmlElement employee = doc.CreateElement(string.Empty, "Employee", string.Empty);
                employeesTag.AppendChild(employee);

                XmlElement id = doc.CreateElement(string.Empty, "ID", string.Empty);
                XmlText idText = doc.CreateTextNode(worker.Id.ToString());
                id.AppendChild(idText);
                employee.AppendChild(id);

                XmlElement first = doc.CreateElement(string.Empty, "FirstName", string.Empty);
                XmlText fnText = doc.CreateTextNode(worker.FirstName);
                first.AppendChild(fnText);
                employee.AppendChild(first);

                XmlElement last = doc.CreateElement(string.Empty, "LastName", string.Empty);
                XmlText lnText = doc.CreateTextNode(worker.LastName);
                last.AppendChild(lnText);
                employee.AppendChild(last);

                XmlElement hours = doc.CreateElement(string.Empty, "MaxHours", string.Empty);
                XmlText hrText = doc.CreateTextNode(worker.MaxHours.ToString());
                hours.AppendChild(hrText);
                employee.AppendChild(hours);

                //Monday
                XmlElement monday = doc.CreateElement(string.Empty, "Monday", string.Empty);
                employee.AppendChild(monday);

                XmlElement msHour = doc.CreateElement(string.Empty, "StartHour", string.Empty);
                XmlText mshText = doc.CreateTextNode(worker.MonStart.Hours.ToString());
                msHour.AppendChild(mshText);
                monday.AppendChild(msHour);

                XmlElement msMin = doc.CreateElement(string.Empty, "StartMin", string.Empty);
                XmlText msmText = doc.CreateTextNode(worker.MonStart.Minutes.ToString());
                msMin.AppendChild(msmText);
                monday.AppendChild(msMin);

                XmlElement meHour = doc.CreateElement(string.Empty, "EndHour", string.Empty);
                XmlText mehText = doc.CreateTextNode(worker.MonEnd.Hours.ToString());
                meHour.AppendChild(mehText);
                monday.AppendChild(meHour);

                XmlElement meMin = doc.CreateElement(string.Empty, "EndMin", string.Empty);
                XmlText memText = doc.CreateTextNode(worker.MonEnd.Minutes.ToString());
                meMin.AppendChild(memText);
                monday.AppendChild(meMin);

                //Tuesday
                XmlElement tuesday = doc.CreateElement(string.Empty, "Tuesday", string.Empty);
                employee.AppendChild(tuesday);

                XmlElement tsHour = doc.CreateElement(string.Empty, "StartHour", string.Empty);
                XmlText tshText = doc.CreateTextNode(worker.TuesStart.Hours.ToString());
                tsHour.AppendChild(tshText);
                tuesday.AppendChild(tsHour);

                XmlElement tsMin = doc.CreateElement(string.Empty, "StartMin", string.Empty);
                XmlText tsmText = doc.CreateTextNode(worker.TuesStart.Minutes.ToString());
                tsMin.AppendChild(tsmText);
                tuesday.AppendChild(tsMin);

                XmlElement teHour = doc.CreateElement(string.Empty, "EndHour", string.Empty);
                XmlText tehText = doc.CreateTextNode(worker.TuesEnd.Hours.ToString());
                teHour.AppendChild(tehText);
                tuesday.AppendChild(teHour);

                XmlElement teMin = doc.CreateElement(string.Empty, "EndMin", string.Empty);
                XmlText temText = doc.CreateTextNode(worker.TuesEnd.Minutes.ToString());
                teMin.AppendChild(temText);
                tuesday.AppendChild(teMin);

                //Wednesday
                XmlElement wednesday = doc.CreateElement(string.Empty, "Wednesday", string.Empty);
                employee.AppendChild(wednesday);

                XmlElement wsHour = doc.CreateElement(string.Empty, "StartHour", string.Empty);
                XmlText wshText = doc.CreateTextNode(worker.WedStart.Hours.ToString());
                wsHour.AppendChild(wshText);
                wednesday.AppendChild(wsHour);

                XmlElement wsMin = doc.CreateElement(string.Empty, "StartMin", string.Empty);
                XmlText wsmText = doc.CreateTextNode(worker.WedStart.Minutes.ToString());
                wsMin.AppendChild(wsmText);
                wednesday.AppendChild(wsMin);

                XmlElement weHour = doc.CreateElement(string.Empty, "EndHour", string.Empty);
                XmlText wehText = doc.CreateTextNode(worker.WedEnd.Hours.ToString());
                weHour.AppendChild(wehText);
                wednesday.AppendChild(weHour);

                XmlElement weMin = doc.CreateElement(string.Empty, "EndMin", string.Empty);
                XmlText wemText = doc.CreateTextNode(worker.WedEnd.Minutes.ToString());
                weMin.AppendChild(wemText);
                wednesday.AppendChild(weMin);

                //Thursday
                XmlElement thursday = doc.CreateElement(string.Empty, "Thursday", string.Empty);
                employee.AppendChild(thursday);

                XmlElement thsHour = doc.CreateElement(string.Empty, "StartHour", string.Empty);
                XmlText thshText = doc.CreateTextNode(worker.ThurStart.Hours.ToString());
                thsHour.AppendChild(thshText);
                thursday.AppendChild(thsHour);

                XmlElement thsMin = doc.CreateElement(string.Empty, "StartMin", string.Empty);
                XmlText thsmText = doc.CreateTextNode(worker.ThurStart.Minutes.ToString());
                thsMin.AppendChild(thsmText);
                thursday.AppendChild(thsMin);

                XmlElement theHour = doc.CreateElement(string.Empty, "EndHour", string.Empty);
                XmlText thehText = doc.CreateTextNode(worker.ThurEnd.Hours.ToString());
                theHour.AppendChild(thehText);
                thursday.AppendChild(theHour);

                XmlElement theMin = doc.CreateElement(string.Empty, "EndMin", string.Empty);
                XmlText themText = doc.CreateTextNode(worker.ThurEnd.Minutes.ToString());
                theMin.AppendChild(themText);
                thursday.AppendChild(theMin);

                //Friday
                XmlElement friday = doc.CreateElement(string.Empty, "Friday", string.Empty);
                employee.AppendChild(friday);

                XmlElement fsHour = doc.CreateElement(string.Empty, "StartHour", string.Empty);
                XmlText fshText = doc.CreateTextNode(worker.FriStart.Hours.ToString());
                fsHour.AppendChild(fshText);
                friday.AppendChild(fsHour);

                XmlElement fsMin = doc.CreateElement(string.Empty, "StartMin", string.Empty);
                XmlText fsmText = doc.CreateTextNode(worker.FriStart.Minutes.ToString());
                fsMin.AppendChild(fsmText);
                friday.AppendChild(fsMin);

                XmlElement feHour = doc.CreateElement(string.Empty, "EndHour", string.Empty);
                XmlText fehText = doc.CreateTextNode(worker.FriEnd.Hours.ToString());
                feHour.AppendChild(fehText);
                friday.AppendChild(feHour);

                XmlElement feMin = doc.CreateElement(string.Empty, "EndMin", string.Empty);
                XmlText femText = doc.CreateTextNode(worker.FriEnd.Minutes.ToString());
                feMin.AppendChild(femText);
                friday.AppendChild(feMin);

                //LL
                var works = worker.HasRoom("LL") ? "yes" : "no";
                var priority = worker.GetRoomPriority("LL").ToString();

                XmlElement ll = doc.CreateElement(string.Empty, "LL", string.Empty);
                employee.AppendChild(ll);

                XmlElement llWorks = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText llwText = doc.CreateTextNode(works);
                llWorks.AppendChild(llwText);
                ll.AppendChild(llWorks);

                XmlElement llPri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText llpText = doc.CreateTextNode(priority);
                llPri.AppendChild(llpText);
                ll.AppendChild(llPri);

                //TT
                works = worker.HasRoom("TT") ? "yes" : "no";
                priority = worker.GetRoomPriority("TT").ToString();

                XmlElement tt = doc.CreateElement(string.Empty, "TT", string.Empty);
                employee.AppendChild(tt);

                XmlElement ttWorks = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText ttwText = doc.CreateTextNode(works);
                ttWorks.AppendChild(ttwText);
                tt.AppendChild(ttWorks);

                XmlElement ttPri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText ttpText = doc.CreateTextNode(priority);
                ttPri.AppendChild(ttpText);
                tt.AppendChild(ttPri);

                //BB1
                works = worker.HasRoom("BB1") ? "yes" : "no";
                priority = worker.GetRoomPriority("BB1").ToString();

                XmlElement bb1 = doc.CreateElement(string.Empty, "BB1", string.Empty);
                employee.AppendChild(bb1);

                XmlElement bb1Works = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText bb1WText = doc.CreateTextNode(works);
                bb1Works.AppendChild(bb1WText);
                bb1.AppendChild(bb1Works);

                XmlElement bb1Pri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText bb1PText = doc.CreateTextNode(priority);
                bb1Pri.AppendChild(bb1PText);
                bb1.AppendChild(bb1Pri);

                //BB2
                works = worker.HasRoom("BB2") ? "yes" : "no";
                priority = worker.GetRoomPriority("BB2").ToString();

                XmlElement bb2 = doc.CreateElement(string.Empty, "BB2", string.Empty);
                employee.AppendChild(bb2);

                XmlElement bb2Works = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText bb2WText = doc.CreateTextNode(works);
                bb2Works.AppendChild(bb2WText);
                bb2.AppendChild(bb2Works);

                XmlElement bb2Pri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText bb2PText = doc.CreateTextNode(priority);
                bb2Pri.AppendChild(bb2PText);
                bb2.AppendChild(bb2Pri);

                //FF1
                works = worker.HasRoom("FF1") ? "yes" : "no";
                priority = worker.GetRoomPriority("FF1").ToString();

                XmlElement ff1 = doc.CreateElement(string.Empty, "FF1", string.Empty);
                employee.AppendChild(ff1);

                XmlElement ff1Works = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText ff1WText = doc.CreateTextNode(works);
                ff1Works.AppendChild(ff1WText);
                ff1.AppendChild(ff1Works);

                XmlElement ff1Pri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText ff1PText = doc.CreateTextNode(priority);
                ff1Pri.AppendChild(ff1PText);
                ff1.AppendChild(ff1Pri);

                //FF2
                works = worker.HasRoom("FF2") ? "yes" : "no";
                priority = worker.GetRoomPriority("FF2").ToString();

                XmlElement ff2 = doc.CreateElement(string.Empty, "FF2", string.Empty);
                employee.AppendChild(ff2);

                XmlElement ff2Works = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText ff2WText = doc.CreateTextNode(works);
                ff2Works.AppendChild(ff2WText);
                ff2.AppendChild(ff2Works);

                XmlElement ff2Pri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText ff2PText = doc.CreateTextNode(priority);
                ff2Pri.AppendChild(ff2PText);
                ff2.AppendChild(ff2Pri);

                //BH
                works = worker.HasRoom("BH") ? "yes" : "no";
                priority = worker.GetRoomPriority("BH").ToString();

                XmlElement bh = doc.CreateElement(string.Empty, "BH", string.Empty);
                employee.AppendChild(bh);

                XmlElement bhWorks = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText bhwText = doc.CreateTextNode(works);
                bhWorks.AppendChild(bhwText);
                bh.AppendChild(bhWorks);

                XmlElement bhPri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText bhpText = doc.CreateTextNode(priority);
                bhPri.AppendChild(bhpText);
                bh.AppendChild(bhPri);

                //BM
                works = worker.HasRoom("BM") ? "yes" : "no";
                priority = worker.GetRoomPriority("BM").ToString();

                XmlElement bm = doc.CreateElement(string.Empty, "BM", string.Empty);
                employee.AppendChild(bm);

                XmlElement bmWorks = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText bmwText = doc.CreateTextNode(works);
                bmWorks.AppendChild(bmwText);
                bm.AppendChild(bmWorks);

                XmlElement bmPri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText bmpText = doc.CreateTextNode(priority);
                bmPri.AppendChild(bmpText);
                bm.AppendChild(bmPri);

                //SA
                works = worker.HasRoom("SA") ? "yes" : "no";
                priority = worker.GetRoomPriority("SA").ToString();

                XmlElement sa = doc.CreateElement(string.Empty, "SA", string.Empty);
                employee.AppendChild(sa);

                XmlElement saWorks = doc.CreateElement(string.Empty, "Works", string.Empty);
                XmlText sawText = doc.CreateTextNode(works);
                saWorks.AppendChild(sawText);
                sa.AppendChild(saWorks);

                XmlElement saPri = doc.CreateElement(string.Empty, "Priority", string.Empty);
                XmlText sapText = doc.CreateTextNode(priority);
                saPri.AppendChild(sapText);
                sa.AppendChild(saPri);
            }

            var filepath = path.Substring(0, path.LastIndexOf('\\') + 1);
            var filename = path.Substring(path.LastIndexOf('\\') + 1);

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "XML-File | *.xml";
            saveFileDialog.FileName = filename;
            saveFileDialog.InitialDirectory = filepath;
            saveFileDialog.Title = "Export Employee Data";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                doc.Save(saveFileDialog.FileName);
            }
        }

        private void ReplaceEmployee(Employee employee, int index)
        {
            employees[index].FirstName = employee.FirstName;
            employees[index].LastName = employee.LastName;
            employees[index].MaxHours = employee.MaxHours;
            employees[index].ReplaceRooms(employee.GetRooms());

            employees[index].MonStart = employee.MonStart;
            employees[index].MonEnd = employee.MonEnd;

            employees[index].TuesStart = employee.TuesStart;
            employees[index].TuesEnd = employee.TuesEnd;

            employees[index].WedStart = employee.WedStart;
            employees[index].WedEnd = employee.WedEnd;

            employees[index].ThurStart = employee.ThurStart;
            employees[index].ThurEnd = employee.ThurEnd;

            employees[index].FriStart = employee.FriStart;
            employees[index].FriEnd = employee.FriEnd;
        }

        private List<Employee> GetEmployeesForTime(string dayOfWeek, TimeSpan startTime, string room = "")
        {
            var roomEmployes = employees;
            if (room != "")
                roomEmployes = GetEmployeesByRoom(room);

            var returnEmployees = new List<Employee>();
            switch (dayOfWeek)
            {
                case "monday":
                    returnEmployees = roomEmployes.Where(x => x.MonStart != TimeSpan.Zero && x.MonStart.CompareTo(startTime) <= 0 && x.MonEnd.CompareTo(startTime) > 0).ToList();
                    break;
                case "tuesday":
                    returnEmployees = roomEmployes.Where(x => x.TuesStart != TimeSpan.Zero && x.TuesStart.CompareTo(startTime) <= 0 && x.TuesEnd.CompareTo(startTime) > 0).ToList();
                    break;
                case "wednesday":
                    returnEmployees = roomEmployes.Where(x => x.WedStart != TimeSpan.Zero && x.WedStart.CompareTo(startTime) <= 0 && x.WedEnd.CompareTo(startTime) > 0).ToList();
                    break;
                case "thursday":
                    returnEmployees = roomEmployes.Where(x => x.ThurStart != TimeSpan.Zero && x.ThurStart.CompareTo(startTime) <= 0 && x.ThurEnd.CompareTo(startTime) > 0).ToList();
                    break;
                case "friday":
                    returnEmployees = roomEmployes.Where(x => x.FriStart != TimeSpan.Zero && x.FriStart.CompareTo(startTime) <= 0 && x.FriEnd.CompareTo(startTime) > 0).ToList();
                    break;
            }

            return returnEmployees;
        }
    }
}
