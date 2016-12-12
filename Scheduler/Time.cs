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
            if (startM == "PM") startHour += 12;

            var endHour = Convert.ToInt32(startEnd[1].Split(' ')[0].Split(':')[0]);
            if (endM == "PM") endHour += 12;

            var startMin = Convert.ToInt32(startEnd[0].Split(' ')[0].Split(':')[1]);
            var endMin = Convert.ToInt32(startEnd[1].Split(' ')[0].Split(':')[1]);

            var returnTimes = new TimeSpan[2];

            returnTimes[0] = new TimeSpan(startHour, startMin, 0);
            returnTimes[1] = new TimeSpan(endHour, endMin, 0);

            return returnTimes;
        }
    }
}
