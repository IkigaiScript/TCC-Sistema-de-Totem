using System;

namespace Backend.Models.Response
{
    public class CombosResponse
    {
        public string Imagem { get; set; }
        public int Id { get; set; }
        public string First { get; set; }
        public string Secondary { get; set; }
        public string Third { get; set; }
        public string Nome { get; set; }
        public float Preco { get; set; }
    }
}