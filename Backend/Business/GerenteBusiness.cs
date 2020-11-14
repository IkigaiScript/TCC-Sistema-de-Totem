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
            Console.WriteLine('0');
            if(inicio.Month < 1 || inicio.Month > 12) throw new ArgumentException("Mês inicial inválido");
            Console.WriteLine('1');
            if(final != new DateTime() && final != null)
            {
                Console.WriteLine('2');
                if(final.Month < 1 || final.Month > 12) throw new ArgumentException("Mês final inválido");
            
                if(final.Year <= DateTime.Now.Year - 2) throw new ArgumentException("Ano inválido"); 

                if(inicio.Month != final.Month || inicio.Year != final.Year)
                {
                    Console.WriteLine($"{inicio.Month > final.Month} + {inicio.Year > final.Year} = {inicio.Month > final.Month || inicio.Year > final.Year} ");
                    if((inicio.Month > final.Month || inicio.Year > final.Year) || (inicio.Month < final.Month && inicio.Year > final.Year)) throw new ArgumentException("Intervalo de meses inválido");            
                   
                    Console.WriteLine('3');
                }
                Console.WriteLine('4');
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
            // if(tipo.ToLower() != "doce" &&
            //     tipo.ToLower() != "pipoca" &&
            //     tipo.ToLower() != "bebida" &&
            //     tipo.ToLower() != "lanche") throw new ArgumentException("Tipo de produto inválido");

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