using System;

namespace InsertsAPI.Models.Response
{
    public class LoginsResponse : Request.LoginsRequest
    {
        public int Id { get; set; }        
    }
}