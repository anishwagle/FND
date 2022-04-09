using System;

namespace FND.DTO
{
    public class PasswordResetRequest
    {
        public string EmailId { get; set; }
        public string Token { get; set; }
        public string  NewPassword { get; set; }

    }
}