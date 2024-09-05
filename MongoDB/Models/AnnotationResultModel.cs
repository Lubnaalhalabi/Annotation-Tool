using System;
using System.Collections.Generic;
using System.Text;
using MongoDB.Bson.Serialization.Attributes;

namespace MongoDB.Models
{
    public class AnnotationResultModel
    {
        [BsonElement("Classes")]

        public List<string> Classes { get; set; }
    }
}
