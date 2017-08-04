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

        private List<Shift> scheduledShifts = new List<Shift>();

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
            //var lambs = childService.GetChildrenByRoom("LL");
            //var turtles = childService.GetChildrenByRoom("TT");
            //var bees1 = childService.GetChildrenByRoom("BB1");
            //var bees2 = childService.GetChildrenByRoom("BB2");
            //var flies1 = childService.GetChildrenByRoom("FF1");
            //var flies2 = childService.GetChildrenByRoom("FF2");
            //var horizons = childService.GetChildrenByRoom("BH");
            //var minds = childService.GetChildrenByRoom("BM");
            //var sa = childService.GetChildrenByRoom("SA");

            //var llEmployees = employeeService.GetEmployeesByRoom("LL");
            //var ttEmployees = employeeService.GetEmployeesByRoom("TT");
            //var bb1Employees = employeeService.GetEmployeesByRoom("BB1");
            //var bb2Employees = employeeService.GetEmployeesByRoom("BB2");
            //var ff1Employees = employeeService.GetEmployeesByRoom("FF1");
            //var ff2Employees = employeeService.GetEmployeesByRoom("FF2");
            //var bhEmployees = employeeService.GetEmployeesByRoom("BH");
            //var bmEmployees = employeeService.GetEmployeesByRoom("BM");
            //var saEmployees = employeeService.GetEmployeesByRoom("SA");

            //var lambTimes = GetEmployeesNeeded(lambs, roomService.GetRoom("LL").Ratio);
            //var turtleTimes = GetEmployeesNeeded(turtles, roomService.GetRoom("TT").Ratio);
            //var bee1Times = GetEmployeesNeeded(bees1, roomService.GetRoom("BB1").Ratio);
            //var bee2Times = GetEmployeesNeeded(bees2, roomService.GetRoom("BB2").Ratio);
            //var fly1Times = GetEmployeesNeeded(flies1, roomService.GetRoom("FF1").Ratio);
            //var fly2Times = GetEmployeesNeeded(flies2, roomService.GetRoom("FF2").Ratio);
            //var horTimes = GetEmployeesNeeded(horizons, roomService.GetRoom("BH").Ratio);
            //var mindTimes = GetEmployeesNeeded(minds, roomService.GetRoom("BM").Ratio);
            //var saTimes = GetEmployeesNeeded(sa, roomService.GetRoom("SA").Ratio, 4);

            //employeeService.InitializeHoursDictionary();

            var childStartTimes = new List<TimeSpan>() { new TimeSpan(6,15,0), new TimeSpan(7, 15, 0), new TimeSpan(7, 30, 0), new TimeSpan(8, 15, 0) };
            var childEndTimes = new List<TimeSpan>() { new TimeSpan(13, 15, 0), new TimeSpan(14, 15, 0), new TimeSpan(16, 30, 0), new TimeSpan(18, 0, 0) };
            var scheduledShifts = new List<Shift>();
            var failedShifts = new List<Shift>();

            //testing vars to be REMOVED
            var dayOfWeek = "monday";
            var room = "LL";
            var maxHours = 8;

            //employeeService.InitializeHoursDictionary();

            //int count = 0;
            //foreach (var time in lambTimes[0])
            //{
            //    if (time.Value > count)
            //    {
            //        childStartTimes.Add(time.Key);
            //        count++;
            //    }
            //    else
            //    {
            //        childEndTimes.Add(time.Key);
            //    }
            //}

            var employeeCheck = employeeService.GetFilteredEmployees(room, dayOfWeek);

            employeeService.AddOrUpdate(employeeCheck.First()); //For testing only.  REMOVE
            employeeService.InitializeHoursDictionary(); //For testing only.  REMOVE


            #region "Update For Earliest"
            //The process in this region makes sure there is an employee that can start early enough for each of the child start times.
            //In the case where there is a child start time too early for any employee the child start time is changed to the earliest
            //employee start time and the difference is recorded as a failed shift.
            //ASSUMES ALL CHILD START TIMES ARE IN SEQUENTIAL ORDER

            //Get the earliest times employees can start.  Get as many as there are child start times.
            var earliest = employeeService.GetEarliestStartTimes(employeeCheck, dayOfWeek, childStartTimes.Count);

            var updatedStartTimes = new List<TimeSpan>();

            var earlyIndex = 1;
            //Go through all the child start times
            foreach (var time in childStartTimes)
            {
                //If its at or after the respective earliest employee start time, add it to a temp list.
                if (time.CompareTo(earliest[earlyIndex]) >= 0)
                {
                    updatedStartTimes.Add(time);
                }
                //If not, add the difference to the failed shifts and add the respective earliest employee time to the temp list.
                else
                {
                    //If this earliest employee time was TimeSpan.MaxValue that means there weren't enough employees that could work in this
                    //room at any point that day.  Mark the child start time to the latest child end time as a failed shift and remove them
                    //from their respective lists.
                    if (earliest[earlyIndex] != TimeSpan.MaxValue)
                    {
                        failedShifts.Add(new Shift(0, "", time, earliest[earlyIndex], room, dayOfWeek));
                        updatedStartTimes.Add(earliest[earlyIndex]);
                    }
                    else
                    {
                        failedShifts.Add(new Shift(0, "", time, childEndTimes.Last(), room, dayOfWeek));
                        childEndTimes.Remove(childEndTimes.Last());
                        //dont need to remove anything from child start times.  Simply not adding anything to the temp list is enough.
                    }
                }
                earlyIndex++;
            }

            //set the child start times to the updated list
            childStartTimes = updatedStartTimes;
            #endregion

            #region "Update For Latest"
            //The process for this region is similar to the Update For Earliest region, but for end times.
            //ASSUMES ALL CHILD END TIMES ARE IN SEQUENTIAL ORDER

            //Get the latest end times employees can end.  Get as many as there are child end times.
            var latest = employeeService.GetLatestEndTimes(employeeCheck, dayOfWeek, childEndTimes.Count);

            var updatedEndTimes = new List<TimeSpan>();

            var lateIndex = latest.Count;
            //Go through all the child end times
            foreach (var time in childEndTimes)
            {
                //If its at or before the respective latest employee end time, add it to a temp list.
                if (time.CompareTo(latest[lateIndex]) <= 0)
                {
                    updatedEndTimes.Add(time);
                }
                //If not, add the difference to the failed shifts and add the respective latest employee time to the temp list.
                else
                {
                    //If this latest employee time was TimeSpan.MinValue that means there weren't enough employees that could work in this
                    //room at any point that day.  This should never happen since there are the same number of end time as start times and 
                    //the Update For Earliest will have handled not having enough employee for that number.  Just in case it does handle it
                    //similarly by removing the earliest child start time.
                    if (latest[lateIndex] != TimeSpan.MinValue)
                    {
                        failedShifts.Add(new Shift(0, "", latest[lateIndex], time, room, dayOfWeek));
                        updatedEndTimes.Add(latest[lateIndex]);
                    }
                    else
                    {
                        failedShifts.Add(new Shift(0, "", childStartTimes.First(), time, room, dayOfWeek));
                        childStartTimes.Remove(childStartTimes.First());
                    }
                }
                lateIndex--;
            }

            //set the child end times to the updated list
            childEndTimes = updatedEndTimes;
            #endregion

            while(childStartTimes.Any())
            {
                var scheduledStartTimes = new Dictionary<int, TimeSpan>();
                var scheduledEndTimes = new Dictionary<int, TimeSpan>();

                foreach (var childStartTime in childStartTimes)
                {
                    var highestPriority = employeeCheck.OrderBy(x => x.GetRoomPriority(room)).First().GetRoomPriority(room); //Find the highest priority for this room from the employees
                    var priorityEmployees = employeeCheck.Where(x => x.GetRoomPriority(room) == highestPriority).ToList(); //A list of the employees at the highest priority
                    var orderedEmployees = priorityEmployees.OrderByDescending(x => x.MaxHours - employeeService.GetScheduledHoursForEmployee(x.Id)); //order employees by the number of max hours left this week.

                    Employee selectedEmployee = null;
                    TimeSpan potentialHoursThisShift = TimeSpan.Zero;

                    //Find an employee that would either have a shift over 3 hours, or that would work at least until the earliest child end time.
                    //This prevents short shifts that don't even make it to a child end time.
                    while (selectedEmployee == null)
                    {
                        foreach (var employee in orderedEmployees)
                        {
                            potentialHoursThisShift = employee.GetEnd(dayOfWeek).Subtract(childStartTime);
                            if (potentialHoursThisShift.Hours >= 2 || employee.GetEnd(dayOfWeek).CompareTo(childEndTimes[0]) >= 0)
                            {
                                selectedEmployee = employee;
                                break;
                            }
                        }
                        //If no employees at the priority level meet the criteria, check the next priority level down.
                        if (selectedEmployee == null)
                        {
                            highestPriority++;
                            if (highestPriority == 10)
                            {
                                //Couldn't find any employee to work at this time.
                                //Record some kind of a fail shift.
                            }

                            //Reset employees to the next highest priority
                            priorityEmployees = employeeCheck.Where(x => x.GetRoomPriority(room) == highestPriority).ToList();
                            orderedEmployees = priorityEmployees.OrderByDescending(x => x.MaxHours - employeeService.GetScheduledHoursForEmployee(x.Id));
                        }
                    }

                    //Set the shift end time to either the employees end time that day, or the max number of hours after the start time.
                    TimeSpan stopTime;

                    if (potentialHoursThisShift.Hours >= maxHours)
                    {
                        stopTime = childStartTime.Add(new TimeSpan(maxHours, 0, 0));
                    }
                    else
                    {
                        stopTime = childStartTime.Add(potentialHoursThisShift);
                    }

                    scheduledStartTimes.Add(selectedEmployee.Id, childStartTime);
                    scheduledEndTimes.Add(selectedEmployee.Id, stopTime);
                }

                var orderedShiftEndTimes = scheduledEndTimes.OrderByDescending(x => x.Value).ToList();

                var tempOrderedShiftEnds = orderedShiftEndTimes.ToList();
                var tempChildEnds = childEndTimes.ToList();

                foreach (var shiftEndTime in tempOrderedShiftEnds)
                {
                    //if this shift end is before the earliest child end, none of the remaining end times can be lined up.
                    if (shiftEndTime.Value.CompareTo(tempChildEnds[0]) < 0)
                    {
                        break;
                    }

                    //find the latest child end time that is still before this shift end time.
                    TimeSpan prevTime = new TimeSpan();
                    bool scheduled = false;
                    foreach (var end in tempChildEnds)
                    {
                        if (shiftEndTime.Value.CompareTo(end) >= 0)
                        {
                            prevTime = end;
                        }
                        else
                        {
                            //consider this shift end time to now be the child end time and remove them both from their respective lists
                            orderedShiftEndTimes.Remove(shiftEndTime);
                            tempChildEnds.Remove(prevTime);

                            var id = shiftEndTime.Key;
                            var name = string.Format("{0} {1}", employeeService.GetEmployee(id).FirstName, employeeService.GetEmployee(id).LastName);
                            var shift = new Shift(id, name, scheduledStartTimes[id], prevTime, room, dayOfWeek);
                            scheduledShifts.Add(shift);
                            employeeService.ScheduleEmployee(shift);

                            scheduled = true;
                            break;
                        }
                    }
                    //This covers the case were the last employee potential shift end is after or equal to the last child end time
                    if (!scheduled)
                    {
                        orderedShiftEndTimes.Remove(shiftEndTime);
                        tempChildEnds.Remove(prevTime);

                        var id = shiftEndTime.Key;
                        var name = string.Format("{0} {1}", employeeService.GetEmployee(id).FirstName, employeeService.GetEmployee(id).LastName);
                        var shift = new Shift(id, name, scheduledStartTimes[id], prevTime, room, dayOfWeek);
                        scheduledShifts.Add(shift);
                        employeeService.ScheduleEmployee(shift);
                    }
                }
            }




            //foreach (var childStartTime in childStartTimes)
            //{
            //    var validEmployees = employeeService.GetFilteredEmployees("LL", "monday", childStartTime);
            //}

            //var outerMaxHours = 10;
            //var replacements = new List<Shift[]>();
            //var MonShifts = new List<Shift>();
            //var swap = new KeyValuePair<TimeSpan, TimeSpan>();
            //var TuesShifts = new List<Shift>();
            //var WedShifts = new List<Shift>();
            //var ThurShifts = new List<Shift>();
            //var FriShifts = new List<Shift>();

            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", lambTimes[1], outerMaxHours, TuesShifts, out replacements, "LL"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", turtleTimes[1], outerMaxHours, TuesShifts, out replacements, "TT"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", bee1Times[1], outerMaxHours, TuesShifts, out replacements, "BB1"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", bee2Times[1], outerMaxHours, TuesShifts, out replacements, "BB2"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", fly1Times[1], outerMaxHours, TuesShifts, out replacements, "FF1"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", fly2Times[1], outerMaxHours, TuesShifts, out replacements, "FF2"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", horTimes[1], outerMaxHours, TuesShifts, out replacements, "BH"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", mindTimes[1], outerMaxHours, TuesShifts, out replacements, "BM"));
            //TuesShifts.AddRange(employeeService.GetIdealEmployee("tuesday", saTimes[1], outerMaxHours, TuesShifts, out replacements, "SA"));

            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", lambTimes[2], outerMaxHours, WedShifts, out replacements, "LL"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", turtleTimes[2], outerMaxHours, WedShifts, out replacements, "TT"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", bee1Times[2], outerMaxHours, WedShifts, out replacements, "BB1"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", bee2Times[2], outerMaxHours, WedShifts, out replacements, "BB2"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", fly1Times[2], outerMaxHours, WedShifts, out replacements, "FF1"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", fly2Times[2], outerMaxHours, WedShifts, out replacements, "FF2"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", horTimes[2], outerMaxHours, WedShifts, out replacements, "BH"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", mindTimes[2], outerMaxHours, WedShifts, out replacements, "BM"));
            //WedShifts.AddRange(employeeService.GetIdealEmployee("wednesday", saTimes[2], outerMaxHours, WedShifts, out replacements, "SA"));

            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", lambTimes[3], outerMaxHours, ThurShifts, out replacements, "LL"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", turtleTimes[3], outerMaxHours, ThurShifts, out replacements, "TT"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", bee1Times[3], outerMaxHours, ThurShifts, out replacements, "BB1"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", bee2Times[3], outerMaxHours, ThurShifts, out replacements, "BB2"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", fly1Times[3], outerMaxHours, ThurShifts, out replacements, "FF1"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", fly2Times[3], outerMaxHours, ThurShifts, out replacements, "FF2"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", horTimes[3], outerMaxHours, ThurShifts, out replacements, "BH"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", mindTimes[3], outerMaxHours, ThurShifts, out replacements, "BM"));
            //ThurShifts.AddRange(employeeService.GetIdealEmployee("thursday", saTimes[3], outerMaxHours, ThurShifts, out replacements, "SA"));

            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", lambTimes[4], outerMaxHours, FriShifts, out replacements, "LL"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", turtleTimes[4], outerMaxHours, FriShifts, out replacements, "TT"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", bee1Times[4], outerMaxHours, FriShifts, out replacements, "BB1"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", bee2Times[4], outerMaxHours, FriShifts, out replacements, "BB2"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", fly1Times[4], outerMaxHours, FriShifts, out replacements, "FF1"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", fly2Times[4], outerMaxHours, FriShifts, out replacements, "FF2"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", horTimes[4], outerMaxHours, FriShifts, out replacements, "BH"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", mindTimes[4], outerMaxHours, FriShifts, out replacements, "BM"));
            //FriShifts.AddRange(employeeService.GetIdealEmployee("friday", saTimes[4], outerMaxHours, FriShifts, out replacements, "SA"));

            //var allShifts = new Dictionary<string, Dictionary<string, List<Shift>>>();
            //allShifts["LL"] = new Dictionary<string, List<Shift>>();
            //allShifts["LL"]["monday"] = new List<Shift>();
            //allShifts["LL"]["tuesday"] = new List<Shift>();
            //allShifts["LL"]["wednesday"] = new List<Shift>();
            //allShifts["LL"]["thursday"] = new List<Shift>();
            //allShifts["LL"]["friday"] = new List<Shift>();

            //allShifts["TT"] = new Dictionary<string, List<Shift>>();
            //allShifts["TT"]["monday"] = new List<Shift>();
            //allShifts["TT"]["tuesday"] = new List<Shift>();
            //allShifts["TT"]["wednesday"] = new List<Shift>();
            //allShifts["TT"]["thursday"] = new List<Shift>();
            //allShifts["TT"]["friday"] = new List<Shift>();

            //allShifts["BB1"] = new Dictionary<string, List<Shift>>();
            //allShifts["BB1"]["monday"] = new List<Shift>();
            //allShifts["BB1"]["tuesday"] = new List<Shift>();
            //allShifts["BB1"]["wednesday"] = new List<Shift>();
            //allShifts["BB1"]["thursday"] = new List<Shift>();
            //allShifts["BB1"]["friday"] = new List<Shift>();

            //allShifts["BB2"] = new Dictionary<string, List<Shift>>();
            //allShifts["BB2"]["monday"] = new List<Shift>();
            //allShifts["BB2"]["tuesday"] = new List<Shift>();
            //allShifts["BB2"]["wednesday"] = new List<Shift>();
            //allShifts["BB2"]["thursday"] = new List<Shift>();
            //allShifts["BB2"]["friday"] = new List<Shift>();

            //allShifts["FF1"] = new Dictionary<string, List<Shift>>();
            //allShifts["FF1"]["monday"] = new List<Shift>();
            //allShifts["FF1"]["tuesday"] = new List<Shift>();
            //allShifts["FF1"]["wednesday"] = new List<Shift>();
            //allShifts["FF1"]["thursday"] = new List<Shift>();
            //allShifts["FF1"]["friday"] = new List<Shift>();

            //allShifts["FF2"] = new Dictionary<string, List<Shift>>();
            //allShifts["FF2"]["monday"] = new List<Shift>();
            //allShifts["FF2"]["tuesday"] = new List<Shift>();
            //allShifts["FF2"]["wednesday"] = new List<Shift>();
            //allShifts["FF2"]["thursday"] = new List<Shift>();
            //allShifts["FF2"]["friday"] = new List<Shift>();

            //allShifts["BH"] = new Dictionary<string, List<Shift>>();
            //allShifts["BH"]["monday"] = new List<Shift>();
            //allShifts["BH"]["tuesday"] = new List<Shift>();
            //allShifts["BH"]["wednesday"] = new List<Shift>();
            //allShifts["BH"]["thursday"] = new List<Shift>();
            //allShifts["BH"]["friday"] = new List<Shift>();

            //allShifts["BM"] = new Dictionary<string, List<Shift>>();
            //allShifts["BM"]["monday"] = new List<Shift>();
            //allShifts["BM"]["tuesday"] = new List<Shift>();
            //allShifts["BM"]["wednesday"] = new List<Shift>();
            //allShifts["BM"]["thursday"] = new List<Shift>();
            //allShifts["BM"]["friday"] = new List<Shift>();

            //allShifts["SA"] = new Dictionary<string, List<Shift>>();
            //allShifts["SA"]["monday"] = new List<Shift>();
            //allShifts["SA"]["tuesday"] = new List<Shift>();
            //allShifts["SA"]["wednesday"] = new List<Shift>();
            //allShifts["SA"]["thursday"] = new List<Shift>();
            //allShifts["SA"]["friday"] = new List<Shift>();

            //MonShifts.ForEach(x => allShifts[x.RoomCode][x.DayOfWeek].Add(x));
            //TuesShifts.ForEach(x => allShifts[x.RoomCode][x.DayOfWeek].Add(x));
            //WedShifts.ForEach(x => allShifts[x.RoomCode][x.DayOfWeek].Add(x));
            //ThurShifts.ForEach(x => allShifts[x.RoomCode][x.DayOfWeek].Add(x));
            //FriShifts.ForEach(x => allShifts[x.RoomCode][x.DayOfWeek].Add(x));

            //WeeklySchedulesForm weeklySchedules = new WeeklySchedulesForm(allShifts);
            //weeklySchedules.Show();
            //x = employeeService.GetIdealEmployee("tuesday", turtleTimes[1], outerMaxHours, shifts, out replacements, "TT");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", bee1Times[1], outerMaxHours, shifts, out replacements, "BB1");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", bee2Times[1], outerMaxHours, shifts, out replacements, "BB2");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", fly1Times[1], outerMaxHours, shifts, out replacements, "FF1");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", fly2Times[1], outerMaxHours, shifts, out replacements, "FF2");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", horTimes[1], outerMaxHours, shifts, out replacements, "BH");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", mindTimes[1], outerMaxHours, shifts, out replacements, "BM");
            //shifts.AddRange(x);
            //x = employeeService.GetIdealEmployee("tuesday", saTimes[1], outerMaxHours, shifts, out replacements, "SA");
            //shifts.AddRange(x);


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
        private IList<Dictionary<TimeSpan,int>> GetEmployeesNeeded(List<Child> children, int ratio, int schoolType = 0)
        {
            if (children == null || !children.Any())
            {
                return null;
            }

            var schoolStart = TimeSpan.Zero;
            var schoolEnd = TimeSpan.Zero;

            if(schoolType == 4)
            {
                schoolStart = new TimeSpan(7, 45, 0);
                schoolEnd = new TimeSpan(15, 0, 0);
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

                    if(!(schoolStart == TimeSpan.Zero) && kid.GetSchool() != "")
                    {
                        monTimesList.Add(new Time(schoolStart, false));
                        monTimesList.Add(new Time(schoolEnd, true));
                    }
                }

                if (kid.TuesStart.Hours != 0)
                {
                    tuesTimesList.Add(new Time(kid.TuesStart, true));
                    tuesTimesList.Add(new Time(kid.TuesEnd, false));

                    if (!(schoolStart == TimeSpan.Zero) && kid.GetSchool() != "")
                    {
                        tuesTimesList.Add(new Time(schoolStart, false));
                        tuesTimesList.Add(new Time(schoolEnd, true));
                    }
                }

                if (kid.WedStart.Hours != 0)
                {
                    wedTimesList.Add(new Time(kid.WedStart, true));
                    wedTimesList.Add(new Time(kid.WedEnd, false));

                    if (!(schoolStart == TimeSpan.Zero) && kid.GetSchool() != "")
                    {
                        wedTimesList.Add(new Time(schoolStart, false));
                        wedTimesList.Add(new Time(schoolEnd, true));
                    }
                }

                if (kid.ThurStart.Hours != 0)
                {
                    thurTimesList.Add(new Time(kid.ThurStart, true));
                    thurTimesList.Add(new Time(kid.ThurEnd, false));

                    if (!(schoolStart == TimeSpan.Zero) && kid.GetSchool() != "")
                    {
                        thurTimesList.Add(new Time(schoolStart, false));
                        thurTimesList.Add(new Time(schoolEnd, true));
                    }
                }

                if (kid.FriStart.Hours != 0)
                {
                    friTimesList.Add(new Time(kid.FriStart, true));
                    friTimesList.Add(new Time(kid.FriEnd, false));

                    if (!(schoolStart == TimeSpan.Zero) && kid.GetSchool() != "")
                    {
                        friTimesList.Add(new Time(schoolStart, false));
                        friTimesList.Add(new Time(schoolEnd, true));
                    }
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
