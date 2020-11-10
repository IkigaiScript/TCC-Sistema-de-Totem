using Microsoft.AspNetCore.Mvc;

using Backend.Business;
using Backend.Utils;
using Backend.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Trailers")]
    public class TrailerController : ControllerBase
    {
        GerenciadorFotos buss = new GerenciadorFotos();
        tcdbContext ctx = new tcdbContext();

        [HttpGet("Videos/{nome}")] // Consultar trailer
        public ActionResult LerVideo (string nome)
        {
            return buss.BuscarFoto(nome);
        }

        [HttpGet("ping")] 
        public string ping()
        {
            return "pong";
        }
    }
}