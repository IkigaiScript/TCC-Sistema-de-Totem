using System;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class CupomDescontoBusiness : Cryptography
    {
        IdBase ConstBase = new IdBase();
        CupomDescontoDatabase db = new CupomDescontoDatabase();
        public TbPedido Consultar(string codigo, int pedido)
        {
            TbCupomDesconto cupom = db.Desconto(CriarHash(codigo));
            TbPedido ped = ConstBase.Pedido(pedido);
            
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