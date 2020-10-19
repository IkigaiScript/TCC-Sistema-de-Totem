using System;

namespace Backend.Utils
{
    public class SessaoConversor
    {
        public Models.Response.SessaoResponse ParaResponse(Models.TbSessao tb)
        {
            return new Models.Response.SessaoResponse {
              Valor = (float) tb.VlIngresso,
              TipoSala = tb.DsTipoSala,
              Horario = tb.DtHorario,
              Filme = tb.IdFilme,
              Sala = tb.NrSala,
            };
        }
    }
}