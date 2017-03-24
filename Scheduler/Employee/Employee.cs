using System;
using System.Collections.Generic;
using System.Linq;
using MongoDB.Bson;

namespace Scheduler
{
    public class Employee
    {
        public readonly int id;
        private readonly Dictionary<string, int> rooms;

        public Employee(int id, string firstName, string lastName, BsonValue maxHours, BsonArray monday, BsonArray tuesday, BsonArray wednesday, BsonArray thursday,
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

            var roomList = new Dictionary<string, int>();
            if (rooms[0]["LL"].AsBoolean) roomList.Add("LL", rooms[0]["Priority"].AsInt32);
            if (rooms[1]["TT"].AsBoolean) roomList.Add("TT", rooms[1]["Priority"].AsInt32);
            if (rooms[2]["BB1"].AsBoolean) roomList.Add("BB1", rooms[2]["Priority"].AsInt32);
            if (rooms[3]["BB2"].AsBoolean) roomList.Add("BB2", rooms[3]["Priority"].AsInt32);
            if (rooms[4]["FF1"].AsBoolean) roomList.Add("FF1", rooms[4]["Priority"].AsInt32);
            if (rooms[5]["FF2"].AsBoolean) roomList.Add("FF2", rooms[5]["Priority"].AsInt32);
            if (rooms[6]["BH"].AsBoolean) roomList.Add("BH", rooms[6]["Priority"].AsInt32);
            if (rooms[7]["BM"].AsBoolean) roomList.Add("BM", rooms[7]["Priority"].AsInt32);
            if (rooms[8]["SA"].AsBoolean) roomList.Add("SA", rooms[8]["Priority"].AsInt32);

            this.rooms = roomList;
        }

        public Employee(int id, string firstName, string lastName, double maxHours, IList<TimeSpan> monday, IList<TimeSpan> tuesday,
            IList<TimeSpan> wednesday,  IList<TimeSpan> thursday, IList<TimeSpan> friday, Dictionary<string, int> rooms)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.MaxHours = maxHours;
            this.rooms = rooms;

            this.MonStart = monday[0];
            this.MonEnd = monday[1];
            this.TuesStart = tuesday[0];
            this.TuesEnd = tuesday[1];
            this.WedStart = wednesday[0];
            this.WedEnd = wednesday[1];
            this.ThurStart = thursday[0];
            this.ThurEnd = thursday[1];
            this.FriStart = friday[0];
            this.FriEnd = friday[1];
        }

        public Employee(int id, Employee employee)
        {
            this.id = id;
            this.FirstName = employee.FirstName;
            this.LastName = employee.LastName;
            this.MaxHours = employee.MaxHours;

            this.MonStart = employee.MonStart;
            this.MonEnd = employee.MonEnd;
            this.TuesStart = employee.TuesStart;
            this.TuesEnd = employee.TuesEnd;
            this.WedStart = employee.WedStart;
            this.WedEnd = employee.WedEnd;
            this.ThurStart = employee.ThurStart;
            this.ThurEnd = employee.ThurEnd;
            this.FriStart = employee.FriStart;
            this.FriEnd = employee.FriEnd;

            this.rooms = employee.GetRooms();
        }


        public int Id
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

        public TimeSpan GetStart(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "monday":
                    return MonStart;
                case "tuesday":
                    return TuesStart;
                case "wednesday":
                    return WedStart;
                case "thursday":
                    return ThurStart;
                case "friday":
                    return FriStart;
                default:
                    return new TimeSpan();
            }
        }

        public TimeSpan GetEnd(string dayOfWeek)
        {
            switch(dayOfWeek)
            {
                case "monday":
                    return MonEnd;
                case "tuesday":
                    return TuesEnd;
                case "wednesday":
                    return WedEnd;
                case "thursday":
                    return ThurEnd;
                case "friday":
                    return FriEnd;
                default:
                    return new TimeSpan();
            }
        }

        public Dictionary<string, int> GetRooms()
        {
            return rooms;
        }

        public bool HasRoom(string room)
        {
            return rooms.Keys.Contains(room);
        }

        public bool HasDay(string dayOfWeek)
        {
            switch (dayOfWeek)
            {
                case "monday":
                    return MonStart != TimeSpan.Zero;
                case "tuesday":
                    return TuesStart != TimeSpan.Zero;
                case "wednesday":
                    return WedStart != TimeSpan.Zero;
                case "thursday":
                    return ThurStart != TimeSpan.Zero;
                case "friday":
                    return FriStart != TimeSpan.Zero;
                default:
                    return false;
            }
        }

        public int GetRoomPriority(string room)
        {
            return HasRoom(room) ? rooms[room] : 0;
        }

        public bool AddRoom(string room, int priority)
        {
            if (rooms.Keys.Contains(room))
            {
                return false;
            }
            rooms.Add(room, priority);
            return true;
        }

        public bool RemoveRoom(string room)
        {
            if (!rooms.Keys.Contains(room))
            {
                return false;
            }
            rooms.Remove(room);
            return true;
        }

        public void ReplaceRooms(Dictionary<string, int> newRooms)
        {
            rooms.Clear();
            foreach (var rm in newRooms)
            {
                rooms.Add(rm.Key, rm.Value);
            }
        }

        public string GetRoomsString()
        {
            return rooms.Keys.Aggregate("", (current, room) => current + (room + " "));
        }

        public string CheckTimesForValidity()
        {
            return Time.CheckTimeValidity(MonStart, MonEnd, TuesStart, TuesEnd, WedStart, WedEnd, ThurStart, ThurEnd, FriStart, FriEnd);
        }

        public BsonArray GetRoomsBsonArray()
        {
            var lambDoc = new BsonDocument{{"LL", HasRoom("LL")}, {"Priority", GetRoomPriority("LL")}};
            var turtleDoc = new BsonDocument { { "TT", HasRoom("TT") }, { "Priority", GetRoomPriority("TT") } };
            var bee1Doc = new BsonDocument { { "BB1", HasRoom("BB1") }, { "Priority", GetRoomPriority("BB1") } };
            var bee2Doc = new BsonDocument { { "BB2", HasRoom("BB2") }, { "Priority", GetRoomPriority("BB2") } };
            var fly1Doc = new BsonDocument { { "FF1", HasRoom("FF1") }, { "Priority", GetRoomPriority("FF1") } };
            var fly2Doc = new BsonDocument { { "FF2", HasRoom("FF2") }, { "Priority", GetRoomPriority("FF2") } };
            var horizonDoc = new BsonDocument { { "BH", HasRoom("BH") }, { "Priority", GetRoomPriority("BH") } };
            var mindDoc = new BsonDocument { { "BM", HasRoom("BM") }, { "Priority", GetRoomPriority("BM") } };
            var ageDoc = new BsonDocument { { "SA", HasRoom("SA") }, { "Priority", GetRoomPriority("SA") } };

            return new BsonArray
            {
                lambDoc,
                turtleDoc,
                bee1Doc,
                bee2Doc,
                fly1Doc,
                fly2Doc,
                horizonDoc,
                mindDoc,
                ageDoc
            };
        }
    }
}
