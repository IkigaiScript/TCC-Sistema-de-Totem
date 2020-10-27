using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers
{
   [ApiController]
   [Route("SnackBars")]
   public class SnackBarController : ControllerBase
   {
       Business.GerenciadorFotos foto = new Business.GerenciadorFotos();
       
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
                   new Models.Response.ErrorResponse(404,ex.Message)
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