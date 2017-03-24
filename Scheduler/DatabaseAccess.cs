using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Scheduler
{
    public class DatabaseAccess
    {
        private static DatabaseAccess DbAccess;
        private readonly IMongoDatabase db;

        private DatabaseAccess()
        {
            const string uri = "mongodb://grod:grodPa$$@ds035786.mlab.com:35786/bethlehemscheduler";
            var client = new MongoClient(uri);
            db = client.GetDatabase("bethlehemscheduler");
        }

        public static DatabaseAccess GetDatabaseAccess()
        {
            if (DbAccess != null)
            {
                return DbAccess;
            }
            DbAccess = new DatabaseAccess();
            return DbAccess;
        }

        public string AddEmployee(Employee employee)
        {
            var employees = db.GetCollection<BsonDocument>("Employees");
            var monday = new BsonArray
            {
                new BsonDocument {{ "Start Hour", employee.MonStart.Hours }},
                new BsonDocument {{ "Start Min", employee.MonStart.Minutes }},
                new BsonDocument {{ "End Hour", employee.MonEnd.Hours }},
                new BsonDocument {{ "End Min", employee.MonEnd.Minutes }}
            };

            var tuesday = new BsonArray
            {
                new BsonDocument {{ "Start Hour", employee.TuesStart.Hours }},
                new BsonDocument {{ "Start Min", employee.TuesStart.Minutes }},
                new BsonDocument {{ "End Hour", employee.TuesEnd.Hours }},
                new BsonDocument {{ "End Min", employee.TuesEnd.Minutes }}
            };

            var wednesday = new BsonArray
            {
                new BsonDocument {{ "Start Hour", employee.WedStart.Hours }},
                new BsonDocument {{ "Start Min", employee.WedStart.Minutes }},
                new BsonDocument {{ "End Hour", employee.WedEnd.Hours }},
                new BsonDocument {{ "End Min", employee.WedEnd.Minutes }}
            };

            var thursday = new BsonArray
            {
                new BsonDocument {{ "Start Hour", employee.ThurStart.Hours }},
                new BsonDocument {{ "Start Min", employee.ThurStart.Minutes }},
                new BsonDocument {{ "End Hour", employee.ThurEnd.Hours }},
                new BsonDocument {{ "End Min", employee.ThurEnd.Minutes }}
            };

            var friday = new BsonArray
            {
                new BsonDocument {{ "Start Hour", employee.FriStart.Hours }},
                new BsonDocument {{ "Start Min", employee.FriStart.Minutes }},
                new BsonDocument {{ "End Hour", employee.FriEnd.Hours }},
                new BsonDocument {{ "End Min", employee.FriEnd.Minutes }}
            };

            var newone = new BsonDocument
            {
                {"FirstName", employee.FirstName},
                {"LastName", employee.LastName},
                {"MaxHours", employee.MaxHours},
                {"Monday", monday},
                {"Tuesday", tuesday},
                {"Wednesday", wednesday},
                {"Thursday", thursday},
                {"Friday", friday},
                {"Rooms", employee.GetRoomsBsonArray()}
            };

            employees.InsertOne(newone);

            var builder = Builders<BsonDocument>.Filter;
            var filter = builder.Eq("FirstName", employee.FirstName) & builder.Eq("LastName", employee.LastName);

            return employees.Find(filter).First()["_id"].AsObjectId.ToString();
        }

        public List<Employee> GetEmployees()
        {
            var employeesDoc = db.GetCollection<BsonDocument>("Employees");

            List<Employee> employees = new List<Employee>();
            var filter = new BsonDocument();

            employeesDoc.Find(filter).ForEachAsync(employee =>
                employees.Add(new Employee(1, employee["FirstName"].AsString, employee["LastName"].AsString, employee["MaxHours"], employee["Monday"].AsBsonArray,
                    employee["Tuesday"].AsBsonArray, employee["Wednesday"].AsBsonArray, employee["Thursday"].AsBsonArray, employee["Friday"].AsBsonArray, employee["Rooms"].AsBsonArray))
            ).Wait();

            return employees;
        }

        public List<Child> GetChildren()
        {
            var kidsDoc = db.GetCollection<BsonDocument>("Children");

            var kids = new List<Child>();
            var filter = new BsonDocument();

            kidsDoc.Find(filter).ForEachAsync(kid =>
                kids.Add(new Child(kid["_id"].AsObjectId.ToString(), kid["FirstName"].AsString, kid["LastName"].AsString, kid["Room"].AsString, kid["Monday"].AsBsonArray, kid["Tuesday"].AsBsonArray,
                    kid["Wednesday"].AsBsonArray, kid["Thursday"].AsBsonArray, kid["Friday"].AsBsonArray, kid.Contains("BreakType") ? kid["BreakType"].AsInt32 : 0 )
            )).Wait();

            return kids;
        }

        public List<Room> GetRooms()
        {
            return null; //TODO
        }
    }
}
