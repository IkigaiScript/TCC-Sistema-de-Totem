using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;

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
    [Route("Cupons")]
    public class CupomDescontoController : ControllerBase
    {
        IdBase ConsTBase = new IdBase();
        CupomDescontoBusiness buss = new CupomDescontoBusiness();
        CupomDescontoConversor conv = new CupomDescontoConversor();

        [HttpGet] // funcionando
        public ActionResult<CupomDescontoResponse> Consultar(string codigo, int pedido)
        {
            try
            {
                TbPedido ped = buss.Consultar(codigo,pedido);
                return conv.ParaResponse((float) ped.VlTotal,ConsTBase.Desconto(ped.IdCupomDesconto.Value).NmCupom); 
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