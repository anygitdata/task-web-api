using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;

namespace TaskWebApi.Models
{
    public class ResProc
    {
        public bool Result { get; set; } = false;
        public string Message { get; set; } = "ok";

        public object ObjResult { get; set; }

        public bool ChangedData { get; set; } = true;

        public HttpResponseMessage ResponseMessage { get; set; } = null;

        public static HttpResponseMessage Create_ResponseMessage(string content, string err, HttpStatusCode statusCode)
        {
            var resp = new HttpResponseMessage(statusCode)
            {
                Content = new StringContent(content),
                ReasonPhrase = err
            };


            return resp;
        }




    }
}