using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Models.Response;
using Backend.Business;

namespace Backend.Controllers
{
   [ApiController]
   [Route("SnackBars")]
   public class SnackBarController : ControllerBase
   {
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

        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
   }
}