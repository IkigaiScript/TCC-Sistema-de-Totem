using System;
using System.Collections.Generic;

namespace Backend.Models.Request
{
    public class PedidoComboRequest
    {
        public int Pedido { get; set; }
        public List<Combos> Itens { get; set; }
    }

    public class Combos 
    {
        public int Qtd { get; set; }
        public int Combo { get; set; }
    }
}