using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Backend.Business;
using Backend.Utils;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Pedidos/Combos")]
    public class PedidoComboController : ControllerBase
    {
        PedidoComboConvesor conv = new PedidoComboConvesor();
        PedidoComboBusiness buss = new PedidoComboBusiness();
        
        [HttpPost] // funcionando
        public ActionResult<List<PedidoComboResponse>> Cadastrar(List<PedidoComboRequest> reqs)
        {
            try
            {
                List<TbPedidoCombo> combos = conv.ParaListaTabela(reqs);
                return conv.ParaListaResponse(buss.Cadastrar(combos));
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