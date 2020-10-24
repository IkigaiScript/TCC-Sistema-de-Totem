using System;

namespace Backend.Business
{
    public class LoginBusiness
    {
        Database.IdBase ConsTBase = new Database.IdBase();
        Database.LoginDatabase db = new Database.LoginDatabase();
        public Models.TbPedido Iniciar(Models.TbLogin tb)
        {
            Models.TbLogin login = new Models.TbLogin();
            if(!string.IsNullOrEmpty(tb.DsEmail))
            {
                Models.TbLogin login1 = ConsTBase.Login(tb.DsEmail,tb.DsSenha);
                if(login1 == null) throw new ArgumentException("Login não encontrado");

                login = login1;
            }
            return db.Iniciar(login);
        }
    }
}