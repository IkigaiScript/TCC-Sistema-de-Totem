using System;
using System.Collections.Generic;
using System.Linq;

namespace InsertsAPI.Utils
{
    public class LoginsConversor
    {
        public Models.Response.LoginsResponse ParaResponse(Models.TbLogin tb)
        {
            return new Models.Response.LoginsResponse {
                Id = tb.IdLogin,
                Senha = tb.DsSenha,
                Email = tb.DsEmail
            };
        }

        public Models.TbLogin ParaTabela(Models.Request.LoginsRequest req)
        {
            return new Models.TbLogin {
                DsSenha = req.Senha,
                DsEmail = req.Email
            };
        }

        public List<Models.TbLogin> ParaListaTabela(List<Models.Request.LoginsRequest> reqs)
        {
            return reqs.Select(x => this.ParaTabela(x)).ToList();
        }

        public List<Models.Response.LoginsResponse> ParaListaResponse(List<Models.TbLogin> tbs)
        {
            return tbs.Select(x => this.ParaResponse(x)).ToList();
        }
    }
}