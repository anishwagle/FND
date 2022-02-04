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
        public string MoodValue { get; set; }
        public string MoodText { get; set; }
        public string sleepQualityValue { get; set; }
        public string sleepQualityText { get; set; }
        public string stressLevelValue { get; set; }
        public string stressLevelText { get; set; }
        public string pwrValue { get; set; }
        public string pwrText { get; set; }
        public string sleepDurationValue { get; set; }
        public string sleepDurationText { get; set; }
        public string palValue { get; set; }
        public string palText { get; set; }
        public string dailyAchievementText { get; set; }
        public DateTime createdAt { get; set; }
        public User User { get; set; }
    }

}
