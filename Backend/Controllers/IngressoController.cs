using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Backend.Business;
using Backend.Utils;
using Backend.Database;
using Backend.Services.Documents;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Ingressos")]
    public class IngressoController : ControllerBase
    {
        IngressoConversor conv = new IngressoConversor();
        IngressoBusiness buss = new IngressoBusiness();

        [HttpGet("{sessao}")] // refazer apos o weverton definir certinho as cadeiras
        public ActionResult<List<IngressoResponse>> ConsultarLugares(int sessao)
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
                    new ErrorResponse(code,error)
                );
            }
        }

        [HttpPost] // funcionando
        public ActionResult Cadastrar(List<IngressoRequest> reqs)
        {
            try
            {
                List<TbIngresso> ingressos = conv.ParaListaTabela(reqs);
                buss.Cadastrar(ingressos);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
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