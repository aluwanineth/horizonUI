using HorizonPollyC.Models;
using HorizonPollyC.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.SignalR.Client;

namespace HorizonPollyC.Pages.Chat
{
    public partial class ChatWindow
    {
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        private HubConnection? hubConnection;
        [Parameter] public string title { get; set; }
        [Parameter] public string messages { get; set; } = string.Empty;
        [Parameter] public string username { get; set; } = string.Empty;
        [Parameter] public Dictionary<string, object> parameters { get; set; }
        private string message = string.Empty;
        IEnumerable<ColleaguesVM> collegues;
        // IEnumerable<Customer> customCustomersData;
        string value = "ALFKI";
        public ChatWindow(IConfiguration Configuration)
        {
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        protected async override void OnParametersSet()
        {
            var BaseURIConfig = _configuration["BaseURLChatHub"];
            hubConnection = new HubConnectionBuilder().WithUrl(BaseURIConfig + "/chathub?username=" + username).WithAutomaticReconnect().Build();
            hubConnection.On<string, string>("ReceiveMessage", (user, message) =>
            {
                var msg = $"{(string.IsNullOrEmpty(user) ? "" : user + ": ")}{message}";
                messages += msg + "\n";
                // JSRuntime.InvokeVoidAsync("scrollToBottom", TextAreaRef);
                StateHasChanged();
            });
            await hubConnection.StartAsync();
            var colleguesList = new List<ColleaguesVM>();
        //    colleguesList.AddRange(new List<ColleaguesVM>{
        //    new ColleaguesVM {ColleagueId = 1,ColleagueName = "Greg", GroupName = "PolyC" ,Department = "BSS"},
        //    new ColleaguesVM {ColleagueId = 1,ColleagueName = "Darryl", GroupName = "PolyC" ,Department = "BSS" },
        //    new ColleaguesVM {ColleagueId = 1,ColleagueName = "Mieke", GroupName = "PolyC" ,Department = "BSS" }
        //});
        //    collegues = colleguesList.AsEnumerable();
        }
        void OnChange(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;
            // console.Log($"{name} value changed to {str}");
        }
        private async Task Send()
        {
            if (hubConnection != null)
            {
                await hubConnection.SendAsync("AddMessageToChat", username, message);
                message = string.Empty;
            }
        }
        private async Task HandleInput(KeyboardEventArgs args)
        {
            if (args.Key.Equals("Enter"))
            {
                await Send();
            }
        }
        public bool IsConnected => hubConnection?.State == HubConnectionState.Connected;
        public async ValueTask DisposeAsync()
        {
            await hubConnection.DisposeAsync();
        }
    }
}
