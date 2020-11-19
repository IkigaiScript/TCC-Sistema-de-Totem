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
        public ActionResult Cadastrar(PedidoComboRequest req)
        {
            try
            {
                List<TbPedidoCombo> combos = conv.ParaTabela(req);
                buss.Cadastrar(combos);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }

        [HttpGet("History/{id}")]
        public ActionResult<List<PedidoComboResponse>> Historico(int id)
        {
            try
            {
                return conv.ParaListaResponse(buss.Historico(id));
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }

        [HttpDelete]
        public ActionResult Deletar (int pedido, int combo)
        {
            try
            {
                buss.Deletar(pedido,combo);
                return new OkResult();
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
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