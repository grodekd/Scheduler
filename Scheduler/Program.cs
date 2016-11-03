using System;
using MongoDB.Bson;

namespace Scheduler
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var dbAccess = DatabaseAccess.GetDatabaseAccess();

            //dbAccess.AddEmployee(2, "Another", "One", new BsonArray
            //{
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}},
            //    new BsonDocument{{"start", 9}, {"end", 5}}
            //}).Wait();

            //var employees = dbAccess.GetEmployees();
            Console.WriteLine("butts");
        }
    }
}
