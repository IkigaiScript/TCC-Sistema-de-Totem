using System;
using System.Linq;
using System.Collections.Generic;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class ClienteBusiness
    {
        ClienteDatabase db = new ClienteDatabase();
        public TbCliente ConsultarCliente(int id)
        {
            
            TbCliente Cliente = db.ConsultarCliente(id);
            if(Cliente == null) throw new ArgumentException("ID incorreto");

            return db.ConsultarCliente(Cliente.IdCliente);
        }
    }
}