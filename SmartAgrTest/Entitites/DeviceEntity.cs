using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Entitites
{
    public class DeviceEntity
    {
        [BsonId]
        public ObjectId Id
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

        [BsonElement("alias")]
        public string Alias
        {
            get;
            set;
        }
        
        [BsonElement("type")]
        public DeviceType Type
        {
            get;
            set;
        }

        [BsonElement("relayState")]
        public bool RelayState
        {
            get;
            set;
        }

        [BsonElement("lastActive")]
        public LastActive LastActive
        {
            get;
            set;
        }

    }

    public class DeviceType
    {
        [BsonElement("tempSensor")]
        public bool TempSensor
        {
            get;
            set;
        }

        [BsonElement("moisSensor")]
        public bool MoisSensor
        {
            get;
            set;
        }

        [BsonElement("relay")]
        public bool Relay
        {
            get;
            set;
        }
    }

    public class LastActive
    {
        [BsonElement("_created")]
        public double Created
        {
            get;
            set;
        }
        [BsonElement("_now")]
        public DateTime Now
        {
            get;
            set;
        }
        [BsonElement("_delta")]
        public int Delta
        {
            get;
            set;
        }
        [BsonElement("_defaultFormat")]
        public string DefaultFormat
        {
            get;
            set;
        }
    }
}