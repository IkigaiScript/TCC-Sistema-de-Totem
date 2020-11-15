using System;
using System.Collections.Generic;
using System.Collections;

using Backend.Database;
using Backend.Models.Response.Gerente;

namespace Backend.Business
{
    public class GerenteBusiness
    {
        GerenteDatabase db = new GerenteDatabase();
        public List<VendasPorDia> VendasDoDia(int dia)
        {
            int day = DateTime.Now.AddMonths(1).AddDays(-DateTime.Now.Day).Day;
            if(dia < 1 || dia > day) throw new ArgumentException("Dia inválido");

            List<VendasPorDia> vendas = db.VendasDoDia(dia);
            if(vendas.Count == 0) throw new ArgumentException($"Nenhum pedido registado no dia {dia}");
            
            return vendas;
        }

        public List<VendasPorMes> VendasdoMes(DateTime inicio,DateTime final)
        {
            if(inicio == null) throw new ArgumentException("Mês inicial está vazio");

            if((inicio - DateTime.Now).TotalDays > 0) throw new ArgumentException("Data para o mês incial ainda não existe");

            if(inicio.Month < 1 || inicio.Month > 12) throw new ArgumentException("Mês inicial está inválido");

            if(db.DatePedExists(inicio) == null)
            {
                string text = "Nenhum pedido foi adicionado a esse mês. ";
                if(db.UltimateExists(inicio) != null) text += $"O dia mais proximo que encontramos foi {db.UltimateExists(inicio).DtHorario.ToLongDateString()}";
                
                throw new ArgumentException(text);
            } 

            if(final != new DateTime() && final != null)
            {
                if(final.Month < 1 || final.Month > 12) throw new ArgumentException("Mês final inválido");
            
                if(inicio.Year <= DateTime.Now.Year - 2 || inicio > DateTime.Now) throw new ArgumentException("Ano/Mês inicial inválido");
                
                if(final > DateTime.Now) throw new ArgumentException("Ano/Mês final inválido"); 

                if(inicio.Month != final.Month || inicio.Year != final.Year)
                {
                    if((inicio - final).TotalDays >= 1) throw new ArgumentException("Intervalo de meses inválido");                               
                }
            }
            return db.VendasdoMes(inicio,final);
        }
        public List<TopFilmes> TopFilmes()
        {
            List<TopFilmes> filmes = db.TopFilmes();

            if(filmes.Count == 0) throw new ArgumentException("Nenhum filme encontrado");
            return filmes;
        }

        public List<TopProdutos> TopProdutos()
        {
            List<TopProdutos> produtos =  db.TopProdutos();

            if(produtos.Count == 0) throw new ArgumentException("Nenhum filme encontrado");
            return produtos;
        } 

        public TotemLogins TotemLogins()
        {
            TotemLogins logins = db.TotemLogins();

            if(logins.Login == 0 && logins.Totem == 0) throw new ArgumentException("Nenhum pedido com cadastrado");         
            return logins;
        } 
    }
}