using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class SMRForm{
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public DateTime DateOfSeizure { get; set; }
        public DateTime TimeOfSeizure { get; set; }
        public string WhatDoingSeizureStarted { get; set; }
        public List<string> HowFeelingSeizureStarted { get; set; }
        public string HowFeelingSeizureStartedText { get; set; }
        public List<string> ActionTaken { get; set; }
        public string ActionTakenText { get; set; }
        public List<string> SeizurePresent { get; set; }
        public string SeizurePresentText { get; set; }
        public string SeizureResolve { get; set; }
        public List<string> FeelingAfterSeizure { get; set; }
        public string FeelingAfterSeizureText { get; set; }
        public string EmergencyService { get; set; }
    }
}
