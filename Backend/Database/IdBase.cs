using System;
using System.Linq;
using System.Collections.Generic;

namespace Backend.Database
{
    public class IdBase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbSessao Sessao(int id)
        {
            return ctx.TbSessao.FirstOrDefault(x => x.IdSessao == id);
        } 

        public Models.TbLogin Login (int id)
        {
            return ctx.TbLogin.FirstOrDefault(x => x.IdLogin == id);
        }

        public Models.TbCupomDesconto Desconto(string codigo)
        {
            return ctx.TbCupomDesconto.FirstOrDefault(x => x.DsCodigo == codigo);
        }

        public Models.TbPedido Pedido(int id)
        {
            return ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id);
        }

        public Models.TbSnackBar SnackBar(int id)
        {
            return ctx.TbSnackBar.FirstOrDefault(x => x.IdSnackBar == id);
        }

        public List<Models.TbPedidoSnackBar> PedidoSnackBar(int id)
        {
            return ctx.TbPedidoSnackBar.Where(x => x.IdPedido == id).ToList();
        }

        public List<Models.TbPedidoCombo> PedidoCombo(int id)
        {
            return ctx.TbPedidoCombo.Where(x => x.IdPedido == id).ToList();
        }

        public List<Models.TbIngresso> Ingressos(int id)
        {
            return ctx.TbIngresso.Where(x => x.IdPedido == id).ToList();
        }

        public Models.TbCombo Combo(int id)
        {
            return ctx.TbCombo.FirstOrDefault(x => x.IdCombo == id);
        }
    }
}