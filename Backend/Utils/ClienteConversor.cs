using System;
using System.Linq;
using System.Collections.Generic;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class ClienteConversor
    {
        public ClienteResponse ParaResponse(TbCliente tb)
        {
            return new ClienteResponse{
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