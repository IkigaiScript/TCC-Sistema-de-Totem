using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

using Backend.Models;
namespace Backend.Database
{
    public class NotaFiscalDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public void Cadastrar(TbNotaFiscal tb)
        {
            ctx.TbNotaFiscal.Add(tb);
            ctx.SaveChanges();
        }

        public bool ExitsPedido(int id)
        {
            return ctx.TbNotaFiscal.Any(x => x.IdPedido == id);
        }

        public TbNotaFiscal Consultar(int pedido)
        {
            return ctx.TbNotaFiscal.FirstOrDefault(x => x.IdPedido == pedido);
        }

        public List<TbPedidoCombo> ConsultarCombo(int pedido)
        {
            return ctx.TbPedidoCombo.Where(x => x.IdPedido == pedido)
                                    .Include(x => x.IdComboNavigation)
                                    .ToList();
        }

        public List<TbPedidoSnackBar> ConsultarSnackBar(int pedido)
        {
            return ctx.TbPedidoSnackBar.Where(x => x.IdPedido == pedido)
                                       .Include(x => x.IdSnackBarNavigation)
                                       .ToList();
        }

        public List<TbIngresso> ConsultarIngresso(int pedido)
        {
            return ctx.TbIngresso.Where(x => x.IdPedido == pedido)
                                 .Include(x => x.IdSessaoNavigation)
                                 .ToList();
        }
    }
}