namespace Scheduler
{
    public class Room
    {
        public Room(string name, string desc, string code, int ratio, int capacity)
        {
            this.Name = name;
            this.Desc = desc;
            this.Code = code;
            this.Ratio = ratio;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public string Desc { get; set; }
        public string Code { get; set; }
        public int Ratio { get; set; }
        public int Capacity { get; set; }

        public static string GetRoomLabelFromName(string roomName)
        {
            if (roomName.ToLower().Contains("young infants")) 
                return "LL";

            if (roomName.ToLower().Contains("mobile infants")) 
                return "TT";

            if (roomName.ToLower().Contains("young toddlers")) 
                return "BB1";

            if (roomName.ToLower().Contains("mature toddlers")) 
                return "BB2";

            if (roomName.ToLower().Contains("young twos")) 
                return "FF1";

            if (roomName.ToLower().Contains("mature twos")) 
                return "FF2";

            if (roomName.ToLower().Contains("three-year-old preschool")) 
                return "BH";

            if (roomName.ToLower().Contains("four-year-old preschool")) 
                return "BM";

            return roomName.ToLower().Contains("school age") ? "SA" : "";
        }
    }
}
