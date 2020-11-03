using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class PedidoSnackBarDatabase
    {
        tcdbContext ctx = new tcdbContext();

        public List<TbPedidoSnackBar> Cadastrar (List<TbPedidoSnackBar> tbs)
        {
            ctx.TbPedidoSnackBar.AddRange(tbs);
            ctx.SaveChanges();

            foreach(TbSnackBar snackBar in ctx.TbSnackBar)
            {
                if(tbs.Any(x => x.IdSnackBar == snackBar.IdSnackBar))
                        snackBar.NrQtdEstoque -= tbs.FirstOrDefault(x => x.IdSnackBar == snackBar.IdSnackBar).NrQtdSnackBar; 
            }            

            ctx.SaveChanges();
            return tbs;
        }       
    }
}