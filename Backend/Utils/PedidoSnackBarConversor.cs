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
        public List<TbPedidoSnackBar> ParaTabela(PedidoSnackBarRequest req)
        {
            List<TbPedidoSnackBar> ret = new List<TbPedidoSnackBar>();

            foreach(Itens x in req.Itens){
                ret.Add(
                    new TbPedidoSnackBar {
                        NrQtdSnackBar = x.Qtd,
                        IdPedido = req.Pedido,
                        IdSnackBar = x.SnackBar
                    }
                );
            }

            return ret;    
        }

        public PedidoSnackBarResponse ParaResponse(TbPedidoSnackBar tb)
        {
            return new PedidoSnackBarResponse {
                Qtd = tb.NrQtdSnackBar,
                SnackBar = tb.IdSnackBar
            };
        }

        public List<PedidoSnackBarResponse> ParaListaResponse(List<TbPedidoSnackBar> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}