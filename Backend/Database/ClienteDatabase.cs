using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class ClienteDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();

        public Models.TbCliente ConsultarCliente(int id)
        {
            return ctx.TbCliente.FirstOrDefault(x => x.IdCliente == id);
        }
    }
}
