using System;
using System.Collections.Generic;
using System.Linq;

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

        public List<TbFilme> ConsultarFilter(int classificacao,string genero,string sala)
        {
            string[] generos = new string[]{ "ação","acao","animação","animacao","aventura", "comédia","comedia","dança","danca","drama","espionagem", "faroeste", "fantasia", "romance", "terror", "guerra","ficcao cientifica","ficção científica", "policial", "musical", "thriller", "suspense", "guerra","infantil"};
            if(classificacao.ToString() != string.Empty && classificacao.ToString() != null)
            {
                if(classificacao < 0 || classificacao > 18) throw new ArgumentException("Classificação inválida");
            }

            if(sala != string.Empty && sala != null)
            {
                if(sala.ToUpper() != "XD" && sala.ToUpper() != "3D") throw new ArgumentException("Tipo de sala inválida");
            }

            if(genero != string.Empty && genero != null)
            {
                if(!generos.Any(x => genero.ToLower() == x)) throw new ArgumentException("Genero não existe");
            }

            return db.ConsultarFilter(genero,classificacao,sala);
        }

        public TbFilme ConsultarUNI(int id)
        {
            TbFilme filme = db.ConsultarUNI(id);

            if(filme == null) throw new ArgumentException("Filme não existe");

            return filme;   
        }
    }
}