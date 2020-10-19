using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class IngressoController : ControllerBase
    {
        Utils.IngressoConversor conv = new Utils.IngressoConversor();
        Business.IngressoBusiness buss = new Business.IngressoBusiness();

        [HttpGet] // refazer apos o weverton definir certinho as cadeiras
        public ActionResult<List<Models.Response.IngressoResponse>> ConsultarLugares(int sessao)
        {
            try
            {
                return conv.ParaListaResponse(buss.ConsultarLugares(sessao));
            }
            catch(Exception ex)
            {
                int code = 0;
                string error = ex.Message; 
                if(ex.Message.Contains("400")) 
                {
                    error = ex.Message.Substring(0,ex.Message.IndexOf("."));
                    code = 400;
                }
                else code = 500;

                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(code,error)
                );
            }
        }

        [HttpPost] // funcionando
        public ActionResult Cadastrar(List<Models.Request.IngressoRequest> reqs)
        {
            try
            {
                List<Models.TbIngresso> ingressos = conv.ParaListaTabela(reqs);
                buss.Cadastrar(ingressos);
                return new OkResult();
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