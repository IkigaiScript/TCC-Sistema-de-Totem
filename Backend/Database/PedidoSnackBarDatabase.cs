using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
namespace Backend.Database
{
    public class PedidoSnackBarDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();

        public List<Models.TbPedidoSnackBar> Cadastrar (List<Models.TbPedidoSnackBar> tbs)
        {
            ctx.TbPedidoSnackBar.AddRange(tbs);
            ctx.SaveChanges();

            foreach(Models.TbSnackBar snackBar in ctx.TbSnackBar)
            {
                if(tbs.Any(x => x.IdSnackBar == snackBar.IdSnackBar))
                        snackBar.NrQtdEstoque -= tbs.FirstOrDefault(x => x.IdSnackBar == snackBar.IdSnackBar).NrQtdSnackBar.Value; 
            }            

            ctx.SaveChanges();
            return tbs;
        }       
    }
}