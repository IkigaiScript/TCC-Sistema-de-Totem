using System;

namespace InsertsAPI.Models.Request
{
    public class CuponsRequest
    {
        public float Gasto { get; set; }
        public float Desconto { get; set; }
        public string Nome { get; set; }
        public string Codigo { get; set; }
    }
}