using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

using Backend.Models;
namespace Backend.Database
{
    public class PedidoDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbPedido Deletar(TbPedido tb)
        {
            ctx.TbIngresso.RemoveRange(tb.TbIngresso);
            ctx.SaveChanges();

            ctx.TbCartao.RemoveRange(tb.TbCartao);
            ctx.SaveChanges();

            ctx.TbNotaFiscal.RemoveRange(tb.TbNotaFiscal);
            ctx.SaveChanges();

            ctx.TbPedidoSnackBar.RemoveRange(tb.TbPedidoSnackBar);
            ctx.SaveChanges();
            
            ctx.TbPedidoCombo.RemoveRange(tb.TbPedidoCombo);
            ctx.SaveChanges();

            ctx.TbPedido.Remove(tb);
            ctx.SaveChanges();

            return tb;
        }

        public TbPedido CalcularTotal(int id)
        {
            decimal total = 0;
           
            total = (decimal) ctx.TbIngresso.Where(x => x.IdPedido == id)
                                                                .Include(x => x.IdSessaoNavigation)
                                                            .Select(x => x.IdSessaoNavigation.VlIngresso)
                                                            .Sum();
            total = (decimal) ctx.TbPedidoCombo.Where(x => x.IdPedido == id)
                                                       .Include(x => x.IdComboNavigation)
                                                    .Select(x => x.IdComboNavigation.VlPreco * x.NrQtdCombo)
                                                    .Sum();
            total += (decimal) ctx.TbPedidoSnackBar.Where(x => x.IdPedido == id)
                                                          .Include(x => x.IdSnackBarNavigation)
                                                        .Select(x => x.IdSnackBarNavigation.VlPreco * x.NrQtdSnackBar)
                                                        .Sum();

            TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id);
            pedido.VlTotal = Math.Round(total,2);
            ctx.SaveChanges();
            return pedido;
        }

        public TbPedido Alterar(int id, TbPedido tb)
        {
            TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id); 

            if(!string.IsNullOrEmpty(tb.NmTitular)) pedido.NmTitular = tb.NmTitular;
            if(!string.IsNullOrEmpty(tb.DsFormaPagamento)) pedido.DsFormaPagamento = tb.DsFormaPagamento;
            if(!string.IsNullOrEmpty(tb.DsStatus)) pedido.DsStatus = tb.DsStatus;
            Console.WriteLine(JsonConvert.SerializeObject(tb));
            ctx.SaveChanges();
            return pedido;
        }
    }
}