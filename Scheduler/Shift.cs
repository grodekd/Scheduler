using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scheduler
{
    public class Shift
    {
        public Shift(int employeeId, TimeSpan startTime, TimeSpan endTime, string roomCode)
        {
            this.EmployeeId = employeeId;
            this.StartTime = startTime;
            this.EndTime = endTime;
            this.RoomCode = roomCode;
        }

        public int EmployeeId { get; private set; }

        public TimeSpan StartTime { get; private set; }

        public TimeSpan EndTime { get; private set; }

        public string RoomCode { get; private set; }
    }
}
