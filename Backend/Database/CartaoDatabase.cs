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
            // Adicionar vl_gasto depois de validar o cartão 
            ctx.TbCartao.Add(tb);
            ctx.SaveChanges();

            Models.TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == tb.IdPedido);
            pedido.DsStatus = "aprovado";
            pedido.DsFormaPagamento = "cartao";
            ctx.SaveChanges();

            return tb;
        }
    }
}