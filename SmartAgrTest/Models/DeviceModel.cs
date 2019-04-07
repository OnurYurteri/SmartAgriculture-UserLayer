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
    public class DeviceModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<DeviceEntity> deviceCollection;

        public DeviceModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            deviceCollection = db.GetCollection<DeviceEntity>("Devices");
        }
        public List<DeviceEntity> findAll()
        {
            return deviceCollection.AsQueryable<DeviceEntity>().ToList();
        }
        public DeviceEntity findWithChipId(string _chipId)
        {
            return deviceCollection.AsQueryable<DeviceEntity>().SingleOrDefault(a => a.ChipId == _chipId);
        }
        public bool update(DeviceEntity device)
        {
            try
            {
                deviceCollection.UpdateOne(
                    Builders<DeviceEntity>.Filter.Eq("chipId", device.ChipId),
                    Builders<DeviceEntity>.Update
                        .Set("alias", device.Alias)
                );
                return true;
            }
            catch
            {
                return false;
            }

        }
        public List<DeviceEntity> findRelays()
        {
            return deviceCollection.Find(a => a.Type.Relay == true).ToList();
        }
        //UPDATE PROBLEM ÇIKARABİLİR

        public int deviceCount()
        {
            return findAll().Count;
        }
    }
}