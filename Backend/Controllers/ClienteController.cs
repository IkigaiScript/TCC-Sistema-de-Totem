using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
    [Route("Clientes")]
    public class ClienteController  : ControllerBase
    {
        ClienteConversor conv = new ClienteConversor();
        ClienteBusiness Buss = new ClienteBusiness();

        [HttpGet("{id}")] // Cliente
        public ActionResult<ClienteResponse> Consultar(int Id)
        {
            try
            {
                return conv.ParaResponse(Buss.ConsultarCliente(Id));
            }
                
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                new ErrorResponse(400,ex.Message));
            }
        } 
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}