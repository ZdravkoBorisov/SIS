using System.Threading.Tasks;

namespace SIS.Http
{
    public interface IHttpServer
    {
        Task StartAsync();

        void Stop();

        Task Reset();
    }
}
