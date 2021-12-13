using System;
using FND.Models;

namespace FND.DTO
{
    public class DailyLogRequest
    {
        public string Type { get; set; }
        public Log Log { get; set; }
        public User User { get; set; }
    }
}