using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Logins")]
    public class LoginController : ControllerBase
    {
        Utils.LoginConversor conv = new Utils.LoginConversor();
        Business.LoginBusiness buss = new Business.LoginBusiness();

        [HttpPost] // testar 
        public ActionResult<Models.Response.LoginResponse> Iniciar(Models.Request.LoginRequest req)
        {
            try
            {
                Models.TbLogin login = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Iniciar(login));
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