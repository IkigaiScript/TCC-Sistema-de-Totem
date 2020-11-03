using System;
using System.Linq;
using System.Collections;

using Backend.Models;
namespace Backend.Database
{
    public class CartaoDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbCartao Cadastrar(TbCartao tb)
        {
            // receber consulta do cartão
            TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == tb.IdPedido);

            tb.VlGasto = pedido.VlTotal.Value; 

            pedido.DsStatus = "aprovado";
            pedido.DsFormaPagamento = "cartao";
        
            // if(pedido.VlTotal - cartao.VlCartao < 0) cartao.VlCartao -= pedido.VlTotal;
            //
            // else cartao.VlCartao = 0;
            ctx.SaveChanges();
 
            ctx.TbCartao.Add(tb);
            ctx.SaveChanges();

            return tb;
        }
    }
}