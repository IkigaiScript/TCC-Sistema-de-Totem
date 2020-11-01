using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class PedidoComboConvesor
    {
        public TbPedidoCombo ParaTabela (PedidoComboRequest req)
        {
            return new TbPedidoCombo {
                NrQtdCombo = req.Qtd,
                IdPedido = req.Pedido,
                IdCombo = req.Combo
            };
        }

        public List<TbPedidoCombo> ParaListaTabela (List<PedidoComboRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }

        public PedidoComboResponse ParaResponse (TbPedidoCombo tb)
        {
            return new PedidoComboResponse {
                Qtd = (int) tb.NrQtdCombo,
                Pedido = (int) tb.IdPedido,
                Combo = (int) tb.IdCombo,
                Id = tb.IdPedidoCombo
            };
        }

        public List<PedidoComboResponse> ParaListaResponse (List<TbPedidoCombo> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}