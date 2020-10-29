using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace InsertsAPI.Databases
{
    public class CuponsDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public List<Models.TbCupomDesconto> Cadastrar(List<Models.TbCupomDesconto> tbs)
        {
            ctx.TbCupomDesconto.AddRange(tbs);
            ctx.SaveChanges();
            return tbs;
        }
    }
}