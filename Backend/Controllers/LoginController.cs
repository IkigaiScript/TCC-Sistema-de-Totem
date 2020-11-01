using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    [Route("Logins")]
    public class LoginController : ControllerBase
    {
        LoginConversor conv = new LoginConversor();
        LoginBusiness buss = new LoginBusiness();

        [HttpPost] // funcionando 
        public ActionResult<LoginResponse> Iniciar(LoginRequest req)
        {
            try
            {
                TbLogin login = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Iniciar(login));
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