using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Driver.GridFS;

namespace BooksApplication.data.Mongo
{
    public interface ICoversRepository
    {
        string Upload(IFormFile file);

        GridFSDownloadStream Download(ObjectId Id);
    }
}
