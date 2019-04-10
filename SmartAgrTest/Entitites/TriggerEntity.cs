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

        [BsonElement("description")]
        public string Description
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
        public SourceType SourceType
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

    public class SourceType
    {
        [BsonElement("temperature")]
        public bool Temperature
        {
            get;
            set;
        }

        [BsonElement("humidity")]
        public bool Humidity
        {
            get;
            set;
        }

        [BsonElement("moisture")]
        public bool Moisture
        {
            get;
            set;
        }
    }
}