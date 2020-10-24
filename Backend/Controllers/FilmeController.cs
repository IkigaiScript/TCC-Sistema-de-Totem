using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Filmes")]
    public class FilmeController : ControllerBase
    {
        Business.FilmeBusines buss = new Business.FilmeBusines();
        Utils.FilmeConversor conv = new Utils.FilmeConversor();

        [HttpGet("Seach/{nome}")]
        public ActionResult<List<Models.Response.FilmeResponse>> ConsultaParcial(string nome)
        {
            try
            {
                return conv.ParaListaResponse(buss.ConsultaParcial(nome));
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