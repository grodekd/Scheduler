using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Scheduler
{
    [TestClass]
    public class ScheduleServiceTest
    {
        private ScheduleService scheduleService;
        [TestInitialize]
        public void MyTestInitialize()
        {
            scheduleService = ScheduleService.GetScheduleService();
        }

        [TestMethod]
        public void TestGetEmployeesNeeded()
        {
            var kids = new List<Child>();
            kids.Add(new Child(1, "Bill", "Bill", "LL", new TimeSpan(6,0,0), new TimeSpan(18,0,0), new TimeSpan(6,0,0), new TimeSpan(18,0,0), new TimeSpan(6,0,0), new TimeSpan(18,0,0), new TimeSpan(6,0,0), new TimeSpan(18,0,0), new TimeSpan(6,0,0), new TimeSpan(18,0,0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Bob", "Bob", "LL", new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0), new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0), new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0), new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0), new TimeSpan(8, 0, 0), new TimeSpan(16, 0, 0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Jim", "Jim", "LL", new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0), new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0), new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0), new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0), new TimeSpan(7, 0, 0), new TimeSpan(17, 0, 0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Jam", "Jam", "LL", new TimeSpan(7, 15, 0), new TimeSpan(16, 15, 0), new TimeSpan(7, 15, 0), new TimeSpan(16, 15, 0), new TimeSpan(7, 15, 0), new TimeSpan(16, 15, 0), new TimeSpan(7, 15, 0), new TimeSpan(16, 15, 0), new TimeSpan(7, 15, 0), new TimeSpan(16, 15, 0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Jam", "Jam", "LL", new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Jam", "Jam", "LL", new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), new TimeSpan(12, 30, 0), new TimeSpan(16, 30, 0), false, false, false, false, false, 0));
            kids.Add(new Child(1, "Jam", "Jam", "LL", new TimeSpan(6, 0, 0), new TimeSpan(12, 30, 0), new TimeSpan(6, 0, 0), new TimeSpan(13, 0, 0), new TimeSpan(6, 0, 0), new TimeSpan(12, 30, 0), new TimeSpan(6, 0, 0), new TimeSpan(12, 30, 0), new TimeSpan(6, 0, 0), new TimeSpan(12, 30, 0), false, false, false, false, false, 0));
            scheduleService.GetEmployeesNeeded(kids, 3);
        }
    }
}
    