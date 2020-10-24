using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace Backend.Controllers
{
    [ApiController]
    [Route("Pedidos/Combos")]
    public class PedidoComboController : ControllerBase
    {
        Utils.PedidoComboConvesor conv = new Utils.PedidoComboConvesor();
        Business.PedidoComboBusiness buss = new Business.PedidoComboBusiness();
        
        [HttpPost] // funcionando
        public ActionResult<List<Models.Response.PedidoComboResponse>> Cadastrar(List<Models.Request.PedidoComboRequest> reqs)
        {
            try
            {
                List<Models.TbPedidoCombo> combos = conv.ParaListaTabela(reqs);
                return conv.ParaListaResponse(buss.Cadastrar(combos));
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