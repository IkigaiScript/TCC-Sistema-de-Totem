using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Backend.Business;
using Backend.Utils;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Sessao")]
    public class SessaoController : ControllerBase
    {
        SessaoBusiness buss = new SessaoBusiness();
        SessaoConversor conv = new SessaoConversor();

        [HttpGet] // funcionando
        public ActionResult<SessaoResponse> Consultar(int sessao)
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
                    new ErrorResponse(code,error)
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