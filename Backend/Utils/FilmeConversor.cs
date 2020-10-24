using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class FilmeConversor
    {
        public Models.Response.FilmeResponse ParaResponse(Models.TbFilme tb)
        {
            return new Models.Response.FilmeResponse
            {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Sinopse = tb.DsSinopse,
                Imagem = tb.DsImagem,
                Classificacao = tb.NrClassficacao.Value,
                Duracao = tb.NrDuracao.Value,
                Breve = tb.BtBreve.Value,
            };
        }

        public List<Models.Response.FilmeResponse> ParaListaResponse(List<Models.TbFilme> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}