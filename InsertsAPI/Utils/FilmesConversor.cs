using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertsAPI.Utils
{
    public class FilmesConversor
    {
        public Models.TbFilme ParaTabela(Models.Request.FilmesRequest req)
        {
            return new Models.TbFilme {
                NmFilme = req.Nome,
                DsGenero = req.Genero,
                NrClassficacao = req.Classificacao,
                DsSinopse = req.Sinopse,
                BtEstreia = req.Estreia,
                NrDuracao = req.Duracao,
                BtBreve = req.Breve
            };
        }

        public Models.Response.FilmesResponse ParaResponse(Models.TbFilme tb)
        {
            return new Models.Response.FilmesResponse {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Classificacao = tb.NrClassficacao.Value,
                Sinopse = tb.DsSinopse,
                Estreia = tb.BtEstreia.Value,
                Duracao = tb.NrDuracao.Value,
                Breve = tb.BtBreve.Value,
                Imagem = tb.DsImagem
            };
        }
    }
}