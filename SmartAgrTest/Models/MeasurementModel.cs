using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Bson;
using MongoDB.Driver;
using SmartAgrTest.Entitites;
using System.Configuration;

namespace SmartAgrTest.Models
{
    public class MeasurementModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<MeasurementEntity> measurementCollection;

        public MeasurementModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            measurementCollection = db.GetCollection<MeasurementEntity>("Measurements");
        }

        public MeasurementEntity getLastDeviceMeasurement(string chipId)
        {
            return measurementCollection.Find(x => x.ChipId.Equals(chipId))
                .Limit(1)
                .Sort("{_id: -1}").Single();
        }
        
        public List<MeasurementEntity> getMeasurementsBetweenDates(string chipId, DateTime from, DateTime to)
        {
            var filterBuilder = Builders<MeasurementEntity>.Filter;
            var filter = filterBuilder.Eq(x => x.ChipId, chipId) & filterBuilder.Gte(x => x.DateTime.Now, from) & filterBuilder.Lte(x => x.DateTime.Now, to);
            return measurementCollection.Find(filter).ToList();
        }
    }
}