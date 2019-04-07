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
    public class ScheduleModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<ScheduleEntity> scheduleCollection;

        public ScheduleModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            scheduleCollection = db.GetCollection<ScheduleEntity>("Schedules");
        }

        public List<ScheduleEntity> findAll()
        {
            return scheduleCollection.AsQueryable<ScheduleEntity>().ToList();
        }

        public ScheduleEntity findWithId(string _id) //PROBLEM ÇIKARABİLİR
        {
            return scheduleCollection.AsQueryable<ScheduleEntity>().SingleOrDefault(a => a.Id.Equals(_id));
        }

        public bool insert(ScheduleEntity schedule)
        {
            try
            {
                scheduleCollection.InsertOne(schedule);
                return true;
            }
            catch
            {
                return false;
            }

        }

        public bool update(ScheduleEntity schedule)
        {
            try
            {
                scheduleCollection.UpdateOne(
                    Builders<ScheduleEntity>.Filter.Eq("_id", ObjectId.Parse(schedule.Id)),
                    Builders<ScheduleEntity>.Update
                        .Set("chipId", schedule.ChipId)
                        .Set("description", schedule.Description)
                        .Set("repeatable", schedule.Repeatable)
                        .Set("occurOn", schedule.OccurOn)
                        .Set("from", schedule.From)
                        .Set("to", schedule.To)
                        .Set("active", schedule.Active)
                );
                return true;
            }
            catch
            {
                return false;
            }

        }

        public int scheduleCount()
        {
            return findAll().Count;
        }
    }
}