using System;
using System.Collections;
using System.Collections.Generic;

using Backend.Database;
using Backend.Models;

namespace Backend.Business
{
    public class PedidoSnackBarBusiness
    {
        PedidoSnackBarDatabase db = new PedidoSnackBarDatabase();
        IdBase ConstBase = new IdBase();
        public void Cadastrar(List<TbPedidoSnackBar> tbs)
        {
            foreach(TbPedidoSnackBar tb in tbs)
            {
                if(ConstBase.SnackBar((int) tb.IdSnackBar) == null) throw new ArgumentException("Lanche não encontrado");

                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não encontrado");
            }
            
            db.Cadastrar(tbs);
        }

        public List<TbPedidoSnackBar> Historico(int id)
        {
            if(ConstBase.Pedido(id) == null) throw new ArgumentException("Pedido não encontrado");

            return db.Historico(id);
        }
    }
}