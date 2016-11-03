
using System;

namespace Scheduler
{
    public class Child
    {
        private readonly int id;

        public Child(int id, String firstName, String lastName, String roomLabel, TimeSpan monStart, TimeSpan monEnd, TimeSpan tuesStart,
            TimeSpan tuesEnd, TimeSpan wedStart, TimeSpan wedEnd, TimeSpan thurStart, TimeSpan thurEnd, TimeSpan friStart,
             TimeSpan friEnd, bool monSchool, bool tuesSchool, bool wedSchool, bool thurSchool, bool friSchool, int schoolType)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoomLabel = roomLabel;
            this.MonStart = monStart;
            this.MonEnd = monEnd;
            this.TuesStart = tuesStart;
            this.TuesEnd = tuesEnd;
            this.WedStart = wedStart;
            this.WedEnd = wedEnd;
            this.ThurStart = thurStart;
            this.ThurEnd = thurEnd;
            this.FriStart = friStart;
            this.FriEnd = friEnd;
            this.MonSchool = monSchool;
            this.TuesSchool = tuesSchool;
            this.WedSchool = wedSchool;
            this.ThurSchool = thurSchool;
            this.FriSchool = friSchool;
            this.SchoolType = schoolType;
        }

        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String RoomLabel { get; set; }

        public TimeSpan MonStart { get; set; }
        public TimeSpan MonEnd { get; set; }
        public TimeSpan TuesStart { get; set; }
        public TimeSpan TuesEnd { get; set; }
        public TimeSpan WedStart { get; set; }
        public TimeSpan WedEnd { get; set; }
        public TimeSpan ThurStart { get; set; }
        public TimeSpan ThurEnd { get; set; }
        public TimeSpan FriStart { get; set; }
        public TimeSpan FriEnd { get; set; }

        public bool MonSchool { get; set; }
        public bool TuesSchool { get; set; }
        public bool WedSchool { get; set; }
        public bool ThurSchool { get; set; }
        public bool FriSchool { get; set; }

        public int SchoolType { get; set; }
    }
}
