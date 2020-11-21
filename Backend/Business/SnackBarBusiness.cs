using System;
using System.Collections.Generic;

using Backend.Database;
namespace Backend.Business
{
    public class SnackBarBusiness
    {
        SnackBarDatabase db = new SnackBarDatabase();
        public List<Models.TbSnackBar> Consultar(string tipoProduto)
        {
            if(tipoProduto.ToLower() != "doce" &&
               tipoProduto.ToLower() != "pipoca" &&
               tipoProduto.ToLower() != "bebida") throw  new ArgumentException($"{tipoProduto} não é um tipo de produto valido");

            List<Models.TbSnackBar> snacks = db.Consultar(tipoProduto);

            if(snacks.Count == 0) throw new ArgumentException("Nenhum snackbar encontrado");
            return snacks;
        }
    }
}