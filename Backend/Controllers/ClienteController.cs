using System;
using System.Collections;
using System.Collections.Generic;
using System.link;

using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteContoller : ControllerBase     
    {
        
        [HttpGet]
        public class int PegarCliente(IdLogin){
            models.tcdbContext ctx = new models.tcdbContext();
            
            int cliente = ctx.TbCliente.Where(x => x.IdCliente = IdLogin)

            return Cliente;
        }
    }
}