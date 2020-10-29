using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;

namespace InsertsAPI.Databases
{
    public class FilmesDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbFilme Cadastrar(Models.TbFilme tb)
        {
            ctx.TbFilme.Add(tb);
            ctx.SaveChanges();
            return tb;
        }
    }
}