using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class Shift
    {
        public Shift(int employeeId, string employeeName, TimeSpan startTime, TimeSpan endTime, string roomCode, string dow)
        {
            this.EmployeeId = employeeId;
            this.EmployeeName = employeeName;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.RoomCode = roomCode;
            this.DayOfWeek = dow;
        }

        public int EmployeeId { get; private set; }

        public string EmployeeName { get; private set; }

        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public string RoomCode { get; private set; }

        public string DayOfWeek { get; private set; }

        public static double GetHoursForEmployee(List<Shift> shifts, int id)
        {
            var employeeShifts = shifts.Where(x => x.EmployeeId == id).ToList();

            return employeeShifts.Sum(shift => Time.GetHoursAsDouble(shift.EndTime.Subtract(shift.StartTime)));
        }
    }
}
