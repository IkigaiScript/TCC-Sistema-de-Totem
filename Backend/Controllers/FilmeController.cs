using System;
using System.Collections.Generic;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

using Backend.Business;
using Backend.Utils;
using Backend.Database;
using Backend.Services.Documents;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Filmes")]
    public class FilmeController : ControllerBase
    {
        GerenciadorFotos fotos = new GerenciadorFotos();
        FilmeBusines buss = new FilmeBusines();
        FilmeConversor conv = new FilmeConversor();

        [HttpGet("Seach/{nome}")] // testar 
        public ActionResult<List<FilmeResponse>> ConsultaParcial(string nome)
        {
            try
            {
                return conv.ParaListaResponse(buss.ConsultaParcial(nome));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }

        [HttpGet] // funcionando
        public ActionResult<List<FilmeResponse>> Consultar()
        {
            try
            {
                return conv.ParaListaResponse(buss.Consultar());
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(500,ex.Message)
                );
            }
        }

        [HttpGet("Breve")]
        public ActionResult<List<FilmeResponse>> ConsultarBreve()
        {
            try
            {
                return conv.ParaListaResponse(buss.ConsultarBreve());
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(500,ex.Message)
                );
            }
        }

        [HttpGet("{id}")]
        public ActionResult<FilmeCompletoResponse> ConsultaUNI(int id)
        {
            try
            {
                return conv.ParaResponseCompleto(buss.ConsultarUNI(id));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }

        [HttpGet("Seach")]
        public ActionResult<List<FilmeResponse>> ConsultarFilter(int classificacao,string sala,string genero)
        {
            try
            {
                return conv.ParaListaResponse(buss.ConsultarFilter(classificacao,genero,sala));
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }

        [HttpGet("Fotos/{nome}")]
        public ActionResult BuscarFoto(string nome)
        {
            try
            {
                return fotos.BuscarFoto(nome);
            }
            catch(Exception ex)
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