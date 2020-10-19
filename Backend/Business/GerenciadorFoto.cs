using System.IO;
using System;
using Microsoft.AspNetCore.Http;

namespace Trailer_API.Business
{
    public class GerenciadorFotos
    {
       public string GerarNovoNome(string nome)
       {
           return Guid.NewGuid() + Path.GetExtension(nome);
       }

       public void salvarFoto(string nome, IFormFile imagem)
       {
           string caminho = Path.Combine(AppContext.BaseDirectory,"Storage","Fotos",nome);
           using(FileStream s = new FileStream(caminho,FileMode.Create))
           {
               imagem.CopyTo(s);
           }
       }

       public byte[] LerFoto (string nome)
       {
           string caminho = Path.Combine(AppContext.BaseDirectory,"Storage","Fotos",nome);
           return File.ReadAllBytes(caminho);
       }

       public string GerarContentType(string nome)
       {
           return $"image/{Path.GetExtension(nome).Replace(".","")}";
       }
        
    }
}