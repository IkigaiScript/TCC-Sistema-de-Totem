using System;

using Backend.Database;
using Backend.Models;

namespace Backend.Business
{
    public class SessaoBusiness
    {
        IdBase ConstBase = new IdBase();
        public TbSessao Consultar(int sessao)
        {
            TbSessao ses = ConstBase.Sessao(sessao);
            if(ses == null) throw new ArgumentException("Sessão não existe");

            return ses;
        }
    }
}