using HorizonPollyC.Models.UserManagement;
using System.Net.Http.Json;

namespace HorizonPollyC.Services.UserManagement
{
    public class UserManagementService: IUserManagementService
    {
        string BaseURISCV;
        HttpClient httpClient;
        private readonly IConfiguration _configuration;

        public UserManagementService(HttpClient httpClient, IConfiguration configuration)
        {

            this.httpClient = httpClient;
            _configuration = configuration;

            BaseURISCV = _configuration["BaseURLUserManagement"];
        }

        public async Task<IEnumerable<Features>> GetFeatures()
        {
            string URL = BaseURISCV + "/GetFeautures";

            //var result = await httpClient.GetFromJsonAsync<List<Features>>(URL);
            var result = await httpClient.PostAsJsonAsync(URL,"");
            List<Features> Features = result.Content.ReadFromJsonAsync<List<Features>>().Result;
            return Features;
        }

        public async Task<IEnumerable<Features>> GetRoleFeatures(string RoleID)
        {
            string URL = BaseURISCV + "/GetRoleFeatures?RoleID="+RoleID;

            List<Features> Features = await httpClient.GetFromJsonAsync<List<Features>>(URL);
            return Features;
        }

        public async Task<IEnumerable<Roles>> GetRoles()
        {
            string URL = BaseURISCV + "/GetRoles";

            var result = await httpClient.PostAsJsonAsync(URL, "");
            List<Roles> roles = result.Content.ReadFromJsonAsync<List<Roles>>().Result;
            return roles;
        }
        public async Task<IEnumerable<UserRoles>> GetUserRoles(string UserName)
        {
            string URL = BaseURISCV + "/GetUserRoles";

            var result = await httpClient.PostAsJsonAsync(URL, UserName);
            List<UserRoles> userRoles = result.Content.ReadFromJsonAsync<List<UserRoles>>().Result;
            return userRoles;
        }



        public async Task<IEnumerable<Features>> GetUsersFeatures(string UserName)
        {
            string URL = BaseURISCV + "/GetUsersFeatures";

            var result = await httpClient.PostAsJsonAsync(URL, UserName);
            List<Features> Features = result.Content.ReadFromJsonAsync<List<Features>>().Result;
            return Features;

        }

        public async Task CreateUpdateFeature(Features model)
        {
            string URL = BaseURISCV + "/CreateUpdateFeature";
            var result = await httpClient.PostAsJsonAsync(URL, model);
        }

        public async Task CreateUpdateRole(Roles model)
        {
            string URL = BaseURISCV + "/CreateUpdateRole";
            var result = await httpClient.PostAsJsonAsync(URL, model);
        }
        public async Task AddRoleFeature(RoleFeature model)
        {
            string URL = BaseURISCV + "/AddRoleFeature";
            var result = await httpClient.PostAsJsonAsync(URL, model);
        }

        public async Task AddUserFeature(UserFeature model)
        {
            string URL = BaseURISCV + "/AddUserFeature";
            var result = await httpClient.PostAsJsonAsync(URL, model);
        }

        public async Task DeleteFeature(int ID)
        {
            string URL = BaseURISCV + "/DeleteFeature?ID=" + ID;
            var result = await httpClient.DeleteAsync(URL);
        }

        public async Task DeleteRole(int ID)
        {
            string URL = BaseURISCV + "/DeleteRole?ID=" + ID;
            var result = await httpClient.DeleteAsync(URL);
        }

        public async Task DeleteUserFeature(int ID, string UserID)
        {
            string URL = BaseURISCV + "/DeleteUserFeature?ID=" + ID;
            var result = await httpClient.DeleteAsync(URL);
        }

        public async Task DeleteRoleFeature(int ID, int RoleID)
        {
            string URL = BaseURISCV + "/DeleteRoleFeature?ID=" + ID+ "&RoleID="+RoleID;
            var result = await httpClient.DeleteAsync(URL);
        }



    }
}
