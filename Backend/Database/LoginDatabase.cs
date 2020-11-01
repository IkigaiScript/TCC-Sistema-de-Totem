using System;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class LoginDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbPedido Iniciar(TbLogin tb)
        {
            TbPedido pedido = new TbPedido();            
            pedido.IdLogin = tb.IdLogin == 0
                        ? 1 // o login do totem é o primeiro login
                        : tb.IdLogin;
            
            ctx.TbPedido.Add(pedido);
            ctx.SaveChanges();
            return pedido;
        }

        public TbLogin Login(string email, string senha)
        {
            return ctx.TbLogin.FirstOrDefault(x => x.DsSenha == senha &&
                                                    x.DsEmail.ToLower() == email.ToLower());
        }       
    }
}