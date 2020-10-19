namespace Backend.Models.Response
{
    public class SnackBarResponse
    {
        public int IdSnackBar { get; set; }

        public string NmProduto { get; set; }

        public string DsTipoProduto { get; set; }

        public string DsMarca { get; set; }

        public string DsSabor { get; set; }

        public string DsImagem { get; set; }

        public int? NrQntEstoque { get; set; }

        public decimal? VlPreco { get; set; }
    }
}