using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SIS.Http
{
    public class HttpRequest
    {
        public HttpRequest(string httpRequestAsString)
        {
            this.Headers = new List<Header>();

            var reader = new StringReader(httpRequestAsString);

            var lines = httpRequestAsString
                       .Split(HttpConstants.NewLine, StringSplitOptions.None);

            var infoHeader = lines[0];
            var infoHeaderParts = infoHeader.Split(' ');

            if (infoHeaderParts.Length != 3)
            {
                throw new HttpServerException("Invalid HTTP Header Line!");
            }

            var httpMethod = infoHeaderParts[0];

            this.Method = httpMethod switch
            {
                "POST" => HttpMethodType.Post,
                "GET" => HttpMethodType.Get,
                "DELETE" => HttpMethodType.Delete,
                "PUT" => HttpMethodType.Put,
                _ => HttpMethodType.Unknown
            };

            this.Path = infoHeaderParts[1];

            var httpVersion = infoHeaderParts[2];

            this.Version = httpVersion switch
            {
                "HTTP/1.0" => HttpVersionType.Http10,
                "HTTP/1.1" => HttpVersionType.Http11,
                "HTTP/2.0" => HttpVersionType.Http20,
                _ => HttpVersionType.Http11
            };

            var isInHeader = true;
            var bodyBuilder = new StringBuilder();

            for (int i = 1; i < lines.Length; i++)
            {
                var line = lines[i];

                if (string.IsNullOrWhiteSpace(line))
                {
                    isInHeader = false;
                }

                if (isInHeader)
                {
                    var headerParts = line.Split(new[] { ": " }, 2, StringSplitOptions.None);

                    if (headerParts.Length != 2)
                    {
                        throw new HttpServerException(@"Invalid header: {line}");
                    }

                    var header = new Header(headerParts[0], headerParts[1]);
                    this.Headers.Add(header);
                }

                else
                {
                    bodyBuilder.AppendLine(line);
                }
            }
        }
        public HttpMethodType Method { get; set; }

        public string Path { get; set; }

        public HttpVersionType Version { get; set; }

        public IList<Header> Headers { get; set; }

        public string Body { get; set; }

    }
}
