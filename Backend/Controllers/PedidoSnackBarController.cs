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

        [HttpGet("History/{id}")] // PRONTO
        public ActionResult<List<PedidoSnackBarResponse>> Historico(int id)
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
        public ActionResult Deletar(int pedido,int snackbar)
        {
            try
            {
                buss.Deletar(pedido,snackbar);
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