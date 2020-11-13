using System;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class LoginConversor
    {
        public TbLogin ParaTabela(LoginRequest req)
        {
            return new TbLogin {
                DsEmail = req.Email,
                DsSenha = req.Senha
            };
        }

        public LoginResponse ParaResponse(TbPedido tb,int nivel)
        {
            return new LoginResponse {
                Pedido = tb.IdPedido,
                Nivel = nivel
            };
        }
    }
}