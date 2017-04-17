using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Windows.Markup;

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

        public void ScheduleWeek(EmployeeService employeeService, ChildService childService, RoomService roomService)
        {
            var lambs = childService.GetChildrenByRoom("LL");
            var turtles = childService.GetChildrenByRoom("TT");
            var bees1 = childService.GetChildrenByRoom("BB1");
            var bees2 = childService.GetChildrenByRoom("BB2");
            var flies1 = childService.GetChildrenByRoom("FF1");
            var flies2 = childService.GetChildrenByRoom("FF2");
            var horizons = childService.GetChildrenByRoom("BH");
            var minds = childService.GetChildrenByRoom("BM");
            var sa = childService.GetChildrenByRoom("SA");

            var llEmployees = employeeService.GetEmployeesByRoom("LL");
            var ttEmployees = employeeService.GetEmployeesByRoom("TT");
            var bb1Employees = employeeService.GetEmployeesByRoom("BB1");
            var bb2Employees = employeeService.GetEmployeesByRoom("BB2");
            var ff1Employees = employeeService.GetEmployeesByRoom("FF1");
            var ff2Employees = employeeService.GetEmployeesByRoom("FF2");
            var bhEmployees = employeeService.GetEmployeesByRoom("BH");
            var bmEmployees = employeeService.GetEmployeesByRoom("BM");
            var saEmployees = employeeService.GetEmployeesByRoom("SA");

            var lambTimes = GetEmployeesNeeded(lambs, roomService.GetRoom("LL").Ratio);
            var turtleTimes = GetEmployeesNeeded(turtles, roomService.GetRoom("TT").Ratio);
            var bee1Times = GetEmployeesNeeded(bees1, roomService.GetRoom("BB1").Ratio);
            var bee2Times = GetEmployeesNeeded(bees2, roomService.GetRoom("BB2").Ratio);
            var fly1Times = GetEmployeesNeeded(flies1, roomService.GetRoom("FF1").Ratio);
            var fly2Times = GetEmployeesNeeded(flies2, roomService.GetRoom("FF2").Ratio);
            var horTimes = GetEmployeesNeeded(horizons, roomService.GetRoom("BH").Ratio);
            var mindTimes = GetEmployeesNeeded(minds, roomService.GetRoom("BM").Ratio);
            var saTimes = GetEmployeesNeeded(sa, roomService.GetRoom("SA").Ratio);

            employeeService.InitializeHoursDictionary();
            var outerMaxHours = 9;
            var replacements = new List<Shift[]>();
            var shifts = new List<Shift>();

            var x = employeeService.GetIdealEmployee("tuesday", lambTimes[1], outerMaxHours, shifts, out replacements, "LL");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", turtleTimes[1], outerMaxHours, shifts, out replacements, "TT");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", bee1Times[1], outerMaxHours, shifts, out replacements, "BB1");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", bee2Times[1], outerMaxHours, shifts, out replacements, "BB2");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", fly1Times[1], outerMaxHours, shifts, out replacements, "FF1");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", fly2Times[1], outerMaxHours, shifts, out replacements, "FF2");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", horTimes[1], outerMaxHours, shifts, out replacements, "BH");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", mindTimes[1], outerMaxHours, shifts, out replacements, "BM");
            shifts.AddRange(x);
            x = employeeService.GetIdealEmployee("tuesday", saTimes[1], outerMaxHours, shifts, out replacements, "SA");
            shifts.AddRange(x);
            //shifts = employeeService.GetIdealEmployee("wednesday", bee2Times[2], outerMaxHours, shifts, "BB2");

            //while (outerMaxHours <= 10)
            //{
            //    var maxHours = outerMaxHours;
            //    var success = employeeService.GetIdealEmployee("wednesday", lambTimes[2], maxHours, "LL");
            //    while (!success)
            //    {
            //        if (maxHours == 10)
            //        {
            //            MessageBox.Show("Fail");
            //        }
            //        maxHours++;
            //        success = employeeService.GetIdealEmployee("wednesday", lambTimes[2], maxHours, "LL");
            //    }

            //    maxHours = outerMaxHours;
            //    success = employeeService.GetIdealEmployee("wednesday", turtleTimes[2], maxHours, "TT");
            //    while (!success)
            //    {
            //        if (maxHours == 10)
            //        {
            //            //clear all shifts in employee service
            //            employeeService.employeeShifts = new List<Shift>();
            //            outerMaxHours++;
            //            break;
            //        }
            //        maxHours++;
            //        success = employeeService.GetIdealEmployee("wednesday", turtleTimes[2], maxHours, "TT");
            //    }
            //    if (!success) continue;

            //    maxHours = outerMaxHours;
            //    success = employeeService.GetIdealEmployee("wednesday", bee1Times[2], maxHours, "BB1");
            //    while (!success)
            //    {
            //        if (maxHours == 10)
            //        {
            //            //clear all shifts in employee service
            //            employeeService.employeeShifts = new List<Shift>();
            //            outerMaxHours++;
            //            break;
            //        }
            //        maxHours++;
            //        success = employeeService.GetIdealEmployee("wednesday", bee1Times[2], maxHours, "BB1");
            //    }
            //    var x = employeeService.employeeShifts;
            //}
        }

        //private bool GetShifts(int index, List<Shift> shifts)
        //{
        //    //if index is roomcount+1 return true
        //    var maxHours = 8;
        //    //while maxHours <= 10
        //    //make call to GetIdeal for this index in room lookup
        //    //if GetIdeal succeeds
        //    //  set shift results locally
        //    //  call GetShifts for next index and pass in shifts param plus local shifts
        //    //  if GetShift call returns true
        //    //      add local shifts to permanant shifts list
        //    //      return true
        //    //  else
        //    //      maxHours ++
        //    //else
        //    //  maxHours ++
        //    //if it makes it outside the while, the whole thing fails.
        //}

        /// <summary>
        /// Assumes all of the given children are in the same room.
        /// </summary>
        /// <param name="children"></param>
        /// <param name="ratio"></param>
        /// <returns></returns>
        private IList<Dictionary<TimeSpan,int>> GetEmployeesNeeded(List<Child> children, int ratio)
        {
            if (children == null || !children.Any())
            {
                return null;
            }
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
                if (kid.MonStart.Hours != 0)
                {
                    monTimesList.Add(new Time(kid.MonStart, true));
                    monTimesList.Add(new Time(kid.MonEnd, false));
                }

                if (kid.TuesStart.Hours != 0)
                {
                    tuesTimesList.Add(new Time(kid.TuesStart, true));
                    tuesTimesList.Add(new Time(kid.TuesEnd, false));
                }

                if (kid.WedStart.Hours != 0)
                {
                    wedTimesList.Add(new Time(kid.WedStart, true));
                    wedTimesList.Add(new Time(kid.WedEnd, false));
                }

                if (kid.ThurStart.Hours != 0)
                {
                    thurTimesList.Add(new Time(kid.ThurStart, true));
                    thurTimesList.Add(new Time(kid.ThurEnd, false));
                }

                if (kid.FriStart.Hours != 0)
                {
                    friTimesList.Add(new Time(kid.FriStart, true));
                    friTimesList.Add(new Time(kid.FriEnd, false));
                }
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
