using System;
using System.Collections.Generic;

using Backend.Models;
using Backend.Database;
namespace Backend.Business
{
    public class ComboBusiness
    {
        ComboDatabase db = new ComboDatabase();
        public List<TbCombo> Consultar()
        {
            List<TbCombo> combos = db.Consultar();

            if(combos.Count == 0) throw new ArgumentException("Nenhum combo encontrado");
            return combos;
        }
    }
}