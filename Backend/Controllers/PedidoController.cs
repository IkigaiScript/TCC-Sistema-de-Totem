using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PedidoController : ControllerBase
    {
        Utils.PedidoConversor conv = new Utils.PedidoConversor();
        Business.PedidoBusiness buss = new Business.PedidoBusiness();

        [HttpDelete("{id}")] // funcionando
        public ActionResult<Models.Response.PedidoResponse> Deletar(int id)
        {
            try
            {
                return conv.ParaResponse(buss.Deletar(id));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(404,ex.Message)
                );
            }
        }

        [HttpPost] // funcionando
        public ActionResult<Models.Response.PedidoResponse> Cadastrar(int login)
        {
            try
            {
                Models.TbPedido pedido = new Models.TbPedido {
                    IdLogin = login,
                };

                return conv.ParaResponse(buss.Cadastrar(pedido));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.Message)
                );
            }
        }
 
        [HttpPut("{id}")] // consertar
        public ActionResult<Models.Response.PedidoResponse> Alterar(int id, Models.Request.PedidoRequest req)
        {
            try
            {
                Models.TbPedido ped = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Alterar(id,ped));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.Message)
                );
            }
        }
         
        [HttpPut("total/{id}")] // consertar  - database - include
        public ActionResult<float> CalcularTotal(int id)
        {
            try
            {
                return buss.CalcularTotal(id);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(500,ex.Message)
                );
            }
        }
        
        [HttpGet("{id}")] // funcionando
        public ActionResult<Models.Response.PedidoResponse> Consultar(int id)
        {
            try
            {
                return conv.ParaResponse(buss.ConsultarPedido(id));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(404,ex.Message)
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