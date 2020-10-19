using System;
using System.Linq;

namespace Backend.Utils
{
    public class PedidoConversor
    {
        public Models.TbPedido ParaTabela(Models.Request.PedidoRequest req)
        {
            return new Models.TbPedido {
                DsFormaPagamento = req.FormaPagamento,
                DsStatus = req.Status,
                NmTitular = req.Titular
            };
        }

        public Models.TbPedido Cadastrar(Models.Request.PedidoRequest req)
        {
            return new Models.TbPedido {
                DsFormaPagamento = "",
                DsStatus = "em processo",
                NmTitular = "",
            };
        }

        public Models.Response.PedidoResponse ParaResponse(Models.TbPedido tb)
        {
            return new Models.Response.PedidoResponse {
                Id = tb.IdPedido,
                Login = tb.IdLogin.Value,
                FormaPagamento = tb.DsFormaPagamento,
                Status = tb.DsStatus,
                Titular = tb.NmTitular
            };
        }
    }
}