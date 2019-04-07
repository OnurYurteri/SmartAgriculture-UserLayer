using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Entitites
{
    public class ScheduleEntity
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id
        {
            get;
            set;
        }
        
        [BsonElement("chipId")]
        public string ChipId
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

        [BsonElement("repeatable")]
        public bool Repeatable
        {
            get;
            set;
        }

        [BsonElement("occurOn")]
        public OccurOn OccurOn
        {
            get;
            set;
        }

        [BsonElement("from")]
        public DateTime From
        {
            get;
            set;
        }

        [BsonElement("to")]
        public DateTime To
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
    }

    public class OccurOn
    {
        [BsonElement("monday")]
        public bool Monday
        {
            get;
            set;
        }

        [BsonElement("tuesday")]
        public bool Tuesday
        {
            get;
            set;
        }

        [BsonElement("wednesday")]
        public bool Wednesday
        {
            get;
            set;
        }

        [BsonElement("thursday")]
        public bool Thursday
        {
            get;
            set;
        }

        [BsonElement("friday")]
        public bool Friday
        {
            get;
            set;
        }

        [BsonElement("saturday")]
        public bool Saturday
        {
            get;
            set;
        }

        [BsonElement("sunday")]
        public bool Sunday
        {
            get;
            set;
        }
    }
}