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
        IdBase ConsTBase = new IdBase();
        LoginConversor conv = new LoginConversor();
        LoginBusiness buss = new LoginBusiness();

        [HttpPost] // funcionando 
        public ActionResult<LoginResponse> Iniciar(LoginRequest req)
        {
            try
            {
                TbLogin login = conv.ParaTabela(req);
                TbPedido pedido = buss.Iniciar(login);
                TbLogin lg = ConsTBase.Login(pedido.IdLogin);

                return conv.ParaResponse(pedido,(int) lg.NrNivel);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.ToString())
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