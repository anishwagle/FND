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
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfPlan { get; set; }
        public bool OnMedication { get; set; }
        public string Medication { get; set; }
        public List<string> MedicalConditions { get; set; }
        public string MedicalHistory { get; set; }
        public Contact EmergencyContact { get; set; }
        public Contact DoctorContact { get; set; }
        public string WarningSign { get; set; }
        public string SeizureType { get; set; }
        public string PresentSeizureCondition { get; set; }
        public string SeizureDuration { get; set; }
        public string Frequenty { get; set; }
        public string FrequencyUnit { get; set; }
        public string AssistanceRequiredFromPeople { get; set; }
        public string UnwantedSeizureThings { get; set; }
        public string NeededAfterSeizure { get; set; }
        public string CallAmbulance { get; set; }
        public string PatientName { get; set; }
        public string RelationshipToPatient { get; set; }
    }
    public class Contact{
        public string Name { get; set; }
        public string RelationShip{ get; set; }
        public string Phone { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
    }
}
