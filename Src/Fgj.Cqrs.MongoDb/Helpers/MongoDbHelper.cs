using MongoDB.Driver;
using System;

namespace Fgj.Cqrs.MongoDb.Helpers
{
    public class MongoDbHelper
    {
        private readonly string _connectionString;
        public IMongoDatabase MongoDatabase;

        public MongoDbHelper()
        {
            _connectionString = Environment.GetEnvironmentVariable("MongoDbConnection");
            CreateMongoDatabase();
        }

        private void CreateMongoDatabase()
        {
            MongoClient client = new MongoClient(_connectionString);
            MongoDatabase = client.GetDatabase("db_fgj_cqrs");
        }
    }
}