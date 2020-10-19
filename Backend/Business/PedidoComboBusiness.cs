using System;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Business
{
    public class PedidoComboBusiness
    {
        Database.IdBase ConstBase = new Database.IdBase();
        Database.PedidoComboDatabase db = new Database.PedidoComboDatabase();
       
        public List<Models.TbPedidoCombo> Cadastrar(List<Models.TbPedidoCombo> tbs)
        {
            foreach(Models.TbPedidoCombo tb in tbs)
            {
                if(tb.NrQtdCombo < 0 || tb.NrQtdCombo > 10) throw new ArgumentException("Quantidade do combo inválido");

                if(ConstBase.Combo((int) tb.IdCombo) == null) throw new ArgumentException("Combo não existe");

                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não existe"); 
            }

            return db.Cadastrar(tbs);
        }
    }
}