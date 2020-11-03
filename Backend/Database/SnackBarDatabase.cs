using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class SnackBarDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public List<Models.TbSnackBar> Consultar(string tipoProduto)
        {
            return ctx.TbSnackBar.Where(x => x.DsTipoProduto == tipoProduto)
                                .OrderBy(x => x.NmProduto)
                                .ToList();
        }
    }
}