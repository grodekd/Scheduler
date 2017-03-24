
using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace Scheduler
{
    public class Child
    {
        public readonly string id;

        public Child(string id, string firstName, string lastName, string roomLabel, BsonArray monday, BsonArray tuesday, BsonArray wednesday, BsonArray thursday, 
            BsonArray friday, int schoolType)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoomLabel = roomLabel;
            this.MonStart = new TimeSpan(monday[1]["Start Hour"].AsInt32, monday[2]["Start Min"].AsInt32, 0);
            this.MonEnd = new TimeSpan(monday[3]["End Hour"].AsInt32, monday[4]["End Min"].AsInt32, 0);
            this.TuesStart = new TimeSpan(tuesday[1]["Start Hour"].AsInt32, tuesday[2]["Start Min"].AsInt32, 0);
            this.TuesEnd = new TimeSpan(tuesday[3]["End Hour"].AsInt32, tuesday[4]["End Min"].AsInt32, 0);
            this.WedStart = new TimeSpan(wednesday[1]["Start Hour"].AsInt32, wednesday[2]["Start Min"].AsInt32, 0);
            this.WedEnd = new TimeSpan(wednesday[3]["End Hour"].AsInt32, wednesday[4]["End Min"].AsInt32, 0);
            this.ThurStart = new TimeSpan(thursday[1]["Start Hour"].AsInt32, thursday[2]["Start Min"].AsInt32, 0);
            this.ThurEnd = new TimeSpan(thursday[3]["End Hour"].AsInt32, thursday[4]["End Min"].AsInt32, 0);
            this.FriStart = new TimeSpan(friday[1]["Start Hour"].AsInt32, friday[2]["Start Min"].AsInt32, 0);
            this.FriEnd = new TimeSpan(friday[3]["End Hour"].AsInt32, friday[4]["End Min"].AsInt32, 0);
            this.MonSchool = monday[0]["Break"].AsBoolean;
            this.TuesSchool = tuesday[0]["Break"].AsBoolean;
            this.WedSchool = wednesday[0]["Break"].AsBoolean;
            this.ThurSchool = thursday[0]["Break"].AsBoolean;
            this.FriSchool = friday[0]["Break"].AsBoolean;
            this.SchoolType = schoolType;
        }

        public Child(string id, string firstName, string lastName, string roomLabel, IList<TimeSpan> monday, IList<TimeSpan> tuesday, IList<TimeSpan> wednesday,
            IList<TimeSpan> thursday, IList<TimeSpan> friday, IList<bool> school, int schoolType)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoomLabel = roomLabel;
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
            this.MonSchool = school[0];
            this.TuesSchool = school[1];
            this.WedSchool = school[2];
            this.ThurSchool = school[3];
            this.FriSchool = school[4];
            this.SchoolType = schoolType;
        }

        public Child(string id, string firstName, string lastName, string room)
        {
            this.id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.RoomLabel = room;
            this.SchoolType = 0;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string RoomLabel { get; set; }

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

        //Used only for 4yr preschool.  This will be 0 for no school or 3yr preschool and regular school
        //Value of 1 for PM preschool (12:15 - 3:00 5 days a week)
        //Value of 2 for AM preschool (8:30 - 11:15 3 days a week MWF)
        public int SchoolType { get; set; }

        public string GetSchool()
        {
            switch (RoomLabel)
            {
                case "BH":
                    if (TuesSchool || ThurSchool)
                    {
                        return "Yes";
                    }
                    break;
                case "BM":
                    switch (SchoolType)
                    {
                        case 1:
                            return "PM";
                        case 2:
                            return "AM";
                    }
                    break;
                case "SA":
                    if (MonSchool || TuesSchool || WedSchool || ThurSchool || FriSchool)
                    {
                        return "Yes";
                    }
                    break;
            }
            return "";
        }

        public void EmptyTimes()
        {
            MonStart = TimeSpan.Zero;
            MonEnd = TimeSpan.Zero;
            TuesStart = TimeSpan.Zero;
            TuesEnd = TimeSpan.Zero;
            WedStart = TimeSpan.Zero;
            WedEnd = TimeSpan.Zero;
            ThurStart = TimeSpan.Zero;
            ThurEnd = TimeSpan.Zero;
            FriStart = TimeSpan.Zero;
            FriEnd = TimeSpan.Zero;
        }

        public string CheckTimesForValidity()
        {
            return Time.CheckTimeValidity(MonStart, MonEnd, TuesStart, TuesEnd, WedStart, WedEnd, ThurStart, ThurEnd, FriStart, FriEnd);
        }
    }
}
