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
            List<TbPedido> pedido = ctx.TbPedido.Where(x => x.DtHorario.Day == data.Day &&
                                                            x.DtHorario.Month == data.Month &&
                                                            x.DtHorario.Year == data.Year )
                                                .ToList();

            List<VendasPorDia> vendas = new List<VendasPorDia>();

            foreach(TbPedido ped in pedido)
            {
                string cliente = "Totem";
                if(ped.IdLogin != 1 && ped.IdLogin != 2)
                {
                    cliente = ctx.TbCliente.FirstOrDefault(y => y.IdLogin == ped.IdLogin).NmCliente;
                }

                VendasPorDia venda = conv.VendasPorDia(ped.IdPedido,ped.DtHorario,cliente,ped.VlTotal.ToString());
                vendas.Add(venda);
            }
            
            return vendas;
        }

        public List<VendasPorMes> VendasdoMes(DateTime inicio, DateTime final)
        {
            List<VendasPorMes> vendas = new List<VendasPorMes>();

            if(final == new DateTime() || final == null) final = inicio;

            while((inicio - final.AddMonths(1)).TotalDays < -1)
            {
                List<TbPedido> pedidos = ctx.TbPedido.Where(x => x.DtHorario.Month == final.Month && x.DtHorario.Year == final.Year).ToList();
                
                float total = (float) pedidos.Sum(x => x.VlTotal).Value;

                string data = final.ToLongDateString();
                data = data.Substring(data.IndexOf("de ") + 3);
       
                string letra = data.Substring(0,1).ToUpper();
                data = string.Concat(letra,data.Substring(1)); 

                VendasPorMes venda = conv.VendasPorMes(data,pedidos.Count,total);
                vendas.Add(venda);
                final = final.AddMonths(-1);
            }
            return vendas;
        }

        public TbPedido DatePedExists(DateTime data)
        {
            return ctx.TbPedido.FirstOrDefault(x => x.DtHorario.Year == data.Year && x.DtHorario.Month == data.Month);
        }

        public TbPedido UltimateExists(DateTime data)
        {
            TbPedido ret = null;

            if(ctx.TbPedido.Any(x => x.DtHorario.Year == data.Year && x.DtHorario.Month > data.Month))
            {
                while(ret == null)
                {
                    ret = ctx.TbPedido.OrderBy(x => x.DtHorario).FirstOrDefault(x => x.DtHorario.Month == data.Month && x.DtHorario.Year == data.Year);
                    data = data.AddMonths(1);
                }
            }

            return ret;
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
                    
            ret = ret.OrderByDescending(x => x.Qtd)
                      .Take(15)
                      .ToList();            
            
            TopFilmes troca = ret[0];
            ret[0] = ret[1];
            ret[1] = troca;

            return ret;
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

            ret = ret.OrderByDescending(x => x.Qtd)
                      .Take(10)
                      .ToList();

            TopProdutos troca = ret[0];
            ret[0] = ret[1];
            ret[1] = troca;

            return ret;
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