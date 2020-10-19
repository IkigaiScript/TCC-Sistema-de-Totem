//using System;
//using System.Collections.Generic;
//using System.Threading.Tasks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;

// N funciona 

//namespace Backend.Controllers
//{
//    public class SnackBarController
//    {
//        Trailer_API.Business.GerenciadorFoto foto = new Trailer_API.Business.GerenciadorFoto();
//        
//        [HttpGet("Foto/{nome}")]
//        public ActionResult BuscarFoto(string nome)
//        {
//            try
//            {
//                byte[] photo =  foto .LerFoto(nome);
//                return File(photo,foto.GerarContentType(nome));
//            }
//            catch (Exception ex)
//            {
//                return new BadRequestObjectResult(
//                    new Models.Response.ErrorResponse(404,ex.Message)
//                );
//            }
//        }
//    }
//}