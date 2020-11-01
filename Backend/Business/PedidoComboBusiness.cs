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
       
        public List<TbPedidoCombo> Cadastrar(List<TbPedidoCombo> tbs)
        {
            foreach(TbPedidoCombo tb in tbs)
            {
                if(tb.NrQtdCombo < 0 || tb.NrQtdCombo > 10) throw new ArgumentException("Quantidade do combo inválido");

                if(ConstBase.Combo((int) tb.IdCombo) == null) throw new ArgumentException("Combo não existe");

                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não existe"); 
            }

            return db.Cadastrar(tbs);
        }
    }
}