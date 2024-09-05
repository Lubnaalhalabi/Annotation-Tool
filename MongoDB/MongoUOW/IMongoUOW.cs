using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.DataAccess;

namespace MongoDB.MongoUOW
{
    public interface IMongoUOW
    {
        public DataAccessDataset Dataset { get; set; }
        public DataAccessRecord Record { get; set; }
    }
}
