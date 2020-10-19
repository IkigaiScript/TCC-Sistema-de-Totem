using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Backend.Business
{
    public class IngressoBusiness
    {
        Database.IdBase ConstBase = new Database.IdBase();
        Database.IngressoDatabase db = new Database.IngressoDatabase();
        public List<Models.TbIngresso> ConsultarLugares(int sessao)
        {
            if(ConstBase.Sessao(sessao) == null) throw new ArgumentException("Sessão não existe.400");

            return db.ConsultarLugares(sessao);
        } 

        public void Cadastrar(List<Models.TbIngresso> tbs)
        {
            char[] column = new char[9] {'A','B','D','E','F','G','H','J','K'};

            foreach(Models.TbIngresso tb in tbs)
            {
                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não existe");
 
                if(ConstBase.Sessao((int) tb.IdSessao) == null) throw new ArgumentException("Sessão não existe");

                if(tb.NrPoltona == 0) throw new ArgumentException("Número de poltrona inválido");

                if(!column.Any(x => x == tb.DsFileira.ToUpper()[0]) && tb.DsFileira.ToUpper()[0] != 'C' &&  tb.DsFileira.ToUpper()[0] != 'I') throw new ArgumentException("Fileira inválida");

                if(column.Any(x => x == tb.DsFileira.ToUpper()[0])  && (tb.NrPoltona < 1 || tb.NrPoltona > 6)) throw new ArgumentException("Poltrona não existe nessa fileira");

                if((tb.DsFileira.ToUpper()[0] == 'C' || tb.DsFileira.ToUpper()[0] == 'I') && (tb.NrPoltona < 1 || tb.NrPoltona > 3)) throw new ArgumentException("Poltrona não existe nessa fileira");
            }

            List<Models.TbIngresso> ingressos = db.Cadastrar(tbs);
        }
    }
}