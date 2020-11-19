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

        public void Deletar(int pedido,int snackbar)
        {
            if(ConstBase.Pedido(pedido) == null) throw new ArgumentException("Pedido não encontrado");

            if(ConstBase.SnackBar(snackbar) == null) throw new ArgumentException("Lanche não encontrado");

            TbPedidoSnackBar tb = db.ConsultExists(pedido,snackbar);
            if(tb == null) throw new ArgumentException("Esse combo não foi registrado ao seu pedido");      

            db.Deletar(tb);     
        }
    }
}