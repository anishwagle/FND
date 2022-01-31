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
        public string onMedication { get; set; }
        public string Medication { get; set; }
        public List<string> MedicalCondition { get; set; }
        public string MedicalHistory { get; set; }
        public List<string> WarningSign { get; set; }
        public string WarningSignText { get; set; }
        public List<string> SeizureType { get; set; }
        public string SeizureTypeText { get; set; }
        public List<string> SeizurePresent { get; set; }
        public string SeizurePresentText { get; set; }

        public string DurationOfSeizure { get; set; }
        public string FrequencyOfSeizure { get; set; }
        public List<string> AssistanceRequired { get; set; }
        public string AssistanceRequiredText { get; set; }
        public List<string> NotDo { get; set; }
        public string NotDoText { get; set; }
        public List<string> NeedAfterSeizure { get; set; }
        public string NeedAfterSeizureText { get; set; }
        public List<string> AmbulanceNeeded { get; set; }
        public string AmbulanceNeededText { get; set; }
    }
}
