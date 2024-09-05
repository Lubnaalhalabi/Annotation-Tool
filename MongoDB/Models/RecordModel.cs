using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models
{
    public class RecordModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        [BsonElement("DatasetId")]
        public string DatasetId { get; set; }

        [BsonElement("Data")]
        public string Data { get; set; }

        [BsonElement("Annotation")]
        public ICollection<AnnotationModel> Annotation { get; set; }
    }
}
