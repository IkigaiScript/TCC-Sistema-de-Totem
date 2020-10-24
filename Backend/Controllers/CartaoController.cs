using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Backend.Controllers
{
    [ApiController]
    [Route("Cartoes")]
    public class CartaoController : ControllerBase
    {
        Utils.CartaoConversor conv = new Utils.CartaoConversor();
        Business.CartaoBusiness buss = new Business.CartaoBusiness();

        [HttpPost]
        public ActionResult<Models.Response.CartaoResponse> Cadastrar(Models.Request.CartaoRequest req)
        {
            try
            {
                Models.TbCartao cartao = conv.ParaTabela(req);
                return conv.ParaResponse(buss.Cadastrar(cartao,req.Cvv,req.Senha,req.Pagamento));
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