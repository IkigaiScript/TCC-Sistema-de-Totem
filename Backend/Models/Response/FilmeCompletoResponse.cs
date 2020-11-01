using System;
using System.Collections.Generic;

namespace Backend.Models.Response
{
    public class FilmeCompletoResponse : FilmeResponse
    {
        public List<AtorResponse> Atores { get; set; }
        public List<DiretorResponse> Diretores { get; set; }
        public List<SessaoResponse> Sessoes { get; set; }
    }
}