namespace Backend.Models.Response
{
    public class FilmeResponse
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Genero { get; set; }
        public string Sinopse { get; set; }
        public string Imagem { get; set; }
        public int Classificacao { get ; set; }
        public int Duracao { get ; set; }
        public bool Breve { get; set; }
        public bool Estreia { get; set; }
    }
}