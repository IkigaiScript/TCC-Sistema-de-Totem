using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace Backend.Database
{
    public class PedidoDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbPedido Deletar(Models.TbPedido tb)
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

        public Models.TbPedido CalcularTotal(int id)
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

            Models.TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id);
            pedido.VlTotal = Math.Round(total,2);
            ctx.SaveChanges();
            return pedido;
        }

        public Models.TbPedido Cadastrar(Models.TbPedido tb)
        {
            ctx.TbPedido.Add(tb);
            ctx.SaveChanges();
            return tb;
        }

        public Models.TbPedido Alterar(int id, Models.TbPedido tb)
        {
            Models.TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id); 

            if(!string.IsNullOrEmpty(tb.NmTitular)) pedido.NmTitular = tb.NmTitular;
            if(!string.IsNullOrEmpty(tb.DsFormaPagamento)) pedido.DsFormaPagamento = tb.DsFormaPagamento;
            if(!string.IsNullOrEmpty(tb.DsStatus)) pedido.DsStatus = tb.DsStatus;
            Console.WriteLine(JsonConvert.SerializeObject(tb));
            ctx.SaveChanges();
            return pedido;
        }
    }
}