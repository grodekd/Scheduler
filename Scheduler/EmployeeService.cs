using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class EmployeeService
    {
        private static EmployeeService EmployeeServiceInstance;
        private DatabaseAccess db;
        private List<Employee> employees; 

        private EmployeeService()
        {
            db = DatabaseAccess.GetDatabaseAccess();
            employees = db.GetEmployees();
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

        public List<Employee> GetEmployeesByRoom(string roomCode)
        {
            return employees.Where(employee => employee.HasRoom(roomCode)).ToList();
        }
    }
}
