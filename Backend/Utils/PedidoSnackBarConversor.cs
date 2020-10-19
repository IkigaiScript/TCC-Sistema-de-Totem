using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class PedidoSnackBarConversor
    {
        public Models.TbPedidoSnackBar ParaTabela(Models.Request.PedidoSnackBarRequest req)
        {
            return new Models.TbPedidoSnackBar {
                NrQtdSnackBar = req.Qtd,
                IdPedido = req.Pedido,
                IdSnackBar = req.SnackBar
            };
        }

        public List<Models.TbPedidoSnackBar> ParaListaTabela(List<Models.Request.PedidoSnackBarRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }

        public Models.Response.PedidoSnackBarResponse ParaResponse(Models.TbPedidoSnackBar tb)
        {
            return new Models.Response.PedidoSnackBarResponse {
                SnackBar = (int) tb.IdSnackBar,
                Qtd = (int) tb.NrQtdSnackBar,
                Pedido = (int) tb.IdPedido,
                Id = tb.IdPedidoSnackBar
            };
        }

        public List<Models.Response.PedidoSnackBarResponse> ParaListaResponse(List<Models.TbPedidoSnackBar> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}