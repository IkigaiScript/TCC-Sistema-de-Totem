using System;

namespace Backend.Utils
{
    public class LoginConversor
    {
        public Models.TbLogin ParaTabela(Models.Request.LoginRequest req)
        {
            return new Models.TbLogin {
                DsEmail = req.Email,
                DsSenha = req.Senha
            };
        }

        public Models.Response.LoginResponse ParaResponse(Models.TbPedido tb)
        {
            return new Models.Response.LoginResponse {
                Pedido = tb.IdPedido
            };
        }
    }
}