using System;

namespace Backend.Utils
{
    public class TrailerConversor
    {
        public Models.TbTrailer ParaTabela(Models.Request.TrailerRequest req)
        {
            return new Models.TbTrailer {
                BtDublado = req.dublado,
                NrDuracao = req.duracao 
            };
        }
    }
}