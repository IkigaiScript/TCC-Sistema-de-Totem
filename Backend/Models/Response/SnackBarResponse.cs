namespace Backend.Models.Response
{
    public class SnackBarResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Peso { get; set; }
        public string Sabor { get; set; }
        public string Imagem { get; set; }
        public decimal Preco { get; set; }
    }
}