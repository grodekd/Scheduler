using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Scheduler
{
    public class EmployeeService
    {
        private static EmployeeService EmployeeServiceInstance;
        private DatabaseAccess db;
        private List<Employee> employees;

        private EmployeeService(DatabaseAccess db)
        {
            this.db = db;
            employees = this.db.GetEmployees();
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

        public List<Employee> GetEmployeesByRoom(string roomCode)
        {
            return employees.Where(employee => employee.HasRoom(roomCode)).ToList();
        }

        public Employee GetEmployee()
        {
            return employees[0];
        }

        public DataTable GetEmployeeDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("First Name", typeof(string));
            table.Columns.Add("Last Name", typeof(string));
            table.Columns.Add("Max Hours", typeof(int));
            table.Columns.Add("Rooms", typeof(string));

            foreach (var employee in employees)
            {
                table.Rows.Add(employee.FirstName, employee.LastName, employee.MaxHours, employee.GetRoomsString());
            }

            return table;
        }
    }
}
