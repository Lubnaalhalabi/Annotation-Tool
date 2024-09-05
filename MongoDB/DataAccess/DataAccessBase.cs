using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Driver;

namespace MongoDB.DataAccess
{
    public class DataAccessBase
    {
        public const string ConnectionString = "mongodb://localhost:27017";
        public const string DatabaseName = "AnnotationTool";
        public const string DatasetCollection = "Dataset";
        public const string RecordCollection = "Record";

        public IMongoCollection<T> ConnectToMongo<T>(in string collection)
        {
            var client = new MongoClient(ConnectionString);
            var db = client.GetDatabase(DatabaseName);
            return db.GetCollection<T>(collection);
        }
    }
}
