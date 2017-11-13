using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class ApiResponseMessage : iApiMessage
    {
        public string Date
        {
            get
            {
                return DateTime.Now.ToString("yyyy/MM/dd ddd hh:mm:ss");
            }
        }
        public string User { get; set; }
        public bool Success { get; set; }
        public string ContentType { get; set; }
        public string Message { get; set; }
    }
    public class ApiRequestMessage : iApiMessage
    {
        public string ContentType { get; set; }
        public string Message { get; set; }

        public string Date { get; set; }
        public string Chanel { get; set; }
        public bool Success { get; set; }
        public string User { get; set; }
    }
    interface iApiMessage
    {
        string ContentType { get; set; }
        string Message { get; set; }
        string Date { get; }
        bool Success { get; set; }
    }
}