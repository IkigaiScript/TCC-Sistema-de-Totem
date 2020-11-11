using System;

using Backend.Database;
using Backend.Models;

namespace Backend.Business
{
    public class SessaoBusiness
    {
        IdBase ConstBase = new IdBase();
        public TbSessao Consultar(int id)
        {
            TbSessao ses = ConstBase.Sessao(id);
            if(ses == null) throw new ArgumentException("Sessão não existe");

            return ses;
        }
    }
}