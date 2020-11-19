using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class PedidoComboDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public void Cadastrar(List<TbPedidoCombo> tbs)
        {
            for(int i=0; i < tbs.Count; i++)
            {
                if(ctx.TbPedidoCombo.Any(x => x.IdPedido == tbs[i].IdPedido && x.IdCombo == tbs[i].IdCombo))
                {
                    TbPedidoCombo pedido = ctx.TbPedidoCombo.FirstOrDefault(x => x.IdPedido == tbs[i].IdPedido && x.IdCombo == tbs[i].IdCombo);
                    pedido.NrQtdCombo += tbs[i].NrQtdCombo;
                    tbs.Remove(tbs[i]);
                }
            }

            ctx.TbPedidoCombo.AddRange(tbs);
            ctx.SaveChanges();
        }

        public List<TbPedidoCombo> Historico(int id)
        {
            return ctx.TbPedidoCombo.Where(x => x.IdPedido == id).ToList();
        }

        public TbPedidoCombo ConsultExits(int pedido, int combo)
        {
            return ctx.TbPedidoCombo.FirstOrDefault(x => x.IdPedido == pedido && x.IdCombo == combo);
        }

        public void Deletar(TbPedidoCombo tb)
        {
            ctx.TbPedidoCombo.Remove(tb);
            ctx.SaveChanges();
        }
    }
}