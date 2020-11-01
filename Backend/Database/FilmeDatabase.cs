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
            return ctx.TbFilme.Where(x => x.BtBreve == true)
                                .OrderBy(x => x.NmFilme)
                                .ToList();
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