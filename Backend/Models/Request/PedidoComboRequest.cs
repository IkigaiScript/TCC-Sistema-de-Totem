using System;

namespace Backend.Models.Request
{
    public class PedidoComboRequest
    {
        public int Qtd { get; set; }
        public int Combo { get; set; }
        public int Pedido { get; set; }
    }
}