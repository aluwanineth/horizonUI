using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using HorizonPollyC.Models;

namespace HorizonPollyC.Components
{
    public class CustomAuthorizationHandler : DelegatingHandler
    {
        HttpClient httpClient;
        private readonly IConfiguration _configuration;
        public ILocalStorageService _localStorageService { get; set; }
        public CustomAuthorizationHandler(ILocalStorageService localStorageService, HttpClient client, IConfiguration configuration)
        {
            httpClient = client;
            //injecting local storage service
            _localStorageService = localStorageService;

            _configuration = configuration;
        }

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            //getting token from the localstorage
            var jwtToken = await _localStorageService.GetItemAsync<AuthResult>("authResult");

            //adding the token in authorization header
            if (jwtToken != null)
                request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwtToken.Token);

            //sending the request
            var response = await base.SendAsync(request, cancellationToken);
            var content = await response.Content.ReadAsStringAsync();
            //if(response.StatusCode!= System.Net.HttpStatusCode.OK && response.StatusCode != System.Net.HttpStatusCode.Accepted)
            //{
            //    var ErrorResponse  = response.Content.ReadAsStringAsync().Result;
            //    throw new Exception(ErrorResponse);
            //}

            return response;
        }
    }
}