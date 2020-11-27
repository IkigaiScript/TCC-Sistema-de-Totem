using System;
using Microsoft.AspNetCore.Mvc;

using Backend.Business;
using Backend.Models;
using Backend.Models.Request;
using Backend.Utils;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Trailers")]
    public class TrailerController : ControllerBase
    {
        TrailerConversor conv = new TrailerConversor();
        TrailerBusiness buss = new TrailerBusiness();
        GerenciadorFotos fotos = new GerenciadorFotos();
        tcdbContext ctx = new tcdbContext();

        [HttpGet("Videos/{id}")] // Consultar trailer
        public ActionResult LerVideo (int id)
        {
            try{
                string nome =  buss.LerVideo(id);
                return fotos.BuscarVideo(nome);
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );   
            }
        }

        [HttpPost] // Inserir trailer
        public ActionResult<string> Cadastrar([FromForm] TrailerRequest req)
        {
            try
            {
                TbTrailer trailer = conv.ParaTabela(req);
                trailer.NmTrailer = fotos.GerarNovoNome(req.Trailer.FileName);
                ctx.Add(trailer);
                ctx.SaveChanges();
                fotos.salvarFoto(trailer.NmTrailer,req.Trailer);
                return trailer.NmTrailer;
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