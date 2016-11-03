using System;

namespace Scheduler
{
    public class Room
    {
        public Room(String name, String desc, String code, int ratio, int capacity)
        {
            this.Name = name;
            this.Desc = desc;
            this.Code = code;
            this.Ratio = ratio;
            this.Capacity = capacity;
        }

        public String Name { get; set; }
        public String Desc { get; set; }
        public String Code { get; set; }
        public int Ratio { get; set; }
        public int Capacity { get; set; }
    }
}
