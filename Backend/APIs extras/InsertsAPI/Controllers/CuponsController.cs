using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("Inserts/[controller]")]
    public class CuponsController : ControllerBase
    {
        Utils.CuponsConversor conv = new Utils.CuponsConversor();
        Business.Cryptography crip = new Business.Cryptography();
        Databases.CuponsDatabase db = new Databases.CuponsDatabase();

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

                return conv.ParaListaResponse(db.Cadastrar(cupons));
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