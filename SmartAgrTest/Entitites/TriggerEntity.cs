using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Entitites
{
    public class TriggerEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }

        [BsonElement("active")]
        public bool Active
        {
            get;
            set;
        }

        [BsonElement("sourceChipId")]
        public string SourceChipId
        {
            get;
            set;
        }

        [BsonElement("actionChipId")]
        public string ActionChipId
        {
            get;
            set;
        }

        [BsonElement("sourceType")]
        public string SourceType
        {
            get;
            set;
        }

        [BsonElement("fromVal")]
        public double FromVal
        {
            get;
            set;
        }

        [BsonElement("toVal")]
        public double ToVal
        {
            get;
            set;
        }

        [BsonElement("isRule")]
        public bool IsRule
        {
            get;
            set;
        }
    }
}