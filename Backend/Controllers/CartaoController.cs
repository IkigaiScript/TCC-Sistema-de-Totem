using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Backend.Business;
using Backend.Utils;
using Backend.Models;
using Backend.Models.Request;
using Backend.Models.Response;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Cartoes")]
    public class CartaoController : ControllerBase
    {
        CartaoConversor conv = new CartaoConversor();
        CartaoBusiness buss = new CartaoBusiness();

        [HttpPost] // terminando 
        public ActionResult<CartaoResponse> Cadastrar(CartaoRequest req)
        {
            try
            {
                TbCartao cartao = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Cadastrar(cartao,req.Cvv,req.Senha,req.Pagamento));
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