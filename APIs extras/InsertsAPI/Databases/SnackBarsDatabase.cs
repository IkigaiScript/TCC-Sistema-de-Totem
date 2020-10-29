using System;

namespace InsertsAPI.Databases
{
    public class SnackBarsDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbSnackBar Cadastrar(Models.TbSnackBar tb)
        {
            ctx.TbSnackBar.Add(tb);
            ctx.SaveChanges();
            return tb;
        }
    }
}