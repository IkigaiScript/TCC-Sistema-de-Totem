using System;
using System.Linq;
namespace Backend.Database
{
    public class LoginDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();

        public Models.TbPedido Iniciar(Models.TbLogin tb)
        {
            Models.TbPedido pedido = new Models.TbPedido();            
            pedido.IdLogin = tb.IdLogin == 0
                        ? 1 // o login do totem é o primeiro login
                        : tb.IdLogin;
            
            ctx.TbPedido.Add(pedido);
            ctx.SaveChanges();
            return pedido;
        }

        public Models.TbLogin Login(string email, string senha)
        {
            return ctx.TbLogin.FirstOrDefault(x => x.DsSenha == senha &&
                                                    x.DsEmail.ToLower() == email.ToLower());
        }       
    }
}