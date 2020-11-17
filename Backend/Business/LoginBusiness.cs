using System;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class LoginBusiness : Cryptography
    {
        LoginDatabase db = new LoginDatabase();
        public (int NumPedido,int Nivel) Iniciar(TbLogin tb)
        {
            TbLogin login = new TbLogin();
            if(!string.IsNullOrEmpty(tb.DsEmail))
            {
                TbLogin login1 = db.Login(tb.DsEmail,tb.DsSenha); // hash da senha
                if(login1 == null) throw new ArgumentException("Login não encontrado");

                login = login1;
            }
            
            return db.Iniciar(login);
        }
    }
}