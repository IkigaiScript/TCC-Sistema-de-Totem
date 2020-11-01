using System;
using System.Linq;
using System.Collections.Generic;

using Backend.Models;
namespace Backend.Database
{
    public class IdBase
    {
        tcdbContext ctx = new tcdbContext();
        public TbSessao Sessao(int id)
        {
            return ctx.TbSessao.FirstOrDefault(x => x.IdSessao == id);
        } 

        public TbCupomDesconto Desconto(int id)
        {
            return ctx.TbCupomDesconto.FirstOrDefault(x => x.IdCupomDesconto == id);
        }

        public TbPedido Pedido(int id)
        {
            return ctx.TbPedido.FirstOrDefault(x => x.IdPedido == id);
        }
        public TbSnackBar SnackBar(int id)
        {
            return ctx.TbSnackBar.FirstOrDefault(x => x.IdSnackBar == id);
        }

        public TbCombo Combo(int id)
        {
            return ctx.TbCombo.FirstOrDefault(x => x.IdCombo == id);
        }
    }
}