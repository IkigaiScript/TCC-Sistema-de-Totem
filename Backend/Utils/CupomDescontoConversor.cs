namespace Backend.Utils
{
    public class CupomDescontoConversor
    {
        public Models.Response.CupomDescontoResponse ParaResponse(float valor, string nome)
        {
            return new Models.Response.CupomDescontoResponse {
                Valor = valor,
                Nome = nome
            };
        }
    }
}