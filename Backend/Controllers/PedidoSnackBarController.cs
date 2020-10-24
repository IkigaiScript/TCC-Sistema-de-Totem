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
    [Route("Pedidos/SnackBars")]
    public class PedidoSnackBarController : ControllerBase
    {
        Business.PedidoSnackBarBusiness buss = new Business.PedidoSnackBarBusiness();
        Utils.PedidoSnackBarConversor conv = new Utils.PedidoSnackBarConversor();

        [HttpPost] // funcionando
        public ActionResult<List<Models.Response.PedidoSnackBarResponse>> Cadastrar(List<Models.Request.PedidoSnackBarRequest> reqs)
        {
            try
            {
                List<Models.TbPedidoSnackBar> psb = conv.ParaListaTabela(reqs);
                return conv.ParaListaResponse(buss.Cadastrar(psb));
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