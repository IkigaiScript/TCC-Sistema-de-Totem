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

        public List<TbIngresso> ParaTabela(IngressoRequest req)
        {
            List<TbIngresso> ret = new List<TbIngresso>();

            foreach(Assento x in req.Assentos){
                ret.Add(
                    new TbIngresso {
                        IdPedido = req.Pedido,
                        DsFileira = x.Fileira.ToString(),
                        NrPoltrona = x.Poltrona,
                        IdSessao = req.Sessao,
                        BtMeiaEntrada = x.MeiaEntrada
                    }
                );
            }

            return ret;

        }
    }
}