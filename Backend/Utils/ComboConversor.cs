using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Response;
using Backend.Models;
namespace Backend.Utils
{
    public class ComboConversor
    {
        public CombosResponse ParaResponse(TbCombo tb)
        {
            return new CombosResponse {
                First = tb.DsFirstItem,
                Secondary = tb.DsSecondaryItem,
                Third = tb.DsThirdItem,
                Nome = tb.NmCombo,
                Id = tb.IdCombo,
                Imagem = tb.DsImagem,
                Preco = (float) tb.VlPreco
            };
        }

        public List<CombosResponse> ParaListaResponse(List<TbCombo> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}