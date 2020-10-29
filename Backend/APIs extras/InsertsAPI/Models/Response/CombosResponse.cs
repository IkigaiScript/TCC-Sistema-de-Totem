using System;

namespace InsertsAPI.Models.Response
{
    public class CombosResponse 
    {
        public int Id { get; set; }
         public string Nome { get; set; }
        public float Preco { get; set; }
        public string Item1 { get; set; }
        public string Item2 { get; set; }
        public string Item3 { get; set; }
        public string Imagem { get; set; }
    }
}