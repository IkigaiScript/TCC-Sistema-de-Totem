using System;

namespace InsertsAPI.Models.Response
{
    public class FilmesResponse 
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int Classificacao { get; set; }
        public int Duracao { get; set; }
        public string Sinopse { get; set; }
        public string Imagem { get; set; }
        public string Genero { get; set; }
        public bool Estreia { get; set; }
        public bool Breve { get; set; }
    }
}