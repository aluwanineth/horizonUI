using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Security.Claims;
using System.Text.Json;
using System.Threading.Tasks;

using Blazored.LocalStorage;
using HorizonPollyC.Models;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http.Headers;

namespace HorizonPollyC.Components
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly HttpClient _httpClient;
        private readonly ILocalStorageService _localStorageService;
      

        public CustomAuthenticationStateProvider(HttpClient httpClient, ILocalStorageService localStorageService)
        {
            _httpClient = httpClient;
            _localStorageService = localStorageService;

        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            AuthResult currentUser = await GetUserAuthentication(); 

            if (currentUser != null && currentUser.UserName != null)
            {
                //create a claims
                var claimNameIdentifier = new Claim(ClaimTypes.NameIdentifier, currentUser.UserName);
                //create claimsIdentity
                var claimsIdentity = new ClaimsIdentity(new[] { claimNameIdentifier }, "serverAuth");
                //create claimsPrincipal
                var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);
                var yourFeatures = await _localStorageService.GetItemAsStringAsync("AvailableFeatures");
                var cleanedupList = yourFeatures.Replace("\"", "");//its doing stupid string things

                foreach (var item in cleanedupList.Split(','))
                {
                    var claimFeature = new Claim(ClaimTypes.Role, item.Replace("\" ",""));
                    var claimsFeatureIdentity= new ClaimsIdentity(new[] { claimFeature }, "serverAuth");
                    claimsPrincipal.AddIdentity(claimsFeatureIdentity);
                }

                return new AuthenticationState(claimsPrincipal);
            }
            else
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async Task<AuthResult> GetUserAuthentication()
        {
            //pulling the token from localStorage
            var results = await _localStorageService.GetItemAsStringAsync("authResult");
            if (results == null) 
                return null;
            else
            {
                return JsonSerializer.Deserialize<AuthResult>(results);
            }             
        }

        public async Task StartTimerForRefreshToken()
        {
            throw new NotImplementedException();
        }

    }
}