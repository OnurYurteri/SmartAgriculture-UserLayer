using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Entitites
{
    public class MeasurementEntity
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

        [BsonElement("humidity")]
        public double Humidity
        {
            get;
            set;
        }

        [BsonElement("temperature")]
        public double Temperature
        {
            get;
            set;
        }

        [BsonElement("heatIndex")]
        public double HeatIndex
        {
            get;
            set;
        }

        [BsonElement("moisture")]
        public double Moisture
        {
            get;
            set;
        }

        [BsonElement("datetime")]
        public LastActive DateTime
        {
            get;
            set;
        }
    }
}