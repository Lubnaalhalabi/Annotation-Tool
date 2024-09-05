using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using MongoDB.Models;

namespace MongoDB.DataAccess
{
    public class DataAccessDataset:DataAccessBase
    {       
        public DatasetModel Create(DatasetModel newdataset)
        {
            var datasetCollection = ConnectToMongo<DatasetModel>(DatasetCollection);
            datasetCollection.InsertOne(newdataset);
            return newdataset;
        }
    }
}
