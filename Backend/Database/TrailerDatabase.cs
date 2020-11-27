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
            TbTrailer trailer = ctx.TbTrailer.FirstOrDefault(x => x.IdFilme == id); 
            return trailer.NmTrailer;
        }
    }
}