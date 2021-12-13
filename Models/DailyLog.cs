using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class DailyLog
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Type { get; set; }
        public List<Log> Logs { get; set; }
        public User User { get; set; }
    }

    public class Log
    {
        public DateTime Time { get; set; }
        public string Rate { get; set; }
        public string Field { get; set; }
    }
}
