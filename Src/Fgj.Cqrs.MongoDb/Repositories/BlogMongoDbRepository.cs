using Fgj.Cqrs.Domain.Blog.Commands;
using Fgj.Cqrs.Domain.Blog.Interfaces.MongoDbRepositories;
using Fgj.Cqrs.Domain.Blog.Queries;
using Fgj.Cqrs.MongoDb.Helpers;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Fgj.Cqrs.MongoDb.Repositories
{
    public class BlogMongoDbRepository : IBlogMongoDbRepository
    {
        private readonly MongoDbHelper _mongoDbHelper;
        private readonly IMongoCollection<BsonDocument> _collection;

        public BlogMongoDbRepository(MongoDbHelper mongoDbHelper)
        {
            _mongoDbHelper = mongoDbHelper;
            _collection = _mongoDbHelper.MongoDatabase.GetCollection<BsonDocument>("Blog");
        }

        private List<BlogGetAllResponseQuery> Map(IAsyncCursor<BsonDocument> bsonDocuments)
        {
            List<BlogGetAllResponseQuery> response = new List<BlogGetAllResponseQuery>(0);

            foreach (var bsonDocument in bsonDocuments.ToList())
            {
                BlogGetAllResponseQuery blogGetAllResponseQuery = Map(bsonDocument);
                if (blogGetAllResponseQuery == null) continue;
                response.Add(blogGetAllResponseQuery);
            }

            return response;
        }

        private BlogGetAllResponseQuery Map(BsonDocument bsonDocument)
        {
            if (bsonDocument == null)
            {
                return null;
            }

            BlogGetAllResponseQuery response = new BlogGetAllResponseQuery(
                Convert.ToDateTime(bsonDocument.GetValue("Date").ToString()),
                bsonDocument.GetValue("Guid").ToString(),
                bsonDocument.GetValue("Title").ToString(),
                bsonDocument.GetValue("Description").ToString(),
                bsonDocument.GetValue("Image").ToString(),
                bsonDocument.GetValue("Tag").ToString(),
                bsonDocument.GetValue("Url").ToString()
            );

            return response;
        }

        public async Task CreateAsync(BlogCreateCommand request)
        {
            var bsonDocumentRequest = new BsonDocument(
                new Dictionary<string, string> {
                    { "Guid", Guid.NewGuid().ToString() },
                    { "Date", DateTime.Now.ToString("dd/MM/yyyy HH:mm") },
                    { "Title", request.Title },
                    { "Description", request.Description },
                    { "Image", request.Image },
                    { "Tag", request.Tag },
                    { "Url", request.Url }
                }
            );

            await _collection.InsertOneAsync(bsonDocumentRequest).ConfigureAwait(false);
        }

        public async Task<List<BlogGetAllResponseQuery>> GetAllAsync()
        {
            //FilterDefinitionBuilder<BsonDocument> builder = Builders<BsonDocument>.Filter;
            //FilterDefinition<BsonDocument> filter = builder.Eq("Desenvolvedor", request.Desenvolvedor);
            IAsyncCursor<BsonDocument> bsonDocuments = _collection.FindAsync(new BsonDocument()).GetAwaiter().GetResult();
            List<BlogGetAllResponseQuery> response = Map(bsonDocuments);
            return response;
        }
    }
}
