using System;
using System.Linq;

namespace Backend.Database
{
    public class CupomDescontoDatabase
    {
        Models.tcdbContext ctx = new Models.tcdbContext();
        public Models.TbPedido Consultar(Models.TbCupomDesconto cupom, Models.TbPedido pedido)
        {
            pedido.IdCupomDesconto = cupom.IdCupomDesconto;
            Console.WriteLine(cupom.IdCupomDesconto);
            Console.WriteLine(cupom.VlDesconto);
            // pedido.VlTotal = 100;
            pedido.VlTotal -= cupom.VlDesconto; 
            Console.WriteLine(pedido.VlTotal);
            ctx.SaveChanges();
            return pedido; // falta o include
        }
    }
}