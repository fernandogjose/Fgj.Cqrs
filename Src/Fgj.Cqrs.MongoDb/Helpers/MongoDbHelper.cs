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
            _connectionString = Environment.GetEnvironmentVariable("FGJ-CQRS-MONGODB-CONNECTION");
            CreateMongoDatabase();
        }

        private void CreateMongoDatabase()
        {
            MongoClient client = new MongoClient(_connectionString);
            MongoDatabase = client.GetDatabase("db_fgj_cqrs");
        }
    }
}