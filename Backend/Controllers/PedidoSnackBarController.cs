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
    [Route("Pedidos/SnackBars")]
    public class PedidoSnackBarController : ControllerBase
    {
        PedidoSnackBarBusiness buss = new PedidoSnackBarBusiness();
        PedidoSnackBarConversor conv = new PedidoSnackBarConversor();

        [HttpPost] // PRONTO
        public ActionResult Cadastrar(PedidoSnackBarRequest reqs)
        {
            try
            {
                List<TbPedidoSnackBar> psb = conv.ParaTabela(reqs);
                buss.Cadastrar(psb);
                return new OkResult();
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