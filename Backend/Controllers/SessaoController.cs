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
    [Route("Sessao")]
    public class SessaoController : ControllerBase
    {
        Business.SessaoController buss = new Business.SessaoController();
        Utils.SessaoConversor conv = new Utils.SessaoConversor();

        [HttpGet] // funcionando
        public ActionResult<Models.Response.SessaoResponse> Consultar(int sessao)
        {
            try
            {
                return conv.ParaResponse(buss.Consultar(sessao));
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

        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}