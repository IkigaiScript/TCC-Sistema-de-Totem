using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class FilmeConversor
    {
        public FilmeResponse ParaResponse(TbFilme tb)
        {
            return new FilmeResponse
            {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Sinopse = tb.DsSinopse,
                Imagem = tb.DsImagem,
                Classificacao = tb.NrClassificacao,
                Duracao = tb.NrDuracao,
                Breve = tb.BtBreve,
                Estreia = tb.BtEstreia
            };
        }

        public List<FilmeResponse> ParaListaResponse(List<TbFilme> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }

        public FilmeCompletoResponse ParaResponseCompleto(TbFilme tb)
        {
            SessaoConversor sessao = new SessaoConversor();

            Func<TbAtor,AtorResponse> ator = (a) => {
                return new AtorResponse {
                    Nascimento = a.DtNascimento,
                    Nome = a.NmAtor
                };           
            };

            Func<TbDiretor,DiretorResponse> diretor = (d) => {
                return new DiretorResponse {
                    Nascimento = d.DtNascimento,
                    Nome = d.NmDiretor
                };
            };
            
            return new FilmeCompletoResponse {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Sinopse = tb.DsSinopse,
                Imagem = tb.DsImagem,
                Classificacao = tb.NrClassificacao,
                Duracao = tb.NrDuracao,
                Breve = tb.BtBreve,
                Estreia = tb.BtEstreia,
                Atores = tb.TbAtor.Select(x => ator(x))
                            .ToList(),
                Diretores = tb.TbDiretor.Select(x => diretor(x))
                            .ToList(),
                Sessoes = tb.TbSessao.Select(x => sessao.ParaResponse(x))
                            .ToList()
            };
        }

         public Models.TbFilme CadastrarRequest(FilmesRequest req)
        {
            return new Models.TbFilme {
                NmFilme = req.Nome,
                DsGenero = req.Genero,
                NrClassificacao = req.Classificacao,
                DsSinopse = req.Sinopse,
                BtEstreia = req.Estreia,
                NrDuracao = req.Duracao,
                BtBreve = req.Breve
            };
        }

        public FilmesResponse CadastrarResponse(TbFilme tb)
        {
            return new Models.Response.FilmesResponse {
                Id = tb.IdFilme,
                Nome = tb.NmFilme,
                Genero = tb.DsGenero,
                Classificacao = tb.NrClassificacao,
                Sinopse = tb.DsSinopse,
                Estreia = tb.BtEstreia,
                Duracao = tb.NrDuracao,
                Breve = tb.BtBreve,
                Imagem = tb.DsImagem
            };
        }
    }
}