using System;
using System.Collections.Generic;

namespace Backend.Business
{
    public class FilmeBusines
    {
        Database.FilmeDatabase db = new Database.FilmeDatabase();
        public List<Models.TbFilme> ConsultaParcial(string nome)
        {
            List<Models.TbFilme> Filmes = db.ConsultaParcial(nome);

            if(Filmes.Count == 0) throw new ArgumentException("Nenhum filme encontrado");
            return Filmes;
        }
    }
}