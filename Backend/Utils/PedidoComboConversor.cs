using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class PedidoComboConvesor
    {
        public Models.TbPedidoCombo ParaTabela (Models.Request.PedidoComboRequest req)
        {
            return new Models.TbPedidoCombo {
                NrQtdCombo = req.Qtd,
                IdPedido = req.Pedido,
                IdCombo = req.Combo
            };
        }

        public List<Models.TbPedidoCombo> ParaListaTabela (List<Models.Request.PedidoComboRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }

        public Models.Response.PedidoComboResponse ParaResponse (Models.TbPedidoCombo tb)
        {
            return new Models.Response.PedidoComboResponse {
                Qtd = (int) tb.NrQtdCombo,
                Pedido = (int) tb.IdPedido,
                Combo = (int) tb.IdCombo,
                Id = tb.IdPedidoCombo
            };
        }

        public List<Models.Response.PedidoComboResponse> ParaListaResponse (List<Models.TbPedidoCombo> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}