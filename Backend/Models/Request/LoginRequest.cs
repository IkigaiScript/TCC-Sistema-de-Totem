using System;

namespace Backend.Models.Request
{
    public class LoginRequest
    {
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}