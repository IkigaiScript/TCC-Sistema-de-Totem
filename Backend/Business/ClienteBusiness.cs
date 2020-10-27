using System;
using System.Linq;
using System.Collections.Generic;

namespace Backend.Business
{
    public class ClienteBusiness
    {
        Database.ClienteDatabase db = new Database.ClienteDatabase();
        public Models.TbCliente ConsultarCliente(int id)
        {
            
            Models.TbCliente Cliente = db.ConsultarCliente(id);
            if(Cliente == null) throw new ArgumentException("ID incorreto");

            return db.ConsultarCliente(Cliente.IdCliente);
        }
    }
}