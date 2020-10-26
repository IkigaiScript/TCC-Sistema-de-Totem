using System;

namespace Backend.Business
{
    public class CupomDescontoBusiness
    {
        Database.IdBase ConstBase = new Database.IdBase();
        Database.CupomDescontoDatabase db = new Database.CupomDescontoDatabase();
        public Models.TbPedido Consultar(string codigo, int pedido)
        {
            Models.TbCupomDesconto cupom = db.Desconto(codigo);
            Models.TbPedido ped = ConstBase.Pedido(pedido);
            
            if(codigo.Length != 4) throw new ArgumentException("Código inválido");

            if(cupom == null) throw new ArgumentException("Cupom não encontrado");

            if(ped.VlTotal < cupom.VlDesconto) throw new ArgumentException("Valor insuficiente");

            if(ped.VlTotal <= 0 || ped.VlTotal == null) throw new ArgumentException("Pedido não possui calculo do preço");

            if(ped == null) throw new ArgumentException("Pedido não existe");

            if(cupom.VlDesconto <= 0) throw new ArgumentException("Cupom não possui nenhum valor");

            if(ped.IdCupomDesconto != 0 &&
                ped.IdCupomDesconto != null) throw new ArgumentException("Um Cupom ja foi adicionado");

            return db.Consultar(cupom.IdCupomDesconto,ped.IdPedido);
        }
    }
}