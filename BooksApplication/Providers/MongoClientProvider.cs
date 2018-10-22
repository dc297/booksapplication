using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BooksApplication.Providers
{
    public class MongoClientProvider
    {
        public readonly MongoClient mongoClient;
        public MongoClientProvider(string connectString)
        {
            mongoClient = new MongoClient(connectString);
        }
    }
}
