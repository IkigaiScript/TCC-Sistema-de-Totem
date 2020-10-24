using System;

namespace Backend.Models.Request
{
    public class NotaFiscalRequest
    {
        public int Pedido { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }
    }
}