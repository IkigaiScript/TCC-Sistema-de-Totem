using System;
using System.Collections;
using System.Collections.Generic;

using Backend.Database;
using Backend.Models;

namespace Backend.Business
{
    public class PedidoComboBusiness
    {
        IdBase ConstBase = new IdBase();
        PedidoComboDatabase db = new PedidoComboDatabase();
       
        public void Cadastrar(List<TbPedidoCombo> tbs)
        {
            foreach(TbPedidoCombo tb in tbs)
            {
                if(tb.NrQtdCombo < 0 || tb.NrQtdCombo > 10) throw new ArgumentException("Quantidade do combo inválido");

                if(ConstBase.Combo((int) tb.IdCombo) == null) throw new ArgumentException("Combo não existe");

                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não existe"); 
            }

            db.Cadastrar(tbs);
        }

        public List<TbPedidoCombo> Historico(int id)
        {
            if(ConstBase.Pedido(id) == null) throw new ArgumentException("Pedido não encontrado");

            return db.Historico(id);
        }

        public void Deletar(int pedido, int combo)
        {
            if(ConstBase.Pedido(pedido) == null) throw new ArgumentException("Pedido não encontrado");

            if(ConstBase.Combo(combo) == null) throw new ArgumentException("Combo não encontrado");
     
            TbPedidoCombo tb = db.ConsultExits(pedido,combo);
            if(tb == null) throw new ArgumentException("Esse combo não foi registrado ao seu pedido");
        
            db.Deletar(tb);
        }
    }
}