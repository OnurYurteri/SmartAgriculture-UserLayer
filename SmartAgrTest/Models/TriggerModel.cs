using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using SmartAgrTest.Entitites;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace SmartAgrTest.Models
{
    public class TriggerModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<TriggerEntity> triggerCollection;

        public TriggerModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            triggerCollection = db.GetCollection<TriggerEntity>("Triggers");
        }

        public List<TriggerEntity> findAll()
        {
            return triggerCollection.AsQueryable<TriggerEntity>().ToList();
        }

        public bool insert(TriggerEntity trigger)
        {
            try
            {
                triggerCollection.InsertOne(trigger);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool update(TriggerEntity trigger)
        {
            try
            {
                triggerCollection.UpdateOne(
                    Builders<TriggerEntity>.Filter.Eq("_id", ObjectId.Parse(trigger.Id)),
                    Builders<TriggerEntity>.Update
                        .Set("active", trigger.Active)
                        .Set("description", trigger.Description)
                        .Set("sourceChipId", trigger.SourceChipId)
                        .Set("actionChipId", trigger.ActionChipId)
                        .Set("sourceType", trigger.SourceType)
                        .Set("fromVal", trigger.FromVal)
                        .Set("toVal", trigger.ToVal)
                        .Set("IsRule", trigger.IsRule)
                );
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}