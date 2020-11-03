using System;
using System.Collections.Generic;
using System.Linq;

using Backend.Models;
namespace Backend.Database
{
    public class ComboDatabase
    {
        tcdbContext ctx = new tcdbContext();
        public List<TbCombo> Consultar()
        {
            return ctx.TbCombo.OrderBy(x => x.NmCombo)
                              .ToList();
        }
    }
}