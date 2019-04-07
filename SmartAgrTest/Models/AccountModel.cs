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
    public class AccountModel
    {
        private MongoClient mongoClient;
        private IMongoCollection<AccountEntity> accountCollection;

        public AccountModel()
        {
            mongoClient = new MongoClient(ConfigurationManager.AppSettings["mongoDBHost"]);
            var db = mongoClient.GetDatabase(ConfigurationManager.AppSettings["mongoDBName"]);
            accountCollection = db.GetCollection<AccountEntity>("Accounts");
        }

        public List<AccountEntity> findAll()
        {
            return accountCollection.AsQueryable<AccountEntity>().ToList();
        }
        
        public AccountEntity findWithId(string id)
        {
            var accountId = new ObjectId(id);
            return accountCollection.AsQueryable<AccountEntity>().SingleOrDefault(a => a.Id == accountId);
        }

        public AccountEntity findWithUsername(string username)
        {
            return accountCollection.AsQueryable<AccountEntity>().SingleOrDefault(a => a.Username == username);
        }

        public bool create(AccountEntity account)
        {
            try
            {
                accountCollection.InsertOne(account);
                return true;
            }
            catch
            {
                return false;
            }
            
        }
        
        public bool update(AccountEntity account)
        {
            try
            {
                accountCollection.UpdateOne(
                    Builders<AccountEntity>.Filter.Eq("_id", account.Id),
                    Builders<AccountEntity>.Update
                        .Set("username", account.Username)
                        .Set("password", account.Password)
                        .Set("isAdmin", account.IsAdmin)
                );
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        public bool delete(string id)
        {
            try
            {
                accountCollection.DeleteOne(
                    Builders<AccountEntity>.Filter.Eq("_id", ObjectId.Parse(id))
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