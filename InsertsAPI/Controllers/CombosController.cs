using System;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CombosController : ControllerBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        Utils.CombosConversor conv = new Utils.CombosConversor();
        Business.GerenciadorFotos fotos = new Business.GerenciadorFotos();
        [HttpPost]
        public ActionResult<Models.Response.CombosResponse> Cadastrar([FromForm] Models.Request.CombosRequest req)
        {
            try
            {
                Models.TbCombo combo = conv.ParaTabela(req);
                combo.DsImagem = fotos.NovoNome(req.Imagem.FileName);

                
                ctx.TbCombo.Add(combo);
                ctx.SaveChanges();
                fotos.SalvarFoto(combo.DsImagem,req.Imagem);

                return conv.ParaResponse(combo);
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