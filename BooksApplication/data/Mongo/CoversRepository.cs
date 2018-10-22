using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BooksApplication.Providers;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.GridFS;

namespace BooksApplication.data.Mongo
{
    public class CoversRepository : ICoversRepository
    {
        GridFSBucket _bucket;
        public CoversRepository(MongoClientProvider mongoClientProvider)
        {
            MongoClient mongoClient = mongoClientProvider.mongoClient;
            var Database = mongoClient.GetDatabase("covers");
            _bucket = new GridFSBucket(Database);
        }
        public GridFSDownloadStream Download(ObjectId Id)
        {
            return _bucket.OpenDownloadStream(Id);
        }

        public string Upload(IFormFile file)
        {
            var Options = new GridFSUploadOptions
            {
                Metadata = new BsonDocument("contentType", file.ContentType)
            };

            using (var reader = new StreamReader((Stream)file.OpenReadStream()))
            {
                var stream = reader.BaseStream;
                var fileId = _bucket.UploadFromStream(file.FileName, stream,Options);
                return fileId.ToString();
            }

        }
    }
}
