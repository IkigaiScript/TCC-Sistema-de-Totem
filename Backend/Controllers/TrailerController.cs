using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Microsoft.AspNetCore.Http;
using Newtonsoft;
using Newtonsoft.Json;

using Backend.Business;
using Backend.Utils;
using Backend.Models;
using Backend.Models.Request;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Trailers")]
    public class TrailerController : ControllerBase
    {
        TrailerConversor conv = new Utils.TrailerConversor();
        GerenciadorFotos buss = new GerenciadorFotos();
        tcdbContext ctx = new tcdbContext();

        [HttpPost] // Inserir trailer
        public ActionResult<string> Cadastrar([FromForm] TrailerRequest req)
        {
            try
            {
                TbTrailer trailer = conv.ParaTabela(req);
                trailer.NmTrailer = buss.GerarNovoNome(req.trailer.FileName);
                ctx.Add(trailer);
                ctx.SaveChanges();    
                buss.salvarFoto(trailer.NmTrailer,req.trailer);
                Console.WriteLine("Concluido");
                return trailer.NmTrailer;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new NotFoundResult();
            }
        }

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