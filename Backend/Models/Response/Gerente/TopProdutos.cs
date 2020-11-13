using System;

namespace Backend.Models.Response.Gerente
{
    public class TopProdutos
    {
        public string Nome { get; set; }
        public string Imagem { get; set; }
        public string Tipo { get; set; }
        public float Total { get; set; }
        public int Qtd { get; set; }
        public float Valor { get; set; }
    }
}