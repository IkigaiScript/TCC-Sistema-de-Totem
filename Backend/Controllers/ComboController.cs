using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Models.Response;
using Backend.Business;
using Backend.Utils;
namespace Backend.Controllers
{
    [ApiController]
    [Route("Combos")]
    public class ComboController : ControllerBase
    {
        GerenciadorFotos foto = new GerenciadorFotos();
        ComboConversor conv = new ComboConversor();
        ComboBusiness buss = new ComboBusiness();

        [HttpGet]
        public ActionResult<List<CombosResponse>> Consultar()
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

        [HttpGet("ping")]
        public string ping()
        {
            return "pong";
        }
    }
}