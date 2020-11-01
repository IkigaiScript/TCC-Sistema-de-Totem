using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CuponsController : ControllerBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        Utils.CuponsConversor conv = new Utils.CuponsConversor();
        Business.Cryptography crip = new Business.Cryptography();

        [HttpPost]
        public ActionResult<List<Models.Response.CuponsResponse>> Cadastrar(List<Models.Request.CuponsRequest> reqs)
        {
            try
            {
                List<Models.TbCupomDesconto> cupons = conv.ParaListaTabela(reqs);
                foreach(Models.TbCupomDesconto cupom in cupons)
                {
                    cupom.DsCodigo = crip.CriarHash(cupom.DsCodigo);
                }

                ctx.TbCupomDesconto.AddRange(cupons);
                ctx.SaveChanges();
                return conv.ParaListaResponse(cupons);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.Message)
                );
            }
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}