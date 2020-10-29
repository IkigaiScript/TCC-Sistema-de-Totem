namespace InsertsAPI.Utils
{
    public class CombosConversor
    {
        public Models.TbCombo ParaTabela(Models.Request.CombosRequest req)
        {
            return new Models.TbCombo {
                NmCombo = req.Nome,
                VlPreco = (decimal?) req.Preco,
                DsThirdItem = req.Item3,
                DsSecondaryItem = req.Item2,
                DsFirstItem = req.Item1,
            };
        }

        public Models.Response.CombosResponse ParaResponse(Models.TbCombo tb)
        {
            return new Models.Response.CombosResponse {
                Id = tb.IdCombo,
                Nome = tb.NmCombo,
                Item1 = tb.DsFirstItem,
                Item2 = tb.DsSecondaryItem,
                Item3 = tb.DsThirdItem,
                Preco = (float) tb.VlPreco,
                Imagem = tb.DsImagem
            };
        }
    }
}