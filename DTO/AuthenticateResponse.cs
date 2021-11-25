using System;

namespace FND.DTO
{
    public class AuthenticateResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string JwtToken { get; set; }
    }
}