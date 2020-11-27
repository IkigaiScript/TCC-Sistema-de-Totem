using System;

using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class SessaoConversor
    {
        public SessaoResponse ParaResponse(TbSessao tb)
        {
            return new SessaoResponse {
              Id = tb.IdSessao,
              Valor = (float) tb.VlIngresso,
              TipoSala = tb.DsTipoSala,
              Horario = tb.DtHorario,
              Filme = tb.IdFilme,
              Sala = tb.NrSala,
            };
        }
    }
}