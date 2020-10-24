using System;

namespace Backend.Utils
{
    public class NotaFiscalConversor
    {
        public Models.TbNotaFiscal ParaTabela(Models.Request.NotaFiscalRequest req)
        {
            return new Models.TbNotaFiscal {
                DsEmail = req.Email,
                DsCpf = req.Cpf,
                IdPedido = req.Pedido
            };
        }

        public Models.Response.NotaFiscalResponse ParaResponse(int pedido)
        {
            return new Models.Response.NotaFiscalResponse {
                Pedido = pedido
            };
        }
    }
}