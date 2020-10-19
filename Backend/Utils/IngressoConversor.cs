using System;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Utils
{
    public class IngressoConversor
    {
        public Models.Response.IngressoResponse ParaResponse(Models.TbIngresso tb)
        {
            return new Models.Response.IngressoResponse {
                Poltrona = tb.NrPoltona,
                Fileira = tb.DsFileira[0]
            };
        }

        public List<Models.Response.IngressoResponse> ParaListaResponse(List<Models.TbIngresso> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }

        public Models.TbIngresso ParaTabela(Models.Request.IngressoRequest req)
        {
            return new Models.TbIngresso {
                DsFileira = req.Fileira.ToString(),
                BtMeiaEntrada = req.MeiaEntrada,
                IdPedido = req.Pedido,
                NrPoltona = req.Poltrona,
                IdSessao = req.Sessao,
            };
        }

        public List<Models.TbIngresso> ParaListaTabela(List<Models.Request.IngressoRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }
    }
}