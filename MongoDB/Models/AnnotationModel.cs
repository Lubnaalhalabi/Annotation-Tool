using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models
{
    public class AnnotationModel
    {
        [BsonElement("AnntatorId")]

        public string AnntatorId { get; set; }

        [BsonElement("AnnotationResult")]
        public AnnotationResultModel AnnotationResult { get; set; }
        public AnnotationResultModel AIAnnotationResult { get; set; }

        [BsonElement("AnnotationDate")]
        public DateTime AnnotationDate { get; set; }

    }
}
