
using Blazored.LocalStorage;
using HorizonPollyC.Components;
using HorizonPollyC.Models;
using Microsoft.AspNetCore.Components;
using System.ComponentModel.Design;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HorizonPollyC.Services.Authentication
{

    public class AuthenticationService : IAuthenticationService
    {
        HttpClient httpClient;
        private NavigationManager _navigationManager;
        private ILocalStorageService _localStorageService;

        public AuthResult authResult { get; set; }
        public User User { get; set; }
        private readonly IConfiguration _configuration;

        string BaseURIConfig;

        public AuthenticationService(
                HttpClient client,
                NavigationManager navigationManager,
                ILocalStorageService localStorageService,
                IConfiguration Configuration
            )
        {
            httpClient = client;
            _navigationManager = navigationManager;
            _localStorageService = localStorageService;
            _configuration = Configuration;


            BaseURIConfig = _configuration["BaseURLAuthentication"];

        }

        public async Task Initialize()
        {
            var result = await _localStorageService.GetItemAsStringAsync("authResult");
            if (result == null)
            {
                return;
            }
            authResult = JsonSerializer.Deserialize<AuthResult>(result);
        }


        public async Task Login(User userModel)
        {
            await _localStorageService.RemoveItemAsync("authResult");

            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "/login", userModel);

            switch (result.StatusCode)
            {
                case System.Net.HttpStatusCode.OK:

                    authResult = await result.Content.ReadFromJsonAsync<AuthResult>();

                    var jwt = new JwtSecurityTokenHandler().ReadJwtToken(authResult.Token);
                    string AvailableFeatures = jwt.Claims.First(c => c.Type == "AvailableFeatures").Value;

                    await _localStorageService.SetItemAsync("AvailableFeatures", AvailableFeatures);
                    await _localStorageService.SetItemAsync("authResult", authResult);
                    await _localStorageService.SetItemAsync("LoggedInUser", userModel.username);
                    break;

                case System.Net.HttpStatusCode.Unauthorized:
                    throw new AccessViolationException("Incorrect username or password");

                default:
                    throw new AccessViolationException("Incorrect username or password");
            }
        }

        public async Task RefreshToken(AuthResult authResult)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "/refreshToken", authResult);
            authResult = result.Content.ReadFromJsonAsync<AuthResult>().Result;

            await _localStorageService.SetItemAsync("authResult", authResult);
        }

        public async Task Logout()
        {
            User = null;
            await _localStorageService.RemoveItemAsync("authResult");
            _navigationManager.NavigateTo("");
        }
    }

}
