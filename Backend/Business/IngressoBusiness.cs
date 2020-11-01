using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class IngressoBusiness
    {
        IdBase ConstBase = new IdBase();
        IngressoDatabase db = new IngressoDatabase();
        public List<TbIngresso> ConsultarLugares(int sessao)
        {
            if(ConstBase.Sessao(sessao) == null) throw new ArgumentException("Sessão não existe.400");

            return db.ConsultarLugares(sessao);
        } 

        public void Cadastrar(List<TbIngresso> tbs)
        {
            char[] column = new char[9] {'A','B','D','E','F','G','H','J','K'};

            foreach(TbIngresso tb in tbs)
            {
                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não existe");
 
                if(ConstBase.Sessao((int) tb.IdSessao) == null) throw new ArgumentException("Sessão não existe");

                if(tb.NrPoltrona == 0) throw new ArgumentException("Número de poltrona inválido");

                if(!column.Any(x => x == tb.DsFileira.ToUpper()[0]) && tb.DsFileira.ToUpper()[0] != 'C' &&  tb.DsFileira.ToUpper()[0] != 'I') throw new ArgumentException("Fileira inválida");

                if(column.Any(x => x == tb.DsFileira.ToUpper()[0])  && (tb.NrPoltrona < 1 || tb.NrPoltrona > 6)) throw new ArgumentException("Poltrona não existe nessa fileira");

                if((tb.DsFileira.ToUpper()[0] == 'C' || tb.DsFileira.ToUpper()[0] == 'I') && (tb.NrPoltrona < 1 || tb.NrPoltrona > 3)) throw new ArgumentException("Poltrona não existe nessa fileira");
            }

            List<TbIngresso> ingressos = db.Cadastrar(tbs);
        }
    }
}