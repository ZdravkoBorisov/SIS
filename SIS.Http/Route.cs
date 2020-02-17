using SIS.Http;
using System;
using System.Net.Http;

namespace SIS.Http
{
    public class Route
    {
        public Route(string path, HttpMethodType methodType, Func<HttpRequest, HttpResponse> action)
        {
           this.Path = path;
           this.HttpMethod = methodType;
           this.Action = action;
        }

        public string Path { get; set; }

        public HttpMethodType HttpMethod { get; set; }

        public Func<HttpRequest,HttpResponse> Action { get; set; }
    }
}
