using Microsoft.AspNetCore.Mvc;
using System.IO;
using System;
using Microsoft.AspNetCore.Http;

namespace Backend.Business
{
    public class GerenciadorFotos : ControllerBase
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

       private byte[] LerFoto (string nome)
       {
           Console.WriteLine('1');
           string caminho = Path.Combine(AppContext.BaseDirectory,"Storage","Fotos",nome);
           Console.WriteLine(caminho);
           return System.IO.File.ReadAllBytes(caminho);
       }

       private string GerarContentType(string nome)
       {
           return $"image/{Path.GetExtension(nome).Replace(".","")}";
       }

       public ActionResult BuscarFoto(string nome)
       {
           byte[] photo =  this.LerFoto(nome);
           return File(photo,this.GerarContentType(nome));
       }

       public ActionResult BuscarVideo(string nome)
       {
           byte[] video = this.LerFoto(nome);
           return File(video,"video/mp4");
       }
    }
}