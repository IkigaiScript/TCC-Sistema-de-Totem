using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Backend.Controllers
{
   public class SnackBarController : ControllerBase
   {
       Business.GerenciadorFotos foto = new Business.GerenciadorFotos();
       
       [HttpGet("Foto/{nome}")]
       public ActionResult BuscarFoto(string nome)
       {
           try
           {
               byte[] photo =  foto.LerFoto(nome);
               return File(photo,foto.GerarContentType(nome));
           }
           catch (Exception ex)
           {
               return new BadRequestObjectResult(
                   new Models.Response.ErrorResponse(404,ex.Message)
               );
           }
       }
   }
}