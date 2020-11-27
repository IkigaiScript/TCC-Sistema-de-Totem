using System;
using System.ComponentModel.DataAnnotations;

namespace Backend.Models.Response
{
    public class SessaoResponse
    {
        public int Id { get; set; }
        public float Valor { get; set; }
        public string TipoSala { get; set; }
        public DateTime Horario { get; set; }
        public int Filme { get; set; }
        public int Sala { get; set; }
    }
}