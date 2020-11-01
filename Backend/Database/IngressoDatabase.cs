using System;
using System.Linq;
using System.Collections.Generic;

using Backend.Models;
namespace Backend.Database
{
    public class IngressoDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public List<TbIngresso> ConsultarLugares(int sessao)
        {
            return ctx.TbIngresso.Where(x => x.IdSessao == sessao).ToList();
        }

        public List<TbIngresso> Cadastrar(List<TbIngresso> tbs)
        {
            ctx.TbIngresso.AddRange(tbs);
            ctx.SaveChanges();
            return tbs;
        }
    }
}