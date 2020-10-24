using System;

namespace Backend.Utils
{
    public class CartaoConversor
    {
        public Models.Response.CartaoResponse ParaResponse(Models.TbCartao tb)
        {
            return new Models.Response.CartaoResponse {
                Id = tb.IdCartao,
                Pedido = tb.IdPedido.Value,
                Gasto  = (float) tb.VlGasto,
                Numero = tb.NrCartao.Value
            };
        }

        public Models.TbCartao ParaTabela(Models.Request.CartaoRequest req)
        {
            return new Models.TbCartao {
                NrCartao = req.Numero,
                IdPedido = req.Pedido
            };
        }
    }
}