using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class IngressoConversor
    {
        public IngressoResponse ParaResponse(TbIngresso tb)
        {
            return new IngressoResponse {
                Poltrona = tb.NrPoltrona,
                Fileira = tb.DsFileira[0]
            };
        }

        public List<IngressoResponse> ParaListaResponse(List<TbIngresso> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }

        public TbIngresso ParaTabela(IngressoRequest req)
        {
            return new TbIngresso {
                DsFileira = req.Fileira.ToString(),
                BtMeiaEntrada = req.MeiaEntrada,
                IdPedido = req.Pedido,
                NrPoltrona = req.Poltrona,
                IdSessao = req.Sessao,
            };
        }

        public List<TbIngresso> ParaListaTabela(List<IngressoRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }
    }
}