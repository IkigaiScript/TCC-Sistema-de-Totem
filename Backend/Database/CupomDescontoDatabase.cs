using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Collections;

using Backend.Models;
namespace Backend.Database
{
    public class CupomDescontoDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public TbPedido Consultar(int cup, int ped)
        {
            TbPedido pedido = ctx.TbPedido.FirstOrDefault(x => x.IdPedido == ped);
            TbCupomDesconto cupom = ctx.TbCupomDesconto.FirstOrDefault(x => x.IdCupomDesconto == cup);
            pedido.IdCupomDesconto = cupom.IdCupomDesconto;
            pedido.VlTotal -= cupom.VlDesconto;
            Console.WriteLine(pedido.VlTotal);
            Console.WriteLine(cupom.VlDesconto);
            ctx.SaveChanges();
            return pedido; 
        }
        public TbCupomDesconto Desconto(string codigo)
        {
            return ctx.TbCupomDesconto.FirstOrDefault(x => x.DsCodigo == codigo);
        }
    }
}