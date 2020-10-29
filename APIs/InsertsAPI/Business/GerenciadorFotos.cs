using System;
using System.Collections;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace InsertsAPI.Business
{
    public class GerenciadorFotos
    {
        public string NovoNome(string txt)
        {
            return Guid.NewGuid() + Path.GetExtension(txt);
        }

        public void SalvarFoto(string nome, IFormFile file)
        {
           string caminho = Path.Combine(AppContext.BaseDirectory,"Storage","Fotos",nome);
            using(FileStream sb = new FileStream(caminho,FileMode.Create))
            {
                file.CopyTo(sb);
            }
        }
    }
}