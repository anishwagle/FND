using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class SMPForm{
          [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateOfPlan { get; set; }
        public DateTime createdAt { get; set; }
        public string OnMedication { get; set; }
        public string Medication { get; set; }
        public List<string> MedicalConditions { get; set; }
        public string MedicalHistory { get; set; }
        public List<string> WarningSigns { get; set; }
        public string WarningSignsText { get; set; }
        public string SeizureType { get; set; }
        public string SeizureTypeText { get; set; }
        public List<string> SeizurePresent { get; set; }
        public string SeizurePresentText { get; set; }
        public string DurationOfSeizure { get; set; }
        public string Frequency { get; set; }
        public string FrequencyUnit { get; set; }
        public List<string> AssistanceRequired { get; set; }
        public string AssistanceRequiredText { get; set; }
        public List<string> NotDo { get; set; }
        public string NotDoText { get; set; }
        public string NeedAfterSeizure { get; set; }
        public string NeedAfterSeizureText { get; set; }
        public List<string> ambulanceNeeded { get; set; }
        public string ambulanceNeededText { get; set; }
    }
}
