using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Database
{
    public class PedidoComboDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public List<Models.TbPedidoCombo> Cadastrar(List<Models.TbPedidoCombo> tbs)
        {
            ctx.TbPedidoCombo.AddRange(tbs);

            ctx.SaveChanges();
            return tbs;
        }
    }
}