using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("Inserts/[controller]")]
    public class LoginsController : ControllerBase
    {
        Business.Cryptography crip = new Business.Cryptography();
        Utils.LoginsConversor conv = new Utils.LoginsConversor();
        Databases.LoginsDatabase db = new Databases.LoginsDatabase();

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

                return conv.ParaListaResponse(db.Cadastrar(logins));
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