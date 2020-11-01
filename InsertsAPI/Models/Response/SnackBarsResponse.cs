using System;

namespace InsertsAPI.Models.Response
{
    public class SnackBarsResponse 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Tipo { get; set; }
        public string Sabor { get; set; }
        public string Peso { get; set; }
        public string Marca { get; set; }
        public int Estoque { get; set; }
        public string Imagem { get; set; }
        public float Preco { get; set; }
    }
}