using System;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Collections.Generic;
using System.Collections;

using Backend.Models;
using Backend.Models.Response.Gerente;
using Backend.Business;
using Backend.Utils;
using Backend.Models.Response;
namespace Backend.Database
{
    [ApiController]
    [Route("[controller]")]
    public class GerenteController : ControllerBase
    {
        GerenteBusiness buss = new GerenteBusiness();
        GerenteConversor conv = new GerenteConversor();

        [HttpGet("Vendas/Dia/{dia}")] // pronto
        public ActionResult<List<VendasPorDia>> VendasDoDia(int dia)
        {
            try
            {
                return buss.VendasDoDia(dia);   
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }

        [HttpGet("Vendas")] // pronto
        public ActionResult<List<VendasPorMes>> VendasDoMes(Models.Request.Gerente.VendasPorMes req)
        {
            try
            {
                Console.WriteLine("start");
                return buss.VendasdoMes(req.Inicio,req.Final);
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(400,ex.Message)
                );
            }
        }   

        [HttpGet("Top/Filmes")] // pronto
        public ActionResult<List<TopFilmes>> TopFilmes()
        {
            try
            {
                return buss.TopFilmes();
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }

        [HttpGet("Top/Produtos")] // pronto
        public ActionResult<List<TopProdutos>> TopProdutos()
        {
            try
            {
                return buss.TopProdutos();
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }

        [HttpGet("Logins")] // pronto
        public ActionResult<TotemLogins> TotemLogins()
        {
            try 
            {
                return buss.TotemLogins();
            }
            catch(Exception ex)
            {
                return new BadRequestObjectResult(
                    new ErrorResponse(500,ex.Message)
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