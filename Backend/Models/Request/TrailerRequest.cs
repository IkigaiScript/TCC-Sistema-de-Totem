using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Models.Request
{
    public class TrailerRequest
    {
        public int duracao { get; set; }
        public bool dublado { get; set; }
        public IFormFile trailer { get; set; }
    }
}