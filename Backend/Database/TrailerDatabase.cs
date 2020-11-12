using System;
using Microsoft.EntityFrameworkCore;
using System.Linq;

using Backend.Models;

namespace Backend.Database
{
    public class TrailerDatabase
    {
        tcdbContext ctx = new tcdbContext();   
        public string LerVideo(int id)
        {
            Random rand = new Random();
            TbFilme filme = ctx.TbFilme.Include(x => x.TbTrailer).FirstOrDefault(x => x.IdFilme == id);
            int value = rand.Next(0,filme.TbTrailer.Count - 1);
            return filme.TbTrailer.ToList()[value].NmTrailer;
        }
    }
}