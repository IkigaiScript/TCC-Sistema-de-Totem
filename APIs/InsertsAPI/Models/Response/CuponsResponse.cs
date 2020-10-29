using System;

namespace InsertsAPI.Models.Response
{
    public class CuponsResponse : Request.CuponsRequest
    {
        public int Id { get; set; }
    }
}