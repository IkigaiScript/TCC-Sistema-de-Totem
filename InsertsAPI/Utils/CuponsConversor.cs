using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertsAPI.Utils
{
    public class CuponsConversor
    {
        public Models.Response.CuponsResponse ParaResponse(Models.TbCupomDesconto tbs)
        {
            return new Models.Response.CuponsResponse {
                Codigo = tbs.DsCodigo,
                Nome = tbs.NmCupom,
                Desconto = (float) tbs.VlDesconto.Value,
                Gasto = (float) tbs.VlMinGasto.Value,
                Id = tbs.IdCupomDesconto
            };
        }

        public Models.TbCupomDesconto ParaTabela(Models.Request.CuponsRequest req)
        {
            return new Models.TbCupomDesconto {
                DsCodigo = req.Codigo,
                NmCupom = req.Nome,
                VlDesconto = (decimal?) req.Desconto,
                VlMinGasto = (decimal?) req.Gasto
            };
        }  

        public List<Models.TbCupomDesconto> ParaListaTabela(List<Models.Request.CuponsRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }  

        public List<Models.Response.CuponsResponse> ParaListaResponse(List<Models.TbCupomDesconto> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }   
    }
}