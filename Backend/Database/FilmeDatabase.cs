using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

using Backend.Models;
namespace Backend.Database
{
    public class FilmeDatabase
    {
        tcdbContext ctx = new tcdbContext();

        public List<TbFilme> ConsultaParcial(string nome)
        {
           return ctx.TbFilme.Where(x => x.NmFilme.Contains(nome) &&
                                        x.BtBreve == false &&
                                        x.BtEstreia == true)
                                    .Where(x => x.BtEstreia == true && x.BtBreve == false)
                                    .OrderBy(x => x.NmFilme)
                                    .ToList();
        }

        public List<TbFilme> Consultar()
        {
            return ctx.TbFilme.Where(x => x.BtEstreia == true)
                              .OrderBy(x => x.NmFilme)
                              .ToList();
        }

        public List<TbFilme> ConsultarBreve()
        {
            return ctx.TbFilme.Where(x => x.BtBreve == true && x.BtBreve == false)
                                .OrderBy(x => x.NmFilme)
                                .ToList();
        }

        public List<TbFilme> ConsultarFilter(string genero,int classificacao,string sala)
        {
            List<TbFilme> filmes = ctx.TbFilme.Include(x => x.TbSessao)  
                                                .Where(x => x.BtEstreia == true && x.BtBreve == false)
                                                .ToList();

            if(sala != null && sala != string.Empty)
            {
                filmes = filmes.Where(x => x.TbSessao.Any(x => x.DsTipoSala.ToLower() == sala.ToLower() &&
                                                               (x.DtHorario.Day == DateTime.Now.Day 
                                                                    || x.DtHorario.Day == DateTime.Now.AddDays(1).Day
                                                                    || x.DtHorario.Day == DateTime.Now.AddDays(2).Day))).ToList();
            }

            if(genero != null && genero != string.Empty)
            {
                filmes = filmes.Where(x => x.DsGenero.ToLower().Contains(genero.ToLower())).ToList();
            }

            if(classificacao.ToString() != null && classificacao.ToString() != string.Empty)
            {
                filmes = filmes.Where(x => x.NrClassificacao == classificacao).ToList();
            }

            return filmes;
        }

        
        public TbFilme ConsultarUNI(int id)
        {
            List<TbFilme> filmes = ctx.TbFilme.Include(x => x.TbSessao)
                                                .Include(x => x.TbDiretor)
                                                .Include(x => x.TbAtor)
                                                .Include(x => x.TbTrailer)
                                                .ToList();
                                                
            return filmes.FirstOrDefault(x => x.IdFilme == id);
        }
    }
}