using System;

namespace InsertsAPI.Models.Response
{
    public class ErrorResponse
    {
        public int Code { get; set; }
        public string Error { get; set; }

        public ErrorResponse(int cod, string erro)
        {
            this.Code = cod;
            this.Error = erro;
        }
    }
}