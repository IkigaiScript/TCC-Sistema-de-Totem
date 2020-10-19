namespace Backend.Models.Response
{
    public class FilmeResponse
    {
        public int IdFilme { get; set; }

        public string NmFilme { get; set; }

        public string DsGenero { get; set; }

        public string DsSinopse { get; set; }

        public string DsImagem { get; set; }
    
        public int? NrClassificacao { get ; set; }

        public int? NrDuracao { get ; set; }

        public bool? BtBreve { get; set; }

        public bool? BtEstreia { get; set; }
    }
}