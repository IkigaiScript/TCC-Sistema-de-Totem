using System;
using System.Linq;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class PedidoConversor
    {
        public TbPedido ParaTabela(PedidoRequest req)
        {
            return new TbPedido {
                DsFormaPagamento = req.FormaPagamento,
                DsStatus = req.Status,
                NmTitular = req.Titular
            };
        }

        public TbPedido Cadastrar(PedidoRequest req)
        {
            return new TbPedido {
                DsFormaPagamento = "",
                DsStatus = "em processo",
                NmTitular = "",
            };
        }

        public PedidoResponse ParaResponse(TbPedido tb)
        {
            return new PedidoResponse {
                Id = tb.IdPedido,
                Login = tb.IdLogin,
                FormaPagamento = tb.DsFormaPagamento ?? string.Empty,
                Status = tb.DsStatus ?? string.Empty,
                Titular = tb.NmTitular ?? string.Empty
            };
        }
    }
}