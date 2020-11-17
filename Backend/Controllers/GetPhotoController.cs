using System;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;

using Backend.Models.Response;
using Backend.Business;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPhotoController : ControllerBase
    {
        GerenciadorFotos fotos = new GerenciadorFotos();

        [HttpGet("{nome}")]
        public ActionResult getPhoto(string nome)
        {
            try
            {
                return fotos.BuscarFoto(nome);
            }
            catch(Exception ex)
            {
                return new NotFoundObjectResult(
                    new ErrorResponse(404,ex.Message)
                );
            }
        }
    }
}