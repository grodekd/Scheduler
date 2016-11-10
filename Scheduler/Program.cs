using System;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //var dbAccess = DatabaseAccess.GetDatabaseAccess();
            //var employeeService = EmployeeService.GetEmployeeService(null);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(null));
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
