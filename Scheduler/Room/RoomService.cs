using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Scheduler
{
    public class RoomService
    {
        private static RoomService RoomServiceInstance;
        private readonly List<Room> rooms;

        private RoomService()
        {
            rooms = new List<Room>
            {
                new Room("Little Lambs", "Young Infants", "LL", 3, 9),
                new Room("Tiny Turtles", "Mobile Infants", "TT", 3, 12),
                new Room("Bumblebee Forest 1", "Young Toddlers", "BB1", 3, 12),
                new Room("Bumblebee Forest 2", "Mature Toddlers", "BB2", 3, 12),
                new Room("Fireflies 1", "Young 2's", "FF1", 4, 12),
                new Room("Fireflies 2", "Mature 2's", "FF2", 4, 12),
                new Room("Bright Horizons", "Three's", "BH", 10, 24),
                new Room("Bright Minds", "Four's", "BM", 10, 24),
                new Room("School Age", "School Age", "SA", 12, 0)
            };
        }

        public static RoomService GetRoomService()
        {
            if (RoomServiceInstance != null)
            {
                return RoomServiceInstance;
            }
            RoomServiceInstance = new RoomService();
            return RoomServiceInstance;
        }

        public Room GetRoom(string roomLabel)
        {
            return rooms.First(room => room.Code == roomLabel);
        }

        public Dictionary<string, Room> GetRoomsLookup()
        {
            return rooms.ToDictionary(x => x.Code, x => x);
        }

        public List<Room> GetRooms()
        {
            return rooms;
        }
        public void UpdateRoom(Room room)
        {
            var index = rooms.FindIndex(x => x.Code == room.Code);

            rooms[index].Name = room.Name;
            rooms[index].Desc = room.Desc;
            rooms[index].Ratio = room.Ratio;
            rooms[index].Capacity = room.Capacity;
        }

        public DataTable GetRoomDataTable()
        {
            var table = new DataTable();
            table.Columns.Add("Room Name", typeof(string));
            table.Columns.Add("Description", typeof(string));
            table.Columns.Add("Room Label", typeof(string));
            table.Columns.Add("Ratio", typeof(int));
            table.Columns.Add("Capacity", typeof(int));

            foreach (var room in rooms)
            {
                table.Rows.Add(room.Name, room.Desc, room.Code, room.Ratio, room.Capacity);
            }

            return table;
        }
    }
}
