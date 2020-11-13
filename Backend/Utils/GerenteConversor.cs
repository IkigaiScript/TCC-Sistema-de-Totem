using System;

using Backend.Models.Response.Gerente;
using Backend.Models;

namespace Backend.Utils
{
    public class GerenteConversor
    {
        public VendasPorDia VendasPorDia(int pedido,DateTime dia,string cliente, string total)
        {
            return new VendasPorDia {
                Pedido = pedido,
                Dia = dia.ToLongDateString(),
                Total = total,
                Cliente = cliente,
                Hora = dia.ToLongTimeString()
            };
        }

        public VendasPorMes VendasPorMes(int mes,int qtd,float total)
        {
            return new VendasPorMes() {
                Mes = mes,
                Qtd = qtd,
                Total = total
            };
        } 

        public TopFilmes TopFilmes(TbFilme filme,int qtd)
        {
            return new TopFilmes {
                Qtd = qtd,
                Nome = filme.NmFilme,
                Genero = filme.DsGenero,
                Imagem = filme.DsImagem,
                Id = filme.IdFilme
            };
        } 

        public TopProdutos TopProdutos(string nome,float total,int qtd,float valor,string imagem,string tipo)
        {
            return new TopProdutos {
                Total = total,
                Valor = valor,
                Qtd = qtd,
                Nome = nome,
                Imagem = imagem,
                Tipo = tipo
            };
        }

        public TotemLogins TotemLogins(int totem,int login)
        {
            return new TotemLogins {
                Totem = totem,
                Login = login                
            };
        } 
    }
}