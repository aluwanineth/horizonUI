using Blazored.LocalStorage;
using HorizonPollyC.Components;
using HorizonPollyC.Models;
using Microsoft.AspNetCore.Components;
using System.Text.Json;

namespace HorizonPollyC.Shared
{

    partial class MainLayout
    {

        [CascadingParameter]
        public GlobalVariables? userInfo { get; set; }

        [CascadingParameter]
        public TimerService _timerService { get; set; }


        public EventCallback setRefreshEventTimer => EventCallback.Factory.Create(this, setRefreshTimer);

        AuthResult existingTokens;
        protected override async Task OnInitializedAsync()
        {

            if (userInfo == null)
                userInfo = new GlobalVariables();

            if (_timerService == null)
                _timerService = new TimerService();

            _timerService.OnElapsed -= setRefreshTimer;
            _timerService.OnElapsed += setRefreshTimer;

            setRefreshTimer(true);

            userInfo = new GlobalVariables();
            var tempValue = await _localStorageService.GetItemAsStringAsync("LoggedInUser");
            userInfo.LoggedInUser = (tempValue == null ? "" : tempValue.Replace("\"", ""));

        }

        internal async void setRefreshTimer()
        {
            setRefreshTimer(false);
        }

        internal async void setRefreshTimer(bool initialLoad)
        {
            Console.WriteLine("set refreshtoken");
            if (initialLoad)
            {
                _timerService.SetTimer(60000);
            }
            else
            {
                existingTokens = await _localStorageService.GetItemAsync<AuthResult>("authResult");
                if (existingTokens != null)
                    GetandSetTimerFromToken(existingTokens);
                else
                    _timerService.SetTimer(30000);
            }

        }

        internal async void GetandSetTimerFromToken(AuthResult authresults)
        {
            //date issues here this may need to change if we fix the globalization 
            DateTime ExpiryToken = existingTokens.Expiration.AddHours(2);

            //we get the new token a min before the old one expires
            TimeSpan ts = ExpiryToken - DateTime.Now.AddMinutes(1);

            //check the timer if its less than a minute remaining then get a new one and set the timer again, else come back later
            if (ts.TotalMinutes <= 1)
            {
                await RefreshToken(existingTokens);
                setRefreshTimer(false);
            }
            else
            {
                _timerService.SetTimer(ts.TotalMilliseconds);
            }

        }

        public async Task RefreshToken(AuthResult authResults)
        {
            await AuthenticationService.RefreshToken(authResults);
        }

    }
}
