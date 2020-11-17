using System;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class NotaFiscalConversor
    {
        public TbNotaFiscal ParaTabela(NotaFiscalRequest req)
        {
            return new TbNotaFiscal {
                DsEmail = req.Email,
                DsCpf = req.Cpf,
                IdPedido = req.Pedido
            };
        }
    }
}