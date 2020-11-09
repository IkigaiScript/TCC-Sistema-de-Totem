using System;
using Newtonsoft;
using Newtonsoft.Json;

using Backend.Database;
using Backend.Models;
namespace Backend.Business
{
    public class PedidoBusiness
    {
        IdBase ConsTBase = new IdBase();
        PedidoDatabase db = new PedidoDatabase();
        public TbPedido Deletar(int id)
        {
            TbPedido pedido = ConsTBase.Pedido(id);
            
            if(pedido == null) throw new ArgumentException("Pedido não existe");
            return db.Deletar(pedido);            
        }

        public TbPedido Alterar(int id,TbPedido tb)
        {
            if(!string.IsNullOrEmpty(tb.DsFormaPagamento))
            {
                if(tb.DsFormaPagamento.ToLower() != "cartao"    && 
                   tb.DsFormaPagamento.ToLower() !=  "dinheiro" &&
                   tb.DsFormaPagamento.ToLower() != "qrcode") throw new ArgumentException("Forma de pagamento inválido");
            }
            
            if(!string.IsNullOrEmpty(tb.DsStatus))
            {
                if(tb.DsStatus.ToLower() != "aprovado" &&
                   tb.DsStatus.ToLower() != "em espera") throw new ArgumentException("Status inváldo");
            }

            if(!string.IsNullOrEmpty(tb.NmTitular))
            {
                if(tb.NmTitular.Length <= 10) throw new ArgumentNullException("Quantidade de caracteres inválida no nome");
                // verificar nome com api externa de nome
            }
            return db.Alterar(id,tb);
        }

        public TbPedido ConsultarPedido(int id)
        {
            TbPedido pedido = ConsTBase.Pedido(id);
            
            if(pedido == null) throw new ArgumentNullException("Pedido não encontrado");
            return pedido;
        }

        public float CalcularTotal(int id)
        {
            if(ConsTBase.Pedido(id) == null) throw new ArgumentException("Pedido não existe");
            
            return (float) db.CalcularTotal(id).VlTotal;
        }        
    }
}