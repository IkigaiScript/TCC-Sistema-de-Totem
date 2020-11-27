using Backend.Models;
using Backend.Models.Request;

namespace Backend.Utils
{
    public class TrailerConversor
    {
        public TbTrailer ParaTabela(TrailerRequest req)
        {
            return new TbTrailer {
                BtDublado = req.Dublado,
                NrDuracao = req.Duracao,
                IdFilme = req. Filme
            };
        }
    }
}