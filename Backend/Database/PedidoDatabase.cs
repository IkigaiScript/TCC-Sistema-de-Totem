using System;
using System.Collections;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Newtonsoft;
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

        public Models.TbPedido CalcularTotal(Models.TbPedido tb)
        {
            // falta o include
            decimal total = 0;
            Console.WriteLine(JsonConvert.SerializeObject(tb));
            total += (decimal) tb.TbIngresso.Sum(x => x.IdSessaoNavigation.VlIngresso);
            Console.WriteLine(total);
            total += (decimal) tb.TbPedidoCombo.Sum(x => x.IdComboNavigation.VlPreco * x.NrQtdCombo);
            Console.WriteLine(total);
            total += (decimal) tb.TbPedidoSnackBar.Sum(x => x.IdSnackBarNavigation.VlPreco * x.NrQtdSnackBar);
  
            tb.VlTotal = total;
            ctx.SaveChanges();

            return tb;
        }

        public Models.TbPedido Cadastrar(Models.TbPedido tb)
        {
            ctx.TbPedido.Add(tb);
            ctx.SaveChanges();
            return tb;
        }

        public Models.TbPedido Alterar(Models.TbPedido pedido, Models.TbPedido tb)
        {
            pedido.NmTitular = tb.NmTitular;
            pedido.DsFormaPagamento = tb.DsFormaPagamento;
            pedido.DsStatus = tb.DsStatus;
            Console.WriteLine(JsonConvert.SerializeObject(pedido));
            ctx.SaveChanges();
            return pedido;
        }
    }
}