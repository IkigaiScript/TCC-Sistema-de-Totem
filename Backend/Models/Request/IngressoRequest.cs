using System;
using System.Collections.Generic;
namespace Backend.Models.Request
{
    public class IngressoRequest
    {
        public int Sessao { get; set; }        
        public List<Assento> Assentos { get; set; }
        public int Pedido { get; set; }
    }

    public class Assento 
    {
        public bool MeiaEntrada { get; set; }
        public char Fileira { get; set; }
        public int Poltrona { get; set; }
    }
}