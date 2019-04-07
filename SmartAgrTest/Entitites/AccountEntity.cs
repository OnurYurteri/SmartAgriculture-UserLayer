using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SmartAgrTest.Entitites
{
    public class AccountEntity
    {
        [BsonId]
        public ObjectId Id
        {
            get;
            set;
        }

        [BsonElement("username")]
        public string Username
        {
            get;
            set;
        }

        [BsonElement("password")]
        public string Password
        {
            get;
            set;
        }

        [BsonElement("isAdmin")]
        public bool IsAdmin
        {
            get;
            set;
        }
    }
}