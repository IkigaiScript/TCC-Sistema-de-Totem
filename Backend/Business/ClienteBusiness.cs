using System;
using System.Linq;
using System.Collections.Generic;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class ClienteBusiness
    {
        IdBase ConsTBase = new IdBase();
        ClienteDatabase db = new ClienteDatabase();
        public TbCliente ConsultarCliente(int id)
        {
            
            TbPedido pedido = ConsTBase.Pedido(id);
            if(pedido == null) throw new ArgumentException("Pedido não encontrado");

            return db.ConsultarCliente(pedido.IdLogin);
        }
    }
}