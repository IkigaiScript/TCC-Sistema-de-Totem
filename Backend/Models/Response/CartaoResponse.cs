using System;

namespace Backend.Models.Response
{
    public class CartaoResponse
    {
        public int Id { get; set; }
        public int Pedido { get; set; }
        public string Numero { get; set; }
        public float Gasto { get; set; }
    }
}