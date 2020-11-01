using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;
namespace Backend.Utils
{
    public class PedidoSnackBarConversor
    {
        public TbPedidoSnackBar ParaTabela(PedidoSnackBarRequest req)
        {
            return new TbPedidoSnackBar {
                NrQtdSnackBar = req.Qtd,
                IdPedido = req.Pedido,
                IdSnackBar = req.SnackBar
            };
        }

        public List<TbPedidoSnackBar> ParaListaTabela(List<PedidoSnackBarRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }

        public PedidoSnackBarResponse ParaResponse(TbPedidoSnackBar tb)
        {
            return new PedidoSnackBarResponse {
                SnackBar = (int) tb.IdSnackBar,
                Qtd = (int) tb.NrQtdSnackBar,
                Pedido = (int) tb.IdPedido,
                Id = tb.IdPedidoSnackBar
            };
        }

        public List<PedidoSnackBarResponse> ParaListaResponse(List<TbPedidoSnackBar> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}