using System;
using System.Collections.Generic;

namespace Scheduler
{
    public class Employee
    {
        private readonly string id;
        private readonly List<string> rooms; 

        public Employee(string id, String firstName, String lastName, int maxHours, TimeSpan monStart, TimeSpan monEnd, TimeSpan tuesStart, TimeSpan tuesEnd,
            TimeSpan wedStart, TimeSpan wedEnd, TimeSpan thurStart, TimeSpan thurEnd, TimeSpan friStart, TimeSpan friEnd, List<string> rooms)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MaxHours = maxHours;

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

            this.rooms = rooms;
        }

        public Employee(string id, string firstName, string lastName)
            : this(id, firstName, lastName, 0, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, TimeSpan.Zero, null)
        { 
        }

        public string Id
        {
            get { return id; }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int MaxHours { get; set; }

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

        public bool HasRoom(string room)
        {
            return rooms.Contains(room);
        }

        public bool AddRoom(string room)
        {
            if (rooms.Contains(room))
            {
                return false;
            }
            rooms.Add(room);
            return true;
        }

        public bool RemoveRoom(string room)
        {
            if (!rooms.Contains(room))
            {
                return false;
            }
            rooms.Remove(room);
            return true;
        }
    }
}
