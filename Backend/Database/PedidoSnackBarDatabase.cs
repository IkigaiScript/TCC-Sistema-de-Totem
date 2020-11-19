using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

using Backend.Models;
namespace Backend.Database
{
    public class PedidoSnackBarDatabase
    {
        tcdbContext ctx = new tcdbContext();

        public void Cadastrar (List<TbPedidoSnackBar> tbs)
        {
            for(int i=0; i < tbs.Count; i++)
            {
                if(ctx.TbPedidoSnackBar.Any(x => x.IdPedido == tbs[i].IdPedido && x.IdSnackBar == tbs[i].IdSnackBar))
                {
                    TbPedidoSnackBar pedido = ctx.TbPedidoSnackBar.FirstOrDefault(x => x.IdPedido == tbs[i].IdPedido && x.IdSnackBar == tbs[i].IdSnackBar);
                    pedido.NrQtdSnackBar += tbs[i].NrQtdSnackBar;
                    tbs.Remove(tbs[i]);
                }
            }

            ctx.TbPedidoSnackBar.AddRange(tbs);
            ctx.SaveChanges();

            foreach(TbSnackBar snackBar in ctx.TbSnackBar)
            {
                if(tbs.Any(x => x.IdSnackBar == snackBar.IdSnackBar))
                        snackBar.NrQtdEstoque -= tbs.FirstOrDefault(x => x.IdSnackBar == snackBar.IdSnackBar).NrQtdSnackBar; 
            }            

            ctx.SaveChanges();
        }      

        public List<TbPedidoSnackBar> Historico(int id)
        {
            return ctx.TbPedidoSnackBar.Where(x => x.IdPedido == id).ToList();
        } 
    }
}