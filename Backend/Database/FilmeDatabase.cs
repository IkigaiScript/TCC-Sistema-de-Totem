using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Database
{
    public class FilmeDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();

        public List<Models.TbFilme> ConsultaParcial(string nome)
        {
           return ctx.TbFilme.Where(x => x.NmFilme.Contains(nome) &&
                                        x.BtBreve == false &&
                                        x.BtEstreia == true)
                                    .OrderBy(x => x.NmFilme)
                                    .ToList();
        }

        public List<Models.TbFilme> Consultar()
        {
            return ctx.TbFilme.Where(x => x.BtBreve == false &&
                                          x.BtEstreia == true)
                              .OrderBy(x => x.NmFilme)
                              .ToList();
        }
    }
}