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
    }
}
