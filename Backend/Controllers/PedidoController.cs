using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

using Backend.Business;
using Backend.Utils;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Pedidos")]
    public class PedidoController : ControllerBase
    {
        PedidoConversor conv = new PedidoConversor();
        PedidoBusiness buss = new PedidoBusiness();

        [HttpDelete("{id}")] // funcionando
        public ActionResult<PedidoResponse> Deletar(int id)
        {
            try
            {
                return conv.ParaResponse(buss.Deletar(id));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }
 
        [HttpPut("{id}")] // funcionando
        public ActionResult<PedidoResponse> Alterar(int id, PedidoRequest req)
        {
            try
            {
                TbPedido ped = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Alterar(id,ped));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }
         
        [HttpPost("Totals/{id}")] // funcionando
        public ActionResult<float> CalcularTotal(int id)
        {
            try
            {
                return buss.CalcularTotal(id);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }
        
        [HttpGet("{id}")] // funcionando
        public ActionResult<PedidoResponse> Consultar(int id)
        {
            try
            {
                return conv.ParaResponse(buss.ConsultarPedido(id));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(404,ex.Message)
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