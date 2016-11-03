using System;
using System.Collections.Generic;

namespace Scheduler
{
    public class ScheduleService
    {
        private static ScheduleService SchedService;

        private ScheduleService()
        {

        }

        public static ScheduleService GetScheduleService()
        {
            if (SchedService != null)
            {
                return SchedService;
            }
            SchedService = new ScheduleService();
            return SchedService;
        }

        /// <summary>
        /// Assumes all of the given children are in the same room.
        /// </summary>
        /// <param name="children"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        public IList<Dictionary<TimeSpan,int>> GetEmployeesNeeded(List<Child> children, int ratio)
        {
            var monTimesList = new List<Time>();
            var tuesTimesList = new List<Time>();
            var wedTimesList = new List<Time>();
            var thurTimesList = new List<Time>();
            var friTimesList = new List<Time>();

            var monTimeln = new Timeline();
            var tuesTimeln = new Timeline();
            var wedTimeln = new Timeline();
            var thurTimeln = new Timeline();
            var friTimeln = new Timeline();

            var employeeTimes = new List<Dictionary<TimeSpan, int>>();

            foreach (Child kid in children)
            {
                monTimesList.Add(new Time(kid.MonStart, true));
                monTimesList.Add(new Time(kid.MonEnd, false));

                tuesTimesList.Add(new Time(kid.TuesStart, true));
                tuesTimesList.Add(new Time(kid.TuesEnd, false));

                wedTimesList.Add(new Time(kid.WedStart, true));
                wedTimesList.Add(new Time(kid.WedEnd, false));

                thurTimesList.Add(new Time(kid.ThurStart, true));
                thurTimesList.Add(new Time(kid.ThurEnd, false));

                friTimesList.Add(new Time(kid.FriStart, true));
                friTimesList.Add(new Time(kid.FriEnd, false));
            }




            foreach (var time in monTimesList)
            {
                monTimeln.AddPoint(time.Point, time.StartTime);
            }
            foreach (var time in tuesTimesList)
            {
                tuesTimeln.AddPoint(time.Point, time.StartTime);
            }
            foreach (var time in wedTimesList)
            {
                wedTimeln.AddPoint(time.Point, time.StartTime);
            }
            foreach (var time in thurTimesList)
            {
                thurTimeln.AddPoint(time.Point, time.StartTime);
            }
            foreach (var time in friTimesList)
            {
                friTimeln.AddPoint(time.Point, time.StartTime);
            }


            employeeTimes.Add(monTimeln.GetEmployeeTimes(ratio));
            employeeTimes.Add(tuesTimeln.GetEmployeeTimes(ratio));
            employeeTimes.Add(wedTimeln.GetEmployeeTimes(ratio));
            employeeTimes.Add(thurTimeln.GetEmployeeTimes(ratio));
            employeeTimes.Add(friTimeln.GetEmployeeTimes(ratio));

            return employeeTimes;
        }
    }
}
