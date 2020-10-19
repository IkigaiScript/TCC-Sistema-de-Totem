using System;

namespace Backend.Models.Request
{
    public class IngressoRequest
    {
        public int Sessao { get; set; }
        public char Fileira { get; set; }
        public int Poltrona { get; set; }
        public int Pedido { get; set; }
        public bool MeiaEntrada { get; set; }
    }
}