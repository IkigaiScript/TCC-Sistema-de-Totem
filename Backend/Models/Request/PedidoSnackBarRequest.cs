using System;
using System.Collections.Generic;

namespace Backend.Models.Request
{
    public class PedidoSnackBarRequest
    {
        public int Pedido { get; set; }
        public List<Itens> Itens { get; set; }
    }

    public class Itens {
        public int Qtd { get; set; }
        public int SnackBar { get; set; }
    }
}