using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.DataAccess;

namespace MongoDB.MongoUOW
{
    public class MongoUOW : IMongoUOW
    {
        public DataAccessDataset Dataset { get; set; }
        public DataAccessRecord Record { get; set; }
    
        public MongoUOW()
        {
            Dataset = new DataAccessDataset();
            Record = new DataAccessRecord();
        }
    }
}
