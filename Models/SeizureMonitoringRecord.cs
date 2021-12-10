using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class SeizureMonitoringRecord
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public string AssistanceRequiredFromPeople { get; set; }
        public string UnwantedSeizureThings { get; set; }
        public string NeededAfterSeizure { get; set; }
        public string CallAmbulance { get; set; }
        public string PatientName { get; set; }
        public string EmergencyContact { get; set; }
        public string RelationshipToPatient { get; set; }
    }
}
