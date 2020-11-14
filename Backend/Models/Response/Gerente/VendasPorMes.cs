using System;
namespace Backend.Models.Response.Gerente
{
    public class VendasPorMes
    {
        public string Mes { get; set; }
        public int Qtd { get; set; }
        public float Total { get; set; }
    }
}