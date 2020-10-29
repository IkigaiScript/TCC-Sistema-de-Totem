using System;
using Microsoft.AspNetCore.Http;

namespace InsertsAPI.Models.Request
{
    public class FilmesRequest
    {
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
        public IFormFile Imagem { get; set; }
        public string Genero { get; set; }
        public bool Estreia { get; set; }
        public bool Breve { get; set; }
    }
}