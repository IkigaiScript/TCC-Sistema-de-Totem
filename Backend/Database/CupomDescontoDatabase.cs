using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;
namespace Backend.Database
{
    public class CupomDescontoDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbPedido Consultar(int cup, int ped)
        {
            Models.TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == ped);
            Models.TbCupomDesconto cupom = ctx.TbCupomDesconto.FirstOrDefault(x => x.IdCupomDesconto == cup);
            pedido.IdCupomDesconto = cupom.IdCupomDesconto;
            pedido.VlTotal -= cupom.VlDesconto.Value;
            Console.WriteLine(pedido.VlTotal);
            Console.WriteLine(cupom.VlDesconto);
            ctx.SaveChanges();
            return pedido; 
        }
        public Models.TbCupomDesconto Desconto(string codigo)
        {
            return ctx.TbCupomDesconto.FirstOrDefault(x => x.DsCodigo == codigo);
        }
    }
}