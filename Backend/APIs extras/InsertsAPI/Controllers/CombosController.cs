using System;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("Inserts/[controller]")]
    public class CombosController : ControllerBase
    {
        Utils.CombosConversor conv = new Utils.CombosConversor();
        Databases.CombosDatabase db = new Databases.CombosDatabase();
        Business.GerenciadorFotos fotos = new Business.GerenciadorFotos();
        [HttpPost]
        public ActionResult<Models.Response.CombosResponse> Cadastrar([FromForm] Models.Request.CombosRequest req)
        {
            try
            {
                Models.TbCombo combo = conv.ParaTabela(req);
                combo.DsImagem = fotos.NovoNome(req.Imagem.FileName);

                combo = db.Cadastrar(combo);
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