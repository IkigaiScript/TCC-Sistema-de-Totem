using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

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
                                                .ToList();

            if(sala != null && sala != string.Empty)
            {
                Console.WriteLine(sala);
                Console.WriteLine(filmes[0].TbSessao.ToList()[0].IdSessao);
                filmes = filmes.Where(x => x.TbSessao.Any(x => x.DsTipoSala.ToLower() == sala.ToLower())).ToList();
            }

            if(genero != null && genero != string.Empty)
            {
                Console.WriteLine($"Genero: {genero}");
                filmes = filmes.Where(x => this.GenderValidation(x.DsGenero.ToLower(),genero)).ToList();
                Console.WriteLine($"{filmes.Count} {filmes[0].NmFilme}");
            }

            if(classificacao != 0)
            {
                filmes = filmes.Where(x => x.NrClassificacao == classificacao).ToList();
            }

            return filmes;
        }

        private bool GenderValidation(string generos, string genero)
        {
           bool ret = false;
           string[] gender = generos.Split("/");
           for(int i = 0; i < gender.Length; i++)
           {
               if(gender[i].ToLower() == genero.ToLower()) ret = true;
           }

           return ret;
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