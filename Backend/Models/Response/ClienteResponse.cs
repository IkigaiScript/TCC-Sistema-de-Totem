namespace Backend.Models.Response
{
    public class ClienteResponse
    {
        public string Cep { get; set; }
        public int Login { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Celular { get; set; }
        public bool? CondicaoEspecial { get; set;} 
        public bool? Vip { get; set; }        
    }
}