using SIS.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DemoApp
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var route = new List<Route>();
            route.Add(new Route("/", HttpMethodType.Get, Index));
            route.Add(new Route("/Users/Login", HttpMethodType.Get, Login));
            route.Add(new Route("/Users/Login", HttpMethodType.Post, DoLogin));
            route.Add(new Route("/Users/Login", HttpMethodType.Get, Contact));
            route.Add(new Route("/favicon.ico", HttpMethodType.Get, FavIcon));



            var httpServer = new HttpServer(80);
            await httpServer.StartAsync();
        }

        public static HttpResponse FavIcon(HttpRequest request)
        {
            throw new NotImplementedException();
        }

        public static HttpResponse Contact(HttpRequest request)
        {
            var content = "<h1>Contact</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);

            return response;
        }

        public static HttpResponse Index(HttpRequest httpRequest)
        {
            var content = "<h1>Random page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }

        public static HttpResponse Login(HttpRequest httpRequest)
        {
            var content = "<h1>Login page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html"));

            return response;
        }

        public static HttpResponse DoLogin(HttpRequest httpRequest)
        {
            var content = "<h1>Login page</h1>";
            byte[] stringContent = Encoding.UTF8.GetBytes(content);

            var response = new HttpResponse(HttpResponseCode.Ok, stringContent);
            response.Headers.Add(new Header("Content-Type", "text/html")); 

            return response;
        }
    }
}
