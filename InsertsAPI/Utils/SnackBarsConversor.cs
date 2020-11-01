using System;

namespace InsertsAPI.Utils
{
    public class SnackBarsConversor
    {
        public Models.TbSnackBar ParaTabela(Models.Request.SnackBarsRequest req)
        {
            return new Models.TbSnackBar {
                DsTipoProduto = req.Tipo,
                DsSabor = req.Sabor,
                VlPreco = (decimal?) req.Preco,
                DsPeso = req.Peso,
                NmProduto = req.Nome,
                DsMarca = req.Marca,
                NrQtdEstoque = req.Estoque,
            };
        }

        public Models.Response.SnackBarsResponse ParaResponse(Models.TbSnackBar tb)
        {
            return new Models.Response.SnackBarsResponse {
                Id = tb.IdSnackBar,
                Tipo = tb.DsTipoProduto,
                Sabor = tb.DsSabor,
                Preco = (float) tb.VlPreco,
                Peso = tb.DsPeso,
                Nome = tb.NmProduto,
                Marca = tb.DsMarca,
                Imagem = tb.DsImagem,
                Estoque = tb.NrQtdEstoque.Value
            };
        }
    }
}