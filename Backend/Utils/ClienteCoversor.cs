using System;
using System.Linq;
using System.Collections.Generic;


namespace Backend.Utils
{
    public class ClienteConversor
    {
        public Models.Response.ClienteResponse ParaResponse(Models.TbCliente tb)
        {
            return new Models.Response.ClienteResponse{
                Id = tb.IdCliente,
                Nome = tb.NmCliente,
                Cpf = tb.DsCpf,
                Rg = tb.DsRg,
                Celular = tb.DsCelular,
                Vip = tb.BtVip
            };
        }
    }
}