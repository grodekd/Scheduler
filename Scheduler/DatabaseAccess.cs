using System;
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
            const string uri = "string";
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

        public async Task AddEmployee(int id, String first, String last, BsonArray times)
        {
            var employees = db.GetCollection<BsonDocument>("Employees");

            var newone = new BsonDocument
            {
                {"Id" , id},
                {"FirstName", first},
                {"LastName", last},
                {"Times", times}
            };

            await employees.InsertOneAsync(newone);
        }

        public List<Employee> GetEmployees()
        {
            var employeesDoc = db.GetCollection<BsonDocument>("Employees");

            List<Employee> employees = new List<Employee>();
            var filter = new BsonDocument();

            employeesDoc.Find(filter).ForEachAsync(employee => 
                employees.Add(new Employee(employee["_id"].AsObjectId.ToString(), employee["FirstName"].AsString, employee["LastName"].AsString))
            ).Wait();

            return null;
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
    }
}
