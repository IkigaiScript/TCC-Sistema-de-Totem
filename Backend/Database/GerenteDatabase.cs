using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using Backend.Models;
using Backend.Utils;
using Backend.Models.Response.Gerente;

namespace Backend.Database
{
    public class GerenteDatabase
    {
        GerenteConversor conv = new GerenteConversor();
        tcdbContext ctx = new tcdbContext();
        public List<VendasPorDia> VendasDoDia(int dia)
        {
            DateTime data = new DateTime(DateTime.Now.Year,DateTime.Now.Month,dia);
            List<TbPedido> pedido = ctx.TbPedido.Where(x => x.DtHorario.Value.Day == data.Day &&
                                                            x.DtHorario.Value.Month == data.Month &&
                                                            x.DtHorario.Value.Year == data.Year )
                                                .ToList();

            List<VendasPorDia> vendas = new List<VendasPorDia>();

            foreach(TbPedido ped in pedido)
            {
                string cliente = "Totem";
                if(ped.IdLogin != 1 && ped.IdLogin != 2)
                {
                    cliente = ctx.TbCliente.FirstOrDefault(y => y.IdLogin == ped.IdLogin).NmCliente;
                }

                VendasPorDia venda = conv.VendasPorDia(ped.IdPedido,ped.DtHorario.Value,cliente,ped.VlTotal.ToString());
                vendas.Add(venda);
            }
            
            return vendas;
        }

        public List<VendasPorMes> VendasdoMes(int inicio, int final)
        {
            List<VendasPorMes> vendas = new List<VendasPorMes>();

            while(inicio <= final)
            {
                List<TbPedido> pedidos = ctx.TbPedido.Where(x => x.DtHorario.Value.Month == final).ToList();
                
                float total = (float) pedidos.Sum(x => x.VlTotal).Value;
                VendasPorMes venda = conv.VendasPorMes(final,pedidos.Count,total);
                vendas.Add(venda);
                final--;
            }

            return vendas;
        }

        public List<TopFilmes> TopFilmes()
        {
             List<TbFilme> filmes = ctx.TbFilme.Include(x => x.TbSessao)  
                                                .ThenInclude(y => y.TbIngresso)
                                                .ToList();

            List<TopFilmes> ret = new List<TopFilmes>();

            foreach(TbFilme filme in filmes)
            {
                int ingressos = 0;
                foreach(TbSessao sessao in filme.TbSessao)
                {
                    ingressos += sessao.TbIngresso.Count;
                } 

                ret.Add(conv.TopFilmes(filme,ingressos));
            }

            return ret.OrderByDescending(x => x.Qtd)
                      .Take(15)
                      .ToList();            
        } 

        public List<TopProdutos> TopProdutos()
        {
            List<TbSnackBar> produtos = ctx.TbSnackBar.Include(x => x.TbPedidoSnackBar)
                                                        .ToList();

            List<TbCombo> combos =  ctx.TbCombo.Include(x => x.TbPedidoCombo)
                                                .ToList();

            List<TopProdutos> ret = new List<TopProdutos>();
            foreach(TbSnackBar produto in produtos)
            {
                int qtd = 0;
                foreach(TbPedidoSnackBar pedidoSnackBar in produto.TbPedidoSnackBar)
                {
                    qtd += pedidoSnackBar.NrQtdSnackBar;
                }

                ret.Add(conv.TopProdutos(produto.NmProduto,(float) (produto.VlPreco * qtd),qtd,(float) produto.VlPreco,produto.DsImagem,produto.DsTipoProduto));
            }

            foreach(TbCombo combo in combos)
            {
                int qtd = 0;
                foreach(TbPedidoCombo pedidoCombo in combo.TbPedidoCombo)
                {
                    qtd += pedidoCombo.NrQtdCombo;
                }

                ret.Add(conv.TopProdutos(combo.NmCombo,(float) (combo.VlPreco * qtd),qtd,(float) combo.VlPreco,combo.DsImagem,"Combo"));
            }

            return ret.OrderByDescending(x => x.Qtd)
                      .Take(10)
                      .ToList();  
        }

        public TotemLogins TotemLogins()
        {
           List<TbPedido> peds = ctx.TbPedido.ToList(); 
           List<TbPedido> pedidos = ctx.TbPedido.Where(x => x.IdLogin == 1 || x.IdLogin == 2)
                                                .ToList();

            TotemLogins ret = conv.TotemLogins(pedidos.Count,peds.Count - pedidos.Count);
            return  ret;
        }
    }
}