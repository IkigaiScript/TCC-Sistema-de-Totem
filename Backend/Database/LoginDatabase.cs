using System;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class LoginDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public (int NumPedido,int Nivel) Iniciar(TbLogin tb)
        {
            TbPedido pedido = new TbPedido();            
            if(tb.NrNivel < 1)
            {
                pedido.IdLogin = tb.IdLogin == 0
                            ? 1 // o login do totem é o primeiro login
                            : tb.IdLogin;
                
                pedido.DtHorario = DateTime.Now;
                ctx.TbPedido.Add(pedido);
                ctx.SaveChanges();
            }

            Console.WriteLine(pedido.IdPedido);
            Console.WriteLine(tb.NrNivel);
            return (pedido.IdPedido,tb.NrNivel);
        }

        public TbLogin Login(string email, string senha)
        {
            return ctx.TbLogin.FirstOrDefault(x => x.DsSenha == senha &&
                                                    x.DsEmail.ToLower() == email.ToLower());
        }       
    }
}