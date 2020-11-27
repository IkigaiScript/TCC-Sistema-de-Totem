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
        tcdbContext ctx = new tcdbContext();
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

        [HttpPost] // funcionando
        public ActionResult<FilmesResponse> Cadastrar([FromForm] FilmesRequest req)
        {
            try
            {
                Models.TbFilme ret = conv.CadastrarRequest(req);
                ret.DsImagem = fotos.GerarNovoNome(req.Imagem.FileName);
                ctx.TbFilme.Add(ret);
                ctx.SaveChanges();
                fotos.salvarFoto(ret.DsImagem,req.Imagem);
                return conv.CadastrarResponse(ret);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.Response.ErrorResponse(400,ex.ToString())
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