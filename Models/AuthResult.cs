using System;

namespace HorizonPollyC.Models
{
    public class AuthResult
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}
