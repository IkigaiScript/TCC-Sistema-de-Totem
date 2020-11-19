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
        public List<TbPedidoCombo> ParaTabela(PedidoComboRequest req)
        {
            List<TbPedidoCombo> ret = new List<TbPedidoCombo>();

            foreach(Combos combo in req.Itens)
            {
                ret.Add(
                    new TbPedidoCombo(){
                        IdPedido = req.Pedido,
                        IdCombo = combo.Combo,
                        NrQtdCombo = combo.Qtd
                    }
                );
            }

            return ret;
        }

        public PedidoComboResponse ParaResponse(TbPedidoCombo tb)
        {
            return new PedidoComboResponse {
                Qtd = tb.NrQtdCombo,
                Combo = tb.IdCombo
            };
        }

        public List<PedidoComboResponse> ParaListaResponse(List<TbPedidoCombo> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}