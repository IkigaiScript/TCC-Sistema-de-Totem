using System;

using Backend.Models.Request;
using Backend.Models.Response;
using Backend.Models;

namespace Backend.Utils
{
    public class CupomDescontoConversor
    {
        public CupomDescontoResponse ParaResponse(float valor, string nome)
        {
            return new CupomDescontoResponse {
                Valor = valor,
                Nome = nome
            };
        }
    }
}