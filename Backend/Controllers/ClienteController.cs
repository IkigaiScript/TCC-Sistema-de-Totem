// using System;
// using System.Collections;
// using System.Collections.Generic;
// using System.Link;

// using Microsoft.AspNetCore.Mvc;

// namespace Backend.Controllers
// {
//     [ApiController]
//     [Route("[controller]")]
//     public class ClienteContoller : ControllerBase     
//     {
        
//        [HttpGet]
//         public int PegarCliente(int IdLogin){
//             Models.tcdbContext ctx = new Models.tcdbContext();
            
//             Models.TbCliente cliente = ctx.TbCliente.Where(x => x.IdCliente == IdLogin);
//             return cliente;
//         }
//     }
// }