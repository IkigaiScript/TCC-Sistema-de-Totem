using System;

namespace Backend.Business
{
    public class CupomDescontoBusiness
    {
        Database.IdBase ConstBase = new Database.IdBase();
        Database.CupomDescontoDatabase db = new Database.CupomDescontoDatabase();
        public Models.TbPedido Consultar(string codigo, int pedido)
        {
            Models.TbCupomDesconto cupom = ConstBase.Desconto(codigo);
            Models.TbPedido ped = ConstBase.Pedido(pedido);
            Console.WriteLine("1");
            if(codigo.Length != 4) throw new ArgumentException("Código inválido");

            if(cupom == null) throw new ArgumentException("Cupom não encontrado");

            if(ped.VlTotal < ConstBase.Desconto(codigo).VlDesconto) throw new ArgumentException("Valor insuficiente");

            if(ped == null) throw new ArgumentException("Pedido não existe");

            if(ped.IdCupomDesconto != 0 &&
                ped.IdCupomDesconto != null) throw new ArgumentException("Um Cupom ja foi adicionado");
            Console.WriteLine("2");
            return db.Consultar(cupom,ped);
        }
    }
}