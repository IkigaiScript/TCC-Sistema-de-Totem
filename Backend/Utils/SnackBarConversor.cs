using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Response;
using Backend.Models;
namespace Backend.Utils
{
    public class SnackBarConversor
    {
        public SnackBarResponse ParaResponse(Models.TbSnackBar tb)
        {
            return new SnackBarResponse 
            {
                Id = tb.IdSnackBar,
                Nome = tb.NmProduto,
                Preco = tb.VlPreco,
                Peso = tb.DsPeso,
                Sabor = tb.DsSabor,
                Imagem = tb.DsImagem
            };
        }

        public List<SnackBarResponse> ParaListaResponse(List<Models.TbSnackBar> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}