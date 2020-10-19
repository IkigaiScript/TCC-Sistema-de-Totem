namespace Backend.Utils
{
    public class FilmeConversor
    {
        public Models.Response.FilmeResponse ParaResponse(Models.TbFilme tb)
        {
            return new Models.Response.FilmeResponse
            {
                IdFilme = tb.IdFilme,

                NmFilme = tb.NmFilme,

                DsGenero = tb.DsGenero,

                DsSinopse = tb.DsSinopse,

                DsImagem = tb.DsImagem,

                NrClassificacao =tb.NrClassficacao,

                NrDuracao = tb.NrDuracao,

                BtBreve = tb.BtBreve,
            };
        }
    }
}