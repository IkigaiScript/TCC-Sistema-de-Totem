using System;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;
namespace Backend.Utils
{
    public class CartaoConversor
    {
        public CartaoResponse ParaResponse(TbCartao tb)
        {
            return new CartaoResponse {
                Id = tb.IdCartao,
                Pedido = tb.IdPedido.Value,
                Gasto  = (float) tb.VlGasto,
                Numero = tb.NrCartao.Value
            };
        }

        public TbCartao ParaTabela(CartaoRequest req)
        {
            return new TbCartao {
                NrCartao = req.Numero,
                IdPedido = req.Pedido
            };
        }
    }
}