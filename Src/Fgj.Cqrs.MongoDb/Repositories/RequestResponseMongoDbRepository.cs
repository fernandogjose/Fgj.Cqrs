using Fgj.Cqrs.Domain.Commands;
using Fgj.Cqrs.Domain.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.MongoDb.Helpers;
using MongoDB.Bson;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgj.Cqrs.MongoDb.Repositories
{
    public class RequestResponseMongoDbRepository : IRequestResponseMongoDbRepository
    {
        private readonly MongoDbHelper _mongoDbHelper;

        public RequestResponseMongoDbRepository(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
        }

        public async Task AdicionarAsync(RequestResponseAdicionarCommand request)
        {
            var collection = _mongoDbHelper.MongoDatabase.GetCollection<BsonDocument>("RequestResponse");
            var bsonDocumentRequest = new BsonDocument(
                new Dictionary<string, string> {
                    { "Data", request.Data.ToString("dd/MM/yyyy HH:mm") },
                    { "Request", request.Request },
                    { "Response", request.Response },
                    { "EndPoint", request.EndPoint }
                }
            );

            await collection.InsertOneAsync(bsonDocumentRequest).ConfigureAwait(false);
        }
    }
}
