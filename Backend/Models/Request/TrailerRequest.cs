using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Models.Request
{
    public class TrailerRequest
    {
        public int Filme { get; set; }
        public int Duracao { get; set; }
        public bool Dublado { get; set; }
        public IFormFile Trailer { get; set; }
    }
}