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

        public Models.TbCupomDesconto Desconto(int id)
        {
            return ctx.TbCupomDesconto.FirstOrDefault(x => x.IdCupomDesconto == id);
        }

        public Models.TbPedido Pedido(int id)
        {
            return ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id);
        }
        public Models.TbSnackBar SnackBar(int id)
        {
            return ctx.TbSnackBar.FirstOrDefault(x => x.IdSnackBar == id);
        }

        public Models.TbCombo Combo(int id)
        {
            return ctx.TbCombo.FirstOrDefault(x => x.IdCombo == id);
        }
    }
}