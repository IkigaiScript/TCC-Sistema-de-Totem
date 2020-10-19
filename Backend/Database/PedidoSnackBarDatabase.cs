using System;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Database
{
    public class PedidoSnackBarDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();

        public List<Models.TbPedidoSnackBar> Cadastrar (List<Models.TbPedidoSnackBar> tbs)
        {
            ctx.TbPedidoSnackBar.AddRange(tbs);

            
            ctx.SaveChanges();
            return tbs;
        }       
    }
}