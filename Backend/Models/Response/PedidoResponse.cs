using System;

namespace Backend.Models.Response
{
    public class PedidoResponse : Request.PedidoRequest
    {
        public int Login { get; set; }
        public int Id { get; set; }
    }
}