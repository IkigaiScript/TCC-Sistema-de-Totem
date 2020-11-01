using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class PedidoComboDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public List<TbPedidoCombo> Cadastrar(List<TbPedidoCombo> tbs)
        {
            ctx.TbPedidoCombo.AddRange(tbs);

            ctx.SaveChanges();
            return tbs;
        }
    }
}