using System;

namespace Backend.Business
{
    public class SessaoController
    {
        Database.IdBase ConstBase = new Database.IdBase();
        public Models.TbSessao Consultar(int sessao)
        {
            Models.TbSessao ses = ConstBase.Sessao(sessao);
            if(ses == null) throw new ArgumentException("Sessão não existe");

            return ses;
        }
    }
}