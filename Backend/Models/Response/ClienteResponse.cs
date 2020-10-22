namespace Backend.Models.Response
{
    public class ClienteResponse
    {
        public int Id { get; set; }

        public int login { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public string Rg { get; set; }

        public string Celular { get; set; }

        public bool? CondiçãoEspecial { get; set;} 
        
        public bool? Vip { get; set; }        
    }
}