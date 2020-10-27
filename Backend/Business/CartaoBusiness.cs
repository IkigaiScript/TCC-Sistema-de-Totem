using System;
using RestSharp;
using RestSharp.Authenticators;
using System.Collections.Generic;

namespace Backend.Business
{
    public class CartaoBusiness : Cryptography
    {
        Database.CartaoDatabase db = new Database.CartaoDatabase();
        Database.IdBase ConsTBase = new Database.IdBase();
        public Models.TbCartao Cadastrar(Models.TbCartao tb, int cvv, int senha, string pagamento)
        {
            if(ConsTBase.Pedido(tb.IdPedido.Value) == null) throw new ArgumentException("Pedido não existe");  

            if(cvv != 3) throw new ArgumentException("CVV inválido");

            if(tb.NrCartao.Value != 16) throw new ArgumentException("Numero de cartão inválido");

            if(pagamento.ToLower() != "debito" &&
                pagamento.ToLower() != "credito") throw new ArgumentException("Forma de pagamento inválido");

            // consulta API de banco 
            // mandar consulta para o banco depois de validar
            // tb.NrCartao = CriarHash(tb.NrCartao);
            return db.Cadastrar(tb);
        }
    }
}