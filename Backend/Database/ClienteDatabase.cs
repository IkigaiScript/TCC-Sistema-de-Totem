using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Backend.Models;
namespace Backend.Database
{
    public class ClienteDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbCliente ConsultarCliente(int id)
        {
            if(id == 1)
            {
                return new TbCliente(){
                    IdLogin = 1,
                    NmCliente = "Totem"
                };
            }
            return ctx.TbCliente.FirstOrDefault(x => x.IdLogin == id);
        }
    }
}
