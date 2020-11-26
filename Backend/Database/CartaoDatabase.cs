using System;
using System.Linq;
using System.Collections;
using Newtonsoft.Json;

using Backend.Models;
namespace Backend.Database
{
    public class CartaoDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbCartao Cadastrar(TbCartao tb)
        {
            TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == tb.IdPedido);
            pedido.DsStatus = "Aprovado";
            pedido.DsFormaPagamento = "Cartão";
            ctx.SaveChanges();

            tb.VlGasto = pedido.VlTotal.Value;
            ctx.TbCartao.Add(tb);
            ctx.SaveChanges();

            return tb;
        }
    }
}