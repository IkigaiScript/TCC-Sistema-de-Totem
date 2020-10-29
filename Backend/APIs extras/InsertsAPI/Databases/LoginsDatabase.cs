using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertsAPI.Databases
{
    public class LoginsDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public List<Models.TbLogin> Cadastrar(List<Models.TbLogin> tbs)
        {
            ctx.TbLogin.AddRange(tbs);
            ctx.SaveChanges();
            return tbs;
        }
    }
}