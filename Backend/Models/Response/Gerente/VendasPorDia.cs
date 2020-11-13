using System;

namespace Backend.Models.Response.Gerente
{
    public class VendasPorDia
    {
        public int Pedido { get; set; }
        public string Cliente { get; set; }
        public string Total  { get; set; }
        public string Dia { get; set; }
        public string Hora { get; set; }
    }
}