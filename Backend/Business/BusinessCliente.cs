using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Business
{
    public class BusinessCliente
    {
        Database.ClienteDatabase db = new Database.ClienteDatabase();
        public Models.TbCliente ConsularCliente(int id)
        {
            Models.TbCliente Cliente = db.ConsultarCliente(id);
            if(Cliente == null) throw new ArgumentException("ID incorreto");
            return db.ConsultarCliente(Cliente.IdCliente);
        }
    }
}