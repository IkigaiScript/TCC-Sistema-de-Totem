using System;
using System.Collections.Generic;

using Backend.Database;
using Backend.Models;
namespace Backend.Business
{
    public class FilmeBusines
    {
        IdBase ConsTBase = new IdBase();
        FilmeDatabase db = new FilmeDatabase();
        public List<TbFilme> ConsultaParcial(string nome)
        {
            List<TbFilme> Filmes = db.ConsultaParcial(nome);

            if(Filmes.Count == 0) throw new ArgumentException("Nenhum filme encontrado");
            return Filmes;
        }

        public List<TbFilme> Consultar()
        {
            List<TbFilme> filmes = db.Consultar();

            if(filmes.Count == 0) throw new ArgumentException("Nenhum filme disponivel");
            return filmes;
        }

        public List<TbFilme> ConsultarBreve()
        {
            List<TbFilme> filmes = db.ConsultarBreve();

            if(filmes.Count == 0) throw new ArgumentException("Nenhum filme encontrado");
            return filmes;
        }

        public TbFilme ConsultarUNI(int id)
        {
            TbFilme filme = ConsTBase.Filme(id);

            if(filme == null) throw new ArgumentException("Filme não existe");
               
        }
    }
}