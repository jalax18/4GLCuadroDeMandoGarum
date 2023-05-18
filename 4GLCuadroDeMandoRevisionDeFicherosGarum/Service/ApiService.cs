using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Text;
using System.Net.Http.Headers;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

using System.Net;
using __4GLCuadroDeMandoRevisionDeFicherosGarum.Service;
using _4GLCuadroDeMandoRevisionDeFicherosGarum.Model;

namespace _4GLCuadroDeMandoRevisionDeFicherosGarum.Service
{
    public class ApiService : IApiService
    {



        public async Task<Response> GetTokenAsync(string urlBase, string servicePrefix, string controller, TokenRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                TokenResponse token = JsonConvert.DeserializeObject<TokenResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = token
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetautomatEstacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken)
        {
            try
            {
                //  string requestString = JsonConvert.SerializeObject(request);
                //   StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }
                List<ControlAutomatResponse> controlAutomatResponse = JsonConvert.DeserializeObject<List<ControlAutomatResponse>>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = controlAutomatResponse
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> putautomatestacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, ControlAutomatPutRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PutAsync(url, content);


                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                //FicheroGarumResponse ficheroGarum = JsonConvert.DeserializeObject<FicheroGarumResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Resultado OK",
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


        public async Task<Response> postautomatestacion(string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, ControlAutomatRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);


                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                //FicheroGarumResponse ficheroGarum = JsonConvert.DeserializeObject<FicheroGarumResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Message = "Resultado OK",
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }

        public async Task<Response> GetEstacionAsyncToken(string Name, string urlBase, string servicePrefix, string controller, string tokenType, string accessToken, EstacionRequest request)
        {
            try
            {
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase),
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                //   HttpResponseMessage response = await client.GetAsync(url);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                EstacionResponse model = JsonConvert.DeserializeObject<EstacionResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = model
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }

        }

        public async Task<Response> GetUserByEmail(
      string urlBase,
      string servicePrefix,
      string controller,
      string tokenType,
      string accessToken,
      string email)
        {
            try
            {
                EmailRequest request = new EmailRequest { Email = email };
                string requestString = JsonConvert.SerializeObject(request);
                StringContent content = new StringContent(requestString, Encoding.UTF8, "application/json");
                HttpClient client = new HttpClient
                {
                    BaseAddress = new Uri(urlBase)
                };

                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(tokenType, accessToken);
                string url = $"{servicePrefix}{controller}";
                HttpResponseMessage response = await client.PostAsync(url, content);
                string result = await response.Content.ReadAsStringAsync();

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = result,
                    };
                }

                UserResponse userResponse = JsonConvert.DeserializeObject<UserResponse>(result);
                return new Response
                {
                    IsSuccess = true,
                    Result = userResponse
                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }


    }
}