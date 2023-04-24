using HorizonPollyC.Models.Configuration;
using HorizonPollyC.Pages.Configuration;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.Configuration
{
    public class MovementService : IMovementService
    {
        private readonly HttpClient httpClient;
        private readonly IConfiguration _configuration;
        string BaseURIConfig;
        public MovementService(HttpClient client, IConfiguration Configuration)
        {
            httpClient = client;
            _configuration = Configuration;
            BaseURIConfig = _configuration["BaseURLConfig"];
        }
        public async Task<IEnumerable<MovementVM>> GetMovements()
        {
            var result = await httpClient.GetFromJsonAsync<IEnumerable<MovementVM>>(BaseURIConfig + "movement/movements");
            return result;
        }

        public async Task<string> SaveMovement(MovementVM movement)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "movement/savemovement", movement);
            return result.ToString();
        }

        public async Task<string> UpdateMovement(MovementVM movement)
        {
            var result = await httpClient.PostAsJsonAsync(BaseURIConfig + "movement/updatemovement", movement);
            return result.ToString();
        }
    }
}
