using System;

namespace Scheduler
{
    public class Time : IComparable<Time>
    {
        public Time(TimeSpan point, bool startTime)
        {
            this.Point = point;
            this.StartTime = startTime;
        }

        public TimeSpan Point { get; private set; }
        public bool StartTime { get; private set; }

        public int CompareTo(Time other)
        {
            return Point.CompareTo(other.Point);
        }

        public static string GetTimeString(TimeSpan start, TimeSpan end)
        {
            if (start.Hours == 0) return "Off";
            var times = "";

            var startMins = start.Minutes < 10 ? "0" + start.Minutes : "" + start.Minutes;
            var endMins = end.Minutes < 10 ? "0" + end.Minutes : "" + end.Minutes;

            if (start.Hours > 12)
            {
                times += (start.Hours - 12) + ":" + startMins + " PM - ";
            }
            else
            {
                times += start.Hours + ":" + startMins + " AM - ";
            }

            if (end.Hours > 12)
            {
                times += (end.Hours - 12) + ":" + endMins + " PM";
            }
            else
            {
                times += end.Hours + ":" + endMins + " AM";
            }

            return times;
        }

        public static TimeSpan[] GetTimeSpans(string timeXml)
        {
            var startEnd = timeXml.Split(new[] { " to " }, StringSplitOptions.None);

            var startM = startEnd[0].Split(' ')[1];
            var endM = startEnd[1].Split(' ')[1];

            var startHour = Convert.ToInt32(startEnd[0].Split(' ')[0].Split(':')[0]);
            if (startM == "PM" && startHour != 12) startHour += 12;

            var endHour = Convert.ToInt32(startEnd[1].Split(' ')[0].Split(':')[0]);
            if (endM == "PM" && endHour != 12) endHour += 12;

            var startMin = Convert.ToInt32(startEnd[0].Split(' ')[0].Split(':')[1]);
            var endMin = Convert.ToInt32(startEnd[1].Split(' ')[0].Split(':')[1]);

            var returnTimes = new TimeSpan[2];

            returnTimes[0] = new TimeSpan(startHour, startMin, 0);
            returnTimes[1] = new TimeSpan(endHour, endMin, 0);

            return returnTimes;
        }

        public static TimeSpan GetTimeSpan(string hour, string min, bool pm)
        {
            if(hour == "") return new TimeSpan(0,0,0);
            var hourNumber = Convert.ToInt32(hour);
            if (pm && hourNumber != 12) hourNumber += 12;

            return new TimeSpan(hourNumber, Convert.ToInt32(min), 0);
        }

        public static string CheckTimeValidity(TimeSpan monStart, TimeSpan monEnd, TimeSpan tuesStart, TimeSpan tuesEnd, TimeSpan wedStart,
            TimeSpan wedEnd, TimeSpan thurStart, TimeSpan thurEnd, TimeSpan friStart, TimeSpan friEnd)
        {
            if (monStart.Hours != 0)
            {
                if (monStart.CompareTo(monEnd) >= 0) return "Monday's start time is before or the same as its end time.";
                if (monStart.Hours < 6 || monStart.Hours > 18) return "Monday's start time is invalid.";
                if (monEnd.Hours < 6 || monEnd.Hours > 18) return "Monday's end time is invalid.";
            }

            if (tuesStart.Hours != 0)
            {
                if (tuesStart.CompareTo(tuesEnd) >= 0) return "Tuesday's start time is before or the same as its end time.";
                if (tuesStart.Hours < 6 || tuesStart.Hours > 18) return "Tuesday's start time is invalid.";
                if (tuesEnd.Hours < 6 || tuesEnd.Hours > 18) return "Tuesday's end time is invalid.";
            }

            if (wedStart.Hours != 0)
            {
                if (wedStart.CompareTo(wedEnd) >= 0) return "Wednesday's start time is before or the same as its end time.";
                if (wedStart.Hours < 6 || wedStart.Hours > 18) return "Wednesday's start time is invalid.";
                if (wedEnd.Hours < 6 || wedEnd.Hours > 18) return "Wednesday's end time is invalid.";
            }

            if (thurStart.Hours != 0)
            {
                if (thurStart.CompareTo(thurEnd) >= 0) return "Thursday's start time is before or the same as its end time.";
                if (thurStart.Hours < 6 || thurStart.Hours > 18) return "Thursday's start time is invalid.";
                if (thurEnd.Hours < 6 || thurEnd.Hours > 18) return "Thursday's end time is invalid.";
            }

            if (friStart.Hours != 0)
            {
                if (friStart.CompareTo(friEnd) >= 0) return "Friday's start time is before or the same as its end time.";
                if (friStart.Hours < 6 || friStart.Hours > 18) return "Friday's start time is invalid.";
                if (friEnd.Hours < 6 || friEnd.Hours > 18) return "Friday's end time is invalid.";
            }

            return "";
        }

        public static double GetHoursAsDouble(TimeSpan time)
        {
            var hours = Convert.ToDouble(time.Hours);

            switch (time.Minutes)
            {
                case 15:
                    hours += .25;
                    break;
                case 30:
                    hours += .5;
                    break;
                case 45:
                    hours += .75;
                    break;
            }

            return hours;
        }
    }
}
