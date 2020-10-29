using System;

namespace InsertsAPI.Databases
{
    public class CombosDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbCombo Cadastrar(Models.TbCombo tb)
        {
            ctx.TbCombo.Add(tb);
            ctx.SaveChanges();
            return  tb;  
        }
    }
}