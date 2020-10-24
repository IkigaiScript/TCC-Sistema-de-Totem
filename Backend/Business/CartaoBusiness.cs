using System;
using RestSharp;
using RestSharp.Authenticators;

namespace Backend.Business
{
    public class CartaoBusiness
    {
        Database.CartaoDatabase db = new Database.CartaoDatabase();
        Database.IdBase ConsTBase = new Database.IdBase();
        public Models.TbCartao Cadastrar(Models.TbCartao tb, int cvv, string senha, string pagamento)
        {
            if(ConsTBase.Pedido(tb.IdPedido.Value) == null) throw new ArgumentException("Pedido não existe");  

            if(cvv != 3) throw new ArgumentException("CVV inválido");

            if(tb.NrCartao.Value != 16) throw new ArgumentException("Numero de cartão inválido");

            foreach(char let in senha)
            {
                int num = (int) let;
                if(num < 48 || num > 57) throw new ArgumentException("Senha só pode conter numero");
            }

            if(pagamento.ToLower() != "debito" &&
                pagamento.ToLower() != "credito") throw new ArgumentException("Forma de pagamento inválido");

            // consulta API de banco 

            return db.Cadastrar(tb);
        }
    }
}