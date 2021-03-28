using ConsoleApp1.Db;
using ConsoleApp1.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace ConsoleApp1.Interfaces {
    class MongoDBWaifusRepository : IWaifusRepository {
        private const string databaseName = "waifu";
        private const string collectionName = "waifus";
        private MongoClient mongoClient;
        private IMongoCollection<Waifu> collectionRef;

        public MongoDBWaifusRepository() {
            this.mongoClient = new("mongodb://root:secret@localhost:27050");
            collectionRef = this.mongoClient.GetDatabase(databaseName).GetCollection<Waifu>(collectionName);
        }

        public void CreateWaifu(Waifu waifu) {
            collectionRef.InsertOne(waifu);
        }

        public List<Waifu> GetWaifus() {
            return collectionRef.Find(_ => true).ToList();
        }
    }
}
