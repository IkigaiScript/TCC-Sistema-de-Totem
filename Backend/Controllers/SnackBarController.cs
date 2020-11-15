using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Models.Response;
using Backend.Business;
using Backend.Utils;
namespace Backend.Controllers
{
   [ApiController]
   [Route("SnackBars")]
   public class SnackBarController : ControllerBase
   {
       SnackBarBusiness buss = new SnackBarBusiness();
       SnackBarConversor conv = new SnackBarConversor();
       GerenciadorFotos foto = new GerenciadorFotos();
       
       [HttpGet("Fotos/{nome}")]
       public ActionResult BuscarFoto(string nome)
       {
           try
           {
               return foto.BuscarFoto(nome);
           }
           catch (Exception ex)
           {
               return new BadRequestObjectResult(
                   new ErrorResponse(404,ex.Message)
               );
           }
       }

       [HttpGet] // PRONTO
       public ActionResult<List<SnackBarResponse>> Consultar(string tipoProduto)
       {
           try
           {
               return conv.ParaListaResponse(buss.Consultar(tipoProduto));
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