using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Clientes")]
    public class ClienteController  : ControllerBase
    {
        Utils.ClienteConversor conv = new Utils.ClienteConversor();
        Business.ClienteBusiness Buss = new Business.ClienteBusiness();

        [HttpGet("{id}")] // Cliente
        public ActionResult<Models.Response.ClienteResponse> Consultar(int id)
        {
            try
            {
                return conv.ParaResponse(Buss.ConsultarCliente(id));
            }
                
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                new Models.Response.ErrorResponse(400,ex.Message));
            }
        } 
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}