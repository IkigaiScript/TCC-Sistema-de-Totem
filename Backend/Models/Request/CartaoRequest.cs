using System;

namespace Backend.Models.Request
{
    public class CartaoRequest
    { 
        public string Numero { get; set; }
        public int Cvv { get; set; }
        public int Senha { get; set; }
        public int Pedido { get; set; }
        public string Pagamento { get; set; } // debito ou credito
    }
}