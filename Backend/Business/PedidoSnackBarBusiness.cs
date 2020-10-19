using System;
using System.Collections;
using System.Collections.Generic;

namespace Backend.Business
{
    public class PedidoSnackBarBusiness
    {
        Database.PedidoSnackBarDatabase db = new Database.PedidoSnackBarDatabase();
        Database.IdBase ConstBase = new Database.IdBase();
        public List<Models.TbPedidoSnackBar> Cadastrar(List<Models.TbPedidoSnackBar> tbs)
        {
            foreach(Models.TbPedidoSnackBar tb in tbs)
            {
                if(tb.NrQtdSnackBar < 1 || tb.NrQtdSnackBar > 10) throw new ArgumentException("Quantidade de lanche inválido");

                if(ConstBase.SnackBar((int) tb.IdSnackBar) == null) throw new ArgumentException("Lanche não encontrado");
                // Console.WriteLine(ConstBase.Pedido((int) tb.IdPedido).IdPedido);
                if(ConstBase.Pedido((int) tb.IdPedido) == null) throw new ArgumentException("Pedido não encontrado");
            }

           return db.Cadastrar(tbs);
        }
    }
}