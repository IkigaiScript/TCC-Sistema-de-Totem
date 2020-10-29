using System;
using Microsoft.AspNetCore.Http;

namespace InsertsAPI.Models.Request
{
    public class SnackBarsRequest
    {
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Sabor { get; set; }
        public string Peso { get; set; }
        public string Marca { get; set; }
        public int Estoque { get; set; }
        public IFormFile Imagem { get; set; }
        public float Preco { get; set; }
    }
}