using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;

namespace FND.Models
{
    public class Contact
    {
        public string Name { get; set; }
        public string RelationShip{ get; set; }
        public string Phone { get; set; }
        public string HomePhone { get; set; }
        public string Address { get; set; }
        public string Profession { get; set; }
    }
}