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
        Cryptography crip = new Cryptography();
        ClienteConversor conv = new ClienteConversor();
        ClienteBusiness Buss = new ClienteBusiness();

        [HttpGet("{id}")] // PRONTO
        public ActionResult<ClienteResponse> Consultar(int id)
        {
            try
            {
                return conv.ParaResponse(Buss.ConsultarCliente(id));
            }
                
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        } 

        [HttpGet("Hash")]
        public string Hash(string senha)
        {
            return crip.CriarHash(senha).ToString();
        }
        
        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}