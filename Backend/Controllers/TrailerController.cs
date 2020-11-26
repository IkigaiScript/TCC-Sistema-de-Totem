using System;
using Microsoft.AspNetCore.Mvc;

using Backend.Business;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Trailers")]
    public class TrailerController : ControllerBase
    {
        TrailerBusiness buss = new TrailerBusiness();
        GerenciadorFotos fotos = new GerenciadorFotos();
        
        [HttpGet("Videos/{id}")] // Consultar trailer
        public ActionResult LerVideo (int id)
        {
            string nome =  buss.LerVideo(id);
            return fotos.BuscarFoto(nome);
        }

        [HttpGet("ping")] 
        public string ping()
        {
            return "pong";
        }
    }
}