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

        [HttpPost] // PRONTO 
        public ActionResult<string> Iniciar(LoginRequest req)
        {
            try
            {
                Console.WriteLine("start login");
                TbLogin login = conv.ParaTabela(req);
                (int,int) pedido = buss.Iniciar(login);
                Console.WriteLine(pedido);
                return pedido.ToString();
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