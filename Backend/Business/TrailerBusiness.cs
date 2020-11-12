using System;

using Backend.Database;
using Backend.Models;

namespace Backend.Business
{
    public class TrailerBusiness
    {
        TrailerDatabase db = new TrailerDatabase();
        IdBase ConstBase = new IdBase();
        public string LerVideo(int id)
        {
           TbFilme filme = ConstBase.Filme(id);
           if(filme == null) throw new ArgumentException("Filme não encontrado");

            return db.LerVideo(id);
        }
    }
}