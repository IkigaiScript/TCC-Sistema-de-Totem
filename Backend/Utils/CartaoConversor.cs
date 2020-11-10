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
                Pedido = tb.IdPedido,
                Gasto  = (float) tb.VlGasto,
            };
        }

        public TbCartao ParaTabela(CartaoRequest req)
        {
            return new TbCartao {
                DsCartao = req.Numero,
                IdPedido = req.Pedido
            };
        }
    }
}