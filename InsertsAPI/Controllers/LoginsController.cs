using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginsController : ControllerBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        Business.Cryptography crip = new Business.Cryptography();
        Utils.LoginsConversor conv = new Utils.LoginsConversor();

        [HttpPost] // funcionando
        public ActionResult<List<Models.Response.LoginsResponse>> Cadastrar(List<Models.Request.LoginsRequest> reqs)
        {
            try
            {
                List<Models.TbLogin> logins = conv.ParaListaTabela(reqs);
                foreach(Models.TbLogin login in logins)
                {
                    login.DsSenha = crip.CriarHash(login.DsSenha);
                }
                
                ctx.TbLogin.AddRange(logins);
                ctx.SaveChanges();
                return conv.ParaListaResponse(logins);
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