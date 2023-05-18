//using ControlIncidencias.Common.Models;


using _4GLCuadroDeMandoRevisionDeFicherosGarum.Model;
using System.Threading.Tasks;

namespace __4GLCuadroDeMandoRevisionDeFicherosGarum.Service

{
    public interface IApiService
    {
        //   Task<Response> GetEstacionAsync(string Name, string urlBase, string servicePrefix, string controller);
        //Task<Response> GetEstacionAsyncToken(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken);
        Task<Response> postautomatestacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, ControlAutomatRequest request);
        Task<Response> putautomatestacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, ControlAutomatPutRequest request);
        Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request);

        Task<Response> GetEstacionAsyncToken(string Name, string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EstacionRequest request);
        Task<Response> GetautomatEstacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken);
    }

}
