using System;
using System.Linq;

namespace Backend.Models.Request
{
    public class PedidoRequest
    {
       public string Titular { get; set; }
       public string Status { get; set; }           
       public string FormaPagamento { get; set; }
    }
}