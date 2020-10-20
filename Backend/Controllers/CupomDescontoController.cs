using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CupomDescontoController : ControllerBase
    {
        Database.IdBase ConsTBase = new Database.IdBase();
        Business.CupomDescontoBusiness buss = new Business.CupomDescontoBusiness();
        Utils.CupomDescontoConversor conv = new Utils.CupomDescontoConversor();

        [HttpGet] // funcionando
        public ActionResult<Models.Response.CupomDescontoResponse> Consultar(string codigo, int pedido)
        {
            try
            {
                Models.TbPedido ped = buss.Consultar(codigo,pedido);
                return conv.ParaResponse((float) ped.VlTotal,ConsTBase.Desconto(codigo).NmCupom); 
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