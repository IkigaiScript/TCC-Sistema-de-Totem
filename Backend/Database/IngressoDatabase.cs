using System;
using System.Linq;
using System.Collections.Generic;

namespace Backend.Database
{
    public class IngressoDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public List<Models.TbIngresso> ConsultarLugares(int sessao)
        {
            return ctx.TbIngresso.Where(x => x.IdSessao == sessao).ToList();
        }

        public List<Models.TbIngresso> Cadastrar(List<Models.TbIngresso> tbs)
        {
            ctx.TbIngresso.AddRange(tbs);
            ctx.SaveChanges();
            return tbs;
        }
    }
}