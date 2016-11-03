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

            //employeesDoc.Find(filter).ForEachAsync(employee => 
            //    employees.Add(new Employee(employee["Id"].AsInt32, employee["FirstName"].AsString, employee["LastName"].AsString, employee["MaxHours"].AsInt32, new TimeSpan(employee[""]), ))
            //).Wait();

            return employees;
        }
    }
}
