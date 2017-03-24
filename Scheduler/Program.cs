using System;
using System.Windows.Forms;

namespace Scheduler
{
    public class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            //var dbAccess = DatabaseAccess.GetDatabaseAccess();
            //var employeeService = EmployeeService.GetEmployeeService(dbAccess);
            //var childService = ChildService.GetChildService(dbAccess);

            var employeeService = EmployeeService.GetEmployeeService();
            var childService = ChildService.GetChildService();
            var roomService = RoomService.GetRoomService();
            var scheduleService = ScheduleService.GetScheduleService();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(employeeService, childService, roomService, scheduleService));


            //var dbAccess = DatabaseAccess.GetDatabaseAccess();
            //var scheduleService = ScheduleService.GetScheduleService();

            //dbAccess.AddEmployee(2, "Another", "One", new BsonArray
            //{
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}}
            //}).Wait();

            //List<Child> employees = dbAccess.GetChildren();
            //List<Child> tts = employees.Where(employee => employee.RoomLabel=="TT").ToList();
            //scheduleService.GetEmployeesNeeded(tts, 3);
        }
    }
}
