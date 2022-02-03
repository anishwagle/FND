using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class UserInfo
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public User User { get; set; }
        public string Phone { get; set; }
        public DateTime DOB { get; set; }
       
        public string Gender { get; set; }
        public Contact EmergencyEontact { get; set; }
        public Contact DoctorDetail { get; set; }
    }
    
}
