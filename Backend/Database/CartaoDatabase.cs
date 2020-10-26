using System;
using System.Linq;
using System.Collections;

namespace Backend.Database
{
    public class CartaoDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbCartao Cadastrar(Models.TbCartao tb)
        {
            // receber consulta do cartão
            Models.TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == tb.IdPedido);

            tb.VlGasto = pedido.VlTotal; 

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