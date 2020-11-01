using System;
using Microsoft.AspNetCore.Mvc;

namespace InsertsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnackBarsController : ControllerBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        Utils.SnackBarsConversor conv = new Utils.SnackBarsConversor();
        Business.GerenciadorFotos fotos = new Business.GerenciadorFotos();
        
        [HttpPost]
        public ActionResult<Models.Response.SnackBarsResponse> Cadastrar([FromForm] Models.Request.SnackBarsRequest req)
        {
            try
            {
                Models.TbSnackBar snackBar = conv.ParaTabela(req);
                snackBar.DsImagem = fotos.NovoNome(req.Imagem.FileName);

                ctx.TbSnackBar.Add(snackBar);
                ctx.SaveChanges();
                fotos.SalvarFoto(snackBar.DsImagem,req.Imagem);

                return conv.ParaResponse(snackBar);
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