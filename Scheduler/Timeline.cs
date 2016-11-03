using System;
using System.Collections.Generic;
using System.Linq;

namespace Scheduler
{
    public class Timeline
    {
        private readonly List<TimeSpan> times;
        private readonly Dictionary<TimeSpan, int> starts;
        private readonly Dictionary<TimeSpan, int> ends; 

        public Timeline()
        {
            times = new List<TimeSpan>();
            starts = new Dictionary<TimeSpan, int>();
            ends = new Dictionary<TimeSpan, int>();
        }

        public void AddPoint(TimeSpan time, bool add)
        {
            if (!times.Contains(time))
            {
                times.Add(time);
            }

            if (add)
            {
                if (starts.ContainsKey(time))
                {
                    starts[time]++;
                }
                else
                {
                    starts.Add(time, 1);
                }
            }
            else
            {
                if (ends.ContainsKey(time))
                {
                    ends[time]++;
                }
                else
                {
                    ends.Add(time, 1);
                }
            }
        }

        public IList<TimeSpan> GetStarts()
        {
            return starts.Keys.ToList();
        }

        public IList<TimeSpan> GetEnds()
        {
            return ends.Keys.ToList();
        }

        public Dictionary<TimeSpan, int> GetEmployeeTimes(int ratio)
        {
            times.Sort();
            var kidCount = 0;
            var employeeCount = 0;
            var employeeStarts = new Dictionary<TimeSpan, int>();

            foreach (var time in times)
            {
                if (starts.ContainsKey(time) && ends.ContainsKey(time))
                {
                    kidCount = kidCount + starts[time] - ends[time];
                }
                else if (starts.ContainsKey(time))
                {
                    kidCount += starts[time];
                }
                else if(ends.ContainsKey(time))
                {
                    kidCount -= ends[time];
                }

                if (kidCount != 0)
                {
                    double x = kidCount / (double)ratio;
                    var neededEmployees = (int)Math.Ceiling(x);
                    if (employeeCount == neededEmployees)
                    {
                        continue;
                    }
                    employeeCount = neededEmployees;
                    employeeStarts.Add(time, employeeCount);
                }
                else
                {
                    employeeStarts.Add(time, 0);
                }
            }

            return employeeStarts;
        }
    }
}
