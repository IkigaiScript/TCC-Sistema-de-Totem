using System;
using Microsoft.AspNetCore.Http;

namespace InsertsAPI.Models.Request
{
    public class CombosRequest
    {
        public string Nome { get; set; }
        public float Preco { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public IFormFile Imagem { get; set; }
    }
}