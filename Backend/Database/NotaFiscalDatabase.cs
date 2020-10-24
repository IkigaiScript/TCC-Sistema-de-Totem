using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Backend.Database
{
    public class NotaFiscalDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public int Cadastrar(Models.TbNotaFiscal tb)
        {
            ctx.TbNotaFiscal.Add(tb);
            ctx.SaveChanges();
            return tb.IdPedido.Value;
        }

        public bool ExitsPedido(int id)
        {
            return ctx.TbNotaFiscal.Any(x => x.IdPedido == id);
        }

        public Models.TbNotaFiscal Consultar(int pedido)
        {
            return ctx.TbNotaFiscal.FirstOrDefault(x => x.IdPedido == pedido);
        }

        public List<Models.TbPedidoCombo> ConsultarCombo(int pedido)
        {
            return ctx.TbPedidoCombo.Where(x => x.IdPedido == pedido)
                                    .Include(x => x.IdComboNavigation)
                                    .ToList();
        }

        public List<Models.TbPedidoSnackBar> ConsultarSnackBar(int pedido)
        {
            return ctx.TbPedidoSnackBar.Where(x => x.IdPedido == pedido)
                                       .Include(x => x.IdSnackBarNavigation)
                                       .ToList();
        }
    }
}