using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public UserPasswordResetToken PasswordResetToken { get; set; }
        

    }
    public class UserPasswordResetToken{
        public string Token { get; set; }
        public DateTime ValidTill { get; set; }
    }
}
