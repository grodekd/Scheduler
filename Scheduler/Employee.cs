using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Scheduler
{
    public class Employee : Person
    {
        private readonly string id;
        private readonly List<string> rooms;

        public Employee(string id, String firstName, String lastName, BsonValue maxHours, BsonArray monday, BsonArray tuesday, BsonArray wednesday, BsonArray thursday,
            BsonArray friday, BsonArray rooms)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MaxHours = maxHours.IsInt32 ? maxHours.AsInt32 : maxHours.AsDouble;

            this.MonStart = new TimeSpan(monday[0]["Start Hour"].AsInt32, monday[1]["Start Min"].AsInt32, 0);
            this.MonEnd = new TimeSpan(monday[2]["End Hour"].AsInt32, monday[3]["End Min"].AsInt32, 0);
            this.TuesStart = new TimeSpan(tuesday[0]["Start Hour"].AsInt32, tuesday[1]["Start Min"].AsInt32, 0);
            this.TuesEnd = new TimeSpan(tuesday[2]["End Hour"].AsInt32, tuesday[3]["End Min"].AsInt32, 0);
            this.WedStart = new TimeSpan(wednesday[0]["Start Hour"].AsInt32, wednesday[1]["Start Min"].AsInt32, 0);
            this.WedEnd = new TimeSpan(wednesday[2]["End Hour"].AsInt32, wednesday[3]["End Min"].AsInt32, 0);
            this.ThurStart = new TimeSpan(thursday[0]["Start Hour"].AsInt32, thursday[1]["Start Min"].AsInt32, 0);
            this.ThurEnd = new TimeSpan(thursday[2]["End Hour"].AsInt32, thursday[3]["End Min"].AsInt32, 0);
            this.FriStart = new TimeSpan(friday[0]["Start Hour"].AsInt32, friday[1]["Start Min"].AsInt32, 0);
            this.FriEnd = new TimeSpan(friday[2]["End Hour"].AsInt32, friday[3]["End Min"].AsInt32, 0);

            var roomList = new List<string>();
            if (rooms[0]["LL"].AsBoolean) roomList.Add("LL");
            if (rooms[1]["TT"].AsBoolean) roomList.Add("TT");
            if (rooms[2]["BB1"].AsBoolean) roomList.Add("BB1");
            if (rooms[3]["BB2"].AsBoolean) roomList.Add("BB2");
            if (rooms[4]["FF1"].AsBoolean) roomList.Add("FF1");
            if (rooms[5]["FF2"].AsBoolean) roomList.Add("FF2");
            if (rooms[6]["BH"].AsBoolean) roomList.Add("BH");
            if (rooms[7]["BM"].AsBoolean) roomList.Add("BM");
            if (rooms[8]["SA"].AsBoolean) roomList.Add("SA");

            this.rooms = roomList;
        }

        public Employee(string id, String firstName, String lastName, double maxHours)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MaxHours = maxHours;

            this.MonStart = TimeSpan.Zero;
            this.MonEnd = TimeSpan.Zero;
            this.TuesStart = TimeSpan.Zero;
            this.TuesEnd = TimeSpan.Zero;
            this.WedStart = TimeSpan.Zero;
            this.WedEnd = TimeSpan.Zero;
            this.ThurStart = TimeSpan.Zero;
            this.ThurEnd = TimeSpan.Zero;
            this.FriStart = TimeSpan.Zero;
            this.FriEnd = TimeSpan.Zero;

            this.rooms = new List<string>{"LL", "TT"};
        }


        public string Id
        {
            get { return id; }
        }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public double MaxHours { get; set; }

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

        public string GetRoomsString()
        {
            return rooms.Aggregate("", (current, room) => current + (room + " "));
        }
    }
}
