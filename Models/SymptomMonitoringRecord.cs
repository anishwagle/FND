using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class SymptomMonitoringRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public DateTime SeizureDate { get; set; }
        public DateTime SeizureTime { get; set; }
        public double SeizureDuration { get; set; }
        public string TaskDuringSeizure { get; set; }
        public string FeelingWhenSeizureStarted { get; set; }
        public string ActionTaken { get; set; }
        public string SizurePresent { get; set; }
        public string SizureResolve { get; set; }
        public string FeelingAfterSizure { get; set; }
        public string EmergencyServiceInvolved { get; set; }
    }
}
