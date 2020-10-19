using System;
using Newtonsoft;
using Newtonsoft.Json;

namespace Backend.Business
{
    public class PedidoBusiness
    {
        Database.IdBase ConsTBase = new Database.IdBase();
        Database.PedidoDatabase db = new Database.PedidoDatabase();
        public Models.TbPedido Deletar(int id)
        {
            Models.TbPedido pedido = ConsTBase.Pedido(id);
            
            if(pedido == null) throw new ArgumentException("Pedido não existe");
            return db.Deletar(pedido);            
        }

        public Models.TbPedido Cadastrar(Models.TbPedido tb)
        {
            if(ConsTBase.Login((int) tb.IdLogin) == null) throw new ArgumentException("Login não existe");
            return db.Cadastrar(tb);
        }

        public Models.TbPedido Alterar(int id,Models.TbPedido tb)
        {
            Models.TbPedido ped = ConsTBase.Pedido(id);
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
            }

            Models.TbPedido pedido =  this.NullValue(id,tb);
            return db.Alterar(ped,pedido);
        }

        public Models.TbPedido ConsultarPedido(int id)
        {
            Models.TbPedido pedido = ConsTBase.Pedido(id);

            if(pedido == null) throw new ArgumentNullException("Pedido não encontrado");
            return pedido;
        }

        public float CalcularTotal(int id)
        {
            Models.TbPedido pedido = ConsTBase.Pedido(id);
            
            if(pedido == null) throw new ArgumentNullException("Pedido não existe");

            if(pedido.VlTotal != 0 && pedido.VlTotal != null) throw  new ArgumentException("Valor já calculado");
            return (float) db.CalcularTotal(pedido).VlTotal;
        }

        public Models.TbPedido NullValue(int id, Models.TbPedido req)
        {
            Models.TbPedido pedido = ConsTBase.Pedido(id);
            Models.TbPedido ret = new Models.TbPedido();
            ret.DsFormaPagamento = string.IsNullOrEmpty(req.DsFormaPagamento)
                    ? pedido.DsFormaPagamento
                    : req.DsFormaPagamento;
            
            ret.NmTitular = string.IsNullOrEmpty(req.NmTitular)
                    ? pedido.NmTitular
                    : req.NmTitular;
            
            ret.DsStatus = string.IsNullOrEmpty(req.DsStatus)
                    ? pedido.DsStatus
                    : req.DsStatus;
            
            return ret;  
        }
    }
}